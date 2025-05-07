using System;

namespace SERVICES.Logic.Exceptions.FamiliaExceptions
{
    public class FamiliaNoEncontradaException : Exception
    {
        public FamiliaNoEncontradaException(string nombreFamilia)
            : base($"La familia '{nombreFamilia}' no existe o no es válida.") { }
    }
}
