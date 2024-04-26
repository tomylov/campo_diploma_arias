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
    public partial class gestion_cc : Form
    {
        int indexCombo;
        public gestion_cc()
        {
            InitializeComponent();
            dataModelcc.DataSource =Controladora.Venta.Obtener_instancia().ListarVentasCC(1);
            comboVta.Text = "Pendiente";
            comboVta.Items.Add("Pendiente");
            comboVta.Items.Add("Aceptadas");
        }

        private void open_cc_Click(object sender, EventArgs e)
        {
            if (dni.Text.Length>0)
            {

                cuenta_corriente cc = new cuenta_corriente(Convert.ToInt32(dni.Text));
                cc.ShowDialog();
            }
        }

        private void dataModelcc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

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
    }
}
