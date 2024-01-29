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
        public Form1()
        {
            InitializeComponent();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            if (password.Text=="admin" && user.Text=="admin")
            {
                Menu menu = new Menu();
                Hide();
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
