using System;

namespace LOGIC.Exceptions.VentaExceptions
{
    /// <summary>
    /// Excepción que se lanza cuando se intenta registrar una venta para un pedido que ya tiene una venta asociada.
    /// </summary>
    public class VentaYaExistenteException : Exception
    {
        public VentaYaExistenteException()
            : base("Ya existe una venta asociada a este pedido. No se puede crear una nueva venta para el mismo pedido.")
        {
        }
    }
}
