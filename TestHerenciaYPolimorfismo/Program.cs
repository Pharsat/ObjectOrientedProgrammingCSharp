using HerenciaYPolimorfismo.Formas;

namespace TestHerenciaYPolimorfismo
{
    using HerenciaYPolimorfismo;

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int y = 5 / 5; // Esto generará una excepción
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Ocurrió una excepción: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Este bloque se ejecutará siempre, independientemente de si ocurrió una excepción o no.");
            }
        }
    }
}