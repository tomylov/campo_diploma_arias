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

        public System.Collections.IList getProductoId(int id)
        {
            var productos = from prod in Modelo.Contexto.Obtener_instancia().Productos
                            where prod.id_prod == id
                            select prod;
            return productos.ToList();
        }

        public System.Collections.IList getProductoNombre(string nombre)
        {
            var productos = from prod in Modelo.Contexto.Obtener_instancia().Productos
                            where prod.nombre.Contains(nombre)
                            select prod;
            return productos.ToList();
        }
    }
}
