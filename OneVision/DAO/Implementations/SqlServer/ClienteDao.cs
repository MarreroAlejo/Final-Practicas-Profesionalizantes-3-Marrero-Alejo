using Dao.Helpers;
using DAO.Contracts;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Implementations.SqlServer.Mappers;

namespace DAO.Implementations.SqlServer
{
    /// <summary>
    /// Implementa la interfaz IClienteDao para el manejo de clientes en una base de datos SqlServer.
    /// </summary>
    public sealed class ClienteDao : IClienteDao
    {
        #region singleton
        private readonly static ClienteDao _instance = new ClienteDao();

        /// <summary>
        /// Obtiene la instancia actual (singleton) de ClienteDao.
        /// </summary>
        public static ClienteDao Current
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Constructor privado para la implementación del singleton.
        /// </summary>
        private ClienteDao()
        {
            // Implement here the initialization of your singleton
        }
        #endregion

        /// <summary>
        /// Obtiene un cliente por su identificador numérico.
        /// </summary>
        /// <param name="id">Identificador numérico del cliente.</param>
        /// <returns>El objeto Cliente encontrado o default si no existe.</returns>
        public Cliente GetById(int id)
        {
            Cliente cliente = default;

            using (var reader = SqlHelper.ExecuteReader("ClienteSelectById", CommandType.StoredProcedure,
              new SqlParameter[] { new SqlParameter("@idCliente", id) }))
            {
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    cliente = ClienteMapper.Current.Fill(data);
                }
            }

            return cliente;
        }

        /// <summary>
        /// Obtiene todos los clientes registrados.
        /// </summary>
        /// <returns>Lista de objetos Cliente.</returns>
        public List<Cliente> GetAll()
        {
            List<Cliente> clientes = new List<Cliente>();

            using (var reader = SqlHelper.ExecuteReader("ClienteSelectAll", CommandType.StoredProcedure,
                new SqlParameter[] { }))
            {
                // Mientras haya registros en la tabla de clientes
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    // Data Mapper...
                    Cliente cliente = ClienteMapper.Current.Fill(data);
                    clientes.Add(cliente);
                }
            }

