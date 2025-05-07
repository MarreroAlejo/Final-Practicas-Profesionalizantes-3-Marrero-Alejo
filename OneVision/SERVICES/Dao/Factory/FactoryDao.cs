using SERVICES.Dao.Contracts;
using SERVICES.Domain.Composite;
using System;
using System.Configuration;
using SERVICES.Dao.Implementations.SqlServer;

namespace SERVICES.Dao.Factory
{
    /// <summary>
    /// Provee métodos de fábrica para crear instancias de DAO según el tipo de backend configurado.
    /// </summary>
    public class FactoryDao
    {
        private static int backendType;

        /// <summary>
        /// Constructor estático que inicializa el tipo de backend a partir del archivo de configuración.
        /// </summary>
        static FactoryDao()
        {
            backendType = int.Parse(ConfigurationManager.AppSettings["BackendType"]);
        }

        /// <summary>
        /// Crea una instancia de IUsuarioDao de acuerdo al backend configurado.
        /// </summary>
        /// <returns>Instancia de IUsuarioDao.</returns>
        public static IUsuarioDao CreateUsuarioDao()
        {
            switch (backendType)
            {
                case (int)BackendType.SqlServer:
                    return UsuarioRepository.Current;
                default:
                    throw new NotSupportedException("Backend no soportado");
            }
        }

        /// <summary>
        /// Crea una instancia de IJoinRepository para la relación Usuario-Patente.
        /// </summary>
        /// <returns>Instancia de IJoinRepository de Usuario.</returns>
        public static IJoinRepository<Usuario> CreateUsuarioPatenteDao()
        {
            switch (backendType)
            {
                case (int)BackendType.SqlServer:
                    return UsuarioPatenteRepository.Current;
                default:
                    throw new NotSupportedException("Backend no soportado");
            }
        }

        /// <summary>
        /// Crea una instancia de IJoinRepository para la relación Usuario-Familia.
        /// </summary>
        /// <returns>Instancia de IJoinRepository de Usuario.</returns>
        public static IJoinRepository<Usuario> CreateUsuarioFamiliaDao()
        {
            switch (backendType)
            {
                case (int)BackendType.SqlServer:
                    return UsuarioFamiliaRepository.Current;
                default:
                    throw new NotSupportedException("Backend no soportado");
            }
        }

        /// <summary>
        /// Crea una instancia de IGenericDao para la entidad Patente.
        /// </summary>
        /// <returns>Instancia de IGenericDao de Patente.</returns>
        public static IGenericDao<Patente> CreatePatenteDao()
        {
            switch (backendType)
            {
                case (int)BackendType.SqlServer:
                    return PatenteRepository.Current;
                default:
                    throw new NotSupportedException("Backend no soportado");
            }
        }

        /// <summary>
        /// Enumera los tipos de backend soportados.
        /// </summary>
        internal enum BackendType
        {
            /// <summary>
            /// Representa el backend SqlServer.
            /// </summary>
            SqlServer = 1
            // Puedes agregar más tipos de backend aquí.
        }
    }
}
