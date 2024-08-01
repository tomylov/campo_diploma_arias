using iTextSharp.text.pdf.codec.wmf;
using Modelo;
using System;
using System.Collections;
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
    public partial class Consultar_ventas : Form
    {
        private static Consultar_ventas instancia;
        private Controladora.Venta cVenta = Controladora.Venta.Obtener_instancia();
        private List<VentaEstadoDTO> ventasFiltradas;
        public Modelo.Ventas venta = new Modelo.Ventas();

        public static Consultar_ventas Obtener_instancia()
        {
            if (instancia == null)
            {
                instancia = new Consultar_ventas();
            }
            if (instancia.IsDisposed)
            {
                instancia = new Consultar_ventas();
            }
            instancia.BringToFront();
            return instancia;
        }

        private Consultar_ventas()
        {
            InitializeComponent();
            ventasFiltradas = cVenta.ListarVentasEstado(2);
            dataVentas.DataSource = ventasFiltradas;
            filtrar();
            dataVentas.Columns[0].Visible = false;
            dataVentas.Columns[1].Visible = false;
            dataVentas.Columns[2].Visible = false;
            comboBoxfiltro.Items.Add("Aceptadas");
            comboBoxfiltro.Items.Add("Venta en cc");
            comboBoxfiltro.SelectedIndex = 0;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            textBoxDNI.Text = "";
            filtrar();
        }

        private void bunifuDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;
            if (iRow >= 0 && iColum > 0)
            {
                venta.id_venta = Convert.ToInt32(dataVentas.Rows[iRow].Cells[0].Value);
                venta.id_cliente= Convert.ToInt32(dataVentas.Rows[iRow].Cells[1].Value);
                venta.id_estado = Convert.ToInt32(dataVentas.Rows[iRow].Cells[2].Value);
                venta.total = Convert.ToDecimal(dataVentas.Rows[iRow].Cells[5].Value);
                this.DialogResult = DialogResult.OK;
                dataVentas.DataSource = null;
                this.Close();
            }
        }

        private void filtrar()
        {
            if (textBoxDNI.Text == "")
            {
                dataVentas.DataSource = ventasFiltradas;
                dataVentas.Columns[0].Visible = false;
                dataVentas.Columns[1].Visible = false;
                dataVentas.Columns[2].Visible = false;
            }
            else
            {
                
                dataVentas.DataSource = ventasFiltradas.Where(x => x.dni.ToString().Contains(textBoxDNI.Text)).ToList();
                dataVentas.Columns[0].Visible = false;
                dataVentas.Columns[1].Visible = false;
                dataVentas.Columns[2].Visible = false;
            }
        }

        private void comboBoxfiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxfiltro.SelectedIndex == 0)
            {
                ventasFiltradas = cVenta.ListarVentasEstado(2);
                filtrar();
            }
            if (comboBoxfiltro.SelectedIndex == 1)
            {
                ventasFiltradas = cVenta.ListarVentasEstado(3);
                filtrar();
            }
        }

        private void textBoxDNI_TextChanged(object sender, EventArgs e)
        {
            filtrar();
        }
    }
}
