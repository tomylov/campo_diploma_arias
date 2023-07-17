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
    public partial class gestion_cc : Form
    {
        public gestion_cc()
        {
            InitializeComponent();
        }

        private void open_cc_Click(object sender, EventArgs e)
        {
            if (dni.Text.Length>0)
            {
                cuenta_corriente cc = new cuenta_corriente();
                cc.ShowDialog();
            }
        }
    }
}
