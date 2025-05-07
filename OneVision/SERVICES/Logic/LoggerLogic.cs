using SERVICES.Dao;
using System.Collections.Generic;
using System.Diagnostics;
/// <summary>
/// Lógica para el manejo de logs del sistema.
/// </summary>
internal static class LoggerLogic
{
    /// <summary>
    /// Escribe un log en el registro según su nivel de traza.
    /// </summary>
    public static void WriteLog(Log log)
    {
        if (log.TraceLevel == TraceLevel.Info || log.TraceLevel == TraceLevel.Error)
        {
            LoggerDao.WriteLog(log);
        }
    }

    /// <summary>
    /// Escribe un log de acceso.
    /// </summary>
    public static void WriteLogAcceso(Log log)
    {
        LoggerDao.WriteLogAcceso(log);
    }

    /// <summary>
    /// Recupera todos los registros de acceso.
    /// </summary>
    public static List<string> GetAllAcceso()
    {
        return LoggerDao.ReadLogAcceso();
    }
}
