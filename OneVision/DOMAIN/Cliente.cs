using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN
{

    /// <summary>
    /// Representa un cliente en el sistema.
    /// </summary>
    
    public class Cliente
    {
        public int IdCliente { get; set; }
        public int NroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public int CodPostal { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public string Barrio { get; set; }
        public string Provincia { get; set; }
        public DateTime FechaRegistro { get; set; }
        public EstadoCliente Estado { get; set; }

        /// <summary>
        /// Define los estados posibles de un cliente.
        /// </summary>


        public enum EstadoCliente
        {
            Suspendido=0,
            Activo=1
        }
    }
}
