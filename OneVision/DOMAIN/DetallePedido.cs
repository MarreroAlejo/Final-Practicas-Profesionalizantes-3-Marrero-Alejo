using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN
{
    /// <summary>
    /// Representa el detalle de un pedido, incluyendo el producto, cantidad y subtotal.
    /// </summary>
    public class DetallePedido
    {
        public Guid IdDetallePedido { get; set; }
        public Guid IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal SubTotal { get; set; }
    }
}
