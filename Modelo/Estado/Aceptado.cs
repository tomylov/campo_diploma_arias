using Modelo.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Estado
{
    public class Aceptado: Estado
    {
        public Aceptado()
        {
            id_estado = 2;
        }

        public override void siguienteEstado(Ventas venta, string opcion)
        {
            var subject = "";
            var body = "";
            Correo correo = new Correo();
            switch (opcion?.ToLower())
            {
                case "pagar":
                    venta.Estado = new Pagado();
                    venta.id_estado = 4;
                    subject = $"Estado venta {venta.id_venta} - Abonada";
                    body = $"Estimado, este correo notifica que la venta número {venta.id_venta}, del día: {venta.fecha.Value.ToString("dd/MM/yyyy")} con un monto de ${venta.total} fue abonada con éxito." +
                        $"\n\nEnviamos un cordial saludo de parte de Hard-Soft.";
                    correo.SendEmail(subject, body, venta.Clientes.email);
                    break;
                case "cuenta corriente":
                    venta.Estado = new Cuenta_corriente();
                    venta.id_estado = 5;
                    subject = $"Estado venta {venta.id_venta} - Cuenta corriente";
                    body = $"Estimado, este correo notifica que la venta número {venta.id_venta}, del día: {venta.fecha.Value.ToString("dd/MM/yyyy")} paso a cuenta corriente con fecha maxima a " +
                        $"pagar {venta.fecha.Value.AddDays(30).ToString("dd/MM/yyyy")} con un monto de ${venta.total}" +
                        $".\n\nEnviamos un cordial saludo de parte de Hard-Soft.";
                    correo.SendEmail(subject, body, venta.Clientes.email);
                    break;
                default:
                    throw new ArgumentException("Debe especificar 'pagar' o 'cuenta corriente' para el siguiente estado.");
            }
        }

        public override void anular(Ventas venta)
        {
            venta.Estado = new Pendiente();
            venta.id_estado = 6;
        }

        public override void EnviarEmailEstadoVenta(Ventas venta)
        {
            var subject = $"Estado venta {venta.id_venta} - Aceptado";
            var body = $"Estimado, este correo notifica que la venta número {venta.id_venta}, del día: {venta.fecha.Value.ToString("dd/MM/yyyy")} tiene un estado de Aceptado.\n\nEnviamos un cordial saludo de parte de Hard-Soft.";
            Correo correo = new Correo();
            correo.SendEmail(subject, body, venta.Clientes.email);
        }
    }    
}
