using System;
using Controller;
using System.Windows.Forms;
using Model.Pessoa_e_Usuario;

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
            if (Txt_DataNacimento.Text != "  /  /")//Verifica se algo foi digitado na data de nascimento da pessoa.   "  /  /" -> é como fica a mascara de data em branco/Null
            {
                Fisica PessoaFBase = new Fisica();

                PessoaFBase.Nome = Txt_Nome.Text;
                PessoaFBase.Endereco = Txt_Endereco.Text;
                PessoaFBase.Email = Txt_Email.Text;
                PessoaFBase.Situacao = Txt_Situacao.Text;
                PessoaFBase.SiglaEstado = Txt_Estado.Text;
                PessoaFBase.Cidade = Txt_Cidade.Text;
                PessoaFBase.Bairro = Txt_Bairro.Text;
                PessoaFBase.Cep = Txt_Cep.Text;
                PessoaFBase.Observacoes = Txt_Observacoes.Text;

                //Parte de Pessoa Física
                PessoaFBase.CPF = Txt_CPF.Text;
                PessoaFBase.Celular = Txt_Celular.Text;
                PessoaFBase.Sexo = Txt_Sexo.Text;
                PessoaFBase.DataDeNascimento = DateTime.Parse(Txt_DataNacimento.Text);

                //A função Save() Retona uma string infomando sobre o que ocorreu.
                string saida = ControllerFisica.Save(PessoaFBase.Nome, PessoaFBase.Endereco, PessoaFBase.Email, PessoaFBase.Situacao, PessoaFBase.SiglaEstado, PessoaFBase.Cidade, PessoaFBase.Bairro, PessoaFBase.Cep, PessoaFBase.Observacoes, PessoaFBase.CPF, PessoaFBase.Celular, PessoaFBase.Sexo, PessoaFBase.DataDeNascimento);

                MessageBox.Show(saida, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (saida == "Pessoa Física registrada com sucesso!")//Se não houver nem um erro na hora de salvar, ira limpar os textbox. 
                {
                    Txt_Bairro.Clear();
                    Txt_Cep.Clear();
                    Txt_Cidade.Clear();
                    Txt_CPF.Clear();
                    Txt_Celular.Clear();
                    Txt_Endereco.Clear();
                    Txt_Nome.Clear();
                    Txt_Observacoes.Clear();
                    Txt_DataNacimento.Clear();
                    Txt_Situacao.Clear();
                    Txt_Email.Clear();
                }
            }
            else
            {
                MessageBox.Show("Data de nascimento inválida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Frm_PessoaFisica_Load(object sender, EventArgs e)
        {
            foreach (var item in ControllerFisica.LoadList())
            {
                Txt_Lista.Items.Add(item.ToString());
            }
        }

        private void Btm_Carregar_Click(object sender, EventArgs e)
        {
            Fisica PessoaFBase = new Fisica();

            PessoaFBase = ControllerFisica.Load(Txt_Lista.Text);

            Txt_Nome.Text = PessoaFBase.Nome;
            Txt_Endereco.Text = PessoaFBase.Endereco;
            Txt_Email.Text = PessoaFBase.Email;
            Txt_Situacao.Text = PessoaFBase.Situacao;
            Txt_Estado.Text = PessoaFBase.SiglaEstado;
            Txt_Cidade.Text = PessoaFBase.Cidade;
            Txt_Bairro.Text = PessoaFBase.Bairro;
            Txt_Cep.Text = PessoaFBase.Cep;
            Txt_Observacoes.Text = PessoaFBase.Observacoes;

            //Parte de Pessoa Física
            Txt_CPF.Text = PessoaFBase.CPF;
            Txt_Celular.Text = PessoaFBase.Celular;
            Txt_Sexo.Text = PessoaFBase.Sexo;
            Txt_DataNacimento.Text = PessoaFBase.DataDeNascimento.ToString();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Txt_DataNacimento.Text != "  /  /")//Verifica se algo foi digitado na data de nascimento da pessoa.   "  /  /" -> é como fica a mascara de data em branco/Null
            {
                Fisica PessoaFBase = new Fisica();

                PessoaFBase.Nome = Txt_Nome.Text;
                PessoaFBase.Endereco = Txt_Endereco.Text;
                PessoaFBase.Email = Txt_Email.Text;
                PessoaFBase.Situacao = Txt_Situacao.Text;
                PessoaFBase.SiglaEstado = Txt_Estado.Text;
                PessoaFBase.Cidade = Txt_Cidade.Text;
                PessoaFBase.Bairro = Txt_Bairro.Text;
                PessoaFBase.Cep = Txt_Cep.Text;
                PessoaFBase.Observacoes = Txt_Observacoes.Text;

                //Parte de Pessoa Física
                PessoaFBase.CPF = Txt_CPF.Text;
                PessoaFBase.Celular = Txt_Celular.Text;
                PessoaFBase.Sexo = Txt_Sexo.Text;
                PessoaFBase.DataDeNascimento = DateTime.Parse(Txt_DataNacimento.Text);

                //A função Save() Retona uma string infomando sobre o que ocorreu.
                string saida = ControllerFisica.Edit(PessoaFBase.Nome, PessoaFBase.Endereco, PessoaFBase.Email, PessoaFBase.Situacao, PessoaFBase.SiglaEstado, PessoaFBase.Cidade, PessoaFBase.Bairro, PessoaFBase.Cep, PessoaFBase.Observacoes, PessoaFBase.CPF, PessoaFBase.Celular, PessoaFBase.Sexo, PessoaFBase.DataDeNascimento);

                MessageBox.Show(saida, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (saida == "Pessoa Física editada com sucesso!")//Se não houver nem um erro na hora de salvar, ira limpar os textbox. 
                {
                    Txt_Bairro.Clear();
                    Txt_Cep.Clear();
                    Txt_Cidade.Clear();
                    Txt_CPF.Clear();
                    Txt_Celular.Clear();
                    Txt_Endereco.Clear();
                    Txt_Nome.Clear();
                    Txt_Observacoes.Clear();
                    Txt_DataNacimento.Clear();
                    Txt_Situacao.Clear();
                    Txt_Email.Clear();
                }
            }
            else
            {
                MessageBox.Show("Data de nascimento inválida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
