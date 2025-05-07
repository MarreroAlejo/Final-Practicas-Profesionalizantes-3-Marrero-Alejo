using System;
using System.Collections.Generic;

namespace DOMAIN
{
    /// <summary>
    /// Representa un pedido realizado por un cliente.
    /// </summary>
    public class Pedido
    {
        public Guid IdPedido { get; set; }
        public int NroPedido { get; set; } 
        public Guid IdEmpleado { get; set; }
        public int IdCliente { get; set; }
        public Guid IdSucursal { get; set; } 
        public decimal Total { get; set; }
        public EstadoPedido Estado { get; set; }
        public List<DetallePedido> obj_DetallePedido { get; set; }
        public DateTime FechaRegistro { get; set; }

        /// <summary>
        /// Define los estados posibles de un pedido.
        /// </summary>
        public enum EstadoPedido
        {
            Suspendido = 0,
            Registrado = 1,
            EnCamino = 2,
            Entregado = 3,
            SinRecepcion = 4
        }
    }
}

