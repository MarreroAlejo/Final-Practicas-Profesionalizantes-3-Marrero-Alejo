using System;

namespace SERVICES.Logic.Exceptions.UserExceptions
{
    /// <summary>
    /// Excepción lanzada cuando las credenciales de usuario (username/contraseña) no son válidas.
    /// </summary>
    public class CredencialesInvalidasException : Exception
    {
        public CredencialesInvalidasException()
            : base("Usuario o contraseña incorrectos.")
        {
        }
    }
}