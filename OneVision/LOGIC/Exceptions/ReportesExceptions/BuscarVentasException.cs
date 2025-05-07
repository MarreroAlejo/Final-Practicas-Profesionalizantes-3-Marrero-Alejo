using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Exceptions.ReportesExceptions
{
    public class BuscarVentasException : Exception
    {
        public BuscarVentasException(string message) : base(message) { }
    }

}
