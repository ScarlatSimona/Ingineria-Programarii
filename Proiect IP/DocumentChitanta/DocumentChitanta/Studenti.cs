using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace DocumentChitanta
{
    public partial class Studenti : Form
    {
        List<Student> listaStudenti = new List<Student>();
        List<Student> listaRestantieri = new List<Student>();
        List<Plata> listaPlati = new List<Plata>();
        OleDbConnection connection;
        OleDbCommand comanda;
        string path = "";
        public Studenti()
        {
            InitializeComponent();
        }
       
        private void btnSendMail_Click(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("simonascarlat6@gmail.com");
            mail.To.Add("simonascarlat6@gmail.com");
            mail.Subject = "Lista Studenti Restantieri";
            mail.Body = "";

            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment(path);
            mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("simonascarlat6@gmail.com", "cibernetica");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
            MessageBox.Show("Mail-ul a fost trimis");

        }

        public List<Plata> CautaPlatiEfectuate()
        {
            connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;
Data Source=C:\Users\Mihai\Documents\Visual Studio 2015\Projects\DocumentChitanta\DocumentChitanta\bin\Debug\utils.accdb;Persist Security Info=False;";
            comanda = new OleDbCommand();
            comanda.Connection = connection;
            try
            {
                connection.Open();
                comanda.CommandText = "select * from [tblPlati]";
                OleDbDataReader reader = comanda.ExecuteReader();
                while (reader.Read())
                {
                    Plata plata = new Plata();
                    plata.Cnp = reader["Cnp"].ToString();
                    plata.Suma = Convert.ToInt32(reader["Suma"].ToString());
                    plata.DataPlatii = Convert.ToDateTime(reader["DataPlatii"].ToString());
                    listaPlati.Add(plata);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return listaPlati;
        }

        public List<Student> CautaTotiStudenti()
        {
            connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;
Data Source=C:\Users\Mihai\Documents\Visual Studio 2015\Projects\DocumentChitanta\DocumentChitanta\bin\Debug\utils.accdb;Persist Security Info=False;";
            comanda = new OleDbCommand();
            comanda.Connection = connection;
            try
            {
                connection.Open();
                comanda.CommandText = "select * from [tblStudenti]";
                OleDbDataReader reader = comanda.ExecuteReader();
                while (reader.Read())
                {
                    Student student = new Student();
                    student.Cnp = reader["cnp"].ToString();
                    student.Nume = reader["Nume"].ToString();
                    student.Camin = reader["Camin"].ToString();
                    student.Camera = Convert.ToInt32(reader["Camera"].ToString());
                    listaStudenti.Add(student);
                }
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
            return listaStudenti;
        }

        public List<Student> CautaStudentiRestantieri()
        {
            listaStudenti = CautaTotiStudenti();
            listaPlati = CautaPlatiEfectuate();
            foreach(Student stud in listaStudenti)
            {
                listaRestantieri.Add(stud);
            }
            foreach(Student stud  in listaStudenti)
            {
                foreach(Plata plata in listaPlati)
                {
                    if(stud.Cnp.Equals(plata.Cnp) && plata.DataPlatii.Month == DateTime.Now.Month)
                    {
                        listaRestantieri.Remove(stud);
                    }
                }
            }
            return listaRestantieri;
        }

        private void Studenti_Load(object sender, EventArgs e)
        {
            int n;
            listaRestantieri = CautaStudentiRestantieri();
            foreach(Student stud in listaRestantieri)
            {
                n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = stud.Nume;
                dataGridView1.Rows[n].Cells[1].Value = stud.Camin;
                dataGridView1.Rows[n].Cells[2].Value = stud.Camera;
            }
            
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            int i = 0;
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlWorkSheet.Cells[i + 1, 1] = "CNP";
            xlWorkSheet.Cells[i + 1, 2] = "Nume";
            xlWorkSheet.Cells[i + 1, 3] = "Camin";
            xlWorkSheet.Cells[i + 1, 4] = "Camera";
            i = i + 1;
            foreach (Student s in listaRestantieri)
            {
                xlWorkSheet.Cells[i + 1, 1] = s.Cnp;
                xlWorkSheet.Cells[i + 1, 2] = s.Nume;
                xlWorkSheet.Cells[i + 1, 3] = s.Camin;
                xlWorkSheet.Cells[i + 1, 4] = s.Camera;
                i++;
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Fisier XLS (*.xls) | *.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                path = sfd.FileName;
            }
            xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
        }
}
}
