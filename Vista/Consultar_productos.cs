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
            comboBusqueda.Items.Add("Nombre");
            comboBusqueda.Items.Add("Categoria");
            comboBusqueda.SelectedIndex = 0;            
        }

        private void filtroBtn_Click(object sender, EventArgs e)
        {
            if (comboBusqueda.SelectedIndex == 0)
            {
                dataGridProductos.DataSource = Controladora.Producto.Obtener_instancia().getProductoNombre(txtbusqueda.Text);
            }            
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
    }
}
