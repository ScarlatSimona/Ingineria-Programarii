using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar1
{
    class Program
    {
        static void Main(string[] args)
        {
            Lista l = new Lista();
            l.AdaugareNod(100);
            l.AdaugareNod(200);
            l.AdaugareNod(300);
            try
            {
                foreach(int k in l)
                {
                    Console.WriteLine(k);
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
    }
}
