using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerEjercicio1
{

    public abstract class Monoplaza : IMonoplaza
    {
        public string Escuderia { get; set; }
        public string Nombre { get; set; }
        bool start, moving;

        public void Encender()
        {
            if (!start)
            {
                start = true;
                Console.WriteLine($"El carro {Nombre} esta encendido.");
            }
            else
                Console.WriteLine($"El carro {Nombre} Esta encendido.");
        }

        public void Apagar()
        {
            if (start)
            {
                if (!moving)
                {
                    start = false;
                    Console.WriteLine($"El carro {Nombre} apagado.");
                }
                else
                    Console.WriteLine($"No se puede apagar el carro {Nombre}, está en movimiento.");
            }
            else
                Console.WriteLine($"El carro {Nombre} esta apagado.");
        }

        public void Detener()
        {
            if (start)
            {
                if (moving)
                {
                    moving = false;
                    Console.WriteLine($"El Carro {Nombre} esta detenido.");
                }
                else
                    Console.WriteLine($"El Carro {Nombre}, no está en movimiento.");
            }
            else
                Console.WriteLine($"El Carro {Nombre} se encuentra apagado.");

        }

        public void Movimiento()
        {
            if (start)
            {
                if (!moving)
                {
                    moving = true;
                    Console.WriteLine($"El carro {Nombre} puesto en movimiento.");
                }
                else
                    Console.WriteLine($"El carro {Nombre}, Esta encuentra en movimiento.");
            }
            else
                Console.WriteLine($"El carro {Nombre} esta encuentra apagado.");

        }

    }


}