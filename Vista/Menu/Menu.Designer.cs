
namespace Vista
{
    partial class Menu
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
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.moduloSeguridad = new System.Windows.Forms.ToolStripMenuItem();
            this.formularioUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.formularioGrupos = new System.Windows.Forms.ToolStripMenuItem();
            this.formularioPermiso = new System.Windows.Forms.ToolStripMenuItem();
            this.moduloVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.formularioGestionarVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.formularioGestionarClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.moduloCC = new System.Windows.Forms.ToolStripMenuItem();
            this.formularioGestionarCuentaCorriente = new System.Windows.Forms.ToolStripMenuItem();
            this.formularioGestionarPagos = new System.Windows.Forms.ToolStripMenuItem();
            this.formularioCuentaCorrienteCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.moduloReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.formularioSesiones = new System.Windows.Forms.ToolStripMenuItem();
            this.formularioReportePagos = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.moduloAuditorias = new System.Windows.Forms.ToolStripMenuItem();
            this.FormularioAuditoriaSesiones = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moduloSeguridad,
            this.moduloVentas,
            this.moduloCC,
            this.moduloReportes,
            this.moduloAuditorias});
            this.menuStrip2.Location = new System.Drawing.Point(0, 45);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1159, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // moduloSeguridad
            // 
            this.moduloSeguridad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formularioUsuarios,
            this.formularioGrupos,
            this.formularioPermiso});
            this.moduloSeguridad.Name = "moduloSeguridad";
            this.moduloSeguridad.Size = new System.Drawing.Size(82, 20);
            this.moduloSeguridad.Text = "🛡️Seguridad";
            // 
            // formularioUsuarios
            // 
            this.formularioUsuarios.Name = "formularioUsuarios";
            this.formularioUsuarios.Size = new System.Drawing.Size(122, 22);
            this.formularioUsuarios.Text = "Usuarios";
            this.formularioUsuarios.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // formularioGrupos
            // 
            this.formularioGrupos.Name = "formularioGrupos";
            this.formularioGrupos.Size = new System.Drawing.Size(122, 22);
            this.formularioGrupos.Text = "Grupos";
            this.formularioGrupos.Click += new System.EventHandler(this.gruposToolStripMenuItem_Click);
            // 
            // formularioPermiso
            // 
            this.formularioPermiso.Name = "formularioPermiso";
            this.formularioPermiso.Size = new System.Drawing.Size(122, 22);
            this.formularioPermiso.Text = "Permisos";
            this.formularioPermiso.Click += new System.EventHandler(this.permisoToolStripMenuItem_Click);
            // 
            // moduloVentas
            // 
            this.moduloVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formularioGestionarVentas,
            this.formularioGestionarClientes});
            this.moduloVentas.Name = "moduloVentas";
            this.moduloVentas.Size = new System.Drawing.Size(64, 20);
            this.moduloVentas.Text = "💸Ventas";
            // 
            // formularioGestionarVentas
            // 
            this.formularioGestionarVentas.Name = "formularioGestionarVentas";
            this.formularioGestionarVentas.Size = new System.Drawing.Size(167, 22);
            this.formularioGestionarVentas.Text = "Gestionar ventas";
            this.formularioGestionarVentas.Click += new System.EventHandler(this.crearVentaToolStripMenuItem_Click);
            // 
            // formularioGestionarClientes
            // 
            this.formularioGestionarClientes.Name = "formularioGestionarClientes";
            this.formularioGestionarClientes.Size = new System.Drawing.Size(167, 22);
            this.formularioGestionarClientes.Text = "Gestionar clientes";
            this.formularioGestionarClientes.Click += new System.EventHandler(this.gestionarClientesToolStripMenuItem_Click);
            // 
            // moduloCC
            // 
            this.moduloCC.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formularioGestionarCuentaCorriente,
            this.formularioGestionarPagos,
            this.formularioCuentaCorrienteCliente});
            this.moduloCC.Name = "moduloCC";
            this.moduloCC.Size = new System.Drawing.Size(122, 20);
            this.moduloCC.Text = "💼 Cuenta corriente";
            // 
            // formularioGestionarCuentaCorriente
            // 
            this.formularioGestionarCuentaCorriente.Name = "formularioGestionarCuentaCorriente";
            this.formularioGestionarCuentaCorriente.Size = new System.Drawing.Size(213, 22);
            this.formularioGestionarCuentaCorriente.Text = "Gestionar cuenta corriente";
            this.formularioGestionarCuentaCorriente.Click += new System.EventHandler(this.gestionarCuentaCorrienteToolStripMenuItem_Click);
            // 
            // formularioGestionarPagos
            // 
            this.formularioGestionarPagos.Name = "formularioGestionarPagos";
            this.formularioGestionarPagos.Size = new System.Drawing.Size(213, 22);
            this.formularioGestionarPagos.Text = "Gestionar pagos";
            this.formularioGestionarPagos.Click += new System.EventHandler(this.gestionarPagosToolStripMenuItem_Click);
            // 
            // formularioCuentaCorrienteCliente
            // 
            this.formularioCuentaCorrienteCliente.Name = "formularioCuentaCorrienteCliente";
            this.formularioCuentaCorrienteCliente.Size = new System.Drawing.Size(213, 22);
            this.formularioCuentaCorrienteCliente.Text = "Cuenta corriente cliente";
            this.formularioCuentaCorrienteCliente.Click += new System.EventHandler(this.formularioCuentaCorrienteCliente_Click);
            // 
            // moduloReportes
            // 
            this.moduloReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formularioSesiones,
            this.formularioReportePagos});
            this.moduloReportes.Name = "moduloReportes";
            this.moduloReportes.Size = new System.Drawing.Size(77, 20);
            this.moduloReportes.Text = "📝Reportes";
            // 
            // formularioSesiones
            // 
            this.formularioSesiones.Name = "formularioSesiones";
            this.formularioSesiones.Size = new System.Drawing.Size(180, 22);
            this.formularioSesiones.Text = "Sesiones";
            this.formularioSesiones.Click += new System.EventHandler(this.sesionesToolStripMenuItem_Click);
            // 
            // formularioReportePagos
            // 
            this.formularioReportePagos.Name = "formularioReportePagos";
            this.formularioReportePagos.Size = new System.Drawing.Size(180, 22);
            this.formularioReportePagos.Text = "Pagos";
            this.formularioReportePagos.Click += new System.EventHandler(this.formularioReportePagos_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Vista.Properties.Resources.hard_soft;
            this.pictureBox1.Location = new System.Drawing.Point(267, 83);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(615, 486);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(1159, 45);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // moduloAuditorias
            // 
            this.moduloAuditorias.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FormularioAuditoriaSesiones});
            this.moduloAuditorias.Name = "moduloAuditorias";
            this.moduloAuditorias.Size = new System.Drawing.Size(85, 20);
            this.moduloAuditorias.Text = "🔍Auditorias";
            // 
            // FormularioAuditoriaSesiones
            // 
            this.FormularioAuditoriaSesiones.Name = "FormularioAuditoriaSesiones";
            this.FormularioAuditoriaSesiones.Size = new System.Drawing.Size(180, 22);
            this.FormularioAuditoriaSesiones.Text = "Sesiones";
            this.FormularioAuditoriaSesiones.Click += new System.EventHandler(this.auditoriaSesiones_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1159, 566);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.Text = "Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Menu_FormClosed);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem moduloSeguridad;
        private System.Windows.Forms.ToolStripMenuItem formularioUsuarios;
        private System.Windows.Forms.ToolStripMenuItem moduloVentas;
        private System.Windows.Forms.ToolStripMenuItem moduloCC;
        private System.Windows.Forms.ToolStripMenuItem formularioGestionarCuentaCorriente;
        private System.Windows.Forms.ToolStripMenuItem formularioGestionarVentas;
        private System.Windows.Forms.ToolStripMenuItem formularioGestionarClientes;
        private System.Windows.Forms.ToolStripMenuItem formularioGestionarPagos;
        private System.Windows.Forms.ToolStripMenuItem formularioGrupos;
        private System.Windows.Forms.ToolStripMenuItem formularioPermiso;
        private System.Windows.Forms.ToolStripMenuItem moduloReportes;
        private System.Windows.Forms.ToolStripMenuItem formularioSesiones;
        private System.Windows.Forms.ToolStripMenuItem formularioCuentaCorrienteCliente;
        private System.Windows.Forms.ToolStripMenuItem formularioReportePagos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem moduloAuditorias;
        private System.Windows.Forms.ToolStripMenuItem FormularioAuditoriaSesiones;
    }
}