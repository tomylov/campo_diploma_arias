using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista.Clientes
{
    public partial class detalle_usuarios : Form
    {
        private static detalle_usuarios instancia;
        private Controladora.Usuario cUsuario = Controladora.Usuario.Obtener_instancia();
        private Modelo.Usuarios usuario;
        private int id_usuario;

        public static detalle_usuarios Obtener_instancia(int id_usuario)
        {
            if (instancia == null)
                instancia = new detalle_usuarios(id_usuario);

            if (instancia.IsDisposed)
                instancia = new detalle_usuarios(id_usuario);

            instancia.BringToFront();
            return instancia;
        }

        public detalle_usuarios(int id_usuario)
        {
            InitializeComponent();
            this.id_usuario = id_usuario;
            if (id_usuario != 0)
            {
                usuario = cUsuario.getUsuarioId(id_usuario).FirstOrDefault();
                txtnombre.Text = usuario.nombre;
                txtemail.Text = usuario.email;
                txtape.Text = usuario.apellido;    
                txtdni.Text = usuario.dni;
                checkEstado.Checked = (bool)usuario.estado;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (id_usuario == 0)
            {
                usuario = new Modelo.Usuarios();
                usuario.nombre = txtnombre.Text;
                usuario.email = txtemail.Text;
                usuario.apellido = txtape.Text;
                usuario.dni = txtdni.Text;
                usuario.estado = checkEstado.Checked;
                cUsuario.agregarUsuario(usuario);
            }
            else
            {
                usuario.id_usuario = id_usuario;
                usuario.nombre = txtnombre.Text;
                usuario.email = txtemail.Text;
                usuario.apellido = txtape.Text;
                usuario.dni = txtdni.Text;
                usuario.estado = checkEstado.Checked;
                cUsuario.modificarUsuario(usuario);
            }
            MessageBox.Show("Usuario guardado con exito");
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
