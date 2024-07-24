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
    public partial class Gestionar_usuarios : Form
    {
        private static Gestionar_usuarios instancia;
        Controladora.Usuario cUsuario = Controladora.Usuario.Obtener_instancia();
        private List<Modelo.Usuarios> Usuarios;
        private List<Modelo.Usuarios> UsuariosFiltrados;
        private Modelo.Usuarios Usuario;
        private int id_usuario;
        private int index;
        Controladora.Seguridad_composite.PermisoGrupo cPermisoGrupo = Controladora.Seguridad_composite.PermisoGrupo.Obtener_instancia();

        public static Gestionar_usuarios Obtener_instancia()
        {
            if (instancia == null)
            {
                instancia = new Gestionar_usuarios();
            }
            if (instancia.IsDisposed)
            {
                instancia = new Gestionar_usuarios();
            }
            instancia.BringToFront();
            return instancia;
        }

        public Gestionar_usuarios()
        {
            InitializeComponent();
            ConfigurarPermisosBotones();
            Usuarios = cUsuario.getUsuarios();
            filtrar();
            comboBoxfiltro.Items.Add("DNI");
            comboBoxfiltro.Items.Add("Nombre");
            comboBoxfiltro.SelectedIndex = 0;
            buttonEliminar.Enabled = false;
            buttonModificar.Enabled = false;
            buttonClave.Enabled = false;
            checkBoxSoloHabilitados.Checked = true;
            dataUsuarios.Columns[0].Visible = false;
            dataUsuarios.Columns[8].Visible = false;
            dataUsuarios.Columns[9].Visible = false;
        }

        private void ConfigurarPermisosBotones()
        {
            buttonAgregar.Visible = cPermisoGrupo.valiPermiso("Agregar usuario");
            buttonModificar.Visible = cPermisoGrupo.valiPermiso("Modificar usuario");
            buttonEliminar.Visible = cPermisoGrupo.valiPermiso("Eliminar usuario");
            buttonEliminar.Visible = cPermisoGrupo.valiPermiso("Resetear clave");
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            Form ventas = detalle_usuario.Obtener_instancia(0);
            ventas.Show();
            Usuarios = cUsuario.getUsuarios();
            filtrar();
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            Form form = detalle_usuario.Obtener_instancia(id_usuario);
            form.Show();
            Usuarios = cUsuario.getUsuarios();
            filtrar();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea eliminar el cliente?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                UsuariosFiltrados = Usuarios;
                Usuario = new Modelo.Usuarios();
                Usuario = UsuariosFiltrados.Where(cliente => cliente.id_usuario == id_usuario).FirstOrDefault();
                Usuario.estado = false;
                cUsuario.eliminarUsuario(Usuario);
                Usuarios = cUsuario.getUsuarios();
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
                buttonClave.Enabled = false;
                id_usuario = Convert.ToInt32(dataUsuarios.Rows[index].Cells[0].Value);
                txtCli.Text = id_usuario.ToString();
            }
            else
            {
                buttonEliminar.Enabled = false;
                buttonModificar.Enabled = false;
                buttonClave.Enabled = false;
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
            if (checkBoxSoloHabilitados.Checked)
            {
                filtrar();
            }
            else
            {
                filtrar();
            }
        }

        public void filtrar()
        {
            UsuariosFiltrados = cUsuario.getUsuarios();
            if (comboBoxfiltro.Text == "Nombre" && textBoxNombre.Text != "")
            {
                UsuariosFiltrados = UsuariosFiltrados.Where(cliente => cliente.nombre.ToLower().Contains(textBoxNombre.Text.ToLower()) && cliente.estado == checkBoxSoloHabilitados.Checked).ToList();
                dataUsuarios.DataSource = UsuariosFiltrados;
            }
            else if (comboBoxfiltro.Text == "DNI" && textBoxNombre.Text != "")
            {
                UsuariosFiltrados = UsuariosFiltrados.Where(cliente => cliente.dni.ToString().ToLower().Contains(textBoxNombre.Text.ToLower()) && cliente.estado == checkBoxSoloHabilitados.Checked).ToList();
                dataUsuarios.DataSource = UsuariosFiltrados;
            }
            else
            {
                dataUsuarios.DataSource = UsuariosFiltrados.Where(cliente => cliente.estado == checkBoxSoloHabilitados.Checked).ToList();
            }

        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonClave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea modificar la clave del usuario?", "Modificar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                UsuariosFiltrados = Usuarios;
                Usuario = new Modelo.Usuarios();
                Usuario = UsuariosFiltrados.Where(cliente => cliente.id_usuario == id_usuario).FirstOrDefault();
                Usuario.clave = "";
                cUsuario.modificarUsuario(Usuario);
                Usuarios = cUsuario.getUsuarios();
                filtrar();
            }
        }
    }
}
