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
using Modelo;

namespace Vista
{
    public partial class consultar_pagos : Form
    {
        private Modelo.Ventas venta = new Modelo.Ventas();
        private Modelo.Clientes cliente = new Modelo.Clientes();
        private Modelo.Pagos pago = new Modelo.Pagos();
        private static consultar_pagos instancia;
        private static Controladora.Pago cPagos = Controladora.Pago.Obtener_instancia();
        private static Controladora.Venta cVenta = Controladora.Venta.Obtener_instancia();
        private static Controladora.Cliente cCliente = Controladora.Cliente.Obtener_instancia();
        public static consultar_pagos Obtener_instancia(int id_pago)
        {
            if (instancia == null)
                instancia = new consultar_pagos(id_pago);

            if (instancia.IsDisposed)
                instancia = new consultar_pagos(id_pago);

            instancia.BringToFront();
            return instancia;
        }
        private consultar_pagos(int id_pago)
        {
            InitializeComponent();
            pago = cPagos.getPagoId(id_pago);
            venta  = pago.Ventas;
            cliente = venta.Clientes;

            txtnombrecliente.Text = cliente.nombre;
            txtfecha.Text = pago.fecha.ToString();
            txtidvta.Text = pago.numero.ToString();
            if (venta.id_estado == 3)
            {
                txtestadopago.Text = "Pago cuenta corriente";                
            }
            if (venta.id_estado == 4)
            {
                txtestadopago.Text = "Pago venta";
            }
            if (venta.id_estado == 5)
            {
                txtestadopago.Text = "Pago venta en cuenta corriente";
            }
            txtdoccliente.Text = cliente.dni.ToString();
            Total.Text = pago.monto.ToString();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            string textoHtml = Properties.Resources.PlantillaRecibo.ToString();
            textoHtml = textoHtml.Replace("@numerocomprobante", pago.numero.ToString());
            textoHtml = textoHtml.Replace("@nombrecliente", cliente.nombre);
            textoHtml = textoHtml.Replace("@telefonocliente", cliente.telefono);
            textoHtml = textoHtml.Replace("@dni", cliente.dni.ToString());
            textoHtml = textoHtml.Replace("@direccion", cliente.email);

            textoHtml = textoHtml.Replace("@tipoPago", txtestadopago.Text);
            textoHtml = textoHtml.Replace("@fechapago", pago.fecha.Value.ToString("G"));
            textoHtml = textoHtml.Replace("@montototal", pago.monto.ToString());

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("pago_{0}.pdf", pago.numero.ToString());
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

                    using (StringReader sr = new StringReader(textoHtml))
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
