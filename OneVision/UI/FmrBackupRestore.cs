using Microsoft.Win32;
using SERVICES.Domain.Composite;
using SERVICES.Facade.Extentions;
using SERVICES.Logic;
using SERVICES.Observer;
using System;
using System.Windows.Forms;

namespace UI
{
    /// <summary>
    /// Formulario para realizar operaciones de backup y restore de la base de datos.
    /// </summary>
    public partial class FmrBackupRestore : Form, IObserver
    {
        private BackupRestoreLogic backupRestoreLogic;
        private Usuario usuarioActual;

        public FmrBackupRestore(Usuario usuario)
        {
            this.usuarioActual = usuario;
            InitializeComponent();
            InitializeDatabaseSelector();
            LanguageNotifier.Instance.RegisterObserver(this);
            Update();
        }

        public new void Update()
        {
            TraducirTextoControles();
        }

        #region Traducción de Controles
        private void TraducirTextoControles()
        {
            lblBasedeDatos.Text = StringExtention.Translate("Base de Datos");

            // Asumiendo que tienes dos group boxes: uno para backup y otro para restore.
            groupBoxBackup.Text = StringExtention.Translate("Backup");
            groupBoxRestore.Text = StringExtention.Translate("Restore");

            btnBuscarBackup.Text = StringExtention.Translate("Buscar");
            btnBuscarRestore.Text = StringExtention.Translate("Buscar");
            btnBackup.Text = StringExtention.Translate("Backup");
            btnRestore.Text = StringExtention.Translate("Restore");
        }
        #endregion

        private void InitializeDatabaseSelector()
        {
            cmbDatabaseSelector.Items.Add("One Vision Business Database");
            cmbDatabaseSelector.Items.Add("One Vision Services Database");
            cmbDatabaseSelector.SelectedIndex = 0;
            SetDatabaseConnection();
        }

        private void SetDatabaseConnection()
        {
            string selectedKey;
            switch (cmbDatabaseSelector.SelectedIndex)
            {
                case 0:
                    selectedKey = "MainConString";
                    break;
                case 1:
                    selectedKey = "ServicesConString";
                    break;
                default:
                    throw new InvalidOperationException("Selección no válida.");
            }
            backupRestoreLogic = new BackupRestoreLogic(selectedKey);
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                if (!VerificarConexion())
                    return;
                if (string.IsNullOrEmpty(txtBackupPath.Text))
                {
                    MessageBox.Show("Por favor, ingrese la ruta del archivo de respaldo.");
                    return;
                }
                backupRestoreLogic.PerformBackup(txtBackupPath.Text);
                MessageBox.Show("Backup realizado con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar el backup: {ex.Message}");
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                if (!VerificarConexion())
                    return;
                if (string.IsNullOrEmpty(txtRestorePath.Text))
                {
                    MessageBox.Show("Por favor, seleccione el archivo de restauración.");
                    return;
                }
                backupRestoreLogic.PerformRestore(txtRestorePath.Text);
                MessageBox.Show("Restauración completada con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al restaurar la base de datos: {ex.Message}");
            }
        }

        private void cmbDatabaseSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDatabaseConnection();
        }

        private void btnBuscarBackup_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Backup File (*.bak)|*.bak";
            // Se obtiene la ruta relativa configurada en la lógica (usando el directorio base de la aplicación)
            string backupDirectory = backupRestoreLogic.GetBackupDirectory();
            saveFileDialog1.InitialDirectory = backupDirectory;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                txtBackupPath.Text = saveFileDialog1.FileName;
        }

        private void btnBuscarRestore_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Backup File (*.bak)|*.bak";
            string restoreDirectory = backupRestoreLogic.GetRestoreDirectory();
            openFileDialog1.InitialDirectory = restoreDirectory;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                txtRestorePath.Text = openFileDialog1.FileName;
        }

        private bool VerificarConexion()
        {
            ConnectionManager.Instance.UpdateConnectionStatus();
            if (!ConnectionManager.Instance.IsConnected)
            {
                MessageBox.Show("La conexión a la base de datos se perdió. " +
                                "Por favor, verifica la configuración.",
                                "Error de Conexión",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                Application.Exit();
                return false;
            }
            return true;
        }

        private void FmrBackupRestore_Load(object sender, EventArgs e)
        {
            VerificarConexion();
        }
    }
}
