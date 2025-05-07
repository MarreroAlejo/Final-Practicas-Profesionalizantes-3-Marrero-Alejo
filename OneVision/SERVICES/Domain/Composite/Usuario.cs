using SERVICES.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Domain.Composite
{
    /// <summary>
    /// Representa un usuario del sistema, incluyendo sus credenciales y la lista de accesos asignados.
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Obtiene o establece el identificador GUID del usuario.
        /// </summary>
        public Guid IdUsuario { get; set; }
        /// <summary>
        /// Obtiene o establece el nombre de usuario.
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Obtiene o establece la contraseña del usuario.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Obtiene o establece el estado del usuario.
        /// </summary>
        public EstadoUsuario Estado { get; set; }

        /// <summary>
        /// Enumera los posibles estados de un usuario.
        /// </summary>
        public enum EstadoUsuario
        {
            /// <summary>
            /// Usuario suspendido.
            /// </summary>
            Suspendido = 0,
            /// <summary>
            /// Usuario activo.
            /// </summary>
            Activo = 1
        }

        /// <summary>
        /// Obtiene la lista de accesos (familias y patentes) asignados al usuario.
        /// </summary>
        public List<Acceso> Accesos { get; private set; } = new List<Acceso>();

        /// <summary>
        /// Constructor por defecto que inicializa la lista de accesos.
        /// </summary>
        public Usuario()
        {
            Accesos = new List<Acceso>();
        }

        /// <summary>
        /// Obtiene recursivamente todas las patentes asignadas al usuario.
        /// </summary>
        /// <param name="accesos">Lista de accesos a evaluar.</param>
        /// <param name="patentesReturn">Lista de patentes resultantes.</param>
        public void GetAllPatentes(List<Acceso> accesos, List<Patente> patentesReturn)
        {
            foreach (var acceso in accesos)
            {
                // Si es un leaf (hoja), significa que es una patente
                if (acceso.GetCountAccesos() == 0 && acceso is Patente patente)
                {
                    if (!patentesReturn.Any(p => p.Id == patente.Id))
                    {
                        patentesReturn.Add(patente);
                    }
                }
                else if (acceso is Familia familia)
                {
                    // Si es una familia, continuar buscando recursivamente
                    GetAllPatentes(familia.Accesos, patentesReturn);
                }
            }
        }

        /// <summary>
        /// Obtiene recursivamente todas las familias asignadas al usuario.
        /// </summary>
        /// <param name="accesos">Lista de accesos a evaluar.</param>
        /// <param name="familiaReturn">Lista de familias resultantes.</param>
        public void GetAllFamilias(List<Acceso> accesos, List<Familia> familiaReturn)
        {
            foreach (var acceso in accesos)
            {
                if (acceso.GetCountAccesos() > 0 && acceso is Familia familia)
                {
                    if (!familiaReturn.Any(f => f.Id == familia.Id))
                    {
                        familiaReturn.Add(familia);
                    }
                    // Buscar familias de forma recursiva
                    GetAllFamilias(familia.Accesos, familiaReturn);
                }
            }
        }

        /// <summary>
        /// Verifica si el usuario tiene acceso a un componente identificado por un GUID.
        /// </summary>
        /// <param name="idAcceso">Identificador GUID del acceso a verificar.</param>
        /// <returns>True si el usuario tiene acceso; de lo contrario, false.</returns>
        public bool TieneAcceso(Guid idAcceso)
        {
            return Accesos.Any(acceso => acceso.Id == idAcceso ||
                (acceso is Familia familia && familia.GetAccesos().Any(a => a.Id == idAcceso)));
        }

        /// <summary>
        /// Asigna directamente una lista de patentes a los accesos del usuario.
        /// </summary>
        /// <param name="patentes">Lista de patentes a asignar.</param>
        public void SetPatentes(List<Patente> patentes)
        {
            Accesos.AddRange(patentes);
        }

        /// <summary>
        /// Asigna directamente una lista de familias a los accesos del usuario.
        /// </summary>
        /// <param name="familias">Lista de familias a asignar.</param>
        public void SetFamilias(List<Familia> familias)
        {
            Accesos.AddRange(familias);
        }
    }
}
