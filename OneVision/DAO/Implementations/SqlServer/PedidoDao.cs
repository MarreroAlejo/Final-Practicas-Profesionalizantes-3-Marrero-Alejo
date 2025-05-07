using Dao.Helpers;
using DAO.Contracts;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DAO.Implementations.SqlServer.Mappers;

namespace DAO.Implementations.SqlServer
{
    /// <summary>
    /// Implementa la interfaz IPedidoDao para el manejo de pedidos en la base de datos.
    /// </summary>
    public sealed class PedidoDao : IPedidoDao
    {
        #region Singleton
        private readonly static PedidoDao _instance = new PedidoDao();

        /// <summary>
        /// Obtiene la instancia única (singleton) de PedidoDao.
        /// </summary>
        public static PedidoDao Current
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Constructor privado para evitar instanciación externa.
        /// </summary>
        private PedidoDao() { }
        #endregion

        /// <summary>
        /// Suspende un pedido basado en su identificador GUID.
        /// </summary>
        /// <param name="idPedido">Identificador GUID del pedido a suspender.</param>
        public void SuspenderPedido(Guid idPedido)
        {
            try
            {
                SqlHelper.ExecuteNonQuery("sp_SuspenderPedido", CommandType.StoredProcedure,
                    new SqlParameter("@IdPedido", idPedido));
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al suspender el pedido en la base de datos.", ex);
            }
        }

        /// <summary>
        /// Obtiene todos los pedidos registrados.
        /// </summary>
        /// <returns>Lista de objetos Pedido.</returns>
        public List<Pedido> GetAll()
        {
            List<Pedido> pedidos = new List<Pedido>();

            using (var reader = SqlHelper.ExecuteReader("sp_GetAllPedidos", CommandType.StoredProcedure))
            {
                while (reader.Read())
                {
                    Pedido pedido = PedidoMapper.Current.FillFromReader(reader);
                    pedidos.Add(pedido);
                }
            }
            return pedidos;
        }

        /// <summary>
        /// Registra un nuevo pedido en la base de datos, incluyendo los detalles del pedido.
        /// </summary>
        /// <param name="pedido">El objeto Pedido a registrar.</param>
        /// <returns>El identificador GUID generado para el pedido.</returns>
        public Guid RegistrarPedido(Pedido pedido)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MainConString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_RegistrarPedido", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Parámetros de entrada
                        cmd.Parameters.AddWithValue("@IdEmpleado", pedido.IdEmpleado);
                        cmd.Parameters.AddWithValue("@IdCliente", pedido.IdCliente);
                        cmd.Parameters.AddWithValue("@IdSucursal", pedido.IdSucursal);
                        cmd.Parameters.AddWithValue("@Total", pedido.Total);
                        cmd.Parameters.AddWithValue("@Estado", (int)pedido.Estado);
                        cmd.Parameters.AddWithValue("@FechaRegistro", pedido.FechaRegistro);

                        // Parámetro de salida para el ID del pedido
                        SqlParameter outputIdParam = new SqlParameter("@IdPedido", SqlDbType.UniqueIdentifier)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outputIdParam);

                        // Parámetro de salida para el nroPedido (columna identity)
                        SqlParameter outputNroPedidoParam = new SqlParameter("@NroPedido", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outputNroPedidoParam);

                        // Crear el parámetro de tipo tabla para los detalles del pedido
                        DataTable detallesTable = new DataTable();
                        detallesTable.Columns.Add("idDetallePedido", typeof(Guid));
                        detallesTable.Columns.Add("idProducto", typeof(Guid));
                        detallesTable.Columns.Add("cantidad", typeof(int));
                        detallesTable.Columns.Add("subtotal", typeof(decimal));

                        foreach (var detalle in pedido.obj_DetallePedido)
                        {
                            detallesTable.Rows.Add(detalle.IdDetallePedido, detalle.IdProducto, detalle.Cantidad, detalle.SubTotal);
                        }

                        SqlParameter detallesParam = new SqlParameter("@DetallePedidoDetalle", SqlDbType.Structured)
                        {
                            TypeName = "dbo.DetallePedidoType",
                            Value = detallesTable
                        };
                        cmd.Parameters.Add(detallesParam);

                        cmd.ExecuteNonQuery();

                        // Asignar el valor generado a las propiedades del objeto
                        pedido.IdPedido = (Guid)outputIdParam.Value;
                        pedido.NroPedido = (int)outputNroPedidoParam.Value;

