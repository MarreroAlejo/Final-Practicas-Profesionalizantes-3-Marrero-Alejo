using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Contracts
{
    /// <summary>
    /// Define las operaciones específicas para el manejo de pedidos, extendiendo las operaciones genéricas.
    /// </summary>
    public interface IPedidoDao : IGenericDao<Pedido>
    {
        /// <summary>
        /// Registra un nuevo pedido.
        /// </summary>
        /// <param name="pedido">El objeto <see cref="Pedido"/> a registrar.</param>
        /// <returns>El identificador único asignado al pedido.</returns>
        Guid RegistrarPedido(Pedido pedido);

        /// <summary>
        /// Obtiene el detalle de un pedido según su identificador.
        /// </summary>
        /// <param name="IdPedido">El identificador único del pedido.</param>
        /// <returns>Una lista de objetos <see cref="DetallePedido"/> asociados al pedido.</returns>
        List<DetallePedido> ObtenerDetallePedido(Guid IdPedido);

        /// <summary>
        /// Actualiza el estado de un pedido.
        /// </summary>
        /// <param name="nroPedido">El número del pedido.</param>
        /// <param name="nuevoEstado">El nuevo estado a asignar al pedido.</param>
        void ActualizarEstadoPedido(int nroPedido, Pedido.EstadoPedido nuevoEstado);

        /// <summary>
        /// Suspende un pedido.
        /// </summary>
        /// <param name="nroPedido">El número del pedido a suspender.</param>
        void SuspenderPedido(int nroPedido);

        /// <summary>
        /// Obtiene un pedido según su número.
        /// </summary>
        /// <param name="nroPedido">El número del pedido a buscar.</param>
        /// <returns>El objeto <see cref="Pedido"/> correspondiente al número especificado.</returns>
        Pedido GetPedidoByNro(int nroPedido);
    }
}
