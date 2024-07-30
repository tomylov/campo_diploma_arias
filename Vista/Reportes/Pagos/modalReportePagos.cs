using Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Vista.Reportes
{
    public partial class modalReportePagos : Form
    {
        private static modalReportePagos instancia;
        DateTime dateIni;
        DateTime dateFin;
        decimal total;
        Controladora.Auditoria.Pagos cPagos = Controladora.Auditoria.Pagos.Obtener_instancia();
        List<Modelo.ReportePagoDTO> pagos = new List<Modelo.ReportePagoDTO>();

        public static modalReportePagos Obtener_instancia(DateTime dateIni, DateTime dateFin, decimal total)
        {
            if (instancia == null)
                instancia = new modalReportePagos(dateIni, dateFin,total);
            if (instancia.IsDisposed)
                instancia = new modalReportePagos(dateIni, dateFin, total);

            instancia.BringToFront();
            return instancia;
        }
        public modalReportePagos(DateTime dateIni, DateTime dateFin, decimal total)
        {
            InitializeComponent();
            this.dateIni = dateIni;
            this.dateFin = dateFin;
            this.total = total;

            pagos = cPagos.GetPagos(dateIni, dateFin);
            chartPagos.Series.Clear();
            var series = new Series("Total ($)")
            {
                ChartType = SeriesChartType.Column
            };
            chartPagos.Series.Add(series);

            foreach (var pago in pagos)
            {
                series.Points.AddXY(pago.Medio_de_pago, pago.Total);
                series.Color = System.Drawing.Color.DarkGreen;
            }
            // Configuración opcional de ejes
            chartPagos.ChartAreas[0].AxisX.Title = "Medio de pago";
            chartPagos.ChartAreas[0].AxisY.Title = "Total ($)";
            Title chartTitle = new Title
            {
                Text = "Reporte Pagos",
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.Black,
                Docking = Docking.Top
            };
            chartPagos.Titles.Add(chartTitle);
        }

        private void buttonExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
            saveFileDialog.Title = "Guardar gráfico como imagen";
            saveFileDialog.FileName = "grafico_pagos de "+dateIni.ToString("dd-MM-yyyy") + " a "+dateFin.ToString("dd-MM-yyyy") + ".png";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Guardar la imagen del gráfico en el archivo seleccionado
                ChartImageFormat format = ChartImageFormat.Png;
                switch (saveFileDialog.FilterIndex)
                {
                    case 1:
                        format = ChartImageFormat.Png;
                        break;
                    case 2:
                        format = ChartImageFormat.Jpeg;
                        break;
                    case 3:
                        format = ChartImageFormat.Bmp;
                        break;
                }
                chartPagos.SaveImage(saveFileDialog.FileName, format);
                MessageBox.Show("Gráfico exportado con éxito!", "Exportar Gráfico", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void chartSesiones_PostPaint(object sender, ChartPaintEventArgs e)
        {
            if (e.ChartElement is ChartArea)
            {
                var chartArea = e.Chart.ChartAreas[0];
                var graphics = e.ChartGraphics.Graphics;
                var font = new Font("Arial", 10);

                // Texto de las fechas a la izquierda
                string textoFechas = $"Fecha desde: {dateIni.ToShortDateString()}\nFecha hasta: {dateFin.ToShortDateString()}";
                SizeF textoFechasSize = graphics.MeasureString(textoFechas, font);

                float xFechas = chartArea.Position.X; // Posición izquierda (margen izquierdo del área del gráfico)
                float yFechas = e.Chart.Height - textoFechasSize.Height - 10; // Ajustar la posición vertical

                graphics.DrawString(textoFechas, font, Brushes.Black, xFechas, yFechas);

                // Texto del total a la derecha
                font = new Font("Arial", 15);
                string textoTotal = "Total: $"+ total.ToString();
                SizeF textoTotalSize = graphics.MeasureString(textoTotal, font);

                float xTotal = (e.Chart.Width - textoTotalSize.Width) - 15; // Posición derecha (margen derecho del área del gráfico)
                float yTotal = yFechas; // Mismo ajuste vertical que las fechas

                graphics.DrawString(textoTotal, font, Brushes.Black, xTotal, yTotal);
            }

        }
    }
}
