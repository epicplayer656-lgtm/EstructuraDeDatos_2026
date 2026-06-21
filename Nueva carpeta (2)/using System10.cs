using System;

namespace TelemetriaGPSStructs
{
    // =====================================================================
    // FASE 3 - MÓDULO A: DISEÑO DEL STRUCT INMUTABLE
    // =====================================================================
    /// <summary>
    /// Representa una posición geográfica mediante latitud y longitud.
    /// Al ser 'readonly struct', garantiza inmutabilidad, semántica de valor 
    /// y almacenamiento eficiente en el Stack.
    /// </summary>
    public readonly struct CoordenadaGPS
    {
        // Propiedades de solo lectura (inmutables)
        public double Latitud { get; }
        public double Longitud { get; }

        // Constructor con validación estricta de rangos geográficos (Módulo C)
        public CoordenadaGPS(double lat, double lon)
        {
            // Validación de Latitud: [-90, 90] grados
            if (lat < -90 || lat > 90)
            {
                throw new ArgumentOutOfRangeException(nameof(lat), "Latitud fuera de rango válido [-90, 90]");
            }

            // Validación de Longitud: [-180, 180] grados
            if (lon < -180 || lon > 180)
            {
                throw new ArgumentOutOfRangeException(nameof(lon), "Longitud fuera de rango válido [-180, 180]");
            }

            Latitud = lat;
            Longitud = lon;
        }

        // Método para imprimir la ubicación formateada
        public void ImprimirUbicacion()
        {
            Console.WriteLine($"Latitud: {Latitud:F4}°, Longitud: {Longitud:F4}°");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==================================================================");
            Console.WriteLine(" UNITEC - ESTRUCTURA DE DATOS: CLASE 10");
            Console.WriteLine(" Telemetría GPS con Tipos de Datos Personalizados (Structs)");
            Console.WriteLine("==================================================================\n");

            // -----------------------------------------------------------------
            // MÓDULO B: COMPROBACIÓN EMPÍRICA DE LA COPIA POR VALOR
            // -----------------------------------------------------------------
            Console.WriteLine(">>> MÓDULO B: Experimento de Ciclo de Vida en el Stack");
            Console.WriteLine("------------------------------------------------------------------");
            
            // Instancia original c1 (Ciudad de México)
            CoordenadaGPS c1 = new CoordenadaGPS(19.4326, -99.1332);
            
            // Copia por valor en el Stack (Se duplica de forma independiente)
            CoordenadaGPS c2 = c1;
            
            // Reasignamos c2 apuntando a una nueva coordenada (Berlín)
            c2 = new CoordenadaGPS(52.5200, 13.4050);

            // Imprimimos ambas para demostrar que c1 permanece intacta
            Console.WriteLine("--- Coordenada c1 (Original - CDMX) ---");
            c1.ImprimirUbicacion();

            Console.WriteLine("\n--- Coordenada c2 (Copia Modificada - Berlín) ---");
            c2.ImprimirUbicacion();
            
            Console.WriteLine("\n[ANÁLISIS]: Modificar c2 NO alteró a c1. Al ser un struct en el Stack,");
            Console.WriteLine("ambas variables son entidades independientes en memoria.");
            Console.WriteLine("------------------------------------------------------------------\n");


            // -----------------------------------------------------------------
            // MÓDULO C: ROBUSTEZ Y CONTROL DE EXCEPCIONES CONTROLADAS
            // -----------------------------------------------------------------
            Console.WriteLine(">>> MÓDULO C: Captura Dinámica y Validación Geográfica");
            Console.WriteLine("------------------------------------------------------------------");
            
            try
            {
                // Lectura interactiva de datos desde consola
                Console.Write("Ingresa la Latitud del punto (-90 a 90): ");
                double usuarioLat = double.Parse(Console.ReadLine() ?? "0");

                Console.Write("Ingresa la Longitud del punto (-180 a 180): ");
                double usuarioLon = double.Parse(Console.ReadLine() ?? "0");

                // Intento de creación del objeto inmutable
                Console.WriteLine("\nProcesando telemetría...");
                CoordenadaGPS coordUsuario = new CoordenadaGPS(usuarioLat, usuarioLon);
                
                Console.Write("[ÉXITO] Coordenada válida registrada: ");
                coordUsuario.ImprimirUbicacion();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // Captura específica del error de rangos geográficos de la Tierra
                Console.WriteLine($"\n[ERROR DE VALIDACIÓN]: {ex.Message}");
            }
            catch (FormatException)
            {
                // Protección contra entradas de texto no numéricas
                Console.WriteLine("\n[ERROR]: El formato de entrada no es un número decimal válido.");
            }
            
            Console.WriteLine("==================================================================");
            Console.WriteLine("¡Misión cumplida! Presiona cualquier tecla para cerrar.");
            Console.ReadKey();
        }
    }
}