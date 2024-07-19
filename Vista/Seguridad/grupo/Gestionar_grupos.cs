using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Vista.Seguridad;

namespace Vista.Clientes
{
    public partial class Gestionar_grupos : Form
    {
        private static Gestionar_grupos instancia;
        Controladora.Seguridad.Grupo cGrupo = Controladora.Seguridad.Grupo.Obtener_instancia();
        Controladora.Seguridad_composite.PermisoGrupo cPermisoGrupo = Controladora.Seguridad_composite.PermisoGrupo.Obtener_instancia();
        private List<Modelo.Grupos> grupos;
        private List<Modelo.Grupos> gruposFiltrados;
        private Modelo.Grupos grupo;
        private int id_grupo;
        private int index;

        public static Gestionar_grupos Obtener_instancia()
        {
            if (instancia == null)
            {
                instancia = new Gestionar_grupos();
            }
            if (instancia.IsDisposed)
            {
                instancia = new Gestionar_grupos();
            }
            instancia.BringToFront();
            return instancia;
        }

        public Gestionar_grupos()
        {
            InitializeComponent();
            grupos = cGrupo.getGrupos();
            ConfigurarPermisosBotones();
            filtrar();
            comboBoxfiltro.Items.Add("Nombre");
            comboBoxfiltro.SelectedIndex = 0;
            checkBoxSoloHabilitados.Checked = true;
            buttonAgregar.Enabled = true;
            buttonEliminar.Enabled = false;
            buttonModificar.Enabled = false;
            checkBoxSoloHabilitados.Checked = true;
            dataClientes.Columns[2].Visible = false;
            dataClientes.Columns[3].Visible = false;
        }

        private void ConfigurarPermisosBotones()
        {
            buttonAgregar.Visible = cPermisoGrupo.valiPermiso("Agregar grupo");
            buttonModificar.Visible = cPermisoGrupo.valiPermiso("Modificar grupo");
            buttonEliminar.Visible = cPermisoGrupo.valiPermiso("Eliminar grupo");
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            Form grupo = detalle_grupo.Obtener_instancia(0);
            grupo.Show();
            refrescar();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea eliminar el grupo?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                gruposFiltrados = grupos;
                grupo = new Modelo.Grupos();
                grupo = gruposFiltrados.Where(grupo => grupo.grupo_nombre == txtCli.Text).FirstOrDefault();
                cGrupo.eliminarGrupo(grupo);
                filtrar();
            }
        }

        private void dataClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index != -1)
            {
                buttonEliminar.Enabled = true;
                buttonModificar.Enabled = true;
                id_grupo = Convert.ToInt32(dataClientes.Rows[index].Cells[0].Value);
                txtCli.Text = id_grupo.ToString();
            }
            else
            {
                buttonModificar.Enabled = false;
                buttonEliminar.Enabled = false;
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

        private void filtrar()
        {
            gruposFiltrados = grupos;
            if (comboBoxfiltro.Text == "Nombre" && textBoxNombre.Text != "")
            {
                gruposFiltrados = gruposFiltrados.Where(grupo => grupo.grupo_nombre.ToLower().Contains(textBoxNombre.Text.ToLower()) && grupo.estado == checkBoxSoloHabilitados.Checked).ToList();
            }
            else
            {
                gruposFiltrados = gruposFiltrados.Where(grupo => grupo.estado == checkBoxSoloHabilitados.Checked).ToList();
            }
            dataClientes.DataSource = gruposFiltrados;
        }

        private void refrescar()
        {
            grupos = cGrupo.getGrupos();
            filtrar();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            Form grupo = detalle_grupo.Obtener_instancia(id_grupo);
            grupo.Show();
            refrescar();
        }
    }
}
