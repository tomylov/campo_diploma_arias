namespace Vista.Reportes
{
    partial class modalReportePagos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartPagos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonExportar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartPagos)).BeginInit();
            this.SuspendLayout();
            // 
            // chartPagos
            // 
            chartArea1.Name = "ChartArea1";
            this.chartPagos.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartPagos.Legends.Add(legend1);
            this.chartPagos.Location = new System.Drawing.Point(56, 35);
            this.chartPagos.Name = "chartPagos";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartPagos.Series.Add(series1);
            this.chartPagos.Size = new System.Drawing.Size(968, 465);
            this.chartPagos.TabIndex = 0;
            this.chartPagos.Text = "chart1";
            this.chartPagos.PostPaint += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ChartPaintEventArgs>(this.chartSesiones_PostPaint);
            // 
            // buttonExportar
            // 
            this.buttonExportar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonExportar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.buttonExportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExportar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.buttonExportar.ForeColor = System.Drawing.Color.White;
            this.buttonExportar.Location = new System.Drawing.Point(854, 532);
            this.buttonExportar.Name = "buttonExportar";
            this.buttonExportar.Size = new System.Drawing.Size(170, 35);
            this.buttonExportar.TabIndex = 56;
            this.buttonExportar.Text = "Exportar pdf";
            this.buttonExportar.UseVisualStyleBackColor = true;
            this.buttonExportar.Click += new System.EventHandler(this.buttonExportar_Click);
            // 
            // modalReportePagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(1069, 579);
            this.Controls.Add(this.buttonExportar);
            this.Controls.Add(this.chartPagos);
            this.Name = "modalReportePagos";
            this.Text = "modalReportePagos";
            ((System.ComponentModel.ISupportInitialize)(this.chartPagos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartPagos;
        private System.Windows.Forms.Button buttonExportar;
    }
}