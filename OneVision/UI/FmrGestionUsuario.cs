using LOGIC;
using SERVICES.Domain.Composite;
using SERVICES.Facade.Extentions;
using SERVICES.Logic;
using SERVICES.Logic.Exceptions.EmpleadoExceptions;
using SERVICES.Logic.Exceptions.UserExceptions;
using SERVICES.Observer;
using System;
using System.Windows.Forms;

namespace UI
{
    public partial class FmrGestionUsuario : Form, IObserver
    {
        private Usuario usuarioActual; // Variable para almacenar el usuario actual
        private UserLogic usuarioLogic;
        private EmpleadoLogic empleadoLogic;

        public FmrGestionUsuario(Usuario usuario)
        {
            this.usuarioActual = usuario;
            usuarioLogic = UserLogic.GetInstance();
            empleadoLogic = EmpleadoLogic.GetInstance();
            InitializeComponent();
            LanguageNotifier.Instance.RegisterObserver(this);
            Update();
        }

        public new void Update()
        {
            TraducirTextoControles();
        }

        private void TraducirTextoControles()
        {
            label1.Text = StringExtention.Translate("Gestion de Usuarios");
            lblnombreusuario.Text = StringExtention.Translate("Nombre Usuario");
            lblcontraseña.Text = StringExtention.Translate("Contraseña");
            lblnombre.Text = StringExtention.Translate("Nombre");
            lblapellido.Text = StringExtention.Translate("Apellido");
            lblmail.Text = StringExtention.Translate("Mail");
            lbltelefono.Text = StringExtention.Translate("Teléfono");

            groupBoxUsuario.Text = StringExtention.Translate("Datos de Usuario");
            groupBoxNegocio.Text = StringExtention.Translate("Datos de Negocio");

            btnGuardar.Text = StringExtention.Translate("Guardar");
            btnCancelar.Text = StringExtention.Translate("Cancelar");
        }

        private void CargarDatos()
        {
            TrimAllTextBoxes(this);
            CargarTextBoxUsuario();
            CargarTextBoxEmpleado();
        }

        private void FmrGestionUsuario_Load(object sender, EventArgs e)
        {
            CargarDatos();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarTextBoxUsuario()
        {
            txtIdUsuario.Text = usuarioActual.IdUsuario.ToString();
            txtUsername.Text = usuarioActual.UserName.ToString();
            txtContraseña.Text = usuarioActual.Password.ToString();
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


        private void CargarTextBoxEmpleado()
        {
            try
            {
                Empleado empleado = empleadoLogic.GetEmpleadoPorUsuario(usuarioActual.IdUsuario);
                if (empleado != null)
                {
                    txtIdEmpleado.Text = empleado.IdEmpleado.ToString();
                    txtNombre.Text = empleado.Nombre;
                    txtApellido.Text = empleado.Apellido;
                    txtTelefono.Text = empleado.Telefono.ToString();
                    txtMail.Text = empleado.Mail;
                }
                else
                {
                    throw new EmpleadoNoEncontradoException();
                }
            }
            catch (EmpleadoNoEncontradoException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado al cargar los datos del empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private bool ValidarCampos()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                    string.IsNullOrWhiteSpace(txtContraseña.Text) ||
                    string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtApellido.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                    string.IsNullOrWhiteSpace(txtMail.Text))
                {
                    throw new CamposObligatoriosException();
                }
                return true;
            }
            catch (CamposObligatoriosException ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado al validar los campos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Guarda los cambios en los datos del usuario y del empleado, actualizando nombre de usuario y contraseña.
        /// Verifica que el nuevo nombre de usuario no esté en uso por otro usuario.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                // Limpiar espacios en blanco de los TextBox
                txtUsername.Text = txtUsername.Text.Trim();
                txtContraseña.Text = txtContraseña.Text.Trim();
                txtNombre.Text = txtNombre.Text.Trim();
                txtApellido.Text = txtApellido.Text.Trim();
                txtTelefono.Text = txtTelefono.Text.Trim();
                txtMail.Text = txtMail.Text.Trim();

                // Actualizar los datos del usuario (usuarioActual) con los valores de los TextBox
                usuarioActual.UserName = txtUsername.Text;
                usuarioActual.Password = txtContraseña.Text; // Si es necesario, aplicar hash aquí

                // Verificar que el nombre de usuario no esté ya en uso por otro usuario
                Usuario userExistente = usuarioLogic.SelectByUsername(usuarioActual.UserName);
                if (userExistente != null && userExistente.IdUsuario != usuarioActual.IdUsuario)
                {
                    throw new UsernameYaExisteException("El nombre de usuario ya está en uso por otro usuario.");
                }

                // Obtener el empleado asociado al usuario y actualizar sus datos
                Empleado empleado = empleadoLogic.GetEmpleadoPorUsuario(usuarioActual.IdUsuario);
                if (empleado == null)
                {
                    throw new EmpleadoNoEncontradoException();
                }

                empleado.Nombre = txtNombre.Text;
                empleado.Apellido = txtApellido.Text;
                empleado.Mail = txtMail.Text;
                empleado.Telefono = txtTelefono.Text;

                // Actualizar el usuario y el empleado en la base de datos
                usuarioLogic.EditarUsuario(usuarioActual);
                empleadoLogic.Editar(empleado);

                MessageBox.Show("Operación realizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (EmpleadoNoEncontradoException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UsernameYaExisteException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UsuarioNoEncontradoException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
