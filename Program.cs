using System;

class Program
{
    static void Main()
    {
        int opcion;
        int stockPlanchas = 0;
        int cantidadEstantes = 0;
        int totalPlanchas = 0;

        do
        {
            Console.WriteLine("========== MENU ==========");
            Console.WriteLine("1. Registrar stock");
            Console.WriteLine("2. Calcular materiales");
            Console.WriteLine("3. Calcular planchas requeridas");
            Console.WriteLine("4. Verificar fabricacion");
            Console.WriteLine("5. Calcular maximo de estantes");
            Console.WriteLine("6. Actualizar stock");
            Console.WriteLine("7. Generar reporte");
            Console.WriteLine("8. Salir");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Ingrese stock de planchas:");
                    stockPlanchas = RegistrarStock();
                    Console.WriteLine("Stock registrado correctamente");
                    break;

                case 2:
                    Console.WriteLine("Ingrese cantidad de estantes:");
                    cantidadEstantes = int.Parse(Console.ReadLine());

                    int paneles = CalcularPaneles(cantidadEstantes);
                    int angulos = CalcularAngulos(cantidadEstantes);

                    Console.WriteLine("Paneles necesarios: " + paneles);
                    Console.WriteLine("Angulos necesarios: " + angulos);
                    break;

                case 3:
                    int planchasPaneles = CalcularPlanchasPaneles(cantidadEstantes);
                    int planchasAngulos = CalcularPlanchasAngulos(cantidadEstantes);

                    totalPlanchas = CalcularTotalPlanchas(
                        planchasPaneles,
                        planchasAngulos);

                    Console.WriteLine("Planchas para paneles: " + planchasPaneles);
                    Console.WriteLine("Planchas para angulos: " + planchasAngulos);
                    Console.WriteLine("Total de planchas requeridas: " + totalPlanchas);
                    break;

                case 4:
                    if (VerificarFabricacion(stockPlanchas, totalPlanchas))
                    {
                        Console.WriteLine("La fabricacion SI es posible");
                    }
                    else
                    {
                        Console.WriteLine("Stock insuficiente");
                    }
                    break;

                case 5:
                    int maximoEstantes = CalcularMaximoEstantes(stockPlanchas);

                    Console.WriteLine("Cantidad maxima de estantes: " + maximoEstantes);
                    break;

                case 6:
                    stockPlanchas = ActualizarStock(stockPlanchas, totalPlanchas);

                    Console.WriteLine("Stock actualizado: " + stockPlanchas);
                    break;

                case 7:
                    GenerarReporte(stockPlanchas, cantidadEstantes, totalPlanchas);
                    break;

                case 8:
                    Console.WriteLine("Saliendo del sistema");
                    break;

                default:
                    Console.WriteLine("Opcion invalida");
                    break;
            }

        } while (opcion != 8);
    }

    static int RegistrarStock()
    {
        return int.Parse(Console.ReadLine());
    }

    static int CalcularPaneles(int estantes)
    {
        return estantes * 5;
    }

    static int CalcularAngulos(int estantes)
    {
        return estantes * 4;
    }

    static int CalcularPlanchasPaneles(int estantes)
    {
        return estantes;
    }

    static int CalcularPlanchasAngulos(int estantes)
    {
        return estantes;
    }

    static int CalcularTotalPlanchas(int paneles, int angulos)
    {
        return paneles + angulos;
    }

    static bool VerificarFabricacion(int stock, int requeridas)
    {
        return stock >= requeridas;
    }

    static int CalcularMaximoEstantes(int stock)
    {
        return stock / 2;
    }

    static int ActualizarStock(int stock, int usadas)
    {
        return stock - usadas;
    }

    static void GenerarReporte(int stock, int estantes, int planchas)
    {
        Console.WriteLine("===== REPORTE FINAL =====");
        Console.WriteLine("Stock actual: " + stock);
        Console.WriteLine("Estantes solicitados: " + estantes);
        Console.WriteLine("Planchas requeridas: " + planchas);
    }
}
