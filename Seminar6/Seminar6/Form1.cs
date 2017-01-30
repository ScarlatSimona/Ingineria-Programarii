using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminar6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.Load("ReflectionDemo");
            ResourceManager manager = new ResourceManager("ReflectionDemo.Resource1", assembly);
            string sir = manager.GetString("s1");
            MessageBox.Show(sir);

        }
    }
}
