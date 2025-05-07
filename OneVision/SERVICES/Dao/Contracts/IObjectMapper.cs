using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Dao.Contracts
{
    /// <summary>
    /// Define un contrato para mapear un arreglo de objetos a una entidad de tipo T.
    /// </summary>
    /// <typeparam name="T">Tipo de la entidad resultante.</typeparam>
    internal interface IObjectMapper<T>
    {
        /// <summary>
        /// Convierte un arreglo de valores en una instancia de tipo T.
        /// </summary>
        /// <param name="values">Arreglo de objetos que contienen los valores a mapear.</param>
        /// <returns>Instancia de T con los valores asignados.</returns>
        T Fill(object[] values);
    }
}
