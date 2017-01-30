using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar3
{
    public class Element2:Cons_obs
    {
        public Element2()
        {

        }
        //delegate <=> pointer la functie
        public delegate void DElement();
        //event <=> proprietate asociata unui delegat
        public event DElement SchimbaEl;

        int element;

        public int Valoare
        {
            get
            {
                return element;
            }
            set
            {
                if(element != value)
                {
                    element = value;
                    if(SchimbaEl != null)
                    {
                        SchimbaEl();
                    }
                }
            }
        }
    }
}
