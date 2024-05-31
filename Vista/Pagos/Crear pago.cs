using Controladora;
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
        private int dni;
        private int id_vta;
        private int estado;
        //Controladora.Pago cPago = Controladora.Pago.Obtener_instancia();
        Controladora.Cuenta_Corriente_Cliente cCuentaCorriente = Controladora.Cuenta_Corriente_Cliente.Obtener_instancia();
        Controladora.Pago cPago = Controladora.Pago.Obtener_instancia();
        Controladora.Cliente cCliente = Controladora.Cliente.Obtener_instancia();
        Controladora.Venta cVenta = Controladora.Venta.Obtener_instancia();
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
                this.dni = (int)venta.dni;
                this.estado = (int)venta.estado;
                this.id_vta = venta.id_venta;
                buttonVenta.Visible = false;
                cargarDatosCliente(dni);
                leerPago(id_vta, estado);
            }
            comboBoxmedio.Items.Add("Transferencia");
            comboBoxmedio.Items.Add("Efectivo");
            comboBoxmedio.SelectedIndex = 1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonCliente_Click(object sender, EventArgs e)
        {
            Consultar_ventas conVta = Consultar_ventas.Obtener_instancia();
            if (conVta.ShowDialog() == DialogResult.OK)
            {
                dni = (int)conVta.venta.dni;
                id_vta = conVta.venta.id_venta;
                estado = (int)conVta.venta.estado;
                cargarDatosCliente(dni);
                leerPago(id_vta, estado);
                buttonVenta.Visible = false;
            }
        }

        private void buttonPagar_Click(object sender, EventArgs e)
        {
            decimal pago = Convert.ToDecimal(txtPago.Text);
            decimal saldo = Convert.ToDecimal(lblSaldo.Text);
            if (pago >= saldo)
            {
                if (estado == 3 || estado == 2)
                {
                    mCuentaCorriente = cCuentaCorriente.Getcc(dni).FirstOrDefault();
                    mCuentaCorriente.saldo -= saldo;
                    cCuentaCorriente.modificarCuentaCorriente(mCuentaCorriente);
                }
                Modelo.Pagos oPago = new Modelo.Pagos();
                oPago.monto = Convert.ToDecimal(txtPago.Text);
                oPago.id_venta = id_vta;
                oPago.fecha = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                cPago.agregarPago(oPago);
                cVenta.cambiarEStado(id_vta,4);
                MessageBox.Show("Pago efectuado con exito");
                this.Close();
            }
            else
            {
                MessageBox.Show("El monto ingresado es menor al saldo de la venta");
            }
        }


    private void leerPago(int pVenta, int pEstado)
    {
        System.Collections.IList detalle = Controladora.Detalle_venta.Obtener_instancia().getDetalleVta(pVenta);
        dataVtas.DataSource = detalle;
        dataVtas.Columns[4].Visible = false;
        dataVtas.Columns[5].Visible = false;
        //si estado es igual 1 significa que se estar por pagar una venta que todavia no fue asignada a una cuenta corriente
        decimal totalPrecio = 0;
        foreach (var item in detalle)
        {
            totalPrecio += (decimal)item.GetType().GetProperty("precio").GetValue(item, null);
        }
        lblSaldo.Text = totalPrecio.ToString();
        if (pEstado == 3)
        {
                totalPrecio *= 1.10m;
                lblSaldo.Text = totalPrecio.ToString();
           }
        }

        private void cargarDatosCliente(int dni)
        {
            mCliente = new Modelo.Clientes();
            mCliente = cCliente.GetCliente(dni).FirstOrDefault();
            txtdni.Text = mCliente.dni.ToString();
            txtnombre.Text = mCliente.nombre;
            txtemail.Text = mCliente.email;
            txtRs.Text = mCliente.ra;
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
}
}
