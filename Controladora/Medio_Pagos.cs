using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class Medio_Pagos
    {
        private static Medio_Pagos instancia;
        public static Medio_Pagos Obtener_instancia()
        {
            if (instancia == null)
                instancia = new Medio_Pagos();
            return instancia;
        }
        private Medio_Pagos() { }

        public List<Modelo.Medio_Pagos> ListarMedioPagos()
        {
            var medio = from mp in Modelo.Contexto.Obtener_instancia().Medio_Pagos
                              select mp;
            return medio.ToList();
        }

    }
}
