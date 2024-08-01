using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Vista.Reportes
{
    public partial class ReporteSesiones : Form
    {
        Controladora.Auditoria.SesionesUsuario cAuditoriaUsuario = Controladora.Auditoria.SesionesUsuario.Obtener_instancia();
        List<Modelo.SesionUsuario> sesionesUsuario;
        List<Modelo.UsuarioReporte> usuarioReportes;
        DateTime fechaDesde;
        DateTime fechaHasta;
        int id_grupo;

        private static ReporteSesiones instancia;
        public static ReporteSesiones Obtener_instancia()
        {
            if (instancia == null)
                instancia = new ReporteSesiones();
            if (instancia.IsDisposed)
                instancia = new ReporteSesiones();

            instancia.BringToFront();
            return instancia;
        }
        private ReporteSesiones()
        {
            InitializeComponent();
            dataAuditoriaUsuario.DataSource = null;
            drpGrupos.DataSource = Controladora.Seguridad.Grupo.Obtener_instancia().getGrupos().Where(g => g.estado ==true).ToList();
            drpGrupos.SelectedIndex = 0;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            fechaDesde = dtpfechainicio.Value;
            fechaHasta = dtpfechafin.Value;
            id_grupo = Convert.ToInt32(drpGrupos.SelectedValue);
            usuarioReportes = cAuditoriaUsuario.GetReporteUsuarios(id_grupo, fechaDesde, fechaHasta);
            dataAuditoriaUsuario.DataSource = usuarioReportes;

        }

        private void buttonExportar_Click(object sender, EventArgs e)
        {
            if (dataAuditoriaUsuario.ColumnCount > 1)
            {
                Form form = Vista.Reportes.modalReporteSesiones.Obtener_instancia(id_grupo, fechaDesde, fechaHasta);
                form.ShowDialog();
            }
        }

        private void buttonExcel_Click(object sender, EventArgs e)
        {
            if (dataAuditoriaUsuario.ColumnCount > 1)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Guardar reporte como Excel";
                saveFileDialog.FileName = "reporte_sesiones de " + fechaDesde.ToString("dd-MM-yyyy") + " a " + fechaHasta.ToString("dd-MM-yyyy") + ".xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Reporte sesiones");

                        // Título del reporte
                        worksheet.Cell(1, 1).Value = "Reporte sesiones";
                        worksheet.Range(1, 1, 1, 3).Merge().AddToNamed("Titles");
                        var titlesStyle = workbook.Style;
                        titlesStyle.Font.Bold = true;
                        titlesStyle.Font.FontSize = 16;
                        titlesStyle.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        worksheet.Cell(1, 1).Style = titlesStyle;

                        // Fechas del reporte
                        worksheet.Cell(2, 1).Value = $"Fecha desde: {fechaDesde.ToShortDateString()}";
                        worksheet.Cell(2, 2).Value = $"Fecha hasta: {fechaHasta.ToShortDateString()}";
                        var dateStyle = workbook.Style;
                        dateStyle.Font.FontSize = 12;
                        worksheet.Cell(2, 1).Style = dateStyle;
                        worksheet.Cell(2, 2).Style = dateStyle;

                        // Encabezados de la tabla
                        worksheet.Cell(4, 1).Value = "Usuario";
                        worksheet.Cell(4, 2).Value = "Total horas trabajadas";
                        var headerStyle = workbook.Style;
                        headerStyle.Font.Bold = true;
                        headerStyle.Fill.BackgroundColor = XLColor.LightGray;
                        worksheet.Cell(4, 1).Style = headerStyle;
                        worksheet.Cell(4, 2).Style = headerStyle;

                        // Datos de la tabla
                        int row = 5;
                        foreach (var dato in usuarioReportes)
                        {
                            worksheet.Cell(row, 1).Value = dato.Usuario;
                            worksheet.Cell(row, 2).Value = dato.TotalHorasTrabajadas;
                            row++;
                        }

                        // Ajustar el ancho de las columnas
                        worksheet.Columns().AdjustToContents();

                        // Guardar el archivo Excel
                        using (var stream = new MemoryStream())
                        {
                            workbook.SaveAs(stream);
                            File.WriteAllBytes(saveFileDialog.FileName, stream.ToArray());
                        }

                        MessageBox.Show("Reporte exportado con éxito!", "Exportar Reporte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

        }
    }
}
