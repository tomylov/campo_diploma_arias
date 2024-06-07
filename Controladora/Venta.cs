using Modelo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class Venta
    {
        private static Venta venta;
        Modelo.Contexto contexto = Modelo.Contexto.Obtener_instancia();


        public static Venta Obtener_instancia()
        {
            if (venta==null)
            {
                venta = new Venta();
            }
            return venta;
        }

        public void SetVentas(int dni)
        {
            Modelo.Ventas vta = new Modelo.Ventas();
            vta.fecha= Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            vta.dni = dni;
            vta.estado = 1;
            Modelo.Contexto.Obtener_instancia().Ventas.Add(vta);
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }

        public System.Collections.IList ListarVentasCC(int estado)
        {
            var vta = from v in Modelo.Contexto.Obtener_instancia().Ventas
                      join cc in Modelo.Contexto.Obtener_instancia().Cuentas_Corrientes on v.dni equals cc.dni
                      join cl in Modelo.Contexto.Obtener_instancia().Clientes on v.dni equals cl.dni
                      where v.estado == estado
                      orderby cc.plazo
                      select new
                      {
                          v.id_venta,
                          v.fecha,
                          v.dni,
                          v.estado,
                          cl.nombre,
                          cl.telefono,
                          cc.plazo
                      };
            return vta.ToList();
        }

        public IEnumerable ListarVentasEstado(int estado)
        {
            var resultado = from venta in Modelo.Contexto.Obtener_instancia().Ventas
                            join detalle in Modelo.Contexto.Obtener_instancia().Detalle_ventas
                            on venta.id_venta equals detalle.id_venta
                            where venta.estado == estado
                            group new { venta, detalle } by new
                            {
                                venta.id_venta,
                                venta.estado,
                                venta.dni
                            } into g
                            select new
                            {
                                id_venta = g.Key.id_venta,
                                dni = g.Key.dni,
                                total = g.Sum(x => x.detalle.precio * x.detalle.cantidad),
                                estado = g.Key.estado
                            };

            return resultado.ToList();
        }

        public List<Modelo.Ventas> listarVentasEstado(int estado)
        {
            var vta = from v in Modelo.Contexto.Obtener_instancia().Ventas
                      where v.estado == estado
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
        public List<Modelo.Ventas> ListarVentas(int state,int dni)
        {
                var vta = from v in Modelo.Contexto.Obtener_instancia().Ventas
                          where v.estado == state && v.dni == dni
                          select v;
            return vta.ToList();            
        }

        public System.Collections.IList ListarVentasId(int id_vta)
        {

            var vta = from v in Modelo.Contexto.Obtener_instancia().Ventas
                      where v.id_venta == id_vta
                      select new
                      {
                          v.id_venta,
                          v.fecha,
                          v.estado
                      };
            return vta.ToList();
        }

        public System.Collections.IList ListarPagos(int dni)
        {

            var pago = from p in Modelo.Contexto.Obtener_instancia().Pagos
                            join v in Modelo.Contexto.Obtener_instancia().Ventas on p.id_venta equals v.id_venta
                            where v.dni == dni
                            select new
                            {
                                numero_venta = v.id_venta,
                                p.fecha,
                                v.estado,
                                monto = p.monto
                            };
            return pago.ToList();
        }

        public void cambiarEStado(int id_venta,int estado)
        {
            //Estados 0=cancelado 1=listo para retirar 2=En cuenta corriente 3=Moroso 4=Pagado 5=pagado con cuenta corriente
            Modelo.Ventas vta= Modelo.Contexto.Obtener_instancia().Ventas.Find(id_venta);
            vta.estado = estado;
            Modelo.Contexto.Obtener_instancia().Entry(vta).State = System.Data.Entity.EntityState.Modified;
            Modelo.Contexto.Obtener_instancia().SaveChanges();

        }

        private void updateMonto(int idcc,decimal monto,double days)
        {
            Modelo.Cuentas_Corrientes cc= Modelo.Contexto.Obtener_instancia().Cuentas_Corrientes.Find(idcc);
            cc.saldo += monto;
            cc.plazo = DateTime.Now.AddDays(days);
            Modelo.Contexto.Obtener_instancia().Entry(cc).State = System.Data.Entity.EntityState.Modified;
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }

        public void ventaCC(int id_venta,int dni)
        {
            //Comprobantes: tipo 1: ventas - tipo 2: Pagos - tipo 3: nota de debito
            Modelo.Comprobantes comprobante = new Modelo.Comprobantes();
            comprobante.tipo = 1;
            comprobante.numero = id_venta;
            Modelo.Contexto.Obtener_instancia().Comprobantes.Add(comprobante);
            Modelo.Contexto.Obtener_instancia().SaveChanges();
            //Cambio el estado de la venta a cuenta corriente
            cambiarEStado(id_venta, 2);
            //Creo el movimiento tipo 1: baja deuda tipo 2: sube deuda
            Modelo.Movimientos movimiento = new Modelo.Movimientos();
            movimiento.tipo = 1;
            movimiento.id_comp = Modelo.Contexto.Obtener_instancia().Comprobantes.Max(c => c.id_comp);
            movimiento.id_cc = Modelo.Contexto.Obtener_instancia().Cuentas_Corrientes
                                                        .Where(cc => cc.dni == dni)
                                                        .Select(cc=>cc.id_cc)
                                                        .FirstOrDefault();
            movimiento.fecha = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            Modelo.Contexto.Obtener_instancia().Movimientos.Add(movimiento);
            Modelo.Contexto.Obtener_instancia().SaveChanges();
            decimal monto = Convert.ToDecimal(Cacl_total(id_venta));
            updateMonto(Convert.ToInt32(movimiento.id_cc),-monto,30);
        }

        public void deleteVta(int idVta)
        {

            List<Modelo.Detalle_ventas> detallesAEliminar = Modelo.Contexto.Obtener_instancia().Detalle_ventas.Where(d => d.id_venta == idVta).ToList();
            if (detallesAEliminar != null)
            {
                int cantidad;
                int idProd = 0;
                int i;
                for (i = 0; i < detallesAEliminar.Count; i++)
                {
                    cantidad = (int)detallesAEliminar[i].cantidad;
                    idProd = (int)detallesAEliminar[i].id_prod;
                    Controladora.Detalle_venta.Obtener_instancia().deleteDetVta(detallesAEliminar[i].id_detalle, cantidad, idProd);
                    
                }
            }
            var ventaAEliminar = Modelo.Contexto.Obtener_instancia().Ventas.FirstOrDefault(v => v.id_venta == idVta);
            Modelo.Contexto.Obtener_instancia().Ventas.Remove(ventaAEliminar);
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }

    }
}
