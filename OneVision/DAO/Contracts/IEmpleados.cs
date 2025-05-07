using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Contracts
{
    /// <summary>
    /// Define las operaciones para el manejo de empleados de tipo genérico.
    /// </summary>
    /// <typeparam name="T">El tipo de objeto empleado.</typeparam>
    public interface IEmpleados<T>
    {
        /// <summary>
        /// Registra un nuevo empleado.
        /// </summary>
        /// <param name="obj">El objeto empleado a registrar.</param>
        /// <returns>El identificador único asignado al empleado.</returns>
        Guid Registrar(T obj);

        /// <summary>
        /// Edita la información de un empleado existente.
        /// </summary>
        /// <param name="obj">El objeto empleado con los datos a modificar.</param>
        /// <returns>El identificador único del empleado editado.</returns>
        Guid Editar(T obj);

        /// <summary>
        /// Obtiene todos los empleados registrados.
        /// </summary>
        /// <returns>Una lista de objetos del tipo empleado.</returns>
        List<T> GetAll();

        /// <summary>
        /// Obtiene un empleado según su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del empleado.</param>
        /// <returns>El objeto empleado correspondiente.</returns>
        T GetById(Guid id);

        /// <summary>
        /// Obtiene el empleado asociado a un usuario.
        /// </summary>
        /// <param name="idUsuario">El identificador del usuario asociado.</param>
        /// <returns>El objeto <see cref="Empleado"/> correspondiente al usuario.</returns>
        Empleado GetEmpleadoPorUsuario(Guid idUsuario);
    }
}
