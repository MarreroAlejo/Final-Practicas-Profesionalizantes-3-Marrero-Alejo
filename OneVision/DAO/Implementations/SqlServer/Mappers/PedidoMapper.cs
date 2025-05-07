using Dao.Contracts;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DOMAIN.Pedido;

namespace DAO.Implementations.SqlServer.Mappers
{
    internal sealed class PedidoMapper
    {
        #region singleton
        // Patron Singleton: asegura que solo exista una única instancia de la clase durante todo el ciclo de vida del programa.
        private readonly static PedidoMapper _instance = new PedidoMapper();
        public static PedidoMapper Current
        {
            get
            {
                return _instance;
            }
        }
        private PedidoMapper()
        {

        }
        #endregion
        public Pedido FillFromReader(SqlDataReader reader)
        {
            try
            {
                var pedido = new Pedido
                {
                    IdPedido = reader.GetGuid(reader.GetOrdinal("idPedido")),
                    NroPedido = reader.GetInt32(reader.GetOrdinal("nroPedido")),
                    IdEmpleado = reader.GetGuid(reader.GetOrdinal("idEmpleado")),
                    IdCliente = reader.GetInt32(reader.GetOrdinal("idCliente")),
                    IdSucursal = reader.GetGuid(reader.GetOrdinal("idSucursal")),
                    Total = reader.GetDecimal(reader.GetOrdinal("total")),
                    Estado = (Pedido.EstadoPedido)reader.GetInt32(reader.GetOrdinal("estado")),
                    FechaRegistro = reader.GetDateTime(reader.GetOrdinal("fechaRegistro"))
                };

                return pedido;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mapear el Pedido: " + ex.Message);
            }
        }

        internal enum PedidoColumns
        {
            idPedido = 0,
            nroPedido = 1,    // Nueva columna
            idEmpleado = 2,
            idCliente = 3,
            idSucursal = 4,
            total = 5,
            estado = 6,
            fechaRegistro = 7
        }
    }
}
