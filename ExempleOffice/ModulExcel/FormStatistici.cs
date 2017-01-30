using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;

namespace ModulExcel
{
    public partial class FormStatistici : Form
    {
        Excel.Worksheet currentSheet = null;

        public FormStatistici()
        {
            InitializeComponent();

            TopMost = true;

            if (Globals.ThisAddIn.Application.ActiveSheet != null)
            {
                currentSheet = Globals.ThisAddIn.Application.ActiveSheet;
                currentSheet.SelectionChange += CurrentSheet_SelectionChange;
                lblTitle.Text = currentSheet.Name;
            }

            Globals.ThisAddIn.Application.SheetDeactivate += (sh) =>
            {
                if (currentSheet != null)
                    currentSheet.SelectionChange -= CurrentSheet_SelectionChange;

                lblTitle.Text = "-";
            };

            Globals.ThisAddIn.Application.SheetActivate += (sh) =>
            {
                currentSheet = sh as Excel.Worksheet;
                currentSheet.SelectionChange += CurrentSheet_SelectionChange;
                lblTitle.Text = currentSheet.Name;
            };
        }

        private void CurrentSheet_SelectionChange(Excel.Range range)
        {
            var sb = new StringBuilder();
            var total = 0m;
            for (int linie = 1; linie <= range.Cells.Rows.Count; linie++)
            {
                for (int coloana = 1; coloana <= range.Cells.Columns.Count; coloana++)
                {
                    var cell = range.Cells[linie, coloana] as Excel.Range;
                    if (cell.Value2 != null)
                    {
                        sb.Append(cell.Value2.ToString() + "  ");
                        try { total += (decimal)cell.Value2; } catch { }
                    }
                }
                sb.AppendLine();
            }

            sb.Insert(0, "TOTAL: " + total.ToString("0.00") 
                + Environment.NewLine + Environment.NewLine);

            txtStatistici.Text = sb.ToString();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
