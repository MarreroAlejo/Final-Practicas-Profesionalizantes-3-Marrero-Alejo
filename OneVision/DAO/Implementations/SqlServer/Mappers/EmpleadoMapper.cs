using Dao.Contracts;
using DOMAIN;
using System;

public sealed class EmpleadoMapper : IObjectMapper<Empleado>
{
    #region Singleton

    private static readonly EmpleadoMapper _instance = new EmpleadoMapper();

    public static EmpleadoMapper Current => _instance;

    private EmpleadoMapper()
    {
        // Initialize singleton if necessary
    }

    #endregion
    public Empleado Fill(object[] values)
    {
        try
        {
            var empleado = new Empleado
            {
                IdEmpleado = Guid.Parse(values[(int)EmpleadoColumns.idEmpleado].ToString()),
                IdUsuario = Guid.Parse(values[(int)EmpleadoColumns.idUsuario].ToString()),
                IdSucursal = Guid.Parse(values[(int)EmpleadoColumns.idSucursal].ToString()),
                IdFamilia = Guid.Parse(values[(int)EmpleadoColumns.idFamilia].ToString()),  // Aquí asignamos el GUID de la familia
                Nombre = values[(int)EmpleadoColumns.nombre]?.ToString() ?? string.Empty,
                Apellido = values[(int)EmpleadoColumns.apellido]?.ToString() ?? string.Empty,
                Mail = values[(int)EmpleadoColumns.mail]?.ToString() ?? string.Empty,
                Telefono = values[(int)EmpleadoColumns.telefono]?.ToString() ?? string.Empty,
                FechaRegistro = DateTime.Parse(values[(int)EmpleadoColumns.fechaRegistro]?.ToString() ?? DateTime.MinValue.ToString()),
            };

            return empleado;
        }
        catch (FormatException ex)
        {
            throw new Exception("Error de formato al llenar el empleado: " + ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception("Error al llenar el empleado: " + ex.Message);
        }
    }

    internal enum EmpleadoColumns
    {
        idEmpleado = 0,
        idUsuario = 1,
        idSucursal = 2,
        idFamilia = 3,  // Ahora usamos un campo para la familia (Guid)
        nombre = 4,
        apellido = 5,
        mail = 6,
        telefono = 7,
        fechaRegistro = 8,
    }
}
