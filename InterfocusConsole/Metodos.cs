using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfocusConsole
{
    public class Metodos
    {
        public static void IsPar(int numero)
        {
            if (numero % 2 == 0)
            {
                Console.WriteLine("{0} é par", numero);
            }
            else
            {
                Console.WriteLine("{0} é impar", numero);
            }
        }

        public void PrintarLista(List<string> lista)
        {
            var i = 1;
            foreach (var item in lista)
            {
                Console.WriteLine("{0}) {1}", i++, item);
            }
        }
    }
}
