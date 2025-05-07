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
    /// Implementa operaciones CRUD para la entidad Usuario.
    /// </summary>
    public sealed class UsuarioRepository : IUsuarioDao
    {
        #region Singleton
        /// <summary>
        /// Instancia única (singleton) de UsuarioRepository.
        /// </summary>
        private readonly static UsuarioRepository _instance = new UsuarioRepository();

        /// <summary>
        /// Propiedad para obtener la instancia única de UsuarioRepository.
        /// </summary>
        public static UsuarioRepository Current
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Constructor privado para evitar la instanciación externa.
        /// </summary>
        private UsuarioRepository()
        {
            // Inicialización del singleton (si es necesario)
        }
        #endregion

        /// <summary>
        /// Obtiene un usuario por su identificador GUID.
        /// </summary>
        /// <param name="id">Identificador GUID del usuario.</param>
        /// <returns>Objeto Usuario encontrado; default si no existe.</returns>
        public Usuario GetById(Guid id)
        {
            Usuario usuario = default;

            using (var reader = SqlHelper.ExecuteReader("UsuarioSelect", CommandType.StoredProcedure,
              new SqlParameter[] { new SqlParameter("@IdUsuario", id) }))
            {
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    usuario = UserMapper.Current.Fill(data);
                }
            }

            return usuario;
        }

        /// <summary>
        /// Obtiene todos los usuarios registrados.
        /// </summary>
        /// <returns>Lista de objetos Usuario.</returns>
        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();

            // Llama al procedimiento almacenado sin parámetros
            using (var reader = SqlHelper.ExecuteReader("UsuarioGetAll", CommandType.StoredProcedure))
            {
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    Usuario usuario = UserMapper.Current.Fill(data);
                    usuarios.Add(usuario);
                }
            }

            return usuarios;
        }

        /// <summary>
        /// Selecciona un usuario basado en su nombre de usuario.
        /// </summary>
        /// <param name="username">Nombre de usuario a buscar.</param>
        /// <returns>Objeto Usuario que coincide con el nombre; default si no existe.</returns>
        public Usuario SelectByUsername(string username)
        {
            Usuario usuario = default;

            using (var reader = SqlHelper.ExecuteReader("UsuarioSelectByUsername", CommandType.StoredProcedure,
                new SqlParameter[] { new SqlParameter("@UserName", username) })) // No aplicar hash aquí
            {
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    usuario = UserMapper.Current.Fill(data);
                }
            }

            return usuario;
        }

        /// <summary>
        /// Registra un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="obj">Objeto Usuario a registrar.</param>
        /// <returns>Identificador GUID del usuario registrado.</returns>
        public Guid Registrar(Usuario obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery("UsuarioInsert", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@IdUsuario", obj.IdUsuario),
                        new SqlParameter("@UserName", obj.UserName),
                        new SqlParameter("@Password", obj.Password),
                        new SqlParameter("@Estado", (int)obj.Estado) // Agregar Estado
                    }
                );
            }
            catch (Exception)
            {
                throw;
            }

            return obj.IdUsuario;
        }

        /// <summary>
        /// Edita la información de un usuario existente.
        /// </summary>
        /// <param name="obj">Objeto Usuario con los datos a editar.</param>
        /// <returns>Identificador GUID del usuario editado.</returns>
        public Guid Editar(Usuario obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery("UsuarioUpdate", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@IdUsuario", obj.IdUsuario),
                        new SqlParameter("@UserName", obj.UserName),
                        new SqlParameter("@Password", obj.Password),
                        new SqlParameter("@Estado", (int)obj.Estado) // Agregar Estado
                    }
                );
            }
            catch (Exception)
            {
                throw;
            }

            return obj.IdUsuario;
        }

        /// <summary>
        /// Método Eliminar no implementado para el contrato IUsuarioDao.
        /// </summary>
        /// <param name="obj">Valor entero (no utilizado).</param>
        /// <returns>No implementado.</returns>
        public Guid Eliminar(int obj)
        {
            throw new NotImplementedException();
        }
    }
}
