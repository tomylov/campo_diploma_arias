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
    public partial class Form1 : Form
    {
        private static Form1 instancia;

        public static Form1 Obtener_instancia()
        {
            if (instancia == null)
                instancia = new Form1();

            if (instancia.IsDisposed)
                instancia = new Form1();
            
            instancia.BringToFront();
            return instancia;
        }
        public Form1()
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
