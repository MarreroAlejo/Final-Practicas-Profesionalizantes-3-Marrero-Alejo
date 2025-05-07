using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN
{
    /// <summary>
    /// Representa una sucursal de la empresa.
    /// </summary>
    public class Sucursal
    {
        public Guid IdSucursal { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public EstadoSucursal Estado { get ; set; }

        /// <summary>
        /// Define los estados posibles para una sucursal.
        /// </summary>
        public enum EstadoSucursal
        {
            Suspendida = 0,
            Activa = 1
        }

        public override string ToString()
        {
            return Nombre; // Mostrar el nombre de la sucursal en el ComboBox
        }
    }
}
