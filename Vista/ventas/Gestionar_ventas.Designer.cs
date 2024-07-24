namespace Vista
{
    partial class Gestionar_ventas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gestionar_ventas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.bunifuPanel2 = new Bunifu.UI.WinForms.BunifuPanel();
            this.comboVtas = new System.Windows.Forms.ComboBox();
            this.dataModelcc = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            this.bunifuGroupBox1 = new Bunifu.UI.WinForms.BunifuGroupBox();
            this.bunifuGroupBox2 = new Bunifu.UI.WinForms.BunifuGroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Eliminar_vta = new System.Windows.Forms.Button();
            this.Modificar_vta = new System.Windows.Forms.Button();
            this.crear_vta = new System.Windows.Forms.Button();
            this.btnsalir = new System.Windows.Forms.Button();
            this.bunifuLabel9 = new Bunifu.UI.WinForms.BunifuLabel();
            this.txtvta = new Bunifu.UI.WinForms.BunifuTextBox();
            this.bunifuPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataModelcc)).BeginInit();
            this.bunifuPanel1.SuspendLayout();
            this.bunifuGroupBox1.SuspendLayout();
            this.bunifuGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuPanel2
            // 
            this.bunifuPanel2.BackgroundColor = System.Drawing.Color.Transparent;
            this.bunifuPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel2.BackgroundImage")));
            this.bunifuPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel2.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel2.BorderRadius = 3;
            this.bunifuPanel2.BorderThickness = 1;
            this.bunifuPanel2.Controls.Add(this.bunifuGroupBox2);
            this.bunifuPanel2.Controls.Add(this.bunifuGroupBox1);
            this.bunifuPanel2.Controls.Add(this.bunifuPanel1);
            this.bunifuPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuPanel2.Location = new System.Drawing.Point(0, 0);
            this.bunifuPanel2.Name = "bunifuPanel2";
            this.bunifuPanel2.ShowBorders = true;
            this.bunifuPanel2.Size = new System.Drawing.Size(1163, 647);
            this.bunifuPanel2.TabIndex = 2;
            // 
            // comboVtas
            // 
            this.comboVtas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboVtas.FormattingEnabled = true;
            this.comboVtas.Location = new System.Drawing.Point(318, 45);
            this.comboVtas.Name = "comboVtas";
            this.comboVtas.Size = new System.Drawing.Size(246, 21);
            this.comboVtas.TabIndex = 6;
            this.comboVtas.SelectedIndexChanged += new System.EventHandler(this.comboVtas_SelectedIndexChanged);
            // 
            // dataModelcc
            // 
            this.dataModelcc.AllowCustomTheming = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataModelcc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataModelcc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataModelcc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataModelcc.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataModelcc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataModelcc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataModelcc.ColumnHeadersHeight = 40;
            this.dataModelcc.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.dataModelcc.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dataModelcc.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dataModelcc.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dataModelcc.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataModelcc.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.dataModelcc.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dataModelcc.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.dataModelcc.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dataModelcc.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataModelcc.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.dataModelcc.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dataModelcc.CurrentTheme.Name = null;
            this.dataModelcc.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataModelcc.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dataModelcc.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dataModelcc.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dataModelcc.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataModelcc.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataModelcc.EnableHeadersVisualStyles = false;
            this.dataModelcc.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dataModelcc.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.dataModelcc.HeaderBgColor = System.Drawing.Color.Empty;
            this.dataModelcc.HeaderForeColor = System.Drawing.Color.White;
            this.dataModelcc.Location = new System.Drawing.Point(12, 22);
            this.dataModelcc.Name = "dataModelcc";
            this.dataModelcc.RowHeadersVisible = false;
            this.dataModelcc.RowTemplate.Height = 40;
            this.dataModelcc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataModelcc.Size = new System.Drawing.Size(916, 483);
            this.dataModelcc.TabIndex = 0;
            this.dataModelcc.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            this.dataModelcc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataModelcc_CellClick);
            this.dataModelcc.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataModelcc_CellDoubleClick);
            // 
            // bunifuPanel1
            // 
            this.bunifuPanel1.BackgroundColor = System.Drawing.Color.Transparent;
            this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
            this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel1.BorderRadius = 3;
            this.bunifuPanel1.BorderThickness = 1;
            this.bunifuPanel1.Controls.Add(this.label1);
            this.bunifuPanel1.Controls.Add(this.comboVtas);
            this.bunifuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuPanel1.Name = "bunifuPanel1";
            this.bunifuPanel1.ShowBorders = true;
            this.bunifuPanel1.Size = new System.Drawing.Size(1163, 100);
            this.bunifuPanel1.TabIndex = 7;
            // 
            // bunifuGroupBox1
            // 
            this.bunifuGroupBox1.BorderColor = System.Drawing.Color.LightGray;
            this.bunifuGroupBox1.BorderRadius = 1;
            this.bunifuGroupBox1.BorderThickness = 1;
            this.bunifuGroupBox1.Controls.Add(this.btnsalir);
            this.bunifuGroupBox1.Controls.Add(this.bunifuLabel9);
            this.bunifuGroupBox1.Controls.Add(this.txtvta);
            this.bunifuGroupBox1.Controls.Add(this.Eliminar_vta);
            this.bunifuGroupBox1.Controls.Add(this.Modificar_vta);
            this.bunifuGroupBox1.Controls.Add(this.crear_vta);
            this.bunifuGroupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.bunifuGroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuGroupBox1.LabelAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bunifuGroupBox1.LabelIndent = 10;
            this.bunifuGroupBox1.LineStyle = Bunifu.UI.WinForms.BunifuGroupBox.LineStyles.Solid;
            this.bunifuGroupBox1.Location = new System.Drawing.Point(944, 100);
            this.bunifuGroupBox1.Name = "bunifuGroupBox1";
            this.bunifuGroupBox1.Size = new System.Drawing.Size(219, 547);
            this.bunifuGroupBox1.TabIndex = 8;
            this.bunifuGroupBox1.TabStop = false;
            this.bunifuGroupBox1.Text = "Botones";
            // 
            // bunifuGroupBox2
            // 
            this.bunifuGroupBox2.BorderColor = System.Drawing.Color.LightGray;
            this.bunifuGroupBox2.BorderRadius = 1;
            this.bunifuGroupBox2.BorderThickness = 1;
            this.bunifuGroupBox2.Controls.Add(this.dataModelcc);
            this.bunifuGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuGroupBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuGroupBox2.LabelAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bunifuGroupBox2.LabelIndent = 10;
            this.bunifuGroupBox2.LineStyle = Bunifu.UI.WinForms.BunifuGroupBox.LineStyles.Solid;
            this.bunifuGroupBox2.Location = new System.Drawing.Point(0, 100);
            this.bunifuGroupBox2.Name = "bunifuGroupBox2";
            this.bunifuGroupBox2.Size = new System.Drawing.Size(944, 547);
            this.bunifuGroupBox2.TabIndex = 9;
            this.bunifuGroupBox2.TabStop = false;
            this.bunifuGroupBox2.Text = "Ventas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(191, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 21);
            this.label1.TabIndex = 24;
            this.label1.Text = "Filtrar por:";
            // 
            // Eliminar_vta
            // 
            this.Eliminar_vta.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.Eliminar_vta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.Eliminar_vta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Eliminar_vta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Eliminar_vta.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.Eliminar_vta.ForeColor = System.Drawing.Color.White;
            this.Eliminar_vta.Location = new System.Drawing.Point(23, 155);
            this.Eliminar_vta.Name = "Eliminar_vta";
            this.Eliminar_vta.Size = new System.Drawing.Size(170, 35);
            this.Eliminar_vta.TabIndex = 16;
            this.Eliminar_vta.Text = "Eliminar";
            this.Eliminar_vta.UseVisualStyleBackColor = true;
            this.Eliminar_vta.Click += new System.EventHandler(this.Eliminar_vta_Click);
            // 
            // Modificar_vta
            // 
            this.Modificar_vta.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.Modificar_vta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.Modificar_vta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Modificar_vta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Modificar_vta.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.Modificar_vta.ForeColor = System.Drawing.Color.White;
            this.Modificar_vta.Location = new System.Drawing.Point(23, 114);
            this.Modificar_vta.Name = "Modificar_vta";
            this.Modificar_vta.Size = new System.Drawing.Size(170, 35);
            this.Modificar_vta.TabIndex = 15;
            this.Modificar_vta.Text = "Modificar";
            this.Modificar_vta.UseVisualStyleBackColor = true;
            this.Modificar_vta.Click += new System.EventHandler(this.Modificar_vta_Click);
            // 
            // crear_vta
            // 
            this.crear_vta.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.crear_vta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.crear_vta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.crear_vta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.crear_vta.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.crear_vta.ForeColor = System.Drawing.Color.White;
            this.crear_vta.Location = new System.Drawing.Point(23, 73);
            this.crear_vta.Name = "crear_vta";
            this.crear_vta.Size = new System.Drawing.Size(170, 35);
            this.crear_vta.TabIndex = 14;
            this.crear_vta.Text = "Agregar";
            this.crear_vta.UseVisualStyleBackColor = true;
            this.crear_vta.Click += new System.EventHandler(this.crear_vta_Click);
            // 
            // btnsalir
            // 
            this.btnsalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(55)))), ((int)(((byte)(235)))));
            this.btnsalir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.btnsalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnsalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnsalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsalir.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnsalir.ForeColor = System.Drawing.Color.White;
            this.btnsalir.Location = new System.Drawing.Point(23, 470);
            this.btnsalir.Name = "btnsalir";
            this.btnsalir.Size = new System.Drawing.Size(170, 35);
            this.btnsalir.TabIndex = 19;
            this.btnsalir.Text = "Salir";
            this.btnsalir.UseVisualStyleBackColor = false;
            this.btnsalir.Click += new System.EventHandler(this.btnsalir_Click);
            // 
            // bunifuLabel9
            // 
            this.bunifuLabel9.AllowParentOverrides = false;
            this.bunifuLabel9.AutoEllipsis = false;
            this.bunifuLabel9.CursorType = null;
            this.bunifuLabel9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuLabel9.ForeColor = System.Drawing.Color.White;
            this.bunifuLabel9.Location = new System.Drawing.Point(11, 388);
            this.bunifuLabel9.Name = "bunifuLabel9";
            this.bunifuLabel9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel9.Size = new System.Drawing.Size(101, 15);
            this.bunifuLabel9.TabIndex = 17;
            this.bunifuLabel9.Text = "Venta seleccionada";
            this.bunifuLabel9.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel9.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // txtvta
            // 
            this.txtvta.AcceptsReturn = false;
            this.txtvta.AcceptsTab = false;
            this.txtvta.AnimationSpeed = 200;
            this.txtvta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtvta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtvta.AutoSizeHeight = true;
            this.txtvta.BackColor = System.Drawing.Color.Transparent;
            this.txtvta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtvta.BackgroundImage")));
            this.txtvta.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtvta.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtvta.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtvta.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtvta.BorderRadius = 1;
            this.txtvta.BorderThickness = 1;
            this.txtvta.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtvta.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtvta.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
            this.txtvta.DefaultText = "";
            this.txtvta.Enabled = false;
            this.txtvta.FillColor = System.Drawing.Color.White;
            this.txtvta.HideSelection = true;
            this.txtvta.IconLeft = null;
            this.txtvta.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtvta.IconPadding = 10;
            this.txtvta.IconRight = null;
            this.txtvta.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtvta.Lines = new string[0];
            this.txtvta.Location = new System.Drawing.Point(11, 409);
            this.txtvta.MaxLength = 32767;
            this.txtvta.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtvta.Modified = false;
            this.txtvta.Multiline = false;
            this.txtvta.Name = "txtvta";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtvta.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtvta.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtvta.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtvta.OnIdleState = stateProperties4;
            this.txtvta.Padding = new System.Windows.Forms.Padding(3);
            this.txtvta.PasswordChar = '\0';
            this.txtvta.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtvta.PlaceholderText = "soy una venta";
            this.txtvta.ReadOnly = false;
            this.txtvta.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtvta.SelectedText = "";
            this.txtvta.SelectionLength = 0;
            this.txtvta.SelectionStart = 0;
            this.txtvta.ShortcutsEnabled = true;
            this.txtvta.Size = new System.Drawing.Size(196, 39);
            this.txtvta.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtvta.TabIndex = 18;
            this.txtvta.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtvta.TextMarginBottom = 0;
            this.txtvta.TextMarginLeft = 3;
            this.txtvta.TextMarginTop = 1;
            this.txtvta.TextPlaceholder = "soy una venta";
            this.txtvta.UseSystemPasswordChar = false;
            this.txtvta.WordWrap = true;
            // 
            // Gestionar_ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(1163, 647);
            this.Controls.Add(this.bunifuPanel2);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Gestionar_ventas";
            this.Text = "Gestionar_ventas";
            this.bunifuPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataModelcc)).EndInit();
            this.bunifuPanel1.ResumeLayout(false);
            this.bunifuPanel1.PerformLayout();
            this.bunifuGroupBox1.ResumeLayout(false);
            this.bunifuGroupBox1.PerformLayout();
            this.bunifuGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel2;
        private Bunifu.UI.WinForms.BunifuDataGridView dataModelcc;
        private System.Windows.Forms.ComboBox comboVtas;
        private Bunifu.UI.WinForms.BunifuGroupBox bunifuGroupBox2;
        private Bunifu.UI.WinForms.BunifuGroupBox bunifuGroupBox1;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Eliminar_vta;
        private System.Windows.Forms.Button Modificar_vta;
        private System.Windows.Forms.Button crear_vta;
        private System.Windows.Forms.Button btnsalir;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel9;
        private Bunifu.UI.WinForms.BunifuTextBox txtvta;
    }
}