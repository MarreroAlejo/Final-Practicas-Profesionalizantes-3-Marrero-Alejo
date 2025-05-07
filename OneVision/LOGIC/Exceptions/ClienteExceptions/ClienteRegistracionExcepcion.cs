using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Exceptions.ClienteExceptions
{
    public class ClienteRegistracionExcepcion : Exception
    {
        public ClienteRegistracionExcepcion(string message) : base(message) { }

    }
}
