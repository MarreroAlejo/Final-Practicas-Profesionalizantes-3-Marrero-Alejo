using DAO.Factory;
using DOMAIN;
using LOGIC;
using LOGIC.Exceptions.ClienteExceptions;
using LOGIC.Facade;
using SERVICES.Domain;
using SERVICES.Domain.Composite;
using SERVICES.Facade;
using SERVICES.Facade.Extentions;
using SERVICES.Observer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using static DOMAIN.Cliente;

namespace UI
{
    public partial class FmrGestionarClientes : Form, IObserver
    {
        private ClienteService clienteService;
        private Usuario usuarioActual;
        private List<Cliente> listaClientes = new List<Cliente>();

        public FmrGestionarClientes(Usuario usuario)
        {
            InitializeComponent();
            clienteService = new ClienteService();
            LanguageNotifier.Instance.RegisterObserver(this);
            Update();
            usuarioActual = usuario;

            // 1. Cargar combo de criterios de búsqueda
            CargarComboBusqueda();

            // 2. Suscribir evento KeyPress para el TextBox Teléfono
            txtTelefono.KeyPress += txtTelefono_KeyPress;
        }

        public new void Update()
        {
            TraducirTextoControles();
        }

        private void FmrGestionarClientes_Load(object sender, EventArgs e)
        {
            this.Refresh();
            InicializarListClientes();
            CargarComboBoxEstado();
            Update();
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

        /// <summary>
        /// Carga la lista de clientes en el ListBox principal.
        /// </summary>
        private void InicializarListClientes()
        {
            ListadeClientes.Items.Clear();
            listaClientes = clienteService.ObtenerClientes();

            foreach (Cliente cliente in listaClientes)
            {
                ListadeClientes.Items.Add($"{cliente.Nombre} {cliente.Apellido}");
            }
        }

        #region Métodos para Controles

        /// <summary>
        /// Carga las opciones de Estado en el ComboBox.
        /// </summary>
        private void CargarComboBoxEstado()
        {
            cmbEstado.DataSource = Enum.GetValues(typeof(EstadoCliente))
                                       .Cast<EstadoCliente>()
                                       .Select(e => new { Value = e, Text = StringExtention.Translate(e.ToString()) })
                                       .ToList();
            cmbEstado.DisplayMember = "Text";
            cmbEstado.ValueMember = "Value";
        }

        /// <summary>
        /// Carga las opciones de criterios de búsqueda en un ComboBox adicional.
        /// Ejemplo: Documento, Nombre, Apellido.
        /// </summary>
        private void CargarComboBusqueda()
        {
            // Crea la lista de criterios
            var criterios = new List<string> { "Documento"};

            // Asigna la lista al ComboBox (ej. cmbBuscarPor)
            cmbBuscarPor.DataSource = criterios;
            // Opcional: cmbBuscarPor.SelectedIndex = 0;  // Selecciona "Documento" por defecto
        }

        /// <summary>
        /// Limpia los TextBox y restablece controles.
        /// </summary>
        private void Limpiar()
        {
            txtId.Text = "";
            txtNroDocumento.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtCodPostal.Text = "";
            txtTelefono.Text = "";
            txtMail.Text = "";
            txtBarrio.Text = "";
            txtProvincia.Text = "";
            cmbEstado.SelectedIndex = 0;
            txtBuscador.Text = "";
            txtNroDocumento.Select();
        }

        /// <summary>
        /// Elimina los espacios en blanco de todos los TextBox relevantes.
        /// </summary>
        private void RemoverEspacios()
        {
            txtId.Text = txtId.Text.Trim();
            txtNroDocumento.Text = txtNroDocumento.Text.Trim();
            txtNombre.Text = txtNombre.Text.Trim();
            txtApellido.Text = txtApellido.Text.Trim();
            txtDireccion.Text = txtDireccion.Text.Trim();
            txtCodPostal.Text = txtCodPostal.Text.Trim();
            txtTelefono.Text = txtTelefono.Text.Trim();
            txtMail.Text = txtMail.Text.Trim();
            txtBarrio.Text = txtBarrio.Text.Trim();
            txtProvincia.Text = txtProvincia.Text.Trim();
            txtBuscador.Text = txtBuscador.Text.Trim();
        }

        /// <summary>
        /// Evento KeyPress para permitir únicamente números en txtTelefono.
        /// </summary>
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Aceptar solo dígitos y teclas de control (Backspace, etc.)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #endregion

        #region Traducción de Controles
        private void TraducirTextoControles()
        {
            lblMenu.Text = StringExtention.Translate("Gestión de Cliente");
            label2.Text = StringExtention.Translate("Clientes registrados");
            lblNroDocumento.Text = StringExtention.Translate("Nro.Documento");
            lblNombre.Text = StringExtention.Translate("Nombre");
            lblApellido.Text = StringExtention.Translate("Apellido");
            lblDireccion.Text = StringExtention.Translate("Dirección");
            lblCodigoPostal.Text = StringExtention.Translate("Código Postal");
            lblTelefono.Text = StringExtention.Translate("Teléfono");
            lblMail.Text = StringExtention.Translate("Mail");
            lblBarrio.Text = StringExtention.Translate("Barrio");
            lblProvincia.Text = StringExtention.Translate("Provincia");
            lblEstado.Text = StringExtention.Translate("Estado");

            groupBox2.Text = StringExtention.Translate("Filtro de búsqueda");


            btnBuscar.Text = StringExtention.Translate("Buscar");
            btnLimpiar.Text = StringExtention.Translate("Limpiar");
            btnRegistrar.Text = StringExtention.Translate("Registrar");
            btnEditar.Text = StringExtention.Translate("Editar");
            btnLimpiarBuscador.Text = StringExtention.Translate("Limpiar");

            // Actualiza también los textos del ComboBox de Estado
            CargarComboBoxEstado();
        }
        #endregion

        #region Eventos

        private void ListadeClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListadeClientes.SelectedIndex >= 0)
            {
                Cliente clienteSeleccionado = listaClientes[ListadeClientes.SelectedIndex];
                CargarDatosCliente(clienteSeleccionado);
                btnRegistrar.Enabled = false;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            btnRegistrar.Enabled = true;
        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Buscar al cliente según el criterio seleccionado en cmbBuscarPor.
        /// </summary>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Eliminar espacios en blanco
                RemoverEspacios();

                // 2. Verificar que haya texto para buscar
                if (string.IsNullOrWhiteSpace(txtBuscador.Text))
                {
                    MessageBox.Show("Por favor ingrese un valor de búsqueda.");
                    return;
                }

                // 3. Obtener el criterio seleccionado (Documento, Nombre o Apellido)
                string criterio = cmbBuscarPor.SelectedItem.ToString();
                Cliente cliente = null;

                // 4. Buscar según el criterio
                switch (criterio)
                {
                    case "Documento":
                        cliente = clienteService.BuscarClientePorDocumento(txtBuscador.Text);
                        break;
                    case "Nombre":
                        cliente = clienteService.BuscarClientePorNombre(txtBuscador.Text);
                        break;
                    case "Apellido":
                        cliente = clienteService.BuscarClientePorApellido(txtBuscador.Text);
                        break;
                }

                if (cliente == null)
                {
                    throw new ClienteNoEncontradoException("No se encontró un cliente con el criterio proporcionado.");
                }

                // 5. Cargar los datos del cliente en los campos
                CargarDatosCliente(cliente);
            }
            catch (ClienteNoEncontradoException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}");
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!VerificarConexion())
                    return;
                RemoverEspacios();

