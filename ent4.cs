using System;

namespace EntregableRecursividad
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("====================================================");
            Console.WriteLine("   ENTREGABLE BIMESTRAL 4 - DOMINANDO LA RECURSIVIDAD");
            Console.WriteLine("====================================================\n");

            try
            {
                // ====================================================
                // PRUEBA 1: CÓMO SE COMPORTA EL CÁLCULO DE FACTORIAL
                // ====================================================
                Console.Write("Introduce un número entero para calcular su Factorial: ");
                if (!int.TryParse(Console.ReadLine(), out int numeroFactorial))
                {
                    throw new FormatException("La entrada introducida no es un número entero válido.");
                }

                long resultadoFactorial = CalcularFactorial(numeroFactorial);
                Console.WriteLine($"\n[Resultado] El factorial de {numeroFactorial}! es: {resultadoFactorial}");
                Console.WriteLine("----------------------------------------------------\n");


                // ====================================================
                // PRUEBA 2: CÓMO SE COMPORTA LA SERIE FIBONACCI
                // ====================================================
                Console.Write("Introduce la posición (n) deseada de la serie Fibonacci: ");
                if (!int.TryParse(Console.ReadLine(), out int posicionFibonacci))
                {
                    throw new FormatException("La entrada introducida no es un número entero válido.");
                }

                long resultadoFibonacci = GenerarFibonacci(posicionFibonacci);
                Console.WriteLine($"\n[Resultado] El número en la posición {posicionFibonacci} de Fibonacci es: {resultadoFibonacci}");
                Console.WriteLine("----------------------------------------------------\n");
            }
            catch (ArgumentException ex)
            {
                // Captura específicamente los errores de validación (entradas negativas)
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n[ERROR DE VALIDACIÓN] {ex.Message}");
                Console.ResetColor();
            }
            catch (FormatException ex)
            {
                // Captura errores cuando el usuario no digita números válidos
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"\n[ERROR DE FORMATO] {ex.Message}");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                // Captura cualquier otro tipo de error genérico imprevisto
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n[ERROR GENÉRICO] Ocurrió un fallo: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine("Programa finalizado de forma segura. Presiona cualquier tecla para salir.");
            Console.ReadKey();
        }

        /// <summary>
        /// Calcula el factorial de un número de forma recursiva.
        /// </summary>
        /// <param name="n">Número entero a evaluar.</param>
        /// <returns>El factorial del número ingresado.</returns>
        public static long CalcularFactorial(int n)
        {
            // Criterio de validación para entradas negativas
            if (n < 0)
            {
                throw new ArgumentException("El factorial no está definido para números negativos.");
            }

            // CASO BASE: 0! es 1 y 1! es 1
            if (n == 0 || n == 1)
            {
                return 1;
            }

            // CASO RECURSIVO
            return n * CalcularFactorial(n - 1);
        }

        /// <summary>
        /// Genera el valor de la serie de Fibonacci en la posición n de forma recursiva.
        /// </summary>
        /// <param name="n">Posición en la secuencia.</param>
        /// <returns>El valor numérico correspondiente en la serie.</returns>
        public static long GenerarFibonacci(int n)
        {
            // Criterio de validación para posiciones negativas
            if (n < 0)
            {
                throw new ArgumentException("La posición de la serie Fibonacci no puede ser negativa.");
            }

            // DOS CASOS BASE (Requerido explícitamente en la lista de verificación)
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }

            // CASO RECURSIVO
            return GenerarFibonacci(n - 1) + GenerarFibonacci(n - 2);
        }
    }
}