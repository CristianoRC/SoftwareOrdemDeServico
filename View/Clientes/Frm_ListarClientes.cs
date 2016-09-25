using Controller;
using System;
using System.Windows.Forms;

namespace View.Pessoas
{
    public partial class Frm_ListarClientes : Form
    {
        public Frm_ListarClientes()
        {
            InitializeComponent();
        }

        private void AtualizarInformacoesDoGrid()
        {
            Data_Os.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Data_Os.DataSource = ControllerPessoa.CarregarLista();

            if (Data_Os.Rows.Count != 0)
            {
                Data_Os.Columns[4].HeaderText = "Estado";
            }
        }

        private void Btm_Atualizar_Click(object sender, EventArgs e)
        {
            AtualizarInformacoesDoGrid();
        }

        private void Frm_ListarClientes_Load(object sender, EventArgs e)
        {
            AtualizarInformacoesDoGrid();
        }

        private void Data_Os_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int IdCliente = int.Parse(Data_Os.CurrentRow.Cells[0].Value.ToString());

            Frm_Clientes frm_Clientes = new Frm_Clientes(IdCliente);

            frm_Clientes.ShowDialog();
        }
    }
}
