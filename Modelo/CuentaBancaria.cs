namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CuentaBancaria
    {
        public CuentaBancaria(int numeroDeCuenta, int saldo)
        {
            NumeroDeCuenta = numeroDeCuenta;
            Movimientos = new List<MovimientoBancario>();
        }

        public int NumeroDeCuenta;

        public List<MovimientoBancario> Movimientos { get; set; }
    }
}
