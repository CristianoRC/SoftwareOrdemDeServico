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
            ControllerOrdemServico controllerOS = new ControllerOrdemServico();

            if (!string.IsNullOrWhiteSpace(Txt_OS.Text)) //Verifica se o valor do txt é nulo ou em branco
            {
                if (controllerOS.Verificar(Txt_OS.Text))
                {
                    if (MessageBox.Show("Você realmente deseja excluir?", "Excluir?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//Verifica se a pessoa quer realmente excluir a Ormde de serviço.
                    {
                       string saida = controllerOS.Excluir(Txt_OS.Text);

                        MessageBox.Show(saida, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Txt_OS.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Ordem de serviço não encontrada!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Insira o numero da ordem de seviço corretamente! ", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
