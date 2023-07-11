using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Notas_debitos
    {
        [Key]
        public int nro_debito { get; set; }
        public decimal monto { get; set; }
        public DateTime fecha { get; set; }
        public int id_movimiento { get; set; }
        public int id_cc { get; set; }
        public virtual Cuenta_corrientes Cuenta_Corrientes { get; set; }
        public virtual Movimientos Movimientos { get; set; }
    }
}
