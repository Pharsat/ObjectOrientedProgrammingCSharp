namespace Intro
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Cliente
    {
        public Cliente(string nombre)
        {
            Nombre = nombre;
        }

        public string Nombre;
        public CuentaBancaria Cuenta;

        public void Consignar(int dinero)
        {
            Cuenta.Saldo = Cuenta.Saldo + dinero;
        }

        public void Retirar(int dinero)
        {
            Cuenta.Saldo = Cuenta.Saldo - dinero;
        }
    }


}
