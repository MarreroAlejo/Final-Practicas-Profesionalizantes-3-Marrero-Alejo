using System;

namespace SERVICES.Logic.Exceptions.FamiliaExceptions
{
    public class FamiliaNoSeleccionadaException : Exception
    {
        public FamiliaNoSeleccionadaException()
            : base("Por favor, seleccione una familia para agregar.") { }
    }
}
