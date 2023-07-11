using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Estados
    {
        [Key]
        public int id_estado { get; set; }
        public string descripcion { get; set; }
        public virtual ICollection<Ventas> Ventas { get; set; }


    }
}
