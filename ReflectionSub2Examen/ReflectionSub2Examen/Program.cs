using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionSub2Examen
{
    class Program
    {
        static void AfisareCampuriProprietati(object obj)
        {
            Type t = obj.GetType();
            foreach(FieldInfo camp in t.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                Console.WriteLine("Denumire camp: {0} | Tip: {1} | Valoare: {2}", camp.Name, camp.FieldType,camp.GetValue(obj));
            }
            foreach(PropertyInfo proprietate in t.GetProperties())
            {
                
                Console.WriteLine("Denumire proprietate: {0} | Tip returnat: {1} | Valoare: {2} ", proprietate.Name, proprietate.PropertyType, proprietate.GetValue(obj));
            }
        }
        static void Main(string[] args)
        {
            //Assembly asm = Assembly.Load("Seminar3");
            AfisareCampuriProprietati(Activator.CreateInstance(typeof(Seminar2.Cont),100));
        }
    }
}
