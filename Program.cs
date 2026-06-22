using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Automatizado
{
    internal class Program
    {
        static string archivoCsv = "fabricacion.csv";

        static void Main()
        {
            int opcion;
            int stockPlanchas = 0;
            int cantidadEstantes = 0;
            int paneles = 0;
            int angulos = 0;
            int planchasPaneles = 0;
            int planchasAngulos = 0;
            int totalPlanchas = 0;
            int maximoEstantes = 0;

            List<string[]> historial = new List<string[]>();

            do
            {
                // Imprimimos el menú con las opciones disponibles
                Console.WriteLine("\n========== MENU ==========");
                Console.WriteLine("1. Registrar stock");
                Console.WriteLine("2. Calcular materiales");
                Console.WriteLine("3. Calcular planchas requeridas");
                Console.WriteLine("4. Verificar fabricacion");
                Console.WriteLine("5. Calcular maximo de estantes fabricables");
                Console.WriteLine("6. Actualizar stock");
                Console.WriteLine("7. Generar reporte");
                Console.WriteLine("8. Exportar CSV");
                Console.WriteLine("9. Importar CSV");
                Console.WriteLine("10. Mostrar historial");
                Console.WriteLine("11. Estadisticas de fabricacion");
                Console.WriteLine("12. Salir");
                
                //Validación del menú principal (rango 1 a 12)
                opcion = LeerEntero("Ingrese una opcion: ", 1, 12);

                // Usamos condicionales para poder darle a cada opcion un diferente proceso
                switch (opcion)
                {
                    case 1:
                        stockPlanchas = registrarStock();
                        break;

                    case 2:
                        //Validación de rango (mínimo 0 estantes)
                        cantidadEstantes = LeerEntero("Ingrese cantidad de estantes: ", 0, int.MaxValue);

                        (paneles, angulos) = calcularMateriales(cantidadEstantes);

                        Console.WriteLine($"Paneles necesarios: {paneles}");
                        Console.WriteLine($"Angulos necesarios: {angulos}");
                        break;

                    case 3:
                        (totalPlanchas, planchasPaneles, planchasAngulos) = calcularPlanchas(paneles, angulos);

                        Console.WriteLine($"Planchas para paneles: {planchasPaneles}");
                        Console.WriteLine($"Planchas para angulos: {planchasAngulos}");
                        Console.WriteLine($"Total de planchas requeridas: {totalPlanchas}");

                        // Agregado de historial
                        historial.Add(new string[]
                        {
                            totalPlanchas.ToString(),
                            angulos.ToString(),
                            paneles.ToString(),
                            cantidadEstantes.ToString()
                        });
                        Console.WriteLine("Registro agregado al historial local.");
                        break;

                    case 4:
                        verificarFabricacion(stockPlanchas, totalPlanchas);
                        break;

                    case 5:
                        maximoEstantes = calcularMaximo(stockPlanchas);
                        Console.WriteLine($"Cantidad maxima de estantes: {maximoEstantes}");
                        break;

                    case 6:
                        stockPlanchas = actualizarStock(stockPlanchas, totalPlanchas);
                        Console.WriteLine($"Stock actualizado: {stockPlanchas}");
                        Console.WriteLine("Estado del stock: " + EvaluarEstadoStock(stockPlanchas));
                        break;

                    case 7:
                        generarReporte(stockPlanchas, cantidadEstantes, totalPlanchas);
                        break;

                    case 8:
                        GuardarCsv(historial);
                        Console.WriteLine("Datos exportados correctamente");
                        break;

                    case 9:
                        historial = LeerCsv();
                        Console.WriteLine($"Datos importados correctamente. {historial.Count} registros cargados.");
                        break;

                    case 10:
                        Mostrar(historial);
                        break;

                    case 11:
                        MostrarEstadisticas(historial);
                        break;

                    case 12:
                        Console.WriteLine("Saliendo del sistema");
                        break;

                    default:
                        Console.WriteLine("Opcion invalida");
                    break;
                }

            } while (opcion != 12);
        }

        //FUNCIÓN DE VALIDACIÓN DE ENTRADAS (Tipo, rango y no vacío)
        public static int LeerEntero(string mensaje, int min, int max)
        {
            int resultado;
            while (true)
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();

                // Validación: No vacío o espacios en blanco
                if (string.IsNullOrWhiteSpace(entrada))
                {
                    Console.WriteLine("Error: La entrada no puede estar vacía. Intente de nuevo.");
                    continue;
                }

                // Validación: Tipo de dato (Debe ser un número entero válido)
                if (!int.TryParse(entrada, out resultado))
                {
                    Console.WriteLine("Error: Debe ingresar un número entero válido. Intente de nuevo.");
                    continue;
                }

                // Validación: Rango numérico permitido
                if (resultado < min || resultado > max)
                {
                    Console.WriteLine($"Error: El valor debe estar en el rango de {min} a {max}. Intente de nuevo.");
                    continue;
                }

                // Si supera todas las validaciones, rompe el ciclo y devuelve el valor
                break;
            }
            return resultado;
        }

        //CREACION DE FUNCIONES
        //funcion opcion 1: 
        public static int registrarStock()
        {
            //Validación de entrada para el stock (mínimo 0)
            int stock = LeerEntero("Ingrese stock de planchas: ", 0, int.MaxValue);
            Console.WriteLine("Stock ingresado correctamente.");
            return stock;
        }

        //funcion opcion 2:
        public static (int paneles, int angulos) calcularMateriales(int estantes)
        {
            return (estantes * 5, estantes * 4);
        }

        //funcion de opcion 3:
        public static (int totalPlanchas, int planchasPaneles, int planchasAngulos) calcularPlanchas(int paneles, int angulos)
        {
            //calculamos las planchas necesarias tanto para paneles como para angulos
            int planchasPaneles = paneles / 5;
            int planchasAngulos = angulos / 20;

            //en caso el resultado de la division "angulos/20" dé un numero decimal, se redondea con la operación dentro del if
            if (angulos % 20 != 0)
            {
                planchasAngulos++;
            }
            //Se suman ambas cantidades de planchas para saber cuantas se necesitan en total y el resultado será el 
            //valor de retorno
            return (planchasPaneles + planchasAngulos, planchasPaneles, planchasAngulos);
        }

        //funcion de opcion 4:
        public static void verificarFabricacion(int stockPlanchas, int totalPlanchas)
        {
            if (stockPlanchas >= totalPlanchas)
            {
                Console.WriteLine("La fabricacion SI es posible");
            }
            else
            {
                Console.WriteLine("Stock insuficiente");
            }
        }

        //funcion de opcion 5:
        public static int calcularMaximo(int stockPlanchas)
        {
            //debido a que se necesita hacer una division con decimales, maximoEstantes deberia ser un dato
            //de tipo double pero esto trae complicaciones al momento de redondear ya que al hacer la division 
            //nos resulta un numero decimal y si usamos "maximoEstantes--;" se le restará un numero en lugar de
            //redondear el resultado, por ello se optó por transformar la operacion:
            //dividir entre 1.2 es lo mismo que dividir entre 12/10 ----> 6/5 y aplicando division de fracciones seria:
            //stockPlanchas / 6/5 ------> (stockPlanchas * 5) / 6 dándonos un número entero como resultado
            return (stockPlanchas * 5) / 6;
        }

        //funcion de opcion 6:
        public static int actualizarStock(int stockPlanchas, int totalPlanchas)
        {
            return stockPlanchas - totalPlanchas;
        }

        // AGREGADO DE FUNCION EVALUAR ESTADO STOCK
        static string EvaluarEstadoStock(int stock)
        {
            if (stock < 10)
                return "Stock bajo";
            if (stock <= 30)
                return "Stock suficiente";

            return "Stock alto";
        }

        //funcion de opcion 7:
        public static void generarReporte(int stockPlanchas, int cantidadEstantes, int totalPlanchas)
        {
            Console.WriteLine("===== REPORTE FINAL =====");
            Console.WriteLine($"Stock actual: {stockPlanchas}");
            Console.WriteLine($"Estantes solicitados: {cantidadEstantes}");
            Console.WriteLine($"Planchas requeridas: {totalPlanchas}");
        }

        //funcion de opcion 8:
        static void GuardarCsv(List<string[]> lista)
        {
            try
            {
                //creamos una lista de lineas que representará el contenido del archivo CSV
                List<string> lineas = new List<string>();
                //agregamos la cabecera del archivo CSV
                lineas.Add("Planchas,Angulos,Paneles,Estantes");

                //recorremos cada fila del historial y la convertimos a formato CSV
                foreach (string[] fila in lista)
                {
                    lineas.Add($"{fila[0]},{fila[1]},{fila[2]},{fila[3]}");
                }
                //guardamos todas las lineas en el archivo definido en la variable archivoCsv
                File.WriteAllLines(archivoCsv, lineas);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al exportar el archivo CSV: " + ex.Message);
            }
        }

        //funcion de opcion 9:
        static List<string[]> LeerCsv()
        {
            List<string[]> lista = new List<string[]>();
            //verificamos si el archivo CSV existe antes de intentar leerlo
            if (!File.Exists(archivoCsv))
            {
                Console.WriteLine("El archivo CSV no existe.");
                return lista;
            }

            try
            {
                //leemos todas las lineas del archivo CSV
                string[] lineas = File.ReadAllLines(archivoCsv);
                //recorremos las lineas ignorando la primera (cabecera)
                for (int i = 1; i < lineas.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(lineas[i]))
                    {
                        //dividimos cada linea por comas y la agregamos a la lista
                        lista.Add(lineas[i].Split(','));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer el archivo CSV: " + ex.Message);
            }

            return lista;
        }

        //funcion de opcion 10:
        static void Mostrar(List<string[]> lista)
        {
            Console.WriteLine("\n===== HISTORIAL =====");
            if (lista.Count == 0)
            {
                Console.WriteLine("No hay registros en el historial.");
                return;
            }
            //recorremos cada registro del historial
            foreach (string[] fila in lista)
            {
                //mostramos los datos organizados por categoría
                Console.WriteLine(
                    $"Planchas: {fila[0]} | " +
                    $"Angulos: {fila[1]} | " +
                    $"Paneles: {fila[2]} | " +
                    $"Estantes: {fila[3]}"
                );
            }
        }

        //funcion de opcion 11:
        static void MostrarEstadisticas(List<string[]> lista)
        {
            //Si no hay registros en el historial, no se puede calcular estadisticas
            if (lista.Count == 0)
            {
                Console.WriteLine("No hay fabricaciones registradas.");
                return;
            }

            int totalEstantes = 0;
            int mayor = int.MinValue;
            int menor = int.MaxValue;
            //recorremos cada registro del historial
            foreach (string[] fila in lista)
            {
                int estantes = int.Parse(fila[3]);
                totalEstantes += estantes;

                if (estantes > mayor) mayor = estantes;
                if (estantes < menor) menor = estantes;
            }
            //calculamos el promedio de estantes por fabricacion
            double promedio = (double)totalEstantes / lista.Count;

            Console.WriteLine("\n===== ESTADISTICAS DE FABRICACION =====");
            Console.WriteLine("Fabricaciones registradas: " + lista.Count);
            Console.WriteLine("Total de estantes producidos: " + totalEstantes);
            Console.WriteLine("Promedio de estantes por fabricacion: " + promedio);
            Console.WriteLine("Mayor fabricacion: " + mayor + " estantes");
            Console.WriteLine("Menor fabricacion: " + menor + " estantes");
        }
    }
}