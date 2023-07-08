namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ClienteNatural : Cliente
    {
        public ClienteNatural(string nombre) : base(nombre)
        {
            
        }

        public override MovimientoBancario EjecutarMovimiento(int dinero)
        {
            return base.EjecutarMovimiento(dinero);
        }
    }
}
