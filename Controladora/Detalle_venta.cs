using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            prod.stock -= cantidad;
            Modelo.Contexto.Obtener_instancia().Entry(prod).State = System.Data.Entity.EntityState.Modified;
            Modelo.Contexto.Obtener_instancia().SaveChanges();

        }


        public void createdetalleVeta (int id_venta, int id_prod, int cantidad, decimal precio)
        {
            Modelo.Detalle_ventas det = new Modelo.Detalle_ventas();
            det.id_venta = id_venta;
            det.id_prod= id_prod;
            det.cantidad= cantidad;
            det.precio= precio;
            updateStock(id_prod,cantidad);
            Modelo.Contexto.Obtener_instancia().Detalle_ventas.Add(det);
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }

    }
}
