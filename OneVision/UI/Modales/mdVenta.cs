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
    public partial class mdVenta : Form
    {

        public Venta _Venta { get; set; }
        private VentaLogic ventaLogic;
        
        public mdVenta()
        {
            InitializeComponent();
            ventaLogic = VentaLogic.GetInstance();
        }

        private void mdVenta_Load(object sender, EventArgs e)
        {
            cmbBusqueda.Items.Clear();
            foreach (DataGridViewColumn columna in DgwData.Columns)
            {
                if (columna.Visible)
                {
                    cmbBusqueda.Items.Add(columna.Name);
                }
            }

            // Obtener todas las ventas y ordenarlas por NroVenta de mayor a menor
            List<Venta> lista = ventaLogic.GetAll().OrderByDescending(v => v.NroVenta).ToList();

            foreach (Venta item in lista)
            {
                Pedido pedido = PedidoLogic.GetInstance().GetByGuid(item.IdPedido);
                DgwData.Rows.Add(new object[]
                {
            item.IdVenta,
            item.NroVenta,
            pedido.IdPedido,
            pedido.NroPedido,
            item.ValorFlete,
            item.Total,
            item.Estado,
            item.FechaRegistro,
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

        private void DgwData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;

            if (row >= 0 && col > 0)
            {
                var idVentaValue = DgwData.Rows[row].Cells["id"].Value?.ToString();
                Guid idVenta = Guid.TryParse(idVentaValue, out var id) ? id : Guid.Empty;

                int nroVenta = Convert.ToInt32(DgwData.Rows[row].Cells["NroVenta"].Value);

                var idPedidoValue = DgwData.Rows[row].Cells["idPedido"].Value?.ToString();
                Guid idPedido = Guid.TryParse(idPedidoValue, out var idP) ? idP : Guid.Empty;
                int nroPedido = Convert.ToInt32(DgwData.Rows[row].Cells["NroPedido"].Value);
                var flete = DgwData.Rows[row].Cells["Flete"].Value;
                var total = DgwData.Rows[row].Cells["Total"].Value;
                var fechaRegistro = (DateTime)DgwData.Rows[row].Cells["FechaRegistro"].Value;
                string estadoValue = DgwData.Rows[row].Cells["Estado"].Value.ToString();

                _Venta = new Venta()
                {
                    IdVenta = idVenta,
                    NroVenta = nroVenta,
                    IdPedido = idPedido,
                    ValorFlete = Convert.ToDecimal(flete),
                    Total = Convert.ToDecimal(total),
                    Estado = (Venta.EstadoVenta)Enum.Parse(typeof(Venta.EstadoVenta), estadoValue),
                    FechaRegistro = fechaRegistro,
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }
    }
}
