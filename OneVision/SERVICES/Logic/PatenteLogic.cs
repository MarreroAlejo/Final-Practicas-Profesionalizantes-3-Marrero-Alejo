using SERVICES.Dao.Contracts;
using SERVICES.Dao.Factory;
using SERVICES.Dao.Helpers;
using SERVICES.Dao.Implementations.SqlServer;
using SERVICES.Domain.Composite;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Logic
{
    /// <summary>
    /// Lógica de negocio para la gestión de Patentes.
    /// </summary>
    public class PatenteLogic
    {
        #region singleton
        private static PatenteLogic instance = new PatenteLogic();
        private static object instanceLock = new object();

        private PatenteLogic() { }

        public static PatenteLogic GetInstance()
        {
            if (instance is null)
            {
                lock (instanceLock)
                {
                    if (instance is null)
                    {
                        instance = new PatenteLogic();
                    }
                }
            }
            return instance;
        }

        public static PatenteLogic Instance
        {
            get
            {
                if (instance is null)
                    instance = new PatenteLogic();

                return instance;
            }
        }

        #endregion

        #region Acciones Patentes


        /// <summary>
        /// Obtiene todas las patentes del sistema.
        /// </summary>
        public List<Patente> GetAllPatentes()
        {
            try
            {
                IGenericDao<Patente> patenteDao = FactoryDao.CreatePatenteDao();
                return patenteDao.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el usuario: " + ex.Message);
            }
        }


        /// <summary>
        /// Asocia una patente a un usuario.
        /// </summary>
        public void Add(Guid idUsuario, Guid idPatente)
        {
            try
            {
                UsuarioPatenteRepository usuarioPatenteDao = (UsuarioPatenteRepository)FactoryDao.CreateUsuarioPatenteDao();
                usuarioPatenteDao.Registrar(idUsuario, idPatente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la patente al usuario: " + ex.Message);
            }
        }


        /// <summary>
        /// Elimina la asociación entre un usuario y una patente.
        /// </summary>
        public void Delete(Guid idUsuario, Guid idPatente)
        {
            try
            {
                UsuarioPatenteRepository usuarioPatenteDao = (UsuarioPatenteRepository)FactoryDao.CreateUsuarioPatenteDao();
                usuarioPatenteDao.Eliminar(idUsuario, idPatente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la patente al usuario: " + ex.Message);
            }
        }


        /// <summary>
        /// Obtiene una patente por su nombre.
        /// </summary>
        public Patente GetPatenteByNombre(string nombrePatente)
        {
            var patentes = PatenteRepository.Current.GetByNombre(nombrePatente);
            return patentes.FirstOrDefault(); // Devuelve la primera patente encontrada o null si no hay
        }



        #endregion

    }
}
