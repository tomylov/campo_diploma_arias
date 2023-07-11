using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Detalle_ventas
    {
        [Key]
        public int id_det { get; set; }
        public int id_venta { get; set; }
        public int id_producto { get; set; }
        public int cantidad { get; set; }
        public virtual Ventas Ventas { get; set; }
        public virtual Productos Productos { get; set; }

    }
}
