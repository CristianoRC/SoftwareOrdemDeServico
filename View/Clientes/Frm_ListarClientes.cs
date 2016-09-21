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

        private void AtualizarLista()
        {
            Data_Os.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Data_Os.DataSource = ControllerPessoa.CarregarLista();
        }

        private void Btm_Atualizar_Click(object sender, EventArgs e)
        {
            AtualizarLista();
        }

        private void Frm_ListarClientes_Load(object sender, EventArgs e)
        {
            AtualizarLista();
        }

        private void Data_Os_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int IdCliente = int.Parse(Data_Os.CurrentRow.Cells[0].Value.ToString());

            Frm_Clientes frm_Clientes = new Frm_Clientes(IdCliente);

            frm_Clientes.ShowDialog();
        }
    }
}
