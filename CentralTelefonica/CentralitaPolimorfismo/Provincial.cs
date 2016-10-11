using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaPolimorfismo
{
    public class Provincial : Llamada
    {
        protected Franja _franjaHoraria;
        public override float CostoLlamada
        {
            get
            {
                return this.CalcularCosto();
            }
        }

        public Provincial(string origen, Franja miFranja, float duracion, string destino)
            : base(origen, destino, duracion)
        {
            this._franjaHoraria = miFranja;
        }

        public Provincial(Franja miFranja, Llamada unaLlamada)
            : this(unaLlamada.NroOrigen, miFranja, unaLlamada.Duracion, unaLlamada.NroDestino)
        {
            // Reutilizo constructor anterior.
        }

        private float CalcularCosto()
        {
            float franja;
            switch (this._franjaHoraria)
            {
                case Franja.Franja_1:
                    franja = 0.99F;
                    break;
                case Franja.Franja_2:
                    franja = 1.25F;
                    break;
                case Franja.Franja_3:
                    franja = 0.66F;
                    break;
                default:
                    franja = 0F;
                    break;
            }
            
            return this.Duracion * franja;
        }

        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Mostrar() 
                + "y costó $" 
                + this.CostoLlamada
                + ". Pertene a la franja \""
                + this._franjaHoraria.ToString());

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            return (obj is Provincial);
        }

        public override string ToString()
        {
            return this.Mostrar();
        }
    }
}
