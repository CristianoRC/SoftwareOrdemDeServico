using System;
using System.Windows.Forms;
using Controller;
using System.Data;

namespace View.Servicos
{
    public partial class Frm_ExcluirServico : Form
    {
        public Frm_ExcluirServico()
        {
            InitializeComponent();
        }

        private void Btm_Excluir_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Txt_IDPesquisa.Text))
            {
                String Saida = ControllerServico.Deletar(Convert.ToInt16(Txt_IDPesquisa.Text));

                MessageBox.Show(Saida, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AtualizarLista();
            }
            else
            {
                MessageBox.Show("Insira um valor", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_ExcluirServico_Load(object sender, EventArgs e)
        {
            AtualizarLista();

        }

        private void AtualizarLista()
        {
            Txt_IDPesquisa.Items.Clear();

            DataTable Tabela = new DataTable("Servicos");

            Tabela = ControllerServico.CarregarListaDeIdsDasOrdensDeServico();

            if (Tabela.Rows.Count != 0)
            {
                foreach (DataRow r in Tabela.Rows)
                {
                    foreach (DataColumn c in Tabela.Columns)
                    {
                        Txt_IDPesquisa.Items.Add(r[c].ToString());
                    }
                }

                Txt_IDPesquisa.Text = Txt_IDPesquisa.Items[0].ToString();
            }
        }
    }
}

