using System;

Console.WriteLine("=== CALCULADORA DE ÁREA DE POLÍGONOS REGULARES ===");

// 1. Seleccionar el polígono y obtener el número de lados
int numeroLados = SeleccionarPoligono();

// Si el usuario decidió salir
if (numeroLados == 0)
{
    Console.WriteLine("\n¡Hasta luego!");
    return;
}

// 2. Pedir la medida del lado y la apotema
(double medidaLado, double apotema) = PedirDatos();

// 3. Calcular el área
double areaFinal = CalcularArea(numeroLados, medidaLado, apotema);

// Mostrar el resultado
Console.WriteLine("\n-------------------------------------------------");
Console.WriteLine($"El área del polígono de {numeroLados} lados es: {areaFinal:F2} unidades cuadradas.");
Console.WriteLine("-------------------------------------------------");


// =================================================================
// FUNCIONES INDEPENDIENTES
// =================================================================

static int SeleccionarPoligono()
{
    int opcion;
    do
    {
        Console.WriteLine("\nSeleccione una opción:");
        Console.WriteLine("1. Pentágono (5 lados)");
        Console.WriteLine("2. Hexágono (6 lados)");
        Console.WriteLine("3. Heptágono (7 lados)");
        Console.WriteLine("4. Octágono (8 lados)");
        Console.WriteLine("0. Salir");
        Console.Write("Opción: ");
        
        if (int.TryParse(Console.ReadLine(), out opcion) && opcion >= 0 && opcion <= 4)
        {
            switch (opcion)
            {
                case 1: return 5;
                case 2: return 6;
                case 3: return 7;
                case 4: return 8;
                case 0: return 0;
            }
        }
        
        Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
    } while (true);
}

static (double lado, double apotema) PedirDatos()
{
    double lado = LeerDoublePositivo("\nIngrese la longitud de un lado: ");
    double apotema = LeerDoublePositivo("Ingrese la longitud de la apotema: ");
    return (lado, apotema);
}

static double CalcularArea(int numLados, double longitudLado, double apotema)
{
    double perimetro = numLados * longitudLado;
    return (perimetro * apotema) / 2;
}

static double LeerDoublePositivo(string mensaje)
{
    double valor;
    do
    {
        Console.Write(mensaje);
        if (double.TryParse(Console.ReadLine(), out valor) && valor > 0)
        {
            return valor;
        }
        Console.WriteLine("Entrada inválida. Por favor, ingrese un número mayor que 0.");
    } while (true);
}