namespace UI
{
    partial class FrmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuClientes = new FontAwesome.Sharp.IconMenuItem();
            this.submenuGestionarClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInventario = new FontAwesome.Sharp.IconMenuItem();
            this.submenuRegistrarProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuRecepcionarProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPedidos = new FontAwesome.Sharp.IconMenuItem();
            this.submenuGestionarPedidos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVentas = new FontAwesome.Sharp.IconMenuItem();
            this.submenuGestionarVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReportes = new FontAwesome.Sharp.IconMenuItem();
            this.submenuReportePedidos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUsuario = new FontAwesome.Sharp.IconMenuItem();
            this.submenuGestionarUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdministrador = new FontAwesome.Sharp.IconMenuItem();
            this.submenuAdministradorUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuAccesos = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuBackupRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTitulo = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.contenedor = new System.Windows.Forms.Panel();
            this.cmbIdioma = new System.Windows.Forms.ComboBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnLogOut = new FontAwesome.Sharp.IconButton();
            this.lblSesión = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            resources.ApplyResources(this.menu, "menu");
            this.menu.BackColor = System.Drawing.Color.DarkSlateGray;
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuClientes,
            this.menuInventario,
            this.menuPedidos,
            this.menuVentas,
            this.menuReportes,
            this.menuUsuario,
            this.menuAdministrador});
            this.menu.Name = "menu";
            // 
            // menuClientes
            // 
            resources.ApplyResources(this.menuClientes, "menuClientes");
            this.menuClientes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuGestionarClientes});
            this.menuClientes.ForeColor = System.Drawing.Color.Black;
            this.menuClientes.IconChar = FontAwesome.Sharp.IconChar.PeopleGroup;
            this.menuClientes.IconColor = System.Drawing.Color.Black;
            this.menuClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuClientes.IconSize = 50;
            this.menuClientes.Name = "menuClientes";
            // 
            // submenuGestionarClientes
            // 
            this.submenuGestionarClientes.Name = "submenuGestionarClientes";
            resources.ApplyResources(this.submenuGestionarClientes, "submenuGestionarClientes");
            this.submenuGestionarClientes.Click += new System.EventHandler(this.submenuGestionarClientes_Click);
            // 
            // menuInventario
            // 
            resources.ApplyResources(this.menuInventario, "menuInventario");
            this.menuInventario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuRegistrarProductos,
            this.submenuRecepcionarProductos});
            this.menuInventario.IconChar = FontAwesome.Sharp.IconChar.Clipboard;
            this.menuInventario.IconColor = System.Drawing.Color.Black;
            this.menuInventario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuInventario.IconSize = 50;
            this.menuInventario.Name = "menuInventario";
            // 
            // submenuRegistrarProductos
            // 
            this.submenuRegistrarProductos.Name = "submenuRegistrarProductos";
            resources.ApplyResources(this.submenuRegistrarProductos, "submenuRegistrarProductos");
            this.submenuRegistrarProductos.Click += new System.EventHandler(this.submenuRegistrarProductos_Click);
            // 
            // submenuRecepcionarProductos
            // 
            this.submenuRecepcionarProductos.Name = "submenuRecepcionarProductos";
            resources.ApplyResources(this.submenuRecepcionarProductos, "submenuRecepcionarProductos");
            this.submenuRecepcionarProductos.Click += new System.EventHandler(this.submenuRecepcionarProductos_Click);
            // 
            // menuPedidos
            // 
            resources.ApplyResources(this.menuPedidos, "menuPedidos");
            this.menuPedidos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuGestionarPedidos});
            this.menuPedidos.IconChar = FontAwesome.Sharp.IconChar.SquareCheck;
            this.menuPedidos.IconColor = System.Drawing.Color.Black;
            this.menuPedidos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuPedidos.IconSize = 50;
            this.menuPedidos.Name = "menuPedidos";
            // 
            // submenuGestionarPedidos
            // 
            this.submenuGestionarPedidos.Name = "submenuGestionarPedidos";
            resources.ApplyResources(this.submenuGestionarPedidos, "submenuGestionarPedidos");
            this.submenuGestionarPedidos.Click += new System.EventHandler(this.submenuGenerarPedidos_Click);
            // 
            // menuVentas
            // 
            resources.ApplyResources(this.menuVentas, "menuVentas");
            this.menuVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuGestionarVentas});
            this.menuVentas.IconChar = FontAwesome.Sharp.IconChar.SackDollar;
            this.menuVentas.IconColor = System.Drawing.Color.Black;
            this.menuVentas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuVentas.IconSize = 50;
            this.menuVentas.Name = "menuVentas";
            // 
            // submenuGestionarVentas
            // 
            this.submenuGestionarVentas.Name = "submenuGestionarVentas";
            resources.ApplyResources(this.submenuGestionarVentas, "submenuGestionarVentas");
            this.submenuGestionarVentas.Click += new System.EventHandler(this.submenuGestionarVentas_Click);
            // 
            // menuReportes
            // 
            resources.ApplyResources(this.menuReportes, "menuReportes");
            this.menuReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuReportePedidos});
            this.menuReportes.IconChar = FontAwesome.Sharp.IconChar.Signal5;
            this.menuReportes.IconColor = System.Drawing.Color.Black;
            this.menuReportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuReportes.IconSize = 50;
            this.menuReportes.Name = "menuReportes";
            // 
            // submenuReportePedidos
            // 
            this.submenuReportePedidos.Name = "submenuReportePedidos";
            resources.ApplyResources(this.submenuReportePedidos, "submenuReportePedidos");
            this.submenuReportePedidos.Click += new System.EventHandler(this.submenuReporteVentas_Click);
            // 
            // menuUsuario
            // 
            resources.ApplyResources(this.menuUsuario, "menuUsuario");
            this.menuUsuario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuGestionarUsuario});
            this.menuUsuario.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            this.menuUsuario.IconColor = System.Drawing.Color.Black;
            this.menuUsuario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuUsuario.IconSize = 50;
            this.menuUsuario.Name = "menuUsuario";
            // 
            // submenuGestionarUsuario
            // 
            this.submenuGestionarUsuario.Name = "submenuGestionarUsuario";
            resources.ApplyResources(this.submenuGestionarUsuario, "submenuGestionarUsuario");
            this.submenuGestionarUsuario.Click += new System.EventHandler(this.submenuGestionarUsuario_Click);
            // 
            // menuAdministrador
            // 
            resources.ApplyResources(this.menuAdministrador, "menuAdministrador");
            this.menuAdministrador.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuAdministradorUsuarios,
            this.submenuAccesos,
            this.subMenuBackupRestore});
            this.menuAdministrador.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            this.menuAdministrador.IconColor = System.Drawing.Color.Black;
            this.menuAdministrador.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuAdministrador.IconSize = 50;
            this.menuAdministrador.Name = "menuAdministrador";
            // 
            // submenuAdministradorUsuarios
            // 
            this.submenuAdministradorUsuarios.Name = "submenuAdministradorUsuarios";
            resources.ApplyResources(this.submenuAdministradorUsuarios, "submenuAdministradorUsuarios");
            this.submenuAdministradorUsuarios.Click += new System.EventHandler(this.submenuAdministradorUsuarios_Click);
            // 
            // submenuAccesos
            // 
            this.submenuAccesos.Name = "submenuAccesos";
            resources.ApplyResources(this.submenuAccesos, "submenuAccesos");
            this.submenuAccesos.Click += new System.EventHandler(this.submenuAccesos_Click);
            // 
            // subMenuBackupRestore
            // 
            this.subMenuBackupRestore.Name = "subMenuBackupRestore";
            resources.ApplyResources(this.subMenuBackupRestore, "subMenuBackupRestore");
            this.subMenuBackupRestore.Click += new System.EventHandler(this.subMenuBackupRestore_Click);
            // 
            // menuTitulo
            // 
            resources.ApplyResources(this.menuTitulo, "menuTitulo");
            this.menuTitulo.BackColor = System.Drawing.Color.DarkSlateGray;
            this.menuTitulo.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuTitulo.Name = "menuTitulo";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // contenedor
            // 
            this.contenedor.BackColor = System.Drawing.Color.LightGray;
            resources.ApplyResources(this.contenedor, "contenedor");
            this.contenedor.Name = "contenedor";
            // 
            // cmbIdioma
            // 
            this.cmbIdioma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbIdioma, "cmbIdioma");
            this.cmbIdioma.FormattingEnabled = true;
            this.cmbIdioma.Items.AddRange(new object[] {
            resources.GetString("cmbIdioma.Items"),
            resources.GetString("cmbIdioma.Items1")});
            this.cmbIdioma.Name = "cmbIdioma";
            this.cmbIdioma.SelectedIndexChanged += new System.EventHandler(this.cmbIdioma_SelectedIndexChanged);
            // 
            // lblUsuario
            // 
            resources.ApplyResources(this.lblUsuario, "lblUsuario");
            this.lblUsuario.BackColor = System.Drawing.Color.DarkSlateGray;
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Name = "lblUsuario";
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.DarkGray;
            resources.ApplyResources(this.btnLogOut, "btnLogOut");
            this.btnLogOut.ForeColor = System.Drawing.Color.White;
            this.btnLogOut.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            this.btnLogOut.IconColor = System.Drawing.Color.White;
            this.btnLogOut.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLogOut.IconSize = 35;
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click_1);
            // 
            // lblSesión
            // 
            resources.ApplyResources(this.lblSesión, "lblSesión");
            this.lblSesión.BackColor = System.Drawing.Color.DarkSlateGray;
            this.lblSesión.ForeColor = System.Drawing.Color.White;
            this.lblSesión.Name = "lblSesión";
            // 
            // FrmMenu
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSesión);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.cmbIdioma);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.menuTitulo);
            this.Name = "FrmMenu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private FontAwesome.Sharp.IconMenuItem menuClientes;
        private System.Windows.Forms.ToolStripMenuItem submenuGestionarClientes;
        private FontAwesome.Sharp.IconMenuItem menuInventario;
        private System.Windows.Forms.ToolStripMenuItem submenuRecepcionarProductos;
        private FontAwesome.Sharp.IconMenuItem menuPedidos;
        private System.Windows.Forms.ToolStripMenuItem submenuGestionarPedidos;
        private FontAwesome.Sharp.IconMenuItem menuVentas;
        private System.Windows.Forms.ToolStripMenuItem submenuGestionarVentas;
        private FontAwesome.Sharp.IconMenuItem menuReportes;
        private System.Windows.Forms.ToolStripMenuItem submenuReportePedidos;
        private FontAwesome.Sharp.IconMenuItem menuUsuario;
        private System.Windows.Forms.ToolStripMenuItem submenuGestionarUsuario;
        private FontAwesome.Sharp.IconMenuItem menuAdministrador;
        private System.Windows.Forms.ToolStripMenuItem submenuAdministradorUsuarios;
        private System.Windows.Forms.MenuStrip menuTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel contenedor;
        private System.Windows.Forms.ToolStripMenuItem submenuAccesos;
        private System.Windows.Forms.ComboBox cmbIdioma;
        private System.Windows.Forms.ToolStripMenuItem submenuRegistrarProductos;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.ToolStripMenuItem subMenuBackupRestore;
        private FontAwesome.Sharp.IconButton btnLogOut;
        private System.Windows.Forms.Label lblSesión;
    }
}