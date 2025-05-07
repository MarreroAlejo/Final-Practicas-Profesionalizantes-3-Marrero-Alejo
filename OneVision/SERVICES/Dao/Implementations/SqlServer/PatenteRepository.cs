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
    /// Proporciona operaciones CRUD para la entidad Patente.
    /// </summary>
    public sealed class PatenteRepository : IGenericDao<Patente>
    {
        #region Singleton
        /// <summary>
        /// Instancia única de PatenteRepository.
        /// </summary>
        private readonly static PatenteRepository _instance = new PatenteRepository();

        /// <summary>
        /// Propiedad para obtener la instancia única de PatenteRepository.
        /// </summary>
        public static PatenteRepository Current
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Constructor privado para evitar instanciación externa.
        /// </summary>
        private PatenteRepository()
        {
            // Implementar inicialización si es necesario
        }
        #endregion

        /// <summary>
        /// Obtiene una lista de patentes que coinciden con el nombre especificado.
        /// </summary>
        /// <param name="nombrePatente">Nombre de la patente a buscar.</param>
        /// <returns>Lista de objetos Patente encontrados.</returns>
        public List<Patente> GetByNombre(string nombrePatente)
        {
            List<Patente> patentes = new List<Patente>();

            using (var reader = SqlHelper.ExecuteReader("PatenteSelectByNombre", CommandType.StoredProcedure,
              new SqlParameter[] { new SqlParameter("@NombrePatente", nombrePatente) }))
            {
                while (reader.Read()) // Leer todas las filas que coincidan con el nombre
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    Patente patente = PatenteMapper.Current.Fill(data); // Mapear datos a un objeto Patente
                    patentes.Add(patente);
                }
            }

            return patentes;
        }

        /// <summary>
        /// Obtiene las patentes individuales asociadas a un usuario.
        /// </summary>
        /// <param name="idUsuario">Identificador GUID del usuario.</param>
        /// <returns>Lista de patentes individuales.</returns>
        public List<Patente> GetPatentesIndividualesByIdUsuario(Guid idUsuario)
        {
            List<Patente> patentesIndividuales = new List<Patente>();

            using (var reader = SqlHelper.ExecuteReader("PatenteSelectIndividualesByUsuario", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("@IdUsuario", idUsuario) }))
            {
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    Patente patente = PatenteMapper.Current.Fill(data);
                    patentesIndividuales.Add(patente);
                }
            }

            return patentesIndividuales;
        }

        /// <summary>
        /// Obtiene una patente por su identificador GUID.
        /// </summary>
        /// <param name="id">Identificador GUID de la patente.</param>
        /// <returns>Objeto Patente encontrado.</returns>
        public Patente GetById(Guid id)
        {
            Patente patente = default;

            using (var reader = SqlHelper.ExecuteReader("PatenteSelect", CommandType.StoredProcedure,
              new SqlParameter[] { new SqlParameter("@IdPatente", id) }))
            {
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    patente = PatenteMapper.Current.Fill(data);
                }
            }
            return patente;
        }

        /// <summary>
        /// Obtiene todas las patentes registradas.
        /// </summary>
        /// <returns>Lista de objetos Patente.</returns>
        public List<Patente> GetAll()
        {
            List<Patente> patentes = new List<Patente>();

            using (var reader = SqlHelper.ExecuteReader("PatenteSelectAll", CommandType.StoredProcedure, new SqlParameter[] { }))
            {
                while (reader.Read()) // Leer todas las filas
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    Patente patenteGet = PatenteMapper.Current.Fill(data); // Mapear la fila a un objeto Patente
                    patentes.Add(patenteGet);
                }
            }

            return patentes;
        }

        /// <summary>
        /// Método no implementado para registrar una patente.
        /// </summary>
        /// <param name="obj">Objeto Patente a registrar.</param>
        /// <returns>Identificador GUID de la patente registrada.</returns>
        public Guid Registrar(Patente obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método no implementado para editar una patente.
        /// </summary>
        /// <param name="obj">Objeto Patente con los datos a editar.</param>
        /// <returns>Identificador GUID de la patente editada.</returns>
        public Guid Editar(Patente obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método no implementado para eliminar una patente.
        /// </summary>
        /// <param name="obj">Valor entero que determina la patente a eliminar.</param>
        /// <returns>Identificador GUID de la patente eliminada.</returns>
        public Guid Eliminar(int obj)
        {
            throw new NotImplementedException();
        }
    }
}
