using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    internal class Usuario
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
