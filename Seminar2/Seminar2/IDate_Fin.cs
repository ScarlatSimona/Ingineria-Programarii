using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar2
{
    public interface IDate_Fin
    {
        string Iban { get; set; }
        void Depune(DateTime dataDepunere, int suma);
        void Extrage(DateTime dataExtragere, int suma);
        int GetSold();
    }
}
