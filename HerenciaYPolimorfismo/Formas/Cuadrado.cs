namespace HerenciaYPolimorfismo.Formas
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Cuadrado : IForma
    {
        public int Lado { get; set; }

        public string Nombre => nameof(Cuadrado);

        public double CalcularArea()
        {
            return Lado * Lado;
        }

        public double CalcularPerimetro()
        {
            return Lado * 4;
        }
    }
}
