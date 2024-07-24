using System;
using System.Collections.Generic;
using System.Linq;
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
