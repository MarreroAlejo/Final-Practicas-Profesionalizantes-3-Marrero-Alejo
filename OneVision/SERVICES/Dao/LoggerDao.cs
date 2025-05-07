using SERVICES.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace SERVICES.Dao
{
    /// <summary>
    /// Proporciona métodos para escribir y leer bitácoras (logs) en archivos.
    /// </summary>
    internal static class LoggerDao
    {
        /// <summary>
        /// Ruta base donde se encuentra el ejecutable de la aplicación.
        /// </summary>
        private static readonly string BasePath = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// Ruta completa del archivo de log de errores, calculada a partir del archivo de configuración.
        /// </summary>
        private static readonly string PathLogError = Path.Combine(BasePath, ConfigurationManager.AppSettings["PathLogError"]);

        /// <summary>
        /// Ruta completa del archivo de log de información, calculada a partir del archivo de configuración.
        /// </summary>
        private static readonly string PathLogInfo = Path.Combine(BasePath, ConfigurationManager.AppSettings["PathLogInfo"]);

        /// <summary>
        /// Ruta completa del archivo de log de accesos, calculada a partir del archivo de configuración.
        /// </summary>
        private static readonly string PathLogAcceso = Path.Combine(BasePath, ConfigurationManager.AppSettings["PathLogAccesos"]);

        /// <summary>
        /// Escribe una entrada de log en el archivo correspondiente según el nivel de traza.
        /// </summary>
        /// <param name="log">Objeto Log que contiene la fecha, el nivel y el mensaje.</param>
        public static void WriteLog(Log log)
        {
            switch (log.TraceLevel)
            {
                case TraceLevel.Error:
                    WriteToFile(PathLogError, FormatMessage(log));
                    break;
                case TraceLevel.Info:
                    WriteToFile(PathLogInfo, FormatMessage(log));
                    break;
            }
        }

        /// <summary>
        /// Lee el archivo de log de accesos, incorporando la fecha en el nombre del archivo.
        /// </summary>
        /// <returns>Lista de cadenas con las entradas de log de accesos.</returns>
        public static List<string> ReadLogAcceso()
        {
            List<string> logs = new List<string>();

            string fileName = System.IO.Path.GetFileName(PathLogAcceso);
            string dailyLogPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(PathLogAcceso), DateTime.Now.ToString("dd-MM-yyyy") + "_" + fileName);

            if (File.Exists(dailyLogPath))
            {
                using (StreamReader sr = new StreamReader(dailyLogPath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        logs.Add(line);
                    }
                }
            }
            else
            {
                Console.WriteLine("El archivo de log no existe.");
            }

            return logs;
        }

        /// <summary>
        /// Escribe una entrada de log en el archivo de log de accesos.
        /// </summary>
        /// <param name="log">Objeto Log a escribir.</param>
        public static void WriteLogAcceso(Log log)
        {
            WriteToFile(PathLogAcceso, FormatMessage(log));
        }

        /// <summary>
        /// Formatea un objeto Log en una cadena de texto.
        /// </summary>
        /// <param name="log">Objeto Log a formatear.</param>
        /// <returns>Cadena formateada con la fecha, nivel y mensaje del log.</returns>
        private static string FormatMessage(Log log)
        {
            return $"{log.Date:dd-MM-yyyy HH:mm:ss} [{log.TraceLevel}] : {log.Message}";
        }

        /// <summary>
        /// Escribe (o anexa) un mensaje en un archivo, asegurándose de que el directorio exista.
        /// </summary>
        /// <param name="path">Ruta completa del archivo.</param>
        /// <param name="message">Mensaje a escribir.</param>
        private static void WriteToFile(string path, string message)
        {
            // Asegurar que el directorio exista
            string directory = System.IO.Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Escribir en el archivo (anexar si existe)
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
