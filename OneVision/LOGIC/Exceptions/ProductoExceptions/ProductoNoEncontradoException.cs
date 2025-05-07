using System;

namespace LOGIC.Exceptions.ProductoExceptions
{
    public class ProductoNoEncontradoException : Exception
    {
        public ProductoNoEncontradoException(string message) : base(message) { }
    }
}
