using Controladora;
using Controladora.Seguridad_composite;
using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.Pagos;

namespace Vista
{
    public partial class cuenta_corriente : Form
    {
        int index;
        //permisos
        Controladora.Seguridad_composite.PermisoGrupo cPermisoGrupo = Controladora.Seguridad_composite.PermisoGrupo.Obtener_instancia();
        Modelo.Clientes cliente = new Modelo.Clientes();
        Modelo.Cuentas_Corrientes cuentaCorriente = new Modelo.Cuentas_Corrientes();
        //ventas
        Controladora.Venta cVenta = Controladora.Venta.Obtener_instancia();
        List<Modelo.Ventas> lVentas = new List<Modelo.Ventas>();
        List<Modelo.Cuentas_Corrientes> Cuentas_Corrientes = new List<Modelo.Cuentas_Corrientes>();
        List<Modelo.Movimientos> Movimientos = new List<Modelo.Movimientos>();
        //pagos
        Controladora.Pago cPago = Controladora.Pago.Obtener_instancia();
        List<Modelo.Pagos> Pagos = new List<Modelo.Pagos>();
        private static cuenta_corriente instancia;
        public static cuenta_corriente Obtener_instancia()
        {
            if (instancia == null)
                instancia = new cuenta_corriente();
            if (instancia.IsDisposed)
                instancia = new cuenta_corriente();
            return instancia;
        }
        private cuenta_corriente()
        {
            InitializeComponent();
            numberVta.Text = "";
            ConfigurarPermisosBotones();

            //Preparo el combo box para que haga las diferentes querys
            comboSelect.Text= "Ventas-retirar";
            comboSelect.Items.Add("Ventas-retirar");
            comboSelect.Items.Add("Ventas-Cuenta Corriente");
            comboSelect.Items.Add("Movimientos");
            comboSelect.Items.Add("Pagos");
        }

        private void ConfigurarPermisosBotones()
        {
            VentaCC.Visible = cPermisoGrupo.valiPermiso("Agregar cc");
            btnPay.Visible = cPermisoGrupo.valiPermiso("Pagar");
            btnPayCC.Visible = cPermisoGrupo.valiPermiso("Pagar cc");
            BtnPrint.Visible = cPermisoGrupo.valiPermiso("Imprimir venta");
            BtnSendEmail.Visible = cPermisoGrupo.valiPermiso("Notificar venta");
        }

        private void bunifuGroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if(numberVta.Text != "")
            {
                Modelo.Ventas venta = new Modelo.Ventas();
                venta.id_venta = Convert.ToInt32(dataMove.Rows[index].Cells[0].Value);
                venta.id_estado = Convert.ToInt32(dataMove.Rows[index].Cells[2].Value);
                venta.id_cliente = Convert.ToInt32(dataMove.Rows[index].Cells[3].Value);
                venta.total = Convert.ToDecimal(dataMove.Rows[index].Cells[5].Value);
                Crear_pago form = Crear_pago.Obtener_instancia(venta);
                form.Show();
                dataMove.DataSource = null;
                numberVta.Text = "";
            }
        }

