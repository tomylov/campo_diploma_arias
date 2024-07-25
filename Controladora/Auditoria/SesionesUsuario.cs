using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.Auditoria
{
    public class SesionesUsuario
    {
        private static SesionesUsuario sesionesUsuario;

        public static SesionesUsuario Obtener_instancia()
        {
            if (sesionesUsuario == null)
            {
                sesionesUsuario = new SesionesUsuario();
            }
            return sesionesUsuario;
        }

        public List<Modelo.SesionUsuario> GetSesionesUsuario(string usuario,DateTime dateIni,DateTime dateFin)
        {
            if (usuario == "")
            {
                var sesionesUsuarios = from sesionUsuario in Modelo.Contexto.Obtener_instancia().SesionesUsuario
                                      where sesionUsuario.FechaInicio >= dateIni && sesionUsuario.FechaInicio <= dateFin
                                      select sesionUsuario;
                return sesionesUsuarios.ToList();
            }
            else
            {
                var sesionesUsuario = from sesionUsuario in Modelo.Contexto.Obtener_instancia().SesionesUsuario
                                      where sesionUsuario.usuario == usuario && sesionUsuario.FechaInicio >= dateIni && sesionUsuario.FechaInicio <= dateFin
                                      select sesionUsuario;
                return sesionesUsuario.ToList();
            }
        }

        public List<Modelo.UsuarioReporte> GetReporteUsuarios(int id_grupo,DateTime dateIni, DateTime dateFin)
        {
            var contexto = Modelo.Contexto.Obtener_instancia();

            // Obtener los usuarios que pertenecen al grupo específico
            var usuariosEnGrupo = contexto.Grupos
                .Where(g => g.id_grupo == id_grupo)
                .SelectMany(g => g.Usuarios)
                .Select(u => u.id_usuario)
                .ToList();

            // Filtrar las sesiones de usuarios que pertenecen al grupo y están dentro del rango de fechas
            var sesiones = contexto.SesionesUsuario
                .Where(s => usuariosEnGrupo.Contains(s.id_usuario) && s.FechaFin != null && s.FechaInicio >= dateIni && s.FechaInicio <= dateFin)
                .ToList();

            var totalHorasTrabajadasPorUsuario = sesiones
                .GroupBy(s => s.usuario)
                .Select(grupo => new UsuarioReporte
                {
                    Usuario = grupo.Key,
                    TotalHorasTrabajadas = Math.Round(grupo.Sum(s =>
                    {
                        var partes = s.Duracion.Split(':');
                        int horas = int.Parse(partes[0]);
                        int minutos = int.Parse(partes[1]);
                        int segundos = int.Parse(partes[2]);
                        return horas + minutos / 60.0 + segundos / 3600.0;
                    }), 2) // Redondea a dos decimales
                })
                .ToList();

            return totalHorasTrabajadasPorUsuario;
        }


        public void RegistrarInicioSesion(Modelo.SesionUsuario usuario)
        {

                var sesionAbierta = Modelo.Contexto.Obtener_instancia().SesionesUsuario
                                           .Where(su => su.id_usuario == usuario.id_usuario && su.FechaFin == null)
                                           .OrderByDescending(su => su.FechaInicio)
                                           .FirstOrDefault();

                if (sesionAbierta != null)
                {
                    CerrarSesionAbierta(sesionAbierta);
            }
                Modelo.Contexto.Obtener_instancia().SesionesUsuario.Add(usuario);
                Modelo.Contexto.Obtener_instancia().SaveChanges();
        }

        public void CerrarSesionAbierta(Modelo.SesionUsuario SesionUsuario)
        {
            SesionUsuario.Duracion = "Sesion sin finalizar";
            Modelo.Contexto.Obtener_instancia().Entry(SesionUsuario).State = System.Data.Entity.EntityState.Modified;
        }

        public void RegistrarFinSesion(Modelo.SesionUsuario usuario)
        {
            var sesionAbierta = Modelo.Contexto.Obtener_instancia().SesionesUsuario
                                           .Where(su => su.id_usuario == usuario.id_usuario && su.FechaFin == null)
                                           .OrderByDescending(su => su.FechaInicio)
                                           .FirstOrDefault();

            if (sesionAbierta != null)
            {
                sesionAbierta.FechaFin = usuario.FechaFin;
                var duracion = sesionAbierta.FechaFin.Value - sesionAbierta.FechaInicio;
                sesionAbierta.Duracion = string.Format("{0:D2}:{1:D2}:{2:D2}",
                                                       duracion.Hours,
                                                       duracion.Minutes,
                                                       duracion.Seconds);
                Modelo.Contexto.Obtener_instancia().Entry(sesionAbierta).State = System.Data.Entity.EntityState.Modified;
                Modelo.Contexto.Obtener_instancia().SaveChanges();
            }
        }
    }
}
