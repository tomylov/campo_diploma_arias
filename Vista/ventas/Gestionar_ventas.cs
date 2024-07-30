using Controladora.Seguridad_composite;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace Vista
{
    public partial class Gestionar_ventas : Form
    {        
        private static Gestionar_ventas instancia;
        Controladora.Seguridad_composite.PermisoGrupo cPermisoGrupo = Controladora.Seguridad_composite.PermisoGrupo.Obtener_instancia();
        Controladora.Venta cVenta = Controladora.Venta.Obtener_instancia();
        int index;
        int indexCombo;
        int id_vta;
        int dni;

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
            ConfigurarPermisosBotones();
            filtrar();
            Modificar_vta.Enabled = false;
            Eliminar_vta.Enabled = false;
            comboVtas.Text = "Pendiente";
            comboVtas.Items.Add("Pendiente");
            comboVtas.Items.Add("Aceptadas");
            comboVtas.SelectedIndex = 0;
        }
        private void ConfigurarPermisosBotones()
        {
            crear_vta.Visible = cPermisoGrupo.valiPermiso("Agregar venta");
            Modificar_vta.Visible = cPermisoGrupo.valiPermiso("Modificar venta");
            Eliminar_vta.Visible = cPermisoGrupo.valiPermiso("Eliminar venta");
        }

        private void crear_vta_Click(object sender, EventArgs e)
        {
            Form vt = Ventas.Obtener_instancia(0,1);
            vt.Show();
            filtrar();
        }

        private void Eliminar_vta_Click(object sender, EventArgs e)
        {
            int idVta = Convert.ToInt32(dataModelcc.Rows[index].Cells[0].Value);
            Controladora.Venta.Obtener_instancia().deleteVta(idVta);
            MessageBox.Show("Venta eliminada con exito");
            filtrar();
            Modificar_vta.Enabled = false;
            Eliminar_vta.Enabled = false;
        }

        private void Modificar_vta_Click(object sender, EventArgs e)
        {
            int idVta = Convert.ToInt32(dataModelcc.Rows[index].Cells[0].Value);
            int dni = Convert.ToInt32(dataModelcc.Rows[index].Cells[2].Value);
            Form vt = Ventas.Obtener_instancia(idVta, dni);
            vt.Show();
            filtrar();
            Modificar_vta.Enabled = false;
            Eliminar_vta.Enabled = false;
        }

        private void dataModelcc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index != -1)
            {
                txtvta.Text = dataModelcc.Rows[index].Cells[0].Value.ToString();
            }
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
                filtrar();
            }
            if (indexCombo == 1)
            {
                filtrar();
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
        public void filtrar()
        {
            if (comboVtas.Text == "Pendiente")
            {
                dataModelcc.DataSource = cVenta.ListarVentasCC(1);
            }
            else if (comboVtas.Text == "Aceptadas")
            {
                dataModelcc.DataSource = cVenta.ListarVentasCC(2);
            }
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
