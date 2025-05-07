using System;

namespace SERVICES.Logic.Exceptions.FamiliaExceptions
{
    public class FamiliaNoEliminableException : Exception
    {
        public FamiliaNoEliminableException(string familiaNombre)
            : base($"La familia '{familiaNombre}' no puede ser eliminada.")
        {
        }
    }
}
