using SERVICES.Dao.Implementations;
using System;

public sealed class ConnectionManager
{
    private static readonly Lazy<ConnectionManager> instance = new Lazy<ConnectionManager>(() => new ConnectionManager());
    private readonly DatabaseConnectionVerifier verifier;

    public bool IsConnected { get; private set; }

    private ConnectionManager()
    {
        verifier = new DatabaseConnectionVerifier();
        UpdateConnectionStatus();
    }

    public static ConnectionManager Instance => instance.Value;

    public void UpdateConnectionStatus()
    {
        IsConnected = verifier.AreConnectionsOk();
    }
}
