using System;
using System.Collections.Generic;
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
            string saida = "";

            if (!UsuarioBase.Verificar(Txt_Login.Text))
            {
                //Salvando e passando o resulado para a saida.
                saida = UsuarioBase.Save(Txt_Login.Text, Txt_Senha.Text, Txt_Tipo.Text);

                Txt_Login.Clear();
                Txt_Senha.Clear();
                Txt_Tipo.Text = " ";
            }
            else
            {
                saida = "Usuario já cadastrado!";
            }



            MessageBox.Show(String.Format("{0}", saida), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Btm_Pesquisar_Click(object sender, EventArgs e)
        {
            Model.Pessoa_e_Usuario.Usuario UsuarioBase = new Model.Pessoa_e_Usuario.Usuario();
            List<string> ListaResultante = new List<string>();

            if (UsuarioBase.Verificar(Txt_Pesquisa.Text))
            {
                ListaResultante =  UsuarioBase.Load(Txt_Pesquisa.Text);

                Txt_Login.Text = ListaResultante[0];
                Txt_Senha.Text = ListaResultante[1];
                Txt_Tipo.Text  = ListaResultante[2];
            }
            else
            {
                MessageBox.Show("Usuário não encontrado!","Informação",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
