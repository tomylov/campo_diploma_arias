namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Notas_debitos
    {
        [Key]
        public int numero { get; set; }

        public decimal? monto { get; set; }

        public DateTime? fecha { get; set; }

        public int? id_cc { get; set; }

        public int? id_comp { get; set; }

        public virtual Comprobantes Comprobantes { get; set; }

        public virtual Cuentas_Corrientes Cuentas_Corrientes { get; set; }
    }
}
