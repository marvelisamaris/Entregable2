using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerEjercicio1
{
    public class Ferrari : Monoplaza
    {
        public Ferrari()
        {
            Escuderia = Escuderias.Ferrari.ToString();
            while (string.IsNullOrWhiteSpace(Nombre))
            {
                Console.Write("Nombre del monoplaza Ferrari ");
                Nombre = Console.ReadLine();
            }
        }

    }
}