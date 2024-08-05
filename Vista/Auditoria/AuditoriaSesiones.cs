using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Vista
{
    public partial class AuditoriaSesiones : Form
    {
        Controladora.Auditoria.SesionesUsuario cAuditoriaUsuario = Controladora.Auditoria.SesionesUsuario.Obtener_instancia();
        List<Modelo.SesionUsuario> sesionesUsuario;
        DateTime fechaDesde;
        DateTime fechaHasta;
        string usuario;

        private static AuditoriaSesiones instancia;
        public static AuditoriaSesiones Obtener_instancia()
        {
            if (instancia == null)
                instancia = new AuditoriaSesiones();
            if (instancia.IsDisposed)
                instancia = new AuditoriaSesiones();

            instancia.BringToFront();
            return instancia;
        }
        private AuditoriaSesiones()
        {
            InitializeComponent();
            dataAuditoriaUsuario.DataSource = null;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            fechaDesde = dtpfechainicio.Value;
            fechaHasta = dtpfechafin.Value;
            usuario = textBoxUsuario.Text;
            sesionesUsuario = cAuditoriaUsuario.GetSesionesUsuario(usuario, fechaDesde, fechaHasta);
            dataAuditoriaUsuario.DataSource = sesionesUsuario;
            dataAuditoriaUsuario.Columns[1].Visible = false;

        }
        private void buttonExcel_Click(object sender, EventArgs e)
        {
            if (dataAuditoriaUsuario.ColumnCount > 1)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Guardar Auditoria como Excel";
                saveFileDialog.FileName = "auditoria_sesiones "+textBoxUsuario.Text+" de " + fechaDesde.ToString("dd-MM-yyyy") + " a " + fechaHasta.ToString("dd-MM-yyyy") + ".xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Reporte sesiones");

                        // Título de la Auditoria
                        worksheet.Cell(1, 1).Value = "Auditoria sesiones";
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
                        worksheet.Cell(4, 1).Value = "id_sesion";
                        worksheet.Cell(4, 2).Value = "Usuario";
                        worksheet.Cell(4, 3).Value = "FechaInicio";
                        worksheet.Cell(4, 4).Value = "FechaFin";
                        worksheet.Cell(4, 5).Value = "Duracion";
                        var headerStyle = workbook.Style;
                        headerStyle.Font.Bold = true;
                        headerStyle.Fill.BackgroundColor = XLColor.LightGray;
                        headerStyle.Fill.BackgroundColor = XLColor.LightGray;
                        headerStyle.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        worksheet.Cell(4, 1).Style = headerStyle;
                        worksheet.Cell(4, 2).Style = headerStyle;
                        worksheet.Cell(4, 3).Style = headerStyle;
                        worksheet.Cell(4, 4).Style = headerStyle;
                        worksheet.Cell(4, 5).Style = headerStyle;

                        // Datos de la tabla
                        int row = 5;
                        foreach (var dato in sesionesUsuario)
                        {
                            worksheet.Cell(row, 1).Value = dato.id_sesion;
                            worksheet.Cell(row, 2).Value = dato.usuario;
                            worksheet.Cell(row, 3).Value = dato.FechaInicio;
                            worksheet.Cell(row, 4).Value = dato.FechaFin;
                            worksheet.Cell(row, 5).Value = dato.Duracion;
                            row++;
                        }

                        // Ajustar el ancho de las columnas
                        worksheet.Column(1).Width = 25;
                        worksheet.Column(2).Width = 25;
                        worksheet.Column(3).Width = 18;
                        worksheet.Column(4).Width = 18;
                        worksheet.Column(5).Width = 20;

                        // Guardar el archivo Excel
                        using (var stream = new MemoryStream())
                        {
                            workbook.SaveAs(stream);
                            File.WriteAllBytes(saveFileDialog.FileName, stream.ToArray());
                        }

                        MessageBox.Show("Auditoria exportado con éxito!", "Exportar auditoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

        }
    }
}
