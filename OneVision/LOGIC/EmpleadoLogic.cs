using DAO.Contracts;
using DAO.Factory;
using DAO.Implementations.SqlServer;
using DOMAIN;
using System;
using System.Collections.Generic;

namespace LOGIC
{
    /// <summary>
    /// Encapsula la lógica de negocio para la gestión de empleados.
    /// </summary>
    public class EmpleadoLogic
    {
        #region Singleton
        private static EmpleadoLogic instance = new EmpleadoLogic();
        private static object instanceLock = new object();

        /// <summary>
        /// Constructor privado para la implementación del patrón singleton.
        /// </summary>
        private EmpleadoLogic() { }

        /// <summary>
        /// Obtiene la instancia única de EmpleadoLogic.
        /// </summary>
        /// <returns>Instancia de EmpleadoLogic.</returns>
        public static EmpleadoLogic GetInstance()
        {
            if (instance is null)
            {
                lock (instanceLock)
                {
                    if (instance is null)
                    {
                        instance = new EmpleadoLogic();
                    }
                }
            }
            return instance;
        }

        /// <summary>
        /// Propiedad para obtener la instancia única de EmpleadoLogic.
        /// </summary>
        public static EmpleadoLogic Instance
        {
            get
            {
                if (instance is null)
                    instance = new EmpleadoLogic();

                return instance;
            }
        }
        #endregion

        /// <summary>
        /// Obtiene un empleado por su identificador GUID.
        /// </summary>
        /// <param name="id">Identificador GUID del empleado.</param>
        /// <returns>Objeto Empleado correspondiente.</returns>
        public Empleado GetById(Guid id)
        {
            try
            {
                IEmpleados<Empleado> empleadoDao = FactoryDao.CreateEmpleadoDao();
                return empleadoDao.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el vendedor: " + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene todos los empleados registrados.
        /// </summary>
        /// <returns>Lista de objetos Empleado.</returns>
        public List<Empleado> GetAll()
        {
            try
            {
                IEmpleados<Empleado> empleadoDao = FactoryDao.CreateEmpleadoDao();
                return empleadoDao.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el vendedor: " + ex.Message);
            }
        }

        /// <summary>
        /// Registra un nuevo empleado en el sistema.
        /// </summary>
        /// <param name="empleado">Objeto Empleado a registrar.</param>
        /// <returns>Identificador GUID del empleado registrado.</returns>
        public Guid Registrar(Empleado empleado)
        {
            IEmpleados<Empleado> empleadoDao = FactoryDao.CreateEmpleadoDao();

            // Asigna un nuevo GUID si el IdEmpleado está vacío
            if (empleado.IdEmpleado == Guid.Empty)
            {
                empleado.IdEmpleado = Guid.NewGuid(); // Crea un nuevo GUID
            }
            return empleadoDao.Registrar(empleado);
        }

        /// <summary>
        /// Edita la información de un empleado existente.
        /// </summary>
        /// <param name="empleado">Objeto Empleado con los datos a editar.</param>
        /// <returns>GUID que indica el resultado de la operación de edición; Guid.Empty si no se puede editar.</returns>
        public Guid Editar(Empleado empleado)
        {
            IEmpleados<Empleado> empleadoDao = FactoryDao.CreateEmpleadoDao();
            if (empleado.IdEmpleado != Guid.Empty)
            {
                empleadoDao.Editar(empleado);
            }
            return Guid.Empty; // Indica que no se puede editar (ID inválido)
        }

        /// <summary>
        /// Obtiene un empleado asociado a un usuario específico.
        /// </summary>
        /// <param name="idUsuario">Identificador del usuario.</param>
        /// <returns>Objeto Empleado asociado al usuario.</returns>
        public Empleado GetEmpleadoPorUsuario(Guid idUsuario)
        {
            IEmpleados<Empleado> empleadoDao = FactoryDao.CreateEmpleadoDao();
            return empleadoDao.GetEmpleadoPorUsuario(idUsuario);
        }
    }
}
