namespace HerenciaYPolimorfismo.Formas
{
    public class Triangulo : IForma
    {
        public int Lado1 { get; set; }

        public int Lado2 { get; set; }

        public int Lado3 { get; set; }

        public int Base { get; set; }

        public int Altura { get; set; }

        public string Nombre => nameof(Triangulo);

        public double CalcularArea()
        {
            return (Base * Altura) / 2;
        }

        public double CalcularPerimetro()
        {
            return Lado1 + Lado2 + Lado3;
        }
    }
}
