using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controladora;
using System.Net;

namespace Vista
{
    public partial class Consultar_venta : Form
    {
        private Modelo.Ventas venta = new Modelo.Ventas();
        private Modelo.Clientes cliente = new Modelo.Clientes();
        private static Consultar_venta instancia;
        public static Consultar_venta Obtener_instancia(int id_vta, int dni)
        {
            if (instancia == null)
                instancia = new Consultar_venta(id_vta, dni);

            if (instancia.IsDisposed)
                instancia = new Consultar_venta(id_vta, dni);

            instancia.BringToFront();
            return instancia;
        }
        private Consultar_venta(int id_vta, int dni)
        {
            InitializeComponent();
            cliente = Controladora.Cliente.Obtener_instancia().GetCliente(dni).FirstOrDefault();
            venta = Controladora.Venta.Obtener_instancia().getVentaId(id_vta);

            txtnombrecliente.Text = cliente.nombre;
            txtfecha.Text = venta.fecha.ToString();
            txtidvta.Text = venta.id_venta.ToString();
            //mail.Text = Convert.ToString(datosCli[0].GetType().GetProperty("email").GetValue(datosCli[0], null));
            if (venta.id_estado == 2)
            {
                txtestadovta.Text = "Venta pendiente a retirar";                
            }
            if (venta.id_estado == 3)
            {
                txtestadovta.Text = "Venta en cuenta corriente";
            }
            txtdoccliente.Text = cliente.dni.ToString();
            System.Collections.IList datos = Controladora.Detalle_venta.Obtener_instancia().getDetalleVta(id_vta);
            dataGridDetail.DataSource = datos;
            dataGridDetail.Columns[4].Visible = false;
            dataGridDetail.Columns[5].Visible = false;
            Total.Text = venta.total.ToString();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            string Texto_Html = Properties.Resources.PlantillaVenta.ToString();
            Texto_Html = Texto_Html.Replace("@numerodocumento", txtidvta.Text);


            Texto_Html = Texto_Html.Replace("@doccliente", txtdoccliente.Text);
            Texto_Html = Texto_Html.Replace("@nombrecliente", txtnombrecliente.Text);
            Texto_Html = Texto_Html.Replace("@fecharegistro", txtfecha.Text);
            Texto_Html = Texto_Html.Replace("@usuarioregistro", txtestadovta.Text);

            string filas = string.Empty;

            foreach (DataGridViewRow row in dataGridDetail.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells[0].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells[2].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells[1].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells[3].Value.ToString() + "</td>";
                filas += "</tr>";
            }
            Texto_Html = Texto_Html.Replace("@filas", filas);
            Texto_Html = Texto_Html.Replace("@montototal", Total.Text);
            Texto_Html = Texto_Html.Replace("@pagocon", "--");

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("{1}_numero_{0}.pdf", venta.id_venta.ToString(),txtestadovta.Text);
            savefile.Filter = "Pdf Files|*.pdf";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {

                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    bool obtenido = true;
                    //byte[] byteImage = new CN_Negocio().ObtenerLogo(out obtenido);

                    if (obtenido)
                    {
                        //iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteImage);
                        //img.ScaleToFit(60, 60);
                        //img.Alignment = iTextSharp.text.Image.UNDERLYING;
                        //img.SetAbsolutePosition(pdfDoc.Left, pdfDoc.GetTop(51));
                        //pdfDoc.Add(img);
                    }

                    using (StringReader sr = new StringReader(Texto_Html))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    pdfDoc.Close();
                    stream.Close();
                    MessageBox.Show("Documento Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            this.Close();

        }
    }
}
