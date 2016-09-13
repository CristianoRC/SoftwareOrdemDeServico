using System;
using Model.Ordem_de_Servico;
using System.Windows.Forms;
using Controller;

namespace View.OS
{
    public partial class Frm_ListarOS : Form
    {
        public Frm_ListarOS(int IdTecnico)
        {
            InitializeComponent();

            v_IDTecnico = IdTecnico;
        }

        private int v_IDTecnico;

        private void Frm_ListarOS_Load(object sender, EventArgs e)
        {
            AualizarLista();
        }

        private void AualizarLista()
        {
            Data_Os.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            Data_Os.DataSource = ControllerOrdemServico.CarregarLista();
        }

        private void Btm_Atualizar_Click(object sender, EventArgs e)
        {
            AualizarLista();
        }

        private void Data_Os_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int IdOs = int.Parse(Data_Os.CurrentRow.Cells[0].Value.ToString());
            Frm_EditarOS frm_Editaros = new Frm_EditarOS(v_IDTecnico, IdOs);

            frm_Editaros.ShowDialog();
        }
    }
}
