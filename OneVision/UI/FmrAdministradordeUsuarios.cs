using DOMAIN;
using LOGIC;
using SERVICES.Dao.Implementations.SqlServer;
using SERVICES.Domain;
using SERVICES.Domain.Composite;
using SERVICES.Facade;
using SERVICES.Facade.Extentions;
using SERVICES.Logic;
using SERVICES.Logic.Exceptions.FamiliaExceptions;
using SERVICES.Observer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace UI
{
    public partial class FmrAdministradordeUsuarios : Form, IObserver
    {
        private UserLogic userLogic;
        private PatenteLogic patenteLogic;
        private FamiliaLogic familiaLogic;
        private LoggerService loggerService;
        private SucursalLogic sucursalLogic;
        private EmpleadoLogic empleadoLogic;
        private Usuario usuarioActual;

        public FmrAdministradordeUsuarios(Usuario usuarioActual)
        {
            InitializeComponent();
            userLogic = UserLogic.GetInstance();
            patenteLogic = PatenteLogic.GetInstance();
            familiaLogic = FamiliaLogic.GetInstance();
            sucursalLogic = SucursalLogic.GetInstance();
            empleadoLogic = EmpleadoLogic.GetInstance();
            this.usuarioActual = usuarioActual;
            LanguageNotifier.Instance.RegisterObserver(this);
            Update();
        }

        private void FmrAdministradordeUsuarios_Load(object sender, EventArgs e)
        {
            Limpiar();
            VerificarConexion();
            CargarListas();
            CargarCmbEstadoUsuario();
            CargarCmbTipoEmpleado();
            CargarSucursales();
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
            TraducirTextoControles();
        }
        #region Traduccion de Controles
        private void TraducirTextoControles()
        {
            // Actualiza los textos de los labels, botones, etc.
            lblMenu.Text = StringExtention.Translate("Administrador de Usuarios");
            lblUsuariosRegistrados.Text = StringExtention.Translate("Usuarios Registrados");
            lblGestionUsuarios.Text = StringExtention.Translate("Gestion de Usuarios");
            lblGestionAccesos.Text = StringExtention.Translate("Gestion de Accesos");
            lblNombreUsuario.Text = StringExtention.Translate("Nombre Usuario");
            lblContraseña.Text = StringExtention.Translate("Contraseña");
            lblNombre.Text = StringExtention.Translate("Nombre");
            lblApellido.Text = StringExtention.Translate("Apellido");
            lblMail.Text = StringExtention.Translate("Mail");
            lblTelefono.Text = StringExtention.Translate("Teléfono");
            lblEstado.Text = StringExtention.Translate("Estado");
            lblTipoEmpleado.Text = StringExtention.Translate("Tipo Empleado");
            lblSucursal.Text = StringExtention.Translate("Sucursal");
            lblIdUsuario.Text = StringExtention.Translate("ID Usuario");
            lblIdEmpleado.Text = StringExtention.Translate("ID Empleado");
            lblFechaAlta.Text = StringExtention.Translate("Fecha Alta");
            lblRoles.Text = StringExtention.Translate("Roles");
            lblPatentes.Text = StringExtention.Translate("Patentes");
            btnGuardar.Text = StringExtention.Translate("Guardar");
            txtLimpiar.Text = StringExtention.Translate("Limpiar");
        }
        #endregion

        private void Limpiar()
        {
            listPatentesElegidas.Items.Clear();
            listFamiliaElegidas.Items.Clear();
            txtIdUsuario.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtIdEmpleado.Text = string.Empty;
            txtNombreEmpleado.Text = string.Empty;
            txtApellidoEmpleado.Text = string.Empty;
            txtTelefonoEmpleado.Text = string.Empty;
            txtMailEmpleado.Text = string.Empty;
            txtFechaAltaEmpleado.Text = string.Empty;
            CargarListas();
        }

        private void TrimAllTextBoxes(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox textBox)
                {
                    textBox.Text = textBox.Text.Trim();
                }
                else if (ctrl.HasChildren)
                {
                    TrimAllTextBoxes(ctrl);
                }
            }
        }


        private void CargarListas()
        {
            CargarlistBoxUsuarios();
            CargarlistBoxFamilias();
            CargarlistBoxPatentes();
        }

        private void CargarCmbEstadoUsuario()
        {
            // Llenar el ComboBox de Estado con los valores del enum traducidos
            cmbEstadoUsuario.DataSource = Enum.GetValues(typeof(Usuario.EstadoUsuario)).Cast<Usuario.EstadoUsuario>().Select(e => new { Value = e, Text = e.ToString() }).ToList();
            // Definir qué mostrar y qué valor utilizar
            cmbEstadoUsuario.DisplayMember = "Text"; // Mostrar el texto traducido (Activo / Suspendido)
            cmbEstadoUsuario.ValueMember = "Value"; // Usar el valor del enum
        }

        private void CargarCmbTipoEmpleado()
        {
            // Llenar el ComboBox con las familias disponibles
            List<Familia> familias = familiaLogic.GetAllFamilias().ToList();

            if (familias == null || !familias.Any())
            {
                MessageBox.Show("No hay familias disponibles.");
                return;
            }

            cmbTipoEmpleado.DataSource = familias;
            cmbTipoEmpleado.DisplayMember = "Nombre"; // Muestra el nombre de la familia
            cmbTipoEmpleado.ValueMember = "Id"; // Usa el Id de la familia como valor

            // No seleccionar nada por defecto
            cmbTipoEmpleado.SelectedIndex = -1;
        }



        private void CargarSucursales()
        {
            try
            {
                List<Sucursal> sucursales = sucursalLogic.GetAll();
                // Configurar el ComboBox con DataSource
                cmbSucursalEmpleado.DataSource = sucursales;
                cmbSucursalEmpleado.DisplayMember = "Nombre";  // Campo que deseas mostrar
                cmbSucursalEmpleado.ValueMember = "IdSucursal";  // Campo que deseas usar como valor
                if (cmbSucursalEmpleado.Items.Count > 0)
                {
                    cmbSucursalEmpleado.SelectedIndex = 0; // Seleccionar el primer elemento
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las sucursales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void listUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listUsuarios.SelectedItem != null)
            {
                string selectedUsername = listUsuarios.SelectedItem.ToString();
                Usuario usuario = userLogic.SelectByUsername(selectedUsername);
                if (usuario != null)
                {
                    txtIdUsuario.Text = usuario.IdUsuario.ToString();
                    txtUserName.Text = usuario.UserName;
                    txtPassword.Text = usuario.Password;
                    cmbEstadoUsuario.Text = usuario.Estado.ToString();

                    Empleado empleado = empleadoLogic.GetEmpleadoPorUsuario(usuario.IdUsuario);
                    if (empleado != null)
                    {
                        txtIdEmpleado.Text = empleado.IdEmpleado.ToString();
                        txtNombreEmpleado.Text = empleado.Nombre;
                        txtApellidoEmpleado.Text = empleado.Apellido;

                        // Buscar en el ComboBox la familia del empleado
                        if (empleado.IdFamilia != null)
                        {
                            cmbTipoEmpleado.SelectedValue = empleado.IdFamilia;
                        }
                        else
                        {
                            cmbTipoEmpleado.SelectedIndex = -1;
                        }

                        Sucursal sucursal = sucursalLogic.GetByGuid(empleado.IdSucursal);
                        if (sucursal != null)
                        {
                            cmbSucursalEmpleado.Text = sucursal.Nombre;
                        }

                        txtTelefonoEmpleado.Text = empleado.Telefono;
                        txtMailEmpleado.Text = empleado.Mail;
                        txtFechaAltaEmpleado.Text = empleado.FechaRegistro.ToString();

                        // Limpiar listas de permisos antes de cargar
                        listPatentesElegidas.Items.Clear();
                        listFamiliaElegidas.Items.Clear();

                        // Obtener y mostrar las patentes del usuario
                        List<string> patentesUsuario = userLogic.ObtenerUsuarioPatentes(usuario.IdUsuario);
                        foreach (var patente in patentesUsuario)
                        {
                            listPatentesElegidas.Items.Add(patente);
                        }

                        // Obtener y mostrar las familias del usuario
                        List<string> familiasUsuario = userLogic.ObtenerUsuarioFamilia(usuario.IdUsuario);
                        foreach (var familia in familiasUsuario)
                        {
                            listFamiliaElegidas.Items.Add(familia);
                        }

                        // Condicional para quitar las patentes ya seleccionadas de ListPatentesAElegir
                        for (int i = listPatentesAElegir.Items.Count - 1; i >= 0; i--)
                        {
                            if (listPatentesElegidas.Items.Contains(listPatentesAElegir.Items[i]))
                            {
                                listPatentesAElegir.Items.RemoveAt(i);
                            }
                        }

                        // Condicional para quitar las familias ya seleccionadas de ListFamiliasAElegir
                        for (int i = listFamiliaAElegir.Items.Count - 1; i >= 0; i--)
                        {
                            if (listFamiliaElegidas.Items.Contains(listFamiliaAElegir.Items[i]))
                            {
                                listFamiliaAElegir.Items.RemoveAt(i);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró un empleado asociado a este usuario.");
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró ningún usuario con el nombre de usuario seleccionado.");
                }
            }
        }

        #region Cargar ListBox
        private void txtLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            CargarlistBoxFamilias();
            CargarlistBoxPatentes();
        }
        private void CargarlistBoxUsuarios()
        {
            try
            {
                List<Usuario> usuarios = userLogic.GetAll().ToList();
                listUsuarios.Items.Clear();

                foreach (var usuario in usuarios)
                {
                    if (!string.IsNullOrEmpty(usuario.UserName))
                    {
                        listUsuarios.Items.Add(usuario.UserName); // Carga solo UserName
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }
        }

        private void CargarlistBoxFamilias()
        {
            try
            {
                List<Familia> familias = familiaLogic.GetAllFamilias().ToList();
                listFamiliaAElegir.Items.Clear();
                foreach (var familia in familias)
                {
                    listFamiliaAElegir.Items.Add(familia.Nombre);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar familias: " + ex.Message);
            }
        }
        private void CargarlistBoxPatentes()
        {
            try
            {
                List<Patente> patentes = patenteLogic.GetAllPatentes().ToList();
                listPatentesAElegir.Items.Clear();
                foreach (var patente in patentes)
                {
                    listPatentesAElegir.Items.Add(patente.Nombre);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar familias: " + ex.Message);
            }
        }
        #endregion


        #region Botones de Gestion
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!VerificarConexion())
                    return;
                txtUserName.Text = txtUserName.Text.Trim();
                txtPassword.Text = txtPassword.Text.Trim();
                txtNombreEmpleado.Text = txtNombreEmpleado.Text.Trim();
                txtApellidoEmpleado.Text = txtApellidoEmpleado.Text.Trim();
                txtMailEmpleado.Text = txtMailEmpleado.Text.Trim();
                txtTelefonoEmpleado.Text = txtTelefonoEmpleado.Text.Trim();
                txtFechaAltaEmpleado.Text = txtFechaAltaEmpleado.Text.Trim();

                // 1. Crear/editar usuario
                Guid idUsuario = string.IsNullOrEmpty(txtIdUsuario.Text) ? Guid.NewGuid() : Guid.Parse(txtIdUsuario.Text);
                var usuario = new Usuario
                {
                    IdUsuario = idUsuario,
                    UserName = txtUserName.Text,
                    Password = string.IsNullOrEmpty(txtPassword.Text)
                               ? null
                               : EncryptLogic.GetSHA256(txtPassword.Text)
                };

                // 2. Crear/editar empleado
                Guid idEmpleado = string.IsNullOrEmpty(txtIdEmpleado.Text) ? Guid.NewGuid() : Guid.Parse(txtIdEmpleado.Text);

                if (cmbSucursalEmpleado.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar una sucursal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Guid idSucursal = (Guid)cmbSucursalEmpleado.SelectedValue;

                if (cmbTipoEmpleado.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar una familia (tipo de empleado).",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Guid idFamilia = (Guid)cmbTipoEmpleado.SelectedValue;

                var empleado = new Empleado
                {
                    IdEmpleado = idEmpleado,
                    IdUsuario = idUsuario,
                    IdSucursal = idSucursal,
                    IdFamilia = idFamilia,
                    Nombre = txtNombreEmpleado.Text,
                    Apellido = txtApellidoEmpleado.Text,
                    Mail = txtMailEmpleado.Text,
                    Telefono = txtTelefonoEmpleado.Text,
                    FechaRegistro = string.IsNullOrEmpty(txtFechaAltaEmpleado.Text)
                                    ? DateTime.Now
                                    : Convert.ToDateTime(txtFechaAltaEmpleado.Text)
                };

                // 3. Registrar/editar usuario y empleado
                bool esNuevo = string.IsNullOrEmpty(txtIdUsuario.Text) || string.IsNullOrEmpty(txtIdEmpleado.Text);
                if (!esNuevo)
                {
                    // Edición
                    userLogic.EditarUsuario(usuario);
                    empleadoLogic.Editar(empleado);
                }
                else
                {
                    // Alta
                    userLogic.RegistrarNuevoUsuario(usuario);
                    empleadoLogic.Registrar(empleado);
                }

                // 4. Obtener la familia seleccionada
                Familia familia = familiaLogic.GetAllFamilias().FirstOrDefault(f => f.Id == idFamilia);
                if (familia != null)
                {
                    // A) Asegurar patentes "obligatorias" en la familia
                    AñadirPatenteNecesaria(familia);

                    // B) Asignar la familia al usuario
                    userLogic.RegistrarUsuarioFamilia(idUsuario, familia.Id);

                    // C) Cargar sus patentes (para tener familia.Accesos)
                    familiaLogic.GetCountFamiliaPatente(familia);

                    // D) Asignar patentes de la familia al usuario
                    foreach (var acceso in familia.Accesos)
                    {
                        if (acceso is Patente patente)
                        {
                            // Registrar la patente en la tabla Usuario_Patente
                            userLogic.RegistrarUsuarioPatente(idUsuario, patente.Id);
                        }
                    }
                }
                    Log log = new Log(
                    $"Usuario {usuario.UserName} ha sido {(esNuevo ? "creado" : "editado")} exitosamente.",
                    TraceLevel.Info,
                    DateTime.Now
                );

                LoggerService.WriteLog(log);

                MessageBox.Show("Operación realizada correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarlistBoxUsuarios();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AñadirPatenteNecesaria(Familia familia)
        {
            try
            {
                Patente patenteUsuario = PatenteLogic.Instance.GetPatenteByNombre("Usuario")
                                             ?? new Patente { Nombre = "Usuario" };
                Patente patenteGestionarUsuario = PatenteLogic.Instance.GetPatenteByNombre("Gestionar Usuario")
                                                      ?? new Patente { Nombre = "Gestionar Usuario" };

                // Verificar si la familia ya tiene la patente "Usuario"
                if (!familia.Accesos.OfType<Patente>().Any(p => p.Id == patenteUsuario.Id))
                {
                    familiaLogic.Add(familia, patenteUsuario);
                }

                // Verificar si la familia ya tiene la patente "Gestionar Usuario"
                if (!familia.Accesos.OfType<Patente>().Any(p => p.Id == patenteGestionarUsuario.Id))
                {
                    familiaLogic.Add(familia, patenteGestionarUsuario);
                }

                MessageBox.Show(
                  $"Se añadieron las patentes correctamente.",
                  "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                  $"Ocurrió un error al añadir las patentes necesarias: {ex.Message}",
                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error
                );
            }
        }


        #endregion

        #region Botones de Accesos
        private void btnAgregarFamilia_Click(object sender, EventArgs e)
        {
            try
            {
                if (!VerificarConexion())
                    return;
                // Obtener el ID del usuario
                Guid idUsuario = Guid.Parse(txtIdUsuario.Text);
                Usuario usuario = userLogic.GetById(idUsuario);

                if (listFamiliaAElegir.SelectedItem != null)
                {
                    // Obtener el nombre de la familia seleccionada
                    string nombreFamilia = listFamiliaAElegir.SelectedItem.ToString();

                    // Obtener todas las familias
                    List<Familia> todasLasFamilias = familiaLogic.GetAllFamilias();

                    // Buscar la familia por el nombre seleccionado
                    Familia familiaSeleccionada = todasLasFamilias
                        .FirstOrDefault(f => f.Nombre.Equals(nombreFamilia, StringComparison.OrdinalIgnoreCase));

                    if (familiaSeleccionada != null && familiaSeleccionada.Id != Guid.Empty)
                    {
                        // Registrar la familia al usuario
                        userLogic.RegistrarUsuarioFamilia(idUsuario, familiaSeleccionada.Id);

                        // Actualizar el ListBox de familias
                        listFamiliaElegidas.Items.Add(familiaSeleccionada.Nombre);
                        listFamiliaAElegir.Items.Remove(nombreFamilia);

                        // Obtener las patentes asociadas a la familia y cargarlas en la colección Accesos
                        familiaLogic.GetCountFamiliaPatente(familiaSeleccionada);

                        // Recorrer las patentes asociadas y registrarlas para el usuario
                        foreach (var patente in familiaSeleccionada.Accesos)
                        {
                            // Registrar la patente en la relación usuario-patente
                            userLogic.RegistrarUsuarioPatente(idUsuario, patente.Id);

                            // Actualizar la interfaz: agregar a la lista de patentes asignadas
                            listPatentesElegidas.Items.Add(patente.Nombre);
                            listPatentesAElegir.Items.Remove(patente.Nombre); // Quitar de la lista de patentes disponibles
                        }

                        MessageBox.Show("Familia y patentes agregadas correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("La familia no existe.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una familia para agregar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar familia: " + ex.Message);
            }
        }

        private void btnEliminarFamilia_Click(object sender, EventArgs e)
        {
            try
            {
                if (!VerificarConexion())
                    return;
                // Obtener el ID del usuario y el objeto usuario
                Guid idUsuario = Guid.Parse(txtIdUsuario.Text);
                Usuario usuario = userLogic.GetById(idUsuario);

                if (listFamiliaElegidas.SelectedItem != null)
                {
                    // Obtener el nombre de la familia seleccionada
                    string nombreFamilia = listFamiliaElegidas.SelectedItem.ToString();

                    // Buscar la familia en la lista de todas las familias
                    Familia familiaSeleccionada = familiaLogic.GetAllFamilias()
                        .FirstOrDefault(f => f.Nombre.Equals(nombreFamilia, StringComparison.OrdinalIgnoreCase));

                    if (familiaSeleccionada != null && familiaSeleccionada.Id != Guid.Empty)
                    {
                        // Eliminar la asociación entre el usuario y la familia
                        userLogic.EliminarUsuarioFamilia(idUsuario, familiaSeleccionada.Id);

                        // Eliminar de la base de datos las patentes asociadas a la familia para ese usuario
                        // (Asegúrate de que la colección Accesos esté cargada)
                        familiaLogic.GetCountFamiliaPatente(familiaSeleccionada);
                        foreach (var patente in familiaSeleccionada.Accesos)
                        {
                            // Si la patente es obligatoria, saltar
                            if (patente.Nombre == "Usuario" || patente.Nombre == "Gestionar Usuario")
                            {
                                continue;
                            }
                            else
                            {
                                userLogic.EliminarUsuarioPatente(idUsuario, patente.Id);
                            }
                        }

                        // Refrescar las listas del usuario para mostrar el estado actual
                        RefrescarListasUsuario(usuario);

                        MessageBox.Show("Familia y patentes eliminadas correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("La familia no existe.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una familia para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar familia: " + ex.Message);
            }
        }


        private void RefrescarListasUsuario(Usuario usuario)
        {
            // Limpiar las listas asignadas
            listPatentesElegidas.Items.Clear();
            listFamiliaElegidas.Items.Clear();

            // Recargar patentes asignadas al usuario
            List<string> patentesUsuario = userLogic.ObtenerUsuarioPatentes(usuario.IdUsuario);
            foreach (var patente in patentesUsuario)
            {
                listPatentesElegidas.Items.Add(patente);
            }

            // Recargar familias asignadas al usuario
            List<string> familiasUsuario = userLogic.ObtenerUsuarioFamilia(usuario.IdUsuario);
            foreach (var familia in familiasUsuario)
            {
                listFamiliaElegidas.Items.Add(familia);
            }

            // Recargar las listas de opciones disponibles (se asume que estos métodos recargan desde la BD o fuente de datos)
            CargarlistBoxFamilias();
            CargarlistBoxPatentes();

            // Quitar de las listas disponibles aquellos elementos que ya están asignados
            for (int i = listPatentesAElegir.Items.Count - 1; i >= 0; i--)
            {
                if (listPatentesElegidas.Items.Contains(listPatentesAElegir.Items[i]))
                {
                    listPatentesAElegir.Items.RemoveAt(i);
                }
            }
            for (int i = listFamiliaAElegir.Items.Count - 1; i >= 0; i--)
            {
                if (listFamiliaElegidas.Items.Contains(listFamiliaAElegir.Items[i]))
                {
                    listFamiliaAElegir.Items.RemoveAt(i);
                }
            }
        }



        #endregion

        private void txtTelefonoEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos (char.IsDigit) y teclas de control (como backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela el evento KeyPress
            }
        }

        private void btnAgregarPatente_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!VerificarConexion())
                    return;
                Guid idUsuario = Guid.Parse(txtIdUsuario.Text);
                Usuario usuario = userLogic.GetById(idUsuario);

                if (listPatentesAElegir.SelectedItem != null)
                {
                    string nombrePatente = listPatentesAElegir.SelectedItem.ToString();

                    // Obtener la patente por su nombre
                    Patente patente = patenteLogic.GetPatenteByNombre(nombrePatente);

                    if (patente != null && patente.Id != Guid.Empty) // Verifica que la patente exista
                    {
                        // Registrar la patente al usuario en la base de datos usando el repository
                        patenteLogic.Add(usuario.IdUsuario, patente.Id);

                        // Actualizar los ListBox después de agregar la patente
                        listPatentesElegidas.Items.Add(patente.Nombre);
                        listPatentesAElegir.Items.Remove(nombrePatente); // Eliminar de la lista de patentes disponibles

                        MessageBox.Show("Patente agregada correctamente.");
                        MessageBox.Show("Por favor, volver a ingresar al sistema para poder aplicar los cambios", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //LoggerService.WriteLogAcceso(new Log($"Patente {patente.Nombre} ha sido asignada al Usuario {usuario.UserName}", TraceLevel.Info));
                    }
                    else
                    {
                        MessageBox.Show("La patente no existe.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una patente para agregar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la patente: " + ex.Message);
            }
        }

        private void btnEliminarPatente_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!VerificarConexion())
                    return;
                Guid idUsuario = Guid.Parse(txtIdUsuario.Text);
                Usuario usuario = userLogic.GetById(idUsuario);

                if (listPatentesElegidas.SelectedItem != null)
                {
                    string nombrePatente = listPatentesElegidas.SelectedItem.ToString();

                    // Obtener la patente por su nombre
                    Patente patente = patenteLogic.GetPatenteByNombre(nombrePatente);

                    if (patente != null && patente.Id != Guid.Empty) // Verifica que la patente exista
                    {
                        // Si la patente es obligatoria, saltar
                        if (patente.Nombre == "Usuario" || patente.Nombre == "Gestionar Usuario")
                        {
                            MessageBox.Show("Esta patente no se puede eliminar.");
                        }
                        else
                        {
                            userLogic.EliminarUsuarioPatente(idUsuario, patente.Id);
                            // Eliminar la patente del usuario en la base de datos usando el repository
                            patenteLogic.Delete(usuario.IdUsuario, patente.Id); // Aquí debes implementar la lógica para eliminar la patente

                            // Actualizar los ListBox después de eliminar la patente
                            listPatentesElegidas.Items.Remove(nombrePatente); // Eliminar de la lista de patentes elegidas
                            listPatentesAElegir.Items.Add(nombrePatente); // Agregar de nuevo a la lista de patentes disponibles

                            MessageBox.Show("Patente eliminada correctamente.");
                            MessageBox.Show("Por favor, volver a ingresar al sistema para poder aplicar los cambios", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //LoggerService.WriteLogAcceso(new Log($"Patente {patente.Nombre} ha sido eliminada del Usuario {usuario.UserName}", TraceLevel.Info));
                        }
                    }
                    else
                    {
                        MessageBox.Show("La patente no existe.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una patente para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la patente: " + ex.Message);
            }
        }
    }
}
