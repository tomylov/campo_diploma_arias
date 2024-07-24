using System;
using System.Linq;
using System.Windows.Forms;

namespace Vista
{
    public partial class Ventas : Form
    {
        Controladora.Venta cVenta = Controladora.Venta.Obtener_instancia();
        Controladora.Detalle_venta cDetVta = Controladora.Detalle_venta.Obtener_instancia();
        Modelo.Detalle_ventas detalle_Ventas = new Modelo.Detalle_ventas();
        Controladora.Cliente cCliente = Controladora.Cliente.Obtener_instancia();
        Controladora.Producto cProducto = Controladora.Producto.Obtener_instancia();
        Controladora.Comprobante cComprobante = Controladora.Comprobante.Obtener_instancia();
        Modelo.Clientes Cliente = new Modelo.Clientes();
        Modelo.Comprobantes comprobante = new Modelo.Comprobantes();
        Modelo.Ventas ventas = new Modelo.Ventas();
        decimal importe = 0;
        int cantidad, id_venta;
        decimal precio;
        int dni;
        int venta = 0;
        int id_det = 0;
        int index;
        private static Ventas instancia;

        public static Ventas Obtener_instancia(int id_vta, int dni)
        {
            if (instancia == null)
                instancia = new Ventas(id_vta, dni);

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
            this.id_venta = id_venta;
            if (id_venta != 0) //si es distinto de 0 es porque se esta editando una venta
            {
                habilitarVentas();
                Cliente = cCliente.GetCliente(dni).FirstOrDefault();
                name.Text = Cliente.nombre;
                mail.Text = Cliente.email;
                dniPK.Text = dni.ToString();
                venta = id_venta;
                var datos = cDetVta.getDetalleVta(venta);
                dataGridDetail.DataSource = datos;
                if(datos.Count > 0)
                {
                    foreach (var item in datos)
                    {
                        importe += (decimal)item.GetType().GetProperty("Subtotal").GetValue(item, null);
                    }
                    Total.Text = importe.ToString();
                }
                dataGridDetail.Columns[4].Visible = false;
            }
        }

        private void addProduct_Click_1(object sender, EventArgs e)
        {
            cantidad = 0;
            precio = 0;
            if (textprod.Text != "" && cuantity.Value <= Convert.ToInt32(stock.Text))
            {
                cantidad = Convert.ToInt32(cuantity.Text);
                TotalItems.Text = (Convert.ToInt32(TotalItems.Text) + cantidad).ToString();
                precio = Convert.ToDecimal(price.Text);
                importe += (precio * cantidad);
                Total.Text = importe.ToString();
                detalle_Ventas.cantidad = Convert.ToInt32(cuantity.Value);
                detalle_Ventas.precio = Convert.ToDecimal(price.Text);
                detalle_Ventas.id_prod = Convert.ToInt32(textprod.Text);
                detalle_Ventas.id_venta = venta;
                cDetVta.AgregarDetalleVenta(detalle_Ventas);
                cDetVta.updateStock(detalle_Ventas.id_prod, -detalle_Ventas.cantidad);
                var datos = Controladora.Detalle_venta.Obtener_instancia().getDetalleVta(venta);
                dataGridDetail.DataSource = null;
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
            if (Total.Text != "")
            {
                comprobante.id_tipo = 1;
                comprobante.numero = venta;
                cComprobante.AgregarComprobante(comprobante);

            
                ventas.id_venta = venta;
                ventas.id_comp = Modelo.Contexto.Obtener_instancia().Comprobantes.Max(c => c.id_comp);
                ventas.id_cliente = Cliente.id_cliente;
                ventas.fecha = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                ventas.id_estado = 2;
                ventas.total = Convert.ToDecimal(Total.Text);
                cVenta.modificarVenta(ventas);                
            }
            MessageBox.Show("Venta guardada con exito");
            Vista.Gestionar_ventas.Obtener_instancia().filtrar();
            this.Close();
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
                    Modelo.Productos datos = cProducto.getProductoId(Convert.ToInt32(textprod.Text));
                    if (datos != null)
                    {
                        description.Text = datos.nombre;
                        price.Text = datos.precio.ToString();
                        stock.Text = datos.stock.ToString();
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
                    Cliente = Controladora.Cliente.Obtener_instancia().GetCliente(dni).FirstOrDefault();
                    if (Cliente != null)
                    {
                        name.Text = Cliente.nombre;
                        mail.Text = Cliente.email;
                    }
                    else
                    {
                        MessageBox.Show("no se encontro el cliente");
                        name.Text = "";
                        mail.Text = "";
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
            if (name.Text != "")
            {
                ventas.id_cliente = Cliente.id_cliente;
                ventas.id_estado = 1;
                cVenta.agregarVenta(ventas);
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
            detalle_Ventas.cantidad = Convert.ToInt32(dataGridDetail.Rows[index].Cells[1].Value);
            detalle_Ventas.id_detalle = Convert.ToInt32(dataGridDetail.Rows[index].Cells[4].Value);
            detalle_Ventas.id_prod = Convert.ToInt32(dataGridDetail.Rows[index].Cells[5].Value);
            cDetVta.deleteDetVta(detalle_Ventas);
            TotalItems.Text = (Convert.ToInt32(TotalItems.Text) - cantidad).ToString();
            dataGridDetail.Columns[4].Visible = false;
            MessageBox.Show(importe.ToString());
            importe -= (Convert.ToDecimal(dataGridDetail.Rows[index].Cells[3].Value));
            MessageBox.Show(importe.ToString());
            Total.Text = importe.ToString();
            dataGridDetail.DataSource = Controladora.Detalle_venta.Obtener_instancia().getDetalleVta(venta);
            Eliminar.Enabled = false;
        }
        private void dataGridDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index != -1)
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
            cVenta.deleteVta(venta);
            MessageBox.Show("Venta cancelada");
            Vista.Gestionar_ventas.Obtener_instancia().filtrar();
            this.Close();
        }
    }
}
