using Dao.Helpers;
using DAO.Contracts;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DAO.Implementations.SqlServer.Mappers;

namespace DAO.Implementations.SqlServer
{
    /// <summary>
    /// Implementa la interfaz IInventarioDao para el manejo del inventario en la base de datos.
    /// </summary>
    public class InventarioDao : IInventarioDao
    {
        #region Singleton
        private readonly static InventarioDao _instance = new InventarioDao();

        /// <summary>
        /// Obtiene la instancia única (singleton) de InventarioDao.
        /// </summary>
        public static InventarioDao Current
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Constructor privado para evitar instanciación externa.
        /// </summary>
        private InventarioDao() { }
        #endregion

        /// <summary>
        /// Agrega un producto al inventario de una sucursal especificada.
        /// </summary>
        /// <param name="idSucursal">Identificador de la sucursal.</param>
        /// <param name="idProducto">Identificador del producto.</param>
        /// <param name="cantidad">Cantidad a agregar.</param>
        public void AgregarProductoInventario(Guid idSucursal, Guid idProducto, int cantidad)
        {
            try
            {
                SqlHelper.ExecuteNonQuery("sp_AgregarProductoInventario", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@idSucursal", idSucursal),
                        new SqlParameter("@idProducto", idProducto),
                        new SqlParameter("@cantidad", cantidad)
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar producto al inventario: " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Obtiene todos los registros del inventario.
        /// </summary>
        /// <returns>Lista de objetos Inventario.</returns>
        public List<Inventario> GetAll()
        {
            List<Inventario> inventarios = new List<Inventario>();

            using (var reader = SqlHelper.ExecuteReader("sp_InventarioSelectAll", CommandType.StoredProcedure, null))
            {
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    Inventario inventario = InventarioMapper.Current.Fill(data);
                    inventarios.Add(inventario);
                }
            }

            return inventarios;
        }

        /// <summary>
        /// Verifica si un producto existe en el inventario de una sucursal y obtiene la cantidad disponible.
        /// </summary>
        /// <param name="idSucursal">Identificador de la sucursal.</param>
        /// <param name="idProducto">Identificador del producto.</param>
        /// <returns>
        /// Una tupla donde el primer valor es 1 si existe (0 en caso contrario) y el segundo la cantidad disponible.
        /// </returns>
        public (int existe, int cantidad) VerificarProductoEnInventario(Guid idSucursal, Guid idProducto)
        {
            try
            {
                SqlParameter outputExiste = new SqlParameter("@existe", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };
                SqlParameter outputCantidad = new SqlParameter("@cantidad", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                SqlHelper.ExecuteNonQuery("sp_VerificarProductoEnInventario", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@idSucursal", idSucursal),
                        new SqlParameter("@idProducto", idProducto),
                        outputExiste,
                        outputCantidad
                    });

                bool existe = (bool)outputExiste.Value;
                int cantidad = (int)outputCantidad.Value;

                return (existe ? 1 : 0, cantidad); // Retorna una tupla (1 o 0, cantidad)
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al verificar producto en inventario: " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Calcula la disponibilidad de un producto en el inventario de una sucursal.
        /// </summary>
        /// <param name="idSucursal">Identificador de la sucursal.</param>
        /// <param name="idProducto">Identificador del producto.</param>
        /// <returns>La cantidad disponible; si no existe, retorna 0.</returns>
        public int CalcularDisponibilidad(Guid idSucursal, Guid idProducto)
        {
            try
            {
                SqlParameter outputDisponibilidad = new SqlParameter("@disponibilidad", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                SqlHelper.ExecuteNonQuery("sp_CalcularDisponibilidadInventario", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@idSucursal", idSucursal),
                        new SqlParameter("@idProducto", idProducto),
                        outputDisponibilidad
                    });

                // Validar si el valor es DBNull antes de convertir
                object valor = outputDisponibilidad.Value;
                if (valor == DBNull.Value)
                {
                    // Se puede decidir retornar 0 o lanzar una excepción
                    return 0;
                }
                return Convert.ToInt32(valor);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al calcular disponibilidad en inventario: " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Actualiza el inventario basado en un pedido para una sucursal.
        /// </summary>
        /// <param name="idPedido">Identificador del pedido.</param>
        /// <param name="idSucursal">Identificador de la sucursal.</param>
        void IInventarioDao.ActualizarInventarioPedido(Guid idPedido, Guid idSucursal)
        {
            try
            {
                SqlHelper.ExecuteNonQuery("sp_ActualizarInventarioPedido", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@idPedido", idPedido),
                        new SqlParameter("@idSucursal", idSucursal)
                    }
                );
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el inventario para el pedido: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Registra un objeto Inventario en la base de datos.
        /// </summary>
        /// <param name="obj">El objeto Inventario a registrar.</param>
        /// <returns>Entero indicando el resultado de la operación.</returns>
        public int Registrar(Inventario obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Edita un objeto Inventario existente.
        /// </summary>
        /// <param name="obj">El objeto Inventario con los nuevos datos.</param>
        /// <returns>Entero indicando el resultado de la operación.</returns>
        public int Editar(Inventario obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Suspende un objeto Inventario.
        /// </summary>
        /// <param name="obj">Identificador o valor que determina el inventario a suspender.</param>
        /// <returns>Entero indicando el resultado de la operación.</returns>
        public int Suspender(string obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene un objeto Inventario por su identificador numérico.
        /// </summary>
        /// <param name="id">Identificador numérico del inventario.</param>
        /// <returns>El objeto Inventario encontrado.</returns>
        public Inventario GetById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene un objeto Inventario por su identificador GUID.
        /// </summary>
        /// <param name="id">Identificador GUID del inventario.</param>
        /// <returns>El objeto Inventario encontrado.</returns>
        public Inventario GetByGuid(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
