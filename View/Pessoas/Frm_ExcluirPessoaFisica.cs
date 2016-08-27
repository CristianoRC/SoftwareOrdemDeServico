using System;
using System.Windows.Forms;
using Controller;

namespace View.Pessoas
{
    public partial class Frm_ExcluirPessoaFisica : Form
    {
        public Frm_ExcluirPessoaFisica()
        {
            InitializeComponent();
        }

        private void Btm_Excluir_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Você realmente deseja excluir?", "Excluir?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//Verifica se a pessoa quer realmente excluir a Ormde de serviço.
            {
                string saida = ControllerPessoa.Deletar(Txt_Pessoa.Text);

                MessageBox.Show(saida, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Txt_Pessoa.DataSource = ControllerPessoa.CarregarLista();
                Txt_Pessoa.Refresh();
            }
        }

        private void Frm_ExcluirPessoaFisica_Load(object sender, EventArgs e)
        {
            Txt_Pessoa.DataSource = ControllerPessoa.CarregarLista();
        }
    }
}
