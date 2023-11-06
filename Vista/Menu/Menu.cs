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
    public partial class Menu : Form
    {
        private static Form formulario = null;
        private static Form formularioActivo = null;
        public Menu()
        {
            InitializeComponent();
        }

        /*private void abrirForm(Form formulario)
        {
            if (formularioActivo!=null)
            {
                formularioActivo.Close();
            }

            formularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            panel.Controls.Add(formulario);
            formulario.Show();
            MessageBox.Show("HOLAAAAAAAAAAAAAAAAA");

        }*/

        private void gestionarCuentaCorrienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //abrirForm(new gestion_cc());
            gestion_cc cc = new gestion_cc();
            cc.Show();
        }
    }
}
