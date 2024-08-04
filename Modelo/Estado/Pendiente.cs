using Modelo.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Estado
{
    public class Pendiente : Estado
    {
        public override void EnviarEmailEstadoVenta(Ventas venta)
        {
            throw new NotImplementedException();
        }

        public override void anular(Ventas venta)
        {
            throw new NotImplementedException();
        }

        public override void siguienteEstado(Ventas venta, string opcion = null)
        {
            venta.Estado = new Aceptado();
            var subject = $"Estado venta {venta.id_venta} - Aceptado";
            var body = $"Estimado, este correo notifica que la venta número {venta.id_venta}, del día: {venta.fecha.Value.ToString("dd/MM/yyyy")} tiene un estado de Aceptado.\n\nEnviamos un cordial saludo de parte de Hard-Soft.";
            Correo correo = new Correo();
            correo.SendEmail(subject, body, venta.Clientes.email);
        }
    }
}
