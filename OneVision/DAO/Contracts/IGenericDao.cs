using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Contracts
{
    /// <summary>
    /// Define las operaciones genéricas para el manejo de entidades.
    /// </summary>
    /// <typeparam name="T">El tipo de entidad a manejar.</typeparam>
    public interface IGenericDao<T>
    {
        /// <summary>
        /// Registra una nueva entidad.
        /// </summary>
        /// <param name="obj">El objeto entidad a registrar.</param>
        /// <returns>Un entero que indica el resultado del registro.</returns>
        int Registrar(T obj);

        /// <summary>
        /// Edita una entidad existente.
        /// </summary>
        /// <param name="obj">El objeto entidad con los datos modificados.</param>
        /// <returns>Un entero que indica el resultado de la edición.</returns>
        int Editar(T obj);

        /// <summary>
        /// Suspende una entidad identificada por un valor.
        /// </summary>
        /// <param name="obj">El identificador o valor que determina la entidad a suspender.</param>
        /// <returns>Un entero que indica el resultado de la suspensión.</returns>
        int Suspender(string obj);

        /// <summary>
        /// Obtiene todas las entidades registradas.
        /// </summary>
        /// <returns>Una lista de objetos del tipo entidad.</returns>
        List<T> GetAll();

        /// <summary>
        /// Obtiene una entidad según un identificador numérico.
        /// </summary>
        /// <param name="id">El identificador numérico de la entidad.</param>
        /// <returns>El objeto entidad correspondiente.</returns>
        T GetById(int id);

        /// <summary>
        /// Obtiene una entidad según un identificador único (GUID).
        /// </summary>
        /// <param name="id">El identificador GUID de la entidad.</param>
        /// <returns>El objeto entidad correspondiente.</returns>
        T GetByGuid(Guid id);
    }
}
