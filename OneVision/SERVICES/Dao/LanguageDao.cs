using SERVICES.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SERVICES.Dao
{
    /// <summary>
    /// Proporciona métodos para la traducción de claves de lenguaje.
    /// </summary>
    internal static class LanguageDao
    {
        /// <summary>
        /// Ruta base para los archivos de lenguaje, definida en el archivo de configuración.
        /// </summary>
        private static string Path = ConfigurationManager.AppSettings["LanguagePath"];

        /// <summary>
        /// Traduce una clave dada según el idioma actual de la aplicación.
        /// </summary>
        /// <param name="key">Clave de la cadena a traducir.</param>
        /// <returns>Traducción de la clave; si no se encuentra, retorna la clave original.</returns>
        public static string Translate(string key)
        {
            string language = Thread.CurrentThread.CurrentUICulture.Name;
            string fileName = Path + language;

            // FALTA EXCEPCION: NO SE ENCONTRO EL ARCHIVO.
            using (StreamReader str = new StreamReader(fileName))
            {
                while (!str.EndOfStream) // Se utiliza para determinar si el lector ha alcanzado el final del flujo de datos.
                {
                    string line = str.ReadLine();
                    // FALTA EXCEPCION: SE SPLITEO MAL.
                    string[] columns = line.Split('=');
                    if (columns[0].ToLower() == key.ToLower())
                    {
                        // Implementar redis en un futuro.
                        return columns[1];
                    }
                }
            }
            return key;
        }

        /// <summary>
        /// Escribe una clave (método no implementado).
        /// </summary>
        /// <param name="key">Clave a escribir.</param>
        public static void EscribirClave(string key)
        {
            string language = Thread.CurrentThread.CurrentUICulture.Name;
            // Método no implementado
        }

        /// <summary>
        /// Obtiene la lista de idiomas disponibles (método no implementado).
        /// </summary>
        /// <returns>Lista de cadenas representando los idiomas.</returns>
        public static List<string> GetLanguage()
        {
            return new List<string>();
        }
    }
}
