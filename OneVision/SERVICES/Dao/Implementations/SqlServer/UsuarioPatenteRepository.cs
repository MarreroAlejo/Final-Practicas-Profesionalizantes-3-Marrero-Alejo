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
    /// Implementa operaciones de unión entre usuarios y patentes.
    /// </summary>
    public sealed class UsuarioPatenteRepository : IJoinRepository<Usuario>
    {
        #region Singleton
        /// <summary>
        /// Instancia única (singleton) de UsuarioPatenteRepository.
        /// </summary>
        private readonly static UsuarioPatenteRepository _instance = new UsuarioPatenteRepository();

        /// <summary>
        /// Propiedad para obtener la instancia única de UsuarioPatenteRepository.
        /// </summary>
        public static UsuarioPatenteRepository Current
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Constructor privado para evitar instanciación externa.
        /// </summary>
        private UsuarioPatenteRepository()
        {
            //Implement here the initialization code
        }
        #endregion

        /// <summary>
        /// Registra la relación entre un usuario y una patente.
        /// </summary>
        /// <param name="idUsuario">Identificador GUID del usuario.</param>
        /// <param name="idPatente">Identificador GUID de la patente.</param>
        public void Registrar(Guid idUsuario, Guid idPatente)
        {
            var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@IdUsuario", idUsuario),
                    new SqlParameter("@IdPatente", idPatente)
                };

            try
            {
                // Ejecutar el procedimiento almacenado para insertar la relación
                SqlHelper.ExecuteNonQuery("Usuario_PatenteInsert", CommandType.StoredProcedure, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar la patente para el usuario: " + ex.Message);
            }
        }

        /// <summary>
        /// Elimina la relación entre un usuario y una patente.
        /// </summary>
        /// <param name="idUsuario">Identificador GUID del usuario.</param>
        /// <param name="idPatente">Identificador GUID de la patente.</param>
        public void Eliminar(Guid idUsuario, Guid idPatente)
        {
            var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@IdUsuario", idUsuario),
                    new SqlParameter("@IdPatente", idPatente)
                };

            try
            {
                // Ejecutar el procedimiento almacenado para eliminar la relación
                SqlHelper.ExecuteNonQuery("Usuario_PatenteDelete", CommandType.StoredProcedure, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar la patente para el usuario: " + ex.Message);
            }
        }

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
        /// Obtiene la lista de nombres de patentes asociadas a un usuario.
        /// </summary>
        /// <param name="idUsuario">Identificador GUID del usuario.</param>
        /// <returns>Lista de cadenas con los nombres de las patentes.</returns>
        public List<string> ObtenerPatentesUsuario(Guid idUsuario)
        {
            List<string> patentes = new List<string>();

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@IdUsuario", idUsuario)
            };

            using (var reader = SqlHelper.ExecuteReader("Usuario_PatenteSelectByIdUsuario", CommandType.StoredProcedure, parameters.ToArray()))
            {
                while (reader.Read()) // Leer todas las filas
                {
                    patentes.Add(reader["NombrePatente"].ToString());
                }
            }

            return patentes;
        }
    }
}
