using System;

namespace EntregableArbolesBinarios
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("====================================================");
            Console.WriteLine("   ENTREGABLE BIMESTRAL 5 - ÁRBOLES BINARIOS Y BIG O");
            Console.WriteLine("====================================================\n");

            // Creamos la raíz del árbol binario de búsqueda (BST)
            Nodo raiz = null;

            try
            {
                // ====================================================
                // SECCIÓN 1: INSERCIÓN DE NODOS
                // ====================================================
                Console.WriteLine("[Fase 1] Insertando nodos en el árbol...");
                
                // Valores de prueba sugeridos en la guía
                int[] valoresAInsertar = { 10, 5, 15, 3, 7, 12, 20 };

                foreach (int valor in valoresAInsertar)
                {
                    raiz = InsertarNodo(raiz, valor);
                    Console.WriteLine($" -> Nodo [{valor}] insertado correctamente.");
                }

                Console.WriteLine("\n¡Estructura jerárquica del árbol creada con éxito!");
                Console.WriteLine("----------------------------------------------------\n");

                // ====================================================
                // SECCIÓN 2: BÚSQUEDA DE UN NODO (PROCESO RECURSIVO)
                // ====================================================
                Console.WriteLine("[Fase 2] Búsqueda interactiva de nodos (Complejidad O(log n))");
                Console.Write("Introduce el valor entero que deseas buscar en el BST: ");
                
                if (!int.TryParse(Console.ReadLine(), out int valorABuscar))
                {
                    throw new FormatException("La entrada introducida no es un número entero válido.");
                }

                Console.WriteLine($"\nBuscando el nodo [{valorABuscar}] de manera recursiva...");
                Nodo nodoEncontrado = BuscarNodo(raiz, valorABuscar);

                if (nodoEncontrado != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n[ÉXITO] ¡Nodo encontrado! El valor {nodoEncontrado.Valor} existe en el árbol.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\n[AVISO] El valor {valorABuscar} NO se encuentra en la estructura del árbol.");
                    Console.ResetColor();
                }
                Console.WriteLine("----------------------------------------------------\n");

            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"\n[ERROR DE FORMATO] {ex.Message}");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n[ERROR GENÉRICO] Ocurrió un fallo inesperado: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine("Programa finalizado de forma segura. Presiona cualquier tecla para salir.");
            Console.ReadKey();
        }

        // ====================================================
        // CLASE NODO (Estructura base para el Árbol Binario)
        // ====================================================
        public class Nodo
        {
            public int Valor { get; set; }
            public Nodo Izquierdo { get; set; }
            public Nodo Derecho { get; set; }

            // Constructor para inicializar el nodo con su valor base
            public Nodo(int valor)
            {
                Valor = valor;
                Izquierdo = null;
                Derecho = null;
            }
        }

        // ====================================================
        // MÉTODO RECURSIVO: INSERCIÓN (BST)
        // ====================================================
        public static Nodo InsertarNodo(Nodo subArbol, int valor)
        {
            // CASO BASE: Si el subárbol está vacío, creamos y retornamos el nuevo nodo aquí
            if (subArbol == null)
            {
                return new Nodo(valor);
            }

            // RECURSIÓN: Decidir si el valor va a la izquierda o a la derecha
            if (valor < subArbol.Valor)
            {
                subArbol.Izquierdo = InsertarNodo(subArbol.Izquierdo, valor);
            }
            else if (valor > subArbol.Valor)
            {
                subArbol.Derecho = InsertarNodo(subArbol.Derecho, valor);
            }
            // Nota: Si el valor es igual (valor == subArbol.Valor), no se hace nada para evitar duplicados.

            return subArbol;
        }

        // ====================================================
        // MÉTODO RECURSIVO: BÚSQUEDA (BST)
        // ====================================================
        public static Nodo BuscarNodo(Nodo subArbol, int valorBuscado)
        {
            // CASO BASE 1: Si el nodo es nulo, el valor no existe en esta rama del árbol
            if (subArbol == null)
            {
                return null;
            }

            // CASO BASE 2: Si encontramos el valor en el nodo actual, lo retornamos
            if (valorBuscado == subArbol.Valor)
            {
                return subArbol;
            }

            // CASO RECURSIVO: Desplazamiento inteligente por las ramas del árbol
            if (valorBuscado < subArbol.Valor)
            {
                // Buscar en el subárbol izquierdo porque el valor es menor
                return BuscarNodo(subArbol.Izquierdo, valorBuscado);
            }
            else
            {
                // Buscar en el subárbol derecho porque el valor es mayor
                return BuscarNodo(subArbol.Derecho, valorBuscado);
            }
        }
    }
}