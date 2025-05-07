using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Domain.Exceptions.UserExceptions
{
    public class ErrorDeLoginException : Exception
    {
        public ErrorDeLoginException() : base("Se produjo un error al intentar iniciar sesión.") { }

        public ErrorDeLoginException(string message, Exception innerException) : base(message, innerException) { }
    }
}
