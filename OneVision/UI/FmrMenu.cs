using FontAwesome.Sharp;
using SERVICES.Dao.Implementations;
using SERVICES.Domain.Composite;
using SERVICES.Facade;
using SERVICES.Facade.Extentions;
using SERVICES.Logic;
using SERVICES.Observer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FrmMenu : Form, IObserver
    {
        private static Form formulario_activo = null;
        private static IconMenuItem menu_activo = null;
        private Usuario usuarioActual;
        private UserLogic userLogic;
        string nameUICulture = Thread.CurrentThread.CurrentUICulture.Name;

        private List<string> patentesUsuario;

        public FrmMenu(Usuario usuario, List<string> patentes)
        {
            InitializeComponent();
            usuarioActual = usuario;
            patentesUsuario = patentes; // Guardar las patentes del usuario
            LanguageNotifier.Instance.RegisterObserver(this);
            Update();
            if (usuarioActual == null)
            {
                MessageBox.Show("No hay usuario logueado. Redirigiendo al login...");
                Application.Exit(); // O redirigir al formulario de login
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



        private void FrmMenu_Load(object sender, EventArgs e)
        {
            this.Refresh();
            TraducirTextoControles();
            lblUsuario.Text = usuarioActual.UserName;
            cmbIdioma.SelectedItem = "Español";
            VerificarConexion();
            // Ocultar menús según los permisos del usuario
            ConfigurarPermisos();
        }



        private void ConfigurarPermisos()
        {
            // Ocultar cada menú si el usuario no tiene permisos
            menuClientes.Visible = patentesUsuario.Contains("Clientes");
            submenuGestionarClientes.Visible = patentesUsuario.Contains("Gestionar Clientes");

            menuInventario.Visible = patentesUsuario.Contains("Inventario");
            submenuRegistrarProductos.Visible = patentesUsuario.Contains("Gestionar Productos");
            submenuRecepcionarProductos.Visible = patentesUsuario.Contains("Recepcionar Productos");

            menuPedidos.Visible = patentesUsuario.Contains("Pedidos");
            submenuGestionarPedidos.Visible = patentesUsuario.Contains("Gestionar Pedidos");

            menuVentas.Visible = patentesUsuario.Contains("Ventas");
            submenuGestionarVentas.Visible = patentesUsuario.Contains("Gestionar Ventas");

            menuReportes.Visible = patentesUsuario.Contains("Reportes");
            submenuReportePedidos.Visible = patentesUsuario.Contains("Reporte de Pedidos");

            menuUsuario.Visible = patentesUsuario.Contains("Usuario");
            submenuGestionarUsuario.Visible = patentesUsuario.Contains("Gestionar Usuario");

            menuAdministrador.Visible = patentesUsuario.Contains("Administrador");
            submenuAdministradorUsuarios.Visible = patentesUsuario.Contains("Administrar Usuarios");
            submenuAccesos.Visible = patentesUsuario.Contains("Gestionar Accesos");
            subMenuBackupRestore.Visible = patentesUsuario.Contains("BackUp-Restore");

        }

        private void cmbIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedLanguage = cmbIdioma.SelectedItem.ToString();

            if (selectedLanguage == "Español")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
            }
            else if (selectedLanguage == "Inglés")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-EN");
            }

            Log log = new Log(
            " Cambio de idioma a: " + Thread.CurrentThread.CurrentUICulture.Name,
            TraceLevel.Info,
            DateTime.Now
            );

            LoggerService.WriteLog(log);

            MessageBox.Show("Idioma actual: " + Thread.CurrentThread.CurrentUICulture.Name);
            // Notificar a los observadores (formularios suscritos)
            LanguageNotifier.Instance.NotifyObservers();
            TraducirTextoControles();
            this.Refresh();
        }

        private void TraducirTextoControles()
        {
            // Actualiza los textos de los labels, botones, etc.
            lblSesión.Text = StringExtention.Translate("Sesión de Usuario");
            menuClientes.Text = StringExtention.Translate("Clientes");
            submenuGestionarClientes.Text = StringExtention.Translate("Gestionar Clientes");
            menuInventario.Text = StringExtention.Translate("Inventario");
            submenuRegistrarProductos.Text = StringExtention.Translate("Gestionar Productos");
            submenuRecepcionarProductos.Text = StringExtention.Translate("Recepción de Productos");
            menuPedidos.Text = StringExtention.Translate("Pedidos");
            submenuGestionarPedidos.Text = StringExtention.Translate("Gestionar Pedidos");
            menuVentas.Text = StringExtention.Translate("Ventas");
            submenuGestionarVentas.Text = StringExtention.Translate("Gestionar Ventas");
            menuReportes.Text = StringExtention.Translate("Reportes");
            submenuReportePedidos.Text = StringExtention.Translate("Reporte de Pedidos");
            menuUsuario.Text = StringExtention.Translate("Usuario");
            submenuGestionarUsuario.Text = StringExtention.Translate("Gestionar Usuario");
            menuAdministrador.Text = StringExtention.Translate("Administrador");
            submenuAdministradorUsuarios.Text = StringExtention.Translate("Administrar Usuarios");
            submenuAccesos.Text = StringExtention.Translate("Administrar Accesos");
        }


        private void AbrirFormulario(IconMenuItem menu, Form formulario) //recibe el menu seleccionado y el formulario que se debe de abrir
        {
            if (menu_activo != null)
            {
                menu_activo.BackColor = Color.DarkSlateGray; //si dejamos de seleccionar el menu pasara a ser blanco nuevamente
            }
            menu.BackColor = Color.Silver; //si seleccionamos el menu pasara a ser silver
            menu_activo = menu;


            if (formulario_activo != null) //si hay un formulario abierto, lo cerramos para abrir otro
            {
                formulario_activo.Close();
            }
            formulario_activo = formulario;
            formulario.TopLevel = false; // no mostrarse como ventana superior
            formulario.FormBorderStyle = FormBorderStyle.None; //sin ningun borde
            formulario.Dock = DockStyle.Fill; //que el contenedor se acomode dentro del formulario
            formulario.BackColor = Color.DarkSlateGray; //damos color al formulario

            contenedor.Controls.Add(formulario_activo); //agregamos formulario al contenedor
            formulario.Show(); //mostramos formulario

        }

        private void submenuGestionarClientes_Click(object sender, EventArgs e)
        {
            var usuarioActual = UserSesion.Instance.UsuarioActual;
            if (usuarioActual != null)
            {
                // Usar el usuarioActual según sea necesario
                AbrirFormulario(menuClientes, new FmrGestionarClientes(usuarioActual));
            }
            else
            {
                MessageBox.Show("No hay usuario logueado.");
            }
        }

        private void submenuAdministradorUsuarios_Click(object sender, EventArgs e)
        {

            var usuarioActual = UserSesion.Instance.UsuarioActual;
            if (usuarioActual != null)
            {
                AbrirFormulario(menuAdministrador, new FmrAdministradordeUsuarios(usuarioActual));
            }
            else
            {
                MessageBox.Show("No hay usuario logueado.");
            }
        }

        private void submenuAccesos_Click(object sender, EventArgs e)
        {

            var usuarioActual = UserSesion.Instance.UsuarioActual;
            if (usuarioActual != null)
            {
                AbrirFormulario(menuAdministrador, new FmrAccesos(usuarioActual));
            }
            else
            {
                MessageBox.Show("No hay usuario logueado.");
            }
        }

        private void submenuRecepcionarProductos_Click(object sender, EventArgs e)
        {

            var usuarioActual = UserSesion.Instance.UsuarioActual;
            if (usuarioActual != null)
            {
                AbrirFormulario(menuInventario, new FmrRecepcionarProductos(usuarioActual));
            }
            else
            {
                MessageBox.Show("No hay usuario logueado.");
            }
        }

        private void submenuRegistrarProductos_Click(object sender, EventArgs e)
        {

            var usuarioActual = UserSesion.Instance.UsuarioActual;
            if (usuarioActual != null)
            {
                AbrirFormulario(menuInventario, new FmrGestionarProductos(usuarioActual));
            }
            else
            {
                MessageBox.Show("No hay usuario logueado.");
            }
        }

        private void submenuGenerarPedidos_Click(object sender, EventArgs e)
        {

            var usuarioActual = UserSesion.Instance.UsuarioActual;
            if (usuarioActual != null)
            {
                AbrirFormulario(menuPedidos, new FmrGestionarPedidos(usuarioActual));
            }
            else
            {
                MessageBox.Show("No hay usuario logueado.");
            }
        }

        private void submenuGestionarVentas_Click(object sender, EventArgs e)
        {

            var usuarioActual = UserSesion.Instance.UsuarioActual;
            if (usuarioActual != null)
            {
                AbrirFormulario(menuVentas, new FmrGestionarVentas(usuarioActual));
            }
            else
            {
                MessageBox.Show("No hay usuario logueado.");
            }
        }

        private void submenuReporteVentas_Click(object sender, EventArgs e)
        {

            var usuarioActual = UserSesion.Instance.UsuarioActual;
            if (usuarioActual != null)
            {
                AbrirFormulario(menuReportes, new FmrReportes(usuarioActual));
            }
            else
            {
                MessageBox.Show("No hay usuario logueado.");
            }
        }

        private void submenuGestionarUsuario_Click(object sender, EventArgs e)
        {
            var usuarioActual = UserSesion.Instance.UsuarioActual;
            if (usuarioActual != null)
            {
                AbrirFormulario(menuUsuario, new FmrGestionUsuario(usuarioActual));
            }
            else
            {
                MessageBox.Show("No hay usuario logueado.");
            }
        }

        private void subMenuBackupRestore_Click(object sender, EventArgs e)
        {
            var usuarioActual = UserSesion.Instance.UsuarioActual;
            if (usuarioActual != null)
            {
                AbrirFormulario(menuAdministrador, new FmrBackupRestore(usuarioActual));
            }
            else
            {
                MessageBox.Show("No hay usuario logueado.");
            }
        }

        private void btnLogOut_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show($"Usuario : {usuarioActual.UserName} ha abandonado el programa.");
            this.Close();
        }
    }
}
