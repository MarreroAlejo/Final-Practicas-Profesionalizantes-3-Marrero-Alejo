using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Dao.Contracts;
using static DOMAIN.Cliente;

namespace DAO.Implementations.SqlServer.Mappers
{
    internal sealed class ClienteMapper : IObjectMapper<Cliente>
    {
        #region singleton

        // Patron Singleton: asegura que solo exista una única instancia de la clase durante todo el ciclo de vida del programa.

        private readonly static ClienteMapper _instance = new ClienteMapper();

        public static ClienteMapper Current
        {
            get
            {
                return _instance;
            }
        }

        private ClienteMapper()
        {
           
        }
        #endregion
        public Cliente Fill(object[] values)
        {
            try
            {
                var cliente = new Cliente
                {
                    IdCliente = int.Parse(values[(int)ClienteColumns.idCliente].ToString()),
                    NroDocumento = int.Parse(values[(int)ClienteColumns.nroDocumento].ToString()),
                    Nombre = values[(int)ClienteColumns.nombre].ToString(),
                    Apellido = values[(int)ClienteColumns.apellido].ToString(),
                    Direccion = values[(int)ClienteColumns.direccion].ToString(),
                    CodPostal = int.Parse(values[(int)ClienteColumns.codPostal].ToString()),
                    Telefono = values[(int)ClienteColumns.telefono].ToString(),
                    Mail = values[(int)ClienteColumns.mail].ToString(),
                    Barrio = values[(int)ClienteColumns.barrio].ToString(),
                    Provincia = values[(int)ClienteColumns.provincia].ToString(),
                    FechaRegistro = DateTime.Parse(values[(int)ClienteColumns.fechaRegistro].ToString()),
                    Estado = (Cliente.EstadoCliente)int.Parse(values[(int)ClienteColumns.estado].ToString())
                };

                return cliente;
            }
            catch (FormatException ex)
            {
                throw new Exception("Error de formato al llenar el cliente: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al llenar el cliente: " + ex.Message);
            }
        }



        internal enum ClienteColumns
        {
            idCliente = 0,
            nroDocumento = 1,
            nombre = 2,
            apellido = 3,
            direccion = 4,
            codPostal = 5,
            telefono = 6,
            mail = 7,
            barrio = 8,
            provincia = 9,
            fechaRegistro = 10,
            estado = 11
        }

    }
}