                if (ValidarFormulario(out string mensajeError))
                {
                    Cliente nuevoCliente = ObtenerDatosFormulario();

                    clienteService.RegistrarCliente(nuevoCliente);
                    listaClientes.Add(nuevoCliente);
                    ListadeClientes.Items.Add($"{nuevoCliente.Nombre} {nuevoCliente.Apellido}");
                    Limpiar();
                    MessageBox.Show("Cliente registrado exitosamente.");
                }
                else
                {
                    MessageBox.Show(mensajeError);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar cliente: {ex.Message}");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!VerificarConexion())
                    return;
                // 1. Eliminar espacios en blanco
                RemoverEspacios();

                // 2. Verificar que exista un cliente seleccionado
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("Seleccione un cliente para editar.");
                    return;
                }

                // 3. Validar formulario
                if (ValidarFormulario(out string mensajeError))
                {
                    // 4. Confirmar si el usuario desea editar al cliente
                    DialogResult resultado = MessageBox.Show("¿Está seguro de que desea editar este cliente?", "Confirmar Edición", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        // 5. Obtener datos y actualizar
                        Cliente clienteActualizado = ObtenerDatosFormulario();
                        clienteService.EditarCliente(clienteActualizado);
                        ActualizarClienteEnLista(clienteActualizado);
                        MessageBox.Show("Cliente actualizado exitosamente.");
                    }
                }
                else
                {
                    MessageBox.Show(mensajeError);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}");
            }
        }

        #endregion

        #region Métodos Auxiliares

        /// <summary>
        /// Retorna un objeto Cliente con los datos de los TextBox.
        /// </summary>
        private Cliente ObtenerDatosFormulario()
        {
            return new Cliente()
            {
                IdCliente = string.IsNullOrEmpty(txtId.Text) ? 0 : Convert.ToInt32(txtId.Text),
                NroDocumento = string.IsNullOrEmpty(txtNroDocumento.Text) ? 0 : Convert.ToInt32(txtNroDocumento.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Direccion = txtDireccion.Text,
                CodPostal = string.IsNullOrEmpty(txtCodPostal.Text) ? 0 : Convert.ToInt32(txtCodPostal.Text),
                Telefono = txtTelefono.Text,
                Mail = txtMail.Text,
                Barrio = txtBarrio.Text,
                Provincia = txtProvincia.Text,
                Estado = (EstadoCliente)cmbEstado.SelectedValue
            };
        }

        /// <summary>
        /// Carga los datos de un cliente en los TextBox.
        /// </summary>
        private void CargarDatosCliente(Cliente cliente)
        {
            txtId.Text = cliente.IdCliente.ToString();
            txtNroDocumento.Text = cliente.NroDocumento.ToString();
            txtNombre.Text = cliente.Nombre;
            txtApellido.Text = cliente.Apellido;
            txtDireccion.Text = cliente.Direccion;
            txtCodPostal.Text = cliente.CodPostal.ToString();
            txtTelefono.Text = cliente.Telefono;
            txtMail.Text = cliente.Mail;
            txtBarrio.Text = cliente.Barrio;
            txtProvincia.Text = cliente.Provincia;

            // Seleccionar en el combo el estado correspondiente
            cmbEstado.SelectedItem = cmbEstado.Items
                .Cast<dynamic>()
                .FirstOrDefault(i => i.Value.Equals(cliente.Estado));
        }

        /// <summary>
        /// Actualiza un cliente en la lista interna y en el ListBox.
        /// </summary>
        private void ActualizarClienteEnLista(Cliente cliente)
        {
            int indice = listaClientes.FindIndex(c => c.IdCliente == cliente.IdCliente);
            if (indice >= 0)
            {
                listaClientes[indice] = cliente;
                ListadeClientes.Items[indice] = $"{cliente.Nombre} {cliente.Apellido}";
            }
        }

        /// <summary>
        /// Valida el formulario y retorna false si encuentra algún error.
        /// </summary>
        private bool ValidarFormulario(out string mensajeError)
        {
            if (string.IsNullOrWhiteSpace(txtNroDocumento.Text))
            {
                mensajeError = "El número de documento es obligatorio.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                mensajeError = "El nombre es obligatorio.";
                return false;
            }
            if (!int.TryParse(txtCodPostal.Text, out _))
            {
                mensajeError = "El código postal debe ser un número.";
                return false;
            }
            if (!string.IsNullOrEmpty(txtMail.Text) && !txtMail.Text.Contains("@"))
            {
                mensajeError = "El correo electrónico no es válido.";
                return false;
            }
            mensajeError = string.Empty;
            return true;
        }

        #endregion

        private void txtNroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Aceptar solo dígitos y teclas de control (Backspace, etc.)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
