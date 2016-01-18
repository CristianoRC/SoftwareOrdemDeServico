using System;
using Controller;
using System.Windows.Forms;

namespace View
{
    public partial class Frm_ExcluirOrcamento : Form
    {
        public Frm_ExcluirOrcamento()
        {
            InitializeComponent();
        }

        private void Btm_Excluir_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(Txt_OS.Text)) //Verifica se o valor do txt é nulo ou em branco
            {
                if (ControllerOrcamento.Verificar(Txt_OS.Text))
                {
                    if (MessageBox.Show("Você realmente deseja excluir?", "Excluir?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//Verifica se a pessoa quer realmente excluir a Ormde de serviço.
                    {
                        string saida = ControllerOrcamento.Excluir(Txt_OS.Text);

                        MessageBox.Show(saida, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Txt_OS.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Orçamento de serviço não encontrado!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Insira o numero do orçamento corretamente! ", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
