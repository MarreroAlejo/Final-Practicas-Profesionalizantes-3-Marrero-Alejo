using System;

namespace DOMAIN
{
    /// <summary>
    /// Representa una venta realizada en el sistema.
    /// </summary>
    public class Venta
    {
        public Guid IdVenta { get; set; }
        public Guid IdPedido { get; set; }
        public decimal ValorFlete { get; set; }
        public decimal Total { get; set; }
        public EstadoVenta Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int NroVenta { get; set; } // Nuevo atributo

        public enum EstadoVenta
        {
            Anulada = 0,
            Generada = 1
        }
    }
}
