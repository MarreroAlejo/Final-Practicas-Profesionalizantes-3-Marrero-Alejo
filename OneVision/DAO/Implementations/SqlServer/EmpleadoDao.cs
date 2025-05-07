using Dao.Helpers;
using DAO.Contracts;
using DAO.Implementations.SqlServer.Mappers;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Implementations.SqlServer
{
    /// <summary>
    /// Implementa la interfaz IEmpleados&lt;Empleado&gt; para el manejo de empleados en una base de datos SqlServer.
    /// </summary>
    public sealed class EmpleadoDao : IEmpleados<Empleado>
    {
        #region singleton
        private readonly static EmpleadoDao _instance = new EmpleadoDao();

        /// <summary>
        /// Obtiene la instancia actual (singleton) de EmpleadoDao.
        /// </summary>
        public static EmpleadoDao Current
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Constructor privado para la implementación del singleton.
        /// </summary>
        private EmpleadoDao()
        {
            // Implement here the initialization of your singleton
        }
        #endregion

        /// <summary>
        /// Obtiene un empleado asociado a un usuario.
        /// </summary>
        /// <param name="idUsuario">El identificador del usuario.</param>
        /// <returns>El objeto Empleado encontrado o default si no existe.</returns>
        public Empleado GetEmpleadoPorUsuario(Guid idUsuario)
        {
            Empleado empleado = default;

            // Usar el helper para ejecutar el procedimiento almacenado
            using (var reader = SqlHelper.ExecuteReader("sp_GetEmpleadoPorUsuario", CommandType.StoredProcedure,
                new SqlParameter[] { new SqlParameter("@idUsuario", idUsuario) }))
            {
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    // Usar el mapper para convertir los datos en un objeto Empleado
                    empleado = EmpleadoMapper.Current.Fill(data);
                }
            }

            return empleado;
        }

        /// <summary>
        /// Registra un nuevo empleado en la base de datos.
        /// </summary>
        /// <param name="obj">El objeto Empleado a registrar.</param>
        /// <returns>El identificador GUID del empleado registrado.</returns>
        public Guid Registrar(Empleado obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery("sp_RegistrarEmpleado", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@IdEmpleado", obj.IdEmpleado),
                        new SqlParameter("@IdUsuario", obj.IdUsuario),
                        new SqlParameter("@IdSucursal", obj.IdSucursal),
                        new SqlParameter("@IdFamilia", obj.IdFamilia),
                        new SqlParameter("@Nombre", obj.Nombre),
                        new SqlParameter("@Apellido", obj.Apellido),
                        new SqlParameter("@Mail", obj.Mail),
                        new SqlParameter("@Telefono", obj.Telefono),
                        new SqlParameter("@FechaRegistro", obj.FechaRegistro)
                    }
                );
            }
            catch (Exception)
            {
                throw;
            }

            return obj.IdEmpleado;
        }

        /// <summary>
        /// Edita la información de un empleado existente.
        /// </summary>
        /// <param name="obj">El objeto Empleado con la información a editar.</param>
        /// <returns>El identificador GUID del empleado editado.</returns>
        public Guid Editar(Empleado obj)
        {
            try
            {
                // Llamar al procedimiento almacenado con los parámetros correctos
                SqlHelper.ExecuteNonQuery("sp_EditarEmpleado", CommandType.StoredProcedure,
                    new SqlParameter[]
                    {
                        new SqlParameter("@IdEmpleado", obj.IdEmpleado),
                        new SqlParameter("@IdUsuario", obj.IdUsuario),
                        new SqlParameter("@IdSucursal", obj.IdSucursal),
                        new SqlParameter("@IdFamilia", obj.IdFamilia),
                        new SqlParameter("@Nombre", obj.Nombre),
                        new SqlParameter("@Apellido", obj.Apellido),
                        new SqlParameter("@Mail", obj.Mail),
                        new SqlParameter("@Telefono", obj.Telefono),
                        new SqlParameter("@FechaRegistro", obj.FechaRegistro)
                    }
                );

                return obj.IdEmpleado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar el empleado: " + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene todos los empleados registrados.
        /// </summary>
        /// <returns>Lista de objetos Empleado.</returns>
        public List<Empleado> GetAll()
        {
            List<Empleado> empleados = new List<Empleado>();

            using (var reader = SqlHelper.ExecuteReader("sp_GetAllEmpleados", CommandType.StoredProcedure,
                new SqlParameter[] { }))
            {
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    // Data Mapper...
                    Empleado empleado = EmpleadoMapper.Current.Fill(data);
                    empleados.Add(empleado);
                }
            }

            return empleados;
        }

        /// <summary>
        /// Obtiene un empleado por su identificador GUID.
        /// </summary>
        /// <param name="id">El identificador GUID del empleado.</param>
        /// <returns>El objeto Empleado encontrado o default si no existe.</returns>
        public Empleado GetById(Guid id)
        {
            Empleado empleado = default;

            using (var reader = SqlHelper.ExecuteReader("sp_GetEmpleadoById", CommandType.StoredProcedure,
              new SqlParameter[] { new SqlParameter("@IdEmpleado", id) }))
            {
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    empleado = EmpleadoMapper.Current.Fill(data);
                }
            }

            return empleado;
        }
    }
}
