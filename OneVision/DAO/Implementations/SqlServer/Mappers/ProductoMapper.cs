using Dao.Contracts;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Implementations.SqlServer.Mappers
{
    internal sealed class ProductoMapper : IObjectMapper<Producto>
    {
        #region singleton

        // Patron Singleton: asegura que solo exista una única instancia de la clase durante todo el ciclo de vida del programa.

        private readonly static ProductoMapper _instance = new ProductoMapper();

        public static ProductoMapper Current
        {
            get
            {
                return _instance;
            }
        }

        private ProductoMapper()
        {

        }
        #endregion
        public Producto Fill(object[] values)
        {
            try
            {
                var producto = new Producto
                {
                    IdProducto = Guid.Parse(values[(int)ProductoColumns.idProducto].ToString()),
                    CodProducto = values[(int)ProductoColumns.codProducto].ToString(),
                    Nombre = values[(int)ProductoColumns.nombre].ToString(),
                    Descripcion = values[(int)ProductoColumns.descripcion].ToString(),
                    Categoria = values[(int)ProductoColumns.categoria].ToString(),
                    PrecioVenta = Convert.ToDecimal(values[(int)ProductoColumns.precioVenta]),
                    PrecioCompra = Convert.ToDecimal(values[(int)ProductoColumns.precioCompra]),
                    Estado = (Producto.EstadoProducto)int.Parse(values[(int)ProductoColumns.estado].ToString())
                };

                return producto;
            }
            catch (FormatException ex)
            {
                throw new Exception("Error de formato al llenar el producto: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al llenar el producto: " + ex.Message);
            }
        }

        internal enum ProductoColumns
        {
            idProducto = 0,
            codProducto = 1,
            nombre = 2,
            descripcion = 3,
            categoria = 4,
            precioVenta = 5,
            precioCompra = 6,
            estado = 7,
        }

    }

}
