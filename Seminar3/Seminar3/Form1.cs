using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminar3
{
    public partial class Form1 : Form, IObservator
    {
        Element2 elem = null;
        public Form1(object _elem)
        {
            InitializeComponent();
            elem = (Element2)_elem;
        }

        public void SchimbaEl()
        {
            mes.Text += "Element modificat" + Environment.NewLine;
        }

        public void Notificare()
        {
            mes.Text += "Element modificat"+Environment.NewLine;
        }

        void Actiune(object sender, EventArgs e)
        {
            label1.Visible = !label1.Visible;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Timer t = new Timer();
            t.Interval = 300;
            t.Tick += new EventHandler(Actiune);
        }

        private void setVal_Click(object sender, EventArgs e)
        {
            elem.Valoare = Convert.ToInt32(tVal.Text);
        }
    }
}
