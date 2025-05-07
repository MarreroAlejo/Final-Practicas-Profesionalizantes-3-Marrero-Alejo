using DOMAIN;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Contracts;
using System.Configuration;

namespace DAO.Implementations.SqlServer
{
    /// <summary>
    /// Proporciona métodos para generar reportes de pedidos desde la base de datos.
    /// </summary>
    public class ReporteDao
    {
        private readonly string connectionString;

        /// <summary>
        /// Constructor que inicializa la cadena de conexión a partir del archivo de configuración.
        /// </summary>
        public ReporteDao()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MainConString"].ConnectionString;
        }

        /// <summary>
        /// Genera un reporte de pedidos entre dos fechas.
        /// </summary>
        /// <param name="fechaInicio">Fecha de inicio del reporte.</param>
        /// <param name="fechaFin">Fecha de fin del reporte.</param>
        /// <returns>Lista de objetos Reporte_Pedido con la información del reporte.</returns>
        public List<Reporte_Pedido> ReportePedido(DateTime fechaInicio, DateTime fechaFin)
        {
            List<Reporte_Pedido> lista = new List<Reporte_Pedido>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ReportePedido", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Pasamos los parámetros como DateTime directamente
                    cmd.Parameters.AddWithValue("@fechainicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@fechafin", fechaFin);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Reporte_Pedido
                            {
                                FechaRegistro = reader["FechaPedido"].ToString(),
                                IdPedido = reader["IdPedido"].ToString(),
                                IdCliente = reader["IdCliente"].ToString(),
                                Cliente = reader["NombreCliente"].ToString(),
                                ValorTotal = reader["ValorTotalPedido"].ToString(),
                                IdProducto = reader["IdProducto"].ToString(),
                                CodigoProducto = reader["CodigoProducto"].ToString(),
                                Producto = reader["NombreProducto"].ToString(),
                                Categoria = reader["CategoriaProducto"].ToString(),
                                Precio = reader["PrecioProducto"].ToString(),
                                Cantidad = reader["CantidadProducto"].ToString(),
                                Subtotal = reader["SubtotalProducto"].ToString()
                            });
                        }
                    }
                }
            }

            return lista;
        }
    }
}
