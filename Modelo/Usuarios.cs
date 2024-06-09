namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuarios()
        {
            Permisos = new HashSet<Permisos>();
            Grupos = new HashSet<Grupos>();
        }

        [Key]
        public int id_usuario { get; set; }

        [StringLength(60)]
        public string nombre { get; set; }

        [StringLength(15)]
        public string dni { get; set; }

        [StringLength(60)]
        public string apellido { get; set; }

        [StringLength(60)]
        public string email { get; set; }

        [StringLength(60)]
        public string clave { get; set; }

        public bool? estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Permisos> Permisos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Grupos> Grupos { get; set; }
    }
}
