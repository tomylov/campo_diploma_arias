using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Movimientos
    {
        [Key]
        public int id_movimiento { get; set; }
        public string monto { get; set; }        
        public int id_tipo { get; set; }

        public int id_venta { get; set; }

        public int id_cc { get; set; }

        public DateTime fecha { get; set; }
        public virtual Tipo_movimientos Tipo_movimientos { get; set; }
        public virtual Ventas Ventas { get; set; }
        public virtual Cuenta_corrientes Cuenta_Corrientes{ get; set; }
    }
}
