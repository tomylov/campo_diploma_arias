using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Cuenta_corrientes
    {
        [Key]
        public int id_cc { get; set; }
        public decimal saldo { get; set; }
        public int dni { get; set; }
        public DateTime plazo { get; set; }
        public virtual Clientes Clientes { get; set; }

        public virtual ICollection<Movimientos> Movimientos{ get; set; }
    }
}
