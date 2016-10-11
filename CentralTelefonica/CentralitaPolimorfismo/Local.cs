using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaPolimorfismo
{
    public class Local : Llamada
    {
        protected float _costo;
        public override float CostoLlamada
        {
            get
            {
                return this.CalcularCosto();
            }
        }

        public Local(string origen, float duracion, string destino, float costo)
            : base(origen, destino, duracion)
        {
            this._costo = costo;
        }

        public Local(Llamada unaLlamada, float costo)
            : this(unaLlamada.NroOrigen, unaLlamada.Duracion, unaLlamada.NroDestino, costo)
        {
            // Reutilizo constructor anterior.
        }

        private float CalcularCosto()
        {
            return this._costo * this._duracion;
        }

        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Mostrar() + "y costó $" + this.CostoLlamada);

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            return (obj is Local);
        }

        public override string ToString()
        {
            return this.Mostrar();
        }
        
    }
}
