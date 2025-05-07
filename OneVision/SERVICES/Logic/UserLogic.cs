using SERVICES.Dao.Contracts;
using SERVICES.Dao.Factory;
using SERVICES.Dao.Implementations.SqlServer;
using SERVICES.Domain.Composite;
using SERVICES.Domain.Exceptions.UserExceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Logic
{
    public class UserLogic
    {
        #region singleton
        private static UserLogic instance = new UserLogic();
        private static object instanceLock = new object();
        private PatenteLogic patenteLogic;
        private Usuario usuarioActual;
        private UserLogic()
        {
            // Inicializar patenteLogic en el constructor
            patenteLogic = PatenteLogic.Instance;
        }
        public static UserLogic GetInstance()
        {
            if (instance is null)
            {
                lock (instanceLock)
                {
                    if (instance is null)
                    {
                        instance = new UserLogic();
                    }
                }
            }
            return instance;
        }

        public static UserLogic Instance
        {
            get
            {
                if (instance is null)
                    instance = new UserLogic();

                return instance;
            }
        }

        #endregion



        #region Acciones Usuario

        public Usuario GetById(Guid idUsuario)
        {
            try
            {
                IUsuarioDao usuarioDao = FactoryDao.CreateUsuarioDao();
                return usuarioDao.GetById(idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el usuario: " + ex.Message);
            }
        }
        public List<Usuario> GetAll()
        {
            try
            {
                IUsuarioDao usuarioDao = FactoryDao.CreateUsuarioDao();
                return usuarioDao.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el usuario: " + ex.Message);
            }
        }


        public Usuario SelectByUsername(string username)
        {
            try
            {
                // FactoryDao decide cuál implementación y conexión usar.
                IUsuarioDao usuarioDao = FactoryDao.CreateUsuarioDao();
                return usuarioDao.SelectByUsername(username);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el usuario: " + ex.Message);
            }
        }

        public Guid RegistrarNuevoUsuario(Usuario usuario)
        {
            try
            {
                IUsuarioDao usuarioDao = FactoryDao.CreateUsuarioDao();
                return usuarioDao.Registrar(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el usuario: " + ex.Message);
            }
        }

        public Guid EditarUsuario(Usuario usuario)
        {
            try
            {
                IUsuarioDao usuarioDao = FactoryDao.CreateUsuarioDao();
                return usuarioDao.Editar(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el usuario: " + ex.Message);
            }
        }


        public Usuario ValidarCredenciales(string username, string password)
        {
            // Buscar el usuario por nombre de usuario
            Usuario usuario = SelectByUsername(username);

            // Si el usuario no existe o la contraseña no coincide, lanza la excepción
            if (usuario == null || usuario.Password != EncryptLogic.GetSHA256(password))
            {
                throw new CredencialesInvalidasException("Usuario o contraseña incorrectos.");
            }

            // Si llega aquí, las credenciales son válidas
            return usuario;
        }


        public List<string> ObtenerUsuarioPatentes(Guid idUsuario)
        {
            try
            {
                UsuarioPatenteRepository usuarioPatenteDao = (UsuarioPatenteRepository)FactoryDao.CreateUsuarioPatenteDao();
                return usuarioPatenteDao.ObtenerPatentesUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el usuario: " + ex.Message);
            }
        }

        public List<string> ObtenerUsuarioFamilia(Guid idUsuario)
        {
            try
            {
                UsuarioFamiliaRepository usuarioPatenteDao = (UsuarioFamiliaRepository)FactoryDao.CreateUsuarioFamiliaDao();
                return usuarioPatenteDao.ObtenerFamiliaUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el usuario: " + ex.Message);
            }
        }

        public void RegistrarUsuarioPatente(Guid idUsuario, Guid idPatente)
        {
            try
            {
                // Se asume que existe un DAO para Usuario-Patente similar al de Usuario-Familia.
                UsuarioPatenteRepository usuarioPatenteDao = (UsuarioPatenteRepository)FactoryDao.CreateUsuarioPatenteDao();
                usuarioPatenteDao.Registrar(idUsuario, idPatente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar la patente para el usuario: " + ex.Message, ex);
            }
        }

        public void EliminarUsuarioPatente(Guid idUsuario, Guid idPatente)
        {
            try
            {
                // Se asume que existe un método en el DAO para eliminar la relación Usuario-Patente.
                UsuarioPatenteRepository usuarioPatenteDao = (UsuarioPatenteRepository)FactoryDao.CreateUsuarioPatenteDao();
                usuarioPatenteDao.Eliminar(idUsuario, idPatente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la patente para el usuario: " + ex.Message, ex);
            }
        }


        public void RegistrarUsuarioFamilia(Guid usuario, Guid familia)
        {
            try
            {
                // Suponiendo que ya tienes una interfaz y DAO para manejar la relación Usuario–Familia.
                UsuarioFamiliaRepository usuarioFamiliaDao = (UsuarioFamiliaRepository)FactoryDao.CreateUsuarioFamiliaDao();
                usuarioFamiliaDao.Registrar(usuario, familia);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar la familia para el usuario: " + ex.Message, ex);
            }
        }

        public void EliminarUsuarioFamilia(Guid usuario, Guid familia)
        {
            try
            {
                // Suponiendo que ya tienes una interfaz y DAO para manejar la relación Usuario–Familia.
                UsuarioFamiliaRepository usuarioFamiliaDao = (UsuarioFamiliaRepository)FactoryDao.CreateUsuarioFamiliaDao();
                usuarioFamiliaDao.Eliminar(usuario, familia);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar la familia para el usuario: " + ex.Message, ex);
            }
        }


        #endregion

    }
}