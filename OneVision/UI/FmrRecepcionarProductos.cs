using DocumentFormat.OpenXml.Wordprocessing;
using DOMAIN;
using LOGIC;
using LOGIC.Exceptions.ProductoExceptions;
using LOGIC.Exceptions.SucursalExceptions;
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
using UI.Modales;

namespace UI
{
    public partial class FmrRecepcionarProductos : Form, IObserver
    {
        private ProductoLogic productoLogic;
        private InventarioLogic inventarioLogic;
        private SucursalLogic sucursalLogic;
        string nameUICulture = Thread.CurrentThread.CurrentUICulture.Name;
        private Usuario usuarioActual; // Variable para almacenar el usuario actual


        public FmrRecepcionarProductos(Usuario usuario)
        {
            InitializeComponent();
            productoLogic = ProductoLogic.GetInstance();
            inventarioLogic = InventarioLogic.GetInstance();
            sucursalLogic = SucursalLogic.GetInstance();
            LanguageNotifier.Instance.RegisterObserver(this);
            Update();
            this.usuarioActual = usuario;
        }

        public new void Update()
        {
            TraducirTextoControles();
        }


        #region Traduccion de Controles
        private void TraducirTextoControles()
        {
            // Actualiza los textos de los labels, botones, etc.
            lblRecepcionDeProductos.Text = StringExtention.Translate("Recepción de Productos");
            lblCodigoProducto.Text = StringExtention.Translate("Codigo Producto");
            lblProducto.Text = StringExtention.Translate("Producto");
            lblPrecioCompra.Text = StringExtention.Translate("Precio Compra");
            lblPrecioVenta.Text = StringExtention.Translate("Precio Venta");
            lblCantidad.Text = StringExtention.Translate("Cantidad");
            lblSucursal.Text = StringExtention.Translate("Sucursal");

            btnBuscarProducto.Text = StringExtention.Translate("Buscar");
            btnAgregar.Text = StringExtention.Translate("Agregar");
            btnLimpiar.Text = StringExtention.Translate("Limpiar");
            btnEliminar.Text = StringExtention.Translate("Eliminar");
            btnRegistrar.Text = StringExtention.Translate("Registrar");
        }
        #endregion


