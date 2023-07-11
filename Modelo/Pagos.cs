using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Pagos
    {
        [Key]
        public int nro_pago { get; set; }
        public decimal monto { get; set; }
        public DateTime fecha { get; set; }
        public int id_venta { get; set; }


        public virtual Ventas Ventas { get; set; }
    }
}
