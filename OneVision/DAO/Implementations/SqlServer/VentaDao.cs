using DAO.Contracts;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao.Helpers;
using DAO.Implementations.SqlServer.Mappers;

namespace DAO.Implementations.SqlServer
{
    /// <summary>
    /// Data Access Object (DAO) para la entidad Venta. Implementa la interfaz IVentaDao para el acceso a datos de ventas.
    /// </summary>
    public sealed class VentaDao : IVentaDao
    {
        #region Singleton
        /// <summary>
        /// Instancia única (singleton) de VentaDao.
        /// </summary>
        private readonly static VentaDao _instance = new VentaDao();

        /// <summary>
        /// Propiedad para obtener la instancia única de VentaDao.
        /// </summary>
        public static VentaDao Current
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Constructor privado para evitar instanciación externa.
        /// </summary>
        private VentaDao() { }
        #endregion

        /// <summary>
        /// Suspende una venta en la base de datos utilizando el procedimiento almacenado "sp_SuspenderVenta".
        /// </summary>
        /// <param name="idVenta">Identificador de la venta a suspender.</param>
        public void SuspenderVenta(Guid idVenta)
        {
            SqlHelper.ExecuteNonQuery("sp_SuspenderVenta", CommandType.StoredProcedure, new SqlParameter("@idVenta", idVenta));
        }

        /// <summary>
        /// Obtiene todas las ventas registradas en la base de datos.
        /// </summary>
        /// <returns>Lista de objetos Venta.</returns>
        public List<Venta> GetAll()
        {
            List<Venta> ventas = new List<Venta>();

            using (var reader = SqlHelper.ExecuteReader("sp_GetAllVentas", CommandType.StoredProcedure,
                new SqlParameter[] { }))
            {
                // Mientras se lean registros de la tabla de ventas.
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    // Data Mapper: Convierte los datos leídos en un objeto Venta.
                    Venta venta = VentaMapper.Current.Fill(data);
                    ventas.Add(venta);
                }
            }

            return ventas;
        }

        /// <summary>
        /// Obtiene una venta utilizando el número de venta.
        /// </summary>
        /// <param name="nroVenta">Número de venta a buscar.</param>
        /// <returns>Objeto Venta que coincide con el número especificado; de lo contrario, null.</returns>
        public Venta GetByNroVenta(int nroVenta)
        {
            Venta venta = null;
            using (var reader = SqlHelper.ExecuteReader("sp_GetVentaByNro", CommandType.StoredProcedure,
                  new SqlParameter[] { new SqlParameter("@nroVenta", nroVenta) }))
            {
                if (reader.Read())
                {
                    venta = VentaMapper.Current.Fill(new object[] {
                        reader["idVenta"],
                        reader["idPedido"],
                        reader["valorFlete"],
                        reader["total"],
                        reader["estado"],
                        reader["fechaRegistro"],
                        reader["nroVenta"]
                    });
                }
            }
            return venta;
        }

        /// <summary>
        /// Registra una nueva venta en la base de datos utilizando el procedimiento almacenado "sp_RegistrarVenta".
        /// </summary>
        /// <param name="venta">Objeto Venta a registrar.</param>
        /// <returns>El identificador GUID de la venta registrada.</returns>
        public Guid RegistrarVenta(Venta venta)
        {
            try
            {
                // Agregar parámetro de salida para obtener el número de venta (nroVenta)
                SqlParameter outputNroVentaParam = new SqlParameter("@nroVenta", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                SqlHelper.ExecuteNonQuery("sp_RegistrarVenta", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@idVenta", venta.IdVenta),
                        new SqlParameter("@idPedido", venta.IdPedido),
                        new SqlParameter("@valorFlete", venta.ValorFlete),
                        new SqlParameter("@total", venta.Total),
                        new SqlParameter("@estado", (int)venta.Estado),
                        new SqlParameter("@fechaRegistro", venta.FechaRegistro),
                        outputNroVentaParam
                    }
                );

                // Asigna el valor de nroVenta al objeto venta
                venta.NroVenta = (int)outputNroVentaParam.Value;

                return venta.IdVenta;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Verifica si existe una venta asociada a un pedido específico mediante el procedimiento almacenado "sp_VentaAsociadoAPedido".
        /// </summary>
        /// <param name="idPedido">Identificador del pedido.</param>
        /// <returns>Booleano indicando si existe una venta asociada al pedido.</returns>
        public bool VentaAsociadaAPedido(Guid idPedido)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MainConString"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand("sp_VentaAsociadoAPedido", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdPedido", idPedido);

                // Agregar el parámetro OUTPUT para determinar si existe una venta asociada.
                SqlParameter outParam = new SqlParameter("@VentaAsociada", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outParam);

                connection.Open();
                command.ExecuteNonQuery();

                // Convierte el valor obtenido a booleano y lo retorna.
                bool ventaAsociada = Convert.ToBoolean(outParam.Value);
                return ventaAsociada;
            }
        }

        /// <summary>
        /// Obtiene una venta utilizando su identificador GUID.
        /// </summary>
        /// <param name="id">Identificador GUID de la venta.</param>
        /// <returns>Objeto Venta que coincide con el GUID especificado; de lo contrario, default.</returns>
        public Venta GetByGuid(Guid id)
        {
            Venta venta = default;

            using (var reader = SqlHelper.ExecuteReader("sp_GetVentaByGuid", CommandType.StoredProcedure,
              new SqlParameter[] { new SqlParameter("@idVenta", id) }))
            {
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    venta = VentaMapper.Current.Fill(data);
                }
            }

            return venta;
        }

        /// <summary>
        /// Actualiza el stock en la venta, basado en el identificador del pedido y de la sucursal.
        /// </summary>
        /// <param name="idPedido">Identificador del pedido.</param>
        /// <param name="idSucursal">Identificador de la sucursal.</param>
        public void ActualizarStockVenta(Guid idPedido, Guid idSucursal)
        {
            try
            {
                SqlHelper.ExecuteNonQuery("sp_ActualizarStockVenta", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@idPedido", idPedido),
                        new SqlParameter("@idSucursal", idSucursal)
                    }
                );
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el stock en la venta: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Método no implementado para registrar una venta utilizando la interfaz genérica.
        /// </summary>
        /// <param name="obj">Objeto Venta a registrar.</param>
        /// <returns>Entero que indica el resultado de la operación.</returns>
        public int Registrar(Venta obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método no implementado para editar una venta.
        /// </summary>
        /// <param name="obj">Objeto Venta con la información a editar.</param>
        /// <returns>Entero que indica el resultado de la operación.</returns>
        public int Editar(Venta obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método no implementado para suspender una venta mediante un parámetro string.
        /// </summary>
        /// <param name="obj">Valor que determina la venta a suspender.</param>
        /// <returns>Entero que indica el resultado de la operación.</returns>
        public int Suspender(string obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método no implementado para obtener una venta por su identificador numérico.
        /// </summary>
        /// <param name="id">Identificador numérico de la venta.</param>
        /// <returns>Objeto Venta encontrado.</returns>
        public Venta GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
