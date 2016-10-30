using Controller;
using Model.Pessoa_e_Usuario;
using System;
using System.Windows.Forms;

namespace View.Pessoas
{

	public partial class Frm_Clientes : Form
	{
		public Frm_Clientes()
		{
			InitializeComponent();
		}

		public Frm_Clientes(int IDCliente)
		{
			InitializeComponent();

			IDCarregado = IDCliente;

			CarregarInformacoes(IDCliente);
		}

		private int IDCarregado;

		private void Frm_Clientes_Load(object sender, EventArgs e)
		{
			AtualziarLsitaDeClientes();
		}

		private void salvar()
		{
			if (!string.IsNullOrWhiteSpace(Txt_Nome.Text))
			{

				string Saida = ControllerPessoa.Criar(PreencherInformacoes());

				MessageBox.Show(Saida, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

				LimparCampos();
				AtualziarLsitaDeClientes();
			}
			else
			{
				MessageBox.Show("Insira um nome!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void editar()
		{
			if (!string.IsNullOrWhiteSpace(Txt_Nome.Text))
			{
				string Saida = ControllerPessoa.Editar(PreencherInformacoes());

				MessageBox.Show(Saida, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

				LimparCampos();
				AtualziarLsitaDeClientes();
			}
			else
			{
				MessageBox.Show("Insira um nome!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		/// <summary>
		/// Carregando as informações dos TXT's para a classe Pessoa
		/// </summary>
		/// <returns></returns>
		private Pessoa PreencherInformacoes()
		{
			Pessoa PessoaBase = new Pessoa();

			PessoaBase.Nome = Txt_Nome.Text;
			PessoaBase.Logradouro = Txt_Endereco.Text;
			PessoaBase.Complemento = Txt_Complemento.Text;
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

			PessoaBase.ID = IDCarregado;

			return PessoaBase;
		}

		/// <summary>
		/// Limpando todos os TextBox
		/// </summary>
		private void LimparCampos()
		{
			Txt_Nome.Clear();
			Txt_Endereco.Clear();
			Txt_Email.Clear();
			Txt_Tipo.Text = "";
			Txt_Estado.Text = "";
			Txt_Cidade.Clear();
			Txt_Bairro.Clear();
			Txt_Cep.Clear();
			Txt_Complemento.Clear();

			//Parte de Pessoa Física
			Txt_CPF.Clear();
			Txt_Celular.Clear();
			Txt_Sexo.Text = "";
			Txt_DataNacimento.Clear();

			//Parte Jurídica
			Txt_CNPJ.Clear();
			Txt_Contato.Clear();
			Txt_RazaoSocial.Clear();
			Txt_InscricaoEstadual.Clear();
		}

		private void AtualziarLsitaDeClientes()
		{
			Txt_Pessoa.Items.Clear();

			System.Data.DataTable tabela = new System.Data.DataTable();

			tabela = ControllerPessoa.CarregarListaDeNomes();
			if (tabela.Rows.Count != 0)
			{
				foreach (System.Data.DataRow r in tabela.Rows)
				{
					foreach (System.Data.DataColumn c in tabela.Columns)
					{
						Txt_Pessoa.Items.Add(r[c].ToString());
					}
				}

				Txt_Pessoa.Text = Txt_Pessoa.Items[0].ToString();
			}
		}

		private void Btm_Salvar_Click(object sender, EventArgs e)
		{
			if (!ControllerPessoa.VerificarExistencia(Txt_Nome.Text))//Se ele não existir crie um novo, senão edite apenas
			{
				salvar();
			}
			else
			{
				editar();
			}
		}

		private void editarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			editar();
		}

		private void Btm_Carregar_Click(object sender, EventArgs e)
		{
			CarregarInformacoes(Txt_Pessoa.Text);
		}

		private void Txt_Cep_Leave(object sender, EventArgs e)
		{
			var valorSemMascara = Txt_Cep.Text.Replace("-", "");

			valorSemMascara = valorSemMascara.Replace("_", "");

			uint Cepuint;

			//Verifica se ele já tem 8 caractres(o valor do CEP), e se são epnas numeros
			if (valorSemMascara.Length == 8 && uint.TryParse(valorSemMascara, out Cepuint))
			{
				try
				{
					DotCEP.Endereco endereco = new DotCEP.Endereco();

					endereco = DotCEP.Consultas.ObterEnderecoCompleto(valorSemMascara);

					Txt_Endereco.Text = endereco.logradouro;
					Txt_Estado.Text = endereco.uf;
					Txt_Cidade.Text = endereco.localidade;
					Txt_Bairro.Text = endereco.bairro;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		/// <summary>
		/// Carrega informações do banco para os textbox
		/// </summary>
		/// <param name="id"></param>
		private void CarregarInformacoes(int id)
		{
			Pessoa PessoaFBase = new Pessoa();

			PessoaFBase = ControllerPessoa.Carregar(id);

			Txt_Nome.Text = PessoaFBase.Nome;
			Txt_Endereco.Text = PessoaFBase.Logradouro;
			Txt_Complemento.Text = PessoaFBase.Complemento;
			Txt_Email.Text = PessoaFBase.Email;
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

			IDCarregado = PessoaFBase.ID;

			//Preenchendo as informações no comboBox Tipo
			if (PessoaFBase.Tipo == "Física" || PessoaFBase.Tipo == "Fisica")
			{
				Txt_Tipo.Text = Txt_Tipo.Items[0].ToString();
			}
			else
			{
				Txt_Tipo.Text = Txt_Tipo.Items[1].ToString();
			}
		}

		/// <summary>
		/// Carrega informações do banco para os textbox
		/// </summary>
		/// <param name="nome">Nome.</param>
		private void CarregarInformacoes(string nome)
		{
			Pessoa PessoaFBase = new Pessoa();

			PessoaFBase = ControllerPessoa.Carregar(nome);

			Txt_Nome.Text = PessoaFBase.Nome;
			Txt_Endereco.Text = PessoaFBase.Logradouro;
			Txt_Complemento.Text = PessoaFBase.Complemento;
			Txt_Email.Text = PessoaFBase.Email;
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

			IDCarregado = PessoaFBase.ID;

			//Preenchendo as informações no comboBox Tipo
			if (PessoaFBase.Tipo == "Física" || PessoaFBase.Tipo == "Fisica")
			{
				Txt_Tipo.Text = Txt_Tipo.Items[0].ToString();
			}
			else
			{
				Txt_Tipo.Text = Txt_Tipo.Items[1].ToString();
			}
		}

	}
}
