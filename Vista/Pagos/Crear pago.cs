using Controladora;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista.Pagos
{
    public partial class Crear_pago : Form
    {
        private static Crear_pago instancia;
        private int id_cliente;
        private int id_vta;
        private int estado;
        private decimal totalPrecio;
        int count=0;
        //Controladora.Pago cPago = Controladora.Pago.Obtener_instancia();
        Controladora.Cuenta_Corriente_Cliente cCuentaCorriente = Controladora.Cuenta_Corriente_Cliente.Obtener_instancia();
        Controladora.Pago cPago = Controladora.Pago.Obtener_instancia();
        Controladora.Cliente cCliente = Controladora.Cliente.Obtener_instancia();
        Controladora.Venta cVenta = Controladora.Venta.Obtener_instancia();
        Controladora.Comprobante cComprobante = Controladora.Comprobante.Obtener_instancia();
        Modelo.Cuentas_Corrientes mCuentaCorriente;
        Modelo.Clientes mCliente;
        private List<Modelo.Cuentas_Corrientes> cc;

        public static Crear_pago Obtener_instancia(Modelo.Ventas venta = null)
        {
            if (instancia == null)
                instancia = new Crear_pago(venta);

            if (instancia.IsDisposed)
                instancia = new Crear_pago(venta);

            instancia.BringToFront();
            return instancia;
        }
        public Crear_pago(Modelo.Ventas venta)
        {
            InitializeComponent();
            if (venta == null)
            {
                buttonVenta.Visible = true;
            }
            else
            {
                this.id_cliente = (int)venta.id_cliente;
                this.estado = (int)venta.id_estado;
                this.id_vta = venta.id_venta;
                this.totalPrecio = (decimal)venta.total;
                buttonVenta.Visible = false;
                cargarDatosCliente(id_cliente);
                leerPago(id_vta);
            }
            comboBoxmedio.DataSource = Controladora.Medio_Pagos.Obtener_instancia().ListarMedioPagos();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonCliente_Click(object sender, EventArgs e)
        {
            Consultar_ventas conVta = Consultar_ventas.Obtener_instancia();
            if (conVta.ShowDialog() == DialogResult.OK)
            {
                id_vta = conVta.venta.id_venta;
                id_cliente = (int)conVta.venta.id_cliente;
                estado = (int)conVta.venta.id_estado;
                totalPrecio = (decimal)conVta.venta.total;
                cargarDatosCliente(id_cliente);
                leerPago(id_vta);
                txtPago.Text = totalPrecio.ToString();
                buttonVenta.Visible = false;
            }
        }

        private void buttonPagar_Click(object sender, EventArgs e)
        {
            decimal pago = Convert.ToDecimal(txtPago.Text);
            decimal saldo = Convert.ToDecimal(lblSaldo.Text);
            if (pago >= saldo)
            {
                Modelo.Pagos oPago = new Modelo.Pagos();
                oPago.monto = Convert.ToDecimal(saldo);
                oPago.id_venta = id_vta;
                oPago.id_med_pago = Convert.ToInt32(comboBoxmedio.SelectedValue);
                oPago.fecha = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                cPago.agregarPago(oPago);
                if (estado == 3)
                {
                    mCuentaCorriente = cCuentaCorriente.Getcc(id_cliente).FirstOrDefault();

                    Modelo.Ventas venta= new Modelo.Ventas();
                    venta = cVenta.getVentaId(id_vta);
                    venta.id_estado = 5;
                    cVenta.modificarVenta(venta);

                    Modelo.Movimientos movimiento = new Modelo.Movimientos();
                    movimiento.tipo = 2;
                    movimiento.fecha = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                    movimiento.id_cc = mCuentaCorriente.id_cc;
                    movimiento.monto = saldo;
                    Controladora.Movimiento.Obtener_instancia().agregarMovimiento(movimiento);


                    mCuentaCorriente.saldo -= saldo;                       
                    mCuentaCorriente.plazo = cVenta.ProximaVentaAVencer(id_cliente,3);                    
                    cCuentaCorriente.modificarCuentaCorriente(mCuentaCorriente);
                }
                else
                {
                    Modelo.Ventas venta = new Modelo.Ventas();
                    venta = cVenta.getVentaId(id_vta);
                    venta.id_estado = 4;
                    cVenta.modificarVenta(venta);
                }

                MessageBox.Show("Pago efectuado con exito");
                this.Close();
            }
            else
            {
                MessageBox.Show("El monto ingresado es menor al saldo de la venta");
            }
        }


    private void leerPago(int pVenta)
    {
        System.Collections.IList detalle = Controladora.Detalle_venta.Obtener_instancia().getDetalleVta(pVenta);
        dataVtas.DataSource = detalle;
        dataVtas.Columns[4].Visible = false;
        dataVtas.Columns[5].Visible = false;
        lblSaldo.Text = totalPrecio.ToString();
    }

        private void cargarDatosCliente(int id_cliente)
        {
            mCliente = new Modelo.Clientes();
            mCliente = cCliente.GetClienteID(id_cliente).FirstOrDefault();
            txtdni.Text = mCliente.dni.ToString();
            txtnombre.Text = mCliente.nombre;
            txtemail.Text = mCliente.email;
            txtTEL.Text = mCliente.telefono;
        }

        private void comboBoxmedio_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBoxmedio.SelectedIndex == 1)
        {
            txtPago.Enabled = true;
            txtPago.Text = "";
        }
        else
        {
            txtPago.Enabled = false;
            txtPago.Text = lblSaldo.Text;
        }
    }

        private void txtPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) || Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            if (e.KeyChar == ',')
            {
                if (count < 1 && txtPago.Text.Trim().Length > 0)
                {
                    count++;
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
