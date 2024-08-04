using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Estado
{
    public abstract class Estado
    {
        protected int id_estado;
        public abstract void siguienteEstado(Ventas venta, string opcion = null);
        public abstract void anular(Ventas venta);
        public abstract void EnviarEmailEstadoVenta(Ventas venta);
    }
}
