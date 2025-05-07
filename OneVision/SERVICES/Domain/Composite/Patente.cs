using SERVICES.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Domain.Composite
{
    /// <summary>
    /// Representa una patente en el sistema, la cual es un acceso simple que no puede contener otros accesos.
    /// </summary>
    public class Patente : Acceso
    {
        /// <summary>
        /// Obtiene o establece el tipo de acceso de la patente.
        /// </summary>
        public TipoAcceso TipoAcceso { get; set; }

        /// <summary>
        /// Obtiene o establece la clave de datos asociada a la patente.
        /// </summary>
        public string DataKey { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Patente, especificando el tipo de acceso (por defecto UI).
        /// </summary>
        /// <param name="tipoAcceso">Tipo de acceso para la patente.</param>
        public Patente(TipoAcceso tipoAcceso = TipoAcceso.UI)
        {
            this.TipoAcceso = tipoAcceso;
        }

        /// <summary>
        /// No se permite agregar componentes a una patente; este método lanza una excepción.
        /// </summary>
        /// <param name="component">Componente a agregar.</param>
        public override void Add(Acceso component)
        {
            throw new OperacionNoPermitidaEnPatente();
        }

        /// <summary>
        /// No se permite eliminar componentes de una patente; este método lanza una excepción.
        /// </summary>
        /// <param name="component">Componente a eliminar.</param>
        public override void Remove(Acceso component)
        {
            throw new OperacionNoPermitidaEnPatente();
        }

        /// <summary>
        /// Retorna la cantidad de accesos hijos; siempre es 0 para una patente.
        /// </summary>
        /// <returns>0, ya que una patente no tiene hijos.</returns>
        public override int GetCountAccesos()
        {
            return 0;
        }

        /// <summary>
        /// Retorna una representación en cadena de la patente, utilizando su nombre.
        /// </summary>
        /// <returns>Nombre de la patente.</returns>
        public override string ToString()
        {
            return Nombre;
        }
    }

    /// <summary>
    /// Enumera los posibles tipos de acceso para una patente.
    /// </summary>
    public enum TipoAcceso
    {
        UI,
        Control,
        UseCases
    }
}
