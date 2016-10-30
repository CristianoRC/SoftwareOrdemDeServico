using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using View.Pessoas;

namespace View
{
	public partial class Frm_Pai : Form
	{
		public Frm_Pai()
		{
			InitializeComponent();
		}

		//Informações dos técnicos para os forms de OS.
		string Login;
		bool NivelAcesso;
		int Id;

		public Frm_Pai(string usuario, bool nivelAcesso, int id)
		{
			InitializeComponent();

			Login = usuario;
			NivelAcesso = nivelAcesso;
			Id = id;

			if (NivelAcesso == false) // Se for técnico e não Administrador
			{
				//Desativando algumas informações que o usario não pode usar.

				usuariosToolStripMenuItem.Enabled = false;
				emailToolStripMenuItem.Enabled = false;
				EmpresaToolStripMenuItem.Enabled = false;
				novoToolStripMenuItem.Enabled = false;
				editarToolStripMenuItem.Enabled = false;


				//Desativando função de excluir para usuarios
				excluirToolStripMenuItem3.Enabled = false;
				excluirToolStripMenuItem2.Enabled = false;
				excluirToolStripMenuItem4.Enabled = false;
				excluirToolStripMenuItem4.Enabled = false;
			}
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Você deseja realmente sair?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Application.Exit();
			}
		}

		private void novoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Formularios_Usuarios.Frm_NewUsu Frm_NewUso = new Formularios_Usuarios.Frm_NewUsu();

			Frm_NewUso.MdiParent = this;

