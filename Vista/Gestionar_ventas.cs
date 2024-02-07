using System;
using System.Reflection;
using System.Windows.Forms;

namespace Vista
{
    public partial class Gestionar_ventas : Form
    {        
        private static Gestionar_ventas instancia;
        int index;

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
            System.Collections.IList list = Controladora.Venta.Obtener_instancia().ListarVentasCC();
            dataModelcc.DataSource = list;
            Modificar_vta.Enabled = false;
            Eliminar_vta.Enabled = false;
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
            dataModelcc.DataSource = Controladora.Venta.Obtener_instancia().ListarVentasCC();
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
            if (index != -1)
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
    }
}
