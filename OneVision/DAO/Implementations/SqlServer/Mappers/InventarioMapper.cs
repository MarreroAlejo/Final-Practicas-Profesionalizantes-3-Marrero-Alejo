using Dao.Contracts;
using DAO.Contracts;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DOMAIN.Inventario;

namespace DAO.Implementations.SqlServer.Mappers
{
    internal sealed class InventarioMapper : IObjectMapper<Inventario>
    {
        #region singleton
        // Patron Singleton: asegura que solo exista una única instancia de la clase durante todo el ciclo de vida del programa.
        private readonly static InventarioMapper _instance = new InventarioMapper();
        public static InventarioMapper Current
        {
            get
            {
                return _instance;
            }
        }
        private InventarioMapper()
        {

        }
        #endregion
        public Inventario Fill(object[] values)
        {
            try
            {
                var inventario = new Inventario
                {
                    IdInventario = Guid.Parse(values[(int)InventarioColumns.idInventario].ToString()),
                    IdProducto = Guid.Parse(values[(int)InventarioColumns.idProducto].ToString()),
                    IdSucursal = Guid.Parse(values[(int)InventarioColumns.idSucursal].ToString()),
                    Cantidad = Convert.ToInt32(values[(int)InventarioColumns.cantidad].ToString()),
                    Reserva = Convert.ToInt32(values[(int)InventarioColumns.reserva].ToString()),
                    Estado = (EstadoInventario)Convert.ToInt32(values[(int)InventarioColumns.reserva].ToString()),

                };

                return inventario;
            }
            catch (FormatException ex)
            {
                throw new Exception("Error de formato al llenar el inventario: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al llenar el inventario: " + ex.Message);
            }
        }
        internal enum InventarioColumns
        {
            idInventario = 0,
            idProducto = 1,
            idSucursal = 2,
            cantidad = 3,
            reserva = 4,
            estado = 5
        }
    }
}
