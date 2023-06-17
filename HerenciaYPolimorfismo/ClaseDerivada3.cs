namespace HerenciaYPolimorfismo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ClaseDerivada3 : ClaseDerivada2
    {
        public ClaseDerivada3()
        {
            Nombre = "Julian";
            Console.WriteLine($"Constructor clase derivada 3. El nombre es {Nombre}");
        }
    }
}
