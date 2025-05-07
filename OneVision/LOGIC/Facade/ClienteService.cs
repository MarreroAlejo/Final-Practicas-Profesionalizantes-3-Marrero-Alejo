using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Facade
{
    /// <summary>
    /// Proporciona servicios de cliente que encapsulan la lógica de negocio relacionada con los clientes.
    /// </summary>
    public class ClienteService
    {
        /// <summary>
        /// Instancia de ClienteLogic utilizada para acceder a la lógica de negocio de clientes.
        /// </summary>
        private ClienteLogic clienteLogic = ClienteLogic.GetInstance();

        /// <summary>
        /// Obtiene la lista de todos los clientes.
        /// </summary>
        /// <returns>Lista de objetos Cliente.</returns>
        public List<Cliente> ObtenerClientes()
        {
            return clienteLogic.GetAll();
        }

        /// <summary>
        /// Busca un cliente por su número de documento.
        /// </summary>
        /// <param name="documento">Número de documento del cliente.</param>
        /// <returns>El objeto Cliente que coincide con el documento.</returns>
        public Cliente BuscarClientePorDocumento(string documento)
        {
            return clienteLogic.SelectByDocumento(documento);
        }

        /// <summary>
        /// Busca un cliente por su nombre.
        /// </summary>
        /// <param name="documento">Nombre del cliente (se utiliza el mismo método de búsqueda por documento).</param>
        /// <returns>El objeto Cliente que coincide con el nombre.</returns>
        public Cliente BuscarClientePorNombre(string documento)
        {
            return clienteLogic.SelectByDocumento(documento);
        }

        /// <summary>
        /// Busca un cliente por su apellido.
        /// </summary>
        /// <param name="documento">Apellido del cliente (se utiliza el mismo método de búsqueda por documento).</param>
        /// <returns>El objeto Cliente que coincide con el apellido.</returns>
        public Cliente BuscarClientePorApellido(string documento)
        {
            return clienteLogic.SelectByDocumento(documento);
        }

        /// <summary>
        /// Registra un nuevo cliente.
        /// </summary>
        /// <param name="cliente">El objeto Cliente a registrar.</param>
        /// <returns>El identificador generado para el cliente.</returns>
        public int RegistrarCliente(Cliente cliente)
        {
            return clienteLogic.Registrar(cliente);
        }

        /// <summary>
        /// Edita la información de un cliente existente.
        /// </summary>
        /// <param name="cliente">El objeto Cliente con los datos a editar.</param>
        /// <returns>Un entero indicando el resultado de la operación de edición.</returns>
        public int EditarCliente(Cliente cliente)
        {
            return clienteLogic.Editar(cliente);
        }
    }
}
