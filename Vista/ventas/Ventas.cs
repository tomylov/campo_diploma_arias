﻿using System;
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
    public partial class Ventas : Form
    {
        decimal importe = 0;
        int cantidad;
        decimal precio;
        int dni;
        int venta = 0;
        int id_det = 0;
        int index;
        private static Ventas instancia;

        public static Ventas Obtener_instancia(int id_vta, int dni)
        {
            if (instancia == null)
                instancia = new Ventas(id_vta,dni);
            
            if (instancia.IsDisposed)
                instancia = new Ventas(id_vta, dni);

            instancia.BringToFront();
            return instancia;
        }
        public Ventas()
        {
            InitializeComponent();
        }

        public void habilitarVentas()
        {
            dniPK.Enabled = false;
            btnVta.Visible = false;
            textprod.Enabled = true;
            searchProd.Enabled = true;
            cancelBtn.Enabled = true;
            btnFinish.Enabled = true;
        }

        public Ventas(int id_venta, int dni)
        {
            InitializeComponent();
            if (id_venta != 0) //si es distinto de 0 es porque se esta editando una venta
            {                
                habilitarVentas();
                var datosCli = Controladora.Cliente.Obtener_instancia().GetCliente(dni);
                name.Text = Convert.ToString(datosCli[0].GetType().GetProperty("nombre").GetValue(datosCli[0], null));
                mail.Text = Convert.ToString(datosCli[0].GetType().GetProperty("email").GetValue(datosCli[0], null));
                dniPK.Text = dni.ToString();
                venta = id_venta;
                var datos = Controladora.Detalle_venta.Obtener_instancia().getDetalleVta(venta);
                dataGridDetail.DataSource = datos;
            }
        }

        private void addProduct_Click_1(object sender, EventArgs e)
        {            
            cantidad = 0;
            precio = 0;
            if (textprod.Text != "" && cuantity.Value <= Convert.ToInt32(stock.Text))
            {
                cantidad = Convert.ToInt32(cuantity.Text);
                precio = Convert.ToDecimal(price.Text);
                importe += (precio * cantidad);
                Total.Text = importe.ToString();
                Controladora.Detalle_venta.Obtener_instancia().createdetalleVeta(venta,Convert.ToInt32(textprod.Text),cantidad,precio);
                var datos = Controladora.Detalle_venta.Obtener_instancia().getDetalleVta(venta);
                dataGridDetail.DataSource = datos;
                dataGridDetail.Columns[4].Visible = false;
                textprod.Text = "";
                description.Text = "";
                price.Text = "";
                cuantity.Value = 0;
                stock.Text = "";
            }

        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Venta finalizada");
            Close();
        }

        private void searchProd_Click(object sender, EventArgs e)
        {
            Consultar_productos cp = Consultar_productos.Obtener_instancia();
            if (cp.ShowDialog() == DialogResult.OK)
            {
                textprod.Text = cp.prod.id_prod.ToString();
                description.Text = cp.prod.nombre;
                price.Text = cp.prod.precio.ToString();
                stock.Text = cp.prod.stock.ToString();
                cuantity.Value = 1;
                addProduct.Enabled = true;
            }

        }

        private void textprod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F1)
            {
                try
                {
                    var datos = Controladora.Producto.Obtener_instancia().getProductoId(Convert.ToInt32(textprod.Text));
                    if (datos.Count > 0)
                    {
                        description.Text = Convert.ToString(datos[0].GetType().GetProperty("nombre").GetValue(datos[0], null));
                        price.Text = Convert.ToString(datos[0].GetType().GetProperty("precio").GetValue(datos[0], null));
                        stock.Text = Convert.ToString(datos[0].GetType().GetProperty("stock").GetValue(datos[0], null));
                        cuantity.Value = 1;
                        addProduct.Enabled = true;
                    }
                    else
                    {
                        description.Text = "";
                        price.Text = "";
                        cuantity.Value = 0;
                        stock.Text = "";
                        addProduct.Enabled = false;
                    }
                }
                catch
                {
                    MessageBox.Show("Producto no encontrado");
                }
            }
        }

        private void dniPK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F1)
            {
                try
                {
                    dni = Convert.ToInt32(dniPK.Text);
                    var datos = Controladora.Cliente.Obtener_instancia().GetCliente(dni);
                    if (datos.Count > 0)
                    {
                        name.Text = Convert.ToString(datos[0].GetType().GetProperty("nombre").GetValue(datos[0], null));
                        mail.Text = Convert.ToString(datos[0].GetType().GetProperty("email").GetValue(datos[0], null));
                    }
                    else
                    {
                        name.Text = "";
                        mail.Text= "";
                        textprod.Enabled = false;
                    }

                }
                catch
                {
                    MessageBox.Show("no se encontro el cliente");
                }
            }

        }

        private void btnVta_Click(object sender, EventArgs e)
        {
            if(name.Text != "")
            {
                Controladora.Venta.Obtener_instancia().SetVentas(dni);
                venta = Modelo.Contexto.Obtener_instancia().Ventas.Max(venta => venta.id_venta);                
                habilitarVentas();
            }
            else
            {
                textprod.Enabled = false;
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            int cantidad = Convert.ToInt32(dataGridDetail.Rows[index].Cells[1].Value);
            id_det = Convert.ToInt32(dataGridDetail.Rows[index].Cells[4].Value);
            int id_prod = Convert.ToInt32(dataGridDetail.Rows[index].Cells[5].Value);
            Controladora.Detalle_venta.Obtener_instancia().deleteDetVta(id_det, cantidad, id_prod);
            dataGridDetail.DataSource = Controladora.Detalle_venta.Obtener_instancia().getDetalleVta(venta);
            Eliminar.Enabled = false;
        }
        private void dataGridDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if(index != -1)
            {
                Eliminar.Enabled = true;
            }
            else
            {
                Eliminar.Enabled = false;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Controladora.Venta.Obtener_instancia().deleteVta(venta);
            MessageBox.Show("Venta cancelada");
            this.Close();
        }
    }
}
