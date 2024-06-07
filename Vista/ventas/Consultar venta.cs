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
        private static Consultar_venta instancia;
        public static Consultar_venta Obtener_instancia(int id_vta, int id_usuario)
        {
            if (instancia == null)
                instancia = new Consultar_venta(id_vta, id_usuario);

            if (instancia.IsDisposed)
                instancia = new Consultar_venta(id_vta, id_usuario);

            instancia.BringToFront();
            return instancia;
        }
        public Consultar_venta(int id_vta, int id_usuario)
        {
            InitializeComponent();
            System.Collections.IList datosCli = Controladora.Cliente.Obtener_instancia().GetCliente(id_usuario);
            System.Collections.IList datosVta = Controladora.Venta.Obtener_instancia().ListarVentasId(id_vta);
            txtnombrecliente.Text = Convert.ToString(datosCli[0].GetType().GetProperty("nombre").GetValue(datosCli[0], null));
            txtfecha.Text = Convert.ToString(datosVta[0].GetType().GetProperty("fecha").GetValue(datosVta[0], null));
            txtidvta.Text = Convert.ToString(datosVta[0].GetType().GetProperty("id_venta").GetValue(datosVta[0], null));
            //mail.Text = Convert.ToString(datosCli[0].GetType().GetProperty("email").GetValue(datosCli[0], null));
            txtestadovta.Text = Convert.ToString(datosVta[0].GetType().GetProperty("estado").GetValue(datosVta[0], null));
            txtdoccliente.Text = Convert.ToString(datosCli[0].GetType().GetProperty("id_usuario").GetValue(datosCli[0], null));
            System.Collections.IList datos = Controladora.Detalle_venta.Obtener_instancia().getDetalleVta(id_vta);
            dataGridDetail.DataSource = datos;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            string Texto_Html = Properties.Resources.PlantillaVenta.ToString();
            Texto_Html = Texto_Html.Replace("@numerodocumento", txtidvta.Text);


            Texto_Html = Texto_Html.Replace("@doccliente", txtdoccliente.Text);
            Texto_Html = Texto_Html.Replace("@nombrecliente", txtnombrecliente.Text);
            Texto_Html = Texto_Html.Replace("@fecharegistro", txtfecha.Text);
            Texto_Html = Texto_Html.Replace("@usuarioregistro", txtidvta.Text);

            string filas = string.Empty;

            foreach (DataGridViewRow row in dataGridDetail.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells[0].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells[0].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells[0].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells[0].Value.ToString() + "</td>";
                filas += "</tr>";
            }
            Texto_Html = Texto_Html.Replace("@filas", filas);
            //Texto_Html = Texto_Html.Replace("@montototal", txtmontototal.Text);
            //Texto_Html = Texto_Html.Replace("@pagocon", txtmontopago.Text);
            //Texto_Html = Texto_Html.Replace("@cambio", txtmontocambio.Text);

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("Venta_{0}.pdf", txtestadovta.Text);
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

            }
    }
}
