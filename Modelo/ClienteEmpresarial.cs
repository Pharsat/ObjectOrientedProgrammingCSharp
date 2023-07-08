namespace Modelo
{
    using System;

    public class ClienteEmpresarial : Cliente
    {
        public ClienteEmpresarial(string nombre) : base(nombre)
        {
        }

        public override MovimientoBancario EjecutarMovimiento(int dinero)
        {
            var diezPorCiento = dinero * 0.1;
            dinero += (int)diezPorCiento;
            MovimientoBancario movimiento = new MovimientoBancario(DateTime.Now, dinero);
            Cuenta.Movimientos.Add(movimiento);

            return movimiento;
        }
    }
}
