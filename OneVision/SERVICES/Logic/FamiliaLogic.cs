using SERVICES.Dao.Implementations.SqlServer;
using SERVICES.Domain.Composite;
using SERVICES.Logic;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;
/// <summary>
/// Lógica de negocio para la gestión de Familias (perfiles o grupos de permisos).
/// </summary>
public class FamiliaLogic
{
    private UserLogic userLogic;

    #region Singleton
    /// <summary>
    /// Instancia única de la clase.
    /// </summary>
    private static FamiliaLogic instance = new FamiliaLogic();

    /// <summary>
    /// Objeto para manejo de concurrencia al instanciar.
    /// </summary>
    private static object instanceLock = new object();

    /// <summary>
    /// Constructor privado para patrón Singleton.
    /// </summary>
    private FamiliaLogic() { }

    /// <summary>
    /// Devuelve la instancia única de la clase (Singleton con doble verificación).
    /// </summary>
    public static FamiliaLogic GetInstance()
    {
        if (instance is null)
        {
            lock (instanceLock)
            {
                if (instance is null)
                {
                    instance = new FamiliaLogic();
                }
            }
        }
        return instance;
    }

    /// <summary>
    /// Propiedad de acceso a la instancia única.
    /// </summary>
    public static FamiliaLogic Instance
    {
        get
        {
            if (instance is null)
                instance = new FamiliaLogic();
            return instance;
        }
    }
    #endregion

    #region Acciones Familia

    /// <summary>
    /// Registra una nueva Familia.
    /// </summary>
    public Guid Registrar(Familia obj)
    {
        return FamiliaRepository.Current.Registrar(obj);
    }

    /// <summary>
    /// Obtiene la lista de todas las Familias.
    /// </summary>
    public List<Familia> GetAllFamilias()
    {
        return FamiliaRepository.Current.GetAll();
    }

    #endregion

    #region Acciones Familia-Patente

    /// <summary>
    /// Obtiene el recuento de patentes asociadas a una Familia.
    /// </summary>
    public void GetCountFamiliaPatente(Familia familia)
    {
        FamiliaPatenteRepository.Current.GetCount(familia);
    }

    /// <summary>
    /// Obtiene una Familia por su identificador.
    /// </summary>
    public void GetById(Guid id)
    {
        FamiliaRepository.Current.GetById(id);
    }

    /// <summary>
    /// Asocia una patente a una familia.
    /// </summary>
    public void Add(Familia familiaPadre, Patente patenteHija)
    {
        familiaPadre.Add(patenteHija);
        FamiliaPatenteRepository.Current.Add(familiaPadre, patenteHija);
    }

    /// <summary>
    /// Elimina la relación entre una familia y una patente.
    /// </summary>
    public void Delete(Familia familiaPadre, Patente patenteHija)
    {
        FamiliaPatenteRepository.Current.Delete(familiaPadre, patenteHija);
    }

    #endregion

    #region Familia - Familia

    /// <summary>
    /// Obtiene recursivamente el conteo de subfamilias asociadas.
    /// </summary>
    public void GetCountFamiliaFamilia(Familia obj, HashSet<Guid> familiasProcesadas = null)
    {
        if (familiasProcesadas == null)
            familiasProcesadas = new HashSet<Guid>();

        if (familiasProcesadas.Contains(obj.Id))
            return;

        familiasProcesadas.Add(obj.Id);
        FamiliaFamiliaRepository.Current.GetCount(obj);

        foreach (var acceso in obj.Accesos)
        {
            if (acceso is Familia subFamilia)
            {
                GetCountFamiliaFamilia(subFamilia, familiasProcesadas);
                FamiliaPatenteRepository.Current.GetCount(subFamilia);
            }
        }
    }

    /// <summary>
    /// Agrega una subfamilia a otra familia.
    /// </summary>
    public void Add(Familia familiaPadre, Familia familiaHija)
    {
        familiaPadre.Add(familiaHija);
        FamiliaFamiliaRepository.Current.Add(familiaPadre, familiaHija);
    }

    /// <summary>
    /// Elimina la relación entre dos familias.
    /// </summary>
    public void Delete(Familia familiaPadre, Familia familiaHija)
    {
        FamiliaFamiliaRepository.Current.Delete(familiaPadre, familiaHija);
    }

    /// <summary>
    /// Elimina una familia por su identificador.
    /// </summary>
    public void Eliminar(Guid idFamilia)
    {
        try
        {
            FamiliaRepository.Current.Eliminar(idFamilia);
        }
        catch (SqlException sqlEx)
        {
            throw new Exception("Error al interactuar con la base de datos al eliminar la familia.", sqlEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Error al eliminar la familia.", ex);
        }
    }

    #endregion
}
