using System;
using System.Windows.Forms;
using Controller;

namespace View.Pessoas
{
    public partial class Frm_ExcluirPessoaJuridica : Form
    {
        public Frm_ExcluirPessoaJuridica()
        {
            InitializeComponent();
        }

        private void Btm_Excluir_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Txt_Nome.Text)) //Verifica se o valor do txt é nulo ou em branco
            {
                if (ControllerJuridica.Verificar(Txt_Nome.Text))
                {
                    if (MessageBox.Show("Você realmente deseja excluir?", "Excluir?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//Verifica se a pessoa quer realmente excluir a Ormde de serviço.
                    {
                        string saida = ControllerJuridica.Excluir(Txt_Nome.Text);

                        MessageBox.Show(saida, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Txt_Nome.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Pessoa juridica não encontrada!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Insira um nome! ", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
