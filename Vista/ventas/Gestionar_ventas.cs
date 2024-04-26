using System;
using System.Reflection;
using System.Windows.Forms;

namespace Vista
{
    public partial class Gestionar_ventas : Form
    {        
        private static Gestionar_ventas instancia;
        int index;
        int indexCombo;

        public static Gestionar_ventas Obtener_instancia()
        {
            if (instancia == null)
            {
                instancia = new Gestionar_ventas();
            }
            if (instancia.IsDisposed)
            {
                instancia = new Gestionar_ventas();
            }
            instancia.BringToFront();
            return instancia;
        }

        public Gestionar_ventas()
        {
            InitializeComponent();
            System.Collections.IList list = Controladora.Venta.Obtener_instancia().ListarVentasCC(1);
            dataModelcc.DataSource = list;
            Modificar_vta.Enabled = false;
            Eliminar_vta.Enabled = false;
            comboVtas.Text = "Pendiente";
            comboVtas.Items.Add("Pendiente");
            comboVtas.Items.Add("Aceptadas");
        }

        private void crear_vta_Click(object sender, EventArgs e)
        {
            Form vt = Ventas.Obtener_instancia(0,1);
            vt.Show();
        }

        private void Eliminar_vta_Click(object sender, EventArgs e)
        {
            int idVta = Convert.ToInt32(dataModelcc.Rows[index].Cells[0].Value);
            Controladora.Venta.Obtener_instancia().deleteVta(idVta);
            dataModelcc.DataSource = Controladora.Venta.Obtener_instancia().ListarVentasCC(1);
            MessageBox.Show("Venta eliminada con exito");
        }

        private void Modificar_vta_Click(object sender, EventArgs e)
        {
            int idVta = Convert.ToInt32(dataModelcc.Rows[index].Cells[0].Value);
            int dni = Convert.ToInt32(dataModelcc.Rows[index].Cells[2].Value);
            Form vt = Ventas.Obtener_instancia(idVta, dni);
            vt.Show();
        }

        private void dataModelcc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index != -1 && indexCombo == 0)
            {
                Modificar_vta.Enabled = true;
                Eliminar_vta.Enabled = true;
            }
            else
            {
                Modificar_vta.Enabled = false;
                Eliminar_vta.Enabled = false;
            }
        }

        private void comboVtas_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexCombo = comboVtas.SelectedIndex;
            if (indexCombo == 0)
            {
                System.Collections.IList list = Controladora.Venta.Obtener_instancia().ListarVentasCC(1);
                dataModelcc.DataSource = list;
            }
            if (indexCombo == 1)
            {
                System.Collections.IList list = Controladora.Venta.Obtener_instancia().ListarVentasCC(2);
                dataModelcc.DataSource = list;
                Modificar_vta.Enabled = false;
                Eliminar_vta.Enabled = false;
            }
        }

        private void dataModelcc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idVta = Convert.ToInt32(dataModelcc.Rows[index].Cells[0].Value);
            int dni = Convert.ToInt32(dataModelcc.Rows[index].Cells[2].Value);
            Form vt = Consultar_venta.Obtener_instancia(idVta, dni);
            vt.Show();
        }
    }
}
