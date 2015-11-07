using System;
using Controller;
using System.Windows.Forms;

namespace View.Usuario
{
    public partial class Frm_EditUsu : Form
    {
        public Frm_EditUsu()
        {
            InitializeComponent();
        }

        private void Frm_EditUsu_Load(object sender, EventArgs e)
        {

        }

        private void Btm_Salvar_Click(object sender, EventArgs e)
        {

            Model.Pessoa_e_Usuario.Usuario UsuarioBase = new Model.Pessoa_e_Usuario.Usuario();
            ControllerUsuario controllerUsuario = new ControllerUsuario();
            string saida = "";

            //Salvando e passando o resulado para a saida.
            saida = controllerUsuario.Save(Txt_Login.Text, Txt_Senha.Text, Txt_Tipo.Text);

            Txt_Login.Clear();
            Txt_Senha.Clear();
            Txt_Tipo.Text = " ";


            MessageBox.Show(String.Format("{0}", saida), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Btm_Pesquisar_Click(object sender, EventArgs e)
        {
            Model.Pessoa_e_Usuario.Usuario UsuarioBase = new Model.Pessoa_e_Usuario.Usuario();
            ControllerUsuario controllerUsuario = new ControllerUsuario();

            if (controllerUsuario.Verificar(Txt_Pesquisa.Text))
            {
                UsuarioBase = controllerUsuario.Load(Txt_Pesquisa.Text);

                Txt_Login.Text = UsuarioBase.Nome;
                Txt_Senha.Text = UsuarioBase.Senha;
                Txt_Tipo.Text = UsuarioBase.NivelAcesso;
            }
            else
            {
                MessageBox.Show("Usuário não encontrado!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
