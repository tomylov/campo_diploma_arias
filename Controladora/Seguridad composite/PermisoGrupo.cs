using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;


namespace Controladora.Seguridad_composite
{
    public class PermisoGrupo : PermisoComponent
    {
        private static PermisoGrupo instancia;

        public static PermisoGrupo Obtener_instancia()
        {
            if (instancia == null)
            {
                instancia = new PermisoGrupo();
            }
            return instancia;
        }

        private readonly List<PermisoComponent> _components = new List<PermisoComponent>();
        private List<Permisos> todosLosPermisos;

        public override void Add(PermisoComponent component)
        {
            _components.Add(component);
        }

        public override void Remove(PermisoComponent component)
        {
            _components.Remove(component);
        }

        public override bool valiPermiso(string permissionName)
        {
            return todosLosPermisos.Any(p => p.nombre_permiso == permissionName);
        }

        public List<Permisos> CargarPermisosUsuario(int idUsuario)
        {
            var usuario = Modelo.Contexto.Obtener_instancia().Usuarios
                .Where(u => u.id_usuario == idUsuario)
                .FirstOrDefault();

            var permisosUsuario = usuario.Permisos.Where(p => p.estado == true).ToList() ?? new List<Permisos>();

            var gruposUsuario = usuario.Grupos.Where(g => g.estado == true).ToList() ?? new List<Grupos>();

            var permisosGrupos = new List<Permisos>();

            foreach (var grupo in gruposUsuario)
            {
                if (grupo.Permisos != null)
                {
                    permisosGrupos.AddRange(grupo.Permisos.Where(pg =>pg.estado == true));
                }
            }

            todosLosPermisos = permisosUsuario
                .Union(permisosGrupos)
                .Distinct()
                .ToList();

            return todosLosPermisos;
        }
    }
}
