using System;
using System.Windows.Forms;
using Controller;

namespace View.Usuario
{
    public partial class Frm_ExcluirUsuario : Form
    {
        public Frm_ExcluirUsuario(String p_NomeUsuario)
        {
            InitializeComponent();

            LoginUsuarioAtual = p_NomeUsuario;
        }

        String LoginUsuarioAtual;

        private void Btm_Excluir_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Txt_Tecnicos.Text))
            {
                if (!VerificarLoginAtualComODaExclusao(Txt_Tecnicos.Text))
                {
                    if (MessageBox.Show("Você deseja realmente excluir esse usuário?", "Verificação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string Saida = ControllerUsuario.Deletar(Txt_Tecnicos.Text.Trim());

                        MessageBox.Show(Saida, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    AtualziarListaDeUsuarios();
                }
                else
                {
                    MessageBox.Show("Você não pdoe excluir o usuário que está logado!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Escolha um usuário!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Frm_ExcluirUsuario_Load(object sender, EventArgs e)
        {
            AtualziarListaDeUsuarios();
        }

        private void AtualziarListaDeUsuarios()
        {

            Txt_Tecnicos.Items.Clear();

            System.Data.DataTable tabela = new System.Data.DataTable();

            tabela = ControllerUsuario.CarregarListaDeNomes();
            if (tabela.Rows.Count != 0)
            {
                foreach (System.Data.DataRow r in tabela.Rows)
                {
                    foreach (System.Data.DataColumn c in tabela.Columns)
                    {
                        Txt_Tecnicos.Items.Add(r[c]);
                    }
                }
            }
        }

        /// <summary>
        /// Verifica se o login que esta sendo usado é o mesmo que vai ser excluido.
        /// </summary>
        /// <returns><c>true</c>, if login atual COM O da exclusao was verificared, <c>false</c> otherwise.</returns>
        /// <param name="LoginASerExcluido">Login A ser excluido.</param>
        private bool VerificarLoginAtualComODaExclusao(String LoginASerExcluido)
        {
            if (LoginASerExcluido.ToLower() == LoginUsuarioAtual.ToLower())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
