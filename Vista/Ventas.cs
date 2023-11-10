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
    public partial class Ventas : Form
    {
        decimal importe;
        int cantidad;
        decimal precio;
        public Ventas()
        {
            InitializeComponent();
        }

        private void addProduct_Click_1(object sender, EventArgs e)
        {            
            importe = 0;
            cantidad = 0;
            precio = 0;
            if (textprod.Text != "")
            {
                cantidad = Convert.ToInt32(cuantity.Text);
                precio = Convert.ToDecimal(price.Text);
                importe = precio * cantidad;
                dataGridDetail.Rows.Add(textprod.Text, description.Text, price.Text, cuantity.Text, importe);
                Controladora.Detalle_venta.Obtener_instancia().createdetalleVeta(1,Convert.ToInt32(textprod.Text),cantidad,precio);
                textprod.Text = "";
                description.Text = "";
                price.Text = "";
                cuantity.Value = 0;
                stock.Text = "";
            }

        }

        private void btnFinish_Click(object sender, EventArgs e)
        {

        }

        private void searchProd_Click(object sender, EventArgs e)
        {

        }

        private void textprod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
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
                    }
                    else
                    {
                        description.Text = "";
                        price.Text = "";
                        cuantity.Value = 0;
                        stock.Text = "";
                    }
                }
                catch
                {
                    MessageBox.Show("Producto no encontrado");
                }
            }
        }

    }
}
