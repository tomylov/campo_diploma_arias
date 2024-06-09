namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Clientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clientes()
        {
            Cuentas_Corrientes = new HashSet<Cuentas_Corrientes>();
            Ventas = new HashSet<Ventas>();
        }

        [Key]
        public int id_cliente { get; set; }

        public int? dni { get; set; }

        [StringLength(60)]
        public string nombre { get; set; }

        [StringLength(60)]
        public string email { get; set; }

        [StringLength(10)]
        public string ra { get; set; }

        [StringLength(20)]
        public string telefono { get; set; }

        public bool? estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cuentas_Corrientes> Cuentas_Corrientes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
