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
            if (MessageBox.Show("Você deseja realmente excluir esse usuário?","Verificação",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ControllerUsuario.Deletar(Txt_Tecnicos.Text);

                MessageBox.Show("Usuário deletado com sucesso!","Informação",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void Frm_ExcluirUsuario_Load(object sender, EventArgs e)
        {
            Txt_Tecnicos.DataSource = ControllerUsuario.CarregarListaDeNomes();
        }
    }
}
