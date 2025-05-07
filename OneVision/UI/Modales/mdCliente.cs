using DOMAIN;
using LOGIC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Modales
{
    public partial class mdCliente : Form
    {
        public Cliente _Cliente { get; set; }
        private ClienteLogic clienteLogic;
        public mdCliente()
        {
            InitializeComponent();
            clienteLogic = ClienteLogic.GetInstance();
        }

        private void mdCliente_Load(object sender, EventArgs e)
        {
            // Limpia el ComboBox antes de cargar para evitar duplicados
            cmbBusqueda.Items.Clear();

            // Recorre las columnas del DataGridView
            foreach (DataGridViewColumn columna in DgwData.Columns)
            {
                // Agrega solo las columnas visibles al ComboBox
                if (columna.Visible)
                {
                    cmbBusqueda.Items.Add(columna.Name); // Agrega el nombre de la columna
                }
            }

            // MOSTRAR SOLO LOS CLIENTES ACTIVOS
            List<Cliente> lista = clienteLogic.GetAll();
            foreach (Cliente item in lista.Where(c => c.Estado == Cliente.EstadoCliente.Activo)) // Filtra solo los clientes activos
            {
                DgwData.Rows.Add(new object[]
                {
            item.IdCliente,
            item.NroDocumento,
            item.Nombre,
            item.Apellido,
            item.Direccion,
            item.CodPostal,
            item.Telefono,
            item.Mail,
            item.Barrio,
            item.Provincia,
            item.FechaRegistro,
            item.Estado,
                });
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = (cmbBusqueda.SelectedItem).ToString();

            if (DgwData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in DgwData.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBuscador.Text.Trim().ToUpper()))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscador.Text = "";
            foreach (DataGridViewRow row in DgwData.Rows)
            {
                row.Visible = true;
            }
        }

        private void DgwData_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;

            if (row >= 0 && col > 0)
            {
                _Cliente = new Cliente()
                {
                    IdCliente = int.TryParse(DgwData.Rows[row].Cells["id"].Value?.ToString(), out var id) ? id : 0,
                    NroDocumento = int.TryParse(DgwData.Rows[row].Cells["NroDocumento"].Value?.ToString(), out var nroDocumento) ? nroDocumento : 0,
                    Nombre = DgwData.Rows[row].Cells["Nombre"].Value?.ToString() ?? string.Empty,
                    Apellido = DgwData.Rows[row].Cells["Apellido"].Value?.ToString() ?? string.Empty,
                    Direccion = DgwData.Rows[row].Cells["Direccion"].Value?.ToString() ?? string.Empty,
                    CodPostal = int.TryParse(DgwData.Rows[row].Cells["CodPostal"].Value?.ToString(), out var codPostal) ? codPostal : 0,
                    Telefono = DgwData.Rows[row].Cells["Telefono"].Value?.ToString() ?? string.Empty,
                    Mail = DgwData.Rows[row].Cells["Mail"].Value?.ToString() ?? string.Empty,
                    Barrio = DgwData.Rows[row].Cells["Barrio"].Value?.ToString() ?? string.Empty,
                    Provincia = DgwData.Rows[row].Cells["Provincia"].Value?.ToString() ?? string.Empty,
                    FechaRegistro = DateTime.TryParse(DgwData.Rows[row].Cells["FechaRegistro"].Value?.ToString(), out var fechaRegistro) ? fechaRegistro : DateTime.MinValue,
                    Estado = int.TryParse(DgwData.Rows[row].Cells["Estado"].Value?.ToString(), out var estado) ? (Cliente.EstadoCliente)estado : Cliente.EstadoCliente.Suspendido
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            string columnaFiltro = (cmbBusqueda.SelectedItem).ToString();

            if (DgwData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in DgwData.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBuscador.Text.Trim().ToUpper()))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
        }
    }
}
