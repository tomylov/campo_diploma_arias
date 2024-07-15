using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.Clientes;

namespace Vista.Seguridad
{
    public partial class Gestionar_permisos : Form
    {
        private static Gestionar_permisos instancia;
        Controladora.Seguridad.Permiso cPermisos = Controladora.Seguridad.Permiso.Obtener_instancia();
        private List<Modelo.Permisos> Permisos;
        private List<Modelo.Permisos> PermisosFiltrados;
        private Modelo.Permisos Usuario;
        private int id_permiso;
        private int index;

        public static Gestionar_permisos Obtener_instancia()
        {
            if (instancia == null)
            {
                instancia = new Gestionar_permisos();
            }
            if (instancia.IsDisposed)
            {
                instancia = new Gestionar_permisos();
            }
            instancia.BringToFront();
            return instancia;
        }

        public Gestionar_permisos()
        {
            InitializeComponent();
            Permisos = cPermisos.getPermisos();
            filtrar();
            comboBoxfiltro.Items.Add("Nombre");
            comboBoxfiltro.SelectedIndex = 0;
            buttonEliminar.Enabled = false;
            buttonModificar.Enabled = false;
            checkBoxSoloHabilitados.Checked = true;
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            Form ventas = detalle_permisos.Obtener_instancia(0);
            ventas.Show();
            Permisos = cPermisos.getPermisos();
            refresh();
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            Form form = detalle_permisos.Obtener_instancia(id_permiso);
            form.Show();
            refresh();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea eliminar el cliente?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
               /* PermisosFiltrados = Permisos;
                Permiso = new Modelo.Permisos();
                Usuario = PermisosFiltrados.Where(cliente => cliente.id_permiso == id_permiso).FirstOrDefault();
                Usuario.estado = false;
                cPermisos.eliminarUsuario(Usuario);
                Permisos = cPermisos.getPermisos();
                filtrar(); */
            }
        }

        private void dataClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index != -1)
            {
                buttonAgregar.Enabled = true;
                buttonEliminar.Enabled = true;
                buttonModificar.Enabled = true;
                id_permiso = Convert.ToInt32(dataUsuarios.Rows[index].Cells[0].Value);
                txtCli.Text = id_permiso.ToString();
            }
            else
            {
                buttonAgregar.Enabled = false;
                buttonEliminar.Enabled = false;
                buttonModificar.Enabled = false;
                txtCli.Text = "";
            }
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

        private void checkBoxSoloHabilitados_CheckedChanged(object sender, EventArgs e)
        {
               refresh();
        }

        private void filtrar()
        {
            PermisosFiltrados = Permisos;
            if (comboBoxfiltro.Text == "Nombre" && textBoxNombre.Text != "")
            {
                PermisosFiltrados = PermisosFiltrados.Where(permiso => permiso.nombre_permiso.ToLower().Contains(textBoxNombre.Text.ToLower())).ToList();
                dataUsuarios.DataSource = PermisosFiltrados;
                //&& permiso.estado == checkBoxSoloHabilitados.Checked
            }
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void refresh()
        {
            Permisos = cPermisos.getPermisos();
            filtrar();
        }
    }
}
