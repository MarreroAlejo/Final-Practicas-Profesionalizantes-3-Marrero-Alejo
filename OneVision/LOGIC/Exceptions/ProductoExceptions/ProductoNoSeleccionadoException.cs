using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Exceptions.ProductoExceptions
{
    public class ProductoNoSeleccionadoException : Exception
    {
        public ProductoNoSeleccionadoException() : base("Debe seleccionar un producto.") { }
    }
}
