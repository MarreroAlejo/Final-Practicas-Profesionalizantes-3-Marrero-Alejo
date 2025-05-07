using SERVICES.Dao.Contracts;

namespace SERVICES.Logic
{
    /// <summary>
    /// Lógica para realizar backup y restore de la base de datos.
    /// </summary>
    public class BackupRestoreLogic
    {
        private readonly IBackUpRestore dao;

        /// <summary>
        /// Inicializa una nueva instancia de la clase BackupRestoreLogic usando la clave de conexión.
        /// </summary>
        /// <param name="connectionKey">La clave de conexión (ej. "MainConString" o "ServicesConString").</param>
        public BackupRestoreLogic(string connectionKey)
        {
            dao = new Dao.Implementations.SqlServer.BackupRestoreDao(connectionKey);
        }

        /// <summary>
        /// Obtiene la ruta de backup configurada.
        /// </summary>
        /// <returns>La ruta de backup.</returns>
        public string GetBackupDirectory()
        {
            return dao.GetBackupDirectory();
        }

        /// <summary>
        /// Obtiene la ruta de restauración configurada.
        /// </summary>
        /// <returns>La ruta de restauración.</returns>
        public string GetRestoreDirectory()
        {
            return dao.GetRestoreDirectory();
        }

        /// <summary>
        /// Realiza el backup de la base de datos en la ruta especificada.
        /// </summary>
        /// <param name="backupPath">La ruta del archivo de backup.</param>
        public void PerformBackup(string backupPath)
        {
            dao.PerformBackup(backupPath);
        }

        /// <summary>
        /// Restaura la base de datos a partir del archivo de backup especificado.
        /// </summary>
        /// <param name="restorePath">La ruta del archivo de backup.</param>
        public void PerformRestore(string restorePath)
        {
            dao.PerformRestore(restorePath);
        }
    }
}
