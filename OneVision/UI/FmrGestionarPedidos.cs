using DAO.Implementations.SqlServer;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Vml.Office;
using DOMAIN;
using LOGIC;
using LOGIC.Exceptions.ClienteExceptions;
using LOGIC.Exceptions.PedidoExceptions;
using LOGIC.Exceptions.ProductoExceptions;
using SERVICES.Dao.Implementations.SqlServer;
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
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Modales;
using static DOMAIN.Pedido;

namespace UI
{
    public partial class FmrGestionarPedidos : Form, IObserver
    {
        private ClienteLogic clienteLogic;
        private PedidoLogic pedidoLogic;
        private SucursalLogic sucursalLogic;
        private InventarioLogic inventarioLogic;
        private ProductoLogic productoLogic;
        private Usuario usuarioActual;
        private UserLogic userLogic;
        private EmpleadoLogic empleadoLogic;
        string nameUICulture = Thread.CurrentThread.CurrentUICulture.Name;



        public FmrGestionarPedidos(Usuario usuario)
        {
            userLogic = UserLogic.GetInstance();
            this.usuarioActual = usuario;
            clienteLogic = ClienteLogic.GetInstance();
            pedidoLogic = PedidoLogic.GetInstance();
            sucursalLogic = SucursalLogic.GetInstance();
            inventarioLogic = InventarioLogic.GetInstance();
            productoLogic = ProductoLogic.GetInstance();
            empleadoLogic = EmpleadoLogic.GetInstance();
            InitializeComponent();
            LanguageNotifier.Instance.RegisterObserver(this);
            Update();
        }

        public new void Update()
        {
            TraducirTextoControles();
        }
        #region Traduccion de Controles
        private void TraducirTextoControles()
        {
            // Actualiza los textos de los labels, botones, etc.
            lblGestionarPedidos.Text = StringExtention.Translate("Gestionar Pedidos");
            lblGUIDPedido.Text = StringExtention.Translate("Nro. Pedido");
            lblFechaRegistro.Text = StringExtention.Translate("Fecha Registro");
            lblEstado.Text = StringExtention.Translate("Estado");

            lblNroDocumento.Text = StringExtention.Translate("Nro.Documento");
            lblNombreApellido.Text = StringExtention.Translate("Nombre y Apellido");
            lblCodProducto.Text = StringExtention.Translate("Codigo Producto");
            lblProducto.Text = StringExtention.Translate("Producto");
            lblPrecio.Text = StringExtention.Translate("Precio");
            lblCantidad.Text = StringExtention.Translate("Cantidad");
            lblSucursal.Text = StringExtention.Translate("Sucursal");
            lblStock.Text = StringExtention.Translate("Stock");
            lblSinReservar.Text = StringExtention.Translate("Sin Reservar");
            lblDetallePedido.Text = StringExtention.Translate("Detalle Pedido");

            groupBoxPedidos.Text = StringExtention.Translate("Buscar Pedido");
            groupBoxClientes.Text = StringExtention.Translate("Datos del Cliente");
            groupBoxProductos.Text = StringExtention.Translate("Datos del Producto");


            btnActualizarEstado.Text = StringExtention.Translate("Actualizar");
            btnConsultarStock.Text = StringExtention.Translate("Consultar");
            btnRegistraPedido.Text = StringExtention.Translate("Registrar Pedido");
            btnSuspender.Text = StringExtention.Translate("Suspender Pedido");
            btnLimpiar.Text = StringExtention.Translate("Limpiar");
            this.Text = StringExtention.Translate("Gestión de Clientes");
        }
        #endregion

