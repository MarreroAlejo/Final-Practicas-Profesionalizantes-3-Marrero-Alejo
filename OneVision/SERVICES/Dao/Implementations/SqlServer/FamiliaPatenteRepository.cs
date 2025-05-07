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
    /// Implementa operaciones de unión entre familias y patentes.
    /// </summary>
    public sealed class FamiliaPatenteRepository : IJoinRepository<Familia>
    {
        #region Singleton
        /// <summary>
        /// Instancia única de FamiliaPatenteRepository.
        /// </summary>
        private readonly static FamiliaPatenteRepository _instance = new FamiliaPatenteRepository();

        /// <summary>
        /// Propiedad para obtener la instancia única.
        /// </summary>
        public static FamiliaPatenteRepository Current
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Constructor privado para la implementación del singleton.
        /// </summary>
        private FamiliaPatenteRepository()
        {
            //Implement here the initialization code
        }
        #endregion

        /// <summary>
        /// Agrega las relaciones de la familia con sus accesos (ya sean patentes o familias).
        /// </summary>
        /// <param name="obj">Familia cuya relación se desea agregar.</param>
        public void Add(Familia obj)
        {
            foreach (var acceso in obj.Accesos)
            {
                if (acceso is Patente patente)
                {
                    // Insertar relación entre Familia y Patente
                    SqlHelper.ExecuteNonQuery("Familia_PatenteInsert", CommandType.StoredProcedure,
                        new SqlParameter[]
                        {
                            new SqlParameter("@IdFamilia", obj.Id),
                            new SqlParameter("@IdPatente", patente.Id)
                        });
                }
                else if (acceso is Familia familia)
                {
                    // Insertar relación entre Familia y Familia
                    SqlHelper.ExecuteNonQuery("sp_InsertFamilia_Familia", CommandType.StoredProcedure,
                        new SqlParameter[]
                        {
                            new SqlParameter("@IdFamilia", obj.Id),
                            new SqlParameter("@IdFamiliaHijo", familia.Id)
                        });
                }
            }
        }

        /// <summary>
        /// Elimina las relaciones de la familia con sus accesos.
        /// </summary>
        /// <param name="obj">Familia de la cual se eliminarán las relaciones.</param>
        public void Delete(Familia obj)
        {
            foreach (var acceso in obj.Accesos)
            {
                if (acceso is Patente)
                {
                    // Eliminar relación Familia-Patente
                    SqlHelper.ExecuteNonQuery("Familia_PatenteDelete", CommandType.StoredProcedure,
                        new SqlParameter[]
                        {
                            new SqlParameter("@IdFamilia", obj.Id),
                            new SqlParameter("@IdPatente", acceso.Id)
                        });
                }
                else if (acceso is Familia)
                {
                    // Eliminar relación Familia-Familia
                    SqlHelper.ExecuteNonQuery("Familia_FamiliaDelete", CommandType.StoredProcedure,
                        new SqlParameter[]
                        {
                            new SqlParameter("@IdFamilia", obj.Id),
                            new SqlParameter("@IdFamiliaHijo", acceso.Id)
                        });
                }
            }
        }

        /// <summary>
        /// Obtiene el conteo de relaciones (y carga los accesos) para una familia.
        /// </summary>
        /// <param name="obj">Familia de la cual se desean obtener las relaciones.</param>
        public void GetCount(Familia obj)
        {
            using (var reader = SqlHelper.ExecuteReader("sp_SelectByIdFamiliaFamilia_Patente", CommandType.StoredProcedure,
            new SqlParameter[] { new SqlParameter("@IdFamilia", obj.Id) }))
            {
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    Guid idPatente = Guid.Parse(data[1].ToString());

                    // Verificar si el acceso ya existe antes de agregarlo
                    if (!obj.Accesos.Any(p => p.Id == idPatente))
                    {
                        obj.Add(PatenteRepository.Current.GetById(idPatente));
                    }
                }
            }
        }

        /// <summary>
        /// Agrega una relación específica entre una familia padre y una patente hija.
        /// </summary>
        /// <param name="familiaPadre">Familia padre.</param>
        /// <param name="patenteHija">Patente hija.</param>
        public void Add(Familia familiaPadre, Patente patenteHija)
        {
            // Llamar al procedimiento almacenado para agregar la relación
            SqlHelper.ExecuteNonQuery("sp_InsertFamilia_Patente", CommandType.StoredProcedure,
                new SqlParameter("@IdFamilia", familiaPadre.Id),
                new SqlParameter("@IdPatente", patenteHija.Id));
        }

        /// <summary>
        /// Elimina la relación específica entre una familia padre y una patente hija.
        /// </summary>
        /// <param name="familiaPadre">Familia padre.</param>
        /// <param name="patenteHija">Patente hija.</param>
        public void Delete(Familia familiaPadre, Patente patenteHija)
        {
            // Llamar al procedimiento almacenado para eliminar la relación
            SqlHelper.ExecuteNonQuery("Familia_PatenteDelete", CommandType.StoredProcedure,
                new SqlParameter("@IdFamilia", familiaPadre.Id),
                new SqlParameter("@IdPatente", patenteHija.Id));
        }
    }
}
