namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Cliente
    {
        public Cliente(string nombre)
        {
            Nombre = nombre;
        }

        public string Nombre;
        public int Cedula;
        public CuentaBancaria Cuenta;

        public void EjecutarMovimiento(int dinero)
        {
            MovimientoBancario movimiento = new MovimientoBancario(DateTime.Now, dinero);
            Cuenta.Movimientos.Add(movimiento);
        }
    }
}
