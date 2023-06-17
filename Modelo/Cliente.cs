namespace Modelo
{
    using System;

    public abstract class Cliente
    {
        public string Nombre { get; set; }

        public Cliente(string nombre)
        {
            Nombre = nombre;
        }

        public CuentaBancaria Cuenta;

        public virtual void EjecutarMovimiento(int dinero)
        {
            MovimientoBancario movimiento = new MovimientoBancario(DateTime.Now, dinero);
            Cuenta.Movimientos.Add(movimiento);
        }
    }
}
