using System;
using Controller;
using System.Windows.Forms;
using Model.Pessoa_e_Usuario;

namespace View.Pessoas
{
    public partial class Frm_Cliente : Form
    {
        public Frm_Cliente()
        {
            InitializeComponent();
        }

        private void Btm_Salvar_Click(object sender, EventArgs e)
        {
            if (!ControllerPessoa.Verificar(Txt_Nome.Text))//Se ele não existir crie um novo, senão edite apenas
            {
                salvar();
            }
            else
            {
                editar();
            }
        }

        private void Frm_PessoaFisica_Load(object sender, EventArgs e)
        {
            Txt_Pessoa.Items.Clear();

            System.Data.DataTable tabela = new System.Data.DataTable();

            tabela = ControllerPessoa.CarregarListaDeNomes();

            foreach (System.Data.DataRow r in tabela.Rows)
            {
                foreach (System.Data.DataColumn c in tabela.Columns) 
                {
                    Txt_Pessoa.Items.Add(r[c].ToString());      
                }
            }  
        }

        private void Btm_Carregar_Click(object sender, EventArgs e)
        {
            Pessoa PessoaFBase = new Pessoa();

            PessoaFBase = ControllerPessoa.Carregar(Txt_Pessoa.Text);

            Txt_Nome.Text = PessoaFBase.Nome;
            Txt_Endereco.Text = PessoaFBase.Endereco;
            Txt_Email.Text = PessoaFBase.Email;
            Txt_Tipo.Text = PessoaFBase.Tipo;
            Txt_Estado.Text = PessoaFBase.SiglaEstado;
            Txt_Cidade.Text = PessoaFBase.Cidade;
            Txt_Bairro.Text = PessoaFBase.Bairro;
            Txt_Cep.Text = PessoaFBase.Cep;

            //Parte de Pessoa Física
            Txt_CPF.Text = PessoaFBase.Cpf;
            Txt_Celular.Text = PessoaFBase.Celular;
            Txt_Sexo.Text = PessoaFBase.Sexo;
            Txt_DataNacimento.Text = PessoaFBase.DataDeNascimento.ToString();

            //Parte Jurídica
            Txt_CNPJ.Text = PessoaFBase.Cnpj;
            Txt_Contato.Text = PessoaFBase.Contato;
            Txt_RazaoSocial.Text = PessoaFBase.RazaoSocial;
            Txt_InscricaoEstadual.Text = PessoaFBase.InscricaoEstadual;

        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editar();
        }

        private void salvar()
        {
            ControllerPessoa.Salvar(PreencherInformacoes());
        }

        private void editar()
        {
            ControllerPessoa.Editar(PreencherInformacoes());
        }

        /// <summary>
        /// Carregando as informações dos TXT's para a classe Pessoa
        /// </summary>
        /// <returns></returns>
        private Pessoa PreencherInformacoes()
        {
            Pessoa PessoaBase = new Pessoa();

            PessoaBase.Nome = Txt_Nome.Text;
            PessoaBase.Endereco = Txt_Endereco.Text;
            PessoaBase.Email = Txt_Email.Text;
            PessoaBase.Tipo = Txt_Tipo.Text;
            PessoaBase.SiglaEstado = Txt_Estado.Text;
            PessoaBase.Cidade = Txt_Cidade.Text;
            PessoaBase.Bairro = Txt_Bairro.Text;
            PessoaBase.Cep = Txt_Cep.Text;

            //Parte de Pessoa Física
            PessoaBase.Cpf = Txt_CPF.Text;
            PessoaBase.Celular = Txt_Celular.Text;
            PessoaBase.Sexo = Txt_Sexo.Text;
            PessoaBase.DataDeNascimento = Txt_DataNacimento.Text;

            //Parte Jurídica
            PessoaBase.Cnpj = Txt_CNPJ.Text;
            PessoaBase.Contato = Txt_Contato.Text;
            PessoaBase.RazaoSocial = Txt_RazaoSocial.Text;
            PessoaBase.InscricaoEstadual = Txt_InscricaoEstadual.Text;

            return PessoaBase;
        }
    }
}
