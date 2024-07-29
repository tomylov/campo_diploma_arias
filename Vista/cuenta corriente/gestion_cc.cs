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
    public partial class gestion_cc : Form
    {
        private int indexCombo;
        private int index;
        Modelo.Ventas venta;

        public static gestion_cc instancia;
        public static gestion_cc Obtener_instancia()
        {
            if (instancia == null)
                instancia = new gestion_cc();
            if (instancia.IsDisposed)
                instancia = new gestion_cc();
            instancia.BringToFront();
            return instancia;
        }
        public gestion_cc()
        {
            InitializeComponent();
            dataModelcc.DataSource =Controladora.Venta.Obtener_instancia().ListarVentasCC(1);
            dataModelcc.Columns["estado"].Visible = false;
            comboVta.Text = "Pendiente";
            comboVta.Items.Add("Pendiente");
            comboVta.Items.Add("Aceptadas");
        }

        private void open_cc_Click(object sender, EventArgs e)
        {
            if (txtdni.Text.Length>0)
            {
                //hay que buscar el id cliente y entrar en al cuenta corriente
                Modelo.Clientes Cliente = new Modelo.Clientes();
                Cliente = Controladora.Cliente.Obtener_instancia().GetCliente(Convert.ToInt32(txtdni.Text)).FirstOrDefault();
            }
        }

        private void dataModelcc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            venta = new Modelo.Ventas();
            venta.id_cliente = Convert.ToInt32(dataModelcc.Rows[index].Cells[2].Value);
            venta.id_venta = Convert.ToInt32(dataModelcc.Rows[index].Cells[0].Value);
            venta.id_venta = Convert.ToInt32(dataModelcc.Rows[index].Cells[3].Value);
            //Crear_pago crear_Pago = Crear_pago.Obtener_instancia(venta);
            Crear_pago crear_Pago = Crear_pago.Obtener_instancia();
            crear_Pago.Show();
        }

        private void comboVta_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexCombo = comboVta.SelectedIndex;
            if (indexCombo == 0)
            {
                System.Collections.IList list = Controladora.Venta.Obtener_instancia().ListarVentasCC(1);
                dataModelcc.DataSource = list;
            }
            if (indexCombo == 1)
            {
                System.Collections.IList list = Controladora.Venta.Obtener_instancia().ListarVentasCC(2);
                dataModelcc.DataSource = list;
            }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {

        }

        private void dataModelcc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index !=-1)
            {
                bunifuButton1.Enabled = true;

            }
        }
    }
}
