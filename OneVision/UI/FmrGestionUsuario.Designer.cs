namespace UI
{
    partial class FmrGestionUsuario
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdEmpleado = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblnombre = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblapellido = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lbltelefono = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.lblmail = new System.Windows.Forms.Label();
            this.btnCancelar = new FontAwesome.Sharp.IconButton();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.lblcontraseña = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblnombreusuario = new System.Windows.Forms.Label();
            this.txtIdUsuario = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBoxUsuario = new System.Windows.Forms.GroupBox();
            this.groupBoxNegocio = new System.Windows.Forms.GroupBox();
            this.groupBoxUsuario.SuspendLayout();
            this.groupBoxNegocio.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2067, 67);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestión de Usuario";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Green;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnGuardar.IconColor = System.Drawing.Color.Black;
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.Location = new System.Drawing.Point(787, 623);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(5);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(286, 40);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1019, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "idEmpleado";
            this.label2.Visible = false;
            // 
            // txtIdEmpleado
            // 
            this.txtIdEmpleado.Location = new System.Drawing.Point(1218, 79);
            this.txtIdEmpleado.Margin = new System.Windows.Forms.Padding(5);
            this.txtIdEmpleado.Name = "txtIdEmpleado";
            this.txtIdEmpleado.Size = new System.Drawing.Size(284, 26);
            this.txtIdEmpleado.TabIndex = 3;
            this.txtIdEmpleado.Visible = false;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(251, 88);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(5);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(284, 26);
            this.txtNombre.TabIndex = 5;
            // 
            // lblnombre
            // 
            this.lblnombre.AutoSize = true;
            this.lblnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnombre.ForeColor = System.Drawing.Color.White;
            this.lblnombre.Location = new System.Drawing.Point(77, 92);
            this.lblnombre.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(62, 17);
            this.lblnombre.TabIndex = 4;
            this.lblnombre.Text = "Nombre:";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(251, 140);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(5);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(284, 26);
            this.txtApellido.TabIndex = 7;
            // 
            // lblapellido
            // 
            this.lblapellido.AutoSize = true;
            this.lblapellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblapellido.ForeColor = System.Drawing.Color.White;
            this.lblapellido.Location = new System.Drawing.Point(77, 145);
            this.lblapellido.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblapellido.Name = "lblapellido";
            this.lblapellido.Size = new System.Drawing.Size(62, 17);
            this.lblapellido.TabIndex = 6;
            this.lblapellido.Text = "Apellido:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(251, 259);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(5);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(284, 26);
            this.txtTelefono.TabIndex = 11;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // lbltelefono
            // 
            this.lbltelefono.AutoSize = true;
            this.lbltelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltelefono.ForeColor = System.Drawing.Color.White;
            this.lbltelefono.Location = new System.Drawing.Point(70, 263);
            this.lbltelefono.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbltelefono.Name = "lbltelefono";
            this.lbltelefono.Size = new System.Drawing.Size(68, 17);
            this.lbltelefono.TabIndex = 10;
            this.lbltelefono.Text = "Telefono:";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(251, 199);
            this.txtMail.Margin = new System.Windows.Forms.Padding(5);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(284, 26);
            this.txtMail.TabIndex = 9;
            // 
            // lblmail
            // 
            this.lblmail.AutoSize = true;
            this.lblmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmail.ForeColor = System.Drawing.Color.White;
            this.lblmail.Location = new System.Drawing.Point(107, 203);
            this.lblmail.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblmail.Name = "lblmail";
            this.lblmail.Size = new System.Drawing.Size(37, 17);
            this.lblmail.TabIndex = 8;
            this.lblmail.Text = "Mail:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Red;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnCancelar.IconColor = System.Drawing.Color.Black;
            this.btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancelar.Location = new System.Drawing.Point(787, 669);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(286, 40);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(284, 223);
            this.txtContraseña.Margin = new System.Windows.Forms.Padding(5);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PasswordChar = '*';
            this.txtContraseña.Size = new System.Drawing.Size(284, 26);
            this.txtContraseña.TabIndex = 18;
            // 
            // lblcontraseña
            // 
            this.lblcontraseña.AutoSize = true;
            this.lblcontraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcontraseña.ForeColor = System.Drawing.Color.White;
            this.lblcontraseña.Location = new System.Drawing.Point(83, 223);
            this.lblcontraseña.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblcontraseña.Name = "lblcontraseña";
            this.lblcontraseña.Size = new System.Drawing.Size(85, 17);
            this.lblcontraseña.TabIndex = 17;
            this.lblcontraseña.Text = "Contraseña:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(284, 170);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(5);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(284, 26);
            this.txtUsername.TabIndex = 16;
            // 
            // lblnombreusuario
            // 
            this.lblnombreusuario.AutoSize = true;
            this.lblnombreusuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnombreusuario.ForeColor = System.Drawing.Color.White;
            this.lblnombreusuario.Location = new System.Drawing.Point(46, 175);
            this.lblnombreusuario.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblnombreusuario.Name = "lblnombreusuario";
            this.lblnombreusuario.Size = new System.Drawing.Size(115, 17);
            this.lblnombreusuario.TabIndex = 15;
            this.lblnombreusuario.Text = "Nombre Usuario:";
            // 
            // txtIdUsuario
            // 
            this.txtIdUsuario.Location = new System.Drawing.Point(498, 87);
            this.txtIdUsuario.Margin = new System.Windows.Forms.Padding(5);
            this.txtIdUsuario.Name = "txtIdUsuario";
            this.txtIdUsuario.Size = new System.Drawing.Size(284, 26);
            this.txtIdUsuario.TabIndex = 22;
            this.txtIdUsuario.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(322, 95);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "idUsuario";
            this.label9.Visible = false;
            // 
            // groupBoxUsuario
            // 
            this.groupBoxUsuario.Controls.Add(this.txtContraseña);
            this.groupBoxUsuario.Controls.Add(this.lblnombreusuario);
            this.groupBoxUsuario.Controls.Add(this.txtUsername);
            this.groupBoxUsuario.Controls.Add(this.lblcontraseña);
            this.groupBoxUsuario.ForeColor = System.Drawing.Color.White;
            this.groupBoxUsuario.Location = new System.Drawing.Point(215, 149);
            this.groupBoxUsuario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxUsuario.Name = "groupBoxUsuario";
            this.groupBoxUsuario.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxUsuario.Size = new System.Drawing.Size(665, 429);
            this.groupBoxUsuario.TabIndex = 23;
            this.groupBoxUsuario.TabStop = false;
            this.groupBoxUsuario.Text = "Datos de Usuario";
            // 
            // groupBoxNegocio
            // 
            this.groupBoxNegocio.Controls.Add(this.txtNombre);
            this.groupBoxNegocio.Controls.Add(this.lblnombre);
            this.groupBoxNegocio.Controls.Add(this.lblapellido);
            this.groupBoxNegocio.Controls.Add(this.txtApellido);
            this.groupBoxNegocio.Controls.Add(this.lblmail);
            this.groupBoxNegocio.Controls.Add(this.txtMail);
            this.groupBoxNegocio.Controls.Add(this.lbltelefono);
            this.groupBoxNegocio.Controls.Add(this.txtTelefono);
            this.groupBoxNegocio.ForeColor = System.Drawing.Color.White;
            this.groupBoxNegocio.Location = new System.Drawing.Point(967, 149);
            this.groupBoxNegocio.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxNegocio.Name = "groupBoxNegocio";
            this.groupBoxNegocio.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxNegocio.Size = new System.Drawing.Size(653, 429);
            this.groupBoxNegocio.TabIndex = 24;
            this.groupBoxNegocio.TabStop = false;
            this.groupBoxNegocio.Text = "Datos de Negocio";
            // 
            // FmrGestionUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1884, 761);
            this.Controls.Add(this.groupBoxNegocio);
            this.Controls.Add(this.groupBoxUsuario);
            this.Controls.Add(this.txtIdUsuario);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtIdEmpleado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FmrGestionUsuario";
            this.Text = "FmrGestionUsuario";
            this.Load += new System.EventHandler(this.FmrGestionUsuario_Load);
            this.groupBoxUsuario.ResumeLayout(false);
            this.groupBoxUsuario.PerformLayout();
            this.groupBoxNegocio.ResumeLayout(false);
            this.groupBoxNegocio.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdEmpleado;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblapellido;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lbltelefono;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label lblmail;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Label lblcontraseña;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblnombreusuario;
        private System.Windows.Forms.TextBox txtIdUsuario;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBoxUsuario;
        private System.Windows.Forms.GroupBox groupBoxNegocio;
    }
}