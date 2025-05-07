using SERVICES.Domain.Composite;
using SERVICES.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Verificar la conexión al iniciar la aplicación
            ConnectionManager.Instance.UpdateConnectionStatus();

            if (!ConnectionManager.Instance.IsConnected)
            {
                MessageBox.Show("No se pudo establecer conexión con alguna o ambas bases de datos. " +
                                "Por favor, verifica la configuración.",
                                "Error de Conexión",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                Application.Exit();
            }
            Application.Run(new FmrLogin());            
        }
        // FmrAdministradordeUsuarios(usuario)
        // FmrLogin()
    }
}
