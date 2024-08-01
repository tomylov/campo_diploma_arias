using Modelo;
using System.Linq;

namespace Controladora
{
    public class Detalle_venta
    {
        private static Detalle_venta det;

        public static Detalle_venta Obtener_instancia()
        {
            if (det == null)
            {
                det = new Detalle_venta();
            }
            return det;
        }
        private Detalle_venta() { }

        public void updateStock(int? id_prod, int? cantidad)
        {
            Modelo.Productos prod = Modelo.Contexto.Obtener_instancia().Productos.FirstOrDefault(p => p.id_prod == id_prod);

            if (prod != null)
            {
                prod.stock += cantidad;
                Modelo.Contexto.Obtener_instancia().Entry(prod).State = System.Data.Entity.EntityState.Modified;
                Modelo.Contexto.Obtener_instancia().SaveChanges();
            }
        }

        public void AgregarDetalleVenta(Modelo.Detalle_ventas detalle_Ventas)
        {
            Modelo.Contexto.Obtener_instancia().Detalle_ventas.Add(detalle_Ventas);
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }

        public void deleteDetVta(Modelo.Detalle_ventas detalle_Venta)
        {
            var contexto = Modelo.Contexto.Obtener_instancia();
            var detalleABorrar = contexto.Detalle_ventas.Find(detalle_Venta.id_detalle);
            if (detalleABorrar != null)
            {
                contexto.Detalle_ventas.Remove(detalleABorrar);
                contexto.SaveChanges();
            }
        }

        public void deleteDetVtaID(int idDetalle)
        {
            var contexto = Modelo.Contexto.Obtener_instancia();

            // Buscar la entidad en la base de datos
            var detalleABorrar = contexto.Detalle_ventas.FirstOrDefault(detalle => detalle.id_detalle == idDetalle);

            if (detalleABorrar != null)
            {
                updateStock(detalleABorrar.id_prod, detalleABorrar.cantidad);
                // Remover la entidad del contexto
                contexto.Detalle_ventas.Remove(detalleABorrar);
                // Guardar los cambios en la base de datos
                contexto.SaveChanges();
            }
        }


        public System.Collections.IList getDetalleVta(int idVta)
        {
            var resultado = from detalle in Modelo.Contexto.Obtener_instancia().Detalle_ventas
                            join producto in Modelo.Contexto.Obtener_instancia().Productos on detalle.id_prod equals producto.id_prod
                            where detalle.id_venta == idVta
                            select new
                            {
                                producto.nombre,
                                detalle.cantidad,
                                detalle.precio,
                                Subtotal = detalle.cantidad * detalle.precio,
                                detalle.id_detalle,
                                producto.id_prod
                            };
            return resultado.ToList();
        }

    }
}
