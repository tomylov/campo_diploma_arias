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
        private PermisoGrupo() { }

        private readonly List<PermisoComponent> _components = new List<PermisoComponent>();
        private List<Permisos> todosLosPermisos;
        Controladora.Seguridad.Grupo cGrupo = Controladora.Seguridad.Grupo.Obtener_instancia();

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
        public List<Permisos> GetPermisosUsuario(int idUsuario)
        {
            var usuario = Modelo.Contexto.Obtener_instancia().Usuarios
                .Where(u => u.id_usuario == idUsuario)
                .FirstOrDefault();

            var permisosUsuario = usuario.Permisos.Where(p => p.estado == true).ToList() ?? new List<Permisos>();

            return permisosUsuario;
        }

        public List<Permisos> GetPermisosGrupo(int idUsuario)
        {
            var gruposUsuario = cGrupo.getGruposUsuarios(idUsuario) ?? new List<Grupos>();

            var permisosGrupos = new List<Permisos>();

            foreach (var grupo in gruposUsuario)
            {
                if (grupo.Permisos != null)
                {
                    permisosGrupos.AddRange(grupo.Permisos.Where(pg => pg.estado == true));
                }
            }

            return permisosGrupos;
        }

        public List<Permisos> GetPermisosLogin(int idUsuario)
        {
            var usuario = Modelo.Contexto.Obtener_instancia().Usuarios
                .Where(u => u.id_usuario == idUsuario)
                .FirstOrDefault();

            var permisosUsuario = GetPermisosUsuario(idUsuario);
            var permisosGrupos = GetPermisosGrupo(idUsuario);

            todosLosPermisos = permisosUsuario
                .Union(permisosGrupos)
                .Distinct()
                .ToList();

            return todosLosPermisos;
        }
        public List<Formularios> GetFormulariosUsuario(int idUsuario)
        {
            List<Permisos> todosLosPermisosUsuario = GetPermisosLogin(idUsuario);

            var formularios = todosLosPermisosUsuario
                            .Where(p => p.Formularios != null)
                            .Select(p => p.Formularios)
                            .Distinct()
                            .ToList();

            return formularios;
        }

        public List<Modulos> GetModulosUsuario(int idUsuario)
        {
            List<Permisos> todosLosPermisosUsuario = todosLosPermisos;

            var modulos = todosLosPermisosUsuario
                .Where(p => p.Formularios != null)
                .Select(p => p.Formularios.Modulos)
                .Distinct()
                .ToList();

            return modulos;
        }

    }
}
