﻿using System;
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
        private static modal_clientes instancia;
        private Controladora.Cliente cCliente = Controladora.Cliente.Obtener_instancia();
        private Modelo.Clientes cliente;
        private int id;

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
                cliente = cCliente.GetCliente(id).FirstOrDefault();
                txtdni.Text = cliente.dni.ToString();
                txtnombre.Text = cliente.nombre;
                txtemail.Text = cliente.email;
                txtTEL.Text = cliente.telefono;
                txtRs.Text = cliente.ra;
                if (cliente.estado == true)
                    checkEstado.Checked = true;
                else
                    checkEstado.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                cliente = new Modelo.Clientes();
                cliente.dni = Convert.ToInt32(txtdni.Text);
                cliente.nombre = txtnombre.Text;
                cliente.email = txtemail.Text;
                cliente.telefono = txtTEL.Text;
                cliente.ra = txtRs.Text;
                if (checkEstado.Checked)
                    cliente.estado = true;
                else
                    cliente.estado = false;
                cCliente.agregarCliente(cliente);
            }
            else
            {
                cliente = cCliente.GetCliente(id).FirstOrDefault();
                cliente.dni = Convert.ToInt32(txtdni.Text);
                cliente.nombre = txtnombre.Text;
                cliente.email = txtemail.Text;
                cliente.telefono = txtTEL.Text;
                cliente.ra = txtRs.Text;
                if (checkEstado.Checked)
                    cliente.estado = true;
                else
                    cliente.estado = false;
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