        private void FmrRecepcionarProductos_Load(object sender, EventArgs e)
        {
            CargarSucursales();
            VerificarConexion();
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

        private void CargarSucursales()
        {
            try
            {
                List<Sucursal> sucursales = sucursalLogic.GetAll();
                cmbSucursal.Items.Clear();
                foreach (var sucursal in sucursales)
                {
                    cmbSucursal.Items.Add(sucursal);
                }
                if (cmbSucursal.Items.Count > 0)
                {
                    cmbSucursal.SelectedIndex = 0; // Seleccionar el primer elemento
                }
            }
            catch (Exception ex)
            {
                throw new SucursalCargaException("Error al cargar las sucursales: " + ex.Message);
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            if (!VerificarConexion())
                return;
            using (var modal = new mdProducto())
            {
                var result = modal.ShowDialog(); //hacemos que se muestre el formulario y cualquier accion que hagamos se guarde en la variable result
                if (result == DialogResult.OK)
                {
                    txtIdProducto.Text = modal._Producto.IdProducto.ToString();
                    txtCodigoProducto.Text = modal._Producto.CodProducto;
                    txtProducto.Text = modal._Producto.Nombre;
                    txtPrecioCompra.Text = modal._Producto.PrecioCompra.ToString();
                    txtPrecioVenta.Text = modal._Producto.PrecioVenta.ToString();
                    numericCantidad.Select();
                }
                else
                {
                    txtCodigoProducto.Select();
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            dgvRecepcionar.Rows.Clear();
        }

        private void Limpiar()
        {
            txtCodigoProducto.Text = "";
            txtIdProducto.Text = "";
            txtProducto.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            numericCantidad.Value = 1;
            btnEliminar.Text = "Eliminar";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIdProducto.Text) || Guid.Parse(txtIdProducto.Text) == Guid.Empty)
                {
                    throw new ProductoNoSeleccionadoException();
                }

                if (!decimal.TryParse(txtPrecioCompra.Text, out decimal precioCompra))
                {
                    throw new PrecioFormatoIncorrectoException("Precio Compra");
                }

                if (!decimal.TryParse(txtPrecioVenta.Text, out decimal precioVenta))
                {
                    throw new PrecioFormatoIncorrectoException("Precio Venta");
                }

                bool productoExiste = false;
                foreach (DataGridViewRow fila in dgvRecepcionar.Rows)
                {
                    if (fila.Cells["id"].Value != null && fila.Cells["id"].Value.ToString() == txtIdProducto.Text)
                    {
                        int cantidadExistente = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                        int cantidadNueva = Convert.ToInt32(numericCantidad.Value);
                        fila.Cells["Cantidad"].Value = cantidadExistente + cantidadNueva;
                        decimal precioCompraExistente = Convert.ToDecimal(fila.Cells["precioCompra"].Value);
                        decimal precioVentaExistente = Convert.ToDecimal(fila.Cells["precioVenta"].Value);

                        if (precioCompraExistente != precioCompra)
                        {
                            fila.Cells["precioCompra"].Value = precioCompra;
                        }
                        if (precioVentaExistente != precioVenta)
                        {
                            fila.Cells["precioVenta"].Value = precioVenta;
                        }

                        productoExiste = true;
                        break;
                    }
                }

                if (!productoExiste)
                {
                    Producto producto = productoLogic.GetByGuid(Guid.Parse(txtIdProducto.Text));
                    dgvRecepcionar.Rows.Add(new object[]
                    {
                        txtIdProducto.Text,
                        txtCodigoProducto.Text,
                        txtProducto.Text,
                        producto.Descripcion,
                        producto.Categoria,
                        txtPrecioCompra.Text,
                        txtPrecioVenta.Text,
                        numericCantidad.Value.ToString(),
                        DateTime.Now,
                    });
                }

                Limpiar();
                txtProducto.Select();
            }
            catch (ProductoNoSeleccionadoException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (PrecioFormatoIncorrectoException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!VerificarConexion())
                    return;
                // Verificar si el DataGridView está vacío o solo tiene la fila "nueva"
                if (dgvRecepcionar.Rows.Count == 0 ||
                   (dgvRecepcionar.Rows.Count == 1 && dgvRecepcionar.Rows[0].IsNewRow))
                {
                    throw new SinProductosException("No hay productos para registrar en el inventario.");
                }

                // Preguntar al usuario si desea registrar los productos
                DialogResult result = MessageBox.Show("¿Está seguro de que desea registrar los productos en el inventario?",
                                                      "Confirmar Registro",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Obtener la sucursal seleccionada en el ComboBox y su Guid
                    Sucursal sucursalSeleccionada = (Sucursal)cmbSucursal.SelectedItem;
                    Guid idSucursal = sucursalSeleccionada.IdSucursal;

                    // Recorrer las filas del DataGridView
                    foreach (DataGridViewRow row in dgvRecepcionar.Rows)
                    {
                        // Omitir la fila 'nueva' si existe
                        if (row.IsNewRow) continue;

                        if (row.Cells["id"].Value != null)
                        {
                            Guid idProducto = Guid.Parse(row.Cells["id"].Value.ToString());
                            int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);

                            // Llama al procedimiento almacenado para agregar o actualizar el inventario
                            inventarioLogic.RegistrarProductoEnInventario(idSucursal, idProducto, cantidad);
                        }
                    }

                    MessageBox.Show("Productos registrados en el inventario exitosamente.",
                                    "Registro Exitoso",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            catch (SinProductosException ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar productos en el inventario: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void dgvRecepcionar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow filaSeleccionada = dgvRecepcionar.Rows[e.RowIndex];

                // Asignar los valores de las celdas a los controles correspondientes
                txtIdProducto.Text = filaSeleccionada.Cells["id"].Value?.ToString();
                txtCodigoProducto.Text = filaSeleccionada.Cells["Codigo"].Value?.ToString();
                txtProducto.Text = filaSeleccionada.Cells["Nombre"].Value?.ToString();
                txtPrecioCompra.Text = filaSeleccionada.Cells["PrecioCompra"].Value?.ToString();
                txtPrecioVenta.Text = filaSeleccionada.Cells["PrecioVenta"].Value?.ToString();
                numericCantidad.Text = filaSeleccionada.Cells["Cantidad"].Value?.ToString();
                btnEliminar.Text = "Eliminar  " + filaSeleccionada.Cells["Codigo"].Value?.ToString();

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada por índice
            if (dgvRecepcionar.CurrentRow != null && dgvRecepcionar.CurrentRow.Index >= 0)
            {
                DialogResult confirmacion = MessageBox.Show(
                    "¿Está seguro de que desea eliminar este producto?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion == DialogResult.Yes)
                {
                    // Obtener la fila actual y eliminarla
                    int filaSeleccionada = dgvRecepcionar.CurrentRow.Index;
                    dgvRecepcionar.Rows.RemoveAt(filaSeleccionada);

                    // Limpiar los controles después de eliminar
                    txtIdProducto.Clear();
                    txtCodigoProducto.Clear();
                    txtProducto.Clear();
                    txtPrecioCompra.Clear();
                    txtPrecioVenta.Clear();
                    numericCantidad.Value = 0;
                    btnEliminar.Text = "Eliminar";
                }
            }
            else
            {
                MessageBox.Show(
                    "Por favor, seleccione una fila para eliminar.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir teclas de control (Backspace, Supr, etc.)
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Permitir dígitos
            if (char.IsDigit(e.KeyChar))
            {
                return;
            }

            // Permitir la coma, verificando que no exista ya otra coma
            TextBox textBox = sender as TextBox;
            if (e.KeyChar == ',' && textBox != null && !textBox.Text.Contains(','))
            {
                return;
            }

            // Si no cumple ninguna de las condiciones anteriores, bloquear
            e.Handled = true;
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Se puede repetir el mismo código o llamar a una función común
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            if (char.IsDigit(e.KeyChar))
            {
                return;
            }

            TextBox textBox = sender as TextBox;
            if (e.KeyChar == ',' && textBox != null && !textBox.Text.Contains(','))
            {
                return;
            }

            e.Handled = true;
        }

    }
}