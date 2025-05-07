using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Exceptions.SucursalExceptions
{
    public class SucursalCargaException : Exception
    {
        public SucursalCargaException(string message) : base(message) { }
    }
}
