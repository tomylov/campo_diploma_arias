using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Tipo_movimientos
    {
        [Key]
        public int id_tipo { get; set; }
        public string descripcion { get; set; }
        public virtual ICollection<Movimientos> Movimientos{ get; set; }

    }
}
