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
        private IEnumerable ventas;
        private IEnumerable ventasFiltradas;
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



        public Consultar_ventas()
        {
            InitializeComponent();
            ventas = cVenta.ListarVentasEstado(1);
            dataVentas.DataSource = ventas;
            filtrar();
            dataVentas.Columns[3].Visible = false;
            comboBoxfiltro.Items.Add("Pendiente");
            comboBoxfiltro.Items.Add("Venta en cc");
            comboBoxfiltro.Items.Add("Moroso");
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
                venta.dni = Convert.ToInt32(dataVentas.Rows[iRow].Cells[1].Value);
                venta.estado = Convert.ToInt32(dataVentas.Rows[iRow].Cells[3].Value);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void filtrar()
        {
            ventasFiltradas = ventas;
            if (textBoxDNI.Text != "")
            {
                //ventasFiltradas.Cast<Modelo.Ventas>().Where(x => x.dni.ToString().Contains(textBoxDNI.Text)).ToList();
                //dataVentas.DataSource = ventasFiltradas;
            }
            else
            {
                dataVentas.DataSource = ventas;
            }
        }

        private void comboBoxfiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxfiltro.SelectedIndex == 0)
            {
                ventas = cVenta.ListarVentasEstado(1);
                filtrar();
            }
            if (comboBoxfiltro.SelectedIndex == 1)
            {
                ventas = cVenta.ListarVentasEstado(2);
                filtrar();
            }
            if (comboBoxfiltro.SelectedIndex == 2)
            {
                ventas = cVenta.ListarVentasEstado(3);
                filtrar();
            }
        }

        private void textBoxDNI_TextChanged(object sender, EventArgs e)
        {
            filtrar();
        }
    }
}
