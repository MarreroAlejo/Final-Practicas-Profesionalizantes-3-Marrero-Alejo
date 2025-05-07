using DAO.Contracts;
using DAO.Factory;
using DAO.Implementations.SqlServer;
using DOMAIN;
using LOGIC.Exceptions.ProductoExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC
{
    /// <summary>
    /// Encapsula la lógica de negocio para la gestión de productos.
    /// </summary>
    public class ProductoLogic
    {
        #region Singleton
        private static ProductoLogic instance = new ProductoLogic();
        private static object instanceLock = new object();

        /// <summary>
        /// Constructor privado para la implementación del patrón singleton.
        /// </summary>
        private ProductoLogic() { }

        /// <summary>
        /// Obtiene la instancia única de ProductoLogic.
        /// </summary>
        /// <returns>Instancia de ProductoLogic.</returns>
        public static ProductoLogic GetInstance()
        {
            if (instance is null)
            {
                lock (instanceLock)
                {
                    if (instance is null)
                    {
                        instance = new ProductoLogic();
                    }
                }
            }
            return instance;
        }

        /// <summary>
        /// Propiedad para obtener la instancia única de ProductoLogic.
        /// </summary>
        public static ProductoLogic Instance
        {
            get
            {
                if (instance is null)
                    instance = new ProductoLogic();

                return instance;
            }
        }
        #endregion

        /// <summary>
        /// Obtiene un producto utilizando su identificador GUID.
        /// </summary>
        /// <param name="id">Identificador GUID del producto.</param>
        /// <returns>Objeto Producto correspondiente.</returns>
        public Producto GetByGuid(Guid id)
        {
            try
            {
                IProductoDao productoDao = FactoryDao.CreateProductoDao();
                return productoDao.GetByGuid(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el producto: " + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene todos los productos registrados.
        /// </summary>
        /// <returns>Lista de objetos Producto.</returns>
        public List<Producto> GetAll()
        {
            try
            {
                IProductoDao productoDao = FactoryDao.CreateProductoDao();
                return productoDao.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el producto: " + ex.Message);
            }
        }

        /// <summary>
        /// Registra un nuevo producto en el sistema.
        /// </summary>
        /// <param name="producto">Objeto Producto a registrar.</param>
        /// <returns>Identificador GUID generado para el producto; Guid.Empty si no se genera.</returns>
        public Guid RegistrarProducto(Producto producto)
        {
            IProductoDao productoDao = FactoryDao.CreateProductoDao();

            if (producto.IdProducto == Guid.Empty)
            {
                // Registrar nuevo producto y devolver el IdProducto generado.
                return productoDao.RegistrarProducto(producto);
            }

            return Guid.Empty; // Si no se genera un nuevo producto, devuelve Guid.Empty.
        }

        /// <summary>
        /// Método no implementado para registrar un producto.
        /// </summary>
        /// <param name="producto">Objeto Producto.</param>
        /// <returns>Entero (valor por defecto 0).</returns>
        public int Registrar(Producto producto) { return 0; }

        /// <summary>
        /// Edita la información de un producto existente.
        /// </summary>
        /// <param name="producto">Objeto Producto con los datos a editar.</param>
        /// <returns>Identificador GUID del producto editado; Guid.Empty si no se puede editar.</returns>
        public Guid EditarProducto(Producto producto)
        {
            IProductoDao productoDao = FactoryDao.CreateProductoDao();

            if (producto.IdProducto != Guid.Empty)
            {
                // Editar el producto y devolver el IdProducto.
                return productoDao.EditarProducto(producto);
            }
            return Guid.Empty; // Indica que no se puede editar (ID inválido)
        }

        /// <summary>
        /// Selecciona un producto utilizando su código.
        /// </summary>
        /// <param name="codigo">Código del producto.</param>
        /// <returns>Objeto Producto encontrado.</returns>
        public Producto SelectByCodigo(string codigo)
        {
            IProductoDao productoDao = FactoryDao.CreateProductoDao();
            Producto productoEncontrado = productoDao.SelectByCodigo(codigo);

            if (productoEncontrado == null)
            {
                throw new ProductoNoEncontradoException($"No se encontró un producto con el código '{codigo}'.");
            }

            return productoEncontrado;
        }

        /// <summary>
        /// Método no implementado para editar un producto.
        /// </summary>
        /// <param name="producto">Objeto Producto a editar.</param>
        /// <returns>Entero (valor por defecto 0).</returns>
        public int Editar(Producto producto)
        {
            return 0;
        }

        /// <summary>
        /// Método para suspender un producto (código comentado).
        /// </summary>
        /// <param name="producto">Objeto Producto a suspender.</param>
        public void Suspender(Producto producto)
        {
            //IProductoDao productoDao = FactoryDao.CreateProductoDao();

            //if (producto.Estado == Producto.EstadoProducto.Activo)
            //{
            //    // Registrar nuevo producto y devolver el IdProducto generado
            //    productoDao.Suspender(producto.Estado);
            //}
        }
    }
}
