using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar2
{
    class Program
    {
        static void Main(string[] args)
        {
            IDate_Fin df = new Cont(100);
            IDate_pers dp = new Cont(200);
            Console.WriteLine(df.GetSold());
            dp.SetDataNasterii(1993, 11, 06);
            dp.Nume = "Simona";
            df.Iban = "jhjhjhjnh";
            df.Depune(DateTime.Now, 100);
            df.Extrage(DateTime.Now, 50);
            Console.WriteLine(df.GetSold());     
        }
    }
}
