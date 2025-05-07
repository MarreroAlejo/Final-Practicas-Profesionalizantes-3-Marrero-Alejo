namespace UI
{
    partial class FmrBackupRestore
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.lblBasedeDatos = new System.Windows.Forms.Label();
            this.groupBoxBackup = new System.Windows.Forms.GroupBox();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnBuscarBackup = new System.Windows.Forms.Button();
            this.txtBackupPath = new System.Windows.Forms.TextBox();
            this.cmbDatabaseSelector = new System.Windows.Forms.ComboBox();
            this.groupBoxRestore = new System.Windows.Forms.GroupBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnBuscarRestore = new System.Windows.Forms.Button();
            this.txtRestorePath = new System.Windows.Forms.TextBox();
            this.groupBoxBackup.SuspendLayout();
            this.groupBoxRestore.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblBasedeDatos
            // 
            this.lblBasedeDatos.AutoSize = true;
            this.lblBasedeDatos.Location = new System.Drawing.Point(901, 101);
            this.lblBasedeDatos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBasedeDatos.Name = "lblBasedeDatos";
            this.lblBasedeDatos.Size = new System.Drawing.Size(126, 20);
            this.lblBasedeDatos.TabIndex = 9;
            this.lblBasedeDatos.Text = "Base de Datos:";
            // 
            // groupBoxBackup
            // 
            this.groupBoxBackup.Controls.Add(this.btnBackup);
            this.groupBoxBackup.Controls.Add(this.btnBuscarBackup);
            this.groupBoxBackup.Controls.Add(this.txtBackupPath);
            this.groupBoxBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBoxBackup.Location = new System.Drawing.Point(166, 281);
            this.groupBoxBackup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxBackup.Name = "groupBoxBackup";
            this.groupBoxBackup.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxBackup.Size = new System.Drawing.Size(766, 246);
            this.groupBoxBackup.TabIndex = 6;
            this.groupBoxBackup.TabStop = false;
            this.groupBoxBackup.Text = "Backup";
            // 
            // btnBackup
            // 
            this.btnBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackup.Location = new System.Drawing.Point(183, 160);
            this.btnBackup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(370, 37);
            this.btnBackup.TabIndex = 2;
            this.btnBackup.Text = "Backup Database";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnBuscarBackup
            // 
            this.btnBuscarBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarBackup.Location = new System.Drawing.Point(507, 77);
            this.btnBuscarBackup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnBuscarBackup.Name = "btnBuscarBackup";
            this.btnBuscarBackup.Size = new System.Drawing.Size(195, 39);
            this.btnBuscarBackup.TabIndex = 1;
            this.btnBuscarBackup.Text = "Buscar";
            this.btnBuscarBackup.UseVisualStyleBackColor = true;
            this.btnBuscarBackup.Click += new System.EventHandler(this.btnBuscarBackup_Click);
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBackupPath.Location = new System.Drawing.Point(69, 81);
            this.txtBackupPath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.Size = new System.Drawing.Size(337, 26);
            this.txtBackupPath.TabIndex = 0;
            // 
            // cmbDatabaseSelector
            // 
            this.cmbDatabaseSelector.FormattingEnabled = true;
            this.cmbDatabaseSelector.Location = new System.Drawing.Point(843, 139);
            this.cmbDatabaseSelector.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbDatabaseSelector.Name = "cmbDatabaseSelector";
            this.cmbDatabaseSelector.Size = new System.Drawing.Size(251, 28);
            this.cmbDatabaseSelector.TabIndex = 8;
            this.cmbDatabaseSelector.SelectedIndexChanged += new System.EventHandler(this.cmbDatabaseSelector_SelectedIndexChanged);
            // 
            // groupBoxRestore
            // 
            this.groupBoxRestore.Controls.Add(this.btnRestore);
            this.groupBoxRestore.Controls.Add(this.btnBuscarRestore);
            this.groupBoxRestore.Controls.Add(this.txtRestorePath);
            this.groupBoxRestore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxRestore.Location = new System.Drawing.Point(1009, 281);
            this.groupBoxRestore.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxRestore.Name = "groupBoxRestore";
            this.groupBoxRestore.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxRestore.Size = new System.Drawing.Size(766, 246);
            this.groupBoxRestore.TabIndex = 7;
            this.groupBoxRestore.TabStop = false;
            this.groupBoxRestore.Text = "Restore";
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(183, 150);
            this.btnRestore.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(370, 37);
            this.btnRestore.TabIndex = 2;
            this.btnRestore.Text = "Restore Database";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnBuscarRestore
            // 
            this.btnBuscarRestore.Location = new System.Drawing.Point(507, 66);
            this.btnBuscarRestore.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnBuscarRestore.Name = "btnBuscarRestore";
            this.btnBuscarRestore.Size = new System.Drawing.Size(195, 39);
            this.btnBuscarRestore.TabIndex = 1;
            this.btnBuscarRestore.Text = "Buscar";
            this.btnBuscarRestore.UseVisualStyleBackColor = true;
            this.btnBuscarRestore.Click += new System.EventHandler(this.btnBuscarRestore_Click);
            // 
            // txtRestorePath
            // 
            this.txtRestorePath.Location = new System.Drawing.Point(69, 71);
            this.txtRestorePath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtRestorePath.Name = "txtRestorePath";
            this.txtRestorePath.Size = new System.Drawing.Size(337, 26);
            this.txtRestorePath.TabIndex = 0;
            // 
            // FmrBackupRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1884, 761);
            this.Controls.Add(this.lblBasedeDatos);
            this.Controls.Add(this.groupBoxBackup);
            this.Controls.Add(this.cmbDatabaseSelector);
            this.Controls.Add(this.groupBoxRestore);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FmrBackupRestore";
            this.Text = "FmrBackupRestore";
            this.Load += new System.EventHandler(this.FmrBackupRestore_Load);
            this.groupBoxBackup.ResumeLayout(false);
            this.groupBoxBackup.PerformLayout();
            this.groupBoxRestore.ResumeLayout(false);
            this.groupBoxRestore.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label lblBasedeDatos;
        private System.Windows.Forms.GroupBox groupBoxBackup;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.ComboBox cmbDatabaseSelector;
        private System.Windows.Forms.GroupBox groupBoxRestore;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnBuscarBackup;
        private System.Windows.Forms.TextBox txtBackupPath;
        private System.Windows.Forms.Button btnBuscarRestore;
        private System.Windows.Forms.TextBox txtRestorePath;
    }
}