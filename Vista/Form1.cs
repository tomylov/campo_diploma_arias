using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class Form1 : Form
    {
        private static Form1 instancia;
        Modelo.Usuarios usuario = new Modelo.Usuarios();
        Controladora.Seguridad.SesionManager cSesionManager = Controladora.Seguridad.SesionManager.Obtener_instancia();

        public static Form1 Obtener_instancia()
        {
            if (instancia == null)
                instancia = new Form1();

            if (instancia.IsDisposed)
                instancia = new Form1();

            instancia.BringToFront();
            return instancia;
        }
        private Form1()
        {
            InitializeComponent();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            usuario = cSesionManager.GetUsuario(user.Text);
            if (usuario == null)
            {
                MessageBox.Show("Usuario y/o contraseña incorrecto", "LogIn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (usuario != null && usuario.clave == "")
            {
                Form form = Vista.primer_login.Obtener_instancia(usuario);
                form.Show();
                return;
            }
            if (usuario.estado == false)
            {
                MessageBox.Show("Usuario inactivo contactarse con el administrador","Información",
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            if (cSesionManager.LoginUser(user.Text, password.Text))
            {
                Modelo.SesionUsuario sesion = new Modelo.SesionUsuario();
                sesion.id_usuario = usuario.id_usuario;
                sesion.usuario = usuario.usuario;
                sesion.FechaInicio = DateTime.Now;
                sesion.Duracion = "Sesion en curso";
                Controladora.Auditoria.SesionesUsuario.Obtener_instancia().RegistrarInicioSesion(sesion);
                Form form = Vista.Menu.Obtener_instancia(usuario);
                form.Show();
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrecto", "LogIn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
