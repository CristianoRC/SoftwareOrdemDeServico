using System;
using Controller;
using System.Windows.Forms;
using Model.Ordem_de_Servico;

namespace View.OS
{
	public partial class Frm_NewOrdem : Form
	{
		//TODO: Adicionar campo de valor de orçamento

		public Frm_NewOrdem(int idTecnico)
		{
			InitializeComponent();

			IDTecnico = idTecnico;
		}

		private int IDTecnico;
		System.Data.DataTable TabelaDeClientes = new System.Data.DataTable();

		private void Frm_NewOrdem_Load(object sender, EventArgs e)
		{
			Txt_DataEntrada.Text = DateTime.Now.ToString("dd/MM/yy");

			//Preenchendo o ComboBox com o nome de Clientes
			TabelaDeClientes = ControllerPessoa.CarregarListaDeNomes();

			if (TabelaDeClientes.Rows.Count != 0)
			{
				foreach (System.Data.DataRow r in TabelaDeClientes.Rows)
				{
					foreach (System.Data.DataColumn c in TabelaDeClientes.Columns)
					{
						Txt_Clientes.Items.Add(r[c].ToString());
					}
				}
			}
		}

		/// <summary>
		/// Btm Salvar
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void button1_Click(object sender, EventArgs e)
		{
			if (ControllerPessoa.VerificarExistencia(Txt_Clientes.Text))
			{
				string Retorno = ControllerOrdemServico.Criar(PreencherOS());

				MessageBox.Show(String.Format("{0}", Retorno), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

				if (MessageBox.Show("Deseja imprimir  a ordem de serviço?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					//TODO: Função para gerar uma ordem de serviço em PDF Aqui.
				}

				if (Ferramentas.VerificarEmailValido(ControllerPessoa.ObterEmail(Txt_Clientes.Text)))
				{
					if (MessageBox.Show("Deseja enviar a ordem de serviço para o cliente?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						//TODO:Arrumar o código após a criação do sistema de e-mail
						// string ResultadoEnvio = ControllerEmail.EnviarOrdemDeServiço(OSBase,EmpresaBase,PessoaBase);
						// MessageBox.Show(ResultadoEnvio, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}

				LimparCampos();
			}
			else
			{
				MessageBox.Show("Selecione um cliente!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

		}

		/// <summary>
		/// Carregando as informações dos TxtBox para a Classe Cliente.
		/// </summary>
		/// <returns></returns>
		private OrdemServico PreencherOS()
		{
			OrdemServico OSBase = new OrdemServico();

			OSBase.dataEntradaServico = Txt_DataEntrada.Text;
			OSBase.Defeito = Txt_Defeito.Text;
			OSBase.Descricao = Txt_Descricao.Text;
			OSBase.Equipamento = Txt_Equipamento.Text;
			OSBase.IDCliente = ControllerPessoa.VerificarID(Txt_Clientes.Text);
			OSBase.IDTecnico = IDTecnico;
			OSBase.NumeroSerie = Txt_Nserie.Text;
			OSBase.Observacao = Txt_Observacoes.Text;
			OSBase.Situacao = Txt_Situacao.Text;
			return OSBase;
		}

		private void LimparCampos()
		{
			Txt_DataEntrada.Clear();
			Txt_Defeito.Clear();
			Txt_Descricao.Clear();
			Txt_Equipamento.Clear();
			Txt_Nserie.Clear();
			Txt_Observacoes.Clear();
		}

		private void Txt_Clientes_TextUpdate(object sender, EventArgs e)
		{
			Txt_Clientes.Items.Clear();

			if (TabelaDeClientes.Rows.Count != 0)
			{
				foreach (System.Data.DataRow r in TabelaDeClientes.Rows)
				{
					foreach (System.Data.DataColumn c in TabelaDeClientes.Columns)
					{
						if (r[c].ToString().Trim().Contains(Txt_Clientes.Text.Trim()))
						{
							Txt_Clientes.Items.Add(r[c].ToString());
						}
					}
				}

				//Move o cursor para o Fim do combobox.
				Txt_Clientes.SelectionStart = Txt_Clientes.Text.ToString().Length;
			}
		}
	}
}
