using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Domain.Exceptions
{
    public class OperacionNoPermitidaEnPatente : InvalidOperationException
    {
        public OperacionNoPermitidaEnPatente() : base("No se puede agregar o quitar elementos de una patente.") { }
    }

}
