using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Contracts
{
    /// <summary>
    /// Define las operaciones específicas para el manejo de ventas, extendiendo las operaciones genéricas.
    /// </summary>
    public interface IVentaDao : IGenericDao<Venta>
    {
        /// <summary>
        /// Registra una nueva venta.
        /// </summary>
        /// <param name="venta">El objeto <see cref="Venta"/> a registrar.</param>
        /// <returns>El identificador único asignado a la venta.</returns>
        Guid RegistrarVenta(Venta venta);

        /// <summary>
        /// Verifica si existe una venta asociada a un pedido específico.
        /// </summary>
        /// <param name="idPedido">El identificador del pedido.</param>
        /// <returns><c>true</c> si existe una venta asociada; de lo contrario, <c>false</c>.</returns>
        bool VentaAsociadaAPedido(Guid idPedido);

        /// <summary>
        /// Suspende una venta.
        /// </summary>
        /// <param name="idVenta">El identificador de la venta a suspender.</param>
        void SuspenderVenta(Guid idVenta);

        /// <summary>
        /// Obtiene todas las ventas registradas.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="Venta"/>.</returns>
        List<Venta> GetAll();

        /// <summary>
        /// Obtiene una venta según su identificador único (GUID).
        /// </summary>
        /// <param name="id">El identificador GUID de la venta.</param>
        /// <returns>El objeto <see cref="Venta"/> correspondiente.</returns>
        Venta GetByGuid(Guid id);

        /// <summary>
        /// Actualiza el stock asociado a una venta, basado en el pedido y la sucursal.
        /// </summary>
        /// <param name="idPedido">El identificador del pedido.</param>
        /// <param name="idSucursal">El identificador de la sucursal.</param>
        void ActualizarStockVenta(Guid idPedido, Guid idSucursal);

        /// <summary>
        /// Obtiene una venta según su número.
        /// </summary>
        /// <param name="nroVenta">El número de la venta a buscar.</param>
        /// <returns>El objeto <see cref="Venta"/> correspondiente al número especificado.</returns>
        Venta GetByNroVenta(int nroVenta);
    }
}
