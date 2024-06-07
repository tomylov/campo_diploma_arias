using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista.Clientes
{
    public partial class detalle_empleados : Form
    {
        private static detalle_empleados instancia;
        private Controladora.Cliente cCliente = Controladora.Cliente.Obtener_instancia();
        private Modelo.Clientes cliente;
        private int id_usuario;

        public static detalle_empleados Obtener_instancia(int id_usuario)
        {
            if (instancia == null)
                instancia = new detalle_empleados(id_usuario);

            if (instancia.IsDisposed)
                instancia = new detalle_empleados(id_usuario);

            instancia.BringToFront();
            return instancia;
        }

        public detalle_empleados(int id_usuario)
        {
            InitializeComponent();
            this.id_usuario = id_usuario;
            if (id_usuario != 0)
            {
                cliente = cCliente.GetCliente(id_usuario).FirstOrDefault();
                //txtid_usuario.Text = cliente.id_usuario.ToString();
                txtnombre.Text = cliente.nombre;
                txtemail.Text = cliente.email;
                txtTEL.Text = cliente.telefono;
                if (cliente.estado == 1)
                    checkEstado.Checked = true;
                else
                    checkEstado.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (id_usuario == 0)
            {
                cliente = new Modelo.Clientes();
                //cliente.id_usuario = Convert.ToInt32(txtid_usuario.Text);
                cliente.nombre = txtnombre.Text;
                cliente.email = txtemail.Text;
                cliente.telefono = txtTEL.Text;
                if (checkEstado.Checked)
                    cliente.estado = 1;
                else
                    cliente.estado = 0;
                cCliente.agregarCliente(cliente);
            }
            else
            {
                cliente = cCliente.GetCliente(id_usuario).FirstOrDefault();
                //cliente.id_usuario = Convert.ToInt32(txtid_usuario.Text);
                cliente.nombre = txtnombre.Text;
                cliente.email = txtemail.Text;
                cliente.telefono = txtTEL.Text;
                if (checkEstado.Checked)
                    cliente.estado = 1;
                else
                    cliente.estado = 0;
                cCliente.modificarCliente(cliente);
            }
            MessageBox.Show("Cliente guardado con exito");
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
