using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
    public class Local : Llamada
    {
        protected float _costo;
        public float CostoLlamada
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

        new public void Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("La llamada desde "
                + this.NroOrigen
                + " a "
                + this.NroDestino
                + " duró "
                + this.Duracion
                + " segundos y costó $"
                + this.CostoLlamada);

            Console.WriteLine(sb);
        }
    }
}
