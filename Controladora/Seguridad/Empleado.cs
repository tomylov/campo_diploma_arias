using Controladora.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class Usuario
    {
        private static Usuario usuario;

        public static Usuario Obtener_instancia()
        {
            if (usuario == null)
            {
                usuario = new Usuario();
            }
            return usuario;
        }

        public List<Modelo.Usuarios> getUsuarios()
        {
            var usuarios = from usuario in Modelo.Contexto.Obtener_instancia().Usuarios
                           select usuario;
            return usuarios.ToList();
        }

        public List<Modelo.Usuarios> getUsuarioId(int id)
        {
            var usuarios = from usuario in Modelo.Contexto.Obtener_instancia().Usuarios
                           where usuario.id_usuario == id
                           select usuario;
            return usuarios.ToList();
        }

        public Modelo.Usuarios getUsuarioNombreUsuario(string usuario)
        {
            var user = from usuarios in Modelo.Contexto.Obtener_instancia().Usuarios
                          where usuarios.usuario == usuario
                          select usuarios;
            return user.FirstOrDefault();
        }

        public void agregarUsuario(Modelo.Usuarios usuario)
        {
            Modelo.Contexto.Obtener_instancia().Usuarios.Add(usuario);
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }

        public void modificarUsuario(Modelo.Usuarios usuario)
        {
            Modelo.Contexto.Obtener_instancia().Entry(usuario).State = System.Data.Entity.EntityState.Modified;
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }

        public void eliminarUsuario(Modelo.Usuarios usuario)
        {
            Modelo.Contexto.Obtener_instancia().Entry(usuario).State = System.Data.Entity.EntityState.Modified;
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }
    }
}