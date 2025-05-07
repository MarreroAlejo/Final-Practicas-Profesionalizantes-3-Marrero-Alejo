using DOMAIN;
using LOGIC;
using LOGIC.Exceptions.ProductoExceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static DOMAIN.Producto;

namespace UI.Modales
{
    public partial class mdProducto : Form
    {

        public Producto _Producto { get; set; }
        private ProductoLogic productoLogic;
        public mdProducto()
        {
            InitializeComponent();
            productoLogic = ProductoLogic.GetInstance();
        }

        private void mdProducto_Load(object sender, EventArgs e)
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

            //MOSTRAR TODOS LOS PRODUCTOS
            List<Producto> lista = productoLogic.GetAll();
            foreach (Producto item in lista) //para cada rol en mi lista..
            {
                DgwData.Rows.Add(new object[]
                {   item.IdProducto,
                    item.CodProducto,
                    item.Nombre,
                    item.Descripcion,
                    item.Categoria,
                    item.PrecioVenta,
                    item.PrecioCompra,
                    item.Estado,
                });
            }
        }

        private void DgwData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;

            if (row >= 0 && col > 0)
            {
                _Producto = new Producto()
                {
                    IdProducto = Guid.TryParse(DgwData.Rows[row].Cells["id"].Value?.ToString(), out var id) ? id : Guid.Empty,
                    CodProducto = DgwData.Rows[row].Cells["Codigo"].Value?.ToString() ?? string.Empty,
                    Nombre = DgwData.Rows[row].Cells["Nombre"].Value?.ToString() ?? string.Empty,
                    Descripcion = DgwData.Rows[row].Cells["Descripcion"].Value?.ToString() ?? string.Empty,
                    Categoria = DgwData.Rows[row].Cells["Categoria"].Value?.ToString() ?? string.Empty,
                    PrecioVenta = Convert.ToDecimal(DgwData.Rows[row].Cells["PrecioVenta"].Value?.ToString()),
                    PrecioCompra = Convert.ToDecimal(DgwData.Rows[row].Cells["PrecioCompra"].Value?.ToString()),
                    Estado = int.TryParse(DgwData.Rows[row].Cells["Estado"].Value?.ToString(), out var estado) ? (Producto.EstadoProducto)estado : Producto.EstadoProducto.Suspendido
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si el campo de texto está vacío
                if (string.IsNullOrWhiteSpace(txtBuscador.Text))
                {
                    throw new CampoVacioException("El campo de búsqueda no puede estar vacío.");
                }

                string columnaFiltro = (cmbBusqueda.SelectedItem).ToString();

                if (DgwData.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in DgwData.Rows)
                    {
                        string valorCelda = row.Cells[columnaFiltro].Value?.ToString().Trim().ToUpper() ?? "";
                        string textoBuscado = txtBuscador.Text.Trim().ToUpper();

                        // Mostrar u ocultar filas según contengan el texto
                        row.Visible = valorCelda.Contains(textoBuscado);
                    }
                }
            }
            catch (CampoVacioException ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
