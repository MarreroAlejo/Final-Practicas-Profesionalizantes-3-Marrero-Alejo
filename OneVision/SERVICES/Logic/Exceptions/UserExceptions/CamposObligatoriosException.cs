using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Logic.Exceptions.UserExceptions
{
    public class CamposObligatoriosException : Exception
    {
        public CamposObligatoriosException()
            : base("Todos los campos obligatorios deben estar completos.") { }
    }
}
