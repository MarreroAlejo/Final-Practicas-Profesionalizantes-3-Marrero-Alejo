using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Domain.Exceptions.AccesoExceptions
{
    public class AccesoNoValidoException : Exception
    {
        public AccesoNoValidoException(string message) : base(message) { }
    }
}
