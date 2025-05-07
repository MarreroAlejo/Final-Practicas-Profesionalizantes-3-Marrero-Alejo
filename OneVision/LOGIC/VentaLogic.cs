using DAO.Contracts;
using DAO.Factory;
using DAO.Implementations.SqlServer;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC
{
    /// <summary>
    /// Encapsula la lógica de negocio para la gestión de ventas.
    /// </summary>
    public class VentaLogic
    {
        #region Singleton
        private static VentaLogic instance = new VentaLogic();
        private static object instanceLock = new object();

        /// <summary>
        /// Constructor privado para la implementación del patrón singleton.
        /// </summary>
        private VentaLogic() { }

        /// <summary>
        /// Obtiene la instancia única de VentaLogic.
        /// </summary>
        /// <returns>Instancia de VentaLogic.</returns>
        public static VentaLogic GetInstance()
        {
            if (instance is null)
            {
                lock (instanceLock)
                {
                    if (instance is null)
                    {
                        instance = new VentaLogic();
                    }
                }
            }
            return instance;
        }

        /// <summary>
        /// Propiedad para obtener la instancia única de VentaLogic.
        /// </summary>
        public static VentaLogic Instance
        {
            get
            {
                if (instance is null)
                    instance = new VentaLogic();

                return instance;
            }
        }
        #endregion

        /// <summary>
        /// Obtiene una venta utilizando su identificador GUID.
        /// </summary>
        /// <param name="idVenta">Identificador GUID de la venta.</param>
        /// <returns>Objeto Venta correspondiente.</returns>
        public Venta GetByGuid(Guid idVenta)
        {
            try
            {
                IVentaDao ventaDao = FactoryDao.CreateVentaDao();
                return ventaDao.GetByGuid(idVenta);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la venta: " + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene todas las ventas registradas.
        /// </summary>
        /// <returns>Lista de objetos Venta.</returns>
        public List<Venta> GetAll()
        {
            try
            {
                IVentaDao ventaDao = FactoryDao.CreateVentaDao();
                return ventaDao.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la venta: " + ex.Message);
            }
        }

        /// <summary>
        /// Verifica si existe una venta asociada a un pedido específico.
        /// </summary>
        /// <param name="IdPedido">Identificador del pedido.</param>
        /// <returns>Booleano que indica si existe una venta asociada.</returns>
        public bool VentaAsociadaAPedido(Guid IdPedido)
        {
            IVentaDao ventaDao = FactoryDao.CreateVentaDao();
            return ventaDao.VentaAsociadaAPedido(IdPedido);
        }

        /// <summary>
        /// Registra una nueva venta en el sistema.
        /// </summary>
        /// <param name="Venta">Objeto Venta a registrar.</param>
        /// <returns>Identificador GUID de la venta registrada.</returns>
        public Guid RegistrarVenta(Venta Venta)
        {
            IVentaDao ventaDao = FactoryDao.CreateVentaDao();
            ventaDao.RegistrarVenta(Venta);
            return Venta.IdVenta;
        }

        /// <summary>
        /// Suspende una venta en el sistema.
        /// </summary>
        /// <param name="idVenta">Identificador GUID de la venta a suspender.</param>
        public void SuspenderVenta(Guid idVenta)
        {
            IVentaDao ventaDao = FactoryDao.CreateVentaDao();
            ventaDao.SuspenderVenta(idVenta);
        }

        /// <summary>
        /// Actualiza el stock de la venta basado en el pedido y la sucursal.
        /// </summary>
        /// <param name="idPedido">Identificador del pedido.</param>
        /// <param name="idSucursal">Identificador de la sucursal.</param>
        public void ActualizarStockVenta(Guid idPedido, Guid idSucursal)
        {
            IVentaDao ventaDao = FactoryDao.CreateVentaDao();
            ventaDao.ActualizarStockVenta(idPedido, idSucursal);
        }
    }
}
