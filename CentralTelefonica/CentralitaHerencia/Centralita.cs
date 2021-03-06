﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
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
            Local auxLocal;
            Provincial auxProvincial;

            foreach (Llamada item in this.Llamadas)
            {
                if(item.GetType() == typeof(Local))
                {
                    auxLocal = (Local)item;
                    gananciaLocal += auxLocal.CostoLlamada;
                }
                else if (item.GetType() == typeof(Provincial))
                {
                    auxProvincial = (Provincial)item;
                    gananciaProvincial += auxProvincial.CostoLlamada;
                }
            }

            if (tipo == TipoLlamada.Local)
                return gananciaLocal;
            else if (tipo == TipoLlamada.Provincial)
                return gananciaProvincial;
            return gananciaProvincial + gananciaLocal;
            


            /*
             * FALLA AL ENCONTRAR UNA LLAMADA LOCAL CUANDO ES PROVINCIAL Y VICEVERSA.
             * LLAMADA DEBERÍA TENER LA PROPIEDAD CostoLlamada PARA QUE FUNCIONE.
             *
            float ganancia = 0; 
            if ((tipo == TipoLlamada.Local) || (tipo == TipoLlamada.Todas))
            {
                foreach (Local item in this.Llamadas)
                {
                    ganancia += item.CostoLlamada;
                }
            }
            if((tipo == TipoLlamada.Provincial) || (tipo == TipoLlamada.Todas))
            {
                foreach (Provincial item in this.Llamadas)
                {
                    ganancia += item.CostoLlamada;
                }
            }
            
            
            return ganancia;
            */
        }

        public void OrdenerLlamadas()
        {
            this.Llamadas.Sort(Llamada.OrdenarPorDuracion);
        }

        public void Mostrar()
        {
            Local auxLocal;
            Provincial auxProvincial;

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
                    auxLocal = (Local)item;
                    auxLocal.Mostrar();
                }
                else if (item is Provincial)
                {
                    auxProvincial = (Provincial)item;
                    auxProvincial.Mostrar();
                }
            }
     
        }
    }
}
