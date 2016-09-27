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
            
            if (!string.IsNullOrWhiteSpace(Txt_Porta.Text))
            {
                Model.Email EmailBase = new Model.Email();

                EmailBase.email = Txt_Email.Text;
                EmailBase.Senha = Txt_Senha.Text;
                EmailBase.Host = Txt_Host.Text;
                EmailBase.Port = int.Parse(Txt_Porta.Text);

                if (ControllerEmail.VerificarInformacoesDoServidorSMTP(EmailBase))
                {
                    string saida = ControllerEmail.SalvarInformacoesLoginServidor(EmailBase.email, EmailBase.Senha, EmailBase.Host, EmailBase.Port);

                    MessageBox.Show(saida, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Informações do servidor SMTP inválidos, verifique seu Login/Senha e as informações do seu servidor.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Insira um valor válido para a porta do seu servidor", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Frm_ConfigEmail_Load(object sender, EventArgs e)
        {
            //Carregando informações do arquivo.

            Model.Email EmailBase = new Model.Email();
            EmailBase = ControllerEmail.CarregarInformacoesLoginServidor();

            Txt_Email.Text = EmailBase.email;
            Txt_Senha.Text = EmailBase.Senha;
            Txt_Host.Text = EmailBase.Host;
            Txt_Porta.Text = EmailBase.Port.ToString();
        }
    }
}
