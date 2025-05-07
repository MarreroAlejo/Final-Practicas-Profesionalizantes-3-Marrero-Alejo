using SERVICES.Facade;
using SERVICES.Facade.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Domain.Exceptions
{
    internal class PalabraNoEncontradaExcepcion : Exception
    {
        public PalabraNoEncontradaExcepcion(string key) : base(($"No se encontro la {key}.").Translate()) 
        {
            // this.HelpLink = HelpLink; Sirve para documentacion. Se puede implementar una URL.
        }
    }
}
