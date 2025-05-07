using Dao.Contracts;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using static DOMAIN.Venta;

namespace DAO.Implementations.SqlServer.Mappers
{
    internal sealed class VentaMapper: IObjectMapper<Venta>
    {
        #region Singleton
        // Patron Singleton: asegura que solo exista una única instancia de la clase durante todo el ciclo de vida del programa.
        private readonly static VentaMapper _instance = new VentaMapper();
        public static VentaMapper Current
        {
            get
            {
                return _instance;
            }
        }
        private VentaMapper()
        {

        }
        #endregion

        public Venta Fill(object[] values)
        {
            try
            {
                var venta = new Venta
                {
                    IdVenta = Guid.Parse(values[(int)VentaColumns.idVenta].ToString()),
                    NroVenta = Convert.ToInt32(values[(int)VentaColumns.nroVenta].ToString()),
                    IdPedido = Guid.Parse(values[(int)VentaColumns.idPedido].ToString()),
                    ValorFlete = Convert.ToDecimal(values[(int)VentaColumns.valorFlete].ToString()),
                    Total = Convert.ToDecimal(values[(int)VentaColumns.total].ToString()),
                    Estado = (Venta.EstadoVenta)Convert.ToInt32(values[(int)VentaColumns.estado].ToString()),
                    FechaRegistro = DateTime.Parse(values[(int)VentaColumns.fechaRegistro].ToString()),
                };

                return venta;
            }
            catch (FormatException ex)
            {
                throw new Exception("Error de formato al llenar la venta: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al llenar la venta: " + ex.Message);
            }
        }

        internal enum VentaColumns
        {
            idVenta = 0,
            nroVenta = 1,  // Nueva columna, debe corresponder al orden del SELECT
            idPedido = 2,
            valorFlete = 3,
            total = 4,
            estado = 5,
            fechaRegistro = 6
        }
    }
}
