using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace View
{
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            InitializeComponent();
        }

        private void Btm_Sair_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Deseja realmente sair", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void bTM_lOGAR_Click(object sender, EventArgs e)
        {
            Model.Pessoa_e_Usuario.Usuario UsuarioBase = new Model.Pessoa_e_Usuario.Usuario();

            //Chamando o load para atualizar as informações
            UsuarioBase.Load(Txt_Login.Text);

            if (UsuarioBase.Verificar(Txt_Login.Text))                
            {
                if(UsuarioBase.Load(Txt_Login.Text)[1] == Txt_Senha.Text)
                {
                    Frm_Pai Pai = new Frm_Pai(UsuarioBase.Load(Txt_Login.Text)[0], UsuarioBase.Load(Txt_Login.Text)[2]);

                    this.Visible = false;

                    Pai.Show();
                }
                else
                {
                    MessageBox.Show("Senha incorreta", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Txt_Senha.Clear();
                }

            }
            else
            {
                MessageBox.Show("Usuário inválido!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Frm_Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
