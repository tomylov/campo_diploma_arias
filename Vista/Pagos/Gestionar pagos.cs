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
        Controladora.Seguridad_composite.PermisoGrupo cPermisoGrupo = Controladora.Seguridad_composite.PermisoGrupo.Obtener_instancia();
        private List<Modelo.Pagos> pagos;
        private List<Modelo.Pagos> pagosFiltrados;
        private Modelo.Pagos pago;
        private int index;
        private int nroPago = 1;

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

        public Gestionar_pagos()
        {
            InitializeComponent();
            pagos = cPago.ListarPagos();
            filtrar();
            ConfigurarPermisosBotones();
            comboBoxfiltro.Items.Add("Pago");
            comboBoxfiltro.Items.Add("Venta");
            comboBoxfiltro.SelectedIndex = 0;
            buttonEliminar.Enabled = false;
            dataClientes.Columns[4].Visible = false;
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
                pagosFiltrados = pagos;
                pago = new Modelo.Pagos();
                pago = pagosFiltrados.Where(pago => pago.numero == nroPago).FirstOrDefault();
                cPago.eliminarPago(pago);
                filtrar();
            }
        }

        private void dataClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index != -1)
            {
                buttonEliminar.Enabled = true;
                nroPago = Convert.ToInt32(dataClientes.Rows[index].Cells[0].Value);
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
            pagosFiltrados = pagos;
            if (comboBoxfiltro.Text == "Venta" && textBoxNombre.Text != "")
            {
                pagosFiltrados = pagosFiltrados.Where(pago => pago.id_venta.ToString().ToLower().Contains(textBoxNombre.Text.ToLower())).ToList();
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
