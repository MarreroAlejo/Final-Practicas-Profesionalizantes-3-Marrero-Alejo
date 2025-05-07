using System;

namespace SERVICES.Logic.Exceptions.PatenteExceptions
{
    public class PatenteNoRemovibleException : Exception
    {
        public PatenteNoRemovibleException(string patenteNombre)
            : base($"No se puede eliminar la patente '{patenteNombre}', ya que es requerida.")
        {
        }
    }
}
