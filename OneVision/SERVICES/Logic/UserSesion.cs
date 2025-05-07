using SERVICES.Domain.Composite;
using System;

public class UserSesion
{
    private static UserSesion instance;
    private static readonly object lockObj = new object();

    public Usuario UsuarioActual { get; private set; }
    public bool IsLoggedIn => UsuarioActual != null;


    private UserSesion() { }

    public static UserSesion Instance
    {
        get
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new UserSesion();
                    }
                }
            }
            return instance;
        }
    }

    public void IniciarSesion(Usuario usuario)
    {
        if (usuario == null)
            throw new ArgumentNullException(nameof(usuario));

        UsuarioActual = usuario;
    }

    public void FinalizarSesion()
    {
        UsuarioActual = null;
    }
}
