namespace Vista.Pagos
{
    partial class pagar_cc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pagar_cc));
            this.bunifuGroupBox1 = new Bunifu.UI.WinForms.BunifuGroupBox();
            this.lblSaldo = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel4 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuGroupBox3 = new Bunifu.UI.WinForms.BunifuGroupBox();
            this.txtPago = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSalir = new System.Windows.Forms.Button();
            this.buttonPagar = new System.Windows.Forms.Button();
            this.comboBoxmedio = new System.Windows.Forms.ComboBox();
            this.bunifuGroupBox1.SuspendLayout();
            this.bunifuGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuGroupBox1
            // 
            this.bunifuGroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(27)))));
            this.bunifuGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.bunifuGroupBox1.BorderRadius = 1;
            this.bunifuGroupBox1.BorderThickness = 1;
            this.bunifuGroupBox1.Controls.Add(this.lblSaldo);
            this.bunifuGroupBox1.Controls.Add(this.bunifuLabel4);
            this.bunifuGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuGroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.bunifuGroupBox1.LabelAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bunifuGroupBox1.LabelIndent = 10;
            this.bunifuGroupBox1.LineStyle = Bunifu.UI.WinForms.BunifuGroupBox.LineStyles.Solid;
            this.bunifuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.bunifuGroupBox1.Name = "bunifuGroupBox1";
            this.bunifuGroupBox1.Size = new System.Drawing.Size(457, 98);
            this.bunifuGroupBox1.TabIndex = 2;
            this.bunifuGroupBox1.TabStop = false;
            this.bunifuGroupBox1.Text = "Datos cliente";
            // 
            // lblSaldo
            // 
            this.lblSaldo.AllowParentOverrides = false;
            this.lblSaldo.AutoEllipsis = false;
            this.lblSaldo.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblSaldo.CursorType = System.Windows.Forms.Cursors.Default;
            this.lblSaldo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblSaldo.ForeColor = System.Drawing.Color.White;
            this.lblSaldo.Location = new System.Drawing.Point(309, 33);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSaldo.Size = new System.Drawing.Size(49, 32);
            this.lblSaldo.TabIndex = 59;
            this.lblSaldo.Text = "0.00";
            this.lblSaldo.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblSaldo.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel4
            // 
            this.bunifuLabel4.AllowParentOverrides = false;
            this.bunifuLabel4.AutoEllipsis = false;
            this.bunifuLabel4.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel4.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.bunifuLabel4.ForeColor = System.Drawing.Color.White;
            this.bunifuLabel4.Location = new System.Drawing.Point(6, 33);
            this.bunifuLabel4.Name = "bunifuLabel4";
            this.bunifuLabel4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel4.Size = new System.Drawing.Size(297, 32);
            this.bunifuLabel4.TabIndex = 58;
            this.bunifuLabel4.Text = "Saldo total de la cuenta: $";
            this.bunifuLabel4.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel4.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuGroupBox3
            // 
            this.bunifuGroupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(27)))));
            this.bunifuGroupBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.bunifuGroupBox3.BorderRadius = 1;
            this.bunifuGroupBox3.BorderThickness = 1;
            this.bunifuGroupBox3.Controls.Add(this.comboBoxmedio);
            this.bunifuGroupBox3.Controls.Add(this.txtPago);
            this.bunifuGroupBox3.Controls.Add(this.label1);
            this.bunifuGroupBox3.Controls.Add(this.buttonSalir);
            this.bunifuGroupBox3.Controls.Add(this.buttonPagar);
            this.bunifuGroupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuGroupBox3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuGroupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.bunifuGroupBox3.LabelAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bunifuGroupBox3.LabelIndent = 10;
            this.bunifuGroupBox3.LineStyle = Bunifu.UI.WinForms.BunifuGroupBox.LineStyles.Solid;
            this.bunifuGroupBox3.Location = new System.Drawing.Point(0, 98);
            this.bunifuGroupBox3.Name = "bunifuGroupBox3";
            this.bunifuGroupBox3.Size = new System.Drawing.Size(457, 178);
            this.bunifuGroupBox3.TabIndex = 4;
            this.bunifuGroupBox3.TabStop = false;
            this.bunifuGroupBox3.Text = "Botones";
            // 
            // txtPago
            // 
            this.txtPago.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPago.Location = new System.Drawing.Point(294, 40);
            this.txtPago.Name = "txtPago";
            this.txtPago.Size = new System.Drawing.Size(138, 29);
            this.txtPago.TabIndex = 55;
            this.txtPago.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPago_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 21);
            this.label1.TabIndex = 56;
            this.label1.Text = "medio de pago";
            // 
            // buttonSalir
            // 
            this.buttonSalir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.buttonSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalir.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.buttonSalir.ForeColor = System.Drawing.Color.White;
            this.buttonSalir.Location = new System.Drawing.Point(59, 103);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(170, 35);
            this.buttonSalir.TabIndex = 55;
            this.buttonSalir.Text = "Cancelar";
            this.buttonSalir.UseVisualStyleBackColor = true;
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // buttonPagar
            // 
            this.buttonPagar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.buttonPagar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.buttonPagar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPagar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.buttonPagar.ForeColor = System.Drawing.Color.White;
            this.buttonPagar.Location = new System.Drawing.Point(252, 103);
            this.buttonPagar.Name = "buttonPagar";
            this.buttonPagar.Size = new System.Drawing.Size(170, 35);
            this.buttonPagar.TabIndex = 54;
            this.buttonPagar.Text = "Pagar";
            this.buttonPagar.UseVisualStyleBackColor = true;
            this.buttonPagar.Click += new System.EventHandler(this.buttonPagar_Click);
            // 
            // comboBoxmedio
            // 
            this.comboBoxmedio.DisplayMember = "descripcion";
            this.comboBoxmedio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxmedio.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.comboBoxmedio.FormattingEnabled = true;
            this.comboBoxmedio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBoxmedio.Location = new System.Drawing.Point(128, 40);
            this.comboBoxmedio.Name = "comboBoxmedio";
            this.comboBoxmedio.Size = new System.Drawing.Size(160, 29);
            this.comboBoxmedio.TabIndex = 58;
            this.comboBoxmedio.ValueMember = "id_med_pago";
            // 
            // pagar_cc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 276);
            this.Controls.Add(this.bunifuGroupBox3);
            this.Controls.Add(this.bunifuGroupBox1);
            this.MaximizeBox = false;
            this.Name = "pagar_cc";
            this.Text = "Registrar pago";
            this.bunifuGroupBox1.ResumeLayout(false);
            this.bunifuGroupBox1.PerformLayout();
            this.bunifuGroupBox3.ResumeLayout(false);
            this.bunifuGroupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuGroupBox bunifuGroupBox1;
        private Bunifu.UI.WinForms.BunifuGroupBox bunifuGroupBox3;
        private System.Windows.Forms.Button buttonSalir;
        private System.Windows.Forms.Button buttonPagar;
        private System.Windows.Forms.TextBox txtPago;
        private System.Windows.Forms.Label label1;
        private Bunifu.UI.WinForms.BunifuLabel lblSaldo;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel4;
        private System.Windows.Forms.ComboBox comboBoxmedio;
    }
}