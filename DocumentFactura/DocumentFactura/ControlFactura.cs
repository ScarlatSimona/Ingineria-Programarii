using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
namespace DocumentFactura
{
    public partial class ControlFactura : UserControl
    {
        object parola = "mirel";
        object tipProtectie = Word.WdProtectionType.wdAllowOnlyFormFields;
        object lipsa = Type.Missing;

        public class Produs
        {
            public decimal Pret { get; set; }
            public string Denumire { get; set; }
            public string Um { get; set; }
            public override string ToString()
            {
                return string.Format("{0} ({1:0.00} lei", this.Denumire, this.Pret);
            }
        }

        List<Produs> produse = new List<Produs>
            { 
                new Produs() { Denumire="Mere",Pret=2.45m,Um="kg" },
                new Produs() { Denumire="Pere",Pret=5m,Um="kg" }
            };
        Word.Table tabel;
        
        public ControlFactura()
        {
            InitializeComponent();
            foreach(Produs produs in produse)
            {
                this.comboBox1.Items.Add(produs);
            }
            this.comboBox1.SelectedIndex = 0;
            tabel = Globals.ThisDocument.Tables[3];

            Globals.ThisDocument.Protect(Word.WdProtectionType.wdAllowOnlyFormFields, ref lipsa, ref parola, ref lipsa, ref lipsa);
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        void Recalculare()
        {
            decimal total = 0, tva = 0;
            for(int i = 3;i<tabel.Rows.Count - 2; i++)
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

        private void button1_Click(object sender, EventArgs e)
        {
            Globals.ThisDocument.Unprotect(ref parola);
            var produs = this.comboBox1.SelectedItem as Produs;

            var rand = tabel.Rows.Add(BeforeRow: tabel.Rows[tabel.Rows.Count-2]);
            rand.Cells[2].Range.Text = produs.Denumire;
            rand.Cells[3].Range.Text = produs.Um;
            rand.Cells[4].Range.Text = numericUpDown1.Value.ToString("0.00");
            rand.Cells[5].Range.Text = produs.Pret.ToString("0.00");
            Recalculare();
            Globals.ThisDocument.Protect(Word.WdProtectionType.wdAllowOnlyFormFields, ref lipsa, ref parola, ref lipsa, ref lipsa);
        }
    }
}
