namespace Vista.Clientes
{
    partial class detalle_permisos
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(detalle_permisos));
            this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuGroupBox1 = new Bunifu.UI.WinForms.BunifuGroupBox();
            this.drpFormulario = new Bunifu.UI.WinForms.BunifuDropdown();
            this.formulariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.checkEstado = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bunifuPanel2 = new Bunifu.UI.WinForms.BunifuPanel();
            this.bunifuPanel3 = new Bunifu.UI.WinForms.BunifuPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.bunifuPanel1.SuspendLayout();
            this.bunifuGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formulariosBindingSource)).BeginInit();
            this.bunifuPanel2.SuspendLayout();
            this.bunifuPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuPanel1
            // 
            this.bunifuPanel1.BackgroundColor = System.Drawing.Color.Transparent;
            this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
            this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel1.BorderColor = System.Drawing.Color.White;
            this.bunifuPanel1.BorderRadius = 3;
            this.bunifuPanel1.BorderThickness = 1;
            this.bunifuPanel1.Controls.Add(this.label1);
            this.bunifuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuPanel1.Name = "bunifuPanel1";
            this.bunifuPanel1.ShowBorders = true;
            this.bunifuPanel1.Size = new System.Drawing.Size(800, 59);
            this.bunifuPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(279, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "Detalle permiso";
            // 
            // bunifuGroupBox1
            // 
            this.bunifuGroupBox1.BorderColor = System.Drawing.Color.White;
            this.bunifuGroupBox1.BorderRadius = 1;
            this.bunifuGroupBox1.BorderThickness = 1;
            this.bunifuGroupBox1.Controls.Add(this.drpFormulario);
            this.bunifuGroupBox1.Controls.Add(this.checkEstado);
            this.bunifuGroupBox1.Controls.Add(this.label3);
            this.bunifuGroupBox1.Controls.Add(this.txtnombre);
            this.bunifuGroupBox1.Controls.Add(this.label5);
            this.bunifuGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuGroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuGroupBox1.ForeColor = System.Drawing.Color.White;
            this.bunifuGroupBox1.LabelAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bunifuGroupBox1.LabelIndent = 10;
            this.bunifuGroupBox1.LineStyle = Bunifu.UI.WinForms.BunifuGroupBox.LineStyles.Solid;
            this.bunifuGroupBox1.Location = new System.Drawing.Point(0, 59);
            this.bunifuGroupBox1.Name = "bunifuGroupBox1";
            this.bunifuGroupBox1.Size = new System.Drawing.Size(800, 266);
            this.bunifuGroupBox1.TabIndex = 1;
            this.bunifuGroupBox1.TabStop = false;
            this.bunifuGroupBox1.Text = "Datos permiso";
            // 
            // drpFormulario
            // 
            this.drpFormulario.BackColor = System.Drawing.Color.Transparent;
            this.drpFormulario.BackgroundColor = System.Drawing.Color.White;
            this.drpFormulario.BorderColor = System.Drawing.Color.Silver;
            this.drpFormulario.BorderRadius = 1;
            this.drpFormulario.Color = System.Drawing.Color.Silver;
            this.drpFormulario.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.formulariosBindingSource, "id_formulario", true));
            this.drpFormulario.DataSource = this.formulariosBindingSource;
            this.drpFormulario.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.drpFormulario.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.drpFormulario.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.drpFormulario.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.drpFormulario.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.drpFormulario.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.drpFormulario.DisplayMember = "nombre";
            this.drpFormulario.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.drpFormulario.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.drpFormulario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpFormulario.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.drpFormulario.FillDropDown = true;
            this.drpFormulario.FillIndicator = false;
            this.drpFormulario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.drpFormulario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.drpFormulario.ForeColor = System.Drawing.Color.Black;
            this.drpFormulario.FormattingEnabled = true;
            this.drpFormulario.Icon = null;
            this.drpFormulario.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.drpFormulario.IndicatorColor = System.Drawing.Color.DarkGray;
            this.drpFormulario.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.drpFormulario.IndicatorThickness = 2;
            this.drpFormulario.IsDropdownOpened = false;
            this.drpFormulario.ItemBackColor = System.Drawing.Color.White;
            this.drpFormulario.ItemBorderColor = System.Drawing.Color.White;
            this.drpFormulario.ItemForeColor = System.Drawing.Color.Black;
            this.drpFormulario.ItemHeight = 20;
            this.drpFormulario.ItemHighLightColor = System.Drawing.Color.DodgerBlue;
            this.drpFormulario.ItemHighLightForeColor = System.Drawing.Color.White;
            this.drpFormulario.ItemTopMargin = 3;
            this.drpFormulario.Location = new System.Drawing.Point(244, 92);
            this.drpFormulario.Name = "drpFormulario";
            this.drpFormulario.Size = new System.Drawing.Size(432, 26);
            this.drpFormulario.TabIndex = 55;
            this.drpFormulario.Text = null;
            this.drpFormulario.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.drpFormulario.TextLeftMargin = 5;
            this.drpFormulario.ValueMember = "id_formulario";
            // 
            // formulariosBindingSource
            // 
            this.formulariosBindingSource.DataSource = typeof(Modelo.Formularios);
            // 
            // checkEstado
            // 
            this.checkEstado.AutoSize = true;
            this.checkEstado.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.checkEstado.ForeColor = System.Drawing.Color.White;
            this.checkEstado.Location = new System.Drawing.Point(694, 154);
            this.checkEstado.Name = "checkEstado";
            this.checkEstado.Size = new System.Drawing.Size(76, 25);
            this.checkEstado.TabIndex = 54;
            this.checkEstado.Text = "Activo";
            this.checkEstado.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(145, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 21);
            this.label3.TabIndex = 48;
            this.label3.Text = "Formulario:";
            // 
            // txtnombre
            // 
            this.txtnombre.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtnombre.Location = new System.Drawing.Point(244, 41);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(334, 29);
            this.txtnombre.TabIndex = 47;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(170, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 21);
            this.label5.TabIndex = 46;
            this.label5.Text = "Nombre:";
            // 
            // bunifuPanel2
            // 
            this.bunifuPanel2.BackgroundColor = System.Drawing.Color.Transparent;
            this.bunifuPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel2.BackgroundImage")));
            this.bunifuPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel2.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel2.BorderRadius = 3;
            this.bunifuPanel2.BorderThickness = 1;
            this.bunifuPanel2.Controls.Add(this.bunifuPanel3);
            this.bunifuPanel2.Controls.Add(this.button2);
            this.bunifuPanel2.Controls.Add(this.button3);
            this.bunifuPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bunifuPanel2.Location = new System.Drawing.Point(0, 254);
            this.bunifuPanel2.Name = "bunifuPanel2";
            this.bunifuPanel2.ShowBorders = true;
            this.bunifuPanel2.Size = new System.Drawing.Size(800, 71);
            this.bunifuPanel2.TabIndex = 2;
            // 
            // bunifuPanel3
            // 
            this.bunifuPanel3.BackgroundColor = System.Drawing.Color.Transparent;
            this.bunifuPanel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel3.BackgroundImage")));
            this.bunifuPanel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel3.BorderColor = System.Drawing.Color.White;
            this.bunifuPanel3.BorderRadius = 3;
            this.bunifuPanel3.BorderThickness = 1;
            this.bunifuPanel3.Controls.Add(this.button1);
            this.bunifuPanel3.Controls.Add(this.button4);
            this.bunifuPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bunifuPanel3.Location = new System.Drawing.Point(0, 0);
            this.bunifuPanel3.Name = "bunifuPanel3";
            this.bunifuPanel3.ShowBorders = true;
            this.bunifuPanel3.Size = new System.Drawing.Size(800, 71);
            this.bunifuPanel3.TabIndex = 50;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(68)))), ((int)(((byte)(89)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(591, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 44);
            this.button1.TabIndex = 14;
            this.button1.Text = "Guardar cambios";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(68)))), ((int)(((byte)(89)))));
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(459, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(126, 44);
            this.button4.TabIndex = 15;
            this.button4.Text = "Cancelar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(68)))), ((int)(((byte)(89)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(591, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(195, 44);
            this.button2.TabIndex = 14;
            this.button2.Text = "Guardar cambios";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(68)))), ((int)(((byte)(89)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(459, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(126, 44);
            this.button3.TabIndex = 15;
            this.button3.Text = "Cancelar";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // detalle_permisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(800, 325);
            this.Controls.Add(this.bunifuPanel2);
            this.Controls.Add(this.bunifuGroupBox1);
            this.Controls.Add(this.bunifuPanel1);
            this.MaximizeBox = false;
            this.Name = "detalle_permisos";
            this.Text = "detalle_empleado";
            this.bunifuPanel1.ResumeLayout(false);
            this.bunifuPanel1.PerformLayout();
            this.bunifuGroupBox1.ResumeLayout(false);
            this.bunifuGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formulariosBindingSource)).EndInit();
            this.bunifuPanel2.ResumeLayout(false);
            this.bunifuPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        private Bunifu.UI.WinForms.BunifuGroupBox bunifuGroupBox1;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox checkEstado;
        private Bunifu.UI.WinForms.BunifuDropdown drpFormulario;
        private System.Windows.Forms.BindingSource formulariosBindingSource;
    }
}