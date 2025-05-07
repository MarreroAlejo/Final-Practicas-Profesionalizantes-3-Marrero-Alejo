using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using SERVICES.Dao.Contracts;

namespace SERVICES.Dao.Implementations.SqlServer
{
    /// <summary>
    /// Implementa el DAO para operaciones de backup y restore de la base de datos en SQL Server.
    /// </summary>
    public sealed class BackupRestoreDao : IBackUpRestore
    {
        private readonly string connectionString;
        private readonly string databaseName;

        /// <summary>
        /// Inicializa una nueva instancia de BackupRestoreDao utilizando la clave de conexión.
        /// </summary>
        /// <param name="connectionKey">Clave de conexión (por ejemplo, "MainConString").</param>
        public BackupRestoreDao(string connectionKey)
        {
            this.databaseName = GetDatabaseName(connectionKey); // Obtener el nombre de la base de datos
            this.connectionString = GetConnectionString(connectionKey); // Obtener la cadena de conexión
        }

        /// <summary>
        /// Obtiene la cadena de conexión a partir de la clave proporcionada.
        /// </summary>
        /// <param name="connectionKey">Clave de conexión.</param>
        /// <returns>Cadena de conexión.</returns>
        private string GetConnectionString(string connectionKey)
        {
            string connString = ConfigurationManager.ConnectionStrings[connectionKey]?.ConnectionString;
            if (string.IsNullOrEmpty(connString))
                throw new InvalidOperationException($"La cadena de conexión '{connectionKey}' no está configurada.");
            return connString;
        }

        /// <summary>
        /// Obtiene el nombre de la base de datos en función de la clave de conexión.
        /// </summary>
        /// <param name="connectionKey">Clave de conexión.</param>
        /// <returns>Nombre de la base de datos.</returns>
        private string GetDatabaseName(string connectionKey)
        {
            switch (connectionKey)
            {
                case "MainConString":
                    return "OneVisionBD"; // Nombre de la base principal
                case "ServicesConString":
                    return "ServicesOneVision"; // Nombre de la base de servicios
                default:
                    throw new ArgumentException("Clave de conexión no válida.");
            }
        }


        public string GetBackupDirectory()
        {
            string backupDirectory = @"C:\SQLBackups";

            if (!System.IO.Directory.Exists(backupDirectory))
                System.IO.Directory.CreateDirectory(backupDirectory);

            return backupDirectory;
        }


        public string GetRestoreDirectory()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string restoreDirectory = System.IO.Path.Combine(basePath, "Restores");

            if (!System.IO.Directory.Exists(restoreDirectory))
                System.IO.Directory.CreateDirectory(restoreDirectory);

            return restoreDirectory;
        }

        /// <summary>
        /// Realiza el backup de la base de datos y lo guarda en la ruta especificada.
        /// </summary>
        /// <param name="backupPath">Ruta donde se guardará el archivo de backup.</param>
        public void PerformBackup(string backupPath)
        {
            if (string.IsNullOrEmpty(backupPath))
                throw new ArgumentException("La ruta de backup no puede estar vacía.");

            string query = $"BACKUP DATABASE [{databaseName}] TO DISK = @backupPath";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@backupPath", backupPath);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new SERVICES.Logic.Exceptions.BackupExcepcion($"Error realizando backup: {ex.Message}");
            }
        }

        /// <summary>
        /// Restaura la base de datos a partir del archivo de backup especificado.
        /// </summary>
        /// <param name="restorePath">Ruta del archivo de backup.</param>
        public void PerformRestore(string restorePath)
        {
            if (string.IsNullOrEmpty(restorePath))
                throw new ArgumentException("La ruta de restauración no puede estar vacía.");

            // Utilizar la cadena de conexión para la base de datos master
            string masterConnectionString = connectionString.Replace($"Initial Catalog={databaseName};", "Initial Catalog=master;");

            // Comando para cerrar conexiones activas a la base de datos
            string killConnectionsQuery = $@"
                ALTER DATABASE [{databaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";

            // Comando para restaurar la base de datos y volver a habilitar el modo multiusuario
            string restoreQuery = $@"
                RESTORE DATABASE [{databaseName}] FROM DISK = @restorePath WITH REPLACE;
                ALTER DATABASE [{databaseName}] SET MULTI_USER;";

            try
            {
                using (SqlConnection conn = new SqlConnection(masterConnectionString))
                {
                    conn.Open();

                    using (SqlCommand killCmd = new SqlCommand(killConnectionsQuery, conn))
                    {
                        killCmd.ExecuteNonQuery();
                    }

                    using (SqlCommand restoreCmd = new SqlCommand(restoreQuery, conn))
                    {
                        restoreCmd.Parameters.AddWithValue("@restorePath", restorePath);
                        restoreCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new SERVICES.Logic.Exceptions.RestoreExcepcion($"Error al restaurar la base de datos: {ex.Message}");
            }
        }
    }
}
