using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar3
{
   public class Observabil_Impl : IObservabil
    {
        public Observabil_Impl()
        {

        }
        protected List<IObservator> listaObservatori = new List<IObservator>();
        public void Cupleaza(IObservator observator)
        {
            listaObservatori.Add(observator);
        }

        public void Decupleaza(IObservator observator)
        {
            listaObservatori.Remove(observator);
        }
    }
}
