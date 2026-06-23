using System;
using System.Collections.Generic;

namespace SimulacroExamenUnitec
{
    class Program
    {
        static void Main(string[] args)
        {
            // FASE 9: Control de Excepciones y Código Defensivo
            try
            {
                // 1. Instanciamos la ubicación mediante un Struct (Inmutable en memoria Stack)
                PuntoDeRed ubicacionCdmx = new PuntoDeRed(19.43, -99.13);

                // Al ser un Struct (Value Type), el operador de asignación '=' copia los VALORES.
                // Ya no comparten la misma referencia en el Heap, eliminando el fallo de corrupción silenciosa.
                PuntoDeRed ubicacionNueva = ubicacionCdmx; 
                
                // Intentar asignar un valor inválido lanzaría una excepción controlada inmediatamente.
                // PuntoDeRed ubicacionInvalida = new PuntoDeRed(500.0, -99.13); // Descomenta para probar el Fail Fast

                // 2. Definición del listado de códigos de respuesta con Colecciones Genéricas
                List<int> codigosCdmx = new List<int> { 200, 200, 500 };

                // 3. Inicialización del servicio usando inyección de dependencias para desacoplar el notificador
                INotificador notificadorSms = new NotificadorSMS();
                ServidorConexion servidor1 = new ServidorConexion(1, "Servidor-CDMX", ubicacionCdmx, codigosCdmx, notificadorSms);

                Console.WriteLine(servidor1.ToString());
                Console.WriteLine("--------------------------------------------------");

                // 4. Ejecución optimizada del motor algorítmico (Complejidad O(n) mediante Memoization)
                // Ahora calcular el índice 40 toma milisegundos en lugar de congelar la consola
                int numeroDiagnostico = 40;
                long estres = servidor1.DiagnosticarLatencia(numeroDiagnostico, out string alerta);

                Console.WriteLine($"[Resultado] Índice de estrés calculado (N={numeroDiagnostico}): {estres}");
                
                if (!string.IsNullOrEmpty(alerta))
                {
                    Console.WriteLine(alerta);
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"[ERROR DE VALIDACIÓN]: {ex.Message}");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"[ERROR DE CONFIGURACIÓN]: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR INESPERADO]: {ex.Message}");
            }
        }
    }

    // ====================================================================
    // COMPONENTE 1: PuntoDeRed (Estructura Inmutable - Memoria Stack)
    // ====================================================================
    // FASE 2: Corregido a 'struct' para asegurar la semántica de valor.
    public struct PuntoDeRed
    {
        // Propiedades de solo lectura (Encapsulamiento estricto)
        public double Latitud { get; }
        public double Longitud { get; }

        // El constructor valida las reglas de negocio antes de inicializar (Principio Fail Fast)
        public PuntoDeRed(double latitud, double longitud)
        {
            if (latitud < -90.0 || latitud > 90.0)
                throw new ArgumentOutOfRangeException(nameof(latitud), "La latitud debe estar entre -90 y 90 grados.");
            
            if (longitud < -180.0 || longitud > 180.0)
                throw new ArgumentOutOfRangeException(nameof(longitud), "La longitud debe estar entre -180 y 180 grados.");

            Latitud = latitud;
            Longitud = longitud;
        }

        public override string ToString() => $"Lat: {Latitud}, Long: {Longitud}";
    }

    // ====================================================================
    // ABSTRACCIONES: Principio de Inversión de Dependencias (DIP - SOLID)
    // ====================================================================
    public interface INotificador
    {
        void EnviarAlerta(string mensaje);
    }

    // ====================================================================
    // COMPONENTE 2: ServidorConexion (Cumple Encapsulamiento y SRP)
    // ====================================================================
    public class ServidorConexion
    {
        // Propiedades auto-implementadas con setters privados (Encapsulamiento Clase 5)
        public int ID { get; private set; }
        public string Nombre { get; private set; }
        public PuntoDeRed Ubicacion { get; private set; }
        
        // FASE 10 (DIP): Exponemos una interfaz de solo lectura para proteger la colección interna
        private readonly List<int> _codigosRespuesta;
        public IReadOnlyCollection<int> CodigosRespuesta => _codigosRespuesta.AsReadOnly();

        // Inyección de dependencias a través del constructor (Desacoplamiento)
        private readonly INotificador _notificador;

        public ServidorConexion(int id, string nombre, PuntoDeRed ubicacion, List<int> codigos, INotificador notificador)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentNullException(nameof(nombre), "El nombre del servidor no puede ser nulo o vacío.");

            ID = id;
            Nombre = nombre;
            Ubicacion = ubicacion;
            _codigosRespuesta = codigos ?? throw new ArgumentNullException(nameof(codigos), "La lista de códigos no puede ser nula.");
            _notificador = notificador ?? throw new ArgumentNullException(nameof(notificador), "El servicio notificador es obligatorio.");
        }

        // ====================================================================
        // COMPONENTE 3: Motor Algorítmico Eficiente (Memoization)
        // ====================================================================
        // FASE 11: Se añade un arreglo de caché privado para guardar los estados ya calculados de Fibonacci.
        // Optimiza el rendimiento de O(2^n) a O(n).
        public long DiagnosticarLatencia(int n, out string alerta)
        {
            // Validación defensiva de límites del examen [0, 99]
            if (n < 0 || n > 99)
                throw new ArgumentOutOfRangeException(nameof(n), "El parámetro de diagnóstico debe estar entre 0 y 99.");

            // Inicialización de la memoria caché
            long[] cache = new long[n + 1];
            
            // Ejecución del cálculo optimizado
            long resultado = CalcularFibonacciOptimizados(n, cache);

            // Gestión de alertas mediante la abstracción inyectada (SOLID - SRP)
            if (resultado > 10000)
            {
                alerta = $"[ALERTA CRÍTICA]: El índice de estrés en '{Nombre}' superó el umbral seguro.";
                _notificador.EnviarAlerta(alerta);
            }
            else
            {
                alerta = string.Empty;
            }

            return resultado;
        }

        // Método recursivo privado que implementa Memoization
        private long CalcularFibonacciOptimizados(int n, long[] cache)
        {
            if (n <= 1) return n;

            // Si ya calculamos este valor previamente, lo retornamos directo desde la memoria RAM (O(1))
            if (cache[n] != 0) return cache[n];

            // Almacenamos el resultado en la caché antes de devolverlo
            cache[n] = CalcularFibonacciOptimizados(n - 1, cache) + CalcularFibonacciOptimizados(n - 2, cache);
            return cache[n];
        }

        public override string ToString() => $"Servidor: {Nombre} (ID: {ID}) | Ubicación: [{Ubicacion}]";
    }

    // ====================================================================
    // COMPONENTE ADICIONAL: Notificaciones Desacopladas (Clase 6 y 7)
    // ====================================================================
    // Corregido: Ya no hereda forzadamente de ServidorConexion. Implementa la interfaz.
    public class NotificadorSMS : INotificador
    {
        public void EnviarAlerta(string mensaje)
        {
            // Simulación de envío técnico encapsulado
            Console.WriteLine($"[SMS ENVIADO AUTOMÁTICAMENTE]: {mensaje}");
        }
    }
}