using System;

namespace SERVICES.Logic.Exceptions
{
    /// <summary>
    /// Excepción lanzada cuando ocurre un error durante la realización de un backup.
    /// </summary>
    public class BackupExcepcion : Exception
    {
        public BackupExcepcion(string message)
            : base(message)
        {
        }
    }
}
