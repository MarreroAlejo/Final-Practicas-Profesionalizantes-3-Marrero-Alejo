using SERVICES.Dao.Helpers;
using SERVICES.Dao.Contracts;
using SERVICES.Dao.Implementations.SqlServer.Mappers;
using SERVICES.Domain.Composite;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Dao.Implementations.SqlServer
{
    /// <summary>
    /// Proporciona operaciones CRUD para la entidad Familia.
    /// </summary>
    public sealed class FamiliaRepository : IGenericDao<Familia>
    {
        #region Singleton
        /// <summary>
        /// Instancia única de FamiliaRepository.
        /// </summary>
        private readonly static FamiliaRepository _instance = new FamiliaRepository();

        /// <summary>
        /// Propiedad para obtener la instancia única.
        /// </summary>
        public static FamiliaRepository Current
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Constructor privado para evitar instanciación externa.
        /// </summary>
        private FamiliaRepository()
        {
            //Implement here the initialization code
        }
        #endregion

        /// <summary>
        /// Registra una nueva familia en la base de datos y sus relaciones.
        /// </summary>
        /// <param name="obj">Objeto Familia a registrar.</param>
        /// <returns>Identificador GUID de la familia registrada.</returns>
        public Guid Registrar(Familia obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery("FamiliaInsert", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@IdFamilia", obj.Id),
                        new SqlParameter("@Nombre", obj.Nombre)
                    });

                // Registrar las relaciones Familia-Patente o Familia-Familia
                FamiliaPatenteRepository.Current.Add(obj);
            }
            catch (Exception)
            {
                throw;
            }

            return obj.Id;
        }

        /// <summary>
        /// Edita la información de una familia y actualiza sus relaciones.
        /// </summary>
        /// <param name="obj">Objeto Familia con los datos a editar.</param>
        /// <returns>Identificador GUID de la familia editada.</returns>
        public Guid Editar(Familia obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery("FamiliaUpdate", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@IdFamilia", obj.Id),
                        new SqlParameter("@Nombre", obj.Nombre)
                    });

                // Actualizar relaciones: eliminar y luego agregar nuevamente
                FamiliaPatenteRepository.Current.Delete(obj);
                FamiliaPatenteRepository.Current.Add(obj);
            }
            catch (Exception)
            {
                throw;
            }

            return obj.Id;
        }

        /// <summary>
        /// Obtiene todas las familias registradas.
        /// </summary>
        /// <returns>Lista de objetos Familia.</returns>
        public List<Familia> GetAll()
        {
            List<Familia> familias = new List<Familia>();

            using (var reader = SqlHelper.ExecuteReader("sp_GetAllFamilia", CommandType.StoredProcedure))
            {
                while (reader.Read()) // Leer todas las filas
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    // Mapear cada fila a una instancia de Familia
                    Familia familia = FamiliaMapper.Current.Fill(data);
                    familias.Add(familia);
                }
            }

            return familias;
        }

        /// <summary>
        /// Obtiene todas las patentes individuales relacionadas a partir de una lista de accesos.
        /// </summary>
        /// <param name="accesos">Lista de accesos asociados a una familia.</param>
        /// <param name="patentesReturn">Lista donde se agregarán las patentes encontradas.</param>
        public void GetAllPatentes(List<Acceso> accesos, List<Patente> patentesReturn)
        {
            foreach (var acceso in accesos)
            {
                // Si es un leaf (hoja), significa que es una patente
                if (acceso.GetCountAccesos() == 0 && acceso is Patente patente)
                {
                    if (!patentesReturn.Any(p => p.Id == patente.Id))
                    {
                        patentesReturn.Add(patente); // Agregar la patente si no está ya
                    }
                }
                else if (acceso is Familia familia) // Si es una familia, buscar recursivamente
                {
                    GetAllPatentes(familia.Accesos, patentesReturn);
                }
            }
        }

        /// <summary>
        /// Obtiene una familia por su identificador GUID.
        /// </summary>
        /// <param name="id">Identificador GUID de la familia.</param>
        /// <returns>Objeto Familia encontrado.</returns>
        public Familia GetById(Guid id)
        {
            Familia familia = default;

            using (var reader = SqlHelper.ExecuteReader("FamiliaSelect", CommandType.StoredProcedure,
              new SqlParameter[] { new SqlParameter("@IdFamilia", id) }))
            {
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    familia = FamiliaMapper.Current.Fill(data);
                }
            }
            return familia;
        }

        /// <summary>
        /// Elimina una familia de la base de datos.
        /// </summary>
        /// <param name="idFamilia">Identificador GUID de la familia a eliminar.</param>
        public void Eliminar(Guid idFamilia)
        {
            try
            {
                SqlHelper.ExecuteNonQuery("sp_DeleteFamiliaCompleto", CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@IdFamilia", idFamilia) });
            }
            catch (SqlException sqlEx)
            {
                // Capturar errores de SQL
                throw new Exception("Error al ejecutar el procedimiento almacenado para eliminar la familia.", sqlEx);
            }
            catch (Exception ex)
            {
                // Capturar errores generales
                throw new Exception("Error al eliminar la familia en el repositorio.", ex);
            }
        }

        /// <summary>
        /// Método Eliminar no implementado para el contrato IGenericDao.
        /// </summary>
        /// <param name="obj">Valor entero (no utilizado).</param>
        /// <returns>No implementado.</returns>
        public Guid Eliminar(int obj)
        {
            throw new NotImplementedException();
        }
    }
}
