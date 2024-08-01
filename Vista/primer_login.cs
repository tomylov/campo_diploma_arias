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
    public partial class primer_login : Form
    {
        private static primer_login instancia;
        Modelo.Usuarios usuario = new Modelo.Usuarios();
        Controladora.Usuario cUsuario = Controladora.Usuario.Obtener_instancia();

        public static primer_login Obtener_instancia(Modelo.Usuarios usuario)
        {
            if (instancia == null)
                instancia = new primer_login(usuario);

            if (instancia.IsDisposed)
                instancia = new primer_login(usuario);
            
            instancia.BringToFront();
            return instancia;
        }
        private primer_login(Modelo.Usuarios usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            if (txtPass1.Text == txtPass2.Text)
            {
                usuario.clave = COMUN.MetodosComunes.EncriptarPassBD(txtPass2.Text);
                cUsuario.modificarUsuario(usuario);
                MessageBox.Show("Contraseña guardada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
