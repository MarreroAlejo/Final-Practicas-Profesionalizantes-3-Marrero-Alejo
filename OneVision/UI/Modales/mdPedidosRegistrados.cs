using DOMAIN;
using LOGIC;
using SERVICES.Domain.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static DOMAIN.Pedido;


namespace UI.Modales
{
    public partial class mdPedidosRegistrados : Form
    {
        public Pedido _Pedido { get; set; }
        private PedidoLogic pedidoLogic;
        private ClienteLogic clienteLogic;
        private EmpleadoLogic empleadoLogic;
        private VentaLogic ventaLogic;
        private Usuario usuarioActual;

        public mdPedidosRegistrados(Usuario usuario)
        {
            InitializeComponent();
            this.usuarioActual = usuario;
            pedidoLogic = PedidoLogic.GetInstance();
            clienteLogic = ClienteLogic.GetInstance();
            empleadoLogic = EmpleadoLogic.GetInstance();
            ventaLogic = VentaLogic.GetInstance();
        }

        private void mdPedidosRegistrados_Load(object sender, EventArgs e)
        {
            // Configurar ComboBox de búsqueda
            cmbBusqueda.Items.Clear();
            foreach (DataGridViewColumn columna in DgwData.Columns)
            {
                if (columna.Visible)
                {
                    cmbBusqueda.Items.Add(columna.Name);
                }
            }

            // Obtener y filtrar la lista de pedidos: solo los registrados y sin venta asociada
            List<Pedido> lista = pedidoLogic.GetAll()
                .Where(p => p.Estado == Pedido.EstadoPedido.Registrado && !ventaLogic.VentaAsociadaAPedido(p.IdPedido))
                .ToList();

            // Llenar el DataGridView y asociar el objeto Pedido a cada fila
            foreach (Pedido item in lista)
            {
                Cliente cliente = clienteLogic.GetById(item.IdCliente);
                int clienteId = cliente?.IdCliente ?? 0;

                int rowIndex = DgwData.Rows.Add(new object[]
                {
            item.IdPedido,
            item.NroPedido,
            clienteId,  // Almacenar el IdCliente en la fila
            cliente != null ? cliente.Nombre + " " + cliente.Apellido : "Cliente no encontrado", // Nombre completo
            item.FechaRegistro,
            item.Estado,
                });

                // Asocia el objeto Pedido a la fila para facilitar su recuperación
                DgwData.Rows[rowIndex].Tag = item;
            }
        }

        private void DgwData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = DgwData.Rows[e.RowIndex];
                // Recupera el objeto Pedido que se asoció a la fila
                Pedido pedido = fila.Tag as Pedido;
                if (pedido != null)
                {
                    _Pedido = pedido;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo obtener la información del pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
    }
}
