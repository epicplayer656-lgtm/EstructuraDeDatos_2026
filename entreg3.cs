using System;
using System.Collections.Generic;
using System.Linq;

namespace InventarioUNITEC
{
    // ==========================================
    // PASO 2: MODELO DE DATOS - CLASE PRODUCTO
    // ==========================================
    public class Producto
    {
        // Propiedades (Auto-properties) con los 4 atributos requeridos
        public int ID { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }

        // Constructor para facilitar la creación de instancias
        public Producto(int id, string nombre, double precio, int cantidad)
        {
            ID = id;
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
        }

        // Override de ToString() para facilitar la impresión en la consola
        public override string ToString()
        {
            return $"[{ID}] {Nombre} - ${Precio:F2} | Stock: {Cantidad}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SISTEMA DE GESTIÓN DE INVENTARIO (UNITEC) ===\n");

            // ==========================================================
            // PASO 3: CONSTRUYENDO EL INVENTARIO CON List<T>
            // ==========================================================
            
            // Sintaxis 1: Inicializador de colección (Primeros 5 productos)
            List<Producto> inventario = new List<Producto>
            {
                new Producto(1, "Laptop Lenovo", 15999.00, 10),
                new Producto(2, "Mouse Inalámbrico", 349.00, 25),
                new Producto(3, "Teclado Mecánico", 899.00, 0), // Agotado
                new Producto(4, "Monitor 24\"", 4500.00, 5),
                new Producto(5, "Audífonos Sony", 1200.00, 0)   // Agotado
            };

            // Sintaxis 2: Agregar elementos individualmente después de crear la lista
            inventario.Add(new Producto(6, "Webcam HD", 750.00, 12));

            // Sintaxis 3: Con var (Inferencia de tipos en C# moderno)
            var otroProducto = new Producto(7, "Hub USB-C", 450.00, 8);
            inventario.Add(otroProducto);

            // Mostrar total de productos cargados
            Console.WriteLine($"Total de tipos de productos en inventario: {inventario.Count}\n");


            // ==========================================================
            // PASO 4: CONSULTAS LINQ - FILTRANDO Y ORDENANDO
            // ==========================================================

            // Consulta 1: Ordenar por precio descendente (Mayor a menor)
            Console.WriteLine("=== Productos por Precio (Descendente) ===");
            var porPrecio = inventario.OrderByDescending(p => p.Precio).ToList();
            foreach (var p in porPrecio)
            {
                Console.WriteLine(p); // Llama automáticamente al método ToString()
            }
            Console.WriteLine();

            // Consulta 2: Filtrar productos agotados (Cantidad == 0)
            Console.WriteLine("=== Productos Agotados ===");
            var agotados = inventario.Where(p => p.Cantidad == 0).ToList();
            if (agotados.Count == 0)
            {
                Console.WriteLine("Sin productos agotados.");
            }
            else
            {
                // Uso de ForEach propio de las Listas
                agotados.ForEach(p => Console.WriteLine(p));
            }
            Console.WriteLine();


            // ==========================================================
            // PASO 5: BÚSQUEDA INSTANTÁNEA CON Dictionary<K,V>
            // ==========================================================
            
            // Conversión de la lista existente a un diccionario optimizado O(1)
            // Llave: ID (int), Valor: Objeto Producto completo
            Dictionary<int, Producto> catalogo = inventario.ToDictionary(p => p.ID, p => p);

            // Ejecución de la función de búsqueda interactiva
            BuscarPorID(catalogo);

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }

        /// <summary>
        /// Función auxiliar para realizar la búsqueda optimizada en el diccionario
        /// </summary>
        static void BuscarPorID(Dictionary<int, Producto> catalogo)
        {
            Console.Write("Ingresa el ID del producto a buscar: ");
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int idBuscado))
            {
                // TryGetValue busca de forma instantánea usando la tabla Hash (O(1))
                if (catalogo.TryGetValue(idBuscado, out Producto encontrado))
                {
                    Console.WriteLine("\n[✓] Producto Encontrado con Éxito:");
                    Console.WriteLine(encontrado);
                }
                else
                {
                    Console.WriteLine($"\n[X] Error: El ID {idBuscado} no existe en el catálogo.");
                }
            }
            else
            {
                Console.WriteLine("\n[X] Error: Por favor, introduce un número entero válido para el ID.");
            }
        }
    }
}