namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ventas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ventas()
        {
            Detalle_ventas = new HashSet<Detalle_ventas>();
            Pagos = new HashSet<Pagos>();
        }

        [Key]
        public int id_venta { get; set; }

        public DateTime? fecha { get; set; }

        public int? id_estado { get; set; }

        public int? id_cliente { get; set; }

        public int? id_comp { get; set; }

        public virtual Clientes Clientes { get; set; }

        public virtual Comprobantes Comprobantes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle_ventas> Detalle_ventas { get; set; }

        public virtual Estado_venta Estado_venta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pagos> Pagos { get; set; }
    }
}
