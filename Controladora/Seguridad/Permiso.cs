using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.Seguridad
{
    public class Permiso
    {
        private static Permiso permiso;

        public static Permiso Obtener_instancia()
        {
            if (permiso == null)
            {
                permiso = new Permiso();
            }
            return permiso;
        }
        private Permiso() { }

        public List<Modelo.Permisos> getPermisos()
        {
            var permisos = from permiso in Modelo.Contexto.Obtener_instancia().Permisos
                           select permiso;
            return permisos.ToList();
        }

        public List<Modelo.Permisos> getPermiso(int id)
        {
            var permisos = from permiso in Modelo.Contexto.Obtener_instancia().Permisos
                           where permiso.id_permiso == id
                           select permiso;
            return permisos.ToList();
        }

        public List<Modelo.Permisos> getPermisosGrupo(int id)
        {
            var grupo = Modelo.Contexto.Obtener_instancia().Grupos.Include(g => g.Permisos).FirstOrDefault(g => g.id_grupo == id);
            if (grupo == null)
            {
                // Si no existe el grupo, devolver una lista vacía
                return new List<Modelo.Permisos>();
            }

            // Devolver los permisos asociados al grupo
            return grupo.Permisos.ToList();
        }

        public List<Modelo.Permisos> getPermisosUsuario(int id)
        {
            var grupo = Modelo.Contexto.Obtener_instancia().Usuarios.Include(g => g.Permisos).FirstOrDefault(g => g.id_usuario == id);
            if (grupo == null)
            {
                // Si no existe el grupo, devolver una lista vacía
                return new List<Modelo.Permisos>();
            }

            // Devolver los permisos asociados al grupo
            return grupo.Permisos.ToList();
        }

        public void agregarPermiso(Modelo.Permisos permiso)
        {

            Modelo.Contexto.Obtener_instancia().Permisos.Add(permiso);
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }

        public void modificarPermiso(Modelo.Permisos permiso)
        {
            Modelo.Contexto.Obtener_instancia().Entry(permiso).State = EntityState.Modified;
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }

        public void eliminarPermiso(Modelo.Permisos permiso)
        {
            Modelo.Contexto.Obtener_instancia().Entry(permiso).State = EntityState.Modified;
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }
    }
}
