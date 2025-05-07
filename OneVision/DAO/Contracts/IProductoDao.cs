using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Contracts
{
    /// <summary>
    /// Define las operaciones específicas para el manejo de productos, extendiendo las operaciones genéricas.
    /// </summary>
    public interface IProductoDao : IGenericDao<Producto>
    {
        /// <summary>
        /// Selecciona un producto según su código.
        /// </summary>
        /// <param name="categoria">El código del producto a buscar.</param>
        /// <returns>El objeto <see cref="Producto"/> que coincide con el código especificado.</returns>
        Producto SelectByCodigo(string categoria);

        /// <summary>
        /// Registra un nuevo producto.
        /// </summary>
        /// <param name="producto">El objeto <see cref="Producto"/> a registrar.</param>
        /// <returns>El identificador único asignado al producto.</returns>
        Guid RegistrarProducto(Producto producto);

        /// <summary>
        /// Edita la información de un producto existente.
        /// </summary>
        /// <param name="producto">El objeto <see cref="Producto"/> con los datos modificados.</param>
        /// <returns>El identificador único del producto editado.</returns>
        Guid EditarProducto(Producto producto);
    }
}
