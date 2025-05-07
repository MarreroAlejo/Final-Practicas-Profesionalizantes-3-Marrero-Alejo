using System;

namespace SERVICES.Logic.Exceptions.UserExceptions
{
    /// <summary>
    /// Excepción que se lanza cuando el nombre de usuario ya está en uso por otro usuario.
    /// </summary>
    public class UsernameYaExisteException : Exception
    {
        public UsernameYaExisteException(string message)
            : base(message)
        {
        }
    }
}
