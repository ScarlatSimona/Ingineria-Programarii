using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Word = Microsoft.Office.Interop.Word;

namespace DocumentFactura
{
    public partial class ControlFactura : UserControl
    {
        object parola = "mirel";
        object tipProtectie = Word.WdProtectionType.wdAllowOnlyFormFields;
        object lipsa = Type.Missing;

        class Produs
        {
            public decimal Pret { get; set; }
            public string Denumire { get; set; }
            public string Um { get; set; }

            public override string ToString()
            {
                return string.Format("{0} ({1:0.00} lei)",
                    this.Denumire,
                    this.Pret);
            }
        }

        List<Produs> produse = new List<Produs> {
            new Produs() { Denumire="Mere", Pret = 2.45m, Um="kg"},
            new Produs() { Denumire="Pere", Pret = 5m , Um="kg"}
        };

        Word.Table tabel;

        public ControlFactura()
        {
            InitializeComponent();

            foreach (Produs produs in produse)
            {
                this.cmbProduse.Items.Add(produs);
            }
            this.cmbProduse.SelectedIndex = 0;

            tabel = Globals.ThisDocument.Tables[3];

            Globals.ThisDocument.SelectionChange += new Microsoft.Office.Tools.Word.SelectionEventHandler(ThisDocument_SelectionChange);

            Globals.ThisDocument.Protect(Word.WdProtectionType.wdAllowOnlyFormFields,
                ref lipsa, ref parola, ref lipsa, ref lipsa);

            Globals.ThisDocument.wdTxtClientNume.Exiting += WdTxtClientNume_Exiting;
        }

        private void WdTxtClientNume_Exiting(object sender, Microsoft.Office.Tools.Word.ContentControlExitingEventArgs e)
        {
            lblClient.Text = string.Format("Client: {0}", Globals.ThisDocument.wdTxtClientNume.Text);
        }

        private void btnAdauga_Click(object sender, EventArgs e)
        {
            Globals.ThisDocument.Unprotect(ref parola);
            var produs = this.cmbProduse.SelectedItem as Produs;

            var rand = tabel.Rows.Add(BeforeRow: tabel.Rows[tabel.Rows.Count - 2]);
            rand.Cells[2].Range.Text = produs.Denumire;
            rand.Cells[3].Range.Text = produs.Um;
            rand.Cells[4].Range.Text = numCantitate.Value.ToString("0.00");
            rand.Cells[5].Range.Text = produs.Pret.ToString("0.00");

            Recalculare();
            Globals.ThisDocument.Protect(Word.WdProtectionType.wdAllowOnlyFormFields,
                ref lipsa, ref parola, ref lipsa, ref lipsa);
        }

        private void btnStergeRand_Click(object sender, EventArgs e)
        {
            if (tabel.Rows.Count < 6)
            {
                return;
            }

            Globals.ThisDocument.Unprotect(ref parola);

            tabel.Rows[tabel.Rows.Count - 3].Delete();
            Recalculare();
            Globals.ThisDocument.Protect(Word.WdProtectionType.wdAllowOnlyFormFields,
                ref lipsa, ref parola, ref lipsa, ref lipsa);
        }

        void ThisDocument_SelectionChange(object sender, Microsoft.Office.Tools.Word.SelectionEventArgs e)
        {
            try
            {
                ;
                if (!e.Selection.Tables[1].Rows[1].Cells[1].Range.Text.StartsWith("Nr."))
                {
                    return;
                }

                int n = e.Selection.Cells[1].RowIndex;
                if (n > 2 && n < tabel.Rows.Count - 2)
                {
                    // utilizare rând selectat
                }
            }
            catch
            {
                // nu avem selectat un rând din tabel
            }
        }

        void Recalculare()
        {
            decimal total = 0, tva = 0;
            for (int i = 3; i < tabel.Rows.Count - 2; i++)
            {
                decimal pret = decimal.Parse(tabel.Rows[i].Cells[5].Range.Text.Replace("\r\a", string.Empty));
                decimal cantitate = decimal.Parse(tabel.Rows[i].Cells[4].Range.Text.Replace("\r\a", string.Empty));
                total += (pret * cantitate * 1.24m);
                tva += (pret * cantitate * 0.24m);

                tabel.Rows[i].Cells[1].Range.Text = (i - 2).ToString();
                tabel.Rows[i].Cells[6].Range.Text = (pret * cantitate * 1.24m).ToString("0.00");
                tabel.Rows[i].Cells[7].Range.Text = (pret * cantitate * 0.24m).ToString("0.00");
            }

            tabel.Rows[tabel.Rows.Count - 1].Cells[6].Range.Text = total.ToString("0.00");
            tabel.Rows[tabel.Rows.Count - 1].Cells[7].Range.Text = tva.ToString("0.00");

        }

        private void btnSalvare_Click(object sender, EventArgs e)
        {

            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "Fișier PDF (*.pdf) | *.pdf";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Globals.ThisDocument.ExportAsFixedFormat(
                        dialog.FileName,
                        Word.WdExportFormat.wdExportFormatPDF, false,
                        Word.WdExportOptimizeFor.wdExportOptimizeForPrint,
                        Word.WdExportRange.wdExportAllDocument, 1, 1,
                        Word.WdExportItem.wdExportDocumentWithMarkup, true, true,
                        Word.WdExportCreateBookmarks.wdExportCreateNoBookmarks,
                        true, true, false, ref lipsa);

                    System.Diagnostics.Process.Start(dialog.FileName);
                }
            }
        }
    }
}
