using DOMAIN;
using LOGIC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static DOMAIN.Pedido;

namespace UI.Modales
{
    public partial class mdPedido : Form
    {
        public Pedido _Pedido { get; set; }
        private PedidoLogic pedidoLogic;
        private ClienteLogic clienteLogic;

        public mdPedido()
        {
            InitializeComponent();
            pedidoLogic = PedidoLogic.GetInstance();
            clienteLogic = ClienteLogic.GetInstance();
        }

        private void mdPedido_Load(object sender, EventArgs e)
        {
            cmbBusqueda.Items.Clear();
            foreach (DataGridViewColumn columna in DgwData.Columns)
            {
                if (columna.Visible)
                {
                    cmbBusqueda.Items.Add(columna.Name);
                }
            }
            List<Pedido> lista = pedidoLogic.GetAll();
            foreach (Pedido item in lista)
            {
                Cliente cliente = clienteLogic.GetById(item.IdCliente);
                int clienteId = cliente?.IdCliente ?? 0;

                DgwData.Rows.Add(new object[]
                {
                    item.IdPedido,
                    item.NroPedido,
                    clienteId,  // Almacenar el IdCliente en la fila
                    cliente != null ? cliente.Nombre + " " + cliente.Apellido : "Cliente no encontrado", // Mostrar nombre y apellido
                    item.FechaRegistro,
                    item.Estado,
                });
            }
        }

        private void DgwData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;

            if (row >= 0)
            {
                var idPedidoValue = DgwData.Rows[row].Cells["id"].Value?.ToString();
                Guid idPedido = Guid.TryParse(idPedidoValue, out var id) ? id : Guid.Empty;
                int nroPedido = (int)DgwData.Rows[row].Cells["nroPedido"].Value;
                var idCliente = (int)DgwData.Rows[row].Cells["IdCliente"].Value;
                var nombreCliente = DgwData.Rows[row].Cells["NombreCliente"].Value;
                var fechaRegistro = (DateTime)DgwData.Rows[row].Cells["FechaRegistro"].Value;
                string estadoValue = DgwData.Rows[row].Cells["Estado"].Value.ToString();

                _Pedido = new Pedido()
                {
                    IdPedido = idPedido,
                    NroPedido = nroPedido,
                    IdCliente = idCliente,
                    FechaRegistro = fechaRegistro,
                    Estado = (Pedido.EstadoPedido)Enum.Parse(typeof(Pedido.EstadoPedido), estadoValue)
                };

                if (_Pedido.IdCliente == 0)
                {
                    MessageBox.Show("El cliente no tiene un ID válido.");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
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
