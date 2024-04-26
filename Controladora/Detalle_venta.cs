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

        public void updateStock(int id_prod, int cantidad)
        {
            Modelo.Productos prod = Modelo.Contexto.Obtener_instancia().Productos.Find(id_prod);

            if (prod != null)
            {
                prod.stock += cantidad;
                Modelo.Contexto.Obtener_instancia().SaveChanges();
            }
        }


        public void createdetalleVeta(int id_venta, int id_prod, int cantidad, decimal precio)
        {
            Modelo.Detalle_ventas det = new Modelo.Detalle_ventas();
            det.id_venta = id_venta;
            det.id_prod = id_prod;
            det.cantidad = cantidad;
            det.precio = precio;
            updateStock(id_prod, -cantidad);
            Modelo.Contexto.Obtener_instancia().Detalle_ventas.Add(det);
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }

        public void deleteDetVta(int idDetVta, int cantidad, int idProd)
        {
            Modelo.Detalle_ventas detalleABorrar = Modelo.Contexto.Obtener_instancia().Detalle_ventas.FirstOrDefault(detalle => detalle.id_detalle == idDetVta);

            if (detalleABorrar != null)
            {
                updateStock(idProd, cantidad);
                Modelo.Contexto.Obtener_instancia().Detalle_ventas.Remove(detalleABorrar);
            }

            Modelo.Contexto.Obtener_instancia().SaveChanges();
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
