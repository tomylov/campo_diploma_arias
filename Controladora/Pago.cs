using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class Pago
    {
        private static Pago pago;

        public static Pago Obtener_instancia()
        {
            if (pago == null)
            {
                pago = new Pago();
            }
            return pago;
        }

        public void agregarPago(Modelo.Pagos pago)
        {
            Modelo.Contexto.Obtener_instancia().Pagos.Add(pago);
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }

        public void modificarPago(Modelo.Pagos pago)
        {
            Modelo.Contexto.Obtener_instancia().Entry(pago).State = System.Data.Entity.EntityState.Modified;
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }

        public void eliminarPago(Modelo.Pagos pago)
        {
            Modelo.Contexto.Obtener_instancia().Entry(pago).State = System.Data.Entity.EntityState.Modified;
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }
    }
}
