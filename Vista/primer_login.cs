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

        public static primer_login Obtener_instancia()
        {
            if (instancia == null)
                instancia = new primer_login();

            if (instancia.IsDisposed)
                instancia = new primer_login();
            
            instancia.BringToFront();
            return instancia;
        }
        public primer_login()
        {
            InitializeComponent();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            if (password.Text=="admin" && user.Text=="admin")
            {
                Hide();
                Menu menu = new Menu();
                menu.Show();
            }
            if (password.Text == "admin1" && user.Text == "admin1")
            {
                Ventas vta = new Ventas();
                vta.ShowDialog();
            }
        }
    }
}
