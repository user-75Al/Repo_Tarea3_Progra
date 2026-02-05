namespace Core
{
    public class Articulo
    {
        public string Nombre { get; set; }
        public string SKU { get; set; }
        public string Color { get; set; }
        public string Marca { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public Articulo(string nombre, string sku, string color, string marca, decimal precio, int stock)
        {
            Nombre = nombre;
            SKU = sku;
            Color = color;
            Marca = marca;
            Precio = precio;
            Stock = stock;
        }

        public void MostrarInfo()
        {
            Console.WriteLine($"--- Información del Artículo ---");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"SKU: {SKU}");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Marca: {Marca}");
            Console.WriteLine($"Precio: {Precio:C}"); // Formato de moneda
            Console.WriteLine($"Stock: {Stock}");
            Console.WriteLine($"------------------------------");
        }
    }
}
