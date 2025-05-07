using System;

namespace LOGIC.Exceptions.ProductoExceptions
{
    /// <summary>
    /// Excepción lanzada cuando la cantidad a agregar excede el stock disponible.
    /// </summary>
    public class CantidadExcedidaException : Exception
    {
        public CantidadExcedidaException(string message) : base(message)
        {
        }
    }
}
