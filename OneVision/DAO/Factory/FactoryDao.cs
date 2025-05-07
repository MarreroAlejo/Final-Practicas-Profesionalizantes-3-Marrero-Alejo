using DAO.Contracts;
using DOMAIN;
using System;
using System.Configuration;
using DAO.Implementations.SqlServer;

namespace DAO.Factory
{
    /// <summary>
    /// Provee métodos de fábrica para crear instancias de DAO según el tipo de backend configurado.
    /// </summary>
    public class FactoryDao
    {
        private static int backendType;

        /// <summary>
        /// Constructor estático que inicializa el backendType a partir del app.config.
        /// </summary>
        static FactoryDao()
        {
            backendType = int.Parse(ConfigurationManager.AppSettings["BackendType"]);
        }

        /// <summary>
        /// Crea una instancia de IVentaDao según el tipo de backend configurado.
        /// </summary>
        /// <returns>Instancia de IVentaDao.</returns>
        public static IVentaDao CreateVentaDao()
        {
            switch (backendType)
            {
                case (int)BackendType.SqlServer:
                    return VentaDao.Current;
                default:
                    throw new NotSupportedException("Backend no soportado");
            }
        }

        /// <summary>
        /// Crea una instancia de IPedidoDao según el tipo de backend configurado.
        /// </summary>
        /// <returns>Instancia de IPedidoDao.</returns>
        public static IPedidoDao CreatePedidoDao()
        {
            try
            {
                switch (backendType)
                {
                    case (int)BackendType.SqlServer:
                        return PedidoDao.Current;
                    default:
                        throw new NotSupportedException("El backend especificado no es soportado.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el DAO de Pedido.", ex);
            }
        }

        /// <summary>
        /// Crea una instancia de IClienteDao según el tipo de backend configurado.
        /// </summary>
        /// <returns>Instancia de IClienteDao.</returns>
        public static IClienteDao CreateClienteDao()
        {
            switch (backendType)
            {
                case (int)BackendType.SqlServer:
                    return ClienteDao.Current;
                default:
                    throw new NotSupportedException("Backend no soportado");
            }
        }

        /// <summary>
        /// Crea una instancia de IEmpleados&lt;Empleado&gt; según el tipo de backend configurado.
        /// </summary>
        /// <returns>Instancia de IEmpleados&lt;Empleado&gt;.</returns>
        public static IEmpleados<Empleado> CreateEmpleadoDao()
        {
            switch (backendType)
            {
                case (int)BackendType.SqlServer:
                    return EmpleadoDao.Current;
                default:
                    throw new NotSupportedException("Backend no soportado");
            }
        }

        /// <summary>
        /// Crea una instancia de ISucursalDao según el tipo de backend configurado.
        /// </summary>
        /// <returns>Instancia de ISucursalDao.</returns>
        public static ISucursalDao CreateSucursalDao()
        {
            switch (backendType)
            {
                case (int)BackendType.SqlServer:
                    return SucursalDao.Current;
                default:
                    throw new NotSupportedException("Backend no soportado");
            }
        }

        /// <summary>
        /// Crea una instancia de IProductoDao según el tipo de backend configurado.
        /// </summary>
        /// <returns>Instancia de IProductoDao.</returns>
        public static IProductoDao CreateProductoDao()
        {
            switch (backendType)
            {
                case (int)BackendType.SqlServer:
                    return ProductoDao.Current;
                default:
                    throw new NotSupportedException("Backend no soportado");
            }
        }

        /// <summary>
        /// Crea una instancia de IInventarioDao según el tipo de backend configurado.
        /// </summary>
        /// <returns>Instancia de IInventarioDao.</returns>
        public static IInventarioDao CreateInventarioDao()
        {
            switch (backendType)
            {
                case (int)BackendType.SqlServer:
                    return InventarioDao.Current;
                default:
                    throw new NotSupportedException("Backend no soportado");
            }
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
    }
}
