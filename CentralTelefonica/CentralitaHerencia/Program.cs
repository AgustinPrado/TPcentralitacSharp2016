using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
    class Program
    {
        static void Main()
        {
            Centralita telefonica = new Centralita("Telefonica");

            Local llamada1 = new Local("Caballito", 30F, "Flores", 2.65F);
            Provincial llamada2 = new Provincial("Belgrano", Franja.Franja_1, 21F, "Avellaneda");
            Local llamada3 = new Local("Lugano", 45F, "Mataderos", 1.99F);
            Provincial llamada4 = new Provincial(Franja.Franja_3, llamada2);

            telefonica.Llamadas.Add(llamada1);
            telefonica.Llamadas.Add(llamada2);
            telefonica.Llamadas.Add(llamada3);
            telefonica.Llamadas.Add(llamada4);

            float ganancia = telefonica.GananciaTotal;

            telefonica.Mostrar();

            Console.ReadKey();
        }
    }
}
