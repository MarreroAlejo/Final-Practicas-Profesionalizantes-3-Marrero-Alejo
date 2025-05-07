using System.Configuration;

namespace SERVICES.Dao.Implementations
{
    public class DatabaseConnectionVerifier
    {
        private readonly string mainConnectionString;
        private readonly string servicesConnectionString;

        public DatabaseConnectionVerifier()
        {
            // Se obtienen las cadenas de conexión del archivo app.config.
            mainConnectionString = ConfigurationManager.ConnectionStrings["MainConString"].ConnectionString;
            servicesConnectionString = ConfigurationManager.ConnectionStrings["ServicesConString"].ConnectionString;
        }

        public bool TestMainConnection()
        {
            var connector = new DatabaseConnector(mainConnectionString);
            return connector.TestConnection();
        }

        public bool TestServicesConnection()
        {
            var connector = new DatabaseConnector(servicesConnectionString);
            return connector.TestConnection();
        }

        /// <summary>
        /// Verifica ambas conexiones y retorna true sólo si ambas son exitosas.
        /// </summary>
        public bool AreConnectionsOk()
        {
            return TestMainConnection() && TestServicesConnection();
        }
    }
}
