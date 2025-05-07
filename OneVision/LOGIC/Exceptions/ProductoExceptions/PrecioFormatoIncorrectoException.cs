using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Exceptions.ProductoExceptions
{
    public class PrecioFormatoIncorrectoException : Exception
    {
        public PrecioFormatoIncorrectoException(string campo) : base($"{campo} - Formato moneda incorrecto.") { }
    }
}
