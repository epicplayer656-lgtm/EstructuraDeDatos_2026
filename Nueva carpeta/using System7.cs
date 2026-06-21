using System;

namespace LogicaRecursividad
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("====================================================");
            Console.WriteLine("   UNITEC - ESTRUCTURA DE DATOS: RECURSIVIDAD       ");
            Console.WriteLine("====================================================\n");

            // --- MÓDULO 1: FACTORIAL ---
            Console.WriteLine(">>> MÓDULO 1: Factorial Recursivo de 5");
            long resultadoFactorial = Factorial(5);
            Console.WriteLine($"Resultado: 5! = {resultadoFactorial}\n");

            // --- MÓDULO 2: FIBONACCI ---
            Console.WriteLine(">>> MÓDULO 2: Serie de Fibonacci (Primeros 6 términos)");
            Console.Write("Serie: ");
            for (int i = 0; i < 6; i++)
            {
                Console.Write(Fibonacci(i) + " ");
            }
            Console.WriteLine("\n");

            // --- MÓDULO 3: SIMULACIÓN DE STACK OVERFLOW ---
            Console.WriteLine(">>> MÓDULO 3: Simulación de Desbordamiento de Pila");
            Console.WriteLine("Ejecutando recursión controlada para demostrar llenado de memoria...");
            SimularStackOverflow(1, 5);

            Console.WriteLine("\n====================================================");
            Console.WriteLine("        PROGRAMA COMPILADO CORRECTAMENTE            ");
            Console.WriteLine("====================================================");
        }

        // Métodos Recursivos Solicitados por el PDF
        
        static long Factorial(int n)
        {
            if (n <= 1) return 1; // Caso base
            return n * Factorial(n - 1); // Caso recursivo
        }

        static int Fibonacci(int n)
        {
            if (n == 0) return 0; // Caso base 1
            if (n == 1) return 1; // Caso base 2
            return Fibonacci(n - 1) + Fibonacci(n - 2); // Caso recursivo
        }

        static void SimularStackOverflow(int actual, int limite)
        {
            Console.WriteLine($"  [Marco de Pila {actual}]: Reservando memoria en el Call Stack...");
            if (actual >= limite)
            {
                Console.WriteLine("  !! Alerta: Límite alcanzado. Evitando caída del programa.");
                return;
            }
            SimularStackOverflow(actual + 1, limite); // Llamada recursiva
        }
    }
}