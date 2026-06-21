using System;
using System.Numerics; // Obligatorio para BigInteger

namespace EntregableFactorialOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==================================================");
            Console.WriteLine(" UNITEC - ESTRUCTURA DE DATOS: ENTREGABLE 8");
            Console.WriteLine("==================================================\n");

            // --- PARTE A: Diagnóstico (int de 32 bits) ---
            Console.WriteLine(">>> PARTE A: Tipos Primitivos (int)");
            Console.WriteLine("n    | Recursivo                 | Iterativo");
            Console.WriteLine("--------------------------------------------------");

            for (int i = 1; i <= 20; i++)
            {
                int rec = FactorialInt(i);
                int ite = FactorialIterativo(i);
                Console.WriteLine($"{i:D2}   | {rec,25} | {ite,25}");
            }

            /* * DOCUMENTACIÓN DEL PUNTO DE QUIEBRE:
             * Ocurre en: n = 13
             * Valor esperado: 6,227,020,800
             * Valor erróneo: 1,932,053,504
             * Explicación: Supera el límite de 32 bits (2,147,483,647) en el Stack y causa wraparound.
             */

            Console.WriteLine("\n[Alerta]: Revisa los comentarios internos para ver el diagnóstico.");
            Console.WriteLine("--------------------------------------------------\n");

            // --- PARTE B: Alta Precisión (BigInteger) ---
            Console.WriteLine(">>> PARTE B: Refactorización Profesional (BigInteger)");
            BigInteger resultadoMasivo = FactorialProfesional(100);
            
            Console.WriteLine("\nResultado de 100! (Precisión absoluta en el Heap):");
            Console.WriteLine(resultadoMasivo);
            Console.WriteLine("==================================================");
        }

        // Métodos de la Parte A
        static int FactorialInt(int n)
        {
            if (n == 0 || n == 1) return 1;
            return n * FactorialInt(n - 1);
        }

        static int FactorialIterativo(int n)
        {
            int resultado = 1;
            for (int i = 2; i <= n; i++)
            {
                resultado *= i;
            }
            return resultado;
        }

        // Método de la Parte B
        static BigInteger FactorialProfesional(BigInteger n)
        {
            if (n == 0 || n == 1) return BigInteger.One;
            return n * FactorialProfesional(n - 1);
        }
    }
}