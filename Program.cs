using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Sistema_Automatizado
{
    internal class Program
    {
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
 
            do
            {
                // Imprimimos el menú con las opciones disponibles
                Console.WriteLine("========== MENU ==========");
                Console.WriteLine("1. Registrar stock");
                Console.WriteLine("2. Calcular materiales");
                Console.WriteLine("3. Calcular planchas requeridas");
                Console.WriteLine("4. Verificar fabricacion");
                Console.WriteLine("5. Calcular maximo de estantes fabricables");
                Console.WriteLine("6. Actualizar stock");
                Console.WriteLine("7. Generar reporte");
                Console.WriteLine("8. Salir");
                Console.WriteLine("Ingrese una opcion: ");
                opcion = int.Parse(Console.ReadLine());
 
                // Usamos condicionales para poder darle a cada opcion un diferente proceso
                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese stock de planchas: ");
                        stockPlanchas = int.Parse(Console.ReadLine());
 
                        Console.WriteLine("Stock registrado correctamente");
                        break;
 
                    case 2:
                        Console.Write("Ingrese cantidad de estantes: ");
                        cantidadEstantes = int.Parse(Console.ReadLine());
 
                        paneles = cantidadEstantes * 5;
                        angulos = cantidadEstantes * 4;
 
                        Console.WriteLine($"Paneles necesarios: {paneles}");
                        Console.WriteLine($"Angulos necesarios: {angulos}");
                        break;
 
                    case 3:
                        //calculamos las planchas necesarias tanto para paneles como para angulos
                        planchasPaneles = paneles/5;
                        planchasAngulos = angulos/20;
 
                        //en caso el resultado de la division "angulos/20" de un numero decimal, se redondea con la operación dentro del if
                        if(angulos % 20 != 0)
                        {
                            planchasAngulos++;
                        }
                        //Se suman ambas cantidades de planchas para saber cuantas se necesitan en total
                        totalPlanchas = planchasPaneles + planchasAngulos;
                        
                        Console.WriteLine($"Planchas para paneles: {planchasPaneles}");
                        Console.WriteLine($"Planchas para angulos: {planchasAngulos}");
                        Console.WriteLine($"Total de planchas requeridas: {totalPlanchas}");
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
                        //debido a que se necesita hacer una division con decimales, maximoEstantes deberia ser un dato
                        //de tipo double pero esto trae complicaciones al momento de redondear ya que al hacer la division 
                        //nos resulta un numero decimal y si usamos "maximoEstantes--;" se le restará un numero en lugar de
                        //redondear el resultado, por ello se optó por transformar la operacion:
                        //dividir entre 1.2 es lo mismo que dividir entre 12/10 ----> 6/5 y aplicando division de fracciones seria:
                        //stockPlanchas / 6/5 ------> (stockPlanchas * 5) / 6 dándonos un número entero como resultado
                        maximoEstantes = (stockPlanchas * 5) / 6;
                        Console.WriteLine($"Cantidad maxima de estantes: {maximoEstantes}");
                        break;
 
                    case 6:
                        stockPlanchas = stockPlanchas - totalPlanchas;
 
                        Console.WriteLine($"Stock actualizado: {stockPlanchas}");
                        break;
 
                    case 7:
                        Console.WriteLine("===== REPORTE FINAL =====");
                        Console.WriteLine($"Stock actual: {stockPlanchas}");
                        Console.WriteLine($"Estantes solicitados: {cantidadEstantes}");
                        Console.WriteLine($"Planchas requeridas: {totalPlanchas}");
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
}