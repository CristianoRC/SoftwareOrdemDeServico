using System;
using System.Windows.Forms;
using Controller;
using Model;

namespace View
{
    public partial class Frm_Servico : Form
    {
		//TODO: Carregar valor do orçamento aqui
        public Frm_Servico(string nomeDoTecnico)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Finalizando Ordem de serviço (Botão).
        /// </summary>
        private void finalizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Txt_IDPesquisa.Text))
            {
                String saida = ControllerOrdemServico.FinalizarOS(PreencherTrabalho());

                MessageBox.Show(saida, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Txt_IDPesquisa.Items.Clear();
                Txt_Descricao.Clear();
                Txt_Valor.Clear();

                atualizarListaDeOS();
            }
            else
            {
                MessageBox.Show("Escolha uma ordem de serviço!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Carregando o nome de todos os serviços e os adicionando no combo Box(Txt_Servicos).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Servico_Load(object sender, EventArgs e)
        {
            atualizarListaDeOS();
        }

        private void atualizarListaDeOS()
        {
            System.Data.DataTable TabelaOS = new System.Data.DataTable();

            TabelaOS = ControllerOrdemServico.CarregarListaDeIdsNaoFinalizados();

            foreach (System.Data.DataRow r in TabelaOS.Rows)
            {
                foreach (System.Data.DataColumn c in TabelaOS.Columns)
                {
                    Txt_IDPesquisa.Items.Add(r[c].ToString());
                }
            }
        }

        /// <summary>
        /// Preenchendo uma classe trabalho com as informações do Form.
        /// </summary>
        /// <returns>The trabalho.</returns>
        private Servico PreencherTrabalho()
        {
            Servico ServicoBase = new Servico();

            ServicoBase.IdOrdemDeServico = Convert.ToInt16(Txt_IDPesquisa.Text);
            ServicoBase.Valor = Convert.ToDecimal(Txt_Valor.Text);
            ServicoBase.Descricao = Txt_Descricao.Text;

            return ServicoBase;
        }

        private void Txt_Valor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))//Verifica se é numero
            {
                if (!(e.KeyChar == ',')) //Verifica se é Vírgula.
                {
                    e.Handled = true;
                }
            }
        }

        private void Btm_Limpar_Click(object sender, EventArgs e)
        {
            Txt_Valor.Clear();
        }
    }
}
