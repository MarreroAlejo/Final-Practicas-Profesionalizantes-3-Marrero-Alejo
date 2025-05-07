using SERVICES.Domain;
using SERVICES.Logic;
using System.Collections.Generic;
using System.Diagnostics;

namespace SERVICES.Facade
{
    /// <summary>
    /// Proporciona servicios para escribir y obtener logs, encapsulando la lógica de LoggerLogic.
    /// </summary>
    public class LoggerService
    {
        /// <summary>
        /// Escribe una entrada de log utilizando LoggerLogic.
        /// </summary>
        /// <param name="log">Objeto Log a escribir.</param>
        public static void WriteLog(Log log)
        {
            LoggerLogic.WriteLog(log);
        }

        /// <summary>
        /// Escribe una entrada en el log de accesos.
        /// </summary>
        /// <param name="log">Objeto Log a escribir en el log de accesos.</param>
        public static void WriteLogAcceso(Log log)
        {
            LoggerLogic.WriteLogAcceso(log);
        }

        /// <summary>
        /// Obtiene todas las entradas del log de accesos.
        /// </summary>
        /// <returns>Lista de cadenas con las entradas del log de accesos.</returns>
        public static List<string> GetAllAcceso()
        {
            return LoggerLogic.GetAllAcceso();
        }
    }
}
