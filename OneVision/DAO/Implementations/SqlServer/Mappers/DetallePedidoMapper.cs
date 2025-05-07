using Dao.Contracts;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Implementations.SqlServer.Mappers
{
    internal sealed class DetallePedidoMapper: IObjectMapper<DetallePedido>
    {
        #region singleton
        private readonly static DetallePedidoMapper _instance = new DetallePedidoMapper();

        public static DetallePedidoMapper Current
        {
            get
            {
                return _instance;
            }
        }

        private DetallePedidoMapper()
        {

        }
        #endregion
        public DetallePedido Fill(object[] values)
        {
            try
            {
                var detallePedido = new DetallePedido
                {
                    IdDetallePedido = Guid.Parse(values[(int)DetallePedidoColumns.idDetallePedido].ToString()),
                    IdProducto = Guid.Parse(values[(int)DetallePedidoColumns.idProducto].ToString()),
                    Cantidad = Convert.ToInt32(values[(int)DetallePedidoColumns.cantidad].ToString()),
                    SubTotal = decimal.Parse(values[(int)DetallePedidoColumns.cantidad].ToString())
                };

                return detallePedido;
            }
            catch (FormatException ex)
            {
                throw new Exception("Error de formato al llenar el detallePedido: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al llenar el detallePedido: " + ex.Message);
            }
        }
        internal enum DetallePedidoColumns
        {
            idDetallePedido = 0,
            idProducto = 1,
            cantidad = 2,
            subtotal = 3,
        }
    }
}
