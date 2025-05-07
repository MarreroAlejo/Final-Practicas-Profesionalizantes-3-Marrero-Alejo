namespace UI
{
    partial class FmrAccesos
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
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.listFamilias = new System.Windows.Forms.ListBox();
            this.btnEliminar = new FontAwesome.Sharp.IconButton();
            this.txtRolSeleccionado = new System.Windows.Forms.TextBox();
            this.lblRolSeleccionado = new System.Windows.Forms.Label();
            this.btnRemoveFamiliaPatente = new FontAwesome.Sharp.IconButton();
            this.btnAddFamiliaPatente = new FontAwesome.Sharp.IconButton();
            this.btnRemoveFamiliaFamilia = new FontAwesome.Sharp.IconButton();
            this.btnLimpiar = new FontAwesome.Sharp.IconButton();
            this.btnAddFamiliaFamilia = new FontAwesome.Sharp.IconButton();
            this.btnConfirmarNuevoRol = new FontAwesome.Sharp.IconButton();
            this.txtNuevoRol = new System.Windows.Forms.TextBox();
            this.lblNombreNuevoRol = new System.Windows.Forms.Label();
            this.listPatentesElegidas = new System.Windows.Forms.ListBox();
            this.listPatentesAElegir = new System.Windows.Forms.ListBox();
            this.listFamiliasElegidasRol = new System.Windows.Forms.ListBox();
            this.listFamiliasAElegirRol = new System.Windows.Forms.ListBox();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(28, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(535, 39);
            this.label2.TabIndex = 0;
            this.label2.Text = "Administrador de Accesos y Roles";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1884, 761);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel3.Controls.Add(this.listFamilias);
            this.panel3.Controls.Add(this.btnEliminar);
            this.panel3.Controls.Add(this.txtRolSeleccionado);
            this.panel3.Controls.Add(this.lblRolSeleccionado);
            this.panel3.Controls.Add(this.btnRemoveFamiliaPatente);
            this.panel3.Controls.Add(this.btnAddFamiliaPatente);
            this.panel3.Controls.Add(this.btnRemoveFamiliaFamilia);
            this.panel3.Controls.Add(this.btnLimpiar);
            this.panel3.Controls.Add(this.btnAddFamiliaFamilia);
            this.panel3.Controls.Add(this.btnConfirmarNuevoRol);
            this.panel3.Controls.Add(this.txtNuevoRol);
            this.panel3.Controls.Add(this.lblNombreNuevoRol);
            this.panel3.Controls.Add(this.listPatentesElegidas);
            this.panel3.Controls.Add(this.listPatentesAElegir);
            this.panel3.Controls.Add(this.listFamiliasElegidasRol);
            this.panel3.Controls.Add(this.listFamiliasAElegirRol);
            this.panel3.Location = new System.Drawing.Point(0, 63);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(2334, 1178);
            this.panel3.TabIndex = 13;
            // 
            // listFamilias
            // 
            this.listFamilias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listFamilias.FormattingEnabled = true;
            this.listFamilias.ItemHeight = 20;
            this.listFamilias.Location = new System.Drawing.Point(46, 35);
            this.listFamilias.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.listFamilias.Name = "listFamilias";
            this.listFamilias.Size = new System.Drawing.Size(259, 584);
            this.listFamilias.TabIndex = 21;
            this.listFamilias.SelectedIndexChanged += new System.EventHandler(this.listFamilias_SelectedIndexChanged);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Red;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnEliminar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnEliminar.IconColor = System.Drawing.Color.Black;
            this.btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminar.Location = new System.Drawing.Point(382, 471);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(344, 58);
            this.btnEliminar.TabIndex = 17;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // txtRolSeleccionado
            // 
            this.txtRolSeleccionado.Enabled = false;
            this.txtRolSeleccionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtRolSeleccionado.Location = new System.Drawing.Point(340, 413);
            this.txtRolSeleccionado.Margin = new System.Windows.Forms.Padding(4);
            this.txtRolSeleccionado.Name = "txtRolSeleccionado";
            this.txtRolSeleccionado.Size = new System.Drawing.Size(420, 26);
            this.txtRolSeleccionado.TabIndex = 15;
            // 
            // lblRolSeleccionado
            // 
            this.lblRolSeleccionado.AutoSize = true;
            this.lblRolSeleccionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblRolSeleccionado.ForeColor = System.Drawing.Color.White;
            this.lblRolSeleccionado.Location = new System.Drawing.Point(338, 371);
            this.lblRolSeleccionado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRolSeleccionado.Name = "lblRolSeleccionado";
            this.lblRolSeleccionado.Size = new System.Drawing.Size(144, 20);
            this.lblRolSeleccionado.TabIndex = 14;
            this.lblRolSeleccionado.Text = "Rol Seleccionado:";
            // 
            // btnRemoveFamiliaPatente
            // 
            this.btnRemoveFamiliaPatente.BackColor = System.Drawing.Color.Red;
            this.btnRemoveFamiliaPatente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnRemoveFamiliaPatente.IconChar = FontAwesome.Sharp.IconChar.SquareMinus;
            this.btnRemoveFamiliaPatente.IconColor = System.Drawing.Color.Black;
            this.btnRemoveFamiliaPatente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRemoveFamiliaPatente.IconSize = 25;
            this.btnRemoveFamiliaPatente.Location = new System.Drawing.Point(1229, 480);
            this.btnRemoveFamiliaPatente.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveFamiliaPatente.Name = "btnRemoveFamiliaPatente";
            this.btnRemoveFamiliaPatente.Size = new System.Drawing.Size(140, 49);
            this.btnRemoveFamiliaPatente.TabIndex = 12;
            this.btnRemoveFamiliaPatente.UseVisualStyleBackColor = false;
            this.btnRemoveFamiliaPatente.Click += new System.EventHandler(this.btnRemoveFamiliaPatente_Click);
            // 
            // btnAddFamiliaPatente
            // 
            this.btnAddFamiliaPatente.BackColor = System.Drawing.Color.Lime;
            this.btnAddFamiliaPatente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnAddFamiliaPatente.IconChar = FontAwesome.Sharp.IconChar.SquareCheck;
            this.btnAddFamiliaPatente.IconColor = System.Drawing.Color.Black;
            this.btnAddFamiliaPatente.IconFont = FontAwesome.Sharp.IconFont.Regular;
            this.btnAddFamiliaPatente.IconSize = 25;
            this.btnAddFamiliaPatente.Location = new System.Drawing.Point(1229, 420);
            this.btnAddFamiliaPatente.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddFamiliaPatente.Name = "btnAddFamiliaPatente";
            this.btnAddFamiliaPatente.Size = new System.Drawing.Size(140, 49);
            this.btnAddFamiliaPatente.TabIndex = 11;
            this.btnAddFamiliaPatente.UseVisualStyleBackColor = false;
            this.btnAddFamiliaPatente.Click += new System.EventHandler(this.btnAddFamiliaPatente_Click);
            // 
            // btnRemoveFamiliaFamilia
            // 
            this.btnRemoveFamiliaFamilia.BackColor = System.Drawing.Color.Red;
            this.btnRemoveFamiliaFamilia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnRemoveFamiliaFamilia.IconChar = FontAwesome.Sharp.IconChar.SquareMinus;
            this.btnRemoveFamiliaFamilia.IconColor = System.Drawing.Color.Black;
            this.btnRemoveFamiliaFamilia.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRemoveFamiliaFamilia.IconSize = 25;
            this.btnRemoveFamiliaFamilia.Location = new System.Drawing.Point(1229, 173);
            this.btnRemoveFamiliaFamilia.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveFamiliaFamilia.Name = "btnRemoveFamiliaFamilia";
            this.btnRemoveFamiliaFamilia.Size = new System.Drawing.Size(140, 49);
            this.btnRemoveFamiliaFamilia.TabIndex = 10;
            this.btnRemoveFamiliaFamilia.UseVisualStyleBackColor = false;
            this.btnRemoveFamiliaFamilia.Click += new System.EventHandler(this.btnRemoveFamiliaFamilia_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.LightGray;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnLimpiar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnLimpiar.IconColor = System.Drawing.Color.Black;
            this.btnLimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiar.Location = new System.Drawing.Point(382, 264);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(344, 58);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnAddFamiliaFamilia
            // 
            this.btnAddFamiliaFamilia.BackColor = System.Drawing.Color.Lime;
            this.btnAddFamiliaFamilia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnAddFamiliaFamilia.IconChar = FontAwesome.Sharp.IconChar.SquareCheck;
            this.btnAddFamiliaFamilia.IconColor = System.Drawing.Color.Black;
            this.btnAddFamiliaFamilia.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAddFamiliaFamilia.IconSize = 25;
            this.btnAddFamiliaFamilia.Location = new System.Drawing.Point(1229, 118);
            this.btnAddFamiliaFamilia.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddFamiliaFamilia.Name = "btnAddFamiliaFamilia";
            this.btnAddFamiliaFamilia.Size = new System.Drawing.Size(140, 49);
            this.btnAddFamiliaFamilia.TabIndex = 9;
            this.btnAddFamiliaFamilia.UseVisualStyleBackColor = false;
            this.btnAddFamiliaFamilia.Click += new System.EventHandler(this.btnAddFamiliaFamilia_Click);
            // 
            // btnConfirmarNuevoRol
            // 
            this.btnConfirmarNuevoRol.BackColor = System.Drawing.Color.Lime;
            this.btnConfirmarNuevoRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnConfirmarNuevoRol.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnConfirmarNuevoRol.IconColor = System.Drawing.Color.Black;
            this.btnConfirmarNuevoRol.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnConfirmarNuevoRol.Location = new System.Drawing.Point(382, 186);
            this.btnConfirmarNuevoRol.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfirmarNuevoRol.Name = "btnConfirmarNuevoRol";
            this.btnConfirmarNuevoRol.Size = new System.Drawing.Size(344, 58);
            this.btnConfirmarNuevoRol.TabIndex = 7;
            this.btnConfirmarNuevoRol.Text = "Confirmar";
            this.btnConfirmarNuevoRol.UseVisualStyleBackColor = false;
            this.btnConfirmarNuevoRol.Click += new System.EventHandler(this.btnConfirmarNuevoRol_Click);
            // 
            // txtNuevoRol
            // 
            this.txtNuevoRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtNuevoRol.Location = new System.Drawing.Point(340, 93);
            this.txtNuevoRol.Margin = new System.Windows.Forms.Padding(4);
            this.txtNuevoRol.Name = "txtNuevoRol";
            this.txtNuevoRol.Size = new System.Drawing.Size(420, 26);
            this.txtNuevoRol.TabIndex = 6;
            // 
            // lblNombreNuevoRol
            // 
            this.lblNombreNuevoRol.AutoSize = true;
            this.lblNombreNuevoRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblNombreNuevoRol.ForeColor = System.Drawing.Color.White;
            this.lblNombreNuevoRol.Location = new System.Drawing.Point(338, 51);
            this.lblNombreNuevoRol.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreNuevoRol.Name = "lblNombreNuevoRol";
            this.lblNombreNuevoRol.Size = new System.Drawing.Size(182, 20);
            this.lblNombreNuevoRol.TabIndex = 5;
            this.lblNombreNuevoRol.Text = "Nombre del Nuevo Rol:";
            // 
            // listPatentesElegidas
            // 
            this.listPatentesElegidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listPatentesElegidas.FormattingEnabled = true;
            this.listPatentesElegidas.ItemHeight = 20;
            this.listPatentesElegidas.Location = new System.Drawing.Point(1408, 348);
            this.listPatentesElegidas.Margin = new System.Windows.Forms.Padding(4);
            this.listPatentesElegidas.Name = "listPatentesElegidas";
            this.listPatentesElegidas.Size = new System.Drawing.Size(340, 264);
            this.listPatentesElegidas.TabIndex = 4;
            // 
            // listPatentesAElegir
            // 
            this.listPatentesAElegir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listPatentesAElegir.FormattingEnabled = true;
            this.listPatentesAElegir.ItemHeight = 20;
            this.listPatentesAElegir.Location = new System.Drawing.Point(860, 348);
            this.listPatentesAElegir.Margin = new System.Windows.Forms.Padding(4);
            this.listPatentesAElegir.Name = "listPatentesAElegir";
            this.listPatentesAElegir.Size = new System.Drawing.Size(340, 264);
            this.listPatentesAElegir.TabIndex = 3;
            // 
            // listFamiliasElegidasRol
            // 
            this.listFamiliasElegidasRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listFamiliasElegidasRol.FormattingEnabled = true;
            this.listFamiliasElegidasRol.ItemHeight = 20;
            this.listFamiliasElegidasRol.Location = new System.Drawing.Point(1408, 35);
            this.listFamiliasElegidasRol.Margin = new System.Windows.Forms.Padding(4);
            this.listFamiliasElegidasRol.Name = "listFamiliasElegidasRol";
            this.listFamiliasElegidasRol.Size = new System.Drawing.Size(340, 264);
            this.listFamiliasElegidasRol.TabIndex = 2;
            // 
            // listFamiliasAElegirRol
            // 
            this.listFamiliasAElegirRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listFamiliasAElegirRol.FormattingEnabled = true;
            this.listFamiliasAElegirRol.ItemHeight = 20;
            this.listFamiliasAElegirRol.Location = new System.Drawing.Point(860, 35);
            this.listFamiliasAElegirRol.Margin = new System.Windows.Forms.Padding(4);
            this.listFamiliasAElegirRol.Name = "listFamiliasAElegirRol";
            this.listFamiliasAElegirRol.Size = new System.Drawing.Size(340, 264);
            this.listFamiliasAElegirRol.TabIndex = 1;
            // 
            // FmrAccesos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1884, 761);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FmrAccesos";
            this.Text = "FmrAccesos";
            this.Load += new System.EventHandler(this.FmrAccesos_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private System.Windows.Forms.TextBox txtRolSeleccionado;
        private System.Windows.Forms.Label lblRolSeleccionado;
        private FontAwesome.Sharp.IconButton btnRemoveFamiliaPatente;
        private FontAwesome.Sharp.IconButton btnAddFamiliaPatente;
        private FontAwesome.Sharp.IconButton btnRemoveFamiliaFamilia;
        private FontAwesome.Sharp.IconButton btnLimpiar;
        private FontAwesome.Sharp.IconButton btnAddFamiliaFamilia;
        private FontAwesome.Sharp.IconButton btnConfirmarNuevoRol;
        private System.Windows.Forms.TextBox txtNuevoRol;
        private System.Windows.Forms.Label lblNombreNuevoRol;
        private System.Windows.Forms.ListBox listPatentesElegidas;
        private System.Windows.Forms.ListBox listPatentesAElegir;
        private System.Windows.Forms.ListBox listFamiliasElegidasRol;
        private System.Windows.Forms.ListBox listFamiliasAElegirRol;
        private System.Windows.Forms.ListBox listFamilias;
    }
}