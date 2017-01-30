using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar2
{
    public class Operatie_Bancara
    {
        DateTime dataOp;
        public int suma;
        public char tip;
        public Operatie_Bancara()
        {

        }
        public Operatie_Bancara(DateTime _dataOp, int _suma, char _tip)
        {
            dataOp = new DateTime(_dataOp.Year, _dataOp.Month, _dataOp.Day);
            suma = _suma;
            tip = _tip;
        }
    }
}
