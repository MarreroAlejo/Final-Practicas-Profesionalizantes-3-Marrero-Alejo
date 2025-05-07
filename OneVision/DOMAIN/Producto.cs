using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN
{
    /// <summary>
    /// Representa un producto del sistema.
    /// </summary>
    public class Producto
    {
        public Guid IdProducto { get; set; }
        public string CodProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioCompra { get; set; }
        public EstadoProducto Estado { get; set; }

        /// <summary>
        /// Define los estados posibles para un producto.
        /// </summary>
        public enum EstadoProducto
        {
            Suspendido = 0,
            Activo = 1
        }

    }
}

