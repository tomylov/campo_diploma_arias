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

        public List<Modelo.Pagos> ListarPagos()
        {
            return Modelo.Contexto.Obtener_instancia().Pagos.ToList();
        }

        public void agregarPago(Modelo.Pagos pago)
        {
            Modelo.Contexto.Obtener_instancia().Pagos.Add(pago);
            Modelo.Contexto.Obtener_instancia().SaveChanges();
            int id_pago = Modelo.Contexto.Obtener_instancia().Pagos.Max(p=> p.numero);

            Modelo.Comprobantes comprobantes = new Modelo.Comprobantes();
            comprobantes.numero = id_pago;
            comprobantes.id_tipo = 2;
            Controladora.Comprobante.Obtener_instancia().AgregarComprobante(comprobantes);
            comprobantes.id_comp = Modelo.Contexto.Obtener_instancia().Comprobantes.Max(p => p.id_comp);

            pago.id_comp = comprobantes.id_comp;
            Modelo.Contexto.Obtener_instancia().Entry(pago).State = System.Data.Entity.EntityState.Modified;
        }

        public void modificarPago(Modelo.Pagos pago)
        {
            Modelo.Contexto.Obtener_instancia().Entry(pago).State = System.Data.Entity.EntityState.Modified;
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }

        public void eliminarPago(Modelo.Pagos pago)
        {
            Modelo.Contexto.Obtener_instancia().Pagos.Remove(pago);
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }
    }
}
