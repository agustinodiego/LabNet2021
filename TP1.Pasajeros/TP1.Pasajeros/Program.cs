using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.Pasajeros
{
    class Program
    {
        static string MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("S.R.L. Transportes");
            Console.WriteLine("==================");
            Console.WriteLine("INGRESE EL NUMERO DE LA OPCION DESEADA:");
            Console.WriteLine("1 - Modificar Parque Automotor");
            Console.WriteLine("2 - Consultar Detalle de Pasajeros");
            Console.WriteLine("3 - Recoger Pasajero");
            Console.WriteLine("4 - Despachar Pasajero");
            Console.WriteLine("0 - Salir");
            Console.Write(":");
            return Console.ReadLine();
        }
        static string ParqueAutomotor()
        {
            Console.Clear();
            Console.WriteLine("S.R.L. Transportes");
            Console.WriteLine("==================");
            Console.WriteLine("Se encuentra modificando el Parque Automotor");
            Console.WriteLine("INGRESE EL NUMERO DE LA OPCION DESEADA:");
            Console.WriteLine("1 - Agregar Omnibus");
            Console.WriteLine("2 - Agregar Taxi");
            Console.WriteLine("0 - Volver al Menu Principal");
            Console.Write(":");
            return Console.ReadLine();
        }
        static string DatosDeTransporte()
        {
            Console.Clear();
            Console.WriteLine("S.R.L. Transportes");
            Console.WriteLine("==================");
            Console.WriteLine("INGRESE LA CANTIDAD MAXIMA DE LUGARES QUE ADMITE EL TRANSPORTE");
            Console.Write(":");
            return Console.ReadLine();
        }

        static TransportePublico ListarYSeleccionarTransportePublico(List<TransportePublico> transportesPublicos)
        {

            if (transportesPublicos.Any())
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("S.R.L. Transportes");
                    Console.WriteLine("==================");
                    Console.WriteLine("SELECCIONE EL TRANSPORTE PUBLICO:");

                    //Mapeo entre el Transporte Publico elegido por pantalla y el de la lista.
                    Dictionary<int, int> mapIndices = new Dictionary<int, int>();

                    int NroTransporte = 0;
                    int Indice = 0;
                    foreach (var transporte in transportesPublicos)
                    {
                        if (transporte is Omnibus)
                        {
                            Indice++;
                            NroTransporte++;
                            Console.WriteLine("{0} - Omnibus {1}", Indice, NroTransporte);
                            mapIndices.Add(Indice, transportesPublicos.IndexOf(transporte));
                        }
                    }

                    NroTransporte = 0;
                    foreach (var transporte in transportesPublicos)
                    {
                        if (transporte is Taxi)
                        {
                            Indice++;
                            NroTransporte++;
                            Console.WriteLine("{0} - Taxi {1}", Indice, NroTransporte);
                            mapIndices.Add(Indice, transportesPublicos.IndexOf(transporte));
                        }
                    }
                    Console.WriteLine("0 - Volver al Menu Principal");
                    Console.Write(":");

                    if (int.TryParse(Console.ReadLine(), out int transporteElegido))
                    {
                        if (transporteElegido <= transportesPublicos.Count + 1 && transporteElegido > 0)
                        {
                            return transportesPublicos.ElementAt(mapIndices[transporteElegido]);
                        }
                        else
                        {
                            if (transporteElegido == 0)
                            {
                                return null;
                            }
                            else
                            {
                                Console.WriteLine("La opcion ingresada no es valida!");
                                Console.Write("Presione una tecla para continuar...");
                                Console.ReadLine();
                            }
                        }
                    }                    
                }
            }
            else
            {
                return null;
            }
        }

        static void ListarPasajeros(List<TransportePublico> transportesPublicos)
        {
            Console.Clear();
            Console.WriteLine("S.R.L. Transportes");
            Console.WriteLine("==================");
            
            if (transportesPublicos.Any())
            {
                int NroTransporte = 0;
                foreach (var transporte in transportesPublicos)
                {
                    if (transporte is Omnibus)
                    {
                        NroTransporte++;
                        Console.WriteLine("Omnibus {0}: {1} Pasajeros", NroTransporte, transporte.Pasajeros);
                    }
                }

                NroTransporte = 0;
                foreach (var transporte in transportesPublicos)
                {
                    if (transporte is Taxi)
                    {
                        NroTransporte++;
                        Console.WriteLine("Taxi {0}: {1} Pasajeros", NroTransporte, transporte.Pasajeros);
                    }
                }
            }
            else
            {
                Console.WriteLine("El Parque Automotor no cuenta con Transportes Publicos disponibles!");
                Console.Write("Presione una tecla para continuar...");
                Console.ReadLine();
            }
        }

        static void Main(string[] args)
        {
            List<TransportePublico> TransportesPublicos = new List<TransportePublico>();

            while (!int.TryParse(MenuPrincipal(), out int opcionMenuPrincipal) || opcionMenuPrincipal != 0)
            {
                switch (opcionMenuPrincipal)
                {
                case 1: //Modificar Parque Automotor
                    while (!int.TryParse(ParqueAutomotor(), out int opcion) || opcion != 0)
                    {
                        switch (opcion)
                        {
                            case 1: //Agregar Omnibus
                                int cantidadOmnibusEnParqueAutomotor = Omnibus.ObtenerCantidadEnParqueAutomotor();
                                if (cantidadOmnibusEnParqueAutomotor < Omnibus.CantidadMaximaPermitidaEnParqueAutomotor)
                                {
                                    if (int.TryParse(DatosDeTransporte(), out int capacidadLugares))
                                    {
                                        Omnibus omnibus = new Omnibus(capacidadLugares);
                                        TransportesPublicos.Add(omnibus);
                                        Console.WriteLine("Omnibus incorporado al Parque Automotor de forma exitosa!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("El Parque Automotor cuenta con su Máxima Cantidad Permitida ({0}) de Omnibus!", Omnibus.CantidadMaximaPermitidaEnParqueAutomotor);
                                }
                                Console.Write("Presione una tecla para continuar...");
                                Console.ReadLine();
                                break;
                            case 2: //Agregar Taxi
                                int cantidadTaxiEnParqueAutomotor = Taxi.ObtenerCantidadEnParqueAutomotor();
                                if (cantidadTaxiEnParqueAutomotor < Taxi.CantidadMaximaPermitidaEnParqueAutomotor)
                                {
                                    if (int.TryParse(DatosDeTransporte(), out int capacidadLugares))
                                    {
                                        Taxi taxi = new Taxi(capacidadLugares);
                                        TransportesPublicos.Add(taxi);
                                        Console.WriteLine("Taxi incorporado al Parque Automotor de forma exitosa!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("El Parque Automotor cuenta con su Máxima Cantidad Permitida ({0}) de Taxis!", Taxi.CantidadMaximaPermitidaEnParqueAutomotor);
                                }
                                Console.Write("Presione una tecla para continuar...");
                                Console.ReadLine();
                                break;
                            case 0:
                                break;
                            default:
                                Console.WriteLine("La opcion ingresada no es valida!");
                                Console.Write("Presione una tecla para continuar...");
                                Console.ReadLine();
                                break;
                        }
                    }
                    break;
                case 2: //Consultar Detalle de Pasajeros
                    if (TransportesPublicos.Any())
                    {
                        ListarPasajeros(TransportesPublicos);
                    }
                    else
                    {
                        Console.WriteLine("El Parque Automotor no cuenta con Transportes Publicos disponibles!");
                    }
                    Console.Write("Presione una tecla para continuar...");
                    Console.ReadLine();
                    break;
                case 3: //Recoger Pasajero
                    if (TransportesPublicos.Any())
                    {
                        TransportePublico transportePublicoElegido = ListarYSeleccionarTransportePublico(TransportesPublicos);
                        if (transportePublicoElegido != null)
                        {
                            if (transportePublicoElegido.HayLugaresDisponibles())
                            {
                                Console.WriteLine(transportePublicoElegido.Avanzar());
                                Console.WriteLine(transportePublicoElegido.Detenerse());
                            }
                            Console.WriteLine(transportePublicoElegido.RecogePasajero());
                        }
                    }
                    else
                    {
                        Console.WriteLine("El Parque Automotor no cuenta con Transportes Publicos disponibles!");
                    }
                    Console.Write("Presione una tecla para continuar...");
                    Console.ReadLine();
                    break;
                case 4: //Despachar Pasajero
                    if (TransportesPublicos.Any())
                    {
                        TransportePublico transportePublicoElegido = ListarYSeleccionarTransportePublico(TransportesPublicos);
                        if (transportePublicoElegido != null)
                        {
                            if (transportePublicoElegido.HayPasajerosEnTransporte())
                            {
                                Console.WriteLine(transportePublicoElegido.Avanzar());
                                Console.WriteLine(transportePublicoElegido.Detenerse());
                            }
                            Console.WriteLine(transportePublicoElegido.DejaPasajero());
                        }
                    }
                    else
                    {
                        Console.WriteLine("El Parque Automotor no cuenta con Transportes Publicos disponibles!");
                    }
                    Console.Write("Presione una tecla para continuar...");
                    Console.ReadLine();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("La opcion ingresada no es valida!");
                    Console.Write("Presione una tecla para continuar...");
                    Console.ReadLine();
                    break;
                }
            }
        }
    }
}
