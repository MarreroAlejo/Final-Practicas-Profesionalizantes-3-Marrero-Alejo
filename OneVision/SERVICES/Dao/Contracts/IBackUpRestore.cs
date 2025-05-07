using System;

namespace SERVICES.Dao.Contracts
{
    /// <summary>
    /// Define un contrato para realizar operaciones de backup y restore en una base de datos.
    /// </summary>
    /// <typeparam name="T">Tipo de la entidad asociada (opcional para el futuro).</typeparam>
    public interface IBackUpRestore
    {
        /// <summary>
        /// Realiza el backup de la base de datos en la ruta especificada.
        /// </summary>
        /// <param name="backupPath">Ruta donde se almacenará el backup.</param>
        void PerformBackup(string backupPath);

        /// <summary>
        /// Restaura la base de datos desde la ruta especificada.
        /// </summary>
        /// <param name="restorePath">Ruta desde donde se realizará la restauración.</param>
        void PerformRestore(string restorePath);

        /// <summary>
        /// Obtiene el directorio donde se almacenan los backups.
        /// </summary>
        /// <returns>Cadena con el path del directorio de backup.</returns>
        string GetBackupDirectory();

        /// <summary>
        /// Obtiene el directorio desde donde se pueden restaurar las bases de datos.
        /// </summary>
        /// <returns>Cadena con el path del directorio de restore.</returns>
        string GetRestoreDirectory();
    }
}
