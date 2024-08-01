using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Vista
{
    public partial class venta_cc : Form
    {
        private static venta_cc instancia;
        private int id_cliente;
        private int id_vta;
        private int estado;
        private decimal totalPrecio;
        int count = 0;
        //Controladora.Pago cPago = Controladora.Pago.Obtener_instancia();
        Controladora.Cuenta_Corriente_Cliente cCuentaCorriente = Controladora.Cuenta_Corriente_Cliente.Obtener_instancia();
        Controladora.Cliente cCliente = Controladora.Cliente.Obtener_instancia();
        Controladora.Venta cVenta = Controladora.Venta.Obtener_instancia();
        Controladora.Comprobante cComprobante = Controladora.Comprobante.Obtener_instancia();
        Controladora.Movimiento cMovimiento = Controladora.Movimiento.Obtener_instancia();
        Modelo.Cuentas_Corrientes mCuentaCorriente;
        Modelo.Clientes mCliente;
        private List<Modelo.Cuentas_Corrientes> cc;

        public static venta_cc Obtener_instancia(Modelo.Ventas venta = null)
        {
            if (instancia == null)
                instancia = new venta_cc(venta);

            if (instancia.IsDisposed)
                instancia = new venta_cc(venta);

            instancia.BringToFront();
            return instancia;
        }
        venta_cc(Modelo.Ventas venta)
        {
            InitializeComponent();
            this.id_cliente = (int)venta.id_cliente;
            this.estado = (int)venta.id_estado;
            this.id_vta = venta.id_venta;
            this.totalPrecio = (decimal)venta.total;
            cargarDatosCliente(id_cliente);
            leerPago(id_vta, estado);
            lblSaldo.Text = totalPrecio.ToString();
            mCuentaCorriente = cCuentaCorriente.Getcc(id_cliente).FirstOrDefault();
        }

        private void buttonPagar_Click(object sender, EventArgs e)
        {
            Modelo.Movimientos movimiento = new Modelo.Movimientos();
            movimiento.id_cc = mCuentaCorriente.id_cc;
            movimiento.fecha = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            movimiento.monto = totalPrecio;
            movimiento.tipo = 1;
            cMovimiento.agregarMovimiento(movimiento);

            Modelo.Ventas venta = new Modelo.Ventas();
            venta = cVenta.getVentaId(id_vta);
            venta.id_estado = 3;
            cVenta.modificarVenta(venta);

            mCuentaCorriente.saldo += totalPrecio;
            if (mCuentaCorriente.plazo == null)
            {
                mCuentaCorriente.plazo = venta.fecha?.AddDays(30);
            }
            cCuentaCorriente.modificarCuentaCorriente(mCuentaCorriente);
            Vista.cuenta_corriente.Obtener_instancia().refresh();
            MessageBox.Show("Se agrego la venta a la cuenta corriente del cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }


        private void leerPago(int pVenta, int pEstado)
        {
            System.Collections.IList detalle = Controladora.Detalle_venta.Obtener_instancia().getDetalleVta(pVenta);
            dataVtas.DataSource = detalle;
            dataVtas.Columns[4].Visible = false;
            dataVtas.Columns[5].Visible = false;
        }

        private void cargarDatosCliente(int id_cliente)
        {
            mCliente = new Modelo.Clientes();
            mCliente = cCliente.GetClienteID(id_cliente).FirstOrDefault();
            txtnombre.Text = mCliente.nombre;
            txtemail.Text = mCliente.email;
            txtRs.Text = mCliente.ra;
            txtTEL.Text = mCliente.telefono;
            txtdni.Text = mCliente.dni.ToString();
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
