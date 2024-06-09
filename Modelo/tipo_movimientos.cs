namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tipo_movimientos
    {
        [Key]
        public int id_tipo_mov { get; set; }

        [StringLength(10)]
        public string descripcion { get; set; }
    }
}
