using System;
using System.IO;
using System.Windows.Forms;

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
            Model.Pessoa_e_Usuario.Juridica PessoaJBase = new Model.Pessoa_e_Usuario.Juridica();

            PessoaJBase.Nome = Txt_Nome.Text;
            PessoaJBase.Endereco = Txt_Endereco.Text;
            PessoaJBase.Telefone = Txt_Telefone.Text;
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

            //A função Save() Retona uma string infomando sobre o que ocorreu.
            MessageBox.Show(PessoaJBase.Save(PessoaJBase.Nome, PessoaJBase.Endereco, PessoaJBase.Telefone, PessoaJBase.Situacao, PessoaJBase.SiglaEstado, PessoaJBase.Cidade, PessoaJBase.Bairro, PessoaJBase.Cep, PessoaJBase.Observacoes, PessoaJBase.Cnpj, PessoaJBase.Contato, PessoaJBase.InscricaoEstadual, PessoaJBase.RazaoSocial));
        }
    }
}
