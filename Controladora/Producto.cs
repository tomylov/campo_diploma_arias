using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class Producto
    {
        private static Producto prod;

        public static Producto Obtener_instancia()
        {
            if (prod == null)
            {
                prod = new Producto();
            }
            return prod;
        }
        private Producto() { }

        public Modelo.Productos getProductoId(int id)
        {
            var productos = from prod in Modelo.Contexto.Obtener_instancia().Productos
                            where prod.id_prod == id
                            select prod;
            return productos.FirstOrDefault();
        }

        public List<Modelo.Productos> getProductos()
        {
            var productos = from prod in Modelo.Contexto.Obtener_instancia().Productos
                            select prod;
            return productos.ToList();
        }
    }
}