			Frm_NewUso.Show();
		}

		private void novaF5ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OS.Frm_NewOrdem frm_NewOrdem = new OS.Frm_NewOrdem(Id);

			frm_NewOrdem.MdiParent = this;

			frm_NewOrdem.Show();
		}

		private void editarToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			OS.Frm_EditarOS Frm_Editar = new OS.Frm_EditarOS(Id);

			Frm_Editar.MdiParent = this;

			Frm_Editar.Show();

		}

		private void telaInicialToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Opicoes.Frm_OpicoesInicial Tela_Inicial = new Opicoes.Frm_OpicoesInicial();

			Tela_Inicial.MdiParent = this;

			Tela_Inicial.Show();
		}

		private void Frm_Pai_Load(object sender, EventArgs e)
		{
			string CaminhoLogo = String.Format("{0}/Logo.png", Controller.Ferramentas.ObterCaminhoDoExecutavel());
			string CaminhoEmpresa = String.Format("{0}/Empresa.CFG", Controller.Ferramentas.ObterCaminhoDoExecutavel());

			//Se o logo estiver na pasta do software ele vai ficar no fundo da Tela Pai.
			if (File.Exists(CaminhoLogo))
			{
				this.BackgroundImage = System.Drawing.Image.FromFile(CaminhoLogo);
			}

			StreamReader sr = null;
			try
			{
				sr = new System.IO.StreamReader(CaminhoEmpresa);

				Lbl_NomeEmpresa.Text = sr.ReadLine();

				Lbl_Nome.Text = Login;
			}
			catch (Exception exc)
			{
				Controller.ControllerArquivoLog.GeraraLog(exc);
			}
			finally
			{
				if (sr != null)
					sr.Close();
			}
		}

		private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Outros.Frm_Sobre Sobre = new Outros.Frm_Sobre();

			Sobre.MdiParent = this;

			Sobre.Show();
		}

		private void listarToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			OS.Frm_ListarOS Frm_ListarOS = new OS.Frm_ListarOS(Id);//ID do tecnico, que já vem, pela tela de login.

			Frm_ListarOS.MdiParent = this;

			Frm_ListarOS.Show();
		}

		private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("calc");
		}

		private void blocoDeNotasToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("Notepad");
		}

		private void editarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			View.Usuario.Frm_EditUsu frm_EdiUso = new View.Usuario.Frm_EditUsu();

			frm_EdiUso.MdiParent = this;

			frm_EdiUso.Show();
		}

		private void listarUsuáriosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Usuario.Frm_ListarUsuarios frm_ListarUsuarios = new Usuario.Frm_ListarUsuarios();

			frm_ListarUsuarios.MdiParent = this;

			frm_ListarUsuarios.Show();
		}

		private void emailBaseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Frm_EmailBase frm_EmailBase = new Frm_EmailBase();

			frm_EmailBase.MdiParent = this;

			frm_EmailBase.Show();
		}

		private void servidorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Frm_ConfigEmail frm_ConfigEmail = new Frm_ConfigEmail();

			frm_ConfigEmail.MdiParent = this;

			frm_ConfigEmail.Show();
		}

		private void listarServiçosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Frm_ListarServico frm_ListarServico = new Frm_ListarServico();

			frm_ListarServico.MdiParent = this;

			frm_ListarServico.Show();
		}

		private void finalizarOSToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Frm_Servico frm_Servico = new Frm_Servico(Lbl_Nome.Text);

			frm_Servico.MdiParent = this;

			frm_Servico.Show();
		}

		private void excluirToolStripMenuItem3_Click(object sender, EventArgs e)
		{
			OS.Frm_ExcluirOS frm_ExcluirOS = new OS.Frm_ExcluirOS();

			frm_ExcluirOS.MdiParent = this;

			frm_ExcluirOS.Show();
		}

		private void excluirToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			Servicos.Frm_ExcluirServico frm_ExcluirServico = new Servicos.Frm_ExcluirServico();

			frm_ExcluirServico.MdiParent = this;

			frm_ExcluirServico.Show();
		}

		private void excluirToolStripMenuItem4_Click(object sender, EventArgs e)
		{
			View.Usuario.Frm_ExcluirUsuario frm_ExcluirUsuario = new View.Usuario.Frm_ExcluirUsuario(Login);

			frm_ExcluirUsuario.MdiParent = this;

			frm_ExcluirUsuario.Show();
		}

		private void finalizarOrdemToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Frm_Servico frm_Servico = new Frm_Servico(Lbl_Nome.Text);

			frm_Servico.MdiParent = this;

			frm_Servico.Show();
		}

		private void Frm_Pai_FormClosing(object sender, FormClosingEventArgs e)
		{
			Application.Exit();
		}

		private void listarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			View.OS.Frm_ListarOrcamento frm_ListarOrcamento = new OS.Frm_ListarOrcamento(Id);

			frm_ListarOrcamento.MdiParent = this;

			frm_ListarOrcamento.Show();
		}

		private void reportarBugsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Frm_Report frm_Report = new Frm_Report();

			frm_Report.MdiParent = this;

			frm_Report.Show();
		}

		private void ordemDeServiçoToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			Frm_ImprimirOS Imprimir = new Frm_ImprimirOS();

			Imprimir.MdiParent = this;

			Imprimir.Show();
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			Frm_Clientes frm_Clientes = new Frm_Clientes();

			frm_Clientes.MdiParent = this;

			frm_Clientes.Show();
		}

		private void toolStripMenuItem3_Click(object sender, EventArgs e)
		{
			Frm_ListarClientes frm_ListarCliente = new Frm_ListarClientes();

			frm_ListarCliente.MdiParent = this;

			frm_ListarCliente.Show();
		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Frm_ExcluirClientes frm_ExcluirClientes = new Frm_ExcluirClientes();
			frm_ExcluirClientes.MdiParent = this;

			frm_ExcluirClientes.Show();
		}

		private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog svDialog = new SaveFileDialog();

			svDialog.FileName = "Relatorio de Clientes";
			svDialog.Title = "Salvar relatório";
			svDialog.Filter = "PDF File(*.pdf)|*.pdf";
			svDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

			DialogResult resultado = svDialog.ShowDialog();

			if (resultado == DialogResult.OK)
			{
				//TODO:Corrigir apos a atualização da Spartacus
				//Controller.ControllerRelatoriosPDF.ExportarListaDeClientesParaPDF(svDialog.FileName);
			}
		}

		private void ordensDeServiçoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog svDialog = new SaveFileDialog();

			svDialog.FileName = "Relatorio de Ordens de Servico executadas";
			svDialog.Title = "Salvar relatório";
			svDialog.Filter = "PDF File(*.pdf)|*.pdf";
			svDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

			DialogResult resultado = svDialog.ShowDialog();

			if (resultado == DialogResult.OK)
			{
				//Controller.ControllerRelatoriosPDF.ExportarListaDeOrdemDeServicoParaPDF(svDialog.FileName);
			}
		}
		private void serviçosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog svDialog = new SaveFileDialog();

			svDialog.FileName = "Relatorio de Servicos executados";
			svDialog.Title = "Salvar relatório";
			svDialog.Filter = "PDF File(*.pdf)|*.pdf";
			svDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

			DialogResult resultado = svDialog.ShowDialog();

			if (resultado == DialogResult.OK)
			{
				//Controller.ControllerRelatoriosPDF.ExportarListaDeServicoParaPDF(svDialog.FileName);
			}
		}

		private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			SaveFileDialog svDialog = new SaveFileDialog();

			svDialog.FileName = "Relatorio de Clientes";
			svDialog.Title = "Salvar relatório";
			svDialog.Filter = "xlsx File(*.xlsx)|*.xlsx";
			svDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

			DialogResult resultado = svDialog.ShowDialog();

			if (resultado == DialogResult.OK)
			{
				Spartacus.Database.Command cmd = new Spartacus.Database.Command();

				cmd.v_text = @"select  Id, Nome, Tipo, Email, SiglaEstado, Endereco, Cidade,Bairro
                          from pessoa where status <> #status#";

				cmd.AddParameter("status", Spartacus.Database.Type.BOOLEAN);
				cmd.SetValue("status", "0");//0(Flase)

				Controller.ControllerRelatoriosXLSX.ExportarTabelaParaXLSX(svDialog.FileName, cmd);
			}
		}

		private void ordensDeServiçoToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			SaveFileDialog svDialog = new SaveFileDialog();

			svDialog.FileName = "Relatorio de Ordens de Servico";
			svDialog.Title = "Salvar relatório";
			svDialog.Filter = "xlsx File(*.xlsx)|*.xlsx";
			svDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

			DialogResult resultado = svDialog.ShowDialog();

			if (resultado == DialogResult.OK)
			{
				Spartacus.Database.Command cmd = new Spartacus.Database.Command();

				cmd.v_text = @"select ID, Equipamento, NumeroDeSerie, Defeito, DataEntradaServico
                               from ordemdeservico";

				Controller.ControllerRelatoriosXLSX.ExportarTabelaParaXLSX(svDialog.FileName, cmd);
			}
		}

		private void serviçosToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			SaveFileDialog svDialog = new SaveFileDialog();

			svDialog.FileName = "Relatorio de servicos executados";
			svDialog.Title = "Salvar relatório";
			svDialog.Filter = "xlsx File(*.xlsx)|*.xlsx";
			svDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

			DialogResult resultado = svDialog.ShowDialog();

			if (resultado == DialogResult.OK)
			{
				Spartacus.Database.Command cmd = new Spartacus.Database.Command();

				cmd.v_text = @"select t.*from Trabalhos t";

				Controller.ControllerRelatoriosXLSX.ExportarTabelaParaXLSX(svDialog.FileName, cmd);
			}
		}

		private void toolStripMenuItem5_Click(object sender, EventArgs e)
		{
			Frm_Clientes frm_Clientes = new Frm_Clientes();

			frm_Clientes.Show();
		}

		private void toolStripMenuItem6_Click(object sender, EventArgs e)
		{
			Frm_ListarClientes frm_ListarCliente = new Frm_ListarClientes();

			frm_ListarCliente.Show();
		}
	}
}
