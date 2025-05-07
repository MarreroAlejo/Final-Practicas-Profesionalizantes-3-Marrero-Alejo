using System;
/// <summary>
/// Se lanza cuando se intenta dejar una familia sin hijos.
/// </summary>
public class ImposibleFamiliaSinHijos : InvalidOperationException
{
    public ImposibleFamiliaSinHijos() : base("Una familia no puede quedar vacía.") { }

    public ImposibleFamiliaSinHijos(string message) : base(message) { }
}
