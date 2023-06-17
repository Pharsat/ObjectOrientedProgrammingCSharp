namespace HerenciaYPolimorfismo.Formas
{
    using System;

    public class Circulo: IForma
    {
        public int Radio { get; set; }

        public double CalcularPerimetro()
        {
            return 2 * Math.PI * Radio;
        }

        public double CalcularArea()
        {
            return Math.PI * Radio * Radio;
        }

        public string Nombre => nameof(Circulo);
    }
}
