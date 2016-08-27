using System;
using Controller;
using System.Windows.Forms;
using Model.Pessoa_e_Usuario;

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
            Txt_Tecnicos.DataSource = ControllerUsuario.CarregarListaDeNomes();
        }

        private void Btm_Salvar_Click(object sender, EventArgs e)
        {
            string saida = "";

            //Salvando e passando o resulado para a saida.
            saida = ControllerUsuario.Editar(Txt_Login.Text, Txt_Senha.Text, VerificarTipo());

            Txt_Login.Clear();
            Txt_Senha.Clear();
            Txt_Tipo.Text = " ";


            MessageBox.Show(String.Format("{0}", saida), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Btm_Pesquisar_Click(object sender, EventArgs e)
        {
                tecnico UsuarioBase = new tecnico();

                UsuarioBase  = ControllerUsuario.Carregar(Txt_Tecnicos.Text);

                Txt_Login.Text = UsuarioBase.Nome;
                Txt_Senha.Text = UsuarioBase.Senha;
                Txt_Tipo.Text = RetornarTipo(UsuarioBase);
        }

        private string RetornarTipo(tecnico Informacoes)
        {
            if (Informacoes.NivelAcesso == true)
            {
                return "Administrador";
            }
            else
            {
                return "Técnico";
            }
        }

        private bool VerificarTipo()
        {
            if (Txt_Tipo.Text == "Administrador")
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
