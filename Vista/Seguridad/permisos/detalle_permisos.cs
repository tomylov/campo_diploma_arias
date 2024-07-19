using System;
using System.Linq;
using System.Windows.Forms;

namespace Vista.Clientes
{
    public partial class detalle_permisos : Form
    {
        private static detalle_permisos instancia;
        //Permiso
        private Controladora.Seguridad.Permiso cPermiso = Controladora.Seguridad.Permiso.Obtener_instancia();
        private Modelo.Permisos permiso;
        //Formulario
        private Controladora.Seguridad.Formulario cFormulario = Controladora.Seguridad.Formulario.Obtener_instancia();

        private int id_permiso;

        public static detalle_permisos Obtener_instancia(int id_permiso)
        {
            if (instancia == null)
                instancia = new detalle_permisos(id_permiso);

            if (instancia.IsDisposed)
                instancia = new detalle_permisos(id_permiso);

            instancia.BringToFront();
            return instancia;
        }

        public detalle_permisos(int id_permiso)
        {
            InitializeComponent();
            drpFormulario.DataSource = cFormulario.getFormularios();
            this.id_permiso = id_permiso;
            if (id_permiso != 0)
            {
                permiso = cPermiso.getPermiso(id_permiso).FirstOrDefault();
                txtnombre.Text = permiso.nombre_permiso;
                drpFormulario.SelectedValue = permiso.id_formulario;
                checkEstado.Checked = (bool)permiso.estado;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (id_permiso == 0)
            {
                permiso = new Modelo.Permisos();
                permiso.nombre_permiso = txtnombre.Text;
                permiso.estado = checkEstado.Checked;
                permiso.id_formulario = Convert.ToInt32(drpFormulario.SelectedValue);
                cPermiso.agregarPermiso(permiso);
            }
            else
            {
                permiso.nombre_permiso = txtnombre.Text;
                permiso.estado = checkEstado.Checked;
                permiso.id_formulario = Convert.ToInt32(drpFormulario.SelectedValue);
                cPermiso.modificarPermiso(permiso);
            }
            MessageBox.Show("Permiso guardado con exito");
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
