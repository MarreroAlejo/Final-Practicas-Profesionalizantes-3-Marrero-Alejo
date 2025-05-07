using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN
{
    /// <summary>
    /// Representa el inventario de un producto en una sucursal.
    /// </summary>
    public class Inventario
    {
        public Guid IdInventario { get; set; }
        public Guid IdProducto { get; set; }
        public Guid IdSucursal { get; set; }
        public int Cantidad { get; set; }
        public int Reserva { get; set; }
        public EstadoInventario Estado { get; set; }

        /// <summary>
        /// Define los estados posibles del inventario.
        /// </summary>
        public enum EstadoInventario
        {
            Suspendido = 0,
            Activo = 1
        }
    }
}
