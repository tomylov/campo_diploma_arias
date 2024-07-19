using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.Seguridad
{
    public class Modulo
    {
        private static Modulo modulo;

        public static Modulo Obtener_instancia()
        {
            if (modulo == null)
            {
                modulo = new Modulo();
            }
            return modulo;
        }

        public List<Modelo.Modulos> getModulos()
        {
            var modulos = from modulo in Modelo.Contexto.Obtener_instancia().Modulos
                          select modulo;
            return modulos.ToList();
        }

        public List<Modelo.Modulos> getModuloId(int id)
        {
            var modulos = from modulo in Modelo.Contexto.Obtener_instancia().Modulos
                          where modulo.id_modulo == id
                          select modulo;
            return modulos.ToList();
        }
    }
}
