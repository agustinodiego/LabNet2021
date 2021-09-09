using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.Pasajeros
{
    public abstract class TransportePublico
    {
        public static int CapacidadLugares = 0;

        private int _pasajeros;
        public int Pasajeros
        {
            get { return _pasajeros; }
            private set { _pasajeros = value; }
        }

        public TransportePublico(int capacidadLugares)
        {
            CapacidadLugares = capacidadLugares;
            _pasajeros = 0;
        }

        public abstract string Avanzar();
        public abstract string Detenerse();

        public bool HayLugaresDisponibles()
        {
            return this._pasajeros < CapacidadLugares;
        }
        public bool HayPasajerosEnTransporte()
        {
            return this._pasajeros > 0;
        }
        public string RecogePasajero()
        {
            string mensaje = string.Empty; 

            if(this.HayLugaresDisponibles())
            {
                _pasajeros++;
                CapacidadLugares--;
                mensaje = "Pasajero a Bordo!";
            }
            else
            {
                mensaje = "Transporte sin espacio!";
            }
            return mensaje;
        }
        public string DejaPasajero()
        {
            string mensaje = string.Empty;

            if (this.HayPasajerosEnTransporte())
            {
                _pasajeros--;
                CapacidadLugares++;
                mensaje = "Pasajero en Destino!";
            }
            else
            {
                mensaje = "Transporte vacio!";
            }
            return mensaje;
        }

    }
}
