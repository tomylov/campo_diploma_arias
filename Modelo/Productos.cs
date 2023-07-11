using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Productos
    {
        [Key]
        public int id_producto { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public virtual ICollection<Detalle_ventas> Detalle_Ventas{ get; set; }
    }
}
