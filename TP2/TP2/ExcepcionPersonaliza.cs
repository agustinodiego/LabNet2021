using System;

namespace TP2
{
    public class ExcepcionPersonaliza : Exception
    {
        public ExcepcionPersonaliza(string mensaje)
            : base(mensaje)
        {
        }
        public override string Message => string.Format("SOBRECARGA DEL MENSAJE DE LA EXCEPCION - {0}",base.Message); 
    }
}
