using Modelo;
using Modelo.Estado;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Controladora
{
    public class Venta
    {
        private static Venta venta;
        Modelo.Contexto contexto = Modelo.Contexto.Obtener_instancia();


        public static Venta Obtener_instancia()
        {
            if (venta == null)
            {
                venta = new Venta();
            }
            return venta;
        }
        private Venta() { }

        public void agregarVenta(Modelo.Ventas venta)
        {
            Modelo.Contexto.Obtener_instancia().Ventas.Add(venta);
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }

        public void modificarVenta(Modelo.Ventas venta)
        {
            Modelo.Contexto.Obtener_instancia().Entry(venta).State = System.Data.Entity.EntityState.Modified;
            Modelo.Contexto.Obtener_instancia().SaveChanges();

            //Estados 1= pendiente 2= aceptado 3=En cuenta corriente 4= Pagado 5= Pagado cuenta 
        }

        public System.Collections.IList ListarVentasCC(int estado)
        {
            var vta = from v in Modelo.Contexto.Obtener_instancia().Ventas
                      join cl in Modelo.Contexto.Obtener_instancia().Clientes on v.id_cliente equals cl.id_cliente
                      join cc in Modelo.Contexto.Obtener_instancia().Cuentas_Corrientes on v.id_cliente equals cc.id_cliente
                      where v.id_estado == estado
                      orderby cc.plazo
                      select new
                      {
                          v.id_venta,
                          v.fecha,
                          cl.dni,
                          v.id_estado,
                          cl.nombre,
                          cl.telefono,
                          v.total
                      };
            return vta.ToList();
        }

        public List<VentaEstadoDTO> ListarVentasEstado(int id_estado)
        {
            var resultado = from v in contexto.Ventas
                            join c in contexto.Clientes on v.id_cliente equals c.id_cliente
                            where v.id_estado == id_estado
                            select new VentaEstadoDTO
                            {
                                id_venta = v.id_venta,
                                id_cliente = (int)v.id_cliente,
                                id_estado = (int)v.id_estado,
                                dni = (int)c.dni,
                                fecha = (DateTime)v.fecha,
                                total = v.total
                            };

            return resultado.ToList();
        }


        public List<Modelo.Ventas> listarVentasEstado(int id_estado)
        {
            var vta = from v in Modelo.Contexto.Obtener_instancia().Ventas
                      where v.id_estado == id_estado
                      select v;
            return vta.ToList();
        }


        public object Cacl_total(int idVta)
        {
            object monto = (from dv in Modelo.Contexto.Obtener_instancia().Detalle_ventas
                            where dv.id_venta == idVta
                            select dv.cantidad * dv.precio).Sum();
            return monto;
        }

        //Listo las ventas de un determinado cliente, y mando por parametro su estado 
        public List<Modelo.Ventas> ListarVentasClientes(int state, int id_cliente)
        {
            var vta = from v in Modelo.Contexto.Obtener_instancia().Ventas
                      where v.id_estado == state && v.id_cliente == id_cliente
                      select v;
            return vta.ToList();
        }

        public Modelo.Ventas getVentaId(int idVta)
        {
            var vta = from v in Modelo.Contexto.Obtener_instancia().Ventas
                      where v.id_venta == idVta
                      select v;
            return vta.FirstOrDefault();
        }

        public DateTime? ProximaVentaAVencer(int id_cliente, int estado)
        {
            var venta = Modelo.Contexto.Obtener_instancia().Ventas
                         .Where(v => v.id_cliente == id_cliente && v.id_estado == estado)
                         .OrderBy(v => v.fecha)
                         .Select(v => v.fecha)
                         .FirstOrDefault();

            if (venta.HasValue)
            {
                return venta.Value.AddDays(30);
            }

            return null;
        }

        public Modelo.Ventas ProximaVentaAVencerClienteCC(int id_cliente)
        {
            var venta = Modelo.Contexto.Obtener_instancia().Ventas
                         .Where(v => v.id_cliente == id_cliente && v.id_estado == 3 || v.id_estado == 1003)
                         .OrderBy(v => v.fecha)
                         .FirstOrDefault();
            return venta;
        }


        public System.Collections.IList ListarPagos(int id_cliente)
        {

            var pago = from p in Modelo.Contexto.Obtener_instancia().Pagos
                       join v in Modelo.Contexto.Obtener_instancia().Ventas on p.id_venta equals v.id_venta
                       join esv in Modelo.Contexto.Obtener_instancia().Estado_venta on v.id_estado equals esv.id_estado
                       where v.id_cliente == id_cliente
                       select new
                       {
                           numero_venta = v.id_venta,
                           p.fecha,
                           esv.descripcion,
                           monto = p.monto
                       };
            return pago.OrderByDescending(p => p.fecha).ToList();
        }

        public decimal ObtenerSumaPagosVenta(int idVenta)
        {

            decimal suma = Modelo.Contexto.Obtener_instancia().Pagos
                .Where(p => p.id_venta == idVenta)
                .Sum(p => (decimal?)p.monto) ?? 0;
            return suma;

        }

        private void updateMonto(int idcc, decimal monto, double days)
        {
            Modelo.Cuentas_Corrientes cc = Modelo.Contexto.Obtener_instancia().Cuentas_Corrientes.Find(idcc);
            cc.saldo += monto;
            cc.plazo = DateTime.Now.AddDays(days);
            Modelo.Contexto.Obtener_instancia().Entry(cc).State = System.Data.Entity.EntityState.Modified;
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }

        public void ventaCC(int id_venta, int id_cliente)
        {
            //Comprobantes: tipo 1: ventas - tipo 2: Pagos - tipo 3: nota de debito
            Modelo.Comprobantes comprobante = new Modelo.Comprobantes();
            comprobante.id_tipo = 1;
            comprobante.numero = id_venta;
            Modelo.Contexto.Obtener_instancia().Comprobantes.Add(comprobante);
            Modelo.Contexto.Obtener_instancia().SaveChanges();
            //Creo el movimiento tipo 1: baja deuda tipo 2: sube deuda
            Modelo.Movimientos movimiento = new Modelo.Movimientos();
            movimiento.tipo = 1;
            movimiento.id_comp = Modelo.Contexto.Obtener_instancia().Comprobantes.Max(c => c.id_comp);
            movimiento.id_cc = Modelo.Contexto.Obtener_instancia().Cuentas_Corrientes
                                                        .Where(cc => cc.id_cliente == id_cliente)
                                                        .Select(cc => cc.id_cc)
                                                        .FirstOrDefault();
            movimiento.fecha = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            Modelo.Contexto.Obtener_instancia().Movimientos.Add(movimiento);
            Modelo.Contexto.Obtener_instancia().SaveChanges();
            decimal monto = Convert.ToDecimal(Cacl_total(id_venta));
            updateMonto(Convert.ToInt32(movimiento.id_cc), -monto, 30);
        }

        public void deleteVta(int idVta)
        {

            List<Modelo.Detalle_ventas> detallesAEliminar = Modelo.Contexto.Obtener_instancia().Detalle_ventas.Where(d => d.id_venta == idVta).ToList();
            if (detallesAEliminar != null)
            {
                int i;
                for (i = 0; i < detallesAEliminar.Count; i++)
                {
                    Modelo.Detalle_ventas detalle = detallesAEliminar[i];
                    Controladora.Detalle_venta.Obtener_instancia().deleteDetVtaID(detalle.id_detalle);
                }
            }
            var ventaAEliminar = Modelo.Contexto.Obtener_instancia().Ventas.FirstOrDefault(v => v.id_venta == idVta);
            Modelo.Contexto.Obtener_instancia().Ventas.Remove(ventaAEliminar);
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }

        public void CambiarEstado(int ventaId, string opcion = null)
        {
            var venta = Contexto.Obtener_instancia().Ventas.Find(ventaId);
            if (venta == null)
                throw new ArgumentException("Venta no encontrada");

            venta.Estado = EstadoFactory.CrearEstado(venta.id_estado);
            venta.SiguienteEstado(opcion);
            Contexto.Obtener_instancia().SaveChanges();
        }

        public void AnularVenta(int ventaId)
        {
            var venta = Contexto.Obtener_instancia().Ventas.Find(ventaId);
            if (venta == null)
                throw new ArgumentException("Venta no encontrada");

            venta.Anular();
            Contexto.Obtener_instancia().SaveChanges();
        }

        public void EnviarEmailEstadoVenta(int ventaId)
        {
            var venta = Contexto.Obtener_instancia().Ventas.Find(ventaId);
            if (venta == null)
                throw new ArgumentException("Venta no encontrada");

            venta.Estado = EstadoFactory.CrearEstado(venta.id_estado);
            venta.EnviarEmailEstadoVenta();

            // No es necesario guardar cambios aquí, ya que enviar un email no modifica el estado
        }

    }
}
