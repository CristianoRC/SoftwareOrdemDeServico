using System;
using System.Windows.Forms;
using Controller;

namespace View.OS
{
    public partial class Frm_ExcluirOS : Form
    {
        public Frm_ExcluirOS()
        {
            InitializeComponent();
        }

        private void Btm_Excluir_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Txt_Os.Text))
            {
                if (MessageBox.Show("Você realmente deseja excluir?", "Excluir?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//Verifica se a pessoa quer realmente excluir a Ormde de serviço.
                {
                    string saida = ControllerOrdemServico.Deletar(Convert.ToInt16(Txt_Os.Text));

                    MessageBox.Show(saida, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                AtualizarListaOS();
            }
            else
            {
                MessageBox.Show("Insira um valor", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_ExcluirOS_Load(object sender, EventArgs e)
        {
            AtualizarListaOS();
        }

        private void AtualizarListaOS()
        {
            Txt_Os.Items.Clear();

            System.Data.DataTable TabelaOS = new System.Data.DataTable();

            TabelaOS = ControllerOrdemServico.CarregarListaDeIds();

            if (TabelaOS.Rows.Count != 0)
            {
                foreach (System.Data.DataRow r in TabelaOS.Rows)
                {
                    foreach (System.Data.DataColumn c in TabelaOS.Columns)
                    {
                        Txt_Os.Items.Add(r[c].ToString());
                    }
                }
            }
        }
    }
}
