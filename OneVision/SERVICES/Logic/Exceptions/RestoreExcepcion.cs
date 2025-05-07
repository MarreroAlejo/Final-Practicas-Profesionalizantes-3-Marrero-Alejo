using System;

namespace SERVICES.Logic.Exceptions
{
    /// <summary>
    /// Excepción lanzada cuando ocurre un error durante la restauración de la base de datos.
    /// </summary>
    public class RestoreExcepcion : Exception
    {
        public RestoreExcepcion(string message)
            : base(message)
        {
        }
    }
}
