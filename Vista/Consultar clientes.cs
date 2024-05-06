using iTextSharp.text.pdf.codec.wmf;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class Consultar_clientes : Form
    {
        private static Consultar_clientes instancia;
        private Controladora.Cliente cCliente = Controladora.Cliente.Obtener_instancia();
        private List<Modelo.Clientes> clientes;
        private List<Modelo.Clientes> clientesFiltrados;
        public Modelo.Clientes cliente = new Modelo.Clientes();

        public static Consultar_clientes Obtener_instancia()
        {
            if (instancia == null)
            {
                instancia = new Consultar_clientes();
            }
            if (instancia.IsDisposed)
            {
                instancia = new Consultar_clientes();
            }
            instancia.BringToFront();
            return instancia;
        }



        public Consultar_clientes()
        {
            InitializeComponent();
            clientes = (List<Modelo.Clientes>)cCliente.getClientes();
            filtrar();
            comboBoxfiltro.Items.Add("DNI");
            comboBoxfiltro.Items.Add("Nombre");
            comboBoxfiltro.SelectedIndex = 0;
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

        private void bunifuDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;
            if (iRow >= 0 && iColum > 0)
            {
                //cliente.id_cliente = Convert.ToInt32(dataClientes.Rows[iRow].Cells[0].Value);
                cliente.nombre = Convert.ToString(dataClientes.Rows[iRow].Cells[1].Value);
                cliente.dni = Convert.ToInt32(dataClientes.Rows[iRow].Cells[2].Value);
                //cliente.direccion = Convert.ToString(dataClientes.Rows[iRow].Cells[3].Value);
                cliente.telefono = Convert.ToString(dataClientes.Rows[iRow].Cells[4].Value);
                cliente.email = Convert.ToString(dataClientes.Rows[iRow].Cells[5].Value);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void filtrar()
        {
            clientesFiltrados = clientes;
            if (comboBoxfiltro.Text == "Nombre" && textBoxNombre.Text != "")
            {
                clientesFiltrados = clientesFiltrados.Where(cliente => cliente.nombre.ToLower().Contains(textBoxNombre.Text.ToLower()) && cliente.estado == 1).ToList();
                dataClientes.DataSource = clientesFiltrados;
            }
            else if (comboBoxfiltro.Text == "DNI" && textBoxNombre.Text != "")
            {
                clientesFiltrados = clientesFiltrados.Where(cliente => cliente.dni.ToString().ToLower().Contains(textBoxNombre.Text.ToLower()) && cliente.estado == 1).ToList();
                dataClientes.DataSource = clientesFiltrados;
            }
        }
    }
}
