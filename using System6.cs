using System;

namespace EntregableMemoriaAlternativo
{
    // Módulo 3: Clase Alumno solicitada para la demostración de referencias
    class Alumno
    {
        public string Nombre { get; set; } = string.Empty;
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("====================================================");
                Console.WriteLine("       MENÚ: ESTRUCTURA DE DATOS - CLASE 6          ");
                Console.WriteLine("====================================================");
                Console.WriteLine("1. Módulo 1: Intercambiar Valores (ref)");
                Console.WriteLine("2. Módulo 2: Calcular División y Residuo (out)");
                Console.WriteLine("3. Módulo 3: Demostración de Memoria (Heap vs Stack)");
                Console.WriteLine("4. Salir");
                Console.WriteLine("====================================================");
                Console.Write("Selecciona una opción (1-4): ");

                switch (Console.ReadLine())
                {
                    case "1":
                        EjecutarModulo1();
                        break;
                    case "2":
                        EjecutarModulo2();
                        break;
                    case "3":
                        EjecutarModulo3();
                        break;
                    case "4":
                        salir = true;
                        Console.WriteLine("Saliendo del programa... ¡Éxito en tu entrega!");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Presiona cualquier tecla para intentar de nuevo.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // ==========================================
        // LÓGICA DE LOS MÓDULOS DEL PDF
        // ==========================================

        static void EjecutarModulo1()
        {
            Console.Clear();
            Console.WriteLine("--- MÓDULO 1: MODIFICADOR REF ---");
            
            int x = 10;
            int y = 25;
            
            Console.WriteLine($"Valores originales en Main -> x: {x}, y: {y}");
            Console.WriteLine("Llamando a Intercambiar(ref x, ref y)...");
            
            Intercambiar(ref x, ref y);
            
            Console.WriteLine($"Valores modificados en Main -> x: {x}, y: {y}");
            Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
            Console.ReadKey();
        }

        static void EjecutarModulo2()
        {
            Console.Clear();
            Console.WriteLine("--- MÓDULO 2: MODIFICADOR OUT ---");
            
            int dividendo = 17;
            int divisor = 5;
            
            // Usamos out para obtener el residuo como un segundo valor de retorno
            int cociente = CalcularYValidar(dividendo, divisor, out int resto);
            
            Console.WriteLine($"Operación: {dividendo} entre {divisor}");
            Console.WriteLine($"Resultado del 'return' (Cociente): {cociente}");
            Console.WriteLine($"Resultado del 'out' (Residuo/Resto): {resto}");
            Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
            Console.ReadKey();
        }

        static void EjecutarModulo3()
        {
            Console.Clear();
            Console.WriteLine("--- MÓDULO 3: REFERENCIAS DE OBJETOS ---");
            
            // Instancia original en el Heap
            Alumno alumno1 = new Alumno { Nombre = "Dany" };
            
            // Copia de dirección de memoria, no clonación del objeto
            Alumno alumno2 = alumno1;
            
            Console.WriteLine($"alumno1 inicial: {alumno1.Nombre}");
            Console.WriteLine("Se ejecuta: alumno2 = alumno1; y luego alumno2.Nombre = \"3Treum\";");
            
            alumno2.Nombre = "3Treum";
            
            Console.WriteLine("\n--- RESULTADO EN MEMORIA RAM ---");
            Console.WriteLine($"alumno1.Nombre actual: {alumno1.Nombre} (Se vio afectado)");
            Console.WriteLine($"alumno2.Nombre actual: {alumno2.Nombre}");
            Console.WriteLine("\nExplicación técnica: Ambos apuntan a la misma celda en el Heap.");
            
            Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
            Console.ReadKey();
        }

        // ==========================================
        // MÉTODOS TÉCNICOS SOLICITADOS
        // ==========================================

        /// <summary>
        /// Intercambia los valores directamente usando sus direcciones de memoria.
        /// </summary>
        static void Intercambiar(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Calcula la división. Obliga por contrato a asignar el parámetro out antes de salir.
        /// </summary>
        static int CalcularYValidar(int dividendo, int divisor, out int residuo)
        {
            residuo = dividendo % divisor; // Contrato cumplido
            return dividendo / divisor;
        }
    }
}