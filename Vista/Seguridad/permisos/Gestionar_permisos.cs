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
        Controladora.Seguridad_composite.PermisoGrupo cPermisoGrupo = Controladora.Seguridad_composite.PermisoGrupo.Obtener_instancia();

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

        private Gestionar_permisos()
        {
            InitializeComponent();
            Permisos = cPermisos.getPermisos();
            ConfigurarPermisosBotones();
            filtrar();
            comboBoxfiltro.Items.Add("Nombre");
            comboBoxfiltro.SelectedIndex = 0;
            buttonEliminar.Enabled = false;
            buttonModificar.Enabled = false;
            checkBoxSoloHabilitados.Checked = true;
            dataUsuarios.Columns[0].Visible = false;
            dataUsuarios.Columns[2].Visible = false;
            dataUsuarios.Columns[4].Visible = false;
            dataUsuarios.Columns[5].Visible = false;
            dataUsuarios.Columns[6].Visible = false;
        }

        private void ConfigurarPermisosBotones()
        {
            buttonAgregar.Visible = cPermisoGrupo.valiPermiso("Agregar permiso");
            buttonModificar.Visible = cPermisoGrupo.valiPermiso("Modificar permiso");
            buttonEliminar.Visible = cPermisoGrupo.valiPermiso("Eliminar permiso");
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            Form ventas = detalle_permisos.Obtener_instancia(0);
            ventas.Show();
            Permisos = cPermisos.getPermisos();
            filtrar();
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            Form form = detalle_permisos.Obtener_instancia(id_permiso);
            form.Show();
            filtrar();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea eliminar el permiso seleccionado?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Modelo.Permisos Permiso = new Modelo.Permisos();
                Permiso = Permisos.Where(cliente => cliente.id_permiso == id_permiso).FirstOrDefault();
                Permiso.estado = false;
                cPermisos.eliminarPermiso(Permiso);
                filtrar();
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
               filtrar();
        }

        public void filtrar()
        {
            PermisosFiltrados = cPermisos.getPermisos();
            if (comboBoxfiltro.Text == "Nombre" && textBoxNombre.Text != "")
            {
                PermisosFiltrados = PermisosFiltrados.Where(permiso => permiso.nombre_permiso.ToLower().Contains(textBoxNombre.Text.ToLower()) && permiso.estado == checkBoxSoloHabilitados.Checked).ToList();
                dataUsuarios.DataSource = PermisosFiltrados;
            }
            else
            {
                dataUsuarios.DataSource = PermisosFiltrados.Where(cliente => cliente.estado == checkBoxSoloHabilitados.Checked).ToList();
            }
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