        private void FmrGenerarPedidos_Load(object sender, EventArgs e)
        {
            VerificarConexion();
            CargarSucursales();
            CargarEstadoPedido();
            cmbPedido.DataSource = Enum.GetValues(typeof(Pedido.EstadoPedido));
            lblUsuarioActual.Text = Convert.ToString(usuarioActual.IdUsuario);
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

        /// <summary>
        /// Agrega un producto al detalle del pedido, actualizando la cantidad si ya existe.
        /// Lanza una excepción si la cantidad a agregar supera el stock disponible.
        /// </summary>

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que se haya seleccionado un producto
                if (string.IsNullOrWhiteSpace(txtCodProducto.Text) || string.IsNullOrWhiteSpace(txtIdProducto.Text))
                {
                    throw new ProductoNoEncontradoException("No se ha seleccionado un producto válido.");
                }

                // Validar que la cantidad a agregar sea mayor que 0
                if (numericCantidad.Value == 0)
                {
                    MessageBox.Show("La cantidad a agregar debe ser mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Verificar que los textbox de stock y reserva contengan valores enteros válidos
                if (!int.TryParse(txtStock.Text, out int stock) || !int.TryParse(txtReserva.Text, out int reserva))
                {
                    throw new NumeroNoValidoException("Consultar si existe stock disponible.");
                }

                // Intentar parsear el precio
                if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
                    throw new FormatException("El precio tiene un formato inválido.");

                // Obtener el ID del producto y de la sucursal actual
                Guid idProducto = Guid.Parse(txtIdProducto.Text);
                Guid idSucursal = (Guid)cmbSucursal.SelectedValue;

                // Validar que el producto pertenece a la sucursal y obtener el stock disponible
                var (existe, cantidadStock) = inventarioLogic.VerificarProductoEnInventario(idSucursal, idProducto);
                if (existe != 1)
                {
                    throw new ProductoNoEncontradoException("El producto no pertenece a la sucursal seleccionada.");
                }

                // Calcular la disponibilidad actual (por ejemplo, restando la cantidad reservada a la cantidad en stock)
                int disponibilidad = inventarioLogic.CalcularDisponibilidad(idSucursal, idProducto);
                // Actualizar los textbox para reflejar los datos actuales
                txtStock.Text = cantidadStock.ToString();
                txtReserva.Text = disponibilidad.ToString();

                // Volver a validar que la cantidad a agregar no supere el stock disponible
                int cantidadNueva = (int)numericCantidad.Value;
                if (cantidadNueva > disponibilidad)
                {
                    throw new CantidadExcedidaException("La cantidad a agregar excede la disponibilidad actual.");
                }

                decimal subtotal = precio * cantidadNueva;
                int stockDisponible = disponibilidad; // puede ser igual a disponibilidad, según la lógica de negocio

                // Verificar si el producto ya existe en el DataGridView de detalle
                bool productoExiste = false;
                foreach (DataGridViewRow fila in dgvDetallePedido.Rows)
                {
                    if (fila.IsNewRow) continue;

                    if (fila.Cells["id"].Value != null && fila.Cells["id"].Value.ToString() == txtIdProducto.Text)
                    {
                        int cantidadExistente = Convert.ToInt32(fila.Cells["cantidad"].Value);
                        int cantidadFinal = cantidadExistente + cantidadNueva;

                        // Validar que la cantidad final no supere el stock disponible
                        if (cantidadFinal > stockDisponible)
                        {
                            throw new CantidadExcedidaException("La cantidad agregada excede el stock disponible.");
                        }

                        // Actualizar la fila con la nueva cantidad y subtotal
                        fila.Cells["cantidad"].Value = cantidadFinal;
                        fila.Cells["subtotal"].Value = precio * cantidadFinal;
                        productoExiste = true;
                        break;
                    }
                }

                // Si el producto no existe en el detalle, verificar la cantidad antes de agregar
                if (!productoExiste)
                {
                    if (cantidadNueva > stockDisponible)
                    {
                        throw new CantidadExcedidaException("La cantidad a agregar excede el stock disponible.");
                    }

                    Producto producto = productoLogic.GetByGuid(idProducto);
                    dgvDetallePedido.Rows.Add(new object[]
                    {
                txtIdProducto.Text,
                txtCodProducto.Text,
                txtProducto.Text,
                precio,
                cantidadNueva,
                subtotal
                    });
                }

                // Limpiar datos del grupo de producto y recalcular totales
                LimpiarGroupBoxDatosProducto();
                txtCodProducto.Select();
                CalcularTotal();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("El precio o cantidad tiene un formato inválido: " + ex.Message, "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (CantidadExcedidaException ex)
            {
                MessageBox.Show(ex.Message, "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (ProductoNoEncontradoException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NumeroNoValidoException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al agregar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnConsultarStock_Click(object sender, EventArgs e)
        {
            try
            {
                if (!VerificarConexion())
                    return;
                if (string.IsNullOrWhiteSpace(txtCodProducto.Text) || string.IsNullOrWhiteSpace(txtIdProducto.Text))
                {
                    throw new ProductoNoEncontradoException("No se ingresó un código de producto válido.");
                }

                Guid idProducto = Guid.Parse(txtIdProducto.Text);
                Guid idSucursal = (Guid)cmbSucursal.SelectedValue;
                var (existe, cantidad) = inventarioLogic.VerificarProductoEnInventario(idSucursal, idProducto);
                int disponibilidad = inventarioLogic.CalcularDisponibilidad(idSucursal, idProducto);

                if (existe == 1)
                {
                    txtStock.Text = cantidad.ToString();
                    txtReserva.Text = disponibilidad.ToString();

                    // Aquí quiero verificar si el producto ya está en dgvDetallePedido y obtener la cantidad reservada
                    foreach (DataGridViewRow row in dgvDetallePedido.Rows)
                    {
                        if (row.Cells["id"].Value == null &&
                            Guid.Parse(row.Cells["id"].Value.ToString()) != idProducto)
                        {
                            txtReserva.Text = disponibilidad.ToString();

                        }
                        else
                        {
                            int cantidadEnPedido = Convert.ToInt32(row.Cells["cantidad"].Value);
                            int reservaActual = disponibilidad - cantidadEnPedido;
                            txtReserva.Text = reservaActual.ToString();
                            break;
                        }
                    }

                    MessageBox.Show("Producto disponible en el inventario.");
                }
                else
                {
                    throw new ProductoNoEncontradoException("Producto no encontrado en el inventario.");
                }
            }
            catch (ProductoNoEncontradoException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistraPedido_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!VerificarConexion())
                    return;
                Empleado empleado = empleadoLogic.GetEmpleadoPorUsuario(usuarioActual.IdUsuario);
                Guid idEmpleado = empleado.IdEmpleado;

                if (!int.TryParse(txtIdCliente.Text, out int idCliente))
                {
                    throw new FormatException("El ID del cliente debe ser un número entero.");
                }
                if (!decimal.TryParse(txtTotalPedido.Text, out decimal totalPedido))
                {
                    throw new FormatException("El total del pedido debe ser un número válido.");
                }

                // Preguntar al usuario si desea registrar el pedido
                DialogResult result = MessageBox.Show("¿Está seguro de que desea registrar el pedido?",
                                                      "Confirmar Registro",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Guid idPedido = Guid.NewGuid();
                    var pedido = new Pedido
                    {
                        IdPedido = idPedido,
                        IdEmpleado = idEmpleado,
                        IdCliente = idCliente,
                        IdSucursal = (Guid)cmbSucursal.SelectedValue, // Se asigna la sucursal seleccionada
                        Total = totalPedido,
                        Estado = Pedido.EstadoPedido.Registrado,
                        FechaRegistro = DateTime.Now,
                        obj_DetallePedido = new List<DetallePedido>()
                    };

                    foreach (DataGridViewRow row in dgvDetallePedido.Rows)
                    {
                        if (row.IsNewRow) continue;

                        if (row.Cells["id"].Value != null &&
                            Guid.TryParse(row.Cells["id"].Value.ToString(), out Guid idProducto) &&
                            int.TryParse(row.Cells["cantidad"].Value?.ToString(), out int cantidad) &&
                            decimal.TryParse(row.Cells["subtotal"].Value?.ToString(), out decimal subtotal))
                        {
                            pedido.obj_DetallePedido.Add(new DetallePedido
                            {
                                IdDetallePedido = Guid.NewGuid(),
                                IdProducto = idProducto,
                                Cantidad = cantidad,
                                SubTotal = subtotal
                            });
                        }
                    }

                    if (pedido.obj_DetallePedido.Count == 0)
                    {
                        throw new PedidoSinDetalleException("El pedido no tiene detalles. Agrega al menos un producto.");
                    }

                    // Registrar pedido
                    Guid resultadoIdPedido = PedidoLogic.Instance.RegistrarPedido(pedido);

                    // Actualizar el estado del pedido a Registrado
                    PedidoLogic.Instance.ActualizarEstadoPedido(pedido.NroPedido, Pedido.EstadoPedido.Registrado);

                    // Actualizar el inventario: descontar la cantidad reservada para ese pedido y sucursal
                    InventarioLogic.Instance.ActualizarInventarioPedido(resultadoIdPedido, pedido.IdSucursal);

                    MessageBox.Show($"Pedido registrado con éxito. Nro Pedido: {pedido.NroPedido}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarGroupBoxDatosProducto();
                    dgvDetallePedido.Rows.Clear();
                    txtTotalPedido.Text = "0.00";
                }
            }
            catch (PedidoSinDetalleException ex)
            {
                MessageBox.Show(ex.Message, "Error de Registro de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al registrar el pedido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarEstadoPedido()
        {
            cmbPedido.DataSource = Enum.GetValues(typeof(Pedido.EstadoPedido))
                                        .Cast<Pedido.EstadoPedido>()
                                        .Select(e => new { Value = (int)e, Name = e.ToString() })
                                        .ToList();
            cmbPedido.ValueMember = "Value";
            cmbPedido.DisplayMember = "Name";
        }


        private void CargarSucursales()
        {
            try
            {
                List<Sucursal> sucursales = sucursalLogic.GetAll();

                // Configurar el ComboBox con DataSource, ValueMember y DisplayMember
                cmbSucursal.DataSource = sucursales;
                cmbSucursal.ValueMember = "IdSucursal"; // Suponiendo que "IdSucursal" es el GUID de cada sucursal
                cmbSucursal.DisplayMember = "Nombre";    // Suponiendo que "Nombre" es el campo que quieres mostrar

                if (cmbSucursal.Items.Count > 0)
                {
                    cmbSucursal.SelectedIndex = 0; // Seleccionar el primer elemento
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las sucursales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizarEstado_Click(object sender, EventArgs e)
        {
            try
            {
                if (!VerificarConexion())
                    return;
                var estadoSeleccionado = (Pedido.EstadoPedido)cmbPedido.SelectedValue;

                if (estadoSeleccionado == Pedido.EstadoPedido.Suspendido)
                {
                    throw new EstadoNoValidoException($"El pedido se encuentra suspendido. Realizar la solicitud nuevamente.");
                }

                int nroPedido = Convert.ToInt32(txtNroPedido.Text);
                Pedido.EstadoPedido nuevoEstado = (Pedido.EstadoPedido)cmbPedido.SelectedValue;
                pedidoLogic.ActualizarEstadoPedido(nroPedido, nuevoEstado);
                MessageBox.Show("El estado del pedido ha sido actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el estado del pedido: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                if (!VerificarConexion())
                    return;
                using (var modal = new mdPedido())
                {
                    if (modal.ShowDialog() == DialogResult.OK)
                    {
                        groupBoxProductos.Enabled = false;
                        groupBoxClientes.Enabled = false;
                        btnBuscarCliente.Enabled = false;
                        btnRegistraPedido.Enabled = false;
                        var pedido = modal._Pedido;

                        if (pedido == null) throw new PedidoNoEncontradoException("El pedido seleccionado no existe.");

                        // Cargar datos del pedido
                        txtNroPedido.Text = pedido.NroPedido.ToString();
                        txtFechaRegistro.Text = pedido.FechaRegistro.ToString();
                        cmbPedido.Text = pedido.Estado.ToString();

                        // Obtener información del cliente
                        var cliente = clienteLogic.GetById(pedido.IdCliente);
                        if (cliente == null) throw new ClienteNoEncontradoException("No se encontró al cliente asociado al pedido.");

                        txtNroDocumento.Text = cliente.NroDocumento.ToString();
                        txtNombreCliente.Text = $"{cliente.Nombre} {cliente.Apellido}";
                        txtIdCliente.Text = cliente.IdCliente.ToString();

                        // Obtener y mostrar detalles del pedido
                        var detalles = pedidoLogic.ObtenerDetallePedido(pedido.IdPedido);
                        dgvDetallePedido.Rows.Clear();

                        foreach (var detalle in detalles)
                        {
                            Producto producto = productoLogic.GetByGuid(detalle.IdProducto);
                            if (producto == null) throw new ProductoNoEncontradoException($"No se encontró el producto con ID: {detalle.IdProducto}");

                            dgvDetallePedido.Rows.Add(detalle.IdProducto, producto.CodProducto, producto.Nombre, producto.PrecioVenta, detalle.Cantidad, detalle.SubTotal);
                        }

                        CalcularTotal();
                    }
                    else
                    {
                        txtNroPedido.Select();
                    }
                }
            }
            catch (ClienteNoEncontradoException ex)
            {
                MessageBox.Show(ex.Message, "Error de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (ProductoNoEncontradoException ex)
            {
                MessageBox.Show(ex.Message, "Error de Producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el pedido: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (!VerificarConexion())
                    return;
                using (var modal = new mdCliente())
                {
                    var result = modal.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        txtIdCliente.Text = modal._Cliente.IdCliente.ToString();
                        txtNroDocumento.Text = modal._Cliente.NroDocumento.ToString();
                        txtNombreCliente.Text = modal._Cliente.Nombre + " " + modal._Cliente.Apellido;
                        txtCodProducto.Select();
                    }
                    else
                    {
                        txtNroDocumento.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            // Limpiar los datos del producto previamente seleccionado
            LimpiarDatosProducto();
            if (!VerificarConexion())
                return;
            using (var modal = new mdProducto())
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtIdProducto.Text = modal._Producto.IdProducto.ToString();
                    txtCodProducto.Text = modal._Producto.CodProducto;
                    txtProducto.Text = modal._Producto.Nombre;
                    txtPrecio.Text = modal._Producto.PrecioVenta.ToString();
                    numericCantidad.Select();
                }
                else
                {
                    txtCodProducto.Select();
                }
            }
        }

        private void LimpiarDatosProducto()
        {
            txtIdProducto.Clear();
            txtCodProducto.Clear();
            txtProducto.Clear();
            txtPrecio.Clear();
            numericCantidad.Value = 0;
            txtStock.Clear();
            txtReserva.Clear();
            // Si existen otros controles relacionados, limpiarlos aquí
        }


        private void CalcularTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow fila in dgvDetallePedido.Rows)
            {
                if (fila.Cells["subtotal"].Value != null)
                {
                    total += Convert.ToDecimal(fila.Cells["subtotal"].Value);
                }
            }
            txtTotalPedido.Text = total.ToString(); // Formato de moneda
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            groupBoxProductos.Enabled = true;
            groupBoxClientes.Enabled = true;
            btnBuscarCliente.Enabled = true;
            btnRegistraPedido.Enabled = true;
            dgvDetallePedido.Rows.Clear();
            txtTotalPedido.Text = "";
            LimpiarGroupBoxDatosPedido();
            LimpiarGroupBoxDatosCliente();
            LimpiarGroupBoxDatosProducto();
        }

        private void LimpiarGroupBoxDatosCliente()
        {
            txtIdCliente.Text = "";
            txtNroDocumento.Text = "";
            txtNombreCliente.Text = "";
        }

        private void LimpiarGroupBoxDatosPedido()
        {
            txtNroPedido.Text = "";
            txtFechaRegistro.Text = "";
        }

        private void LimpiarGroupBoxDatosProducto()
        {
            txtCodProducto.Text = "";
            txtIdProducto.Text = "";
            txtProducto.Text = "";
            txtPrecio.Text = "";
            numericCantidad.Value = 0;
            txtStock.Text = "";
            txtReserva.Text = "";
        }
        private void btnSuspender_Click(object sender, EventArgs e)
        {
            try
            {
                if (!VerificarConexion())
                    return;
                int nroPedido = Convert.ToInt32(txtNroPedido.Text);
                // Aquí puedes obtener el pedido por nroPedido si es necesario para verificar otros datos:
                Pedido pedido = pedidoLogic.GetPedidoByNro(nroPedido);
                var estadoSeleccionado = (Pedido.EstadoPedido)cmbPedido.SelectedValue;

                if (estadoSeleccionado != Pedido.EstadoPedido.Registrado)
                {
                    throw new EstadoNoValidoException($"El pedido no se puede anular en el estado actual: {estadoSeleccionado}.");
                }

                // Llamar a la lógica para suspender el pedido
                pedidoLogic.SuspenderPedido(nroPedido);

                MessageBox.Show("Pedido anulado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbPedido.SelectedIndex = 0;
            }
            catch (PedidoNoValidoException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (EstadoNoValidoException ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
