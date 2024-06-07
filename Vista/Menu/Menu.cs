using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.Clientes;
using Vista.Pagos;

namespace Vista
{
    public partial class Menu : Form
    {
        private static Form formulario = null;
        private static Form formularioActivo = null;
        private static Menu instancia;

        public static Menu Obtener_instancia()
        {
            if (instancia == null)
                instancia = new Menu();
            if (instancia.IsDisposed)
                instancia = new Menu();

            instancia.BringToFront();
            return instancia;
        }
        public Menu()
        {
            InitializeComponent();
            //FormBorderStyle = FormBorderStyle.Sizable;
            //WindowState = FormWindowState.Maximized;
        }

        private void abrirForm(Form formulario)
        {
            if (formularioActivo!=null)
            {
                formularioActivo.Close();
            }

            formularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            int containerCenterX = panel.Width / 2 - formulario.Width / 2;
            int containerCenterY = panel.Height / 2 - formulario.Height / 2;

            // Set the form's location to the center of the container
            formulario.Location = new Point(containerCenterX, containerCenterY);

            panel.Controls.Add(formulario);
            formulario.Show();
        }

        private void gestionarCuentaCorrienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //abrirForm(new gestion_cc());
            gestion_cc cc = new gestion_cc();
            cc.ShowDialog();
        }

        private void crearVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form gv = Gestionar_ventas.Obtener_instancia();
            gv.ShowDialog();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nuevaVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ventas = Ventas.Obtener_instancia(0, 1);
            ventas.ShowDialog();
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form form = new Form1();
            form.ShowDialog();
        }

        private void gestionarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Gestionar_empleados.Obtener_instancia();
            form.ShowDialog();
        }

        private void gestionarPagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Gestionar_pagos.Obtener_instancia();
            form.ShowDialog();
        }
    }
}
