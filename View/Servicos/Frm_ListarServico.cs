using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Controller;

namespace View
{
    public partial class Frm_ListarServico : Form
    {
        public Frm_ListarServico()
        {
            InitializeComponent();
        }

        private void Frm_ListarServico_Load(object sender, EventArgs e)
        {
            AtualizarLista();
        }

        private void AtualizarLista()
        {
            Data_Os.Columns.Clear();

            Data_Os.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            Data_Os.DataSource = ControllerServico.CarregarLista();
        }

        private void Btm_Atualizar_Click(object sender, EventArgs e)
        {
            AtualizarLista();
        }
    }
}
