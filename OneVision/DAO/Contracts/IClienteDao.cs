using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Contracts
{
    /// <summary>
    /// Define las operaciones específicas para el manejo de clientes, extendiendo las operaciones genéricas.
    /// </summary>
    public interface IClienteDao : IGenericDao<Cliente>
    {
        /// <summary>
        /// Selecciona un cliente según el apellido.
        /// </summary>
        /// <param name="apellido">El apellido del cliente a buscar.</param>
        /// <returns>El objeto <see cref="Cliente"/> que coincide con el apellido especificado.</returns>
        Cliente SelectByApellido(string apellido);

        /// <summary>
        /// Selecciona un cliente según el número de documento.
        /// </summary>
        /// <param name="nroDocumento">El número de documento del cliente a buscar.</param>
        /// <returns>El objeto <see cref="Cliente"/> que coincide con el número de documento.</returns>
        Cliente SelectByDocumento(string nroDocumento);

        /// <summary>
        /// Selecciona un cliente según el nombre.
        /// </summary>
        /// <param name="nombre">El nombre del cliente a buscar.</param>
        /// <returns>El objeto <see cref="Cliente"/> que coincide con el nombre.</returns>
        Cliente SelectByNombre(string nombre);
    }
}
