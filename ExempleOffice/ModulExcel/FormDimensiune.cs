using System;
using System.Windows.Forms;

namespace ModulExcel
{
    public partial class FormDimensiune : Form
    {
        public FormDimensiune()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public int Dimensiune
        {
            get
            {
                return Math.Max(1, (int)numDimensiune.Value);
            }
        }
    }
}
