using DOMAIN;
using LOGIC;
using LOGIC.Exceptions;
using System.Globalization;
using CsvHelper;
using LOGIC.Exceptions.ProductoExceptions;
using SERVICES.Domain.Composite;
using SERVICES.Facade;
using SERVICES.Facade.Extentions;
using SERVICES.Observer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static DOMAIN.Producto;
using System.IO;

namespace UI
{
    public partial class FmrGestionarProductos : Form, IObserver
    {
        private ProductoLogic productoLogic;
        string nameUICulture = Thread.CurrentThread.CurrentUICulture.Name;
        private Usuario usuarioActual; // Variable para almacenar el usuario actual

        public FmrGestionarProductos(Usuario usuario)
        {
            InitializeComponent();
            productoLogic = ProductoLogic.GetInstance();
            LanguageNotifier.Instance.RegisterObserver(this);
            Update();
            usuarioActual = usuario;
        }

        public new void Update()
        {
            TraducirTextoControles();
        }

        #region Traduccion de Controles
        private void TraducirTextoControles()
        {
            // Actualiza los textos de los labels, botones, etc.
            lblGestionarProductos.Text = StringExtention.Translate("Gestionar Productos");
            lblCodProducto.Text = StringExtention.Translate("Codigo Producto");
            lblProducto.Text = StringExtention.Translate("Producto");
            lblDescripcion.Text = StringExtention.Translate("Descripcion");
            lblPrecioCompra.Text = StringExtention.Translate("Precio Compra");
            lblPrecioVenta.Text = StringExtention.Translate("Precio Venta");
            lblCategoria.Text = StringExtention.Translate("Categoria");
            lblEstado.Text = StringExtention.Translate("Estado");
            lblCodProductoBuscador.Text = StringExtention.Translate("Codigo Producto");

            btnBuscador.Text = StringExtention.Translate("Buscar");
            btnLimpiar.Text = StringExtention.Translate("Limpiar");
            btnGuardar.Text = StringExtention.Translate("Guardar");
            btnImportar.Text = StringExtention.Translate("Importar");
            btnExportar.Text = StringExtention.Translate("Exportar");
            btnLimpiarBuscador.Text = StringExtention.Translate("Limpiar");

            // Actualiza también los textos del ComboBox de Estado
            CargarComboBox();
        }
        #endregion

