using Controladora;
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
    public partial class Consultar_productos : Form
    {
        public Modelo.Productos prod = new Modelo.Productos();
        private Controladora.Producto cProducto = Controladora.Producto.Obtener_instancia();
        private List<Productos> productos;
        private List<Productos> productosFiltados;

        private static Consultar_productos instancia;
        public static Consultar_productos Obtener_instancia()
        {
            if (instancia == null)
                instancia = new Consultar_productos();
            if (instancia.IsDisposed)
                instancia = new Consultar_productos();
            return instancia;
        }

        public Consultar_productos()
        {
            InitializeComponent();
            comboBusqueda.Items.Add("id_producto");
            comboBusqueda.Items.Add("Nombre");
            comboBusqueda.SelectedIndex = 0;
            productos = cProducto.getProductos();
            dataGridProductos.DataSource = productos;
        }

        private void filtroBtn_Click(object sender, EventArgs e)
        {
                       
        }

        private void dataGridProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;
            if (iRow >= 0 && iColum > 0)
            {
                prod.id_prod = Convert.ToInt32(dataGridProductos.Rows[iRow].Cells[0].Value);
                prod.nombre = Convert.ToString(dataGridProductos.Rows[iRow].Cells[1].Value);
                prod.precio = Convert.ToDecimal(dataGridProductos.Rows[iRow].Cells[2].Value);
                prod.stock = Convert.ToInt32(dataGridProductos.Rows[iRow].Cells[3].Value);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            txtbusqueda.Focus();
            dataGridProductos.DataSource = null;
        }

        private void txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void filtrar()
        {
            productosFiltados = productos;
            if (comboBusqueda.SelectedIndex == 1)
            {
                productosFiltados = productos.Where(producto => producto.nombre.ToLower().Contains(txtbusqueda.Text.ToLower())).ToList();
            }
            else
            {
                productosFiltados = productos.Where(producto => producto.id_prod.ToString().ToLower().Contains(txtbusqueda.Text.ToLower())).ToList();
            }

        }

    }
}
