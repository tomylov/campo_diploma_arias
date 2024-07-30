using ClosedXML.Excel;
using Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Vista.Reportes
{
    public partial class ReportePago : Form
    {
        Controladora.Auditoria.Pagos cPagos = Controladora.Auditoria.Pagos.Obtener_instancia();
        List<Modelo.ReportePagoDTO> pagos = new List<Modelo.ReportePagoDTO>();
        DateTime fechaDesde;
        DateTime fechaHasta;
        decimal total;

        public static ReportePago instancia;
        public static ReportePago Obtener_instancia()
        {
            if (instancia == null)
                instancia = new ReportePago();
            if (instancia.IsDisposed)
                instancia = new ReportePago();

            instancia.BringToFront();
            return instancia;
        }
        public ReportePago()
        {
            InitializeComponent();
            dataAuditoriaUsuario.DataSource = null;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            fechaDesde = dtpfechainicio.Value;
            fechaHasta = dtpfechafin.Value;
            pagos = cPagos.GetPagos(fechaDesde, fechaHasta);
            dataAuditoriaUsuario.DataSource = pagos;
            total = pagos.Sum(p => p.Total).Value;
        }

        private void buttonExportar_Click(object sender, EventArgs e)
        {
            if (dataAuditoriaUsuario.ColumnCount > 1)
            {
                Form form = Vista.Reportes.modalReportePagos.Obtener_instancia(fechaDesde,fechaHasta,total);
                form.Show();
            }
        }

        private void buttonExcel_Click(object sender, EventArgs e)
        {
            if (dataAuditoriaUsuario.ColumnCount > 1)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    Title = "Guardar reporte como Excel",
                    FileName = $"reporte_pagos_de_{fechaDesde:dd-MM-yyyy}_a_{fechaHasta:dd-MM-yyyy}.xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Reporte Pagos");

                        // Título del reporte
                        worksheet.Cell(1, 1).Value = "Reporte de Pagos";
                        worksheet.Range(1, 1, 1, 3).Merge().Style
                            .Font.SetBold(true)
                            .Font.SetFontSize(16)
                            .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        // Fechas del reporte
                        worksheet.Cell(2, 1).Value = $"Fecha desde: {fechaDesde:dd/MM/yyyy}";
                        worksheet.Cell(2, 2).Value = $"Fecha hasta: {fechaHasta:dd/MM/yyyy}";
                        worksheet.Range(2, 1, 2, 2).Style
                            .Font.SetFontSize(12);

                        // Encabezados de la tabla
                        worksheet.Cell(4, 1).Value = "Descripción del Medio de Pago";
                        worksheet.Cell(4, 2).Value = "Total Monto";
                        worksheet.Range(4, 1, 4, 2).Style
                            .Font.SetBold(true)
                            .Fill.SetBackgroundColor(XLColor.LightGray);

                        // Datos de la tabla
                        int row = 5;
                        foreach (var pago in pagos)
                        {
                            worksheet.Cell(row, 1).Value = pago.Medio_de_pago;
                            worksheet.Cell(row, 2).Value = pago.Total;
                            row++;
                        }

                        // Calcular el total y agregarlo al final
                        worksheet.Cell(row, 1).Value = "Total";
                        worksheet.Cell(row, 2).Value = total;
                        worksheet.Range(row, 1, row, 2).Style
                            .Font.SetBold(true)
                            .Fill.SetBackgroundColor(XLColor.LightYellow);

                        // Ajustar el ancho de las columnas
                        worksheet.Columns().AdjustToContents();

                        // Guardar el archivo Excel
                        using (var stream = new MemoryStream())
                        {
                            workbook.SaveAs(stream);
                            File.WriteAllBytes(saveFileDialog.FileName, stream.ToArray());
                        }

                        MessageBox.Show("Reporte de pagos exportado con éxito!", "Exportar Reporte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
        }
    }
}
