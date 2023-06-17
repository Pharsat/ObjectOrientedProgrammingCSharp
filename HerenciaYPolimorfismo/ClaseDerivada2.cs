namespace HerenciaYPolimorfismo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ClaseDerivada2 : ClaseDerivada1
    {
        public ClaseDerivada2()
        {
            Console.WriteLine($"Constructor clase derivada 2. El nombre es {Nombre}");
        }
    }
}
