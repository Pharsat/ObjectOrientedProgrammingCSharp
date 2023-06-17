using HerenciaYPolimorfismo.Formas;

namespace TestHerenciaYPolimorfismo
{
    using HerenciaYPolimorfismo;

    internal class Program
    {
        static void Main(string[] args)
        {
            var triangulo = new Triangulo()
            {
                Base = 10,
                Altura = 5
            };

            var cuadrado = new Cuadrado()
            {
                Lado = 10
            };

            var formas = new List<IForma>()
            {
                triangulo,
                cuadrado,
                new Circulo()
                {
                    Radio = 3
                }
            };

            foreach (var forma in formas)
            {
                Console.WriteLine($"El area del {forma.Nombre} es: " + forma.CalcularArea());
                Console.WriteLine($"El perimetro del {forma.Nombre} es: " + forma.CalcularPerimetro());
            }

            Console.ReadLine();
        }
    }
}