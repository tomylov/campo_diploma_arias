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
    public partial class modal_clientes : Form
    {
        private Controladora.Cliente cCliente = Controladora.Cliente.Obtener_instancia();
        private Modelo.Clientes cliente;
        private int id;
        private static modal_clientes instancia;

        public static modal_clientes Obtener_instancia(int id)
        {
            if (instancia == null)
                instancia = new modal_clientes(id);

            if (instancia.IsDisposed)
                instancia = new modal_clientes(id);

            instancia.BringToFront();
            return instancia;
        }

        public modal_clientes(int id)
        {
            InitializeComponent();
            this.id = id;
            if (id != 0)
            {
                cliente = cCliente.GetClienteID(id).FirstOrDefault();
                txtdni.Text = cliente.dni.ToString();
                txtnombre.Text = cliente.nombre;
                txtemail.Text = cliente.email;
                txtTEL.Text = cliente.telefono;
                if (cliente.estado == true)
                    checkEstado.Checked = true;
                else
                    checkEstado.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                return;
            }

            if (id == 0)
            {
                cliente = new Modelo.Clientes();
                cliente.dni = Convert.ToInt32(txtdni.Text);
                cliente.nombre = txtnombre.Text;
                cliente.email = txtemail.Text;
                cliente.telefono = txtTEL.Text;
                if (checkEstado.Checked)
                    cliente.estado = true;
                else
                    cliente.estado = false;
                cCliente.agregarCliente(cliente);
                Modelo.Cuentas_Corrientes cc = new Modelo.Cuentas_Corrientes();
                cc.id_cliente = cliente.id_cliente;
                cc.saldo = 0;
                Controladora.Cuenta_Corriente_Cliente.Obtener_instancia().agregarCC(cc);
            }
            else
            {
                cliente = cCliente.GetClienteID(id).FirstOrDefault();
                cliente.dni = Convert.ToInt32(txtdni.Text);
                cliente.nombre = txtnombre.Text;
                cliente.email = txtemail.Text;
                cliente.telefono = txtTEL.Text;
                if (checkEstado.Checked)
                    cliente.estado = true;
                else
                    cliente.estado = false;
                cCliente.modificarCliente(cliente);
            }
            MessageBox.Show("Cliente guardado con exito");
            Vista.Clientes.Gestionar_clientes.Obtener_instancia().filtrar();
            this.Close();
        }

        private bool ValidarDatos()
        {
            if (txtdni.Text == "" || txtnombre.Text == "" || txtemail.Text == "" || txtTEL.Text == "")
            {
                MessageBox.Show("Complete todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!COMUN.MetodosComunes.EsSoloNumeros(txtTEL.Text))
            {
                MessageBox.Show("Número de telefono ingresado incorrecto", "Error telefono", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtTEL.Focus();
                return false;
            }

            if (!COMUN.MetodosComunes.ValidacionEMAIL(txtemail.Text))
            {
                MessageBox.Show("Email ingresado incorrecto", "Error email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtemail.Focus();
                return false;
            }

            if (!COMUN.MetodosComunes.ValidaDNI(txtdni.Text))
            {
                MessageBox.Show("DNI ingresado incorrecto", "Error DNI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtdni.Focus();
                return false;
            }

            Modelo.Clientes clienteValidar = cCliente.GetCliente(Convert.ToInt32(txtdni.Text)).FirstOrDefault();
            if (id == 0 && clienteValidar != null)
            {
                MessageBox.Show("Ya existe un cliente con ese dni en la base", "Error DNI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtdni.Focus();
                return false;
            }

            if (id != 0 && clienteValidar != null && clienteValidar != cliente)
            {
                MessageBox.Show("Ya existe un cliente con ese dni en la base", "Error DNI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtdni.Focus();
                return false;
            }

            return true;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = COMUN.MetodosComunes.KeyPressSoloLetras(e, txtnombre.Text);
        }
    }
}
