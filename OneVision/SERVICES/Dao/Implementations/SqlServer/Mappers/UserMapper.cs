using SERVICES.Dao.Contracts;
using SERVICES.Domain.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SERVICES.Domain.Composite.Usuario;

namespace SERVICES.Dao.Implementations.SqlServer.Mappers
{
    public sealed class UserMapper : IObjectMapper<Usuario>
    {

        #region singleton

        // Patron Singleton: asegura que solo exista una única instancia de la clase durante todo el ciclo de vida del programa.

        private readonly static UserMapper _instance = new UserMapper();

        public static UserMapper Current
        {
            get
            {
                return _instance;
            }
        }

        private UserMapper()
        {

        }
        #endregion
        public Usuario Fill(object[] values)
        {
            //Nivel de hidratación 1 : Primitivos
            Usuario usuario = new Usuario();
            usuario.IdUsuario = Guid.Parse(values[0].ToString());
            usuario.UserName = values[1].ToString();
            usuario.Password = values[2].ToString();
            usuario.Estado = (EstadoUsuario)Enum.Parse(typeof(EstadoUsuario), values[3].ToString()); // Asumiendo que Estado está en la posición 3

            ////Nivel de hidratación 2 : Agregaciones
            //UsuarioFamiliaRepository.Current.GetCount(usuario);
            //UsuarioPatenteRepository.Current.GetCount(usuario);
            return usuario;
        }
    }
}
