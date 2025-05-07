using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Contracts
{
    /// <summary>
    /// Define las operaciones específicas para el manejo del inventario, extendiendo las operaciones genéricas.
    /// </summary>
    public interface IInventarioDao : IGenericDao<Inventario>
    {
        /// <summary>
        /// Calcula la disponibilidad de un producto en una sucursal específica.
        /// </summary>
        /// <param name="idSucursal">El identificador de la sucursal.</param>
        /// <param name="idProducto">El identificador del producto.</param>
        /// <returns>Un entero que representa la disponibilidad.</returns>
        int CalcularDisponibilidad(Guid idSucursal, Guid idProducto);

        /// <summary>
        /// Agrega un producto al inventario.
        /// </summary>
        /// <param name="idInventario">El identificador del inventario.</param>
        /// <param name="idProducto">El identificador del producto.</param>
        /// <param name="cantidad">La cantidad a agregar.</param>
        void AgregarProductoInventario(Guid idInventario, Guid idProducto, int cantidad);

        /// <summary>
        /// Actualiza el inventario basado en un pedido.
        /// </summary>
        /// <param name="idPedido">El identificador del pedido.</param>
        /// <param name="idSucursal">El identificador de la sucursal.</param>
        void ActualizarInventarioPedido(Guid idPedido, Guid idSucursal);

        /// <summary>
        /// Verifica si un producto existe en el inventario de una sucursal y la cantidad disponible.
        /// </summary>
        /// <param name="idSucursal">El identificador de la sucursal.</param>
        /// <param name="idProducto">El identificador del producto.</param>
        /// <returns>
        /// Una tupla donde el primer valor indica si existe y el segundo la cantidad disponible.
        /// </returns>
        (int existe, int cantidad) VerificarProductoEnInventario(Guid idSucursal, Guid idProducto);
    }
}
