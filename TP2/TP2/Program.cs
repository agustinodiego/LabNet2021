using System;
using System.Windows.Forms;

namespace TP2
{
    public class Logic
    {
        public static void GenerarExcepcionRandom()
        {
            Random rand = new Random();
            int opcion = rand.Next(1, 4);

            switch (opcion)
            {
                case 1:
                    throw new InvalidOperationException();
                case 2:
                    throw new ArgumentOutOfRangeException();
                case 3:
                    throw new StackOverflowException();
            }
        }
    }

    class Program
    {
        static string MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("Prueba de Conceptos");
            Console.WriteLine("===================");
            Console.WriteLine("INGRESE EL NUMERO DE LA OPCION DESEADA:");
            Console.WriteLine("1 - Generar Excepcion - Division por Cero");
            Console.WriteLine("2 - Realizar Division entre dos numeros");
            Console.WriteLine("3 - Generar Excepcion - Clase Logic - Random");
            Console.WriteLine("4 - Generar Excepcion Personalizada - Nueva Clase Logic en Proyecto ");
            Console.WriteLine("0 - Salir");
            Console.Write(":");
            return Console.ReadLine();
        }
        static void GenerarExcepcionDivisionPorCero()
        {
            const int Divisor = 0;
            bool ExcepcionCapturada = false;

            while (!ExcepcionCapturada)
            {
                Console.Clear();
                Console.WriteLine("Generar Excepcion - Division por Cero");
                Console.WriteLine("=====================================");
                Console.WriteLine("INGRESE UN VALOR PARA EL DIVIDENDO DE LA DIVISION:");
                Console.Write(":");
            
                if (int.TryParse(Console.ReadLine(), out int dividendo))
                {
                    try
                    {
                        int resultado = dividendo / Divisor;
                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.WriteLine("Mensaje de Excepcion: {0}", ex.Message);
                        ExcepcionCapturada = true;
                    }
                    finally
                    {
                        Console.WriteLine("Finalizo la division por Cero!!!");
                        Console.WriteLine("Presione una tecla para continuar...");
                        Console.ReadLine();
                    };
                }
            }
        }
        static void RealizarDivision()
        {
            bool ingresoValorCorrecto = false;

            while (!ingresoValorCorrecto)
            {
                Console.Clear();
                Console.WriteLine("Realizar Division entre dos numeros");
                Console.WriteLine("=====================================");
                Console.WriteLine("INGRESE EL VALOR DEL DIVIDENDO:");
                Console.Write(":");
                try
                {
                    int dividendo = int.Parse(Console.ReadLine());
                    Console.WriteLine("INGRESE EL VALOR DEL DIVISOR:");
                    Console.Write(":");
                    int divisor = int.Parse(Console.ReadLine());
                    int resultado = dividendo / divisor;
                    Console.WriteLine("El resultado de la division es: {0}", resultado);
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadLine();
                    ingresoValorCorrecto = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Seguro Ingreso una letra o no ingreso nada!");
                    Console.WriteLine("Mensaje de Excepcion: {0}", ex.Message);
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadLine();
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine("Solo Chuck Norris divide por cero!");
                    Console.WriteLine("Mensaje de Excepcion: {0}", ex.Message);
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadLine();
                }
            }
        }
        static void GenerarExcepcionClaseLogic()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Generar Excepcion - Clase Logic");
                Console.WriteLine("=====================================");
                Logic.GenerarExcepcionRandom();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Tipo de la Excepcion: {0}", ex.GetType().Name);
                Console.WriteLine("Mensaje de la Excepcion: {0}", ex.Message);
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadLine();
            }
        }
        static void GenerarExcepcionPersonalizada()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Generar Excepcion Personalizada - Nueva Clase Logic en Proyecto");
                Console.WriteLine("===============================================================");
                throw new ExcepcionPersonaliza("Se genero una excepcion personalizada!!!");
            }
            catch(ExcepcionPersonaliza ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadLine();
            }
        }

        static void Main(string[] args)
        {
            while (!int.TryParse(MenuPrincipal(), out int opcionMenuPrincipal) || opcionMenuPrincipal != 0)
            {
                switch (opcionMenuPrincipal)
                {
                    case 1:
                        GenerarExcepcionDivisionPorCero();
                        break;
                    case 2:
                        RealizarDivision();
                        break;
                    case 3:
                        GenerarExcepcionClaseLogic();
                        break;
                    case 4:
                        GenerarExcepcionPersonalizada();
                        break;
                    case 0:
                        break;
                }
            }
        }
    }
}
