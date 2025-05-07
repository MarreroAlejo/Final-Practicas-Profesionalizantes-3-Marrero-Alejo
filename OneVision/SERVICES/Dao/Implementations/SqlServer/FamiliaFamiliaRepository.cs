using SERVICES.Dao.Contracts;
using SERVICES.Domain.Composite;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SERVICES.Dao.Helpers;

namespace SERVICES.Dao.Implementations.SqlServer
{
    /// <summary>
    /// Implementa operaciones de unión entre familias (relaciones de familia a familia).
    /// </summary>
    public sealed class FamiliaFamiliaRepository : IJoinRepository<Familia>
    {
        #region Singleton
        /// <summary>
        /// Instancia única de FamiliaFamiliaRepository.
        /// </summary>
        private readonly static FamiliaFamiliaRepository _instance = new FamiliaFamiliaRepository();

        /// <summary>
        /// Propiedad para obtener la instancia única.
        /// </summary>
        public static FamiliaFamiliaRepository Current
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Constructor privado para la implementación del singleton.
        /// </summary>
        private FamiliaFamiliaRepository()
        {
            //Implement here the initialization code
        }
        #endregion

        /// <summary>
        /// Agrega una relación entre una familia padre y una familia hija.
        /// </summary>
        /// <param name="familiaPadre">Familia padre.</param>
        /// <param name="familiaHija">Familia hija.</param>
        public void Add(Familia familiaPadre, Familia familiaHija)
        {
            // Llamar al procedimiento almacenado para agregar la relación
            SqlHelper.ExecuteNonQuery("sp_InsertFamilia_Familia", CommandType.StoredProcedure,
                new SqlParameter("@IdFamilia", familiaPadre.Id),
                new SqlParameter("@IdFamiliaHijo", familiaHija.Id));
        }

        /// <summary>
        /// Elimina la relación entre una familia padre y una familia hija.
        /// </summary>
        /// <param name="familiaPadre">Familia padre.</param>
        /// <param name="familiaHija">Familia hija.</param>
        public void Delete(Familia familiaPadre, Familia familiaHija)
        {
            // Llamar al procedimiento almacenado para eliminar la relación
            SqlHelper.ExecuteNonQuery("sp_DeleteFamilia_Familia", CommandType.StoredProcedure,
                new SqlParameter("@IdFamilia", familiaPadre.Id),
                new SqlParameter("@IdFamiliaHijo", familiaHija.Id));
        }

        /// <summary>
        /// Método Delete sin parámetros adicionales (no implementado).
        /// </summary>
        /// <param name="familia">Familia sobre la cual se aplicará la eliminación.</param>
        public void Delete(Familia familia)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene el conteo de relaciones para una familia y carga las familias hijas.
        /// </summary>
        /// <param name="obj">Familia de la cual se obtendrán los hijos.</param>
        public void GetCount(Familia obj)
        {
            // Obtener Familias relacionadas con la Familia
            using (var reader = SqlHelper.ExecuteReader("sp_Familia_FamiliaSelectByIdFamilia", CommandType.StoredProcedure,
            new SqlParameter[] { new SqlParameter("@IdFamilia", obj.Id) }))
            {
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    Guid idFamiliaHija = Guid.Parse(data[1].ToString());

                    // Verificar si el acceso ya existe antes de agregarlo
                    if (!obj.Accesos.Any(f => f.Id == idFamiliaHija))
                    {
                        obj.Add(FamiliaRepository.Current.GetById(idFamiliaHija));
                    }
                }
            }
        }

        /// <summary>
        /// Método Add sin parámetros adicionales (no implementado).
        /// </summary>
        /// <param name="obj">Familia a agregar.</param>
        public void Add(Familia obj)
        {
            throw new NotImplementedException();
        }
    }
}
