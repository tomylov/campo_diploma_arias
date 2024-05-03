using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista.Pagos
{
    public partial class Crear_pago : Form
    {
        public Crear_pago()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, @"^[0-9]*(?:\.[0-9]*)?$"))
            {
                textBox1.Text = "";
            }
        }
    }
}
