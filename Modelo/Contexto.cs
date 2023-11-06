using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Modelo
{
    public partial class Contexto : DbContext
    {
        private static Contexto instancia;

        public static Contexto Obtener_instancia()
        {
            if (instancia == null)
                instancia = new Contexto();

            return instancia;
        }
        public Contexto()
            : base("name=Contexto")
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Comprobantes> Comprobantes { get; set; }
        public virtual DbSet<Cuentas_Corrientes> Cuentas_Corrientes { get; set; }
        public virtual DbSet<Detalle_ventas> Detalle_ventas { get; set; }
        public virtual DbSet<Facturas> Facturas { get; set; }
        public virtual DbSet<Medio_Pagos> Medio_Pagos { get; set; }
        public virtual DbSet<Movimientos> Movimientos { get; set; }
        public virtual DbSet<Notas_debitos> Notas_debitos { get; set; }
        public virtual DbSet<Pagos> Pagos { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Tipo_Facturas> Tipo_Facturas { get; set; }
        public virtual DbSet<Ventas> Ventas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.ra)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Cuentas_Corrientes>()
                .Property(e => e.saldo)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Detalle_ventas>()
                .Property(e => e.precio)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Facturas>()
                .Property(e => e.total)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Medio_Pagos>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Medio_Pagos>()
                .HasMany(e => e.Facturas)
                .WithOptional(e => e.Medio_Pagos)
                .HasForeignKey(e => e.id_med_pagos);

            modelBuilder.Entity<Movimientos>()
                .Property(e => e.monto)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Notas_debitos>()
                .Property(e => e.monto)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Pagos>()
                .Property(e => e.monto)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Productos>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Productos>()
                .Property(e => e.precio)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Tipo_Facturas>()
                .Property(e => e.descripcion)
                .IsUnicode(false);
        }
    }
}
