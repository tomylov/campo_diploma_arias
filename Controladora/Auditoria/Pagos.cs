using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.Auditoria
{
    public class Pagos
    {
        private static Pagos pagos;

        public static Pagos Obtener_instancia()
        {
            if (pagos == null)
            {
                pagos = new Pagos();
            }
            return pagos;
        }

        private Pagos() { }

        public List<Modelo.ReportePagoDTO> GetPagos(DateTime fechaDesde, DateTime fechaHasta)
        {
            var contexto = Modelo.Contexto.Obtener_instancia();
            var resultado = from p in contexto.Pagos
                            join mp in contexto.Medio_Pagos on p.id_med_pago equals mp.id_med_pago
                            where p.fecha >= fechaDesde && p.fecha <= fechaHasta
                            group p by new { mp.id_med_pago, mp.descripcion } into g
                            select new Modelo.ReportePagoDTO
                            {
                                Medio_de_pago = g.Key.descripcion,
                                Total = g.Sum(p => p.monto)
                            };
            return resultado.ToList();
        }
    }
}