            return clientes;
        }

        /// <summary>
        /// Selecciona un cliente por su número de documento.
        /// </summary>
        /// <param name="nroDocumento">Número de documento a buscar.</param>
        /// <returns>El objeto Cliente encontrado o default si no existe.</returns>
        public Cliente SelectByDocumento(string nroDocumento)
        {
            Cliente cliente = default;

            using (var reader = SqlHelper.ExecuteReader("ClienteSelectByDocumento", CommandType.StoredProcedure,
              new SqlParameter[] { new SqlParameter("@nroDocumento", nroDocumento) }))
            {
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    cliente = ClienteMapper.Current.Fill(data);
                }
            }
            return cliente;
        }

        /// <summary>
        /// Selecciona un cliente por su nombre.
        /// </summary>
        /// <param name="nombre">Nombre del cliente a buscar.</param>
        /// <returns>El objeto Cliente encontrado o default si no existe.</returns>
        public Cliente SelectByNombre(string nombre)
        {
            Cliente cliente = default;

            using (var reader = SqlHelper.ExecuteReader("ClienteSelectByNombre", CommandType.StoredProcedure,
              new SqlParameter[] { new SqlParameter("@nombre", nombre) }))
            {
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    cliente = ClienteMapper.Current.Fill(data);
                }
            }
            return cliente;
        }

        /// <summary>
        /// Selecciona un cliente por su apellido.
        /// </summary>
        /// <param name="apellido">Apellido del cliente a buscar.</param>
        /// <returns>El objeto Cliente encontrado o default si no existe.</returns>
        public Cliente SelectByApellido(string apellido)
        {
            Cliente cliente = default;

            using (var reader = SqlHelper.ExecuteReader("ClienteSelectByApellido", CommandType.StoredProcedure,
              new SqlParameter[] { new SqlParameter("@apellido", apellido) }))
            {
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    cliente = ClienteMapper.Current.Fill(data);
                }
            }
            return cliente;
        }

        /// <summary>
        /// Registra un nuevo cliente en la base de datos.
        /// </summary>
        /// <param name="cliente">El objeto Cliente a registrar.</param>
        /// <returns>El identificador generado para el cliente.</returns>
        public int Registrar(Cliente cliente)
        {
            int idClienteGenerado = 0;

            try
            {
                // Parámetro de salida para capturar el ID generado
                SqlParameter idClienteParam = new SqlParameter("@idCliente", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                SqlHelper.ExecuteNonQuery("RegistrarCliente", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@nroDocumento", cliente.NroDocumento),
                        new SqlParameter("@nombre", cliente.Nombre),
                        new SqlParameter("@apellido", cliente.Apellido),
                        new SqlParameter("@direccion", cliente.Direccion),
                        new SqlParameter("@codPostal", cliente.CodPostal),
                        new SqlParameter("@telefono", cliente.Telefono),
                        new SqlParameter("@mail", cliente.Mail),
                        new SqlParameter("@barrio", cliente.Barrio),
                        new SqlParameter("@provincia", cliente.Provincia),
                        new SqlParameter("@fechaRegistro", cliente.FechaRegistro == default ? (object)DBNull.Value : cliente.FechaRegistro),
                        new SqlParameter("@estado", (int)cliente.Estado), // Conversión de enum a entero
                        idClienteParam
                    }
                );

                idClienteGenerado = Convert.ToInt32(idClienteParam.Value);
            }
            catch (Exception)
            {
                throw;
            }

            return idClienteGenerado;
        }

        /// <summary>
        /// Edita la información de un cliente existente.
        /// </summary>
        /// <param name="obj">El objeto Cliente con la información a editar.</param>
        /// <returns>El resultado de la operación, según lo devuelto por el procedimiento almacenado.</returns>
        public int Editar(Cliente obj)
        {
            try
            {
                // Obtén la fecha de registro previamente registrada en la base de datos
                var fechaRegistroPrevio = ObtenerFechaRegistroPrevio(obj.IdCliente);

                // Si no se ha establecido una fecha de registro, utiliza la fecha de registro previo
                if (obj.FechaRegistro == DateTime.MinValue)
                {
                    obj.FechaRegistro = fechaRegistroPrevio;
                }

                var resultadoParam = new SqlParameter("@resultado", SqlDbType.Int);
                resultadoParam.Direction = ParameterDirection.Output;

                var result = SqlHelper.ExecuteNonQuery("EditarCliente", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@idCliente", obj.IdCliente),
                        new SqlParameter("@nroDocumento", obj.NroDocumento),
                        new SqlParameter("@nombre", obj.Nombre),
                        new SqlParameter("@apellido", obj.Apellido),
                        new SqlParameter("@direccion", obj.Direccion),
                        new SqlParameter("@codPostal", obj.CodPostal),
                        new SqlParameter("@telefono", obj.Telefono),
                        new SqlParameter("@mail", obj.Mail),
                        new SqlParameter("@barrio", obj.Barrio),
                        new SqlParameter("@provincia", obj.Provincia),
                        new SqlParameter("@fechaRegistro", obj.FechaRegistro),  // Aquí pasamos el valor de FechaRegistro
                        new SqlParameter("@estado", (int)obj.Estado),
                        resultadoParam
                    }
                );

                // Lee el valor del parámetro de salida
                int resultado = (int)resultadoParam.Value;

                // Si la operación fue exitosa, devuelve el resultado del procedimiento almacenado
                return resultado;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones (opcional)
                Console.WriteLine(ex.Message);
                return -1; // Devuelve un código de error
            }
        }

        /// <summary>
        /// Obtiene la fecha de registro previamente almacenada para un cliente.
        /// </summary>
        /// <param name="idCliente">El identificador del cliente.</param>
        /// <returns>La fecha de registro previamente almacenada o DateTime.MinValue si no se encuentra.</returns>
        private DateTime ObtenerFechaRegistroPrevio(int idCliente)
        {
            try
            {
                var resultado = SqlHelper.ExecuteScalar("SELECT FechaRegistro FROM Cliente WHERE idCliente = @idCliente", CommandType.Text,
                    new SqlParameter[]
                    {
                        new SqlParameter("@idCliente", idCliente)
                    }
                );

                return (DateTime)resultado;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones (opcional)
                Console.WriteLine(ex.Message);
                return DateTime.MinValue; // Devuelve un valor por defecto si no se puede obtener la fecha
            }
        }

        /// <summary>
        /// Suspende un cliente. (No implementado)
        /// </summary>
        /// <param name="obj">El identificador o valor que determina el cliente a suspender.</param>
        /// <returns>Resultado de la suspensión.</returns>
        public int Suspender(string obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene un cliente por su identificador GUID. (No implementado)
        /// </summary>
        /// <param name="id">El identificador GUID del cliente.</param>
        /// <returns>El objeto Cliente.</returns>
        public Cliente GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene un cliente por su identificador GUID. (No implementado)
        /// </summary>
        /// <param name="id">El identificador GUID del cliente.</param>
        /// <returns>El objeto Cliente.</returns>
        public Cliente GetByGuid(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
