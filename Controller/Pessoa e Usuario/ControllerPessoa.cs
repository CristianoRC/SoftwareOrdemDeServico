using System;
using System.Collections.Generic;
using Model.Pessoa_e_Usuario;
using System.Data;

namespace Controller
{
	public static class ControllerPessoa
	{

		/// <summary>
		/// Criando um nome Cliente
		/// </summary>
		/// <param name="cliente"></param>
		/// <returns></returns>
		public static string Criar(Pessoa cliente)
		{
			char nivelAcesso = '1';
			string Saida = "";
			Spartacus.Database.Generic database;
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();


			cmd.v_text = @"insert into pessoa  
                        (Nome,Tipo,Email,Logradouro,Complemento,
                         SiglaEstado,Cidade,Bairro,CEP,
                         Sexo,CPF,Celular,DataDeNascimento,
                         RazaoSocial,Cnpj,InscricaoEstadual,Status)
                         values (#nome#,#tipo#,#email#,#logradouro#,#complemento#,
                                 #siglaestado#,#cidade#,#bairro#,#cep#,
                                 #sexo#,#cpf#,#celular#,#datadenascimento#,
                                 #razaosocial#,#cnpj#,#inscricaoestadual#,#status#);";


			cmd.AddParameter("nome", Spartacus.Database.Type.STRING);
			cmd.AddParameter("tipo", Spartacus.Database.Type.STRING);
			cmd.AddParameter("email", Spartacus.Database.Type.STRING);
			cmd.AddParameter("logradouro", Spartacus.Database.Type.STRING);
			cmd.AddParameter("complemento", Spartacus.Database.Type.STRING);
			cmd.AddParameter("siglaEstado", Spartacus.Database.Type.STRING);
			cmd.AddParameter("cidade", Spartacus.Database.Type.STRING);
			cmd.AddParameter("bairro", Spartacus.Database.Type.STRING);
			cmd.AddParameter("cep", Spartacus.Database.Type.STRING);
			cmd.AddParameter("sexo", Spartacus.Database.Type.STRING);
			cmd.AddParameter("cpf", Spartacus.Database.Type.STRING);
			cmd.AddParameter("celular", Spartacus.Database.Type.STRING);
			cmd.AddParameter("dataDeNascimento", Spartacus.Database.Type.STRING);
			cmd.AddParameter("razaoSocial", Spartacus.Database.Type.STRING);
			cmd.AddParameter("cnpj", Spartacus.Database.Type.STRING);
			cmd.AddParameter("inscricaoEstadual", Spartacus.Database.Type.STRING);
			cmd.AddParameter("status", Spartacus.Database.Type.BOOLEAN);

			cmd.SetValue("nome", cliente.Nome);
			cmd.SetValue("tipo", cliente.Tipo);
			cmd.SetValue("email", cliente.Email);
			cmd.SetValue("logradouro", cliente.Logradouro);
			cmd.SetValue("complemento", cliente.Complemento);
			cmd.SetValue("siglaEstado", cliente.SiglaEstado);
			cmd.SetValue("cidade", cliente.Cidade);
			cmd.SetValue("bairro", cliente.Bairro);
			cmd.SetValue("cep", cliente.Cep);
			cmd.SetValue("sexo", cliente.Sexo);
			cmd.SetValue("cpf", cliente.Cpf);
			cmd.SetValue("celular", cliente.Celular);
			cmd.SetValue("dataDeNascimento", cliente.DataDeNascimento);
			cmd.SetValue("razaoSocial", cliente.RazaoSocial);
			cmd.SetValue("cnpj", cliente.Cnpj);
			cmd.SetValue("inscricaoEstadual", cliente.InscricaoEstadual);
			cmd.SetValue("status", nivelAcesso.ToString()); //Passa o valor 1(true), porque na criação o usuário já sai ativo.


			if (VerificarExistencia(cliente.Nome) == false)
			{
				database = new Spartacus.Database.Sqlite(DB.GetStrConection());

				try
				{
					database.Execute(cmd.GetUpdatedText());

					Saida = "Cliente registrada com sucesso!";
				}
				catch (Exception exc)
				{
					ControllerArquivoLog.GeraraLog(exc);

					Saida = "Ocorreu um erro inesperado: " + exc.Message;
				}

				return Saida;
			}
			else
			{
				//Se o a pessoa jurídica já for cadastrada caira nesse código como retorno e nada sera salvo.
				Saida = "Cliente já cadastrada.";

				return Saida;
			}
		}

		/// <summary>
		/// Editando informações sobre um cliente ainda já criado.
		/// </summary>
		/// <param name="cliente"></param>
		/// <returns></returns>
		public static string Editar(Pessoa cliente)
		{
			string Saida = "";

			Spartacus.Database.Generic database;
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = @"update pessoa set 
                    Nome = #nome#,
                    Tipo = #tipo#,
                    Email = #email#,
					Logradouro = #logradouro#,
					Complemento = #complemento#,
                    SiglaEstado = #siglaestado#,
                    Cidade = #cidade#,
                    Bairro = #bairro#,
                    CEP = #cep#,
                    Sexo = #sexo#,
                    CPF = #cpf#,
                    Celular = #celular#,
                    DataDeNascimento = #datadenascimento#,
                    RazaoSocial = #razaosocial#,
                    Cnpj = #cnpj#,
                    InscricaoEstadual = #inscricaoestadual#
                    where ID = #id#";


			cmd.AddParameter("id", Spartacus.Database.Type.INTEGER);
			cmd.AddParameter("nome", Spartacus.Database.Type.STRING);
			cmd.AddParameter("tipo", Spartacus.Database.Type.STRING);
			cmd.AddParameter("email", Spartacus.Database.Type.STRING);
			cmd.AddParameter("logradouro", Spartacus.Database.Type.STRING);
			cmd.AddParameter("complemento", Spartacus.Database.Type.STRING);
			cmd.AddParameter("siglaEstado", Spartacus.Database.Type.STRING);
			cmd.AddParameter("cidade", Spartacus.Database.Type.STRING);
			cmd.AddParameter("bairro", Spartacus.Database.Type.STRING);
			cmd.AddParameter("cep", Spartacus.Database.Type.STRING);
			cmd.AddParameter("sexo", Spartacus.Database.Type.STRING);
			cmd.AddParameter("cpf", Spartacus.Database.Type.STRING);
			cmd.AddParameter("celular", Spartacus.Database.Type.STRING);
			cmd.AddParameter("dataDeNascimento", Spartacus.Database.Type.STRING);
			cmd.AddParameter("razaoSocial", Spartacus.Database.Type.STRING);
			cmd.AddParameter("cnpj", Spartacus.Database.Type.STRING);
			cmd.AddParameter("inscricaoEstadual", Spartacus.Database.Type.STRING);

			cmd.SetValue("id", cliente.ID.ToString());
			cmd.SetValue("nome", cliente.Nome);
			cmd.SetValue("tipo", cliente.Tipo);
			cmd.SetValue("email", cliente.Email);
			cmd.SetValue("logradouro", cliente.Logradouro);
			cmd.SetValue("complemento", cliente.Complemento);
			cmd.SetValue("siglaEstado", cliente.SiglaEstado);
			cmd.SetValue("cidade", cliente.Cidade);
			cmd.SetValue("bairro", cliente.Bairro);
			cmd.SetValue("cep", cliente.Cep);
			cmd.SetValue("sexo", cliente.Sexo);
			cmd.SetValue("cpf", cliente.Cpf);
			cmd.SetValue("celular", cliente.Celular);
			cmd.SetValue("dataDeNascimento", cliente.DataDeNascimento);
			cmd.SetValue("razaoSocial", cliente.RazaoSocial);
			cmd.SetValue("cnpj", cliente.Cnpj);
			cmd.SetValue("inscricaoEstadual", cliente.InscricaoEstadual);

			try
			{
				database = new Spartacus.Database.Sqlite(DB.GetStrConection());

				database.Execute(cmd.GetUpdatedText());

				Saida = "Cliente editado com sucesso!";
			}
			catch (Exception exc)
			{
				ControllerArquivoLog.GeraraLog(exc);

				Saida = "Ocorreu um erro inesperado: " + exc.Message;
			}

			return Saida;
		}

		/// <summary>
		/// Excluindo cliente
		/// </summary>
		/// <param name="Nome"></param>
		/// <returns>Resultado da operação</returns>
		public static string Deletar(string Nome)
		{
			char nivelAcesso = '0';
			string saida = string.Format("cliente {0} foi excluido com sucesso!", Nome);
			Spartacus.Database.Generic database;
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "update pessoa set Status = #status# Where Nome = #nome#";

			cmd.AddParameter("nome", Spartacus.Database.Type.STRING);
			cmd.AddParameter("status", Spartacus.Database.Type.INTEGER);

			cmd.SetValue("nome", Nome);
			cmd.SetValue("status", nivelAcesso.ToString());//Recebe o valor 0(false), para desativar usuário

			try
			{
				database = new Spartacus.Database.Sqlite(DB.GetStrConection());

				database.Execute(cmd.GetUpdatedText());
			}
			catch (Exception exc)
			{
				ControllerArquivoLog.GeraraLog(exc);
				saida = string.Format("Ocorreu um erro ao excluir ao excluir o cliente {0}", exc.Message);
			}

			return saida;
		}

		/// <summary>
		/// Carregando informações do cliente.
		/// </summary>
		public static Pessoa Carregar(string Nome)
		{
			Spartacus.Database.Generic database;
			DataTable tabela = new DataTable("pessoas");
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "Select * from pessoa where nome = #nome#";

			cmd.AddParameter("nome", Spartacus.Database.Type.STRING);
			cmd.SetValue("nome", Nome);


			try
			{
				database = new Spartacus.Database.Sqlite(DB.GetStrConection());

				tabela = database.Query(cmd.GetUpdatedText(), "pessoas");
			}
			catch (Exception ex)
			{
				ControllerArquivoLog.GeraraLog(ex);
			}

			return PreencherCliente(tabela);
		}

		/// <summary>
		/// Carregando informações do cliente.
		/// </summary>
		public static Pessoa Carregar(int id)
		{
			Spartacus.Database.Generic database;
			DataTable tabela = new DataTable("pessoas");
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "Select * from pessoa where ID = #id#";

			cmd.AddParameter("id", Spartacus.Database.Type.INTEGER);
			cmd.SetValue("id", id.ToString());


			try
			{
				database = new Spartacus.Database.Sqlite(DB.GetStrConection());

				tabela = database.Query(cmd.GetUpdatedText(), "pessoas");
			}
			catch (Exception ex)
			{
				ControllerArquivoLog.GeraraLog(ex);
			}

			return PreencherCliente(tabela);

		}

		/// <summary>
		/// Retorna um DataTable com todas as informações de todos clientes
		/// </summary>
		/// <returns>The lista.</returns>
		public static DataTable CarregarLista()
		{
			Spartacus.Database.Generic database;
			DataTable tabela = new DataTable("Pessoas");
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = @"select  Id, Nome, Tipo, Email, SiglaEstado, Endereco, Cidade,Bairro
                          from pessoa where status <> #status#";

			cmd.AddParameter("status", Spartacus.Database.Type.BOOLEAN);
			cmd.SetValue("status", "0");//0(Flase)

			try
			{
				database = new Spartacus.Database.Sqlite(DB.GetStrConection());

				tabela = database.Query(cmd.GetUpdatedText(), "Pessoas");
			}
			catch (Exception ex)
			{
				ControllerArquivoLog.GeraraLog(ex);
			}

			return tabela;
		}

		/// <summary>
		/// Carregando lista com nome de todos clientes
		/// </summary>
		/// <returns>The lista.</returns>
		public static DataTable CarregarListaDeNomes()
		{
			char nivelAcesso = '0';//0(Flase)
			Spartacus.Database.Generic database;
			DataTable tabela = new DataTable("Pessoas");
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "select Nome from pessoa where status <> #status#";

			cmd.AddParameter("status", Spartacus.Database.Type.BOOLEAN);
			cmd.SetValue("status", nivelAcesso.ToString());

			try
			{
				database = new Spartacus.Database.Sqlite(DB.GetStrConection());

				tabela = database.Query(cmd.GetUpdatedText(), "Pessoas");
			}
			catch (Exception ex)
			{
				ControllerArquivoLog.GeraraLog(ex);
			}

			return tabela;
		}

		/// <summary>
		/// /Verificando a existencia do cliente
		/// </summary>
		/// <param name="Nome">Nome.</param>
		public static bool VerificarExistencia(string Nome)
		{
			bool PessoaEncontrada = false;
			Spartacus.Database.Generic dataBase;
			DataTable Tabela;
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "select * from pessoa where Nome = #nome#";

			cmd.AddParameter("Nome", Spartacus.Database.Type.STRING);

			cmd.SetValue("Nome", Nome);

			try
			{
				dataBase = new Spartacus.Database.Sqlite(DB.GetStrConection());

				Tabela = dataBase.Query(cmd.GetUpdatedText(), "Pessoa");


				if (Tabela.Rows.Count != 0)
				{
					PessoaEncontrada = true;
				}
			}
			catch (Exception Exc)
			{
				ControllerArquivoLog.GeraraLog(Exc);

				PessoaEncontrada = false;
			}

			return PessoaEncontrada;
		}

		/// <summary>
		/// Retornando o ID do cliente atravez do nome
		/// </summary>
		/// <param name="Nome"></param>
		/// <returns></returns>
		public static int VerificarID(string Nome)
		{
			int saida = 0;
			Spartacus.Database.Generic database;
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "Select ID from pessoa where nome = #nome#";

			cmd.AddParameter("nome", Spartacus.Database.Type.STRING);
			cmd.SetValue("nome", Nome);

			try
			{
				database = new Spartacus.Database.Sqlite(DB.GetStrConection());

				saida = int.Parse(database.ExecuteScalar(cmd.GetUpdatedText()));
			}
			catch (Exception ex)
			{
				ControllerArquivoLog.GeraraLog(ex);
			}
			return saida;
		}

		/// <summary>
		/// Retornando o nome atravez do ID
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public static string VerificarNome(int id)
		{
			string saida = "";
			Spartacus.Database.Generic database;
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "Select Nome from pessoa where Id = #id#";

			cmd.AddParameter("id", Spartacus.Database.Type.INTEGER);
			cmd.SetValue("id", id.ToString());

			try
			{
				database = new Spartacus.Database.Sqlite(DB.GetStrConection());

				saida = database.ExecuteScalar(cmd.GetUpdatedText());
			}
			catch (Exception ex)
			{
				ControllerArquivoLog.GeraraLog(ex);
			}
			return saida;
		}

		/// <summary>
		/// Verifica o e-mail do cliente atravez do seu nome
		/// </summary>
		/// <returns>The email.</returns>
		/// <param name="NomeDoCliente">Nome do cliente.</param>
		public static string ObterEmail(string NomeDoCliente)
		{
			string saida = "";
			Spartacus.Database.Generic database;
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "Select Email from pessoa where Nome = #nome#";

			cmd.AddParameter("nome", Spartacus.Database.Type.STRING);
			cmd.SetValue("nome", NomeDoCliente);

			try
			{
				database = new Spartacus.Database.Sqlite(DB.GetStrConection());

				saida = database.ExecuteScalar(cmd.GetUpdatedText());
			}
			catch (Exception ex)
			{
				ControllerArquivoLog.GeraraLog(ex);
			}
			return saida;
		}


		/// <summary>
		/// Preenchendo a classe Pessoa com as informações do DataTable
		/// </summary>
		/// <returns>The cliente.</returns>
		/// <param name="tabela">Tabela.</param>
		private static Pessoa PreencherCliente(DataTable tabela)
		{
			List<string> InfoCliente = new List<string>();
			Pessoa Cliente = new Pessoa();


			try
			{
				foreach (DataRow r in tabela.Rows)
				{
					foreach (DataColumn c in tabela.Columns)
					{
						InfoCliente.Add(r[c].ToString());
					}
				}

				Cliente.ID = Convert.ToInt16(InfoCliente[0]);
				Cliente.Nome = InfoCliente[1];
				Cliente.Tipo = InfoCliente[2];
				Cliente.Email = InfoCliente[3];
				Cliente.Logradouro = InfoCliente[4];
				Cliente.Complemento = InfoCliente[5];
				Cliente.SiglaEstado = InfoCliente[6];
				Cliente.Cidade = InfoCliente[7];
				Cliente.Bairro = InfoCliente[8];
				Cliente.Cep = InfoCliente[9];
				Cliente.Sexo = InfoCliente[10];
				Cliente.Cpf = InfoCliente[11];
				Cliente.Celular = InfoCliente[12];
				Cliente.DataDeNascimento = InfoCliente[13];
				Cliente.RazaoSocial = InfoCliente[14];
				Cliente.Cnpj = InfoCliente[15];
				Cliente.InscricaoEstadual = InfoCliente[16];
				Cliente.Status = Convert.ToBoolean(InfoCliente[17]);
			}
			catch (Exception ex)
			{
				ControllerArquivoLog.GeraraLog(ex);
			}

			InfoCliente.Clear();
			return Cliente;
		}
	}
}
