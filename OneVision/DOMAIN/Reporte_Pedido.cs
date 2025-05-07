using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN
{
    /// <summary>
    /// Representa un reporte consolidado de un pedido, incluyendo información del cliente, producto y totales.
    /// </summary>
    public class Reporte_Pedido
    {
        public string FechaRegistro { get; set; }
        public string IdPedido { get; set; }
        public string IdCliente { get; set; }
        public string Cliente { get; set; }
        public string ValorTotal { get; set; }
        public string IdProducto { get; set; }
        public string CodigoProducto { get; set; }
        public string Producto { get; set; }
        public string Categoria { get; set; }
        public string Precio { get; set; }
        public string Cantidad { get; set; }
        public string Subtotal { get; set; }
    }
}
