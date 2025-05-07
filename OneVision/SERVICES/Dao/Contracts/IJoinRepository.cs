using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Dao.Contracts
{
    /// <summary>
    /// Define un contrato para operaciones de repositorio que involucran la unión (join) de entidades.
    /// </summary>
    /// <typeparam name="T">Tipo de entidad involucrada en la unión.</typeparam>
    public interface IJoinRepository<T>
    {
        /// <summary>
        /// Agrega una nueva relación o entrada de tipo T.
        /// </summary>
        /// <param name="obj">Objeto de tipo T a agregar.</param>
        void Add(T obj);

        /// <summary>
        /// Elimina una relación o entrada de tipo T.
        /// </summary>
        /// <param name="obj">Objeto de tipo T a eliminar.</param>
        void Delete(T obj);

        /// <summary>
        /// Obtiene la cantidad de relaciones o entradas de tipo T.
        /// </summary>
        /// <param name="obj">Objeto de tipo T para contar sus relaciones.</param>
        void GetCount(T obj);
    }
}
