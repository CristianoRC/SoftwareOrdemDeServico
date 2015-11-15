using System;
using Controller;
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
