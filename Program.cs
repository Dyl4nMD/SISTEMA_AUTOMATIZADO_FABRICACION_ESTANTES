using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static string archivoCsv = "fabricacion.csv";

    static void Main()
    {
        int opcion;
        int stockPlanchas = 0;
        int cantidadEstantes = 0;
        int totalPlanchas = 0;

        List<string[]> historial = new List<string[]>();

        do
        {
            Console.WriteLine("\n========== MENU ==========");
            Console.WriteLine("1. Registrar stock");
            Console.WriteLine("2. Calcular materiales");
            Console.WriteLine("3. Calcular planchas requeridas");
            Console.WriteLine("4. Verificar fabricacion");
            Console.WriteLine("5. Calcular maximo de estantes");
            Console.WriteLine("6. Actualizar stock");
            Console.WriteLine("7. Generar reporte");
            Console.WriteLine("8. Exportar CSV");
            Console.WriteLine("9. Importar CSV");
            Console.WriteLine("10. Mostrar historial");
            Console.WriteLine("11. Estadisticas de fabricacion");
            Console.WriteLine("12. Salir");

<<<<<<< HEAD
            opcion = int.Parse(Console.ReadLine()!);
=======
            opcion = int.Parse(Console.ReadLine());
>>>>>>> 0294a55c235ac1744c05b856ff27c10a935fc200

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese stock de planchas: ");
                    stockPlanchas = RegistrarStock();
                    Console.WriteLine("Stock registrado correctamente");
                    break;

                case 2:
                    Console.Write("Ingrese cantidad de estantes: ");
<<<<<<< HEAD
                    cantidadEstantes = int.Parse(Console.ReadLine()!);
=======
                    cantidadEstantes = int.Parse(Console.ReadLine());
>>>>>>> 0294a55c235ac1744c05b856ff27c10a935fc200

                    int paneles = CalcularPaneles(cantidadEstantes);
                    int angulos = CalcularAngulos(cantidadEstantes);

                    Console.WriteLine("Paneles necesarios: " + paneles);
                    Console.WriteLine("Angulos necesarios: " + angulos);
                    break;

                case 3:
                    int planchasPaneles = CalcularPlanchasPaneles(cantidadEstantes);
                    int planchasAngulos = CalcularPlanchasAngulos(cantidadEstantes);

<<<<<<< HEAD
                    totalPlanchas = CalcularTotalPlanchas(planchasPaneles, planchasAngulos);
=======
                    totalPlanchas = CalcularTotalPlanchas(
                        planchasPaneles,
                        planchasAngulos);
>>>>>>> 0294a55c235ac1744c05b856ff27c10a935fc200

                    Console.WriteLine("Planchas para paneles: " + planchasPaneles);
                    Console.WriteLine("Planchas para angulos: " + planchasAngulos);
                    Console.WriteLine("Total de planchas requeridas: " + totalPlanchas);

                    historial.Add(new string[]
                    {
                        totalPlanchas.ToString(),
                        CalcularAngulos(cantidadEstantes).ToString(),
                        CalcularPaneles(cantidadEstantes).ToString(),
                        cantidadEstantes.ToString()
                    });

                    break;

                case 4:
                    if (VerificarFabricacion(stockPlanchas, totalPlanchas))
<<<<<<< HEAD
                        Console.WriteLine("La fabricacion SI es posible");
                    else
                        Console.WriteLine("Stock insuficiente");
=======
                    {
                        Console.WriteLine("La fabricacion SI es posible");
                    }
                    else
                    {
                        Console.WriteLine("Stock insuficiente");
                    }
>>>>>>> 0294a55c235ac1744c05b856ff27c10a935fc200
                    break;

                case 5:
                    int maximoEstantes = CalcularMaximoEstantes(stockPlanchas);
<<<<<<< HEAD
                    Console.WriteLine("Cantidad maxima de estantes: " + maximoEstantes);
                    break;

                case 6:
                    stockPlanchas = ActualizarStock(stockPlanchas, totalPlanchas);

                    Console.WriteLine("Stock actualizado: " + stockPlanchas);
                    Console.WriteLine("Estado del stock: " + EvaluarEstadoStock(stockPlanchas));
                    break;

                case 7:
                    GenerarReporte(stockPlanchas, cantidadEstantes, totalPlanchas);
=======

                    Console.WriteLine("Cantidad maxima de estantes: "
                                      + maximoEstantes);
                    break;

                case 6:
                    stockPlanchas = ActualizarStock(
                        stockPlanchas,
                        totalPlanchas);

                    Console.WriteLine("Stock actualizado: "
                                      + stockPlanchas);
                    break;

                case 7:
                    GenerarReporte(
                        stockPlanchas,
                        cantidadEstantes,
                        totalPlanchas);
>>>>>>> 0294a55c235ac1744c05b856ff27c10a935fc200
                    break;

                case 8:
                    GuardarCsv(historial);
                    Console.WriteLine("Datos exportados correctamente");
                    break;

                case 9:
                    historial = LeerCsv();
                    Console.WriteLine("Datos importados correctamente");
                    break;

                case 10:
                    Mostrar(historial);
                    break;

                case 11:
                    MostrarEstadisticas(historial);
                    break;

                case 12:
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opcion invalida");
                    break;
            }

        } while (opcion != 12);
    }

    static int RegistrarStock()
    {
<<<<<<< HEAD
        return int.Parse(Console.ReadLine()!);
=======
        return int.Parse(Console.ReadLine());
>>>>>>> 0294a55c235ac1744c05b856ff27c10a935fc200
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

<<<<<<< HEAD
    // NUEVA FUNCION AGREGADA
    static string EvaluarEstadoStock(int stock)
    {
        if (stock < 10)
            return "Stock bajo";

        if (stock <= 30)
            return "Stock suficiente";

        return "Stock alto";
    }

    static void GenerarReporte(int stock, int estantes, int planchas)
=======
    static void GenerarReporte(
        int stock,
        int estantes,
        int planchas)
>>>>>>> 0294a55c235ac1744c05b856ff27c10a935fc200
    {
        Console.WriteLine("===== REPORTE FINAL =====");
        Console.WriteLine("Stock actual: " + stock);
        Console.WriteLine("Estantes solicitados: " + estantes);
        Console.WriteLine("Planchas requeridas: " + planchas);
    }

    static void GuardarCsv(List<string[]> lista)
    {
        List<string> lineas = new List<string>();
<<<<<<< HEAD
=======

>>>>>>> 0294a55c235ac1744c05b856ff27c10a935fc200
        lineas.Add("Planchas,Angulos,Paneles,Estantes");

        foreach (string[] fila in lista)
        {
<<<<<<< HEAD
            lineas.Add($"{fila[0]},{fila[1]},{fila[2]},{fila[3]}");
=======
            lineas.Add(
                $"{fila[0]},{fila[1]},{fila[2]},{fila[3]}"
            );
>>>>>>> 0294a55c235ac1744c05b856ff27c10a935fc200
        }

        File.WriteAllLines(archivoCsv, lineas);
    }

    static List<string[]> LeerCsv()
    {
        List<string[]> lista = new List<string[]>();

        if (!File.Exists(archivoCsv))
            return lista;

        string[] lineas = File.ReadAllLines(archivoCsv);

        for (int i = 1; i < lineas.Length; i++)
        {
            lista.Add(lineas[i].Split(','));
        }

        return lista;
    }

    static void Mostrar(List<string[]> lista)
    {
        Console.WriteLine("\n===== HISTORIAL =====");

        foreach (string[] fila in lista)
        {
            Console.WriteLine(
                $"Planchas: {fila[0]} | " +
                $"Angulos: {fila[1]} | " +
                $"Paneles: {fila[2]} | " +
                $"Estantes: {fila[3]}"
            );
        }
    }
<<<<<<< HEAD

=======
>>>>>>> 0294a55c235ac1744c05b856ff27c10a935fc200
    static void MostrarEstadisticas(List<string[]> lista)
    {
        if (lista.Count == 0)
        {
            Console.WriteLine("No hay fabricaciones registradas.");
            return;
        }

        int totalEstantes = 0;
        int mayor = int.MinValue;
        int menor = int.MaxValue;

        foreach (string[] fila in lista)
        {
            int estantes = int.Parse(fila[3]);

            totalEstantes += estantes;

            if (estantes > mayor)
<<<<<<< HEAD
                mayor = estantes;

            if (estantes < menor)
                menor = estantes;
=======
            mayor = estantes;

            if (estantes < menor)
            menor = estantes;
>>>>>>> 0294a55c235ac1744c05b856ff27c10a935fc200
        }

        double promedio = (double)totalEstantes / lista.Count;

        Console.WriteLine("\n===== ESTADISTICAS DE FABRICACION =====");
        Console.WriteLine("Fabricaciones registradas: " + lista.Count);
        Console.WriteLine("Total de estantes producidos: " + totalEstantes);
        Console.WriteLine("Promedio de estantes por fabricacion: " + promedio);
        Console.WriteLine("Mayor fabricacion: " + mayor + " estantes");
        Console.WriteLine("Menor fabricacion: " + menor + " estantes");
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 0294a55c235ac1744c05b856ff27c10a935fc200
