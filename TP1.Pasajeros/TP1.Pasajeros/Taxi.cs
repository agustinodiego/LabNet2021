using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.Pasajeros
{
    public class Taxi : TransportePublico
    {
        public const int CantidadMaximaPermitidaEnParqueAutomotor = 5;
        private static int CantidadEnParqueAutomotor = 0;

        public Taxi(int capacidadLugares) 
            : base(capacidadLugares)
        {
            CantidadEnParqueAutomotor++;
        }
        public static int ObtenerCantidadEnParqueAutomotor()
        {
            return CantidadEnParqueAutomotor;
        }
        public override string Avanzar()
        {
            return $"El Taxi avanza hacia el destino!";
        }

        public override string Detenerse()
        {
            return $"El Taxi se detiene en el destino!";
        }
    }
}
