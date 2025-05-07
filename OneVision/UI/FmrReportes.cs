using ClosedXML.Excel;
using DOMAIN;
using LOGIC;
using LOGIC.Exceptions.ReportesExceptions;
using SERVICES.Domain.Composite;
using SERVICES.Facade.Extentions;
using SERVICES.Observer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FmrReportes : Form, IObserver
    {
        ReporteLogic reporteLogic;
        string nameUICulture = Thread.CurrentThread.CurrentUICulture.Name;
        private Usuario usuarioActual;

        public FmrReportes(Usuario usuario)
        {
            this.usuarioActual = usuario;
            InitializeComponent();
            reporteLogic = ReporteLogic.GetInstance();
            LanguageNotifier.Instance.RegisterObserver(this);
            Update();
        }

        private void FmrReporteVentas_Load(object sender, EventArgs e)
        {
            try
            {
                VerificarConexion();
                this.Refresh();
                cmbBusqueda.Items.Clear();
                foreach (DataGridViewColumn columna in DgvReporteVentas.Columns)
                {
                    if (columna.Visible)
                    {
                        cmbBusqueda.Items.Add(columna.Name);
                    }
                }
                Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool VerificarConexion()
        {
            ConnectionManager.Instance.UpdateConnectionStatus();
            if (!ConnectionManager.Instance.IsConnected)
            {
                MessageBox.Show("La conexión a la base de datos se perdió. " +
                                "Por favor, verifica la configuración.",
                                "Error de Conexión",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                Application.Exit();
                return false;
            }
            return true;
        }

        public new void Update()
        {
            try
            {
                TraducirTextoControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar los textos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Traduccion de Controles
        private void TraducirTextoControles()
        {
            lblReporteVentas.Text = StringExtention.Translate("Reporte de Pedidos");
            lblDesde.Text = StringExtention.Translate("Desde");
            lblHasta.Text = StringExtention.Translate("Hasta");
            lblFiltroBusqueda.Text = StringExtention.Translate("Filtro de búsqueda");

            btnBuscarVentasPedidos.Text = StringExtention.Translate("Buscar");
            btnBuscar.Text = StringExtention.Translate("Buscar");
            btnLimpiar.Text = StringExtention.Translate("Limpiar");
            btnExportarExcel.Text = StringExtention.Translate("Exportar");
        }
        #endregion

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string columnaFiltro = cmbBusqueda.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(columnaFiltro))
                {
                    throw new FiltrarDatosException("Debe seleccionar una columna para filtrar.");
                }

                if (DgvReporteVentas.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in DgvReporteVentas.Rows)
                    {
                        if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBusqueda.Text.Trim().ToUpper()))
                        {
                            row.Visible = true;
                        }
                        else
                        {
                            row.Visible = false;
                        }
                    }
                }
            }
            catch (FiltrarDatosException ex)
            {
                MessageBox.Show(ex.Message, "Filtro inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Busca y muestra en el DataGridView las ventas registradas en el rango de fechas especificado.
        /// La fecha de fin se extiende hasta el último milisegundo del día seleccionado para incluir todas las ventas del día.
        /// </summary>
        private void btnBuscarVentasPedidos_Click(object sender, EventArgs e)
        {
            try
            {
                if (!VerificarConexion())
                    return;
                // Establece la fecha de inicio a las 12:00 AM del día seleccionado
                var fechaInicio = dateTimePickerDesde.Value.Date;
                // Establece la fecha de fin al último milisegundo del día seleccionado
                var fechaFin = dateTimePickerHasta.Value.Date.AddDays(1).AddMilliseconds(-1);

                // Validar que la fecha de inicio no sea mayor que la fecha de fin
                if (fechaInicio > fechaFin)
                {
                    throw new BuscarVentasException("La fecha de inicio no puede ser mayor que la fecha de fin.");
                }

                // Obtener el reporte de ventas dentro del rango especificado
                List<Reporte_Pedido> lista = reporteLogic.ReportePedido(fechaInicio, fechaFin);
                DgvReporteVentas.Rows.Clear();

                foreach (Reporte_Pedido rv in lista)
                {
                    DgvReporteVentas.Rows.Add(new object[]
                    {
                rv.FechaRegistro,
                rv.IdPedido,
                rv.Cliente,
                rv.ValorTotal,
                rv.CodigoProducto,
                rv.Producto,
                rv.Categoria,
                rv.Precio,
                rv.Cantidad,
                rv.Subtotal
                    });
                }

                if (lista.Count == 0)
                {
                    MessageBox.Show("No se encontraron ventas en el rango de fechas especificado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (BuscarVentasException ex)
            {
                MessageBox.Show(ex.Message, "Búsqueda inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al buscar las ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Reporte de Ventas");

                    for (int col = 0; col < DgvReporteVentas.Columns.Count; col++)
                    {
                        worksheet.Cell(1, col + 1).Value = DgvReporteVentas.Columns[col].HeaderText;
                    }

                    for (int row = 0; row < DgvReporteVentas.Rows.Count; row++)
                    {
                        for (int col = 0; col < DgvReporteVentas.Columns.Count; col++)
                        {
                            if (DgvReporteVentas.Rows[row].Visible)
                            {
                                worksheet.Cell(row + 2, col + 1).Value = DgvReporteVentas.Rows[row].Cells[col].Value?.ToString() ?? string.Empty;
                            }
                        }
                    }

                    string fechaHoy = DateTime.Now.ToString("yyyyMMdd");
                    string fileName = $"ReporteVentas_{fechaHoy}.xlsx";

                    using (SaveFileDialog sfd = new SaveFileDialog()
                    {
                        Filter = "Excel Workbook|*.xlsx",
                        Title = "Guardar Reporte de Ventas",
                        FileName = fileName
                    })
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            workbook.SaveAs(sfd.FileName);
                            MessageBox.Show("Reporte exportado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (ExportarExcelException ex)
            {
                MessageBox.Show(ex.Message, "Error de exportación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al exportar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

