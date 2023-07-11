using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Clientes
    {    
        [Key]
        public int dni { get; set; }
        public string nombre { get; set; }
        public string razon_social { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public ICollection<Ventas> Ventas { get; set; }
        public virtual ICollection<Cuenta_corrientes> Cuenta_corrientes { get; set; }

    }
}
