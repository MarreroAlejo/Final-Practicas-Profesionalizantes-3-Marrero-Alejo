using DAO.Contracts;
using DAO.Factory;
using DAO.Implementations.SqlServer;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC
{
    /// <summary>
    /// Encapsula la lógica de negocio para la gestión de sucursales.
    /// </summary>
    public class SucursalLogic
    {
        #region Singleton
        private static SucursalLogic instance = new SucursalLogic();
        private static object instanceLock = new object();

        /// <summary>
        /// Constructor privado para la implementación del patrón singleton.
        /// </summary>
        private SucursalLogic() { }

        /// <summary>
        /// Obtiene la instancia única de SucursalLogic.
        /// </summary>
        /// <returns>Instancia de SucursalLogic.</returns>
        public static SucursalLogic GetInstance()
        {
            if (instance is null)
            {
                lock (instanceLock)
                {
                    if (instance is null)
                    {
                        instance = new SucursalLogic();
                    }
                }
            }
            return instance;
        }

        /// <summary>
        /// Propiedad para obtener la instancia única de SucursalLogic.
        /// </summary>
        public static SucursalLogic Instance
        {
            get
            {
                if (instance is null)
                    instance = new SucursalLogic();

                return instance;
            }
        }
        #endregion

        /// <summary>
        /// Obtiene todas las sucursales registradas.
        /// </summary>
        /// <returns>Lista de objetos Sucursal.</returns>
        public List<Sucursal> GetAll()
        {
            try
            {
                ISucursalDao sucursalDao = FactoryDao.CreateSucursalDao();
                return sucursalDao.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el vendedor: " + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene una sucursal utilizando su identificador GUID.
        /// </summary>
        /// <param name="id">Identificador GUID de la sucursal.</param>
        /// <returns>Objeto Sucursal correspondiente.</returns>
        public Sucursal GetByGuid(Guid id)
        {
            try
            {
                ISucursalDao sucursalDao = FactoryDao.CreateSucursalDao();
                return sucursalDao.GetByGuid(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el producto: " + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene una sucursal utilizando su nombre.
        /// </summary>
        /// <param name="nombre">Nombre de la sucursal.</param>
        /// <returns>Objeto Sucursal correspondiente.</returns>
        public Sucursal GetByNombre(string nombre)
        {
            try
            {
                ISucursalDao sucursalDao = FactoryDao.CreateSucursalDao();
                return sucursalDao.GetSucursalByNombre(nombre);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el producto: " + ex.Message);
            }
        }
    }
}
