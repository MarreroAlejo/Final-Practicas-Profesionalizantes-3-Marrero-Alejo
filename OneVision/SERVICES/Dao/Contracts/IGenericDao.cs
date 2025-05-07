using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Dao.Contracts
{
    /// <summary>
    /// Define un contrato genérico para las operaciones CRUD sobre una entidad.
    /// </summary>
    /// <typeparam name="T">Tipo de la entidad.</typeparam>
    public interface IGenericDao<T>
    {
        /// <summary>
        /// Registra una nueva entidad.
        /// </summary>
        /// <param name="obj">Objeto de tipo T a registrar.</param>
        /// <returns>Identificador GUID de la entidad registrada.</returns>
        Guid Registrar(T obj);

        /// <summary>
        /// Edita una entidad existente.
        /// </summary>
        /// <param name="obj">Objeto de tipo T con los datos modificados.</param>
        /// <returns>Identificador GUID de la entidad editada.</returns>
        Guid Editar(T obj);

        /// <summary>
        /// Elimina una entidad identificada por un entero.
        /// </summary>
        /// <param name="obj">Identificador entero de la entidad a eliminar.</param>
        /// <returns>Identificador GUID de la entidad eliminada.</returns>
        Guid Eliminar(int obj);

        /// <summary>
        /// Obtiene todas las entidades registradas.
        /// </summary>
        /// <returns>Lista de objetos de tipo T.</returns>
        List<T> GetAll();

        /// <summary>
        /// Obtiene una entidad a partir de su identificador GUID.
        /// </summary>
        /// <param name="id">Identificador GUID de la entidad.</param>
        /// <returns>Objeto de tipo T encontrado.</returns>
        T GetById(Guid id);
    }
}
