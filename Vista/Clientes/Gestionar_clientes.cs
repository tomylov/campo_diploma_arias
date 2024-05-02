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

namespace Vista.Clientes
{
    public partial class Gestionar_clientes : Form
    {
        private static Gestionar_clientes instancia;
        Controladora.Cliente cCliente = Controladora.Cliente.Obtener_instancia();
        private List<Modelo.Clientes> clientes;
        private List<Modelo.Clientes> clientesFiltrados;
        private Modelo.Clientes cliente;
        private int dni;
        private int index;
        private int estado = 1;

        public static Gestionar_clientes Obtener_instancia()
        {
            if (instancia == null)
            {
                instancia = new Gestionar_clientes();
            }
            if (instancia.IsDisposed)
            {
                instancia = new Gestionar_clientes();
            }
            instancia.BringToFront();
            return instancia;
        }

        public Gestionar_clientes()
        {
            InitializeComponent();
            clientes = (List<Modelo.Clientes>)cCliente.getClientes();
            filtrar();
            comboBoxfiltro.Items.Add("DNI");
            comboBoxfiltro.Items.Add("Nombre");
            comboBoxfiltro.SelectedIndex = 0;
            buttonAgregar.Enabled = false;
            buttonEliminar.Enabled = false;
            buttonModificar.Enabled = false;
            checkBoxSoloHabilitados.Checked = true;
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            Form ventas = modal_clientes.Obtener_instancia(0);
            ventas.Show();
            filtrar();
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            Form form = modal_clientes.Obtener_instancia(dni);
            form.Show();
            filtrar();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            clientesFiltrados = clientes;
            cliente = new Modelo.Clientes();
            cliente = clientesFiltrados.Where(cliente => cliente.dni == dni).FirstOrDefault();
            MessageBox.Show("Cliente eliminado con exito"); //preguntar si se va a eliminar o no
            cCliente.eliminarCliente(cliente);
            filtrar();
        }

        private void dataClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index != -1)
            {
                buttonAgregar.Enabled = true;
                buttonEliminar.Enabled = true;
                buttonModificar.Enabled = true;
                dni = Convert.ToInt32(dataClientes.Rows[index].Cells[0].Value);
                txtCli.Text = dni.ToString();
            }
            else
            {
                buttonAgregar.Enabled = false;
                buttonEliminar.Enabled = false;
                buttonModificar.Enabled = false;
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

        private void checkBoxSoloHabilitados_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSoloHabilitados.Checked)
            {
                estado = 1;
                filtrar();
            }
            else
            {
                estado = 0;
                filtrar();
            }
        }

        private void filtrar()
        {
            clientesFiltrados = clientes;
            if (comboBoxfiltro.Text == "Nombre" && textBoxNombre.Text != "")
            {
                clientesFiltrados = clientesFiltrados.Where(cliente => cliente.nombre.ToLower().Contains(textBoxNombre.Text.ToLower()) && cliente.estado == estado).ToList();
                dataClientes.DataSource = clientesFiltrados;
            }
            else if (comboBoxfiltro.Text == "DNI" && textBoxNombre.Text != "")
            {
                clientesFiltrados = clientesFiltrados.Where(cliente => cliente.dni.ToString().ToLower().Contains(textBoxNombre.Text.ToLower()) && cliente.estado == estado).ToList();
                dataClientes.DataSource = clientesFiltrados;
            }
            else
            {
                dataClientes.DataSource = clientesFiltrados.Where(cliente =>cliente.estado == estado).ToList();
            }

        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
