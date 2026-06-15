using System;

class Program
{
    static void Main()
    {
        // definimos las variables
        int opcion;
        int stockPlanchas;
        int cantidadEstantes = 0;
        int paneles, angulos;
        int planchasPaneles, planchasAngulos;
        int totalPlanchas = 0;
        int maximoEstantes;

        stockPlanchas = 0;

        do
        {
            // imprimimos el menu con las opciones disponibles
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

            // usamos condicionales para poder darle a cada opcion un diferente proceso
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Ingrese stock de planchas:");
                    stockPlanchas = int.Parse(Console.ReadLine());

                    Console.WriteLine("Stock registrado correctamente");
                    break;

                case 2:
                    Console.WriteLine("Ingrese cantidad de estantes:");
                    cantidadEstantes = int.Parse(Console.ReadLine());

                    paneles = cantidadEstantes * 5;
                    angulos = cantidadEstantes * 4;

                    Console.WriteLine("Paneles necesarios: " + paneles);
                    Console.WriteLine("Angulos necesarios: " + angulos);
                    break;

                case 3:
                    planchasPaneles = cantidadEstantes;
                    planchasAngulos = cantidadEstantes;

                    totalPlanchas = planchasPaneles + planchasAngulos;

                    Console.WriteLine("Planchas para paneles: " + planchasPaneles);
                    Console.WriteLine("Planchas para angulos: " + planchasAngulos);
                    Console.WriteLine("Total de planchas requeridas: " + totalPlanchas);
                    break;

                case 4:
                    if (stockPlanchas >= totalPlanchas)
                    {
                        Console.WriteLine("La fabricacion SI es posible");
                    }
                    else
                    {
                        Console.WriteLine("Stock insuficiente");
                    }
                    break;

                case 5:
                    maximoEstantes = stockPlanchas / 2;

                    Console.WriteLine("Cantidad maxima de estantes: " + maximoEstantes);
                    break;

                case 6:
                    stockPlanchas = stockPlanchas - totalPlanchas;

                    Console.WriteLine("Stock actualizado: " + stockPlanchas);
                    break;

                case 7:
                    Console.WriteLine("===== REPORTE FINAL =====");
                    Console.WriteLine("Stock actual: " + stockPlanchas);
                    Console.WriteLine("Estantes solicitados: " + cantidadEstantes);
                    Console.WriteLine("Planchas requeridas: " + totalPlanchas);
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
}
