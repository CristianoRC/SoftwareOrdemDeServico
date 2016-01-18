using System;
using System.Windows.Forms;
using Controller;

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
            if (!string.IsNullOrWhiteSpace(Txt_OS.Text)) //Verifica se o valor do txt é nulo ou em branco
            {
                if (ControllerServico.Verificar(Txt_OS.Text))
                {
                    if (MessageBox.Show("Você realmente deseja excluir?", "Excluir?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//Verifica se a pessoa quer realmente excluir a Ormde de serviço.
                    {
                        string saida = ControllerServico.Excluir(Txt_OS.Text);

                        MessageBox.Show(saida, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Txt_OS.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Serviço não encontrado!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Insira o numero do seviço corretamente! ", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
