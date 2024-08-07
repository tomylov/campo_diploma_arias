﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        private Grupo() { }

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

        public List<Modelo.Grupos> getGruposUsuarios(int id)
        {
            // Incluir los usuarios asociados al grupo
            var usuario = Modelo.Contexto.Obtener_instancia().Usuarios.Include(u => u.Grupos).FirstOrDefault(u => u.id_usuario == id);

            if (usuario == null)
            {
                // Si no existe el usuario, devolver una lista vacía
                return new List<Modelo.Grupos>();
            }

            // Filtrar los grupos por el estado
            var gruposActivos = usuario.Grupos.Where(g => g.estado == true).ToList();

            return gruposActivos;
        }


        public void agregarGrupo(Modelo.Grupos grupo)
        {
            Modelo.Contexto.Obtener_instancia().Grupos.Add(grupo);
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }

        public void modificarGrupo(Modelo.Grupos grupo)
        {
            Modelo.Contexto.Obtener_instancia().Entry(grupo).State = System.Data.Entity.EntityState.Modified;
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }

        public void eliminarGrupo(Modelo.Grupos grupo)
        {
            Modelo.Contexto.Obtener_instancia().Entry(grupo).State = System.Data.Entity.EntityState.Modified;
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }
    }
}