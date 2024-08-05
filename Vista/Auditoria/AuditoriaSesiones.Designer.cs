namespace Vista
{
    partial class AuditoriaSesiones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bunifuGroupBox1 = new Bunifu.UI.WinForms.BunifuGroupBox();
            this.textBoxUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpfechafin = new System.Windows.Forms.DateTimePicker();
            this.dtpfechainicio = new System.Windows.Forms.DateTimePicker();
            this.bunifuGroupBox2 = new Bunifu.UI.WinForms.BunifuGroupBox();
            this.buttonExcel = new System.Windows.Forms.Button();
            this.dataAuditoriaUsuario = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.bunifuGroupBox1.SuspendLayout();
            this.bunifuGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataAuditoriaUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuGroupBox1
            // 
            this.bunifuGroupBox1.BorderColor = System.Drawing.Color.LightGray;
            this.bunifuGroupBox1.BorderRadius = 1;
            this.bunifuGroupBox1.BorderThickness = 1;
            this.bunifuGroupBox1.Controls.Add(this.textBoxUsuario);
            this.bunifuGroupBox1.Controls.Add(this.label1);
            this.bunifuGroupBox1.Controls.Add(this.btnLimpiar);
            this.bunifuGroupBox1.Controls.Add(this.label3);
            this.bunifuGroupBox1.Controls.Add(this.label2);
            this.bunifuGroupBox1.Controls.Add(this.dtpfechafin);
            this.bunifuGroupBox1.Controls.Add(this.dtpfechainicio);
            this.bunifuGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuGroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuGroupBox1.LabelAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bunifuGroupBox1.LabelIndent = 10;
            this.bunifuGroupBox1.LineStyle = Bunifu.UI.WinForms.BunifuGroupBox.LineStyles.Solid;
            this.bunifuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.bunifuGroupBox1.Name = "bunifuGroupBox1";
            this.bunifuGroupBox1.Size = new System.Drawing.Size(947, 109);
            this.bunifuGroupBox1.TabIndex = 0;
            this.bunifuGroupBox1.TabStop = false;
            this.bunifuGroupBox1.Text = "Filtros";
            // 
            // textBoxUsuario
            // 
            this.textBoxUsuario.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxUsuario.Location = new System.Drawing.Point(377, 22);
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.Size = new System.Drawing.Size(237, 29);
            this.textBoxUsuario.TabIndex = 57;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(302, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 21);
            this.label1.TabIndex = 56;
            this.label1.Text = "Usuario:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.White;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.btnLimpiar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.Black;
            this.btnLimpiar.Location = new System.Drawing.Point(693, 37);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(52, 40);
            this.btnLimpiar.TabIndex = 36;
            this.btnLimpiar.Text = "🔎";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(462, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 21);
            this.label3.TabIndex = 35;
            this.label3.Text = "Fecha final:*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(197, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 21);
            this.label2.TabIndex = 34;
            this.label2.Text = "Fecha inicial:*";
            // 
            // dtpfechafin
            // 
            this.dtpfechafin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpfechafin.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfechafin.CustomFormat = "dd/MM/yyyy";
            this.dtpfechafin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfechafin.Location = new System.Drawing.Point(561, 60);
            this.dtpfechafin.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.dtpfechafin.Name = "dtpfechafin";
            this.dtpfechafin.Size = new System.Drawing.Size(107, 23);
            this.dtpfechafin.TabIndex = 33;
            // 
            // dtpfechainicio
            // 
            this.dtpfechainicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpfechainicio.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfechainicio.CustomFormat = "dd/MM/yyyy";
            this.dtpfechainicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfechainicio.Location = new System.Drawing.Point(306, 60);
            this.dtpfechainicio.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.dtpfechainicio.Name = "dtpfechainicio";
            this.dtpfechainicio.Size = new System.Drawing.Size(115, 23);
            this.dtpfechainicio.TabIndex = 32;
            // 
            // bunifuGroupBox2
            // 
            this.bunifuGroupBox2.BorderColor = System.Drawing.Color.LightGray;
            this.bunifuGroupBox2.BorderRadius = 1;
            this.bunifuGroupBox2.BorderThickness = 1;
            this.bunifuGroupBox2.Controls.Add(this.buttonExcel);
            this.bunifuGroupBox2.Controls.Add(this.dataAuditoriaUsuario);
            this.bunifuGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuGroupBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuGroupBox2.LabelAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bunifuGroupBox2.LabelIndent = 10;
            this.bunifuGroupBox2.LineStyle = Bunifu.UI.WinForms.BunifuGroupBox.LineStyles.Solid;
            this.bunifuGroupBox2.Location = new System.Drawing.Point(0, 109);
            this.bunifuGroupBox2.Name = "bunifuGroupBox2";
            this.bunifuGroupBox2.Size = new System.Drawing.Size(947, 472);
            this.bunifuGroupBox2.TabIndex = 1;
            this.bunifuGroupBox2.TabStop = false;
            this.bunifuGroupBox2.Text = "Datos usuarios";
            // 
            // buttonExcel
            // 
            this.buttonExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonExcel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.buttonExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExcel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.buttonExcel.ForeColor = System.Drawing.Color.White;
            this.buttonExcel.Location = new System.Drawing.Point(731, 425);
            this.buttonExcel.Name = "buttonExcel";
            this.buttonExcel.Size = new System.Drawing.Size(170, 35);
            this.buttonExcel.TabIndex = 56;
            this.buttonExcel.Text = "Excel";
            this.buttonExcel.UseVisualStyleBackColor = true;
            this.buttonExcel.Click += new System.EventHandler(this.buttonExcel_Click);
            // 
            // dataAuditoriaUsuario
            // 
            this.dataAuditoriaUsuario.AllowCustomTheming = false;
            this.dataAuditoriaUsuario.AllowUserToAddRows = false;
            this.dataAuditoriaUsuario.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataAuditoriaUsuario.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataAuditoriaUsuario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataAuditoriaUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataAuditoriaUsuario.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataAuditoriaUsuario.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataAuditoriaUsuario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataAuditoriaUsuario.ColumnHeadersHeight = 40;
            this.dataAuditoriaUsuario.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.dataAuditoriaUsuario.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dataAuditoriaUsuario.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dataAuditoriaUsuario.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dataAuditoriaUsuario.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataAuditoriaUsuario.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.dataAuditoriaUsuario.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dataAuditoriaUsuario.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.dataAuditoriaUsuario.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dataAuditoriaUsuario.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataAuditoriaUsuario.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.dataAuditoriaUsuario.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dataAuditoriaUsuario.CurrentTheme.Name = null;
            this.dataAuditoriaUsuario.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataAuditoriaUsuario.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dataAuditoriaUsuario.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dataAuditoriaUsuario.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dataAuditoriaUsuario.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataAuditoriaUsuario.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataAuditoriaUsuario.EnableHeadersVisualStyles = false;
            this.dataAuditoriaUsuario.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dataAuditoriaUsuario.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.dataAuditoriaUsuario.HeaderBgColor = System.Drawing.Color.Empty;
            this.dataAuditoriaUsuario.HeaderForeColor = System.Drawing.Color.White;
            this.dataAuditoriaUsuario.Location = new System.Drawing.Point(33, 22);
            this.dataAuditoriaUsuario.Name = "dataAuditoriaUsuario";
            this.dataAuditoriaUsuario.ReadOnly = true;
            this.dataAuditoriaUsuario.RowHeadersVisible = false;
            this.dataAuditoriaUsuario.RowTemplate.Height = 40;
            this.dataAuditoriaUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataAuditoriaUsuario.Size = new System.Drawing.Size(868, 385);
            this.dataAuditoriaUsuario.TabIndex = 0;
            this.dataAuditoriaUsuario.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // AuditoriaSesiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(947, 581);
            this.Controls.Add(this.bunifuGroupBox2);
            this.Controls.Add(this.bunifuGroupBox1);
            this.ForeColor = System.Drawing.Color.White;
            this.MaximizeBox = false;
            this.Name = "AuditoriaSesiones";
            this.Text = "ReporteSesiones";
            this.bunifuGroupBox1.ResumeLayout(false);
            this.bunifuGroupBox1.PerformLayout();
            this.bunifuGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataAuditoriaUsuario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuGroupBox bunifuGroupBox1;
        private Bunifu.UI.WinForms.BunifuGroupBox bunifuGroupBox2;
        private Bunifu.UI.WinForms.BunifuDataGridView dataAuditoriaUsuario;
        private System.Windows.Forms.DateTimePicker dtpfechafin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpfechainicio;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button buttonExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxUsuario;
    }
}