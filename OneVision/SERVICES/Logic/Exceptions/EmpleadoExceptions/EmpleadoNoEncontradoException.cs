using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Logic.Exceptions.EmpleadoExceptions
{
    public class EmpleadoNoEncontradoException : Exception
    {
        public EmpleadoNoEncontradoException()
            : base("No se encontró un empleado asociado al usuario.") { }
    }
}

