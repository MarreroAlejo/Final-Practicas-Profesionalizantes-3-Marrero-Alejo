using SERVICES.Domain.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Dao.Contracts
{
    /// <summary>
    /// Define un contrato para las operaciones de acceso a datos de usuarios.
    /// </summary>
    public interface IUsuarioDao : IGenericDao<Usuario>
    {
        /// <summary>
        /// Selecciona un usuario basado en su nombre de usuario.
        /// </summary>
        /// <param name="username">Nombre de usuario a buscar.</param>
        /// <returns>Objeto Usuario que coincide con el nombre de usuario especificado.</returns>
        Usuario SelectByUsername(string username);
    }
}
