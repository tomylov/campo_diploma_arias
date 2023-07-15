using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Modelo
{
    public partial class Contexto : DbContext
    {
        public Contexto()
            : base("name=Contexto")
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Comprobantes> Comprobantes { get; set; }
        public virtual DbSet<Cuentas_Corrientes> Cuentas_Corrientes { get; set; }
        public virtual DbSet<Detalle_ventas> Detalle_ventas { get; set; }
        public virtual DbSet<Movimientos> Movimientos { get; set; }
        public virtual DbSet<Notas_debitos> Notas_debitos { get; set; }
        public virtual DbSet<Pagos> Pagos { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
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
        }
    }
}
