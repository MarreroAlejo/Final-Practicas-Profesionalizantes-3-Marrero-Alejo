using Dao.Helpers;
using DAO.Contracts;
using DAO.Implementations.SqlServer.Mappers;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Implementations.SqlServer;

namespace DAO.Implementations.SqlServer
{
    /// <summary>
    /// Implementa la interfaz IProductoDao para el manejo de productos en la base de datos.
    /// </summary>
    public sealed class ProductoDao : IProductoDao
    {
        #region Singleton
        private readonly static ProductoDao _instance = new ProductoDao();

        /// <summary>
        /// Obtiene la instancia única (singleton) de ProductoDao.
        /// </summary>
        public static ProductoDao Current
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Constructor privado para evitar instanciación externa.
        /// </summary>
        private ProductoDao()
        {
            // Implement here the initialization of your singleton
        }
        #endregion

        /// <summary>
        /// Registra un producto en la base de datos. (No implementado)
        /// </summary>
        /// <param name="obj">El objeto Producto a registrar.</param>
        /// <returns>Entero indicando el resultado de la operación.</returns>
        public int Registrar(Producto obj)
        {
            return 0;
        }

        /// <summary>
        /// Registra un producto en la base de datos y retorna su identificador generado.
        /// </summary>
        /// <param name="obj">El objeto Producto a registrar.</param>
        /// <returns>El identificador GUID generado para el producto.</returns>
        public Guid RegistrarProducto(Producto obj)
        {
            Guid idProductoGenerado = Guid.Empty;

            try
            {
                // Parámetro de salida para capturar el IdProducto
                SqlParameter idProductoParameter = new SqlParameter("@idProducto", SqlDbType.UniqueIdentifier)
                {
                    Direction = ParameterDirection.Output
                };

                SqlHelper.ExecuteNonQuery("sp_RegistrarProducto", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@codProducto", obj.CodProducto),
                        new SqlParameter("@nombre", obj.Nombre),
                        new SqlParameter("@descripcion", obj.Descripcion),
                        new SqlParameter("@categoria", obj.Categoria),
                        new SqlParameter("@precioVenta", obj.PrecioVenta),
                        new SqlParameter("@precioCompra", obj.PrecioCompra),
                        new SqlParameter("@estado", (int)obj.Estado), // Conversión de enum a entero
                        idProductoParameter // Parámetro de salida para el ID generado
                    }
                );

                idProductoGenerado = (Guid)idProductoParameter.Value;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar el producto: " + ex.Message);
            }

            return idProductoGenerado;
        }

        /// <summary>
        /// Edita la información de un producto existente en la base de datos y retorna su identificador.
        /// </summary>
        /// <param name="obj">El objeto Producto con la información a editar.</param>
        /// <returns>El identificador GUID del producto editado.</returns>
        public Guid EditarProducto(Producto obj)
        {
            try
            {
                // Aquí eliminamos el parámetro de salida
                SqlParameter idParam = new SqlParameter("@idProducto", obj.IdProducto);

                SqlHelper.ExecuteNonQuery("sp_EditarProducto", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        idParam,
                        new SqlParameter("@codProducto", obj.CodProducto),
                        new SqlParameter("@nombre", obj.Nombre),
                        new SqlParameter("@descripcion", obj.Descripcion),
                        new SqlParameter("@categoria", obj.Categoria),
                        new SqlParameter("@precioVenta", obj.PrecioVenta),
                        new SqlParameter("@precioCompra", obj.PrecioCompra),
                        new SqlParameter("@estado", (int)obj.Estado)
                    }
                );

                // Si no estás utilizando un OUTPUT, puedes simplemente devolver el IdProducto
                return obj.IdProducto; // Retornamos el ID del producto editado
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar el producto: " + ex.Message);
            }
        }

        /// <summary>
        /// Edita un producto. (No implementado)
        /// </summary>
        /// <param name="obj">El objeto Producto a editar.</param>
        /// <returns>Entero indicando el resultado de la operación.</returns>
        public int Editar(Producto obj)
        {
            return 0;
        }

        /// <summary>
        /// Suspende un producto. (No implementado)
        /// </summary>
        /// <param name="obj">Identificador o valor que determina el producto a suspender.</param>
        /// <returns>Entero indicando el resultado de la operación.</returns>
        public int Suspender(string obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene todos los productos registrados.
        /// </summary>
        /// <returns>Lista de objetos Producto.</returns>
        public List<Producto> GetAll()
        {
            List<Producto> productos = new List<Producto>();

            using (var reader = SqlHelper.ExecuteReader("sp_GetAllProductos", CommandType.StoredProcedure,
                new SqlParameter[] { }))
            {
                // Mientras tenga algo en la tabla de productos
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    // Data Mapper...
                    Producto producto = ProductoMapper.Current.Fill(data);
                    productos.Add(producto);
                }
            }
            return productos;
        }

        /// <summary>
        /// Obtiene un producto por su identificador GUID.
        /// </summary>
        /// <param name="id">Identificador GUID del producto.</param>
        /// <returns>El objeto Producto encontrado o default si no existe.</returns>
        public Producto GetByGuid(Guid id)
        {
            Producto producto = default;

            using (var reader = SqlHelper.ExecuteReader("sp_GetProductoById", CommandType.StoredProcedure,
              new SqlParameter[] { new SqlParameter("@idProducto", id) }))
            {
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    producto = ProductoMapper.Current.Fill(data);
                }
            }

            return producto;
        }

        /// <summary>
        /// Obtiene un producto por su identificador numérico. (No implementado)
        /// </summary>
        /// <param name="id">Identificador numérico del producto.</param>
        /// <returns>El objeto Producto encontrado.</returns>
        public Producto GetById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Selecciona un producto por su código.
        /// </summary>
        /// <param name="codigo">Código del producto a buscar.</param>
        /// <returns>El objeto Producto encontrado o default si no existe.</returns>
        public Producto SelectByCodigo(string codigo)
        {
            Producto producto = default;

            using (var reader = SqlHelper.ExecuteReader("sp_GetProductoByCodigo", CommandType.StoredProcedure,
              new SqlParameter[] { new SqlParameter("@Codigo", codigo) }))
            {
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    producto = ProductoMapper.Current.Fill(data);
                }
            }

            return producto;
        }
    }
}
