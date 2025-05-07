using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Domain.Composite
{
    /// <summary>
    /// Clase base abstracta que representa un acceso en el sistema.
    /// Aplica el patrón Composite para manejar estructuras jerárquicas de accesos.
    /// </summary>
    public abstract class Acceso
    {
        /// <summary>
        /// Identificador único del acceso.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nombre del acceso.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Acceso() { }

        /// <summary>
        /// Agrega un acceso dentro de otro (implementado en subclases).
        /// </summary>
        public abstract void Add(Acceso component);

        /// <summary>
        /// Remueve un acceso dentro de otro (implementado en subclases).
        /// </summary>
        public abstract void Remove(Acceso component);

        /// <summary>
        /// Devuelve la cantidad de accesos contenidos dentro de este acceso.
        /// </summary>
        public abstract int GetCountAccesos();
    }
}