namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Detalle_ventas
    {
        [Key]
        public int id_detalle { get; set; }

        public int? cantidad { get; set; }

        public decimal? precio { get; set; }

        public int? id_prod { get; set; }

        public int? id_venta { get; set; }

        public virtual Productos Productos { get; set; }

        public virtual Ventas Ventas { get; set; }
    }
}
