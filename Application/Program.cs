using Core; // Importa el namespace donde se encuentra la clase Articulo
using System;
using System.Collections.Generic;

namespace Application
{
    public class Program
    {
        static List<Articulo> articulos = new List<Articulo>();

        static void Main(string[] args)
        {
            // Lista inicial de artículos de ejemplo
            articulos.Add(new Articulo("Laptop Gamer", "LT-GM-001", "Negro", "MSI", 1200.50m, 15));
            articulos.Add(new Articulo("Teclado Mecánico", "TC-MC-005", "RGB", "HyperX", 80.00m, 8));
            articulos.Add(new Articulo("Monitor Curvo", "MN-CR-010", "Negro", "Samsung", 350.75m, 25));
            articulos.Add(new Articulo("Mouse Inalámbrico", "MS-IN-002", "Gris", "Logitech", 45.99m, 5));
            articulos.Add(new Articulo("Auriculares Gaming", "AU-GM-003", "Rojo", "Razer", 110.20m, 12));
            articulos.Add(new Articulo("SSD 1TB", "AL-SS-007", "N/A", "Crucial", 99.99m, 3)); // Artículo con stock bajo

            bool salir = false;
            while (!salir)
            {
                MostrarMenu();
                string? opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ConsultarTodosLosArticulos();
                        break;
                    case "2":
                        ConsultarArticulosBajoStock();
                        break;
                    case "3":
                        AgregarNuevoArticulo();
                        break;
                    case "4":
                        salir = true;
                        Console.WriteLine("Saliendo del programa. ¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                        break;
                }
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("--- Gestión de Artículos ---");
            Console.WriteLine("1. Consultar todos los artículos");
            Console.WriteLine("2. Consultar artículos con existencia menor a 10");
            Console.WriteLine("3. Agregar un nuevo artículo");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
        }

        static void ConsultarTodosLosArticulos()
        {
            if (articulos.Count == 0)
            {
                Console.WriteLine("No hay artículos para mostrar.");
                return;
            }
            foreach (var articulo in articulos)
            {
                articulo.MostrarInfo();
            }
        }

        static void ConsultarArticulosBajoStock()
        {
            var articulosBajoStock = articulos.Where(a => a.Stock < 10).ToList();
            if (articulosBajoStock.Count == 0)
            {
                Console.WriteLine("No hay artículos con stock menor a 10.");
                return;
            }
            foreach (var articulo in articulosBajoStock)
            {
                articulo.MostrarInfo();
            }
        }

        static void AgregarNuevoArticulo()
        {
            Console.Clear();
            Console.WriteLine("\n--- Agregar Nuevo Artículo ---");

            Console.Write("Nombre: ");
            string? nombre = Console.ReadLine() ?? string.Empty;

            Console.Write("SKU: ");
            string? sku = Console.ReadLine() ?? string.Empty;

            Console.Write("Color: ");
            string? color = Console.ReadLine() ?? string.Empty;

            Console.Write("Marca: ");
            string? marca = Console.ReadLine() ?? string.Empty;

            decimal precio = 0;
            bool precioValido = false;
            while (!precioValido)
            {
                Console.Write("Precio: ");
                string? precioInput = Console.ReadLine();
                if (decimal.TryParse(precioInput, out precio) && precio >= 0)
                {
                    precioValido = true;
                }
                else
                {
                    Console.WriteLine("Precio no válido. Por favor, ingrese un número decimal positivo.");
                }
            }

            int stock = 0;
            bool stockValido = false;
            while (!stockValido)
            {
                Console.Write("Stock: ");
                string? stockInput = Console.ReadLine();
                if (int.TryParse(stockInput, out stock) && stock >= 0) // Validar stock positivo
                {
                    stockValido = true;
                }
                else
                {
                    Console.WriteLine("Stock no válido. Por favor, ingrese un número entero positivo.");
                }
            }

            Articulo nuevoArticulo = new Articulo(nombre, sku, color, marca, precio, stock);
            articulos.Add(nuevoArticulo);
            Console.WriteLine("Artículo agregado exitosamente!");
        }
    }
}
