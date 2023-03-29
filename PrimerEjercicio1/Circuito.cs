using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerEjercicio1
{
    class Circuito
    {
        public string Nombre { get; set; }
        public int Vueltas { get; set; }
        IMonoplaza? Monoplaza { get; set; }

        Dictionary<string, long> TablaResultados = new Dictionary<string, long>();

        public Circuito()
        {
            while (string.IsNullOrWhiteSpace(Nombre))
            {
                Console.Write("Nombre del Circuito");
                Nombre = Console.ReadLine();
            }
            int nVueltas = 0;
            while (nVueltas == 0)
            {
                Console.Write("Cantidad de vueltas ");
                int.TryParse(Console.ReadLine(), out nVueltas);
            }
            Vueltas = nVueltas;

        }

        public void AgregarMonoPlaza(IMonoplaza car)
        {
            if (this.Monoplaza == null)
                this.Monoplaza = car;
        }

        public void SacarMonoPlaza()
        {
            if (this.Monoplaza != null)
                this.Monoplaza = null;
        }


        public void RealizarPrueba()
        {
            if (this.Monoplaza == null)
            {
                Console.WriteLine($"No hay un monoplaza en el circuito");
            }
            else
            {
                string nKeyMonoplaza = $"{this.Monoplaza.Escuderia} - {this.Monoplaza.Nombre}";
                if (this.TablaResultados.Any(p => p.Key == nKeyMonoplaza))
                {
                    Console.WriteLine($"Prueba realizada a este monoplaza ({nKeyMonoplaza})");
                    return;
                }


                this.Monoplaza.Encender();
                long nBestTime = 999999;
                Console.WriteLine();
                Console.WriteLine($"Iniciando prueba  {this.Monoplaza.Nombre} - {this.Monoplaza.Escuderia}");
                this.Monoplaza.Movimiento();
                for (int i = 1; i <= this.Vueltas; i++)
                {

                    long nTime = new Random().Next(100000, 999999);
                    Console.WriteLine($"Vuelta {i} - Tiempo: {nTime}");
                    if (nTime < nBestTime)
                        nBestTime = nTime;
                }

                this.Monoplaza.Detener();
                Console.WriteLine($"Finalizada prueba {this.Monoplaza.Nombre} - {this.Monoplaza.Escuderia}");
                Console.WriteLine($"Mejor tiempo: {nBestTime}");

                this.Monoplaza.Apagar();
                this.TablaResultados.Add(nKeyMonoplaza, nBestTime);
                Console.WriteLine();
            }
        }


        public bool Finalizar()
        {
            if (this.Monoplaza != null)
            {
                Console.WriteLine($"Hay un monoplaza");
                return false;
            }

            Console.WriteLine();
            Console.WriteLine($"Circuito {this.Nombre} Finalizado.");
            Console.WriteLine();
            Console.WriteLine($"Posiciones:");
            var TablaPosiciones = TablaResultados.OrderBy(p => p.Value);
            if (TablaPosiciones.Any())
            {
                Console.WriteLine("----------------------------------------------------------");
                int nPos = 1;
                foreach (var item in TablaPosiciones)
                {
                    Console.WriteLine($"| {nPos.ToString().PadRight(4)} | {item.Key.Trim().PadRight(30)} | Tiempo: {item.Value} |");
                    Console.WriteLine("----------------------------------------------------------");
                    nPos++;
                }
            }
            else
                Console.WriteLine("NO se realizó prueba en el circuito");

            return true;
        }
    }
}