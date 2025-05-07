using SERVICES.Domain;
using SERVICES.Domain.Composite;
using SERVICES.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Facade
{
    /// <summary>
    /// Proporciona servicios relacionados con la gestión de usuarios.
    /// </summary>
    public static class UserService
    {
        /// <summary>
        /// Selecciona un usuario basado en su nombre de usuario.
        /// </summary>
        /// <param name="username">Nombre de usuario a buscar.</param>
        public static void SelectByUsername(string username)
        {
            UserLogic.Instance.SelectByUsername(username);
        }

        /// <summary>
        /// Obtiene un usuario por su identificador GUID.
        /// </summary>
        /// <param name="guid">Identificador GUID del usuario.</param>
        public static void GetById(Guid guid)
        {
            UserLogic.Instance.GetById(guid);
        }
    }
}
