using DAO.Implementations.SqlServer;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC
{
    /// <summary>
    /// Encapsula la lógica de negocio para la generación de reportes.
    /// </summary>
    public class ReporteLogic
    {
        #region Singleton
        private static ReporteLogic instance = new ReporteLogic();
        private static object instanceLock = new object();

        /// <summary>
        /// Constructor privado para la implementación del patrón singleton.
        /// </summary>
        private ReporteLogic() { }

        /// <summary>
        /// Obtiene la instancia única de ReporteLogic.
        /// </summary>
        /// <returns>Instancia de ReporteLogic.</returns>
        public static ReporteLogic GetInstance()
        {
            if (instance is null)
            {
                lock (instanceLock)
                {
                    if (instance is null)
                    {
                        instance = new ReporteLogic();
                    }
                }
            }
            return instance;
        }

        /// <summary>
        /// Propiedad para obtener la instancia única de ReporteLogic.
        /// </summary>
        public static ReporteLogic Instance
        {
            get
            {
                if (instance is null)
                    instance = new ReporteLogic();

                return instance;
            }
        }
        #endregion

        /// <summary>
        /// Instancia de ReporteDao utilizada para generar reportes.
        /// </summary>
        private ReporteDao reporteDao = new ReporteDao();

        /// <summary>
        /// Genera un reporte de pedidos en un rango de fechas.
        /// </summary>
        /// <param name="fechainicio">Fecha de inicio del reporte.</param>
        /// <param name="fechafin">Fecha de fin del reporte.</param>
        /// <returns>Lista de objetos Reporte_Pedido con los datos del reporte.</returns>
        public List<Reporte_Pedido> ReportePedido(DateTime fechainicio, DateTime fechafin)
        {
            return reporteDao.ReportePedido(fechainicio, fechafin);
        }
    }
}
