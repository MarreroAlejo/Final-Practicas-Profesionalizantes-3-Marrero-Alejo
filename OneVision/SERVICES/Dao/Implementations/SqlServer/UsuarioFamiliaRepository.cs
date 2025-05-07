using SERVICES.Dao.Contracts;
using SERVICES.Dao.Helpers;
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
    /// Implementa operaciones de unión entre usuarios y familias (relaciones de usuario a familia).
    /// </summary>
    public sealed class UsuarioFamiliaRepository : IJoinRepository<Usuario>
    {
        #region Singleton
        /// <summary>
        /// Instancia única (singleton) de UsuarioFamiliaRepository.
        /// </summary>
        private readonly static UsuarioFamiliaRepository _instance = new UsuarioFamiliaRepository();

        /// <summary>
        /// Propiedad para obtener la instancia única de UsuarioFamiliaRepository.
        /// </summary>
        public static UsuarioFamiliaRepository Current
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Constructor privado para evitar la instanciación externa.
        /// </summary>
        private UsuarioFamiliaRepository()
        {
            //Implement here the initialization code
        }
        #endregion

        /// <summary>
        /// No implementado: Agrega una entrada de usuario (método de IJoinRepository).
        /// </summary>
        /// <param name="obj">Objeto Usuario a agregar.</param>
        public void Add(Usuario obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// No implementado: Elimina una entrada de usuario (método de IJoinRepository).
        /// </summary>
        /// <param name="obj">Objeto Usuario a eliminar.</param>
        public void Delete(Usuario obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// No implementado: Obtiene el conteo de entradas (método de IJoinRepository).
        /// </summary>
        /// <param name="obj">Objeto Usuario para obtener el conteo.</param>
        public void GetCount(Usuario obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene la lista de nombres de familia asociados a un usuario.
        /// </summary>
        /// <param name="idUsuario">Identificador GUID del usuario.</param>
        /// <returns>Lista de cadenas con los nombres de las familias.</returns>
        public List<string> ObtenerFamiliaUsuario(Guid idUsuario)
        {
            List<string> patentes = new List<string>();

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@IdUsuario", idUsuario)
            };

            using (var reader = SqlHelper.ExecuteReader("Usuario_FamiliaSelectByIdUsuario", CommandType.StoredProcedure, parameters.ToArray()))
            {
                while (reader.Read()) // Leer todas las filas
                {
                    patentes.Add(reader["NombreFamilia"].ToString());
                }
            }

            return patentes;
        }

        /// <summary>
        /// Registra la relación entre un usuario y una familia.
        /// </summary>
        /// <param name="idUsuario">Identificador GUID del usuario.</param>
        /// <param name="idFamilia">Identificador GUID de la familia.</param>
        public void Registrar(Guid idUsuario, Guid idFamilia)
        {
            var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@IdUsuario", idUsuario),
                    new SqlParameter("@IdFamilia", idFamilia)
                };

            try
            {
                // Ejecutar el procedimiento almacenado para insertar la relación
                SqlHelper.ExecuteNonQuery("Usuario_FamiliaInsert", CommandType.StoredProcedure, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar la patente para el usuario: " + ex.Message);
            }
        }

        /// <summary>
        /// Elimina la relación entre un usuario y una familia.
        /// </summary>
        /// <param name="idUsuario">Identificador GUID del usuario.</param>
        /// <param name="idFamilia">Identificador GUID de la familia.</param>
        public void Eliminar(Guid idUsuario, Guid idFamilia)
        {
            var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@IdUsuario", idUsuario),
                    new SqlParameter("@IdFamilia", idFamilia)
                };

            try
            {
                // Ejecutar el procedimiento almacenado para eliminar la relación
                SqlHelper.ExecuteNonQuery("Usuario_FamiliaDelete", CommandType.StoredProcedure, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar la patente para el usuario: " + ex.Message);
            }
        }
    }
}
