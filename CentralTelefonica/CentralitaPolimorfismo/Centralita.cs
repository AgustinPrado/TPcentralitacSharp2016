using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaPolimorfismo
{
    public class Centralita
    {
        private List<Llamada> _listaDeLlamadas;
        public List<Llamada> Llamadas
        {
            get
            {
                return this._listaDeLlamadas;
            }
        }
        protected string _razonSocial;

        public float GananciaPorLocal
        {
            get
            {
                return this.CalcularGanancia(TipoLlamada.Local);
            }
        }
        public float GananciaPorProvincial
        {
            get
            {
                return this.CalcularGanancia(TipoLlamada.Provincial);
            }
        }
        public float GananciaTotal
        {
            get
            {
                return this.CalcularGanancia(TipoLlamada.Todas);
            }
        }

        public Centralita()
        {
            this._listaDeLlamadas = new List<Llamada>();
            this._razonSocial = "Sin Nombre";
        }

        public Centralita(string nombreEmpresa)
            : this()
        {
            this._razonSocial = nombreEmpresa;
        }

        private float CalcularGanancia(TipoLlamada tipo)
        {
            
            float gananciaLocal = 0;
            float gananciaProvincial = 0;

            foreach (Llamada item in this.Llamadas)
            {
                if(item is Local)
                {
                    gananciaLocal += item.CostoLlamada;
                }
                else if (item is Provincial)
                {
                    gananciaProvincial += item.CostoLlamada;
                }
            }

            if (tipo == TipoLlamada.Local)
                return gananciaLocal;
            else if (tipo == TipoLlamada.Provincial)
                return gananciaProvincial;
            return gananciaProvincial + gananciaLocal;
        }

        public void OrdenerLlamadas()
        {
            this.Llamadas.Sort(Llamada.OrdenarPorDuracion);
        }

        public void Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Razón social: " + this._razonSocial);
            sb.AppendLine("Ganancia total: $" + this.GananciaTotal);
            sb.AppendLine("Ganancia por llamadas locales: $" + this.GananciaPorLocal);
            sb.AppendLine("Ganancia por llamadas provinciales: $" + this.GananciaPorProvincial);
            sb.AppendLine("Detalle de llamdas:");

            Console.WriteLine(sb);

            foreach (Llamada item in this.Llamadas)
            {
                if (item is Local)
                {
                    Console.WriteLine(item.ToString()); 
                }
                else if (item is Provincial)
                {
                    Console.WriteLine(item.ToString()); 
                }
            }
     
        }

        private void AgregarLlamada(Llamada nuevaLlamada)
        {
            this._listaDeLlamadas.Add(nuevaLlamada);
        }

        public static bool operator ==(Centralita central, Llamada nuevaLlamada)
        {
            foreach (Llamada item in central._listaDeLlamadas)
            {
                if (item == nuevaLlamada)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Centralita central, Llamada nuevaLlamada)
        {
            return !(central == nuevaLlamada);
        }

        public static Centralita operator +(Centralita central, Llamada nuevaLlamada)
        {
            if (central != nuevaLlamada)
            {
                central.AgregarLlamada(nuevaLlamada);
            }
            else
                Console.WriteLine("La llamada ya se encuentra en la central.");
            return central;
        }
    }
}
