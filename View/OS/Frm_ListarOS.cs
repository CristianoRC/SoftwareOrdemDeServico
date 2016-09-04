using System;
using Model.Ordem_de_Servico;
using System.Windows.Forms;
using Controller;

namespace View.OS
{
    public partial class Frm_ListarOS : Form
    {
        public Frm_ListarOS()
        {
            InitializeComponent();
        }

        private void Frm_ListarOS_Load(object sender, EventArgs e)
        {
            Data_Os.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            Data_Os.DataSource = ControllerOrdemServico.CarregarLista();
        }
    }
}
