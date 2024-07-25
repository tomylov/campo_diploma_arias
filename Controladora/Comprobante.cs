using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class Comprobante
    {
        private static Comprobante instancia;

        public static Comprobante Obtener_instancia()
        {
            if (instancia == null)
            {
                instancia = new Comprobante();
            }
            return instancia;
        }

        public void AgregarComprobante(Modelo.Comprobantes comprobante)
        {
            Modelo.Contexto.Obtener_instancia().Comprobantes.Add(comprobante);
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }

        public void deleteComprobante(Modelo.Comprobantes comprobante)
        {
            Modelo.Contexto.Obtener_instancia().Comprobantes.Remove(comprobante);
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }
    }
}
