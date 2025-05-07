namespace UI
{
    partial class FmrGestionarVentas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblGestionarVenta = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNroVenta = new System.Windows.Forms.TextBox();
            this.cmbEstadoVenta = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnBuscarVenta = new FontAwesome.Sharp.IconButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNroPedido = new System.Windows.Forms.TextBox();
            this.txtIdVentaBuscador = new System.Windows.Forms.TextBox();
            this.lblIdentificadorVenta = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtIdEmpleado = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.lblFechaRegistro = new System.Windows.Forms.Label();
            this.dateTimePickerFechaRegistro = new System.Windows.Forms.DateTimePicker();
            this.btnCalcularTotal = new FontAwesome.Sharp.IconButton();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.lblValorFlete = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.btnLimpiarCampos = new FontAwesome.Sharp.IconButton();
            this.btnBuscarProducto = new FontAwesome.Sharp.IconButton();
            this.txtIdPedido = new System.Windows.Forms.TextBox();
            this.lblIdentificadorPedido = new System.Windows.Forms.Label();
            this.lblDetallePedido = new System.Windows.Forms.Label();
            this.btnAnularVenta = new FontAwesome.Sharp.IconButton();
            this.btnRegistrarVenta = new FontAwesome.Sharp.IconButton();
            this.dgvDetallePedido = new System.Windows.Forms.DataGridView();
            this.idProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtValorFlete = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallePedido)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel2.Controls.Add(this.lblGestionarVenta);
            this.panel2.Location = new System.Drawing.Point(5, 5);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1876, 52);
            this.panel2.TabIndex = 7;
            // 
            // lblGestionarVenta
            // 
            this.lblGestionarVenta.AutoSize = true;
            this.lblGestionarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGestionarVenta.ForeColor = System.Drawing.Color.White;
            this.lblGestionarVenta.Location = new System.Drawing.Point(6, 6);
            this.lblGestionarVenta.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblGestionarVenta.Name = "lblGestionarVenta";
            this.lblGestionarVenta.Size = new System.Drawing.Size(195, 29);
            this.lblGestionarVenta.TabIndex = 0;
            this.lblGestionarVenta.Text = "Gestionar Venta";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(5, 66);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1876, 748);
            this.panel1.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.groupBox2.Controls.Add(this.txtNroVenta);
            this.groupBox2.Controls.Add(this.cmbEstadoVenta);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblEstado);
            this.groupBox2.Controls.Add(this.btnBuscarVenta);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(4, 5);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(1865, 75);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtro de Búsqueda:";
            // 
            // txtNroVenta
            // 
            this.txtNroVenta.Enabled = false;
            this.txtNroVenta.Location = new System.Drawing.Point(296, 23);
            this.txtNroVenta.Margin = new System.Windows.Forms.Padding(5);
            this.txtNroVenta.Name = "txtNroVenta";
            this.txtNroVenta.Size = new System.Drawing.Size(331, 26);
            this.txtNroVenta.TabIndex = 17;
            // 
            // cmbEstadoVenta
            // 
            this.cmbEstadoVenta.Enabled = false;
            this.cmbEstadoVenta.FormattingEnabled = true;
            this.cmbEstadoVenta.Location = new System.Drawing.Point(1341, 23);
            this.cmbEstadoVenta.Margin = new System.Windows.Forms.Padding(5);
            this.cmbEstadoVenta.Name = "cmbEstadoVenta";
            this.cmbEstadoVenta.Size = new System.Drawing.Size(249, 28);
            this.cmbEstadoVenta.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(39, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Nro. de Venta:";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.ForeColor = System.Drawing.Color.White;
            this.lblEstado.Location = new System.Drawing.Point(1229, 29);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(66, 20);
            this.lblEstado.TabIndex = 14;
            this.lblEstado.Text = "Estado:";
            // 
            // btnBuscarVenta
            // 
            this.btnBuscarVenta.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnBuscarVenta.IconColor = System.Drawing.Color.Black;
            this.btnBuscarVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscarVenta.IconSize = 15;
            this.btnBuscarVenta.Location = new System.Drawing.Point(680, 23);
            this.btnBuscarVenta.Margin = new System.Windows.Forms.Padding(5);
            this.btnBuscarVenta.Name = "btnBuscarVenta";
            this.btnBuscarVenta.Size = new System.Drawing.Size(131, 28);
            this.btnBuscarVenta.TabIndex = 10;
            this.btnBuscarVenta.UseVisualStyleBackColor = true;
            this.btnBuscarVenta.Click += new System.EventHandler(this.btnBuscarVenta_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.groupBox1.Controls.Add(this.txtNroPedido);
            this.groupBox1.Controls.Add(this.txtIdVentaBuscador);
            this.groupBox1.Controls.Add(this.lblIdentificadorVenta);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtIdEmpleado);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtIdCliente);
            this.groupBox1.Controls.Add(this.lblFechaRegistro);
            this.groupBox1.Controls.Add(this.dateTimePickerFechaRegistro);
            this.groupBox1.Controls.Add(this.btnCalcularTotal);
            this.groupBox1.Controls.Add(this.lblValorTotal);
            this.groupBox1.Controls.Add(this.txtValorTotal);
            this.groupBox1.Controls.Add(this.lblValorFlete);
            this.groupBox1.Controls.Add(this.txtCliente);
            this.groupBox1.Controls.Add(this.lblCliente);
            this.groupBox1.Controls.Add(this.btnLimpiarCampos);
            this.groupBox1.Controls.Add(this.btnBuscarProducto);
            this.groupBox1.Controls.Add(this.txtIdPedido);
            this.groupBox1.Controls.Add(this.lblIdentificadorPedido);
            this.groupBox1.Controls.Add(this.lblDetallePedido);
            this.groupBox1.Controls.Add(this.btnAnularVenta);
            this.groupBox1.Controls.Add(this.btnRegistrarVenta);
            this.groupBox1.Controls.Add(this.dgvDetallePedido);
            this.groupBox1.Controls.Add(this.txtValorFlete);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(5, 90);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(1867, 601);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Venta:";
            // 
            // txtNroPedido
            // 
            this.txtNroPedido.Enabled = false;
            this.txtNroPedido.Location = new System.Drawing.Point(254, 206);
            this.txtNroPedido.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.txtNroPedido.Name = "txtNroPedido";
            this.txtNroPedido.Size = new System.Drawing.Size(331, 26);
            this.txtNroPedido.TabIndex = 57;
            // 
            // txtIdVentaBuscador
            // 
            this.txtIdVentaBuscador.Enabled = false;
            this.txtIdVentaBuscador.Location = new System.Drawing.Point(294, 44);
            this.txtIdVentaBuscador.Margin = new System.Windows.Forms.Padding(5);
            this.txtIdVentaBuscador.Name = "txtIdVentaBuscador";
            this.txtIdVentaBuscador.Size = new System.Drawing.Size(331, 26);
            this.txtIdVentaBuscador.TabIndex = 11;
            this.txtIdVentaBuscador.Visible = false;
            // 
            // lblIdentificadorVenta
            // 
            this.lblIdentificadorVenta.AutoSize = true;
            this.lblIdentificadorVenta.ForeColor = System.Drawing.Color.White;
            this.lblIdentificadorVenta.Location = new System.Drawing.Point(37, 51);
            this.lblIdentificadorVenta.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblIdentificadorVenta.Name = "lblIdentificadorVenta";
            this.lblIdentificadorVenta.Size = new System.Drawing.Size(176, 20);
            this.lblIdentificadorVenta.TabIndex = 10;
            this.lblIdentificadorVenta.Text = "Identificador de Venta:";
            this.lblIdentificadorVenta.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(250, 177);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 56;
            this.label1.Text = "Nro. de Pedido:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(615, 102);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 20);
            this.label13.TabIndex = 55;
            this.label13.Text = "id Empleado:";
            this.label13.Visible = false;
            // 
            // txtIdEmpleado
            // 
            this.txtIdEmpleado.Location = new System.Drawing.Point(619, 126);
            this.txtIdEmpleado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIdEmpleado.Name = "txtIdEmpleado";
            this.txtIdEmpleado.Size = new System.Drawing.Size(173, 26);
            this.txtIdEmpleado.TabIndex = 54;
            this.txtIdEmpleado.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(409, 102);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 53;
            this.label5.Text = "id Cliente:";
            this.label5.Visible = false;
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Location = new System.Drawing.Point(413, 126);
            this.txtIdCliente.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(173, 26);
            this.txtIdCliente.TabIndex = 52;
            this.txtIdCliente.Visible = false;
            // 
            // lblFechaRegistro
            // 
            this.lblFechaRegistro.AutoSize = true;
            this.lblFechaRegistro.ForeColor = System.Drawing.Color.White;
            this.lblFechaRegistro.Location = new System.Drawing.Point(250, 490);
            this.lblFechaRegistro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaRegistro.Name = "lblFechaRegistro";
            this.lblFechaRegistro.Size = new System.Drawing.Size(128, 20);
            this.lblFechaRegistro.TabIndex = 50;
            this.lblFechaRegistro.Text = "Fecha Registro:";
            // 
            // dateTimePickerFechaRegistro
            // 
            this.dateTimePickerFechaRegistro.Location = new System.Drawing.Point(254, 513);
            this.dateTimePickerFechaRegistro.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateTimePickerFechaRegistro.Name = "dateTimePickerFechaRegistro";
            this.dateTimePickerFechaRegistro.Size = new System.Drawing.Size(331, 26);
            this.dateTimePickerFechaRegistro.TabIndex = 49;
            // 
            // btnCalcularTotal
            // 
            this.btnCalcularTotal.BackColor = System.Drawing.Color.Silver;
            this.btnCalcularTotal.ForeColor = System.Drawing.Color.White;
            this.btnCalcularTotal.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnCalcularTotal.IconColor = System.Drawing.Color.Black;
            this.btnCalcularTotal.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCalcularTotal.Location = new System.Drawing.Point(254, 437);
            this.btnCalcularTotal.Margin = new System.Windows.Forms.Padding(5);
            this.btnCalcularTotal.Name = "btnCalcularTotal";
            this.btnCalcularTotal.Size = new System.Drawing.Size(333, 31);
            this.btnCalcularTotal.TabIndex = 48;
            this.btnCalcularTotal.Text = "Calcular";
            this.btnCalcularTotal.UseVisualStyleBackColor = false;
            this.btnCalcularTotal.Click += new System.EventHandler(this.btnCalcularTotal_Click);
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.ForeColor = System.Drawing.Color.White;
            this.lblValorTotal.Location = new System.Drawing.Point(250, 375);
            this.lblValorTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(95, 20);
            this.lblValorTotal.TabIndex = 47;
            this.lblValorTotal.Text = "Valor Total:";
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Location = new System.Drawing.Point(254, 399);
            this.txtValorTotal.Margin = new System.Windows.Forms.Padding(5);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Size = new System.Drawing.Size(331, 26);
            this.txtValorTotal.TabIndex = 46;
            // 
            // lblValorFlete
            // 
            this.lblValorFlete.AutoSize = true;
            this.lblValorFlete.ForeColor = System.Drawing.Color.White;
            this.lblValorFlete.Location = new System.Drawing.Point(250, 308);
            this.lblValorFlete.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValorFlete.Name = "lblValorFlete";
            this.lblValorFlete.Size = new System.Drawing.Size(95, 20);
            this.lblValorFlete.TabIndex = 45;
            this.lblValorFlete.Text = "Valor Flete:";
            // 
            // txtCliente
            // 
            this.txtCliente.Enabled = false;
            this.txtCliente.Location = new System.Drawing.Point(254, 268);
            this.txtCliente.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(331, 26);
            this.txtCliente.TabIndex = 42;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.ForeColor = System.Drawing.Color.White;
            this.lblCliente.Location = new System.Drawing.Point(250, 241);
            this.lblCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(66, 20);
            this.lblCliente.TabIndex = 41;
            this.lblCliente.Text = "Cliente:";
            // 
            // btnLimpiarCampos
            // 
            this.btnLimpiarCampos.ForeColor = System.Drawing.Color.Black;
            this.btnLimpiarCampos.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnLimpiarCampos.IconColor = System.Drawing.Color.Black;
            this.btnLimpiarCampos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiarCampos.IconSize = 15;
            this.btnLimpiarCampos.Location = new System.Drawing.Point(633, 286);
            this.btnLimpiarCampos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLimpiarCampos.Name = "btnLimpiarCampos";
            this.btnLimpiarCampos.Size = new System.Drawing.Size(194, 57);
            this.btnLimpiarCampos.TabIndex = 39;
            this.btnLimpiarCampos.Text = "Limpiar campos";
            this.btnLimpiarCampos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLimpiarCampos.UseVisualStyleBackColor = true;
            this.btnLimpiarCampos.Click += new System.EventHandler(this.btnLimpiarCampos_Click);
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarProducto.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnBuscarProducto.IconColor = System.Drawing.Color.Black;
            this.btnBuscarProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscarProducto.IconSize = 15;
            this.btnBuscarProducto.Location = new System.Drawing.Point(633, 184);
            this.btnBuscarProducto.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(194, 60);
            this.btnBuscarProducto.TabIndex = 38;
            this.btnBuscarProducto.Text = "Buscar Pedido\r\n";
            this.btnBuscarProducto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscarProducto.UseVisualStyleBackColor = true;
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // txtIdPedido
            // 
            this.txtIdPedido.Enabled = false;
            this.txtIdPedido.Location = new System.Drawing.Point(37, 126);
            this.txtIdPedido.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.txtIdPedido.Name = "txtIdPedido";
            this.txtIdPedido.Size = new System.Drawing.Size(331, 26);
            this.txtIdPedido.TabIndex = 31;
            this.txtIdPedido.Visible = false;
            // 
            // lblIdentificadorPedido
            // 
            this.lblIdentificadorPedido.AutoSize = true;
            this.lblIdentificadorPedido.ForeColor = System.Drawing.Color.White;
            this.lblIdentificadorPedido.Location = new System.Drawing.Point(33, 97);
            this.lblIdentificadorPedido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdentificadorPedido.Name = "lblIdentificadorPedido";
            this.lblIdentificadorPedido.Size = new System.Drawing.Size(184, 20);
            this.lblIdentificadorPedido.TabIndex = 30;
            this.lblIdentificadorPedido.Text = "Identificador de Pedido:";
            this.lblIdentificadorPedido.Visible = false;
            // 
            // lblDetallePedido
            // 
            this.lblDetallePedido.AutoSize = true;
            this.lblDetallePedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetallePedido.ForeColor = System.Drawing.Color.White;
            this.lblDetallePedido.Location = new System.Drawing.Point(1267, 57);
            this.lblDetallePedido.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDetallePedido.Name = "lblDetallePedido";
            this.lblDetallePedido.Size = new System.Drawing.Size(158, 20);
            this.lblDetallePedido.TabIndex = 0;
            this.lblDetallePedido.Text = "Detalle de Pedido";
            // 
            // btnAnularVenta
            // 
            this.btnAnularVenta.BackColor = System.Drawing.Color.Red;
            this.btnAnularVenta.ForeColor = System.Drawing.Color.White;
            this.btnAnularVenta.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnAnularVenta.IconColor = System.Drawing.Color.Black;
            this.btnAnularVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAnularVenta.Location = new System.Drawing.Point(633, 484);
            this.btnAnularVenta.Margin = new System.Windows.Forms.Padding(5);
            this.btnAnularVenta.Name = "btnAnularVenta";
            this.btnAnularVenta.Size = new System.Drawing.Size(194, 57);
            this.btnAnularVenta.TabIndex = 21;
            this.btnAnularVenta.Text = "Anular Venta";
            this.btnAnularVenta.UseVisualStyleBackColor = false;
            this.btnAnularVenta.Click += new System.EventHandler(this.btnAnularVenta_Click);
            // 
            // btnRegistrarVenta
            // 
            this.btnRegistrarVenta.BackColor = System.Drawing.Color.Green;
            this.btnRegistrarVenta.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarVenta.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnRegistrarVenta.IconColor = System.Drawing.Color.Black;
            this.btnRegistrarVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRegistrarVenta.Location = new System.Drawing.Point(633, 386);
            this.btnRegistrarVenta.Margin = new System.Windows.Forms.Padding(5);
            this.btnRegistrarVenta.Name = "btnRegistrarVenta";
            this.btnRegistrarVenta.Size = new System.Drawing.Size(194, 57);
            this.btnRegistrarVenta.TabIndex = 20;
            this.btnRegistrarVenta.Text = "Registrar Venta";
            this.btnRegistrarVenta.UseVisualStyleBackColor = false;
            this.btnRegistrarVenta.Click += new System.EventHandler(this.btnRegistrarVenta_Click);
            // 
            // dgvDetallePedido
            // 
            this.dgvDetallePedido.AllowUserToAddRows = false;
            this.dgvDetallePedido.AllowUserToDeleteRows = false;
            this.dgvDetallePedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetallePedido.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idProducto,
            this.codigo,
            this.producto,
            this.precio,
            this.cantidad,
            this.subTotal});
            this.dgvDetallePedido.Location = new System.Drawing.Point(871, 88);
            this.dgvDetallePedido.Margin = new System.Windows.Forms.Padding(5);
            this.dgvDetallePedido.Name = "dgvDetallePedido";
            this.dgvDetallePedido.ReadOnly = true;
            this.dgvDetallePedido.RowHeadersWidth = 51;
            this.dgvDetallePedido.Size = new System.Drawing.Size(939, 499);
            this.dgvDetallePedido.TabIndex = 19;
            // 
            // idProducto
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.idProducto.DefaultCellStyle = dataGridViewCellStyle1;
            this.idProducto.HeaderText = "idProducto";
            this.idProducto.MinimumWidth = 6;
            this.idProducto.Name = "idProducto";
            this.idProducto.ReadOnly = true;
            this.idProducto.Visible = false;
            this.idProducto.Width = 125;
            // 
            // codigo
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.codigo.DefaultCellStyle = dataGridViewCellStyle2;
            this.codigo.HeaderText = "Codigo";
            this.codigo.MinimumWidth = 6;
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.codigo.Width = 125;
            // 
            // producto
            // 
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.producto.DefaultCellStyle = dataGridViewCellStyle3;
            this.producto.HeaderText = "Producto";
            this.producto.MinimumWidth = 6;
            this.producto.Name = "producto";
            this.producto.ReadOnly = true;
            this.producto.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.producto.Width = 200;
            // 
            // precio
            // 
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.precio.DefaultCellStyle = dataGridViewCellStyle4;
            this.precio.HeaderText = "Precio";
            this.precio.MinimumWidth = 6;
            this.precio.Name = "precio";
            this.precio.ReadOnly = true;
            this.precio.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.precio.Width = 125;
            // 
            // cantidad
            // 
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.cantidad.DefaultCellStyle = dataGridViewCellStyle5;
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.MinimumWidth = 6;
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            this.cantidad.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cantidad.Width = 125;
            // 
            // subTotal
            // 
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.subTotal.DefaultCellStyle = dataGridViewCellStyle6;
            this.subTotal.HeaderText = "Subtotal";
            this.subTotal.MinimumWidth = 6;
            this.subTotal.Name = "subTotal";
            this.subTotal.ReadOnly = true;
            this.subTotal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.subTotal.Width = 120;
            // 
            // txtValorFlete
            // 
            this.txtValorFlete.Location = new System.Drawing.Point(254, 333);
            this.txtValorFlete.Margin = new System.Windows.Forms.Padding(5);
            this.txtValorFlete.Name = "txtValorFlete";
            this.txtValorFlete.Size = new System.Drawing.Size(331, 26);
            this.txtValorFlete.TabIndex = 7;
            // 
            // FmrGestionarVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1884, 761);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FmrGestionarVentas";
            this.Text = "FmrGestionarVentas";
            this.Load += new System.EventHandler(this.FmrGestionarVentas_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallePedido)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblGestionarVenta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbEstadoVenta;
        private System.Windows.Forms.Label lblEstado;
        private FontAwesome.Sharp.IconButton btnBuscarVenta;
        private System.Windows.Forms.TextBox txtIdVentaBuscador;
        private System.Windows.Forms.Label lblIdentificadorVenta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblFechaRegistro;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaRegistro;
        private FontAwesome.Sharp.IconButton btnCalcularTotal;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.Label lblValorFlete;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label lblCliente;
        private FontAwesome.Sharp.IconButton btnLimpiarCampos;
        private FontAwesome.Sharp.IconButton btnBuscarProducto;
        private System.Windows.Forms.TextBox txtIdPedido;
        private System.Windows.Forms.Label lblIdentificadorPedido;
        private System.Windows.Forms.Label lblDetallePedido;
        private FontAwesome.Sharp.IconButton btnAnularVenta;
        private FontAwesome.Sharp.IconButton btnRegistrarVenta;
        private System.Windows.Forms.DataGridView dgvDetallePedido;
        private System.Windows.Forms.TextBox txtValorFlete;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtIdEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn subTotal;
        private System.Windows.Forms.TextBox txtNroPedido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNroVenta;
        private System.Windows.Forms.Label label2;
    }
}