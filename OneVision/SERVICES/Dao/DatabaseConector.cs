using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Dao.Implementations
{
    public class DatabaseConnector
    {
        private readonly string connectionString;

        public DatabaseConnector(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool TestConnection()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Si se abre correctamente, la conexión es válida.
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Aquí podrías registrar el error si lo consideras necesario.
                return false;
            }
        }
    }

}
