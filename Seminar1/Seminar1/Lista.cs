using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar1
{
    public class Lista:IEnumerable
    {
        public class nod
        {
            object inf;
            public nod next;
            public nod(object k,nod urm)
            {
                inf = k;
                next = urm;
            }

            public object Informatie
            {
                get
                {
                    return this.inf;
                }
                set
                {
                    this.inf = value;
                }
            }
           
        }
        nod cap;
        protected uint nrnoduri;
        public Lista()
        {
            cap = null;
            nrnoduri = 0;
        }
        public void AdaugareNod(object k)
        {
            nod temp = new nod(k, cap);
            nrnoduri++;
            cap = temp;
        }

        public IEnumerator GetEnumerator()
        {
            if(nrnoduri == 0)
            {
                return null;
            } else
            {
                return new ListEnum(cap);
            }
        }
    }
}
