using DAO.Contracts;
using DAO.Factory;
using DOMAIN;
using System;
using System.Collections.Generic;

namespace LOGIC
{
    /// <summary>
    /// Encapsula la lógica de negocio para la gestión de clientes.
    /// </summary>
    public class ClienteLogic
    {
        #region Singleton
        private static ClienteLogic instance = new ClienteLogic();
        private static object instanceLock = new object();

        /// <summary>
        /// Constructor privado para la implementación del patrón singleton.
        /// </summary>
        private ClienteLogic() { }

        /// <summary>
        /// Obtiene la instancia única de ClienteLogic.
        /// </summary>
        /// <returns>Instancia única de ClienteLogic.</returns>
        public static ClienteLogic GetInstance()
        {
            if (instance is null)
            {
                lock (instanceLock)
                {
                    if (instance is null)
                    {
                        instance = new ClienteLogic();
                    }
                }
            }
            return instance;
        }

        /// <summary>
        /// Propiedad para obtener la instancia única de ClienteLogic.
        /// </summary>
        public static ClienteLogic Instance
        {
            get
            {
                if (instance is null)
                    instance = new ClienteLogic();

                return instance;
            }
        }
        #endregion

        /// <summary>
        /// Obtiene un cliente por su identificador.
        /// </summary>
        /// <param name="idCliente">Identificador del cliente.</param>
        /// <returns>Objeto Cliente correspondiente.</returns>
        public Cliente GetById(int idCliente)
        {
            try
            {
                IClienteDao clienteDao = FactoryDao.CreateClienteDao();
                return clienteDao.GetById(idCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el cliente: " + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene todos los clientes registrados.
        /// </summary>
        /// <returns>Lista de objetos Cliente.</returns>
        public List<Cliente> GetAll()
        {
            try
            {
                IClienteDao clienteDao = FactoryDao.CreateClienteDao();
                return clienteDao.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el cliente: " + ex.Message);
            }
        }

        /// <summary>
        /// Selecciona un cliente utilizando su número de documento.
        /// </summary>
        /// <param name="nroDocumento">Número de documento del cliente.</param>
        /// <returns>Objeto Cliente encontrado.</returns>
        public Cliente SelectByDocumento(string nroDocumento)
        {
            try
            {
                IClienteDao clienteDao = FactoryDao.CreateClienteDao();
                return clienteDao.SelectByDocumento(nroDocumento);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el cliente: " + ex.Message);
            }
        }

        /// <summary>
        /// Selecciona un cliente utilizando su nombre.
        /// </summary>
        /// <param name="nombre">Nombre del cliente.</param>
        /// <returns>Objeto Cliente encontrado.</returns>
        public Cliente SelectByNombre(string nombre)
        {
            try
            {
                IClienteDao clienteDao = FactoryDao.CreateClienteDao();
                return clienteDao.SelectByNombre(nombre);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el cliente: " + ex.Message);
            }
        }

        /// <summary>
        /// Selecciona un cliente utilizando su apellido.
        /// </summary>
        /// <param name="apellido">Apellido del cliente.</param>
        /// <returns>Objeto Cliente encontrado.</returns>
        public Cliente SelectByApellido(string apellido)
        {
            try
            {
                IClienteDao clienteDao = FactoryDao.CreateClienteDao();
                return clienteDao.SelectByApellido(apellido);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el cliente: " + ex.Message);
            }
        }

        /// <summary>
        /// Registra un nuevo cliente en el sistema.
        /// </summary>
        /// <param name="cliente">Objeto Cliente a registrar.</param>
        /// <returns>Identificador generado para el cliente.</returns>
        public int Registrar(Cliente cliente)
        {
            IClienteDao clienteDao = FactoryDao.CreateClienteDao();

            // Validar si el cliente ya existe por nroDocumento
            Cliente clienteExistente = clienteDao.SelectByDocumento(cliente.NroDocumento.ToString());
            if (clienteExistente != null)
            {
                throw new Exception($"Ya existe un cliente registrado con el número de documento {cliente.NroDocumento}. " +
                                    $"Cliente existente: {clienteExistente.Nombre} {clienteExistente.Apellido}.");
            }

            // Registrar nuevo cliente y devolver el IdCliente generado
            return clienteDao.Registrar(cliente);
        }

        /// <summary>
        /// Edita la información de un cliente existente.
        /// </summary>
        /// <param name="cliente">Objeto Cliente con los datos a editar.</param>
        /// <returns>Resultado de la operación de edición.</returns>
        public int Editar(Cliente cliente)
        {
            IClienteDao clienteDao = FactoryDao.CreateClienteDao();

            if (cliente.IdCliente != 0)
            {
                // Llamar al DAO para editar y retornar el resultado
                int resultado = clienteDao.Editar(cliente);

                if (resultado > 0)
                {
                    // La operación de edición fue exitosa
                    return resultado;
                }
                else
                {
                    // La operación de edición no fue exitosa
                    throw new Exception("Error al editar el cliente");
                }
            }
            return -1; // Indica que no se puede editar (ID inválido)
        }
    }
}
