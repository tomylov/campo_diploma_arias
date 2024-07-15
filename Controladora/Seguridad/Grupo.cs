using System.Collections.Generic;
using System.Linq;

namespace Controladora.Seguridad
{
    public class Grupo
    {
        private static Grupo grupo;

        public static Grupo Obtener_instancia()
        {
            if (grupo == null)
            {
                grupo = new Grupo();
            }
            return grupo;
        }

        public List<Modelo.Grupos> getGrupos()
        {
            var grupos = from grupo in Modelo.Contexto.Obtener_instancia().Grupos
                         select grupo;
            return grupos.ToList();
        }

        public List<Modelo.Grupos> getGrupoId(int id)
        {
            var grupos = from grupo in Modelo.Contexto.Obtener_instancia().Grupos
                         where grupo.id_grupo == id
                         select grupo;
            return grupos.ToList();
        }

        public void agregarGrupo(Modelo.Grupos grupo, List<Modelo.Permisos> nuevosPermisosGrupo)
        {
            Modelo.Contexto.Obtener_instancia().Grupos.Add(grupo);
            if (nuevosPermisosGrupo != null && nuevosPermisosGrupo.Count > 0)
            {
                foreach (Modelo.Permisos permiso in nuevosPermisosGrupo)
                {
                    grupo.Permisos.Add(permiso);
                }
            }
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }

        public void modificarGrupo(Modelo.Grupos grupo, List<Modelo.Permisos> nuevosPermisosGrupo, List<Modelo.Permisos> eliminarPermisoGrupo)
        {
            Modelo.Contexto.Obtener_instancia().Entry(grupo).State = System.Data.Entity.EntityState.Modified;

            if (nuevosPermisosGrupo != null && nuevosPermisosGrupo.Count > 0)
            {
                foreach (Modelo.Permisos permiso in nuevosPermisosGrupo)
                {
                    grupo.Permisos.Add(permiso);
                }
            }

            if (eliminarPermisoGrupo != null && eliminarPermisoGrupo.Count > 0)
            {
                foreach (Modelo.Permisos permiso in eliminarPermisoGrupo)
                {
                    grupo.Permisos.Remove(permiso);
                }
            }

            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }

        public void eliminarGrupo(Modelo.Grupos grupo)
        {
            grupo.estado = false;
            Modelo.Contexto.Obtener_instancia().Entry(grupo).State = System.Data.Entity.EntityState.Modified;
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }
    }
}