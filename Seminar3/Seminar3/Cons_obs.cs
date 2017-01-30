using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar3
{
    public class Cons_obs : IObservator
    {
        public Cons_obs()
        {

        }
        public void Notificare()
        {
            Console.WriteLine("Element modificat");
        }

        public void SchimbaEl()
        {
            Console.WriteLine("Element modificat");
        }
    }
}
