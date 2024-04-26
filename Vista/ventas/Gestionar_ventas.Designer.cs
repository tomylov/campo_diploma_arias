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
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bunifuPanel2 = new Bunifu.UI.WinForms.BunifuPanel();
            this.comboVtas = new System.Windows.Forms.ComboBox();
            this.Modificar_vta = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.Eliminar_vta = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.crear_vta = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.dataModelcc = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.bunifuPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataModelcc)).BeginInit();
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
            this.bunifuPanel2.Controls.Add(this.comboVtas);
            this.bunifuPanel2.Controls.Add(this.Modificar_vta);
            this.bunifuPanel2.Controls.Add(this.bunifuLabel1);
            this.bunifuPanel2.Controls.Add(this.Eliminar_vta);
            this.bunifuPanel2.Controls.Add(this.crear_vta);
            this.bunifuPanel2.Controls.Add(this.dataModelcc);
            this.bunifuPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuPanel2.Location = new System.Drawing.Point(0, 0);
            this.bunifuPanel2.Name = "bunifuPanel2";
            this.bunifuPanel2.ShowBorders = true;
            this.bunifuPanel2.Size = new System.Drawing.Size(1191, 592);
            this.bunifuPanel2.TabIndex = 2;
            // 
            // comboVtas
            // 
            this.comboVtas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboVtas.FormattingEnabled = true;
            this.comboVtas.Location = new System.Drawing.Point(547, 39);
            this.comboVtas.Name = "comboVtas";
            this.comboVtas.Size = new System.Drawing.Size(246, 21);
            this.comboVtas.TabIndex = 6;
            this.comboVtas.SelectedIndexChanged += new System.EventHandler(this.comboVtas_SelectedIndexChanged);
            // 
            // Modificar_vta
            // 
            this.Modificar_vta.AllowAnimations = true;
            this.Modificar_vta.AllowMouseEffects = true;
            this.Modificar_vta.AllowToggling = false;
            this.Modificar_vta.AnimationSpeed = 200;
            this.Modificar_vta.AutoGenerateColors = false;
            this.Modificar_vta.AutoRoundBorders = false;
            this.Modificar_vta.AutoSizeLeftIcon = true;
            this.Modificar_vta.AutoSizeRightIcon = true;
            this.Modificar_vta.BackColor = System.Drawing.Color.Transparent;
            this.Modificar_vta.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.Modificar_vta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Modificar_vta.BackgroundImage")));
            this.Modificar_vta.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Modificar_vta.ButtonText = "Modificar venta";
            this.Modificar_vta.ButtonTextMarginLeft = 0;
            this.Modificar_vta.ColorContrastOnClick = 45;
            this.Modificar_vta.ColorContrastOnHover = 45;
            this.Modificar_vta.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.Modificar_vta.CustomizableEdges = borderEdges1;
            this.Modificar_vta.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Modificar_vta.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.Modificar_vta.DisabledFillColor = System.Drawing.Color.Empty;
            this.Modificar_vta.DisabledForecolor = System.Drawing.Color.Empty;
            this.Modificar_vta.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.Modificar_vta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Modificar_vta.ForeColor = System.Drawing.Color.White;
            this.Modificar_vta.IconLeft = null;
            this.Modificar_vta.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Modificar_vta.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.Modificar_vta.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.Modificar_vta.IconMarginLeft = 11;
            this.Modificar_vta.IconPadding = 10;
            this.Modificar_vta.IconRight = null;
            this.Modificar_vta.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Modificar_vta.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.Modificar_vta.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.Modificar_vta.IconSize = 25;
            this.Modificar_vta.IdleBorderColor = System.Drawing.Color.Empty;
            this.Modificar_vta.IdleBorderRadius = 0;
            this.Modificar_vta.IdleBorderThickness = 0;
            this.Modificar_vta.IdleFillColor = System.Drawing.Color.Empty;
            this.Modificar_vta.IdleIconLeftImage = null;
            this.Modificar_vta.IdleIconRightImage = null;
            this.Modificar_vta.IndicateFocus = false;
            this.Modificar_vta.Location = new System.Drawing.Point(525, 520);
            this.Modificar_vta.Name = "Modificar_vta";
            this.Modificar_vta.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.Modificar_vta.OnDisabledState.BorderRadius = 1;
            this.Modificar_vta.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Modificar_vta.OnDisabledState.BorderThickness = 1;
            this.Modificar_vta.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.Modificar_vta.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.Modificar_vta.OnDisabledState.IconLeftImage = null;
            this.Modificar_vta.OnDisabledState.IconRightImage = null;
            this.Modificar_vta.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.Modificar_vta.onHoverState.BorderRadius = 1;
            this.Modificar_vta.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Modificar_vta.onHoverState.BorderThickness = 1;
            this.Modificar_vta.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.Modificar_vta.onHoverState.ForeColor = System.Drawing.Color.White;
            this.Modificar_vta.onHoverState.IconLeftImage = null;
            this.Modificar_vta.onHoverState.IconRightImage = null;
            this.Modificar_vta.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.Modificar_vta.OnIdleState.BorderRadius = 1;
            this.Modificar_vta.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Modificar_vta.OnIdleState.BorderThickness = 1;
            this.Modificar_vta.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.Modificar_vta.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.Modificar_vta.OnIdleState.IconLeftImage = null;
            this.Modificar_vta.OnIdleState.IconRightImage = null;
            this.Modificar_vta.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.Modificar_vta.OnPressedState.BorderRadius = 1;
            this.Modificar_vta.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Modificar_vta.OnPressedState.BorderThickness = 1;
            this.Modificar_vta.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.Modificar_vta.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.Modificar_vta.OnPressedState.IconLeftImage = null;
            this.Modificar_vta.OnPressedState.IconRightImage = null;
            this.Modificar_vta.Size = new System.Drawing.Size(149, 40);
            this.Modificar_vta.TabIndex = 5;
            this.Modificar_vta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Modificar_vta.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Modificar_vta.TextMarginLeft = 0;
            this.Modificar_vta.TextPadding = new System.Windows.Forms.Padding(0);
            this.Modificar_vta.UseDefaultRadiusAndThickness = true;
            this.Modificar_vta.Click += new System.EventHandler(this.Modificar_vta_Click);
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AllowParentOverrides = false;
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuLabel1.Location = new System.Drawing.Point(478, 39);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(28, 15);
            this.bunifuLabel1.TabIndex = 4;
            this.bunifuLabel1.Text = "filtro:";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // Eliminar_vta
            // 
            this.Eliminar_vta.AllowAnimations = true;
            this.Eliminar_vta.AllowMouseEffects = true;
            this.Eliminar_vta.AllowToggling = false;
            this.Eliminar_vta.AnimationSpeed = 200;
            this.Eliminar_vta.AutoGenerateColors = false;
            this.Eliminar_vta.AutoRoundBorders = false;
            this.Eliminar_vta.AutoSizeLeftIcon = true;
            this.Eliminar_vta.AutoSizeRightIcon = true;
            this.Eliminar_vta.BackColor = System.Drawing.Color.Transparent;
            this.Eliminar_vta.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.Eliminar_vta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Eliminar_vta.BackgroundImage")));
            this.Eliminar_vta.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Eliminar_vta.ButtonText = "Eliminar venta";
            this.Eliminar_vta.ButtonTextMarginLeft = 0;
            this.Eliminar_vta.ColorContrastOnClick = 45;
            this.Eliminar_vta.ColorContrastOnHover = 45;
            this.Eliminar_vta.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.Eliminar_vta.CustomizableEdges = borderEdges2;
            this.Eliminar_vta.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Eliminar_vta.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.Eliminar_vta.DisabledFillColor = System.Drawing.Color.Empty;
            this.Eliminar_vta.DisabledForecolor = System.Drawing.Color.Empty;
            this.Eliminar_vta.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.Eliminar_vta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Eliminar_vta.ForeColor = System.Drawing.Color.White;
            this.Eliminar_vta.IconLeft = null;
            this.Eliminar_vta.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Eliminar_vta.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.Eliminar_vta.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.Eliminar_vta.IconMarginLeft = 11;
            this.Eliminar_vta.IconPadding = 10;
            this.Eliminar_vta.IconRight = null;
            this.Eliminar_vta.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Eliminar_vta.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.Eliminar_vta.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.Eliminar_vta.IconSize = 25;
            this.Eliminar_vta.IdleBorderColor = System.Drawing.Color.Empty;
            this.Eliminar_vta.IdleBorderRadius = 0;
            this.Eliminar_vta.IdleBorderThickness = 0;
            this.Eliminar_vta.IdleFillColor = System.Drawing.Color.Empty;
            this.Eliminar_vta.IdleIconLeftImage = null;
            this.Eliminar_vta.IdleIconRightImage = null;
            this.Eliminar_vta.IndicateFocus = false;
            this.Eliminar_vta.Location = new System.Drawing.Point(653, 458);
            this.Eliminar_vta.Name = "Eliminar_vta";
            this.Eliminar_vta.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.Eliminar_vta.OnDisabledState.BorderRadius = 1;
            this.Eliminar_vta.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Eliminar_vta.OnDisabledState.BorderThickness = 1;
            this.Eliminar_vta.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.Eliminar_vta.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.Eliminar_vta.OnDisabledState.IconLeftImage = null;
            this.Eliminar_vta.OnDisabledState.IconRightImage = null;
            this.Eliminar_vta.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.Eliminar_vta.onHoverState.BorderRadius = 1;
            this.Eliminar_vta.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Eliminar_vta.onHoverState.BorderThickness = 1;
            this.Eliminar_vta.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.Eliminar_vta.onHoverState.ForeColor = System.Drawing.Color.White;
            this.Eliminar_vta.onHoverState.IconLeftImage = null;
            this.Eliminar_vta.onHoverState.IconRightImage = null;
            this.Eliminar_vta.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.Eliminar_vta.OnIdleState.BorderRadius = 1;
            this.Eliminar_vta.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Eliminar_vta.OnIdleState.BorderThickness = 1;
            this.Eliminar_vta.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.Eliminar_vta.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.Eliminar_vta.OnIdleState.IconLeftImage = null;
            this.Eliminar_vta.OnIdleState.IconRightImage = null;
            this.Eliminar_vta.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.Eliminar_vta.OnPressedState.BorderRadius = 1;
            this.Eliminar_vta.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Eliminar_vta.OnPressedState.BorderThickness = 1;
            this.Eliminar_vta.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.Eliminar_vta.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.Eliminar_vta.OnPressedState.IconLeftImage = null;
            this.Eliminar_vta.OnPressedState.IconRightImage = null;
            this.Eliminar_vta.Size = new System.Drawing.Size(149, 40);
            this.Eliminar_vta.TabIndex = 3;
            this.Eliminar_vta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Eliminar_vta.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Eliminar_vta.TextMarginLeft = 0;
            this.Eliminar_vta.TextPadding = new System.Windows.Forms.Padding(0);
            this.Eliminar_vta.UseDefaultRadiusAndThickness = true;
            this.Eliminar_vta.Click += new System.EventHandler(this.Eliminar_vta_Click);
            // 
            // crear_vta
            // 
            this.crear_vta.AllowAnimations = true;
            this.crear_vta.AllowMouseEffects = true;
            this.crear_vta.AllowToggling = false;
            this.crear_vta.AnimationSpeed = 200;
            this.crear_vta.AutoGenerateColors = false;
            this.crear_vta.AutoRoundBorders = false;
            this.crear_vta.AutoSizeLeftIcon = true;
            this.crear_vta.AutoSizeRightIcon = true;
            this.crear_vta.BackColor = System.Drawing.Color.Transparent;
            this.crear_vta.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.crear_vta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("crear_vta.BackgroundImage")));
            this.crear_vta.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.crear_vta.ButtonText = "Crear venta";
            this.crear_vta.ButtonTextMarginLeft = 0;
            this.crear_vta.ColorContrastOnClick = 45;
            this.crear_vta.ColorContrastOnHover = 45;
            this.crear_vta.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges3.BottomLeft = true;
            borderEdges3.BottomRight = true;
            borderEdges3.TopLeft = true;
            borderEdges3.TopRight = true;
            this.crear_vta.CustomizableEdges = borderEdges3;
            this.crear_vta.DialogResult = System.Windows.Forms.DialogResult.None;
            this.crear_vta.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.crear_vta.DisabledFillColor = System.Drawing.Color.Empty;
            this.crear_vta.DisabledForecolor = System.Drawing.Color.Empty;
            this.crear_vta.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.crear_vta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.crear_vta.ForeColor = System.Drawing.Color.White;
            this.crear_vta.IconLeft = null;
            this.crear_vta.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.crear_vta.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.crear_vta.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.crear_vta.IconMarginLeft = 11;
            this.crear_vta.IconPadding = 10;
            this.crear_vta.IconRight = null;
            this.crear_vta.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.crear_vta.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.crear_vta.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.crear_vta.IconSize = 25;
            this.crear_vta.IdleBorderColor = System.Drawing.Color.Empty;
            this.crear_vta.IdleBorderRadius = 0;
            this.crear_vta.IdleBorderThickness = 0;
            this.crear_vta.IdleFillColor = System.Drawing.Color.Empty;
            this.crear_vta.IdleIconLeftImage = null;
            this.crear_vta.IdleIconRightImage = null;
            this.crear_vta.IndicateFocus = false;
            this.crear_vta.Location = new System.Drawing.Point(390, 458);
            this.crear_vta.Name = "crear_vta";
            this.crear_vta.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.crear_vta.OnDisabledState.BorderRadius = 1;
            this.crear_vta.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.crear_vta.OnDisabledState.BorderThickness = 1;
            this.crear_vta.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.crear_vta.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.crear_vta.OnDisabledState.IconLeftImage = null;
            this.crear_vta.OnDisabledState.IconRightImage = null;
            this.crear_vta.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.crear_vta.onHoverState.BorderRadius = 1;
            this.crear_vta.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.crear_vta.onHoverState.BorderThickness = 1;
            this.crear_vta.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.crear_vta.onHoverState.ForeColor = System.Drawing.Color.White;
            this.crear_vta.onHoverState.IconLeftImage = null;
            this.crear_vta.onHoverState.IconRightImage = null;
            this.crear_vta.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.crear_vta.OnIdleState.BorderRadius = 1;
            this.crear_vta.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.crear_vta.OnIdleState.BorderThickness = 1;
            this.crear_vta.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.crear_vta.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.crear_vta.OnIdleState.IconLeftImage = null;
            this.crear_vta.OnIdleState.IconRightImage = null;
            this.crear_vta.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.crear_vta.OnPressedState.BorderRadius = 1;
            this.crear_vta.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.crear_vta.OnPressedState.BorderThickness = 1;
            this.crear_vta.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.crear_vta.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.crear_vta.OnPressedState.IconLeftImage = null;
            this.crear_vta.OnPressedState.IconRightImage = null;
            this.crear_vta.Size = new System.Drawing.Size(149, 40);
            this.crear_vta.TabIndex = 2;
            this.crear_vta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.crear_vta.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.crear_vta.TextMarginLeft = 0;
            this.crear_vta.TextPadding = new System.Windows.Forms.Padding(0);
            this.crear_vta.UseDefaultRadiusAndThickness = true;
            this.crear_vta.Click += new System.EventHandler(this.crear_vta_Click);
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
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
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
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataModelcc.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataModelcc.EnableHeadersVisualStyles = false;
            this.dataModelcc.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dataModelcc.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.dataModelcc.HeaderBgColor = System.Drawing.Color.Empty;
            this.dataModelcc.HeaderForeColor = System.Drawing.Color.White;
            this.dataModelcc.Location = new System.Drawing.Point(79, 80);
            this.dataModelcc.Name = "dataModelcc";
            this.dataModelcc.RowHeadersVisible = false;
            this.dataModelcc.RowTemplate.Height = 40;
            this.dataModelcc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataModelcc.Size = new System.Drawing.Size(1023, 344);
            this.dataModelcc.TabIndex = 0;
            this.dataModelcc.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            this.dataModelcc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataModelcc_CellClick);
            this.dataModelcc.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataModelcc_CellDoubleClick);
            // 
            // Gestionar_ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 592);
            this.Controls.Add(this.bunifuPanel2);
            this.Name = "Gestionar_ventas";
            this.Text = "Gestionar_ventas";
            this.bunifuPanel2.ResumeLayout(false);
            this.bunifuPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataModelcc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel2;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton Eliminar_vta;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton crear_vta;
        private Bunifu.UI.WinForms.BunifuDataGridView dataModelcc;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton Modificar_vta;
        private System.Windows.Forms.ComboBox comboVtas;
    }
}