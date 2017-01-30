using System;
using System.Collections;

namespace Seminar1
{
    class ListEnum : IEnumerator
    {
        Lista.nod aux,init;
        bool vb;
        public ListEnum(Lista.nod ccp)
        {
            aux = init = ccp;
            vb = true;
        }

        public object Current
        {
            get
            {
                return this.aux.Informatie;
            }
        }

        public bool MoveNext()
        {
            if(aux == init && vb)
            {
                vb = false;
                return true;
            }
            if(aux.next != null)
            {
                aux = aux.next;
                return true;
            }else
            {
                return false;
            }
        }

        public void Reset()
        {
            aux = init;
            vb = true;
        }
    }
}