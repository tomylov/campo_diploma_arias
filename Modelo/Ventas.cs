using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Modelo
{
    public class Ventas
    {
        [Key]
        public int id_venta { get; set; }
        public DateTime fecha { get; set; }
        public decimal monto { get; set; }
        public int dni { get; set; }
        public virtual Clientes Clientes{ get; set; }

        public int id_estado { get; set; }
        public virtual Estados Estados { get; set; }
        public virtual ICollection<Movimientos> Movimientos { get; set; }
        public virtual ICollection<Detalle_ventas> Detalle_Ventas { get; set; }
    }
}
