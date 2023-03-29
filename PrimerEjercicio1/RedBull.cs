using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerEjercicio1
{
    public class RedBull : Monoplaza
    {
        public RedBull()
        {
            Escuderia = Escuderias.RedBull.ToString();
            while (string.IsNullOrWhiteSpace(Nombre))
            {
                Console.Write("Nombre del Redbull ");
                Nombre = Console.ReadLine();
            }
        }

    }
}