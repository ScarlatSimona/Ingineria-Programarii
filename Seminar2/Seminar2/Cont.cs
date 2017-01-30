using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar2
{
    public class Cont : IDate_pers, IDate_Fin
    {
        int soldInitial;
        string numePrenume, iban;
        DateTime data = new DateTime();
        List<Operatie_Bancara> listaOperatiiBancare = new List<Operatie_Bancara>();
        public Cont()
        {

        }
        public Cont(int _soldInitial)
        {
            soldInitial = _soldInitial;
        }
        string IDate_Fin.Iban
        {
            get
            {
                return iban;
            }

            set
            {
                iban = value;
            }
        }

        string IDate_pers.Nume
        {
            get
            {
                return numePrenume;
            }

            set
            {
                numePrenume = value;
            }
        }

        void IDate_Fin.Depune(DateTime dataDepunere, int suma)
        {
            listaOperatiiBancare.Add(new Operatie_Bancara(dataDepunere, suma, 'd'));
        }

        void IDate_Fin.Extrage(DateTime dataExtragere, int suma)
        {
            listaOperatiiBancare.Add(new Operatie_Bancara(dataExtragere, suma, 'r'));
        }

        int IDate_Fin.GetSold()
        {
            int sumaD=0, sumaR=0;
            foreach(Operatie_Bancara op in listaOperatiiBancare)
            {
                if(op.tip.Equals('d'))
                {
                    sumaD += op.suma;
                }else
                {
                    sumaR += op.suma;
                }
            }
            return soldInitial + sumaD - sumaR;
        }

        int IDate_pers.GetVarsta()
        {
            return DateTime.Now.Year - data.Year;
        }

        void IDate_pers.SetDataNasterii(int year, int month, int day)
        {
            data = DateTime.Parse(year.ToString() + "-" + month.ToString() + "-" + day.ToString());
        }
    }
}
