using Dao.Helpers;
using DAO.Implementations.SqlServer.Mappers;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Contracts;

namespace DAO.Implementations.SqlServer
{
    /// <summary>
    /// Implementa la interfaz ISucursalDao para el manejo de sucursales en la base de datos.
    /// </summary>
    public sealed class SucursalDao : ISucursalDao
    {
        #region Singleton
        private readonly static SucursalDao _instance = new SucursalDao();

        /// <summary>
        /// Obtiene la instancia única (singleton) de SucursalDao.
        /// </summary>
        public static SucursalDao Current
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Constructor privado para evitar instanciación externa.
        /// </summary>
        private SucursalDao()
        {
            // Implement here the initialization of your singleton
        }
        #endregion

        /// <summary>
        /// Obtiene todas las sucursales registradas.
        /// </summary>
        /// <returns>Lista de objetos Sucursal.</returns>
        public List<Sucursal> GetAll()
        {
            List<Sucursal> sucursales = new List<Sucursal>();
            using (var reader = SqlHelper.ExecuteReader("sp_GetAllSucursal", CommandType.StoredProcedure,
                new SqlParameter[] { }))
            {
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    // Data Mapper...
                    Sucursal sucursal = SucursalMapper.Current.Fill(data);
                    sucursales.Add(sucursal);
                }
            }

            return sucursales;
        }

        /// <summary>
        /// Obtiene una sucursal por su identificador GUID.
        /// </summary>
        /// <param name="id">Identificador GUID de la sucursal.</param>
        /// <returns>El objeto Sucursal encontrado o default si no existe.</returns>
        public Sucursal GetByGuid(Guid id)
        {
            Sucursal sucursal = default;

            using (var reader = SqlHelper.ExecuteReader("sp_GetSucursalById", CommandType.StoredProcedure,
              new SqlParameter[] { new SqlParameter("@idSucursal", id) }))
            {
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    sucursal = SucursalMapper.Current.Fill(data);
                }
            }
            return sucursal;
        }

        /// <summary>
        /// Obtiene una sucursal por su nombre.
        /// </summary>
        /// <param name="nombre">Nombre de la sucursal a buscar.</param>
        /// <returns>El objeto Sucursal encontrado o default si no existe.</returns>
        public Sucursal GetSucursalByNombre(string nombre)
        {
            Sucursal sucursal = default;

            using (var reader = SqlHelper.ExecuteReader("sp_GetSucursalByNombre", CommandType.StoredProcedure,
              new SqlParameter[] { new SqlParameter("@nombre", nombre) }))
            {
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    sucursal = SucursalMapper.Current.Fill(data);
                }
            }
            return sucursal;
        }

        /// <summary>
        /// Registra una nueva sucursal en la base de datos. (No implementado)
        /// </summary>
        /// <param name="obj">El objeto Sucursal a registrar.</param>
        /// <returns>Entero indicando el resultado de la operación.</returns>
        public int Registrar(Sucursal obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Edita la información de una sucursal existente. (No implementado)
        /// </summary>
        /// <param name="obj">El objeto Sucursal con los nuevos datos.</param>
        /// <returns>Entero indicando el resultado de la operación.</returns>
        public int Editar(Sucursal obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Suspende una sucursal. (No implementado)
        /// </summary>
        /// <param name="obj">Identificador o valor que determina la sucursal a suspender.</param>
        /// <returns>Entero indicando el resultado de la operación.</returns>
        public int Suspender(string obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene una sucursal por su identificador numérico. (No implementado)
        /// </summary>
        /// <param name="id">Identificador numérico de la sucursal.</param>
        /// <returns>El objeto Sucursal encontrado.</returns>
        public Sucursal GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
