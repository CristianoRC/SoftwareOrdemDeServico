using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace View.Pessoas
{
    public partial class Frm_PessoaFisica : Form
    {
        public Frm_PessoaFisica()
        {
            InitializeComponent();
        }

        private void Btm_Salvar_Click(object sender, EventArgs e)
        {

            Model.Pessoa_e_Usuario.Fisica PessoaFBase = new Model.Pessoa_e_Usuario.Fisica();

            PessoaFBase.Nome = Txt_Nome.Text;
            PessoaFBase.Endereco = Txt_Endereco.Text;
            PessoaFBase.Telefone = Txt_Telefone.Text;
            PessoaFBase.Situacao = Txt_Situacao.Text;
            PessoaFBase.SiglaEstado = Txt_Estado.Text;
            PessoaFBase.Cidade = Txt_Cidade.Text;
            PessoaFBase.Bairro = Txt_Bairro.Text;
            PessoaFBase.Cep = Txt_Cep.Text;
            PessoaFBase.Observacoes = Txt_Observacoes.Text;

            //Parte de Pessoa Jurídica
            PessoaFBase.CPF = Txt_CPF.Text;
            PessoaFBase.Celular = Txt_Celular.Text;
            PessoaFBase.Sexo = Txt_Sexo.Text;
            PessoaFBase.DataDeNascimento = DateTime.Parse(Txt_DataNacimento.Text);

            //A função Save() Retona uma string infomando sobre o que ocorreu.
            MessageBox.Show(PessoaFBase.Save(PessoaFBase.Nome, PessoaFBase.Endereco, PessoaFBase.Telefone, PessoaFBase.Situacao, PessoaFBase.SiglaEstado, PessoaFBase.Cidade, PessoaFBase.Bairro, PessoaFBase.Cep, PessoaFBase.Observacoes, PessoaFBase.CPF, PessoaFBase.Celular, PessoaFBase.Sexo, PessoaFBase.DataDeNascimento));
        }
    }
}
