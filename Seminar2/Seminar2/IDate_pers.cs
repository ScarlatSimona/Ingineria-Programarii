using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar2
{
    public interface IDate_pers
    {
        string Nume { get; set; }
        void  SetDataNasterii(int year, int month, int day);
        int GetVarsta();
    }
}
