using SERVICES.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Domain.Composite
{
    /// <summary>
    /// Representa una familia en el sistema, la cual es un tipo de acceso compuesto que puede contener otros accesos.
    /// </summary>
    public class Familia : Acceso
    {
        // Lista interna que almacena los accesos (hijos) asociados a la familia.
        private List<Acceso> accesos = new List<Acceso>();

        /// <summary>
        /// Inicializa una nueva instancia de la clase Familia, agregando opcionalmente un acceso inicial.
        /// </summary>
        /// <param name="acceso">Acceso opcional para agregar a la familia.</param>
        public Familia(Acceso acceso = null)
        {
            if (acceso != null && !accesos.Any(a => a.Id == acceso.Id))
                accesos.Add(acceso);
        }

        /// <summary>
        /// Constructor por defecto que inicializa la familia sin accesos.
        /// </summary>
        public Familia()
        {
        }

        /// <summary>
        /// Agrega un componente de tipo Acceso a la familia, si aún no existe.
        /// </summary>
        /// <param name="component">Componente de tipo Acceso a agregar.</param>
        public override void Add(Acceso component)
        {
            if (!accesos.Any(a => a.Id == component.Id))
                accesos.Add(component);
        }

        /// <summary>
        /// Elimina un componente de tipo Acceso de la familia. Si la familia queda sin hijos, lanza una excepción.
        /// </summary>
        /// <param name="component">Componente de tipo Acceso a eliminar.</param>
        public override void Remove(Acceso component)
        {
            accesos.RemoveAll(o => o.Id == component.Id);
            if (accesos.Count == 0)
                throw new ImposibleFamiliaSinHijos();
        }

        /// <summary>
        /// Obtiene la lista de accesos (hijos) que contiene la familia.
        /// </summary>
        /// <returns>Lista de objetos Acceso.</returns>
        public List<Acceso> GetAccesos()
        {
            return accesos;
        }

        /// <summary>
        /// Retorna el número de accesos hijos que contiene la familia.
        /// </summary>
        /// <returns>Número de accesos hijos.</returns>
        public override int GetCountAccesos()
        {
            return accesos.Count;
        }

        /// <summary>
        /// Propiedad que retorna la lista de accesos asociados a la familia.
        /// </summary>
        public List<Acceso> Accesos
        {
            get
            {
                return accesos;
            }
        }

        /// <summary>
        /// Retorna una representación en cadena de la familia, utilizando su nombre.
        /// </summary>
        /// <returns>Nombre de la familia.</returns>
        public override string ToString()
        {
            return Nombre;
        }
    }
}
