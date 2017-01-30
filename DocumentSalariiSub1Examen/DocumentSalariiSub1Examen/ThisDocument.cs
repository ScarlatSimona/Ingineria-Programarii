using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Office.Tools.Word;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
namespace DocumentSalariiSub1Examen
{
    public partial class ThisDocument
    {
        Button btnPreluare;
        Button btnFinalizare;
        int rand = 0;
        Excel.Application xlApp;
        
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        private void ThisDocument_Startup(object sender, System.EventArgs e)
        {
            btnPreluare = new Button();
            btnPreluare.Text = "Preluare date";
            btnPreluare.Click += new EventHandler(btnPreluare_Click);
            btnFinalizare = new Button();
            btnFinalizare.Text = "Finalizare";
            btnFinalizare.Click += new EventHandler(btnFinalizare_Click);
            Globals.ThisDocument.ActionsPane.Controls.Add(btnPreluare);
            Globals.ThisDocument.ActionsPane.Controls.Add(btnFinalizare);
            
           
            object misValue = System.Reflection.Missing.Value;
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlWorkSheet.Cells[rand + 1, 1] = "Nume";
            xlWorkSheet.Cells[rand + 1, 2] = "Sex";
            xlWorkSheet.Cells[rand + 1, 3] = "Nr ore lucrate";
            xlWorkSheet.Cells[rand + 1, 4] = "Salariu orar";
            
        }
        private void btnFinalizare_Click(object sender,EventArgs e)
        {
            //Word._Document document = this.Application.ActiveDocument;
            //document.Close(Word.WdSaveOptions.wdDoNotSaveChanges);
            
            double fondSalarii = 0;
            for(int i=2;i<=rand+1;i++)
            {
                var nrOre = (double)(xlWorkSheet.Cells[i, 3] as Excel.Range).Value;
                var salariuOrar =(double) (xlWorkSheet.Cells[i, 4] as Excel.Range).Value;
                fondSalarii = fondSalarii + nrOre * salariuOrar;
            }
            rand += 1;
            xlWorkSheet.Cells[rand + 1, 5] = fondSalarii;
            this.Application.Quit();

        }

        private void btnPreluare_Click(object sender, EventArgs e)
        {
            Salariat salariat = new Salariat();
            salariat.Nume = tbxNumeSalariat.Text;
            salariat.Sex = ddlSexSalariat.Text;
            salariat.NrOreLucrate = Int32.Parse(tbxNrOreLucrate.Text);
            salariat.SalariuOrar = Decimal.Parse(tbxSalariuOrar.Text);

            xlApp.Visible = true;

            rand += 1;
            xlWorkSheet.Cells[rand + 1, 1] = salariat.Nume;
            xlWorkSheet.Cells[rand + 1, 2] = salariat.Sex;
            xlWorkSheet.Cells[rand + 1, 3] = salariat.NrOreLucrate;
            xlWorkSheet.Cells[rand + 1, 4] = salariat.SalariuOrar;

            
        }
        private void ThisDocument_Shutdown(object sender, System.EventArgs e)
        {
           
        }

        #region VSTO Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisDocument_Startup);
            this.Shutdown += new System.EventHandler(ThisDocument_Shutdown);
        }

        #endregion
    }
}
