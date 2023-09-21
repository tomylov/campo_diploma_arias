namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pagos
    {
        [Key]
        public int numero { get; set; }

        public decimal? monto { get; set; }

        public DateTime? fecha { get; set; }

        public int? id_venta { get; set; }

        public virtual Ventas Ventas { get; set; }
    }
}
