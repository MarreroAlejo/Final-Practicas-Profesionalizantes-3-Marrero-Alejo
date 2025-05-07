using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Exceptions.PedidoExceptions
{
    public class PedidoNoValidoException : Exception
    {
        public PedidoNoValidoException(string message) : base(message) { }
    }
}