                        // Retornar el IdPedido si fuera necesario (o podrías retornar el objeto completo)
                        return pedido.IdPedido;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al registrar el pedido: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Obtiene la lista de detalles de un pedido dado su identificador GUID.
        /// </summary>
        /// <param name="idPedido">Identificador GUID del pedido.</param>
        /// <returns>Lista de objetos DetallePedido asociados al pedido.</returns>
        public List<DetallePedido> ObtenerDetallePedido(Guid idPedido)
        {
            var detalles = new List<DetallePedido>();
            string connectionString = ConfigurationManager.ConnectionStrings["MainConString"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand("sp_ObtenerDetallePedido", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdPedido", idPedido);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        detalles.Add(new DetallePedido
                        {
                            IdDetallePedido = reader.GetGuid(reader.GetOrdinal("idDetallePedido")),
                            IdProducto = reader.GetGuid(reader.GetOrdinal("idProducto")),
                            Cantidad = reader.GetInt32(reader.GetOrdinal("cantidad")),
                            SubTotal = reader.GetDecimal(reader.GetOrdinal("subtotal")) // SubTotal es el nombre correcto
                        });
                    }
                }
            }

            return detalles;
        }

        /// <summary>
        /// Actualiza el estado de un pedido dado su número de pedido.
        /// </summary>
        /// <param name="NroPedido">Número del pedido.</param>
        /// <param name="nuevoEstado">Nuevo estado a asignar al pedido.</param>
        public void ActualizarEstadoPedido(int NroPedido, Pedido.EstadoPedido nuevoEstado)
        {
            try
            {
                // Obtener la cadena de conexión desde el archivo app.config
                string connectionString = ConfigurationManager.ConnectionStrings["MainConString"].ConnectionString;

                // Crear la conexión con la base de datos
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Preparar el comando que ejecutará el procedimiento almacenado
                    using (var command = new SqlCommand("sp_ActualizarEstadoPedido", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        // Agregar los parámetros al procedimiento almacenado
                        command.Parameters.AddWithValue("@NroPedido", NroPedido);
                        command.Parameters.AddWithValue("@NuevoEstado", (int)nuevoEstado);
                        // Ejecutar el procedimiento almacenado
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new ApplicationException("Error al actualizar el estado del pedido.", ex);
            }
        }

        /// <summary>
        /// Edita la información de un pedido existente.
        /// </summary>
        /// <param name="obj">El objeto Pedido con la información a editar.</param>
        /// <returns>Entero indicando el resultado de la operación.</returns>
        public int Editar(Pedido obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene un pedido por su identificador GUID.
        /// </summary>
        /// <param name="id">Identificador GUID del pedido.</param>
        /// <returns>El objeto Pedido encontrado o null si no existe.</returns>
        public Pedido GetByGuid(Guid id)
        {
            Pedido pedido = null;
            using (var reader = SqlHelper.ExecuteReader("sp_GetPedidoByGuid", CommandType.StoredProcedure,
                  new SqlParameter[] { new SqlParameter("@idPedido", id) }))
            {
                if (reader.Read())
                {
                    pedido = PedidoMapper.Current.FillFromReader(reader);
                }
            }
            return pedido;
        }

        /// <summary>
        /// Obtiene un pedido por su número de pedido.
        /// </summary>
        /// <param name="nroPedido">Número del pedido a buscar.</param>
        /// <returns>El objeto Pedido encontrado o null si no existe.</returns>
        public Pedido GetPedidoByNro(int nroPedido)
        {
            Pedido pedido = null;
            using (var reader = SqlHelper.ExecuteReader("sp_GetPedidoByNro", CommandType.StoredProcedure,
                  new SqlParameter[] { new SqlParameter("@nroPedido", nroPedido) }))
            {
                if (reader.Read())
                {
                    pedido = PedidoMapper.Current.FillFromReader(reader);
                }
            }
            return pedido;
        }

        /// <summary>
        /// Obtiene un pedido por su identificador numérico.
        /// </summary>
        /// <param name="id">Identificador numérico del pedido.</param>
        /// <returns>El objeto Pedido encontrado.</returns>
        public Pedido GetById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Registra un pedido en la base de datos.
        /// </summary>
        /// <param name="obj">El objeto Pedido a registrar.</param>
        /// <returns>Entero indicando el resultado de la operación.</returns>
        public int Registrar(Pedido obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Suspende un pedido basado en un parámetro string.
        /// </summary>
        /// <param name="obj">Identificador o valor para suspender el pedido.</param>
        /// <returns>Entero indicando el resultado de la operación.</returns>
        public int Suspender(string obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Suspende un pedido basado en su número de pedido.
        /// </summary>
        /// <param name="nroPedido">Número del pedido a suspender.</param>
        public void SuspenderPedido(int nroPedido)
        {
            try
            {
                SqlHelper.ExecuteNonQuery("sp_SuspenderPedido", CommandType.StoredProcedure,
                    new SqlParameter("@nroPedido", nroPedido));
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al suspender el pedido en la base de datos.", ex);
            }
        }
    }
}
