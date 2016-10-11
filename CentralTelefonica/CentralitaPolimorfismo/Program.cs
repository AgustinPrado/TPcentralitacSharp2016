using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaPolimorfismo
{
    class Program
    {
        static void Main(string[] args)
        {
            Centralita telefonica = new Centralita("Telefonica");

            Local llamada1 = new Local("Caballito", 30F, "Avellaneda", 2.65F);
            Provincial llamada2 = new Provincial("Flores", Franja.Franja_1, 21F, "Floresta");
            Local llamada3 = new Local("Congreso", 45F, "Belgrano", 1.99F);
            Provincial llamada4 = new Provincial(Franja.Franja_3, llamada2);

            telefonica += llamada1;
            telefonica += llamada2;
            telefonica += llamada3;
            telefonica += llamada4;
            telefonica += llamada1;
            telefonica += llamada2;

            telefonica.Mostrar();

            telefonica.OrdenerLlamadas();

            telefonica.Mostrar();

            Console.ReadKey();
        }
    }
}
