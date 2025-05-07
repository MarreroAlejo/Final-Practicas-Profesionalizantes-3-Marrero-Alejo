using SERVICES.Domain.Composite;
using SERVICES.Domain.Exceptions.UserExceptions;
using SERVICES.Facade;
using SERVICES.Logic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace UI
{
    public partial class FmrLogin : Form
    {
        private UserLogic userLogic = UserLogic.GetInstance();
        public FmrLogin()
        {
            InitializeComponent();
        }

        private void Fmr_Cerrando(object sender, FormClosingEventArgs e)
        {
            txtUsuario.Text = "";
            txtContraseña.Text = "";
            this.Show(); // metodo para volver a abrir el formulario de login
        }

        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            if (!VerificarConexion())
                return;
            try
            {
                string username = txtUsuario.Text.Trim();
                string password = txtContraseña.Text.Trim();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Por favor, ingresa un nombre de usuario y contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar credenciales (este método lanzará CredencialesInvalidasException si son incorrectas)
                Usuario usuario = userLogic.ValidarCredenciales(username, password);

                // Comparar el hash de la contraseña
                string epassword = EncryptLogic.GetSHA256(password);
                if (usuario.Password == epassword)
                {
                    UserSesion.Instance.IniciarSesion(usuario);

                    MessageBox.Show($"Bienvenido, {usuario.UserName}.");
                    List<string> patentes = UserLogic.Instance.ObtenerUsuarioPatentes(usuario.IdUsuario);
                    FrmMenu form = new FrmMenu(usuario, patentes);
                    form.Show();
                    this.Hide();

                    form.FormClosing += Fmr_Cerrando;
                }
            }
            catch (CredencialesInvalidasException)
            {
                // Registrar el intento fallido en la bitácora
                Log log = new Log(
                    $"Intento fallido de acceso para el usuario '{txtUsuario.Text.Trim()}'.",
                    TraceLevel.Error,
                    DateTime.Now
                );
                LoggerService.WriteLog(log);

                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "";
            txtContraseña.Text = "";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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



        private void FmrLogin_Load(object sender, EventArgs e)
        {
            VerificarConexion(); 
        }
    }
}