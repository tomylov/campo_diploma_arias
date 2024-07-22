using Controladora;
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
using Vista.Seguridad;

namespace Vista
{
    public partial class Menu : Form
    {
        private static Form formulario = null;
        private static Form formularioActivo = null;
        private static Menu instancia;
        private List<Modelo.Formularios> formularios = new List<Modelo.Formularios>();
        private List<Modelo.Modulos> modulos = new List<Modelo.Modulos>();
        Controladora.Seguridad_composite.PermisoGrupo cPermisoGrupo = Controladora.Seguridad_composite.PermisoGrupo.Obtener_instancia();

        public static Menu Obtener_instancia(Modelo.Usuarios usuario)
        {
            if (instancia == null)
                instancia = new Menu(usuario);
            if (instancia.IsDisposed)
                instancia = new Menu(usuario);

            instancia.BringToFront();
            return instancia;
        }
        public Menu(Modelo.Usuarios usuario)
        {
            InitializeComponent();
            cPermisoGrupo.GetPermisosLogin(usuario.id_usuario);
            formularios = cPermisoGrupo.GetFormulariosUsuario(usuario.id_usuario);
            modulos = cPermisoGrupo.GetModulosUsuario(usuario.id_usuario);
            ConfigurarModulos();
            ConfigurarFormularios();
            //FormBorderStyle = FormBorderStyle.Sizable;
            //WindowState = FormWindowState.Maximized;
        }

        private void ConfigurarModulos()
        {
            moduloSeguridad.Visible = modulos.Any(m => m.nombre == "Seguridad");
            moduloVentas.Visible = modulos.Any(m => m.nombre == "Ventas");
            moduloCC.Visible = modulos.Any(m => m.nombre == "Cuenta corriente");
        }

        private void ConfigurarFormularios()
        {
            //Seguridad
            formularioUsuarios.Visible = formularios.Any(f => f.nombre == "Usuarios");
            formularioGrupos.Visible = formularios.Any(f => f.nombre == "Grupos");
            formularioPermiso.Visible = formularios.Any(f => f.nombre == "Permisos");
            //Ventas
            formularioGestionarVentas.Visible = formularios.Any(f => f.nombre == "Gestionar ventas");
            formularioGestionarClientes.Visible = formularios.Any(f => f.nombre == "Gestionar clientes");
            //Cuenta corriente
            formularioGestionarCuentaCorriente.Visible = true;//formularios.Any(f => f.nombre == "Gestionar cuenta corriente"); no botones ahi
            formularioGestionarPagos.Visible = formularios.Any(f => f.nombre == "Gestionar pagos");
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
            Form form = Gestionar_usuarios.Obtener_instancia();
            form.Show();
        }

        private void nuevaVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ventas = Ventas.Obtener_instancia(0, 1);
            ventas.Show();
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form form = Form1.Obtener_instancia();
            form.Show();
        }

        private void gestionarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Gestionar_clientes.Obtener_instancia();
            form.ShowDialog();
        }

        private void gestionarPagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Gestionar_pagos.Obtener_instancia();
            form.ShowDialog();
        }

        private void gruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Gestionar_grupos.Obtener_instancia();
            form.ShowDialog();
        }

        private void permisoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Gestionar_permisos.Obtener_instancia();
            form.ShowDialog();
        }
    }
}
