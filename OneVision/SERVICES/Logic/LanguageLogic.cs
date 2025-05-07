using SERVICES.Dao;
using SERVICES.Domain.Exceptions;
using System;
/// <summary>
/// Lógica para traducción de claves.
/// </summary>
internal static class LanguageLogic
{
    /// <summary>
    /// Traduce una clave de idioma. Registra la clave si no existe.
    /// </summary>
    public static string Translate(string key)
    {
        try
        {
            return LanguageDao.Translate(key);
        }
        catch (PalabraNoEncontradaExcepcion ex)
        {
            LanguageDao.EscribirClave(key);
            throw ex;
        }
        catch (Exception)
        {
            // No hace nada con otras excepciones
        }
        return key;
    }
}
