using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Exceptions
{
    public class DatosInvalidosException : Exception
    {
        public DatosInvalidosException(string message) : base(message) { }
    }
}
