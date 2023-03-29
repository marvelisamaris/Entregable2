using System;
using System.Collections.Generic;

class Ingrediente
{
    public string NombreIngrediente;
    public int Cantidad;
    public double Precio;
}

class Pastel : Ingrediente
{
    public string NombrePastel;
    public string TamañoPastel;

    public Pastel(string nombrePastel, string tamañoPastel, string nombreIngrediente, int cantidad, double precio)
    {
        NombrePastel = nombrePastel;
        TamañoPastel = tamañoPastel;
        NombreIngrediente = nombreIngrediente;
        Cantidad = cantidad;
        Precio = precio;
    }

    public double CalcularCosto()
    {
        return Cantidad * Precio;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Ingrediente> ingredientes = new List<Ingrediente>();
        List<Pastel> pasteles = new List<Pastel>();

        while (true)
        {
            Console.WriteLine("=== Pastelería ===");
            Console.WriteLine("1. Listar ingredientes");
            Console.WriteLine("2. Agregar un nuevo ingrediente");
            Console.WriteLine("3. Calcular el valor total del pastel");

            Console.Write("Ingrese una opción: ");
            int opcion = int.Parse(Console.ReadLine());
            Console.WriteLine();

            if (opcion == 1)
            {
                Console.WriteLine("=== Ingredientes ===");
                foreach (Ingrediente ingrediente in ingredientes)
                {
                    Console.WriteLine($"- {ingrediente.NombreIngrediente} ({ingrediente.Cantidad} unidades, ${ingrediente.Precio} cada una)");
                }
                Console.WriteLine();
            }
            else if (opcion == 2)
            {
                Ingrediente ingrediente = new Ingrediente();

                Console.Write("Ingrese el nombre del ingrediente: ");
                ingrediente.NombreIngrediente = Console.ReadLine();

                Console.Write("Ingrese la cantidad disponible del ingrediente: ");
                ingrediente.Cantidad = int.Parse(Console.ReadLine());

                Console.Write("Ingrese el precio del ingrediente: $");
                ingrediente.Precio = double.Parse(Console.ReadLine());

                ingredientes.Add(ingrediente);
                Console.WriteLine();
            }
            else if (opcion == 3)
            {
                Console.Write("Ingrese el nombre del pastel: ");
                string nombrePastel = Console.ReadLine();

                Console.Write("Ingrese el tamaño del pastel: ");
                string tamañoPastel = Console.ReadLine();

                double costoTotal = 0;

                while (true)
                {
                    Console.Write("Ingrese el nombre del ingrediente a agregar (o presione Enter para terminar): ");
                    string nombreIngrediente = Console.ReadLine();
                    if (nombreIngrediente == "") break;

                    Ingrediente ingrediente = ingredientes.Find(i => i.NombreIngrediente == nombreIngrediente);
                    if (ingrediente == null)
                    {
                        Console.WriteLine("El ingrediente no existe");
                        continue;
                    }

                    Console.Write($"Ingrese la cantidad de {nombreIngrediente}: ");
                    int cantidad = int.Parse(Console.ReadLine());

                    Pastel pastel = new Pastel(nombrePastel, tamañoPastel, nombreIngrediente, cantidad, ingrediente.Precio);
                    pasteles.Add(pastel);

                    costoTotal += pastel.CalcularCosto();
                }

                Console.WriteLine($"El costo total del pastel es: ${costoTotal}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Opción inválida");
                Console.WriteLine();
            }
        }
    }
}