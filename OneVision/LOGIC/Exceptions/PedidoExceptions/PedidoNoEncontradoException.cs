using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Exceptions.PedidoExceptions
{
    public class PedidoNoEncontradoException : Exception
    {
        public PedidoNoEncontradoException(string message) : base(message) { }
    }
}
