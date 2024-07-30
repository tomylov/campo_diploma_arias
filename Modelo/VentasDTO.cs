using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class VentaEstadoDTO
    {
        public int id_venta { get; set; }
        public int id_cliente { get; set; }
        public int id_estado { get; set; }
        public int dni { get; set; }
        public DateTime fecha { get; set; }
        public decimal total { get; set; }
    }
}
