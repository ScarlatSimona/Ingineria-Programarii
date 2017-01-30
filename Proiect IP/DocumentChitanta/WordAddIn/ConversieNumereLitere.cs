using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace WordAddIn
{
    public partial class ConversieNumereLitere
    {
        private void ConversieNumereLitere_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void btnExecutaConversie_Click(object sender, RibbonControlEventArgs e)
        {
            Form1 frmConversie = new Form1();
            frmConversie.ShowDialog();
        }

        private void btnGenerareNr_Click(object sender, RibbonControlEventArgs e)
        {
            Random randomNumber = new Random();
            int nrChitanta = randomNumber.Next(100000000, 900000000);
            Globals.ThisAddIn.Application.ActiveDocument.Activate();
            Globals.ThisAddIn.Application.ActiveDocument.FormFields["tbxNrChitanta"].Result = nrChitanta.ToString();
        }
    }
}
