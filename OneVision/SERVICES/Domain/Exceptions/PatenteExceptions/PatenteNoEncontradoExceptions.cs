using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Domain.Exceptions.PatenteExceptions
{
    public class PatenteNoEncontradoExceptions : Exception
    {
        public PatenteNoEncontradoExceptions(string message) : base(message) { }
    }
}
