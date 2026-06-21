using System;
using System.Diagnostics; // Requerido para usar el Stopwatch

namespace OptimizacionFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==================================================================");
            Console.WriteLine(" UNITEC - ESTRUCTURA DE DATOS: CLASE 9");
            Console.WriteLine(" Optimización Avanzada: Recursividad vs. Memoization");
            Console.WriteLine("==================================================================\n");

            // --- VALIDACIÓN DE ENTRADAS (Reto Avanzado) ---
            Console.Write("Ingresa un número entero positivo (Sugerido entre 35 y 43): ");
            string input = Console.ReadLine() ?? "";

            // Verifica que el texto sea numérico, no sea vacío y sea mayor o igual a 0
            if (!int.TryParse(input, out int n) || n < 0)
            {
                Console.WriteLine("\n[ERROR]: Por favor, ingresa un número entero positivo válido.");
                return;
            }

            // Para evitar tiempos exageradamente largos de congelamiento en el método inseguro
            if (n > 45)
            {
                Console.WriteLine("\n[ADVERTENCIA]: Valores mayores a 45 pueden congelar el método Inseguro por horas.");
                Console.Write("¿Deseas continuar de todas formas? (S/N): ");
                if (Console.ReadLine()?.ToUpper() != "S")
                {
                    return;
                }
            }

            Stopwatch sw = new Stopwatch();

            // -----------------------------------------------------------------
            // MÓDULO A: FIBONACCI RECURSIVO TRADICIONAL (Fuerza Bruta)
            // -----------------------------------------------------------------
            Console.WriteLine("\n>>> MÓDULO A: Ejecutando Fibonacci Inseguro...");
            
            sw.Restart();
            long resultadoInseguro = FibonacciInseguro(n);
            sw.Stop();
            
            Console.WriteLine($"Resultado Inseguro: F({n}) = {resultadoInseguro}");
            Console.WriteLine($"Tiempo de ejecución: {sw.ElapsedMilliseconds} ms");
            Console.WriteLine("------------------------------------------------------------------");


            // -----------------------------------------------------------------
            // MÓDULO B: FIBONACCI OPTIMIZADO (Memoization)
            // -----------------------------------------------------------------
            Console.WriteLine("\n>>> MÓDULO B: Ejecutando Fibonacci Pro con Caché...");

            // Inicialización del arreglo caché de tamaño (n + 1)
            long[] cache = new long[n + 1];
            
            // Llenar el caché con -1 (el centinela que significa 'no calculado aún')
            for (int i = 0; i <= n; i++)
            {
                cache[i] = -1;
            }

            sw.Restart();
            long resultadoPro = FibonacciPro(n, cache);
            sw.Stop();

            Console.WriteLine($"Resultado Pro:      F({n}) = {resultadoPro}");
            Console.WriteLine($"Tiempo de ejecución: {sw.ElapsedMilliseconds} ms");
            Console.WriteLine("==================================================================");
            
            Console.WriteLine("\n¡Misión cumplida! Presiona cualquier tecla para finalizar.");
            Console.ReadKey();
        }

        // =====================================================================
        // MÉTODOS DEL ENTREGABLE
        // =====================================================================

        /// <summary>
        /// Módulo A: Versión clásica no optimizada. Complejidad Exponencial O(2^n).
        /// </summary>
        public static long FibonacciInseguro(int n)
        {
            if (n == 0) return 0; // Caso base 1
            if (n == 1) return 1; // Caso base 2

            // Doble bifurcación recursiva redundante
            return FibonacciInseguro(n - 1) + FibonacciInseguro(n - 2);
        }

        /// <summary>
        /// Módulo B: Versión Pro optimizada con Memoization. Complejidad Lineal O(n).
        /// </summary>
        public static long FibonacciPro(int n, long[] cache)
        {
            if (n == 0) return 0; // Caso base 1
            if (n == 1) return 1; // Caso base 2

            // ¿Ya se calculó previamente este subproblema? Consulta en O(1)
            if (cache[n] != -1)
            {
                return cache[n]; // Retorno inmediato reutilizando el valor
            }

            // Si no se ha calculado (-1), lo procesa, lo almacena en el caché y lo devuelve
            cache[n] = FibonacciPro(n - 1, cache) + FibonacciPro(n - 2, cache);
            return cache[n];
        }
    }
}