        private void FmrRegistrarProductos_Load(object sender, EventArgs e)
        {
            VerificarConexion();
            InicializateDataGridView();
            CargarComboBox();
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

        private void InicializateDataGridView()
        {
            try
            {
                DGVProductos.Rows.Clear();
                List<Producto> lista = productoLogic.GetAll();

                foreach (Producto p in lista)
                {
                    DGVProductos.Rows.Add(new object[]
                    { p.IdProducto.ToString(),
                      p.CodProducto,
                      p.Nombre,
                      p.Descripcion,
                      p.Categoria,
                      p.PrecioVenta,
                      p.PrecioCompra,
                      LanguageService.Translate(p.Estado.ToString()) // Traducir el estado al agregar la fila
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar el DataGridView: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarComboBox()
        {
            try
            {
                cmbEstado.DataSource = Enum.GetValues(typeof(EstadoProducto)).Cast<EstadoProducto>().Select(e => new { Value = e, Text = StringExtention.Translate(e.ToString()) }).ToList();
                cmbEstado.DisplayMember = "Text"; // Mostrar el texto traducido (Activo / Suspendido)
                cmbEstado.ValueMember = "Value"; // Usar el valor del enum
                cmbEstado.SelectedValue = EstadoProducto.Activo; // Asumiendo que "Activo" es un miembro de tu enum EstadoProducto.
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el ComboBox de estado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            txtIdProducto.Text = "";
            txtCodProducto.Text = "";
            txtCodigo.Text = "";
            txtProducto.Text = "";
            txtDescripcion.Text = "";
            txtCategoria.Text = "";
            txtPrecioVenta.Text = "";
            txtPrecioCompra.Text = "";
        }

        private void DGVProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Verificar que se haya hecho clic en una fila válida
                {
                    DataGridViewRow filaSeleccionada = DGVProductos.Rows[e.RowIndex];

                    txtIdProducto.Text = filaSeleccionada.Cells["id"].Value?.ToString();
                    txtCodProducto.Text = filaSeleccionada.Cells["Codigo"].Value?.ToString();
                    txtProducto.Text = filaSeleccionada.Cells["Nombre"].Value?.ToString();
                    txtDescripcion.Text = filaSeleccionada.Cells["Descripcion"].Value?.ToString();
                    txtCategoria.Text = filaSeleccionada.Cells["Categoria"].Value?.ToString();
                    txtPrecioVenta.Text = filaSeleccionada.Cells["PrecioVenta"].Value?.ToString();
                    txtPrecioCompra.Text = filaSeleccionada.Cells["PrecioCompra"].Value?.ToString();
                    cmbEstado.Text = filaSeleccionada.Cells["Estado"].Value?.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!VerificarConexion())
                    return;
                if (string.IsNullOrWhiteSpace(txtCodProducto.Text) || string.IsNullOrWhiteSpace(txtCategoria.Text) ||
                    string.IsNullOrWhiteSpace(txtProducto.Text) || string.IsNullOrWhiteSpace(txtPrecioCompra.Text) ||
                    string.IsNullOrWhiteSpace(txtPrecioVenta.Text))
                {
                    throw new DatosInvalidosException("Por favor, complete todos los campos obligatorios.");
                }

                Producto producto = new Producto()
                {
                    IdProducto = Guid.TryParse(txtIdProducto.Text, out var idProducto) ? idProducto : Guid.Empty,
                    CodProducto = txtCodProducto.Text,
                    Nombre = txtProducto.Text,
                    Descripcion = txtDescripcion.Text,
                    Categoria = txtCategoria.Text,
                    PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text),
                    PrecioCompra = Convert.ToDecimal(txtPrecioCompra.Text),
                    Estado = (EstadoProducto)cmbEstado.SelectedValue,
                };

                if (txtIdProducto.Text == string.Empty)
                {
                    Guid idGenerado = productoLogic.RegistrarProducto(producto);
                    if (idGenerado != Guid.Empty)
                    {
                        DGVProductos.Rows.Add(new object[] {
                    "",
                    idGenerado,
                    producto.CodProducto,
                    producto.Nombre,
                    producto.Descripcion,
                    producto.Categoria,
                    producto.PrecioVenta,
                    producto.PrecioCompra,
                    producto.Estado.ToString()
                });
                    }
                }
                else
                {
                    txtIdProducto.Text = producto.IdProducto.ToString();
                    producto.IdProducto = productoLogic.EditarProducto(producto);
                }
                InicializateDataGridView();
            }
            catch (DatosInvalidosException ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodProducto.Focus();
            }
            catch (FormatException)
            {
                MessageBox.Show("Error en el formato de los precios. Por favor, ingrese un valor numérico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                bool precioCompraInvalido = !decimal.TryParse(txtPrecioCompra.Text, out _);
                bool precioVentaInvalido = !decimal.TryParse(txtPrecioVenta.Text, out _);

                if (precioCompraInvalido && precioVentaInvalido)
                {
                    txtPrecioVenta.Clear();
                    txtPrecioCompra.Clear();
                    txtPrecioCompra.Focus();
                }
                else if (precioCompraInvalido)
                {
                    txtPrecioCompra.Clear();
                    txtPrecioCompra.Focus();
                }
                else if (precioVentaInvalido)
                {
                    txtPrecioVenta.Clear();
                    txtPrecioVenta.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error al guardar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void btnBuscador_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = txtCodigo.Text;

                if (!string.IsNullOrEmpty(codigo))
                {
                    Producto producto = productoLogic.SelectByCodigo(codigo);

                    // Llenar los datos del producto en los controles
                    txtIdProducto.Text = producto.IdProducto.ToString();
                    txtCodProducto.Text = producto.CodProducto.ToString();
                    txtProducto.Text = producto.Nombre;
                    txtDescripcion.Text = producto.Descripcion;
                    txtCategoria.Text = producto.Categoria;
                    txtPrecioCompra.Text = producto.PrecioCompra.ToString();
                    txtPrecioVenta.Text = producto.PrecioVenta.ToString();
                    cmbEstado.SelectedItem = cmbEstado.Items.Cast<dynamic>().FirstOrDefault(i => i.Value.Equals(producto.Estado));
                }
                else
                {
                    MessageBox.Show("El código ingresado no es válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (ProductoNoEncontradoException ex)
            {
                // Mostrar el mensaje de la excepción personalizada
                MessageBox.Show(ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Mostrar solo excepciones no controladas específicamente
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir teclas de control (como Backspace)
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            // Permitir dígitos
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            // Permitir la coma ',' (si no existe ya en el TextBox)
            if (e.KeyChar == ',')
            {
                // Verificar que el TextBox aún no contenga una coma
                if (!txtPrecioCompra.Text.Contains(','))
                {
                    e.Handled = false;
                    return;
                }
            }

            // Si no cumple ninguna de las condiciones anteriores, se bloquea
            e.Handled = true;
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir teclas de control (como Backspace)
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            // Permitir dígitos
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            // Permitir la coma ',' (si no existe ya en el TextBox)
            if (e.KeyChar == ',')
            {
                // Verificar que el TextBox aún no contenga una coma
                if (!txtPrecioVenta.Text.Contains(','))
                {
                    e.Handled = false;
                    return;
                }
            }

            // Bloquear cualquier otro carácter
            e.Handled = true;
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    OpenFileDialog ofd = new OpenFileDialog
            //    {
            //        Filter = "Archivos CSV (*.csv)|*.csv",
            //        Title = "Seleccione el archivo CSV a importar",
            //        InitialDirectory = @"C:\Users\ASUS\OneDrive\Escritorio\ANALISTA DE SISTEMAS\4to año\PRACTICAS PROFESIONALIZANTES 3\Proyecto 2024\OneVision\DAO\Implementations\Excel"
            //    };

            //    if (ofd.ShowDialog() == DialogResult.OK)
            //    {
            //        using (var reader = new StreamReader(ofd.FileName, Encoding.UTF8))
            //        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            //        {
            //            // Si el CSV tiene encabezado, CSVHelper lo leerá automáticamente.
            //            var records = csv.GetRecords<dynamic>().ToList();

            //            foreach (var record in records)
            //            {
            //                // Acceder a las propiedades según los encabezados del CSV.
            //                // Por ejemplo, si los encabezados son "IdProducto", "CodProducto", etc.
            //                DGVProductos.Rows.Add(
            //                    record.IdProducto,
            //                    record.CodProducto,
            //                    record.Nombre,
            //                    record.Descripcion,
            //                    record.Categoria,
            //                    record.PrecioVenta,
            //                    record.PrecioCompra,
            //                    record.Estado
            //                );
            //            }
            //        }

            //        MessageBox.Show("Importación de CSV realizada con éxito.", "Importar CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error al importar el archivo CSV: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }


        /// <summary>
        /// Método auxiliar para determinar si la primera línea es un encabezado.
        /// Puedes ajustar la lógica según tus necesidades.
        /// </summary>
        //private bool EsEncabezado(string primeraLinea)
        //{
        //    // Ejemplo sencillo: si la primera línea contiene alguna palabra clave del encabezado (como "CodProducto" o "Nombre")
        //    return primeraLinea.Contains("CodProducto") || primeraLinea.Contains("Nombre");
        //}
        private void btnExportar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    SaveFileDialog sfd = new SaveFileDialog
            //    {
            //        Filter = "Todos los archivos compatibles (*.csv;*.xlsx)|*.csv;*.xlsx|Archivos CSV (*.csv)|*.csv|Archivos de Excel (*.xlsx)|*.xlsx",
            //        FileName = "Productos_" + DateTime.Now.ToString("yyyyMMdd"),
            //        InitialDirectory = @"C:\Users\ASUS\OneDrive\Escritorio\ANALISTA DE SISTEMAS\4to año\PRACTICAS PROFESIONALIZANTES 3\Proyecto 2024\OneVision\DAO\Implementations\Excel"
            //    };

            //    if (sfd.ShowDialog() == DialogResult.OK)
            //    {
            //        StringBuilder csv = new StringBuilder();
            //        csv.AppendLine("IdProducto,CodProducto,Nombre,Descripcion,Categoria,PrecioVenta,PrecioCompra,Estado");

            //        foreach (DataGridViewRow row in DGVProductos.Rows)
            //        {
            //            if (!row.IsNewRow)
            //            {
            //                List<string> celdas = new List<string>();

            //                foreach (DataGridViewCell cell in row.Cells)
            //                {
            //                    string valor = cell.Value?.ToString() ?? "";
            //                    valor = "\"" + valor.Replace("\"", "\"\"") + "\"";
            //                    celdas.Add(valor);
            //                }

            //                csv.AppendLine(string.Join(";", celdas));
            //            }
            //        }

            //        System.IO.File.WriteAllText(sfd.FileName, csv.ToString(), Encoding.UTF8);
            //        MessageBox.Show("Exportación realizada con éxito.", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error al exportar el listado de productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

    }
}
