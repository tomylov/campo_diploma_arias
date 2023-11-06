namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Facturas
    {
        [Key]
        public int id_factura { get; set; }

        public int? id_med_pagos { get; set; }

        public int? id_tipo_fact { get; set; }

        public int? id_venta { get; set; }

        public int? estado { get; set; }

        public DateTime? fecha { get; set; }

        public decimal? total { get; set; }

        public virtual Medio_Pagos Medio_Pagos { get; set; }

        public virtual Tipo_Facturas Tipo_Facturas { get; set; }

        public virtual Ventas Ventas { get; set; }
    }
}
