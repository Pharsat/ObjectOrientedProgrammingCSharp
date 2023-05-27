namespace Intro
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class CuentaBancaria
    {
        public CuentaBancaria(int numeroDeCuenta, int saldo)
        {
            NumeroDeCuenta = numeroDeCuenta;
            Saldo = saldo;
        }

        public int NumeroDeCuenta;
        public int Saldo;
    }
}
