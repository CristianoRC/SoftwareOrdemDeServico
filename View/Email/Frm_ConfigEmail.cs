using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //TODO: Arrumar um modo de critografar a senha no arquivo de Dat.
            Model.Email EmailBase = new Model.Email();
            EmailBase.EnderecoEmail = Txt_Email.Text;
            EmailBase.Senha = Txt_Senha.Text;
            EmailBase.Host = Txt_Host.Text;
            EmailBase.Port = int.Parse(Txt_Porta.Text);
            EmailBase.SaveConfig(EmailBase.EnderecoEmail, EmailBase.Senha, EmailBase.Host, EmailBase.Port);

            MessageBox.Show(EmailBase.SaveConfig(EmailBase.EnderecoEmail, EmailBase.Senha, EmailBase.Host, EmailBase.Port),"Informação",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //Mostrando o resultado da Função SaveConfig();
        }

        private void Frm_ConfigEmail_Load(object sender, EventArgs e)
        {
            //Carregando informações do arquivo.
            Model.Email EmailBase = new Model.Email();
            EmailBase = EmailBase.LoadConfig();

            Txt_Email.Text = EmailBase.EnderecoEmail;
            Txt_Senha.Text = EmailBase.Senha;
            Txt_Host.Text = EmailBase.Host;
            Txt_Porta.Text = EmailBase.Port.ToString();
        }
    }
}
