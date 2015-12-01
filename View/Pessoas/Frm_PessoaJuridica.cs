using System;
using Controller;
using System.Windows.Forms;
using Model.Pessoa_e_Usuario;

namespace View.Pessoas
{
    public partial class Frm_PessoaJuridica : Form
    {
        public Frm_PessoaJuridica()
        {
            InitializeComponent();
        }

        private void Btm_Salvar_Click(object sender, EventArgs e)
        {
            Juridica PessoaJBase = new Juridica();
            ControllerJuridica controllerPJ = new ControllerJuridica();

            PessoaJBase.Nome = Txt_Nome.Text;
            PessoaJBase.Endereco = Txt_Endereco.Text;
            PessoaJBase.Email = Txt_Email.Text;
            PessoaJBase.Situacao = Txt_Situacao.Text;
            PessoaJBase.SiglaEstado = Txt_Estado.Text;
            PessoaJBase.Cidade = Txt_Cidade.Text;
            PessoaJBase.Bairro = Txt_Bairro.Text;
            PessoaJBase.Cep = Txt_Cep.Text;
            PessoaJBase.Observacoes = Txt_Observacoes.Text;

            //Parte de Pessoa Jurídica
            PessoaJBase.Cnpj = Txt_CNPJ.Text;
            PessoaJBase.Contato = Txt_Contato.Text;
            PessoaJBase.InscricaoEstadual = Txt_InscricaoEstadual.Text;
            PessoaJBase.RazaoSocial = Txt_RazaoSocial.Text;

            string saida = controllerPJ.Save(PessoaJBase.Nome, PessoaJBase.Endereco, PessoaJBase.Email, PessoaJBase.Situacao, PessoaJBase.SiglaEstado, PessoaJBase.Cidade, PessoaJBase.Bairro, PessoaJBase.Cep, PessoaJBase.Observacoes, PessoaJBase.Cnpj, PessoaJBase.Contato, PessoaJBase.InscricaoEstadual, PessoaJBase.RazaoSocial);

            //A função Save() Retona uma string infomando sobre o que ocorreu.
            MessageBox.Show(saida, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (saida == "Pessoa Jurídica registrada com sucesso!")//Se não ocorreu nem um erro ira limpar os textbox.
            {

                Txt_Bairro.Clear();
                Txt_Cep.Clear();
                Txt_Cidade.Clear();
                Txt_CNPJ.Clear();
                Txt_Contato.Clear();
                Txt_Endereco.Clear();
                Txt_InscricaoEstadual.Clear();
                Txt_Nome.Clear();
                Txt_Observacoes.Clear();
                Txt_RazaoSocial.Clear();
                Txt_Situacao.Clear();
                Txt_Email.Clear();
            }
        }

        private void Frm_PessoaJuridica_Load(object sender, EventArgs e)
        {

            Juridica PessoaJuridicaBase = new Juridica();
            ControllerJuridica controllerPJ = new ControllerJuridica();

            foreach (var item in controllerPJ.LoadList())
            {
                Txt_Lista.Items.Add(item.ToString());
            }
        }

        private void Btm_Carregar_Click(object sender, EventArgs e)
        {
            Juridica PessoaJBase = new Juridica();
            ControllerJuridica controllerPJ = new ControllerJuridica();

            PessoaJBase = controllerPJ.Load(Txt_Lista.Text);

            Txt_Nome.Text = PessoaJBase.Nome;
            Txt_Endereco.Text = PessoaJBase.Endereco;
            Txt_Email.Text = PessoaJBase.Email;
            Txt_Situacao.Text = PessoaJBase.Situacao;
            Txt_Estado.Text = PessoaJBase.SiglaEstado;
            Txt_Cidade.Text = PessoaJBase.Cidade;
            Txt_Bairro.Text = PessoaJBase.Bairro;
            Txt_Cep.Text = PessoaJBase.Cep;
            Txt_Observacoes.Text = PessoaJBase.Observacoes;

            //Parte de Pessoa Jurídica
            Txt_CNPJ.Text = PessoaJBase.Cnpj;
            Txt_Contato.Text = PessoaJBase.Contato;
            Txt_InscricaoEstadual.Text = PessoaJBase.InscricaoEstadual;
            Txt_RazaoSocial.Text = PessoaJBase.RazaoSocial;
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Juridica PessoaJBase = new Juridica();
            ControllerJuridica controllerPJ = new ControllerJuridica();

            PessoaJBase.Nome = Txt_Nome.Text;
            PessoaJBase.Endereco = Txt_Endereco.Text;
            PessoaJBase.Email = Txt_Email.Text;
            PessoaJBase.Situacao = Txt_Situacao.Text;
            PessoaJBase.SiglaEstado = Txt_Estado.Text;
            PessoaJBase.Cidade = Txt_Cidade.Text;
            PessoaJBase.Bairro = Txt_Bairro.Text;
            PessoaJBase.Cep = Txt_Cep.Text;
            PessoaJBase.Observacoes = Txt_Observacoes.Text;

            //Parte de Pessoa Jurídica
            PessoaJBase.Cnpj = Txt_CNPJ.Text;
            PessoaJBase.Contato = Txt_Contato.Text;
            PessoaJBase.InscricaoEstadual = Txt_InscricaoEstadual.Text;
            PessoaJBase.RazaoSocial = Txt_RazaoSocial.Text;

            string saida = controllerPJ.Edit(PessoaJBase.Nome, PessoaJBase.Endereco, PessoaJBase.Email, PessoaJBase.Situacao, PessoaJBase.SiglaEstado, PessoaJBase.Cidade, PessoaJBase.Bairro, PessoaJBase.Cep, PessoaJBase.Observacoes, PessoaJBase.Cnpj, PessoaJBase.Contato, PessoaJBase.InscricaoEstadual, PessoaJBase.RazaoSocial);

            //A função Save() Retona uma string infomando sobre o que ocorreu.
            MessageBox.Show(saida, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (saida == "Pessoa Jurídica editada com sucesso!")
            {

                Txt_Bairro.Clear();
                Txt_Cep.Clear();
                Txt_Cidade.Clear();
                Txt_CNPJ.Clear();
                Txt_Contato.Clear();
                Txt_Endereco.Clear();
                Txt_InscricaoEstadual.Clear();
                Txt_Nome.Clear();
                Txt_Observacoes.Clear();
                Txt_RazaoSocial.Clear();
                Txt_Situacao.Clear();
                Txt_Email.Clear();
            }
        }
    }
}
