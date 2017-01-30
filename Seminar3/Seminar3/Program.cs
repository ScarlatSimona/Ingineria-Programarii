using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar3
{
    class Program
    {
        static void Main(string[] args)
        {
            Cons_obs ob1 = new Cons_obs();
            Cons_obs ob2 = new Cons_obs();

            Element2 element = new Element2();
            Form1 form1 = new Form1(element);
            //element.Cupleaza(ob1);
            //element.Cupleaza(ob2);
            //element.Cupleaza(form1);
            //element.Valoare = 50;
            element.SchimbaEl += new Element2.DElement(ob1.SchimbaEl);
            element.SchimbaEl += new Element2.DElement(ob2.SchimbaEl);
            element.SchimbaEl += new Element2.DElement(form1.SchimbaEl);
            element.Valoare = 100;
            form1.ShowDialog();
        }
    }
}
