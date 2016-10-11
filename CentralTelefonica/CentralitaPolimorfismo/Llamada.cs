using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaPolimorfismo
{
    public abstract class Llamada
    {
        protected float _duracion;
        public float Duracion
        {
            get
            {
                return this._duracion;
            }
        }
        protected string _nroDestino;
        public string NroDestino
        {
            get
            {
                return this._nroDestino;
            }
        }
        protected string _nroOrigen;
        public string NroOrigen
        {
            get
            {
                return this._nroOrigen;
            }
        }
        public abstract float CostoLlamada
        {
            get;
        }


        public Llamada (string origen, string destino, float duracion)
        {
            this._nroOrigen = origen;
            this._nroDestino = destino;
            this._duracion = duracion;
        }

        public static int OrdenarPorDuracion(Llamada uno, Llamada dos)
        {
            return uno._duracion.CompareTo(dos._duracion);
        }

        protected virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("La llamada desde "
                + this.NroOrigen
                + " a " 
                + this.NroDestino 
                + " duró "
                + this.Duracion
                + " segundos.");

            return sb.ToString();
        }

        public static bool operator ==(Llamada uno, Llamada dos)
        {
            if (uno.Equals(dos))
            {
                if (String.Compare(uno.NroOrigen, dos.NroOrigen) == 0)
                {
                    if (String.Compare(uno.NroDestino, uno.NroDestino) == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator !=(Llamada uno, Llamada dos)
        {
            return !(uno == dos);
        }
    }
}
