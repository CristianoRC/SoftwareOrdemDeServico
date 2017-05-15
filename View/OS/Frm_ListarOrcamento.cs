using System;
using System.Windows.Forms;
using Controller;

namespace View.OS
{
    public partial class Frm_ListarOrcamento : Form
    {
        public Frm_ListarOrcamento(int IDTecnico)
        {
            InitializeComponent();

            v_IdTecnico = IDTecnico;
        }

        private int v_IdTecnico;

        private void Btm_Atualizar_Click(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        private void Frm_ListarOrcamento_Load(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            Data_Os.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Data_Os.DataSource = Controller.ControllerOrdemServico.CarregarListaOrcamentos();

            if (Data_Os.Rows.Count != 0)
            {
                Data_Os.Columns[2].HeaderText = "Numero de Serie";
                Data_Os.Columns[4].HeaderText = "Data de Entrada";
				Data_Os.Columns[5].HeaderText = "Valor do Orçamento";
            }
        }

        private void Data_Os_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int IdOs = int.Parse(Data_Os.CurrentRow.Cells[0].Value.ToString());
            Frm_EditarOS frm_Editaros = new Frm_EditarOS(v_IdTecnico, IdOs);

            frm_Editaros.ShowDialog();
        }

        private void Data_Os_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
