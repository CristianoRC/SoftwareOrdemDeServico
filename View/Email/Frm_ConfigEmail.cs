using System;
using Controller;
using System.Windows.Forms;

namespace View
{
    public partial class Frm_ConfigEmail : Form
    {
        public Frm_ConfigEmail()
        {
            InitializeComponent();
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Model.Email EmailBase = new Model.Email();
            ControllerEmail controllerEmail = new ControllerEmail();

            EmailBase.EnderecoEmail = Txt_Email.Text;
            EmailBase.Senha = Txt_Senha.Text;
            EmailBase.Host = Txt_Host.Text;
            EmailBase.Port = int.Parse(Txt_Porta.Text);
            controllerEmail.SaveConfig(EmailBase.EnderecoEmail, EmailBase.Senha, EmailBase.Host, EmailBase.Port);

            MessageBox.Show(controllerEmail.SaveConfig(EmailBase.EnderecoEmail, EmailBase.Senha, EmailBase.Host, EmailBase.Port), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Mostrando o resultado da Função SaveConfig();
        }

        private void Frm_ConfigEmail_Load(object sender, EventArgs e)
        {
            //Carregando informações do arquivo.
            ControllerEmail controllerEmail = new ControllerEmail();

            Model.Email EmailBase = new Model.Email();
            EmailBase = controllerEmail.LoadConfig();

            Txt_Email.Text = EmailBase.EnderecoEmail;
            Txt_Senha.Text = EmailBase.Senha;
            Txt_Host.Text = EmailBase.Host;
            Txt_Porta.Text = EmailBase.Port.ToString();
        }
    }
}
