namespace UI
{
    partial class FmrGestionarPedidos
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSuspender = new FontAwesome.Sharp.IconButton();
            this.btnRegistraPedido = new FontAwesome.Sharp.IconButton();
            this.dgvDetallePedido = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxPedidos = new System.Windows.Forms.GroupBox();
            this.btnActualizarEstado = new FontAwesome.Sharp.IconButton();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.cmbPedido = new System.Windows.Forms.ComboBox();
            this.lblFechaRegistro = new System.Windows.Forms.Label();
            this.btnBuscarPedido = new FontAwesome.Sharp.IconButton();
            this.txtNroPedido = new System.Windows.Forms.TextBox();
            this.lblGUIDPedido = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblDetallePedido = new System.Windows.Forms.Label();
            this.btnLimpiar = new FontAwesome.Sharp.IconButton();
            this.txtTotalPedido = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxProductos = new System.Windows.Forms.GroupBox();
            this.txtReserva = new System.Windows.Forms.TextBox();
            this.lblSinReservar = new System.Windows.Forms.Label();
            this.btnConsultarStock = new FontAwesome.Sharp.IconButton();
            this.txtIdProducto = new System.Windows.Forms.TextBox();
            this.lblSucursal = new System.Windows.Forms.Label();
            this.cmbSucursal = new System.Windows.Forms.ComboBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.btnAgregarProducto = new FontAwesome.Sharp.IconButton();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.numericCantidad = new System.Windows.Forms.NumericUpDown();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.btnBuscarProducto = new FontAwesome.Sharp.IconButton();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.txtCodProducto = new System.Windows.Forms.TextBox();
            this.lblCodProducto = new System.Windows.Forms.Label();
            this.groupBoxClientes = new System.Windows.Forms.GroupBox();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.lblNombreApellido = new System.Windows.Forms.Label();
            this.btnBuscarCliente = new FontAwesome.Sharp.IconButton();
            this.txtNroDocumento = new System.Windows.Forms.TextBox();
            this.lblNroDocumento = new System.Windows.Forms.Label();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.lblGestionarPedidos = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblUsuarioActual = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallePedido)).BeginInit();
            this.groupBoxPedidos.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBoxProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCantidad)).BeginInit();
            this.groupBoxClientes.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSuspender);
            this.panel1.Controls.Add(this.btnRegistraPedido);
            this.panel1.Controls.Add(this.dgvDetallePedido);
            this.panel1.Controls.Add(this.groupBoxPedidos);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnLimpiar);
            this.panel1.Controls.Add(this.txtTotalPedido);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.groupBoxProductos);
            this.panel1.Controls.Add(this.groupBoxClientes);
            this.panel1.Location = new System.Drawing.Point(11, 66);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1868, 691);
            this.panel1.TabIndex = 0;
            // 
            // btnSuspender
            // 
            this.btnSuspender.BackColor = System.Drawing.Color.Red;
            this.btnSuspender.ForeColor = System.Drawing.Color.White;
            this.btnSuspender.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnSuspender.IconColor = System.Drawing.Color.Black;
            this.btnSuspender.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSuspender.Location = new System.Drawing.Point(1073, 541);
            this.btnSuspender.Margin = new System.Windows.Forms.Padding(5);
            this.btnSuspender.Name = "btnSuspender";
            this.btnSuspender.Size = new System.Drawing.Size(410, 49);
            this.btnSuspender.TabIndex = 14;
            this.btnSuspender.Text = "Anular Pedido";
            this.btnSuspender.UseVisualStyleBackColor = false;
            this.btnSuspender.Click += new System.EventHandler(this.btnSuspender_Click);
            // 
            // btnRegistraPedido
            // 
            this.btnRegistraPedido.BackColor = System.Drawing.Color.Green;
            this.btnRegistraPedido.ForeColor = System.Drawing.Color.White;
            this.btnRegistraPedido.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnRegistraPedido.IconColor = System.Drawing.Color.Black;
            this.btnRegistraPedido.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRegistraPedido.Location = new System.Drawing.Point(1073, 481);
            this.btnRegistraPedido.Margin = new System.Windows.Forms.Padding(5);
            this.btnRegistraPedido.Name = "btnRegistraPedido";
            this.btnRegistraPedido.Size = new System.Drawing.Size(410, 49);
            this.btnRegistraPedido.TabIndex = 13;
            this.btnRegistraPedido.Text = "Registrar Pedido";
            this.btnRegistraPedido.UseVisualStyleBackColor = false;
            this.btnRegistraPedido.Click += new System.EventHandler(this.btnRegistraPedido_Click_1);
            // 
            // dgvDetallePedido
            // 
            this.dgvDetallePedido.AllowUserToAddRows = false;
            this.dgvDetallePedido.AllowUserToDeleteRows = false;
            this.dgvDetallePedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetallePedido.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.codigo,
            this.producto,
            this.precio,
            this.cantidad,
            this.subtotal});
            this.dgvDetallePedido.Location = new System.Drawing.Point(6, 360);
            this.dgvDetallePedido.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvDetallePedido.Name = "dgvDetallePedido";
            this.dgvDetallePedido.ReadOnly = true;
            this.dgvDetallePedido.RowHeadersWidth = 51;
            this.dgvDetallePedido.RowTemplate.Height = 24;
            this.dgvDetallePedido.Size = new System.Drawing.Size(944, 315);
            this.dgvDetallePedido.TabIndex = 17;
            // 
            // id
            // 
            this.id.HeaderText = "idProducto";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 125;
            // 
            // codigo
            // 
            this.codigo.HeaderText = "Codigo";
            this.codigo.MinimumWidth = 6;
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.codigo.Width = 125;
            // 
            // producto
            // 
            this.producto.HeaderText = "Producto";
            this.producto.MinimumWidth = 6;
            this.producto.Name = "producto";
            this.producto.ReadOnly = true;
            this.producto.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.producto.Width = 200;
            // 
            // precio
            // 
            this.precio.HeaderText = "Precio";
            this.precio.MinimumWidth = 6;
            this.precio.Name = "precio";
            this.precio.ReadOnly = true;
            this.precio.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.precio.Width = 125;
            // 
            // cantidad
            // 
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.MinimumWidth = 6;
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            this.cantidad.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cantidad.Width = 125;
            // 
            // subtotal
            // 
            this.subtotal.HeaderText = "Subtotal";
            this.subtotal.MinimumWidth = 6;
            this.subtotal.Name = "subtotal";
            this.subtotal.ReadOnly = true;
            this.subtotal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.subtotal.Width = 125;
            // 
            // groupBoxPedidos
            // 
            this.groupBoxPedidos.BackColor = System.Drawing.Color.DarkCyan;
            this.groupBoxPedidos.Controls.Add(this.btnActualizarEstado);
            this.groupBoxPedidos.Controls.Add(this.lblEstado);
            this.groupBoxPedidos.Controls.Add(this.txtFechaRegistro);
            this.groupBoxPedidos.Controls.Add(this.cmbPedido);
            this.groupBoxPedidos.Controls.Add(this.lblFechaRegistro);
            this.groupBoxPedidos.Controls.Add(this.btnBuscarPedido);
            this.groupBoxPedidos.Controls.Add(this.txtNroPedido);
            this.groupBoxPedidos.Controls.Add(this.lblGUIDPedido);
            this.groupBoxPedidos.ForeColor = System.Drawing.Color.White;
            this.groupBoxPedidos.Location = new System.Drawing.Point(6, 5);
            this.groupBoxPedidos.Margin = new System.Windows.Forms.Padding(5);
            this.groupBoxPedidos.Name = "groupBoxPedidos";
            this.groupBoxPedidos.Padding = new System.Windows.Forms.Padding(5);
            this.groupBoxPedidos.Size = new System.Drawing.Size(1854, 89);
            this.groupBoxPedidos.TabIndex = 14;
            this.groupBoxPedidos.TabStop = false;
            this.groupBoxPedidos.Text = "Buscar Pedido:";
            // 
            // btnActualizarEstado
            // 
            this.btnActualizarEstado.BackColor = System.Drawing.Color.Gray;
            this.btnActualizarEstado.ForeColor = System.Drawing.Color.White;
            this.btnActualizarEstado.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnActualizarEstado.IconColor = System.Drawing.Color.Black;
            this.btnActualizarEstado.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnActualizarEstado.Location = new System.Drawing.Point(1361, 26);
            this.btnActualizarEstado.Margin = new System.Windows.Forms.Padding(5);
            this.btnActualizarEstado.Name = "btnActualizarEstado";
            this.btnActualizarEstado.Size = new System.Drawing.Size(190, 31);
            this.btnActualizarEstado.TabIndex = 27;
            this.btnActualizarEstado.Text = "Actualizar";
            this.btnActualizarEstado.UseVisualStyleBackColor = false;
            this.btnActualizarEstado.Click += new System.EventHandler(this.btnActualizarEstado_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.ForeColor = System.Drawing.Color.White;
            this.lblEstado.Location = new System.Drawing.Point(1037, 34);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(66, 20);
            this.lblEstado.TabIndex = 25;
            this.lblEstado.Text = "Estado:";
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Location = new System.Drawing.Point(791, 30);
            this.txtFechaRegistro.Margin = new System.Windows.Forms.Padding(5);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(218, 26);
            this.txtFechaRegistro.TabIndex = 13;
            // 
            // cmbPedido
            // 
            this.cmbPedido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPedido.FormattingEnabled = true;
            this.cmbPedido.Location = new System.Drawing.Point(1125, 28);
            this.cmbPedido.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbPedido.Name = "cmbPedido";
            this.cmbPedido.Size = new System.Drawing.Size(214, 28);
            this.cmbPedido.TabIndex = 24;
            // 
            // lblFechaRegistro
            // 
            this.lblFechaRegistro.AutoSize = true;
            this.lblFechaRegistro.ForeColor = System.Drawing.Color.White;
            this.lblFechaRegistro.Location = new System.Drawing.Point(616, 34);
            this.lblFechaRegistro.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblFechaRegistro.Name = "lblFechaRegistro";
            this.lblFechaRegistro.Size = new System.Drawing.Size(128, 20);
            this.lblFechaRegistro.TabIndex = 12;
            this.lblFechaRegistro.Text = "Fecha Registro:";
            // 
            // btnBuscarPedido
            // 
            this.btnBuscarPedido.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnBuscarPedido.IconColor = System.Drawing.Color.Black;
            this.btnBuscarPedido.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscarPedido.IconSize = 15;
            this.btnBuscarPedido.Location = new System.Drawing.Point(457, 31);
            this.btnBuscarPedido.Margin = new System.Windows.Forms.Padding(5);
            this.btnBuscarPedido.Name = "btnBuscarPedido";
            this.btnBuscarPedido.Size = new System.Drawing.Size(131, 29);
            this.btnBuscarPedido.TabIndex = 2;
            this.btnBuscarPedido.UseVisualStyleBackColor = true;
            this.btnBuscarPedido.Click += new System.EventHandler(this.btnBuscarPedido_Click);
            // 
            // txtNroPedido
            // 
            this.txtNroPedido.Enabled = false;
            this.txtNroPedido.Location = new System.Drawing.Point(157, 32);
            this.txtNroPedido.Margin = new System.Windows.Forms.Padding(5);
            this.txtNroPedido.Name = "txtNroPedido";
            this.txtNroPedido.Size = new System.Drawing.Size(289, 26);
            this.txtNroPedido.TabIndex = 1;
            // 
            // lblGUIDPedido
            // 
            this.lblGUIDPedido.AutoSize = true;
            this.lblGUIDPedido.ForeColor = System.Drawing.Color.White;
            this.lblGUIDPedido.Location = new System.Drawing.Point(27, 35);
            this.lblGUIDPedido.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblGUIDPedido.Name = "lblGUIDPedido";
            this.lblGUIDPedido.Size = new System.Drawing.Size(101, 20);
            this.lblGUIDPedido.TabIndex = 10;
            this.lblGUIDPedido.Text = "Nro. Pedido:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel3.Controls.Add(this.lblDetallePedido);
            this.panel3.Location = new System.Drawing.Point(5, 317);
            this.panel3.Margin = new System.Windows.Forms.Padding(5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(945, 35);
            this.panel3.TabIndex = 2;
            // 
            // lblDetallePedido
            // 
            this.lblDetallePedido.AutoSize = true;
            this.lblDetallePedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetallePedido.ForeColor = System.Drawing.Color.White;
            this.lblDetallePedido.Location = new System.Drawing.Point(364, 7);
            this.lblDetallePedido.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDetallePedido.Name = "lblDetallePedido";
            this.lblDetallePedido.Size = new System.Drawing.Size(158, 20);
            this.lblDetallePedido.TabIndex = 0;
            this.lblDetallePedido.Text = "Detalle de Pedido";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Silver;
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnLimpiar.IconColor = System.Drawing.Color.Black;
            this.btnLimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiar.Location = new System.Drawing.Point(1073, 599);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(5);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(410, 49);
            this.btnLimpiar.TabIndex = 15;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // txtTotalPedido
            // 
            this.txtTotalPedido.Enabled = false;
            this.txtTotalPedido.Location = new System.Drawing.Point(1193, 410);
            this.txtTotalPedido.Margin = new System.Windows.Forms.Padding(5);
            this.txtTotalPedido.Name = "txtTotalPedido";
            this.txtTotalPedido.Size = new System.Drawing.Size(289, 26);
            this.txtTotalPedido.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1067, 401);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Total:";
            // 
            // groupBoxProductos
            // 
            this.groupBoxProductos.BackColor = System.Drawing.Color.DarkSlateGray;
            this.groupBoxProductos.Controls.Add(this.txtReserva);
            this.groupBoxProductos.Controls.Add(this.lblSinReservar);
            this.groupBoxProductos.Controls.Add(this.btnConsultarStock);
            this.groupBoxProductos.Controls.Add(this.txtIdProducto);
            this.groupBoxProductos.Controls.Add(this.lblSucursal);
            this.groupBoxProductos.Controls.Add(this.cmbSucursal);
            this.groupBoxProductos.Controls.Add(this.txtStock);
            this.groupBoxProductos.Controls.Add(this.lblStock);
            this.groupBoxProductos.Controls.Add(this.btnAgregarProducto);
            this.groupBoxProductos.Controls.Add(this.lblCantidad);
            this.groupBoxProductos.Controls.Add(this.numericCantidad);
            this.groupBoxProductos.Controls.Add(this.txtPrecio);
            this.groupBoxProductos.Controls.Add(this.lblPrecio);
            this.groupBoxProductos.Controls.Add(this.btnBuscarProducto);
            this.groupBoxProductos.Controls.Add(this.txtProducto);
            this.groupBoxProductos.Controls.Add(this.lblProducto);
            this.groupBoxProductos.Controls.Add(this.txtCodProducto);
            this.groupBoxProductos.Controls.Add(this.lblCodProducto);
            this.groupBoxProductos.ForeColor = System.Drawing.Color.White;
            this.groupBoxProductos.Location = new System.Drawing.Point(7, 192);
            this.groupBoxProductos.Margin = new System.Windows.Forms.Padding(5);
            this.groupBoxProductos.Name = "groupBoxProductos";
            this.groupBoxProductos.Padding = new System.Windows.Forms.Padding(5);
            this.groupBoxProductos.Size = new System.Drawing.Size(1852, 117);
            this.groupBoxProductos.TabIndex = 2;
            this.groupBoxProductos.TabStop = false;
            this.groupBoxProductos.Text = "Datos del Producto:";
            // 
            // txtReserva
            // 
            this.txtReserva.Enabled = false;
            this.txtReserva.Location = new System.Drawing.Point(1160, 71);
            this.txtReserva.Margin = new System.Windows.Forms.Padding(5);
            this.txtReserva.Name = "txtReserva";
            this.txtReserva.Size = new System.Drawing.Size(118, 26);
            this.txtReserva.TabIndex = 26;
            // 
            // lblSinReservar
            // 
            this.lblSinReservar.AutoSize = true;
            this.lblSinReservar.ForeColor = System.Drawing.Color.White;
            this.lblSinReservar.Location = new System.Drawing.Point(1027, 71);
            this.lblSinReservar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSinReservar.Name = "lblSinReservar";
            this.lblSinReservar.Size = new System.Drawing.Size(111, 20);
            this.lblSinReservar.TabIndex = 25;
            this.lblSinReservar.Text = "Sin Reservar:";
            // 
            // btnConsultarStock
            // 
            this.btnConsultarStock.BackColor = System.Drawing.Color.Gray;
            this.btnConsultarStock.ForeColor = System.Drawing.Color.White;
            this.btnConsultarStock.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnConsultarStock.IconColor = System.Drawing.Color.Black;
            this.btnConsultarStock.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnConsultarStock.Location = new System.Drawing.Point(1319, 49);
            this.btnConsultarStock.Margin = new System.Windows.Forms.Padding(5);
            this.btnConsultarStock.Name = "btnConsultarStock";
            this.btnConsultarStock.Size = new System.Drawing.Size(119, 31);
            this.btnConsultarStock.TabIndex = 11;
            this.btnConsultarStock.Text = "Consultar";
            this.btnConsultarStock.UseVisualStyleBackColor = false;
            this.btnConsultarStock.Click += new System.EventHandler(this.btnConsultarStock_Click);
            // 
            // txtIdProducto
            // 
            this.txtIdProducto.Location = new System.Drawing.Point(486, 30);
            this.txtIdProducto.Margin = new System.Windows.Forms.Padding(5);
            this.txtIdProducto.Name = "txtIdProducto";
            this.txtIdProducto.Size = new System.Drawing.Size(23, 26);
            this.txtIdProducto.TabIndex = 24;
            this.txtIdProducto.Visible = false;
            // 
            // lblSucursal
            // 
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.ForeColor = System.Drawing.Color.White;
            this.lblSucursal.Location = new System.Drawing.Point(786, 34);
            this.lblSucursal.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(80, 20);
            this.lblSucursal.TabIndex = 23;
            this.lblSucursal.Text = "Sucursal:";
            // 
            // cmbSucursal
            // 
            this.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSucursal.FormattingEnabled = true;
            this.cmbSucursal.Location = new System.Drawing.Point(790, 61);
            this.cmbSucursal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbSucursal.Name = "cmbSucursal";
            this.cmbSucursal.Size = new System.Drawing.Size(214, 28);
            this.cmbSucursal.TabIndex = 10;
            // 
            // txtStock
            // 
            this.txtStock.Enabled = false;
            this.txtStock.Location = new System.Drawing.Point(1160, 30);
            this.txtStock.Margin = new System.Windows.Forms.Padding(5);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(118, 26);
            this.txtStock.TabIndex = 21;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.ForeColor = System.Drawing.Color.White;
            this.lblStock.Location = new System.Drawing.Point(1083, 37);
            this.lblStock.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(56, 20);
            this.lblStock.TabIndex = 20;
            this.lblStock.Text = "Stock:";
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnAgregarProducto.IconColor = System.Drawing.Color.Black;
            this.btnAgregarProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAgregarProducto.IconSize = 20;
            this.btnAgregarProducto.Location = new System.Drawing.Point(1475, 49);
            this.btnAgregarProducto.Margin = new System.Windows.Forms.Padding(5);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(90, 31);
            this.btnAgregarProducto.TabIndex = 12;
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.ForeColor = System.Drawing.Color.White;
            this.lblCantidad.Location = new System.Drawing.Point(503, 71);
            this.lblCantidad.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(80, 20);
            this.lblCantidad.TabIndex = 19;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // numericCantidad
            // 
            this.numericCantidad.Location = new System.Drawing.Point(615, 69);
            this.numericCantidad.Margin = new System.Windows.Forms.Padding(5);
            this.numericCantidad.Name = "numericCantidad";
            this.numericCantidad.Size = new System.Drawing.Size(119, 26);
            this.numericCantidad.TabIndex = 9;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(615, 29);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(5);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(118, 26);
            this.txtPrecio.TabIndex = 8;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.ForeColor = System.Drawing.Color.White;
            this.lblPrecio.Location = new System.Drawing.Point(520, 34);
            this.lblPrecio.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(62, 20);
            this.lblPrecio.TabIndex = 10;
            this.lblPrecio.Text = "Precio:";
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnBuscarProducto.IconColor = System.Drawing.Color.Black;
            this.btnBuscarProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscarProducto.IconSize = 15;
            this.btnBuscarProducto.Location = new System.Drawing.Point(337, 30);
            this.btnBuscarProducto.Margin = new System.Windows.Forms.Padding(5);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(131, 28);
            this.btnBuscarProducto.TabIndex = 6;
            this.btnBuscarProducto.UseVisualStyleBackColor = true;
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // txtProducto
            // 
            this.txtProducto.Enabled = false;
            this.txtProducto.Location = new System.Drawing.Point(165, 68);
            this.txtProducto.Margin = new System.Windows.Forms.Padding(5);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(303, 26);
            this.txtProducto.TabIndex = 7;
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.ForeColor = System.Drawing.Color.White;
            this.lblProducto.Location = new System.Drawing.Point(10, 71);
            this.lblProducto.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(81, 20);
            this.lblProducto.TabIndex = 16;
            this.lblProducto.Text = "Producto:";
            // 
            // txtCodProducto
            // 
            this.txtCodProducto.Enabled = false;
            this.txtCodProducto.Location = new System.Drawing.Point(165, 29);
            this.txtCodProducto.Margin = new System.Windows.Forms.Padding(5);
            this.txtCodProducto.Name = "txtCodProducto";
            this.txtCodProducto.Size = new System.Drawing.Size(161, 26);
            this.txtCodProducto.TabIndex = 5;
            // 
            // lblCodProducto
            // 
            this.lblCodProducto.AutoSize = true;
            this.lblCodProducto.ForeColor = System.Drawing.Color.White;
            this.lblCodProducto.Location = new System.Drawing.Point(10, 30);
            this.lblCodProducto.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodProducto.Name = "lblCodProducto";
            this.lblCodProducto.Size = new System.Drawing.Size(138, 20);
            this.lblCodProducto.TabIndex = 14;
            this.lblCodProducto.Text = "Codigo Producto:";
            // 
            // groupBoxClientes
            // 
            this.groupBoxClientes.BackColor = System.Drawing.Color.DarkSlateGray;
            this.groupBoxClientes.Controls.Add(this.txtNombreCliente);
            this.groupBoxClientes.Controls.Add(this.lblNombreApellido);
            this.groupBoxClientes.Controls.Add(this.btnBuscarCliente);
            this.groupBoxClientes.Controls.Add(this.txtNroDocumento);
            this.groupBoxClientes.Controls.Add(this.lblNroDocumento);
            this.groupBoxClientes.Controls.Add(this.txtIdCliente);
            this.groupBoxClientes.ForeColor = System.Drawing.Color.White;
            this.groupBoxClientes.Location = new System.Drawing.Point(6, 99);
            this.groupBoxClientes.Margin = new System.Windows.Forms.Padding(5);
            this.groupBoxClientes.Name = "groupBoxClientes";
            this.groupBoxClientes.Padding = new System.Windows.Forms.Padding(5);
            this.groupBoxClientes.Size = new System.Drawing.Size(1854, 89);
            this.groupBoxClientes.TabIndex = 1;
            this.groupBoxClientes.TabStop = false;
            this.groupBoxClientes.Text = "Datos del Cliente:";
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Enabled = false;
            this.txtNombreCliente.Location = new System.Drawing.Point(947, 37);
            this.txtNombreCliente.Margin = new System.Windows.Forms.Padding(5);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(391, 26);
            this.txtNombreCliente.TabIndex = 13;
            // 
            // lblNombreApellido
            // 
            this.lblNombreApellido.AutoSize = true;
            this.lblNombreApellido.ForeColor = System.Drawing.Color.White;
            this.lblNombreApellido.Location = new System.Drawing.Point(691, 41);
            this.lblNombreApellido.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblNombreApellido.Name = "lblNombreApellido";
            this.lblNombreApellido.Size = new System.Drawing.Size(150, 20);
            this.lblNombreApellido.TabIndex = 12;
            this.lblNombreApellido.Text = "Nombre y Apellido:";
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnBuscarCliente.IconColor = System.Drawing.Color.Black;
            this.btnBuscarCliente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscarCliente.IconSize = 15;
            this.btnBuscarCliente.Location = new System.Drawing.Point(495, 35);
            this.btnBuscarCliente.Margin = new System.Windows.Forms.Padding(5);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(131, 26);
            this.btnBuscarCliente.TabIndex = 4;
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // txtNroDocumento
            // 
            this.txtNroDocumento.Enabled = false;
            this.txtNroDocumento.Location = new System.Drawing.Point(224, 34);
            this.txtNroDocumento.Margin = new System.Windows.Forms.Padding(5);
            this.txtNroDocumento.Name = "txtNroDocumento";
            this.txtNroDocumento.Size = new System.Drawing.Size(260, 26);
            this.txtNroDocumento.TabIndex = 3;
            // 
            // lblNroDocumento
            // 
            this.lblNroDocumento.AutoSize = true;
            this.lblNroDocumento.ForeColor = System.Drawing.Color.White;
            this.lblNroDocumento.Location = new System.Drawing.Point(11, 37);
            this.lblNroDocumento.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblNroDocumento.Name = "lblNroDocumento";
            this.lblNroDocumento.Size = new System.Drawing.Size(136, 20);
            this.lblNroDocumento.TabIndex = 10;
            this.lblNroDocumento.Text = "Nro. Documento:";
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Enabled = false;
            this.txtIdCliente.Location = new System.Drawing.Point(1399, 37);
            this.txtIdCliente.Margin = new System.Windows.Forms.Padding(5);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(167, 26);
            this.txtIdCliente.TabIndex = 0;
            this.txtIdCliente.Visible = false;
            // 
            // lblGestionarPedidos
            // 
            this.lblGestionarPedidos.AutoSize = true;
            this.lblGestionarPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGestionarPedidos.ForeColor = System.Drawing.Color.White;
            this.lblGestionarPedidos.Location = new System.Drawing.Point(17, 6);
            this.lblGestionarPedidos.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblGestionarPedidos.Name = "lblGestionarPedidos";
            this.lblGestionarPedidos.Size = new System.Drawing.Size(221, 29);
            this.lblGestionarPedidos.TabIndex = 0;
            this.lblGestionarPedidos.Text = "Gestionar Pedidos";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel2.Controls.Add(this.lblUsuarioActual);
            this.panel2.Controls.Add(this.lblGestionarPedidos);
            this.panel2.Location = new System.Drawing.Point(11, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1867, 52);
            this.panel2.TabIndex = 1;
            // 
            // lblUsuarioActual
            // 
            this.lblUsuarioActual.AutoSize = true;
            this.lblUsuarioActual.Location = new System.Drawing.Point(1466, 15);
            this.lblUsuarioActual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuarioActual.Name = "lblUsuarioActual";
            this.lblUsuarioActual.Size = new System.Drawing.Size(64, 20);
            this.lblUsuarioActual.TabIndex = 1;
            this.lblUsuarioActual.Text = "usuario";
            this.lblUsuarioActual.Visible = false;
            // 
            // FmrGestionarPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1884, 761);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FmrGestionarPedidos";
            this.Text = "FmrGestionarPedidos";
            this.Load += new System.EventHandler(this.FmrGenerarPedidos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallePedido)).EndInit();
            this.groupBoxPedidos.ResumeLayout(false);
            this.groupBoxPedidos.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBoxProductos.ResumeLayout(false);
            this.groupBoxProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCantidad)).EndInit();
            this.groupBoxClientes.ResumeLayout(false);
            this.groupBoxClientes.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTotalPedido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxProductos;
        private System.Windows.Forms.GroupBox groupBoxClientes;
        private System.Windows.Forms.Label lblGestionarPedidos;
        private FontAwesome.Sharp.IconButton btnLimpiar;
        private FontAwesome.Sharp.IconButton btnAgregarProducto;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Label lblNombreApellido;
        private FontAwesome.Sharp.IconButton btnBuscarCliente;
        private System.Windows.Forms.TextBox txtNroDocumento;
        private System.Windows.Forms.Label lblNroDocumento;
        private System.Windows.Forms.TextBox txtIdCliente;
        private FontAwesome.Sharp.IconButton btnBuscarProducto;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.TextBox txtCodProducto;
        private System.Windows.Forms.Label lblCodProducto;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown numericCantidad;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblDetallePedido;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBoxPedidos;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.ComboBox cmbPedido;
        private System.Windows.Forms.Label lblFechaRegistro;
        private FontAwesome.Sharp.IconButton btnBuscarPedido;
        private System.Windows.Forms.TextBox txtNroPedido;
        private System.Windows.Forms.Label lblGUIDPedido;
        private System.Windows.Forms.Label lblSucursal;
        private System.Windows.Forms.ComboBox cmbSucursal;
        private System.Windows.Forms.TextBox txtIdProducto;
        private FontAwesome.Sharp.IconButton btnConsultarStock;
        private System.Windows.Forms.DataGridView dgvDetallePedido;
        private System.Windows.Forms.TextBox txtReserva;
        private System.Windows.Forms.Label lblSinReservar;
        private System.Windows.Forms.Label lblUsuarioActual;
        private FontAwesome.Sharp.IconButton btnRegistraPedido;
        private FontAwesome.Sharp.IconButton btnSuspender;
        private FontAwesome.Sharp.IconButton btnActualizarEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotal;
    }
}