        private void dataMove_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index != -1)
            {
                string idVta = (dataMove.Rows[index].Cells[0].Value).ToString();
                numberVta.Text = idVta;                
            }
            else
            {
                numberVta.Text = "";
            }
        }

        private void VentaCC_Click(object sender, EventArgs e)
        {
            if (numberVta.Text != "")
            {
                Modelo.Ventas venta = new Modelo.Ventas();
                venta.id_venta = Convert.ToInt32(dataMove.Rows[index].Cells[0].Value);
                venta.id_estado = Convert.ToInt32(dataMove.Rows[index].Cells[2].Value);
                venta.id_cliente = Convert.ToInt32(dataMove.Rows[index].Cells[3].Value);
                venta.total = Convert.ToDecimal(dataMove.Rows[index].Cells[5].Value);
                venta_cc form = venta_cc.Obtener_instancia(venta);
                form.Show();
                numberVta.Text = "";
            }
        }

        private void comboSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            refresh();
        }

        public void refresh()
        {
            cuentaCorriente = Controladora.Cuenta_Corriente_Cliente.Obtener_instancia().Getcc(cliente.id_cliente).FirstOrDefault();
            if (cuentaCorriente != null)
            {
                if (cuentaCorriente.plazo != null)
                {
                    bunifuDatePicker1.Visible = true;
                    bunifuLabel6.Text = "Proxima venta a vencer:";
                    bunifuDatePicker1.Value = cuentaCorriente.plazo.Value;
                }
                else
                {
                    bunifuLabel6.Text = "No hay ventas a vencer";
                    bunifuDatePicker1.Visible = false;
                }
                lblSaldo.Text = cuentaCorriente.saldo.ToString();

                if (comboSelect.SelectedIndex == 2)
                {
                    dataMove.DataSource = Controladora.Cuenta_Corriente_Cliente.Obtener_instancia().listarMovimientos(cuentaCorriente.id_cc);
                    dataMove.Columns[0].Visible = false;
                    btnPay.Enabled = false;
                    VentaCC.Enabled = false;
                    BtnSendEmail.Enabled = false;
                }
                if (comboSelect.SelectedIndex == 0)
                {
                    lVentas = cVenta.ListarVentasClientes(2, cliente.id_cliente);
                    dataMove.DataSource = lVentas;
                    dataMove.Columns[2].Visible = false;
                    dataMove.Columns[3].Visible = false;
                    dataMove.Columns[4].Visible = false;
                    dataMove.Columns[6].Visible = false;
                    dataMove.Columns[7].Visible = false;
                    dataMove.Columns[8].Visible = false;
                    dataMove.Columns[9].Visible = false;
                    dataMove.Columns[10].Visible = false;
                    dataMove.Columns[11].Visible = false;
                    btnPay.Enabled = true;
                    VentaCC.Enabled = true;
                    BtnSendEmail.Enabled = true;
                }
                if (comboSelect.SelectedIndex == 1)
                {
                    lVentas = cVenta.ListarVentasClientes(3, cliente.id_cliente);
                    dataMove.DataSource = lVentas;
                    btnPay.Enabled = true;
                    VentaCC.Enabled = false;
                    dataMove.Columns[2].Visible = false;
                    dataMove.Columns[3].Visible = false;
                    dataMove.Columns[4].Visible = false;
                    dataMove.Columns[6].Visible = false;
                    dataMove.Columns[7].Visible = false;
                    dataMove.Columns[8].Visible = false;
                    dataMove.Columns[9].Visible = false;
                    dataMove.Columns[10].Visible = false;
                    dataMove.Columns[11].Visible = false;
                    BtnSendEmail.Enabled = true;
                }
                if (comboSelect.SelectedIndex == 3)
                {
                    dataMove.DataSource = Controladora.Venta.Obtener_instancia().ListarPagos(cliente.id_cliente);
                    btnPay.Enabled = false;
                    VentaCC.Enabled = false;
                    BtnSendEmail.Enabled = true;
                    dataMove.Columns[1].Visible = false;
                }
                if (cuentaCorriente.saldo != null && cuentaCorriente.saldo != 0.00m)
                {
                    btnPayCC.Enabled = true;
                }
                else
                {
                    btnPayCC.Enabled = false;
                }
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Consultar_clientes form = Consultar_clientes.Obtener_instancia();
            if (form.ShowDialog() == DialogResult.OK)
            {
                cliente.id_cliente = form.cliente.id_cliente;
                cliente.dni = form.cliente.dni;
                cliente.nombre = form.cliente.nombre;
                cliente.telefono = form.cliente.telefono;
                cliente.email = form.cliente.email;
                cliente.ra = form.cliente.ra;
            }
            inputDNI.Text = Convert.ToString(cliente.dni);
            inputName.Text = cliente.nombre;
            inputEmail.Text = cliente.email;
            refresh();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void BtnSendEmail_Click(object sender, EventArgs e)
        {
            if (numberVta.Text !="")
            {
                cVenta.EnviarEmailEstadoVenta(Convert.ToInt32(dataMove.Rows[index].Cells[0].Value));
                MessageBox.Show("Usuario notificado con exito");
            }
        }

        private void btnPayCC_Click(object sender, EventArgs e)
        {
            pagar_cc form = pagar_cc.Obtener_instancia(cuentaCorriente);
            form.Show();
        }

        private void dataMove_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (numberVta.Text == "" || inputDNI.Text == "")
            {
                return;                
            }

            if (comboSelect.SelectedIndex == 0 || comboSelect.SelectedIndex == 1)
            {
                int idVta = Convert.ToInt32(numberVta.Text);
                int dni = Convert.ToInt32(inputDNI.Text);
                Form vt = Consultar_venta.Obtener_instancia(idVta, dni);
                vt.Show();
            }
            if (comboSelect.SelectedIndex == 3)
            {
                int idPago = Convert.ToInt32(dataMove.Rows[index].Cells[1].Value);
                Form vt = consultar_pagos.Obtener_instancia(idPago);
                vt.Show();
            }
        }
    }
}
