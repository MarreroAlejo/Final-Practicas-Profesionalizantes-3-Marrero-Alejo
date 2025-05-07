using DAO.Contracts;
using DAO.Factory;
using DAO.Implementations.SqlServer;
using DOMAIN;
using System;

namespace LOGIC
{
    /// <summary>
    /// Encapsula la lógica de negocio para la gestión del inventario.
    /// </summary>
    public class InventarioLogic
    {
        #region Singleton
        private static InventarioLogic instance = new InventarioLogic();
        private static object instanceLock = new object();

        /// <summary>
        /// Constructor privado para la implementación del patrón singleton.
        /// </summary>
        private InventarioLogic() { }

        /// <summary>
        /// Obtiene la instancia única de InventarioLogic.
        /// </summary>
        /// <returns>Instancia única de InventarioLogic.</returns>
        public static InventarioLogic GetInstance()
        {
            if (instance is null)
            {
                lock (instanceLock)
                {
                    if (instance is null)
                    {
                        instance = new InventarioLogic();
                    }
                }
            }
            return instance;
        }

        /// <summary>
        /// Propiedad para obtener la instancia única de InventarioLogic.
        /// </summary>
        public static InventarioLogic Instance
        {
            get
            {
                if (instance is null)
                    instance = new InventarioLogic();

                return instance;
            }
        }
        #endregion

        /// <summary>
        /// Registra un producto en el inventario de una sucursal.
        /// </summary>
        /// <param name="idSucursal">Identificador de la sucursal.</param>
        /// <param name="idProducto">Identificador del producto.</param>
        /// <param name="cantidad">Cantidad a agregar.</param>
        public void RegistrarProductoEnInventario(Guid idSucursal, Guid idProducto, int cantidad)
        {
            IInventarioDao inventarioDao = FactoryDao.CreateInventarioDao();
            inventarioDao.AgregarProductoInventario(idSucursal, idProducto, cantidad);
        }

        /// <summary>
        /// Verifica si un producto existe en el inventario de una sucursal y obtiene la cantidad disponible.
        /// </summary>
        /// <param name="idSucursal">Identificador de la sucursal.</param>
        /// <param name="idProducto">Identificador del producto.</param>
        /// <returns>Tupla con un entero que indica si existe (1 o 0) y la cantidad disponible.</returns>
        public (int existe, int cantidad) VerificarProductoEnInventario(Guid idSucursal, Guid idProducto)
        {
            IInventarioDao inventarioDao = FactoryDao.CreateInventarioDao();
            return inventarioDao.VerificarProductoEnInventario(idSucursal, idProducto);
        }

        /// <summary>
        /// Calcula la disponibilidad de un producto en una sucursal.
        /// </summary>
        /// <param name="idSucursal">Identificador de la sucursal.</param>
        /// <param name="idProducto">Identificador del producto.</param>
        /// <returns>La cantidad disponible del producto.</returns>
        public int CalcularDisponibilidad(Guid idSucursal, Guid idProducto)
        {
            IInventarioDao inventarioDao = FactoryDao.CreateInventarioDao();
            return inventarioDao.CalcularDisponibilidad(idSucursal, idProducto);
        }

        /// <summary>
        /// Actualiza el inventario basado en un pedido para una sucursal.
        /// </summary>
        /// <param name="idPedido">Identificador del pedido.</param>
        /// <param name="idSucursal">Identificador de la sucursal.</param>
        public void ActualizarInventarioPedido(Guid idPedido, Guid idSucursal)
        {
            IInventarioDao inventarioDao = FactoryDao.CreateInventarioDao();
            inventarioDao.ActualizarInventarioPedido(idPedido, idSucursal);
        }
    }
}
