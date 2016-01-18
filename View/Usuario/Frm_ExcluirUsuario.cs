using System;
using System.Windows.Forms;
using Controller;

namespace View.Usuario
{
    public partial class Frm_ExcluirUsuario : Form
    {
        public Frm_ExcluirUsuario()
        {
            InitializeComponent();
        }

        private void Btm_Excluir_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Txt_Nome.Text)) //Verifica se o valor do txt é nulo ou em branco
            {
                if (ControllerUsuario.Verificar(Txt_Nome.Text))
                {
                    if (MessageBox.Show("Você realmente deseja excluir?", "Excluir?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//Verifica se a pessoa quer realmente excluir a Ormde de serviço.
                    {
                        string saida = ControllerUsuario.Excluir(Txt_Nome.Text);

                        MessageBox.Show(saida, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Txt_Nome.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Usuario não encontrada!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Insira um nome! ", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
