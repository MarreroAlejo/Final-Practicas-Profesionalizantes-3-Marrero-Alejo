using DAO.Implementations.SqlServer;
using DOMAIN;
using LOGIC;
using LOGIC.Exceptions.VentasExceptions;
using SERVICES.Domain.Composite;
using SERVICES.Facade.Extentions;
using SERVICES.Logic;
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
    public partial class FmrGestionarVentas : Form, IObserver
    {
        private ClienteLogic clienteLogic;
        private PedidoLogic pedidoLogic;
        private SucursalLogic sucursalLogic;
        private VentaLogic ventaLogic;
        private ProductoLogic productoLogic;
        private Usuario usuarioActual;
        private UserLogic userLogic;
        string nameUICulture = Thread.CurrentThread.CurrentUICulture.Name;


        public FmrGestionarVentas(Usuario usuario)
        {
            userLogic = UserLogic.GetInstance();
            this.usuarioActual = usuario;
            clienteLogic = ClienteLogic.GetInstance();
            pedidoLogic = PedidoLogic.GetInstance();
            sucursalLogic = SucursalLogic.GetInstance();
            ventaLogic = VentaLogic.GetInstance();
            productoLogic = ProductoLogic.GetInstance();
            LanguageNotifier.Instance.RegisterObserver(this);
            InitializeComponent();
            Update();
        }
        private void FmrGestionarVentas_Load(object sender, EventArgs e)
        {
            this.Refresh();
            VerificarConexion();
            CargarEstadoVenta();
            dateTimePickerFechaRegistro.Enabled = false;
            Update();
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

        #region Traduccion de Controles
        private void TraducirTextoControles()
        {
            // Actualiza los textos de los labels, botones, etc.
            label1.Text = StringExtention.Translate("Nro. de Venta");
            label2.Text = StringExtention.Translate("Nro. de Venta");
            lblGestionarVenta.Text = StringExtention.Translate("Gestionar Venta");
            lblIdentificadorPedido.Text = StringExtention.Translate("Identificador de Venta");
            lblEstado.Text = StringExtention.Translate("Estado");
            lblIdentificadorPedido.Text = StringExtention.Translate("Identificador de Pedido");
            lblCliente.Text = StringExtention.Translate("Cliente");
            lblValorFlete.Text = StringExtention.Translate("Valor Flete");
            lblValorTotal.Text = StringExtention.Translate("Valor Total");
            lblFechaRegistro.Text = StringExtention.Translate("Fecha Registro");
            lblDetallePedido.Text = StringExtention.Translate("Detalle Pedido");

            btnBuscarProducto.Text = StringExtention.Translate("Buscar Pedido");
            btnLimpiarCampos.Text = StringExtention.Translate("Limpiar Campos");
            btnRegistrarVenta.Text = StringExtention.Translate("Registrar Venta");
            btnAnularVenta.Text = StringExtention.Translate("Anular Venta");
            btnCalcularTotal.Text = StringExtention.Translate("Calcular");

            groupBox1.Text = StringExtention.Translate("Datos de Venta");
            groupBox2.Text = StringExtention.Translate("Filtro de Búsqueda");
        }
        #endregion
        public new void Update()
        {
            TraducirTextoControles();
        }

        /// <summary>
        /// Registra una nueva venta para un pedido, siempre y cuando el pedido no esté ya asociado a una venta.
        /// Actualiza el estado del pedido a 'Registrado' y limpia la interfaz.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            if (!VerificarConexion())
                return;
            try
            {
                // Validar que todos los campos requeridos estén llenos
                if (string.IsNullOrEmpty(txtIdPedido.Text) || string.IsNullOrEmpty(txtValorFlete.Text) || string.IsNullOrEmpty(txtValorTotal.Text))
                {
                    throw new RegistroVentaException("Todos los campos son obligatorios.");
                }

                // Convertir y obtener el ID del pedido
                int nroPedido = Convert.ToInt32(txtNroPedido.Text);
                Pedido pedido = pedidoLogic.GetPedidoByNro(nroPedido);

                // Verificar si ya existe una venta asociada a este pedido
                if (ventaLogic.VentaAsociadaAPedido(pedido.IdPedido))
                {
                    throw new LOGIC.Exceptions.VentaExceptions.VentaYaExistenteException();
                }

                if (!decimal.TryParse(txtValorFlete.Text, out decimal valorFlete))
                {
                    throw new FormatException("El valor del flete debe ser un número válido.");
                }
                if (!decimal.TryParse(txtValorTotal.Text, out decimal total))
                {
                    throw new FormatException("El total del pedido debe ser un número válido.");
                }

                // Preguntar al usuario si desea registrar la venta
                DialogResult result = MessageBox.Show("¿Está seguro de que desea registrar la venta?",
                                                      "Confirmar Registro",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Crear el objeto Venta
                    Venta venta = new Venta
                    {
                        IdVenta = Guid.NewGuid(),
                        IdPedido = pedido.IdPedido,
                        ValorFlete = valorFlete,
                        Total = total,
                        Estado = Venta.EstadoVenta.Generada,
                        FechaRegistro = DateTime.Now
                    };

                    // Registrar la venta en la base de datos
                    ventaLogic.RegistrarVenta(venta);

                    // Actualizar el estado del pedido utilizando el nroPedido obtenido correctamente
                    pedidoLogic.ActualizarEstadoPedido(pedido.NroPedido, Pedido.EstadoPedido.Entregado);

                    // Actualizar el stock y el stock reservado de acuerdo a los detalles del pedido
                    ventaLogic.ActualizarStockVenta(venta.IdPedido, pedido.IdSucursal);

                    // Limpiar los controles de la interfaz
                    Limpiar();

                    MessageBox.Show("Venta registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (LOGIC.Exceptions.VentaExceptions.VentaYaExistenteException ex)
            {
                MessageBox.Show(ex.Message, "Error de Venta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (RegistroVentaException ex)
            {
                MessageBox.Show($"Error al registrar la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CalcularTotal()
        {
            try
            {
                decimal subtotal = 0;
                decimal flete = 0;

                foreach (DataGridViewRow fila in dgvDetallePedido.Rows)
                {
                    if (fila.Cells["subtotal"].Value != null && decimal.TryParse(fila.Cells["subtotal"].Value.ToString(), out var subTotalValue))
                    {
                        if (subTotalValue < 0)
                        {
                            throw new CalculoTotalException("El subtotal no puede ser negativo.");
                        }
                        subtotal += subTotalValue;
                    }
                }

                if (!string.IsNullOrEmpty(txtValorFlete.Text) && decimal.TryParse(txtValorFlete.Text, out var fleteValue))
                {
                    if (fleteValue < 0)
                    {
                        throw new CalculoTotalException("El valor del flete no puede ser negativo.");
                    }
                    flete = fleteValue;
                }
                else
                {
                    MessageBox.Show("El valor del flete no es válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                txtValorTotal.Text = (subtotal + flete).ToString();
            }
            catch (CalculoTotalException ex)
            {
                MessageBox.Show($"Error en el cálculo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            if (!VerificarConexion())
                return;
            using (var modal = new mdPedidosRegistrados(usuarioActual))
            {
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    var pedido = modal._Pedido;
                    if (pedido == null) return;

                    // Cargar datos del pedido en los controles
                    txtIdPedido.Text = pedido.IdPedido.ToString();
                    cmbEstadoVenta.Text = pedido.Estado.ToString();
                    txtNroPedido.Text = pedido.NroPedido.ToString();

                    // Obtener información del cliente
                    var cliente = clienteLogic.GetById(pedido.IdCliente);
                    if (cliente == null)
                    {
                        MessageBox.Show("No se encontró al cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    txtCliente.Text = $"{cliente.Nombre} {cliente.Apellido}";
                    txtIdCliente.Text = cliente.IdCliente.ToString();

                    // Obtener y mostrar detalles del pedido
                    var detalles = pedidoLogic.ObtenerDetallePedido(pedido.IdPedido);
                    dgvDetallePedido.Rows.Clear();
                    foreach (var detalle in detalles)
                    {
                        Producto producto = productoLogic.GetByGuid(detalle.IdProducto);
                        dgvDetallePedido.Rows.Add(detalle.IdProducto, producto.CodProducto, producto.Nombre, producto.PrecioVenta, detalle.Cantidad, detalle.SubTotal);
                    }
                }
                else
                {
                    txtIdPedido.Select();
                }
            }
        }


        private void btnCalcularTotal_Click(object sender, EventArgs e)
        {
            CalcularTotal();
        }


        private void CargarEstadoVenta()
        {
            cmbEstadoVenta.DataSource = Enum.GetValues(typeof(Venta.EstadoVenta))
                                        .Cast<Venta.EstadoVenta>()
                                        .Select(e => new { Value = (int)e, Name = e.ToString() })
                                        .ToList();
            cmbEstadoVenta.ValueMember = "Value";
            cmbEstadoVenta.DisplayMember = "Name";
        }

        private void btnBuscarVenta_Click(object sender, EventArgs e)
        {
            if (!VerificarConexion())
                return;
            using (var modal = new mdVenta())
            {
                if (modal.ShowDialog() == DialogResult.OK)
                {

                    cmbEstadoVenta.Enabled = false;
                    txtIdPedido.Enabled = false;
                    txtCliente.Enabled = false;
                    txtValorFlete.Enabled = false;
                    txtValorTotal.Enabled = false;
                    btnRegistrarVenta.Enabled = false;
                    btnCalcularTotal.Enabled = false;

                    var venta = modal._Venta;
                    if (venta == null) return;
                    txtIdVentaBuscador.Text = venta.IdVenta.ToString();
                    txtNroVenta.Text = venta.NroVenta.ToString();
                    cmbEstadoVenta.Text = venta.Estado.ToString();
                    txtIdPedido.Text = venta.IdPedido.ToString();
                    Pedido pedido1 = pedidoLogic.GetByGuid(venta.IdPedido);
                    txtNroPedido.Text = pedido1.NroPedido.ToString();
                    txtValorFlete.Text = venta.ValorFlete.ToString();
                    txtValorTotal.Text = venta.Total.ToString();
                    dateTimePickerFechaRegistro.Text = venta.FechaRegistro.ToString();

                    var pedido = pedidoLogic.GetByGuid(venta.IdPedido);
                    if (pedido == null)
                    {
                        MessageBox.Show("No se encontró al cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var cliente = clienteLogic.GetById(pedido.IdCliente);
                    if (cliente == null)
                    {
                        MessageBox.Show("No se encontró al cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    txtCliente.Text = $"{cliente.Nombre} {cliente.Apellido}";
                    txtIdCliente.Text = cliente.IdCliente.ToString();

                    // Obtener y mostrar detalles del pedido
                    var detalles = pedidoLogic.ObtenerDetallePedido(pedido.IdPedido);
                    dgvDetallePedido.Rows.Clear();

                    foreach (var detalle in detalles)
                    {
                        Producto producto = productoLogic.GetByGuid(detalle.IdProducto);

                        dgvDetallePedido.Rows.Add(detalle.IdProducto, producto.CodProducto, producto.Nombre, producto.PrecioVenta, detalle.Cantidad, detalle.SubTotal);
                    }

                    CalcularTotal();
                }
                else
                {
                    txtIdVentaBuscador.Select();
                }
            }
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            cmbEstadoVenta.Enabled = true;
            txtIdPedido.Enabled = true;
            txtNroVenta.Enabled = true;
            txtNroPedido.Enabled = true;
            txtCliente.Enabled = true;
            txtValorFlete.Enabled = true;
            txtValorTotal.Enabled = true;
            btnRegistrarVenta.Enabled = true;
            btnCalcularTotal.Enabled = true;
            CargarEstadoVenta();
            txtIdVentaBuscador.Text = "";
            txtIdPedido.Text = "";
            txtNroPedido.Text = "";
            txtNroVenta.Text = "";
            txtCliente.Text = "";
            txtIdCliente.Text = "";
            txtValorFlete.Text = "";
            txtValorTotal.Text = "";
            dgvDetallePedido.Rows.Clear();
        }

        private void btnAnularVenta_Click(object sender, EventArgs e)
        {
            if (!VerificarConexion())
                return;
            if (Guid.TryParse(txtIdVentaBuscador.Text, out Guid idVenta))
            {
                Guid idPedido = Guid.Parse(txtIdPedido.Text);
                Pedido pedido = pedidoLogic.GetByGuid(idPedido);
                var estadoSeleccionado = (Venta.EstadoVenta)cmbEstadoVenta.SelectedValue;

                // Verificar si el pedido está en estado Registrado antes de suspender la venta
                if (pedido.Estado == Pedido.EstadoPedido.Registrado)
                {
                    // Preguntar al usuario si desea suspender la venta
                    DialogResult result = MessageBox.Show("¿Está seguro de que desea suspender la venta?",
                                                          "Confirmar Suspensión",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            // Primero suspender el pedido
                            pedidoLogic.SuspenderPedido(pedido.NroPedido);
                            MessageBox.Show("Pedido N° " +pedido.NroPedido + " Anulado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Luego suspender la venta
                            ventaLogic.SuspenderVenta(idVenta);
                            Venta venta = ventaLogic.GetByGuid(idVenta);
                            MessageBox.Show("Venta N° " + venta.NroVenta + "Anulada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al suspender la venta o el pedido: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"No se puede suspender la venta porque el pedido está en estado '{pedido.Estado}'.",
                                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("ID de la venta o pedido no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
