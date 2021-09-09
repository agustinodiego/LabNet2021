using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.Pasajeros
{
    public class Omnibus : TransportePublico
    {
        public const int CantidadMaximaPermitidaEnParqueAutomotor = 5;
        private static int CantidadEnParqueAutomotor = 0;  

        public Omnibus(int capacidadLugares)
            :base(capacidadLugares)
        {
            CantidadEnParqueAutomotor++;
        }
        public static int ObtenerCantidadEnParqueAutomotor()
        {
            return CantidadEnParqueAutomotor;
        }
        public override string Avanzar()
        {
            return $"El Omnibus avanza a la siguiente parada!";
        }

        public override string Detenerse()
        {
            return $"El Omnibus se detiene en la parada!";
        }
    }
}
