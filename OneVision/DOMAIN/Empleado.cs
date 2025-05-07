using System;

/// <summary>
/// Representa un empleado del sistema.
/// </summary>

public class Empleado
{
    public Guid IdEmpleado { get; set; }
    public Guid IdUsuario { get; set; }
    public Guid IdSucursal { get; set; }
    public Guid IdFamilia { get; set; } 
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Mail { get; set; }
    public string Telefono { get; set; }
    public DateTime FechaRegistro { get; set; }
}
