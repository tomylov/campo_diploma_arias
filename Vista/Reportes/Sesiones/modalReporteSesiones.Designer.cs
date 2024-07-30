namespace Vista.Reportes
{
    partial class modalReporteSesiones
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
            this.chartSesiones = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonExportar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartSesiones)).BeginInit();
            this.SuspendLayout();
            // 
            // chartSesiones
            // 
            chartArea1.Name = "ChartArea1";
            this.chartSesiones.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartSesiones.Legends.Add(legend1);
            this.chartSesiones.Location = new System.Drawing.Point(56, 35);
            this.chartSesiones.Name = "chartSesiones";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartSesiones.Series.Add(series1);
            this.chartSesiones.Size = new System.Drawing.Size(968, 465);
            this.chartSesiones.TabIndex = 0;
            this.chartSesiones.Text = "chart1";
            this.chartSesiones.PostPaint += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ChartPaintEventArgs>(this.chartSesiones_PostPaint);
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
            // modalReporteSesiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(1069, 579);
            this.Controls.Add(this.buttonExportar);
            this.Controls.Add(this.chartSesiones);
            this.MaximizeBox = false;
            this.Name = "modalReporteSesiones";
            this.Text = "modalReporteSesiones";
            ((System.ComponentModel.ISupportInitialize)(this.chartSesiones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartSesiones;
        private System.Windows.Forms.Button buttonExportar;
    }
}