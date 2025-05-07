using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Contracts
{
    /// <summary>
    /// Define las operaciones específicas para el manejo de sucursales, extendiendo las operaciones genéricas.
    /// </summary>
    public interface ISucursalDao : IGenericDao<Sucursal>
    {
        /// <summary>
        /// Obtiene una sucursal según su nombre.
        /// </summary>
        /// <param name="nombre">El nombre de la sucursal a buscar.</param>
        /// <returns>El objeto <see cref="Sucursal"/> que coincide con el nombre especificado.</returns>
        Sucursal GetSucursalByNombre(string nombre);
    }
}
