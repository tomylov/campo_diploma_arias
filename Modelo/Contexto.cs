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
        public virtual DbSet<Estado_venta> Estado_venta { get; set; }
        public virtual DbSet<Formularios> Formularios { get; set; }
        public virtual DbSet<Grupos> Grupos { get; set; }
        public virtual DbSet<Medio_Pagos> Medio_Pagos { get; set; }
        public virtual DbSet<Modulos> Modulos { get; set; }
        public virtual DbSet<Movimientos> Movimientos { get; set; }
        public virtual DbSet<Notas_creditos> Notas_creditos { get; set; }
        public virtual DbSet<Notas_debitos> Notas_debitos { get; set; }
        public virtual DbSet<Pagos> Pagos { get; set; }
        public virtual DbSet<Permisos> Permisos { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Tipo_Comprobantes> Tipo_Comprobantes { get; set; }
        public virtual DbSet<tipo_movimientos> tipo_movimientos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Ventas> Ventas { get; set; }
        public DbSet<SesionUsuario> SesionesUsuario { get; set; }

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

            modelBuilder.Entity<Estado_venta>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Formularios>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Grupos>()
                .Property(e => e.grupo_nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Grupos>()
                .HasMany(e => e.Permisos)
                .WithMany(e => e.Grupos)
                .Map(m => m.ToTable("PermisoGrupos").MapLeftKey("id_grupo").MapRightKey("id_permiso"));

            modelBuilder.Entity<Grupos>()
                .HasMany(e => e.Usuarios)
                .WithMany(e => e.Grupos)
                .Map(m => m.ToTable("UsuarioGrupos").MapLeftKey("id_grupo").MapRightKey("id_usuario"));

            modelBuilder.Entity<Medio_Pagos>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Modulos>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Movimientos>()
                .Property(e => e.monto)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Notas_creditos>()
                .Property(e => e.monto)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Notas_debitos>()
                .Property(e => e.monto)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Pagos>()
                .Property(e => e.monto)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Permisos>()
                .Property(e => e.nombre_permiso)
                .IsUnicode(false);

            modelBuilder.Entity<Permisos>()
                .HasMany(e => e.Usuarios)
                .WithMany(e => e.Permisos)
                .Map(m => m.ToTable("PermisoUsuarios").MapLeftKey("id_permiso").MapRightKey("id_usuario"));

            modelBuilder.Entity<Productos>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Productos>()
                .Property(e => e.precio)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Tipo_Comprobantes>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<tipo_movimientos>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.dni)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.clave)
                .IsUnicode(false);

            modelBuilder.Entity<SesionUsuario>()
            .ToTable("SesionesUsuario");
        }
    }
}
