using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordAddIn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private string ConvertesteSuma(int suma)
        {
            string sumaLitere = "[";
            string[] cifre = { "zero", "un", "doi", "trei", "patru", "cinci", "sase", "sapte", "opt", "noua" };
            string[] cifreGenF = { "zero", "o", "doua", "trei", "patru", "cinci", "sase", "sapte", "opt", "noua" };
            string[] cifreZeci = { "zece", "unsprezece", "doisprezece", "treisprezece", "paisprezece", "cincisprezece", "saisprezece", "saptesprezece", "optsprezece", "nouasprezece" };
            int sute=0;
            if (suma >= 100)
            {
                sute = Convert.ToInt32(suma / 100);
                if(sute != 1)
                {
                    sumaLitere += cifreGenF[sute%10] + " sute";
                }else
                {
                    sumaLitere += "o suta";
                }
                suma = suma%100;
            }
            else
            {
                sumaLitere = "";
            }
            if(suma >= 10 && suma<=19)
            {
                sumaLitere += " " + cifreZeci[suma - 10];
            } else if(suma >= 10)
            {
                int zeci = 0;
                zeci = Convert.ToInt32(suma/10);
                sumaLitere += " " + cifreGenF[zeci % 10] + "zeci";
                if(suma%10 > 0)
                {
                    sumaLitere += " si";
                }
                suma = suma % 10;
            }
            if(suma > 0)
            {
                sumaLitere += " " + cifre[suma % 10];
            }
            sumaLitere += " lei]";
            return sumaLitere;
        }

        private void btnTransforma_Click(object sender, EventArgs e)
        {
            int suma = Convert.ToInt32(tbxSuma.Text);
            tbxSumaLitere.Text = ConvertesteSuma(suma);

        }

        private void tbxSumaLitere_TextChanged(object sender, EventArgs e)
        {
            Globals.ThisAddIn.Application.ActiveDocument.Activate();
            Globals.ThisAddIn.Application.ActiveDocument.FormFields["tbxSumaText"].Result= tbxSumaLitere.Text;
        }
    }
}
