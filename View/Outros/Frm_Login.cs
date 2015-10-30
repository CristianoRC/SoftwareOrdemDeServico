using System;
using System.IO;
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
            if (MessageBox.Show("Deseja realmente sair", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void bTM_lOGAR_Click(object sender, EventArgs e)
        {
            Model.Pessoa_e_Usuario.Usuario UsuarioBase = new Model.Pessoa_e_Usuario.Usuario();

            if (UsuarioBase.Verificar(Txt_Login.Text))
            {
                //Chamando o load para atualizar as informações
                UsuarioBase = UsuarioBase.Load(Txt_Login.Text);

                if (UsuarioBase.Senha == Txt_Senha.Text)
                {
                    Frm_Pai Pai = new Frm_Pai(UsuarioBase.Nome, UsuarioBase.NivelAcesso);

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
            this.Visible = false;
        }

        private void Frm_Login_Load(object sender, EventArgs e)
        {
            /*
                Se o arquivo "Logo1.png" existir ele ira apagar o "logo.png" e mudar o nome do logo1 para "Logo.png".

                Isso acontecera quando o usuario tenha trocado o logo da empresa e já existir um antigo.
                Na hora de salvar se já existir um logo antigo ele ira salvar com o nome de logo1.
            */

            if (File.Exists("Logo1.png"))
            {
                if (File.Exists("Logo.png"))
                {
                    File.Delete("Logo.png");

                    //Problemas em renomear arquivo então faz uma cópia e deleta o antigo.
                    File.Copy("Logo1.png", "Logo.png");
                    File.Delete("Logo1.png");
                }
            }


            //Carregando o logo para empresa
            if (File.Exists("Logo.png"))
            {
                //Carregando o logo da empresa para o PictureBox
                pictureBox1.ImageLocation = "Logo.png";
            }
        }
    }
}
