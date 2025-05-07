using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Exceptions.VentasExceptions
{
    public class RegistroVentaException : Exception
    {
        public RegistroVentaException(string message) : base(message) { }
    }
}
