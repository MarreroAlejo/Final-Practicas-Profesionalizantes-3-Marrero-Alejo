using System.Diagnostics;
using System;

/// <summary>
/// Representa una entrada de log con mensaje, nivel de traza y fecha.
/// </summary>
public class Log
{
    /// <summary>
    /// Obtiene o establece el mensaje del log.
    /// </summary>
    public string Message { get; set; }
    /// <summary>
    /// Obtiene o establece el nivel de traza del log.
    /// </summary>
    public TraceLevel TraceLevel { get; set; }
    /// <summary>
    /// Obtiene o establece la fecha en la que se generó el log.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Inicializa una nueva instancia de Log con el mensaje, nivel de traza y fecha especificados.
    /// </summary>
    /// <param name="message">Mensaje del log.</param>
    /// <param name="traceLevel">Nivel de traza.</param>
    /// <param name="date">Fecha del log.</param>
    public Log(string message, TraceLevel traceLevel, DateTime date)
    {
        Message = message;
        TraceLevel = traceLevel;
        Date = date;
    }
}
