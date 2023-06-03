namespace Modelo
{
    public class MovimientoBancario
    {
        public MovimientoBancario(DateTime fecha, int valor)
        {
            Fecha = fecha;
            Valor = valor;
        }

        // La fecha se utiliza para hacer el seguimiento de los movimientos.
        public DateTime Fecha { get; set; }

        /*
         * Cada movimiento tiene un valor, si es positivo
         * significa una consignmación y si es negativo es
         * un retiro
         */
        public int Valor { get; set; }
    }
}
