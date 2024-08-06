using Controladora;
using iTextSharp.text.pdf.codec.wmf;
using Modelo;
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

namespace Vista.Clientes
{
    public partial class Gestionar_pagos : Form
    {
        private static Gestionar_pagos instancia;
        Controladora.Pago cPago = Controladora.Pago.Obtener_instancia();
        Controladora.Venta cVenta = Controladora.Venta.Obtener_instancia();
        Controladora.Cuenta_Corriente_Cliente cCuentaCorriente = Controladora.Cuenta_Corriente_Cliente.Obtener_instancia();
        Controladora.Comprobante cComprobante = Controladora.Comprobante.Obtener_instancia();
        Controladora.Seguridad_composite.PermisoGrupo cPermisoGrupo = Controladora.Seguridad_composite.PermisoGrupo.Obtener_instancia();
        private List<Modelo.PagosDTO> pagos;
        private List<Modelo.PagosDTO> pagosFiltrados;
        private Modelo.Pagos pago;
        private int index;
        private int nroPago;
        private int nroVenta;

        public static Gestionar_pagos Obtener_instancia()
        {
            if (instancia == null)
            {
                instancia = new Gestionar_pagos();
            }
            if (instancia.IsDisposed)
            {
                instancia = new Gestionar_pagos();
            }
            instancia.BringToFront();
            return instancia;
        }

        private Gestionar_pagos()
        {
            InitializeComponent();
            pagos = cPago.ListarPagos();
            filtrar();
            ConfigurarPermisosBotones();
            comboBoxfiltro.Items.Add("Pago");
            comboBoxfiltro.Items.Add("DNI");
            comboBoxfiltro.SelectedIndex = 0;
            buttonEliminar.Enabled = false;
            dataClientes.Columns[0].Visible = false;
            dataClientes.Columns[1].Visible = false;
        }

        public void ConfigurarPermisosBotones()
        {
            buttonAgregar.Visible = cPermisoGrupo.valiPermiso("Agregar pago");
            buttonEliminar.Visible = cPermisoGrupo.valiPermiso("Eliminar pago");
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            Form pg = Crear_pago.Obtener_instancia();
            pg.Show();
            filtrar();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea eliminar el pago?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                decimal totaPago = 0;
                pagosFiltrados = pagos;
                pago = new Modelo.Pagos();
                pago = cPago.getPagoId(nroPago);
                totaPago = (decimal)pago.monto;
                int id_comprobante = pago.id_comp.Value;
                cPago.eliminarPago(pago);

                Modelo.Comprobantes comprobantes = new Modelo.Comprobantes();
                comprobantes = cComprobante.GetComrobanteId(id_comprobante);
                cComprobante.deleteComprobante(comprobantes);

                Modelo.Ventas venta = new Modelo.Ventas();
                venta = cVenta.getVentaId(nroVenta);
                Modelo.Cuentas_Corrientes mCuentaCorriente = cCuentaCorriente.Getcc((int)venta.id_cliente).FirstOrDefault();
                if (venta.id_estado == 5)
                {
                    venta.id_estado = 3;
                    cVenta.modificarVenta(venta);

                    Modelo.Movimientos movimiento = new Modelo.Movimientos();
                    movimiento.tipo = 1;
                    movimiento.fecha = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                    movimiento.id_cc = mCuentaCorriente.id_cc;
                    movimiento.monto = venta.total;
                    Controladora.Movimiento.Obtener_instancia().agregarMovimiento(movimiento);


                    mCuentaCorriente.saldo += venta.total;
                    mCuentaCorriente.plazo = cVenta.ProximaVentaAVencer((int)venta.id_cliente, 3);
                    cCuentaCorriente.modificarCuentaCorriente(mCuentaCorriente);
                }
                if (venta.id_estado == 4)
                {
                     venta.id_estado = 2;
                    cVenta.modificarVenta(venta);                    
                }
                if (venta.id_estado == 3)
                {
                    Modelo.Movimientos movimiento = new Modelo.Movimientos();
                    movimiento.tipo = 1;
                    movimiento.fecha = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                    movimiento.id_cc = mCuentaCorriente.id_cc;
                    movimiento.monto = totaPago;
                    Controladora.Movimiento.Obtener_instancia().agregarMovimiento(movimiento);


                    mCuentaCorriente.saldo += totaPago;
                    mCuentaCorriente.plazo = cVenta.ProximaVentaAVencer((int)venta.id_cliente, 3);
                    cCuentaCorriente.modificarCuentaCorriente(mCuentaCorriente);
                }

            }
            filtrar();
            buttonEliminar.Enabled = false;
        }

        private void dataClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index != -1)
            {
                buttonEliminar.Enabled = true;
                nroPago = Convert.ToInt32(dataClientes.Rows[index].Cells[2].Value);
                nroVenta = Convert.ToInt32(dataClientes.Rows[index].Cells[0].Value);

                txtCli.Text = nroPago.ToString();
            }
            else
            {
                buttonEliminar.Enabled = false;
                txtCli.Text = "";
            }
        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            textBoxNombre.Text = "";
            filtrar();
        }

        private void filtrar()
        {
            pagosFiltrados = cPago.ListarPagos();
            if (comboBoxfiltro.Text == "DNI" && textBoxNombre.Text != "")
            {
                pagosFiltrados = pagosFiltrados.Where(pago => pago.dni.ToString().ToLower().Contains(textBoxNombre.Text.ToLower())).ToList();
                dataClientes.DataSource = pagosFiltrados;
            }
            else if (comboBoxfiltro.Text == "Pago" && textBoxNombre.Text != "")
            {
                pagosFiltrados = pagosFiltrados.Where(pago => pago.numero.ToString().ToLower().Contains(textBoxNombre.Text.ToLower())).ToList();
                dataClientes.DataSource = pagosFiltrados;
            }
            else
            {
                dataClientes.DataSource = pagosFiltrados.ToList();
            }

        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
