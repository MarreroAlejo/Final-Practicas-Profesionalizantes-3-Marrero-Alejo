using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Domain.Exceptions.UserExceptions
{
    public class CredencialesInvalidasException : Exception
    {
        public CredencialesInvalidasException() : base("Las credenciales son incorrectas.") { }

        public CredencialesInvalidasException(string message) : base(message) { }
    }
}
