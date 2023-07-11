using System;
using System.Data.Entity;
using System.Linq;
using Modelo;

namespace Contexto
{
    public class Empresa : DbContext
    {
        private static Empresa instance;

        public static Empresa obtener_instancia() 
        {
            if (instance == null)
                instance = new Empresa();
            return instance;
        }
        // El contexto se ha configurado para usar una cadena de conexión 'Empresa' del archivo 
        // de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
        // esta cadena de conexión tiene como destino la base de datos 'Contexto.Empresa' de la instancia LocalDb. 
        // 
        // Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
        // modifique la cadena de conexión 'Empresa'  en el archivo de configuración de la aplicación.
        public Empresa()
            : base("name=Empresa")
        {
        }
        public virtual DbSet<Modelo.Clientes> Clientes { get; set; }
        public virtual DbSet<Modelo.Cuenta_corrientes> Cuenta_Corrientes{ get; set; }
        public virtual DbSet<Modelo.Detalle_ventas> Detalle_Ventas{ get; set; }
        public virtual DbSet<Modelo.Estados> Estados { get; set; }
        public virtual DbSet<Modelo.Movimientos> Movimientos { get; set; }
        public virtual DbSet<Modelo.Notas_debitos> Nota_Debitos{ get; set; }
        public virtual DbSet<Modelo.Pagos> Pagos{ get; set; }
        public virtual DbSet<Modelo.Productos> Productos{ get; set; }
        public virtual DbSet<Modelo.Tipo_movimientos> Tipo_Movimientos{ get; set; }
        public virtual DbSet<Modelo.Ventas> Ventas{ get; set; }

        // Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
        // sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}