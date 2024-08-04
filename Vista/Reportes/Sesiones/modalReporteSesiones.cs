using Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Vista.Reportes
{
    public partial class modalReporteSesiones : Form
    {
        DateTime dateIni;
        DateTime dateFin;
        private static modalReporteSesiones instancia;

        public static modalReporteSesiones Obtener_instancia(int id_grupo, DateTime dateIni, DateTime dateFin)
        {
            if (instancia == null)
                instancia = new modalReporteSesiones(id_grupo, dateIni, dateFin);
            if (instancia.IsDisposed)
                instancia = new modalReporteSesiones(id_grupo, dateIni, dateFin);

            instancia.BringToFront();
            return instancia;
        }
        private modalReporteSesiones(int id_grupo, DateTime dateIni, DateTime dateFin)
        {
            InitializeComponent();
            this.dateIni = dateIni;
            this.dateFin = dateFin;
            List<UsuarioReporte> datos = Controladora.Auditoria.SesionesUsuario.Obtener_instancia().GetReporteUsuarios(id_grupo, dateIni, dateFin);
            chartSesiones.Series.Clear();
            var series = new Series("Horas trabajadas")
            {
                ChartType = SeriesChartType.Column
            };
            chartSesiones.Series.Add(series);

            foreach (var dato in datos)
            {
                series.Points.AddXY(dato.Usuario, dato.TotalHorasTrabajadas);
            }
            // Configuración opcional de ejes
            chartSesiones.ChartAreas[0].AxisX.Title = "Usuarios";
            chartSesiones.ChartAreas[0].AxisY.Title = "Total horas trabajadas";
            Title chartTitle = new Title
            {
                Text = "Reporte sesiones",
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.Black,
                Docking = Docking.Top
            };
            chartSesiones.Titles.Add(chartTitle);
        }

        private void buttonExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
            saveFileDialog.Title = "Guardar gráfico como imagen";
            saveFileDialog.FileName = "grafico_sesiones de "+dateIni.ToString("dd-MM-yyyy") + " a "+dateFin.ToString("dd-MM-yyyy") + ".png";

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
                chartSesiones.SaveImage(saveFileDialog.FileName, format);
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

                string textoFechas = $"Fecha desde: {dateIni.ToShortDateString()}\nFecha hasta: {dateFin.ToShortDateString()}";
                SizeF textoSize = graphics.MeasureString(textoFechas, font);

                // Calcular la posición para el texto debajo del gráfico
                float x = (e.Chart.Width - textoSize.Width) - 15;
                float y = e.Chart.Height - textoSize.Height - 10; // Ajustar la posición vertical

                graphics.DrawString(textoFechas, font, Brushes.Black, x, y);
            }
        }
    }
}
