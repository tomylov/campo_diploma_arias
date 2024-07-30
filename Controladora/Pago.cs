using Modelo;
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

        public List<Modelo.PagosDTO> ListarPagos()
        {
            Modelo.Contexto contexto = Modelo.Contexto.Obtener_instancia();
            var resultado = from p in contexto.Pagos
                            join mp in contexto.Medio_Pagos on p.id_med_pago equals mp.id_med_pago
                            join v in contexto.Ventas on p.id_venta equals v.id_venta
                            join c in contexto.Clientes on v.id_cliente equals c.id_cliente
                            orderby p.numero descending
                            select new PagosDTO
                            {
                                id_venta = p.id_venta,
                                id_estado = v.id_estado,
                                numero = p.numero,
                                dni = c.dni,
                                monto = p.monto,
                                fecha = p.fecha,
                                descripcion = mp.descripcion
                            };

            return resultado.ToList();
        }

        public Modelo.Pagos getPagoId(int nro)
        {
            return Modelo.Contexto.Obtener_instancia().Pagos.FirstOrDefault(p => p.numero == nro);
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
