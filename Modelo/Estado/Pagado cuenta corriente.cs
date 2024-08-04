using Modelo.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Estado
{
    public class Pagado_cuenta_corriente : Estado
    {
        public override void EnviarEmailEstadoVenta(Ventas venta)
        {
            var subject = $"Estado venta {venta.id_venta} - Cuenta saldada";
            var body = $"Estimado, este correo notifica que la venta número {venta.id_venta}, del día: {venta.fecha.Value.ToString("dd/MM/yyyy")} con un monto de ${venta.total} " +
                $"fue abonada con exito desde la cuenta corriente, dejando un saldo actual de: ${venta.Clientes.Cuentas_Corrientes.FirstOrDefault().saldo}." +
                $"\n\nEnviamos un cordial saludo de parte de Hard-Soft.";
            Correo correo = new Correo();
            correo.SendEmail(subject, body, venta.Clientes.email);
        }

        public override void anular(Ventas venta)
        {
            venta.Estado = new Cuenta_corriente();
            venta.id_estado = 3;
        }

        public override void siguienteEstado(Ventas venta, string opcion = null)
        {
            throw new Exception("No se puede actualizar estado de venta pagada.");
        }
    }
}
