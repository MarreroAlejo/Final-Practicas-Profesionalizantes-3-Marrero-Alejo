using Dao.Contracts;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using static DOMAIN.Sucursal;

namespace DAO.Implementations.SqlServer.Mappers
{
    internal sealed class SucursalMapper : IObjectMapper<Sucursal>
    {
        #region singleton

        // Patron Singleton: asegura que solo exista una única instancia de la clase durante todo el ciclo de vida del programa.

        private readonly static SucursalMapper _instance = new SucursalMapper();

        public static SucursalMapper Current
        {
            get
            {
                return _instance;
            }
        }

        private SucursalMapper()
        {

        }
        #endregion
        public Sucursal Fill(object[] values)
        {
            try
            {
                var sucursal = new Sucursal
                {
                    IdSucursal = Guid.Parse(values[(int)SucursalColumns.idSucursal].ToString()),
                    Nombre = values[(int)SucursalColumns.nombre].ToString(),
                    Direccion = values[(int)SucursalColumns.direccion].ToString(),
                    Telefono = values[(int)SucursalColumns.telefono].ToString(),
                    Estado = (EstadoSucursal)Convert.ToInt32(values[(int)SucursalColumns.estado].ToString())
                };

                return sucursal;
            }
            catch (FormatException ex)
            {
                throw new Exception("Error de formato al llenar la sucursal: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al llenar la sucursal: " + ex.Message);
            }
        }
        internal enum SucursalColumns
        {
            idSucursal = 0,
            nombre = 1,
            direccion = 2,
            telefono = 3,
            estado = 4
        }
    }
}
