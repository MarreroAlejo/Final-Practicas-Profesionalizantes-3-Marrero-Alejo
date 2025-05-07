using DAO.Contracts;
using DAO.Factory;
using DAO.Implementations.SqlServer;
using DOMAIN;
using LOGIC.Exceptions.PedidoExceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DOMAIN.Pedido;

namespace LOGIC
{
    /// <summary>
    /// Encapsula la lógica de negocio para la gestión de pedidos.
    /// </summary>
    public class PedidoLogic
    {
        #region Singleton
        private static PedidoLogic instance = new PedidoLogic();
        private static object instanceLock = new object();

        /// <summary>
        /// Constructor privado para la implementación del patrón singleton.
        /// </summary>
        private PedidoLogic() { }

        /// <summary>
        /// Obtiene la instancia única de PedidoLogic.
        /// </summary>
        /// <returns>Instancia de PedidoLogic.</returns>
        public static PedidoLogic GetInstance()
        {
            if (instance is null)
            {
                lock (instanceLock)
                {
                    if (instance is null)
                    {
                        instance = new PedidoLogic();
                    }
                }
            }
            return instance;
        }

        /// <summary>
        /// Propiedad para obtener la instancia única de PedidoLogic.
        /// </summary>
        public static PedidoLogic Instance
        {
            get
            {
                if (instance is null)
                    instance = new PedidoLogic();

                return instance;
            }
        }
        #endregion

        /// <summary>
        /// Obtiene todos los pedidos registrados.
        /// </summary>
        /// <returns>Lista de objetos Pedido.</returns>
        public List<Pedido> GetAll()
        {
            try
            {
                IPedidoDao pedidoDao = FactoryDao.CreatePedidoDao();
                return pedidoDao.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el pedido: " + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene un pedido utilizando su identificador GUID.
        /// </summary>
        /// <param name="idPedido">Identificador GUID del pedido.</param>
        /// <returns>Objeto Pedido correspondiente.</returns>
        public Pedido GetByGuid(Guid idPedido)
        {
            try
            {
                IPedidoDao pedidoDao = FactoryDao.CreatePedidoDao();
                return pedidoDao.GetByGuid(idPedido);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la venta: " + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene un pedido utilizando su número de pedido.
        /// </summary>
        /// <param name="nroPedido">Número del pedido.</param>
        /// <returns>Objeto Pedido correspondiente.</returns>
        public Pedido GetPedidoByNro(int nroPedido)
        {
            try
            {
                IPedidoDao pedidoDao = FactoryDao.CreatePedidoDao();
                return pedidoDao.GetPedidoByNro(nroPedido);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la venta: " + ex.Message);
            }
        }

        /// <summary>
        /// Registra un nuevo pedido en el sistema.
        /// </summary>
        /// <param name="pedido">Objeto Pedido a registrar.</param>
        /// <returns>Identificador GUID generado para el pedido; Guid.Empty en caso de fallo.</returns>
        public Guid RegistrarPedido(Pedido pedido)
        {
            IPedidoDao pedidoDao = FactoryDao.CreatePedidoDao();

            if (pedido.IdPedido != Guid.Empty)
            {
                // Registrar nuevo pedido y devolver el IdPedido generado.
                return pedidoDao.RegistrarPedido(pedido);
            }

            return Guid.Empty; // Si no se genera un nuevo pedido, devuelve Guid.Empty.
        }

        /// <summary>
        /// Obtiene la lista de detalles de un pedido dado su identificador GUID.
        /// </summary>
        /// <param name="IdPedido">Identificador GUID del pedido.</param>
        /// <returns>Lista de objetos DetallePedido asociados al pedido.</returns>
        public List<DetallePedido> ObtenerDetallePedido(Guid IdPedido)
        {
            IPedidoDao pedidoDao = FactoryDao.CreatePedidoDao();
            return pedidoDao.ObtenerDetallePedido(IdPedido);
        }

        /// <summary>
        /// Actualiza el estado de un pedido.
        /// </summary>
        /// <param name="NroPedido">Número del pedido.</param>
        /// <param name="nuevoEstado">Nuevo estado a asignar al pedido.</param>
        public void ActualizarEstadoPedido(int NroPedido, Pedido.EstadoPedido nuevoEstado)
        {
            IPedidoDao pedidoDao = FactoryDao.CreatePedidoDao();
            pedidoDao.ActualizarEstadoPedido(NroPedido, nuevoEstado);
        }

        /// <summary>
        /// Suspende un pedido utilizando su número.
        /// </summary>
        /// <param name="nroPedido">Número del pedido a suspender.</param>
        public void SuspenderPedido(int nroPedido)
        {
            try
            {
                IPedidoDao pedidoDao = FactoryDao.CreatePedidoDao();
                var pedido = pedidoDao.GetPedidoByNro(nroPedido);

                if (pedido == null)
                {
                    throw new PedidoNoValidoException("El pedido no existe o el número es inválido.");
                }

                if (pedido.Estado == Pedido.EstadoPedido.Suspendido || pedido.Estado == Pedido.EstadoPedido.EnCamino || pedido.Estado == Pedido.EstadoPedido.Entregado)
                {
                    throw new EstadoNoValidoException($"El pedido no puede suspenderse porque está en el estado '{pedido.Estado}'.");
                }

                pedidoDao.SuspenderPedido(nroPedido);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar suspender el pedido.", ex);
            }
        }
    }
}
