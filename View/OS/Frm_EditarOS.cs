using System;
using Controller;
using System.Windows.Forms;
using Model.Ordem_de_Servico;

namespace View.OS
{
	public partial class Frm_EditarOS : Form
	{
		//TODO: Adicionar campo de valor de orçamento

		/// <summary>
		/// Utilizado quando o é chamado pelo formulário de listagem de OS para edicao.
		/// </summary>
		/// <param name="idTecnico"></param>
		/// <param name="IDOs"></param>
		public Frm_EditarOS(int idTecnico, int IDOs)
		{
			IDTecnico = idTecnico;
			IDChamado = IDOs;
			InicializacaoPeloFormularioExterno = true;

			InitializeComponent();
		}

		public Frm_EditarOS(int idTecnico)
		{
			IDTecnico = idTecnico;

			InitializeComponent();
		}

		private int IDTecnico;
		private int IDChamado;
		private bool InicializacaoPeloFormularioExterno;
		//Pega a informação se o formulário foi aberto do form ListaOS

		System.Data.DataTable TabelaDeClientes = new System.Data.DataTable();


		private void Frm_EditarOS_Load(object sender, EventArgs e)
		{
			AtualizarListaDeClintes();
			AtualizarListaDeOS();


			if (InicializacaoPeloFormularioExterno)
			{
				//Carregando as informações passadas pelo form de listagem de OS.
				PreencherCamposDeTexto(IDChamado);

				InicializacaoPeloFormularioExterno = false;
			}
		}

		private void Btm_Pesquisa_Click(object sender, EventArgs e)
		{
			//Verificado se a ordem de serviço que foi procurada existe e se existir retornar a Ordem de serviço base.
			if (!String.IsNullOrEmpty(Txt_IDPesquisa.Text))
			{
				PreencherCamposDeTexto(Convert.ToInt32(Txt_IDPesquisa.Text));
			}
			else
			{
				MessageBox.Show("Escolha uma ordem de serviço!", "Informações", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			if (ControllerPessoa.VerificarExistencia(Txt_Cliente.Text))
			{
				string Retorno = ControllerOrdemServico.Editar(PreencherOS());

				MessageBox.Show(String.Format("{0}", Retorno), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

				if (MessageBox.Show("Deseja imprimir o arquivo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					//TODO: Função para gerar uma ordem de serviço em PDF Aqui.
				}


				Txt_DataEntrada.Clear();
				Txt_Defeito.Clear();
				Txt_Descricao.Clear();
				Txt_Equipamento.Clear();
				Txt_Nserie.Clear();
				Txt_Observacoes.Clear();
			}
			else
			{
				MessageBox.Show(String.Format("Verifique o nome do cliente"), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void PreencherCamposDeTexto(int id)
		{
			OrdemServico InformacoesOrdemDeServico = new OrdemServico();
			InformacoesOrdemDeServico = ControllerOrdemServico.Carregar(id);

			IDChamado = InformacoesOrdemDeServico.ID;
			Txt_IDPesquisa.Text = InformacoesOrdemDeServico.ID.ToString();
			Txt_Situacao.Text = InformacoesOrdemDeServico.Situacao;
			Txt_Defeito.Text = InformacoesOrdemDeServico.Defeito;
			Txt_Descricao.Text = InformacoesOrdemDeServico.Descricao;
			Txt_Observacoes.Text = InformacoesOrdemDeServico.Observacao;
			Txt_Nserie.Text = InformacoesOrdemDeServico.NumeroSerie;
			Txt_Equipamento.Text = InformacoesOrdemDeServico.Equipamento;
			Txt_DataEntrada.Text = InformacoesOrdemDeServico.dataEntradaServico;
			Txt_Descricao.Text = InformacoesOrdemDeServico.Descricao;
			Txt_Cliente.Text = ControllerPessoa.VerificarNome(InformacoesOrdemDeServico.IDCliente);

			//Caso o estatus da OS for finalizado, não é possível mudar.
			if (InformacoesOrdemDeServico.Situacao == "Finalizado")
			{
				Txt_Situacao.Enabled = false;
			}
			else
			{
				Txt_Situacao.Enabled = true;
			}
		}

		/// <summary>
		/// Carregando as informações dos TxtBox para a Classe Cliente.
		/// </summary>
		/// <returns></returns>
		private OrdemServico PreencherOS()
		{
			OrdemServico OSBase = new OrdemServico();
			OSBase.ID = IDChamado;
			OSBase.dataEntradaServico = Txt_DataEntrada.Text;
			OSBase.Defeito = Txt_Defeito.Text;
			OSBase.Descricao = Txt_Descricao.Text;
			OSBase.Equipamento = Txt_Equipamento.Text;
			OSBase.IDCliente = ControllerPessoa.VerificarID(Txt_Cliente.Text);
			OSBase.IDTecnico = IDTecnico;
			OSBase.NumeroSerie = Txt_Nserie.Text;
			OSBase.Observacao = Txt_Observacoes.Text;
			OSBase.Situacao = Txt_Situacao.Text;
			return OSBase;
		}

		private void AtualizarListaDeClintes()
		{

			TabelaDeClientes = ControllerPessoa.CarregarListaDeNomes();

			if (TabelaDeClientes.Rows.Count != 0)
			{
				foreach (System.Data.DataRow r in TabelaDeClientes.Rows)
				{
					foreach (System.Data.DataColumn c in TabelaDeClientes.Columns)
					{
						Txt_Cliente.Items.Add(r[c].ToString());
					}
				}
			}
		}

		private void AtualizarListaDeOS()
		{
			System.Data.DataTable TabelaOS = new System.Data.DataTable();

			TabelaOS = ControllerOrdemServico.CarregarListaDeIds();
			if (TabelaOS.Rows.Count != 0)
			{
				foreach (System.Data.DataRow r in TabelaOS.Rows)
				{
					foreach (System.Data.DataColumn c in TabelaOS.Columns)
					{
						Txt_IDPesquisa.Items.Add(r[c].ToString());
					}
				}
			}

		}

		private void Txt_Cliente_TextUpdate(object sender, EventArgs e)
		{
			Txt_Cliente.Items.Clear();

			if (TabelaDeClientes.Rows.Count != 0)
			{
				foreach (System.Data.DataRow r in TabelaDeClientes.Rows)
				{
					foreach (System.Data.DataColumn c in TabelaDeClientes.Columns)
					{
						if (r[c].ToString().Trim().Contains(Txt_Cliente.Text.Trim()))
						{
							Txt_Cliente.Items.Add(r[c].ToString());
						}
					}
				}

				//Move o cursor para o Fim do combobox.
				Txt_Cliente.SelectionStart = Txt_Cliente.Text.ToString().Length;
			}
		}
	}
}