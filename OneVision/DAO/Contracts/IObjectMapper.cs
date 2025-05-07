using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao.Contracts
{
    /// <summary>
    /// Define un contrato para mapear un arreglo de objetos a un objeto de tipo T.
    /// </summary>
    /// <typeparam name="T">El tipo de objeto al que se mapearán los valores.</typeparam>
    internal interface IObjectMapper<T>
    {
        /// <summary>
        /// Llena un objeto de tipo T con los valores proporcionados en un arreglo de objetos.
        /// </summary>
        /// <param name="values">Un arreglo de objetos que contienen los valores a mapear.</param>
        /// <returns>El objeto de tipo T mapeado con los valores proporcionados.</returns>
        T Fill(object[] values);
    }
}
