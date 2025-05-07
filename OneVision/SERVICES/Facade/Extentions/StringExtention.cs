using SERVICES.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Facade.Extentions
{
    /// <summary>
    /// Proporciona métodos de extensión para la clase string.
    /// </summary>
    public static class StringExtention
    {
        /// <summary>
        /// Traduce una clave de lenguaje utilizando la lógica definida en LanguageLogic.
        /// </summary>
        /// <param name="key">Clave de la cadena a traducir.</param>
        /// <returns>Cadena traducida según el idioma actual.</returns>
        public static string Translate(this string key)
        {
            return LanguageLogic.Translate(key);
        }
    }
}
