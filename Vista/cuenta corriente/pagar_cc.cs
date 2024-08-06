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
    public partial class pagar_cc : Form
    {
        private static pagar_cc instancia;
        private int id_cliente;
        private int id_vta;
        int count=0;
        //Controladora.Pago cPago = Controladora.Pago.Obtener_instancia();
        Controladora.Cuenta_Corriente_Cliente cCuentaCorriente = Controladora.Cuenta_Corriente_Cliente.Obtener_instancia();
        Controladora.Pago cPago = Controladora.Pago.Obtener_instancia();
        Controladora.Venta cVenta = Controladora.Venta.Obtener_instancia();
        Modelo.Cuentas_Corrientes mCuentaCorriente;
        Modelo.Ventas mVenta;

        public static pagar_cc Obtener_instancia(Modelo.Cuentas_Corrientes cc)
        {
            if (instancia == null)
                instancia = new pagar_cc(cc);

            if (instancia.IsDisposed)
                instancia = new pagar_cc(cc);

            instancia.BringToFront();
            return instancia;
        }
        private pagar_cc(Modelo.Cuentas_Corrientes cc)
        {
            InitializeComponent(); 
            comboBoxmedio.DataSource = Controladora.Medio_Pagos.Obtener_instancia().ListarMedioPagos();
            this.id_cliente = (int)cc.id_cliente;
            mVenta = cVenta.ProximaVentaAVencerClienteCC(id_cliente);
            if (mVenta == null)
            {
                MessageBox.Show("No hay ventas a pagar");
                this.Close();
                return;
            }
            this.id_vta = (int)mVenta.id_venta;
            decimal total = mVenta.total;
            total -= cVenta.ObtenerSumaPagosVenta(mVenta.id_venta);
            lblSaldo.Text = total.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonPagar_Click(object sender, EventArgs e)
        {
            decimal pago = Convert.ToDecimal(txtPago.Text);
            decimal saldo = Convert.ToDecimal(lblSaldo.Text);

            if (pago >= saldo)
            {
                Modelo.Ventas venta= new Modelo.Ventas();
                cVenta.CambiarEstado(id_vta);
                venta = cVenta.getVentaId(id_vta);
                venta.id_estado = 5;
                cVenta.modificarVenta(venta);
                pagar(saldo);
            }
            else
            {
                pagar(pago);
            }            
            MessageBox.Show("Pago efectuado con exito");
            cuenta_corriente.Obtener_instancia().refresh();
            this.Close();
        }

        private void pagar(decimal total)
        {
            Modelo.Pagos oPago = new Modelo.Pagos();
            oPago.monto = Convert.ToDecimal(total);
            oPago.id_venta = id_vta;
            oPago.id_med_pago = Convert.ToInt32(comboBoxmedio.SelectedValue);
            oPago.fecha = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            cPago.agregarPago(oPago);
            mCuentaCorriente = cCuentaCorriente.Getcc(id_cliente).FirstOrDefault();

            Modelo.Movimientos movimiento = new Modelo.Movimientos();
            movimiento.tipo = 2;
            movimiento.fecha = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            movimiento.id_cc = mCuentaCorriente.id_cc;
            movimiento.monto = total;
            Controladora.Movimiento.Obtener_instancia().agregarMovimiento(movimiento);

            mCuentaCorriente.saldo -= total;
            mCuentaCorriente.plazo = cVenta.ProximaVentaAVencer(id_cliente, 3);
            cCuentaCorriente.modificarCuentaCorriente(mCuentaCorriente);
            MessageBox.Show("Pago efectuado con exito");
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

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxmedio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
