using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar3
{
    class Element:Observabil_Impl
    {
        int element;
        public int Valoare
        {
            get { return element; }
            set
            {
                if(element!=value)
                {
                    element = value;
                    foreach(IObservator obs in listaObservatori)
                    {
                        obs.Notificare();
                    }
                }
            }
        }
    }
}
