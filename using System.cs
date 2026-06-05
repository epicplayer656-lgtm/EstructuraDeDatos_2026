using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // 1. Crear una lista para almacenar a los alumnos
        List<Alumno> grupo = new List<Alumno>();

        // 2. Agregar alumnos a la lista usando el constructor
        grupo.Add(new Alumno("Emiliano", 20, 9.5));
        grupo.Add(new Alumno("Alejandro", 22, 7.8));
        grupo.Add(new Alumno("Sofia", 19, 10.0));
        grupo.Add(new Alumno("Carlos", 21, 5.4)); // Alumno reprobado para probar la lógica

        // 3. Desplegar la información de todos los alumnos
        Console.WriteLine("==================================================");
        Console.WriteLine("          LISTA COMPLETA DE ALUMNOS               ");
        Console.WriteLine("==================================================");
        
        foreach (Alumno alumno in grupo)
        {
            alumno.MostrarInformacion();
        }

        // 4. Calcular y mostrar el promedio general del grupo
        double sumaCalificaciones = 0;
        foreach (Alumno alumno in grupo)
        {
            sumaCalificaciones += alumno.Calificacion;
        }
        double promedioGrupo = sumaCalificaciones / grupo.Count;

        Console.WriteLine("==================================================");
        Console.WriteLine($" Promedio general del grupo: {promedioGrupo:F2}");
        Console.WriteLine("==================================================");
    }
}

// Clase que define el objeto Alumno
class Alumno
{
    // Propiedades (Atributos)
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public double Calificacion { get; set; }

    // Constructor para inicializar el objeto fácilmente
    public Alumno(string nombre, int edad, double calificacion)
    {
        Nombre = nombre;
        Edad = edad;
        Calificacion = calificacion;
    }

    // Método para evaluar si el alumno aprobó (Calificación mínima: 6.0)
    public string EvaluarEstatus()
    {
        return Calificacion >= 6.0 ? "APROBADO" : "REPROBADO";
    }

    // Método para imprimir los detalles del alumno en la consola
    public void MostrarInformacion()
    {
        Console.WriteLine($"Nombre: {Nombre,-12} | Edad: {Edad} años | Calif: {Calificacion,4:F1} | Estatus: {EvaluarEstatus()}");
    }
}

