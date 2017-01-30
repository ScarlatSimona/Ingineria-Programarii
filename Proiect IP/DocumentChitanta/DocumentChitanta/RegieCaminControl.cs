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
using System.Data.OleDb;
using System.Drawing.Printing;

namespace DocumentChitanta
{
    public partial class RegieCaminControl : UserControl
    {
        public RegieCaminControl()
        {
            InitializeComponent();
        }


        private Student CautaStudent(string CNP)
        {
            Student stud = null;
            OleDbConnection connection = null;
            OleDbCommand comanda = null;
            try
            {
                connection = new OleDbConnection();
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;
Data Source=C:\Users\Mihai\Documents\Visual Studio 2015\Projects\DocumentChitanta\DocumentChitanta\bin\Debug\utils.accdb;Persist Security Info=False;";
                comanda = new OleDbCommand();
                comanda.Connection = connection;
                connection.Open();
                comanda.CommandText = "select * from [tblStudenti] where cnp='" + CNP + "'";
                OleDbDataReader reader = comanda.ExecuteReader();
                stud = new Student();
                while (reader.Read())
                {
                    stud.Cnp  = reader["cnp"].ToString();
                    stud.Nume = reader["Nume"].ToString();
                    stud.Adresa = reader["Adresa"].ToString();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return stud;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student stud = CautaStudent(tbxCNPStudent.Text);
            if (stud != null)
            {
                Globals.ThisDocument.FormFields["tbxNumeStudent"].Result = stud.Nume;
                Globals.ThisDocument.FormFields["tbxAdresaStudent"].Result = stud.Adresa;
                if (!tbxSumaPlatita.Equals(String.Empty))
                {
                    Globals.ThisDocument.FormFields["tbxSuma"].Result = tbxSumaPlatita.Text;
                }

                else
                {
                    errorProvider1.SetError(tbxSumaPlatita, "Va rugam sa introduceti suma de plata!");
                }
                Globals.ThisDocument.FormFields["tbxDataCurenta"].Result = DateTime.Now.ToShortDateString();
            }
            else
            {
                errorProvider1.SetError(tbxCNPStudent, "Va rugam sa introduceti CNP-ul studentului");
            }
            

        }

        private void tbxSumaPlatita_DoubleClick(object sender, EventArgs e)
        {
            Globals.ThisDocument.FormFields["tbxSuma"].Result = tbxSumaPlatita.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            object l = Type.Missing;
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "Fisier PDF (*.pdf) | *.pdf";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Globals.ThisDocument.ExportAsFixedFormat(
                        dialog.FileName,
                        Word.WdExportFormat.wdExportFormatPDF, false,
                        Word.WdExportOptimizeFor.wdExportOptimizeForPrint,
                        Word.WdExportRange.wdExportAllDocument, 1, 1,
                        Word.WdExportItem.wdExportDocumentWithMarkup, true, true,
                        Word.WdExportCreateBookmarks.wdExportCreateNoBookmarks,
                        true, true, false, ref l);

                    System.Diagnostics.Process.Start(dialog.FileName);
                }
            }
        }

        private void btnVizualizareStudenti_Click(object sender, EventArgs e)
        {
            Studenti form2 = new Studenti();
            form2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection connection= new OleDbConnection(); ;
            OleDbCommand comanda;
            try
            {
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;
Data Source=C:\Users\Mihai\Documents\Visual Studio 2015\Projects\DocumentChitanta\DocumentChitanta\bin\Debug\utils.accdb;Persist Security Info=False;";
                comanda = new OleDbCommand();
                comanda.Connection = connection;
                comanda.Parameters.AddWithValue("@cnp", tbxCNPStudent.Text);
                comanda.Parameters.AddWithValue("@suma", Convert.ToInt32(tbxSumaPlatita.Text));
                comanda.Parameters.AddWithValue("@dataPlatii", DateTime.Now.ToShortDateString());
                comanda.CommandText = "insert into [tblPlati] (cnp,Suma,DataPlatii) values (@cnp,@suma,@dataPlatii);";
                connection.Open();
                comanda.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Plata a fost inregistrata!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }finally
            {
                connection.Close();
            }
            tbxCNPStudent.Text = "";
            tbxSumaPlatita.Text = "";
        }
    }
}
