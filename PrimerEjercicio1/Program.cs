using System.ComponentModel.Design;

namespace PrimerEjercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuPpal();
        }


        static void MenuPpal()
        {
            Console.WriteLine("PRUEBAS MONOPLAZA");
            Console.WriteLine("1. Nuevo Circuito");
            Console.WriteLine("2. Salir");
            Console.Write("Selecione una opción: ");

            int nOpcion = 0;
            int.TryParse(Console.ReadLine(), out nOpcion);
            if (nOpcion == 0 || nOpcion > 2)
            {
                Console.WriteLine("La opcion no es valida");
                MenuPpal();
            }
            else
            {
                switch (nOpcion)
                {
                    case 1:
                        MenuCircuito(new Circuito());
                        break;
                    case 2:
                        Environment.Exit(0);
                        break;
                }
            }

        }

        static void MenuCircuito(Circuito pCircuito)
        {
            Console.WriteLine($"CIRCUITO: {pCircuito.Nombre} ({pCircuito.Vueltas} Vueltas)");
            Console.WriteLine("1. Agregar Monoplaza");
            Console.WriteLine("2. Retirar Monoplaza");
            Console.WriteLine("3. Realizar Prueba");
            Console.WriteLine("4. Finalizar Circuito");
            Console.Write("Selecione una opción: ");

            int nOpcion = 0;
            int.TryParse(Console.ReadLine(), out nOpcion);
            if (nOpcion == 0 || nOpcion > 4)
            {
                Console.WriteLine("La opcion no es valida");
                MenuCircuito(pCircuito);
            }
            else
            {
                switch (nOpcion)
                {
                    case 1:
                        pCircuito.AgregarMonoPlaza(MenuMonoplaza());
                        Console.Clear();
                        MenuCircuito(pCircuito);
                        break;
                    case 2:
                        pCircuito.SacarMonoPlaza();
                        MenuCircuito(pCircuito);
                        break;
                    case 3:
                        pCircuito.RealizarPrueba();
                        MenuCircuito(pCircuito);
                        break;
                    case 4:
                        if (pCircuito.Finalizar())
                            MenuPpal();
                        else
                            MenuCircuito(pCircuito);

                        break;
                }
            }

        }

        static IMonoplaza MenuMonoplaza()
        {
            Console.WriteLine("ESCUDERÍA: ");
            Console.WriteLine("1. McLaren");
            Console.WriteLine("2. Ferrari");
            Console.WriteLine("3. RedBull");
            Console.Write("Selecione una escudería: ");

            int nOpcion = 0;
            int.TryParse(Console.ReadLine(), out nOpcion);
            if (nOpcion == 0 || nOpcion > 3)
            {
                Console.WriteLine("La opcion no es valida");
                return MenuMonoplaza();
            }
            else
            {
                switch (nOpcion)
                {
                    case 1:
                        return new McLaren();
                    case 2:
                        return new Ferrari();
                    case 3:
                        return new RedBull();
                    default:
                        return MenuMonoplaza();
                }
            }
        }



    }
}