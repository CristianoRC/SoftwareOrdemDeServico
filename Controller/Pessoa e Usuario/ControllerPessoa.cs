using System;
using System.Collections.Generic;
using Model.Pessoa_e_Usuario;
using System.Data;

namespace Controller
{
    public static class ControllerPessoa
    {

        /// <summary>
        /// Salvando informações de usuario
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="endereco"></param>
        /// <param name="email"></param>
        /// <param name="situacao"></param>
        /// <param name="siglaEstado"></param>
        /// <param name="cidade"></param>
        /// <param name="bairro"></param>
        /// <param name="cep"></param>
        /// <param name="observacoes"></param>
        /// <param name="cnpj"></param>
        /// <param name="contato"></param>
        /// <param name="inscricaoestadual"></param>
        /// <param name="razaosocial"></param>
        /// <returns></returns>
        public static String Salvar(Pessoa cliente)
        {
            string Saida = "";
            Spartacus.Database.Generic database;
            Spartacus.Database.Command cmd = new Spartacus.Database.Command();


            cmd.v_text = @"insert into pessoa  
                        (Nome,Tipo,Endereco,Email,
                         SiglaEstado,Cidade,Bairro,CEP,
                         Sexo,CPF,Celular,DataDeNascimento,
                         RazaoSocial,Cnpj,InscricaoEstadual)
                         values (#nome#,#tipo#,#endereco#,#email#,
                                 #siglaEstado#,#cidade#,#bairro#,#cep#,
                                 #sexo#,#cpf#,#celular#,#dataDeNascimento#,
                                 #razaoSocial#,#cnpj#,#inscricaoEstadual#);";


            cmd.AddParameter("nome", Spartacus.Database.Type.STRING);
            cmd.AddParameter("tipo", Spartacus.Database.Type.STRING);
            cmd.AddParameter("endereco", Spartacus.Database.Type.STRING);
            cmd.AddParameter("email", Spartacus.Database.Type.STRING);
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


            cmd.SetValue("nome", cliente.Nome);
            cmd.SetValue("tipo", cliente.Tipo);
            cmd.SetValue("endereco", cliente.Endereco);
            cmd.SetValue("email", cliente.Email);
            cmd.SetValue("siglaEstado", cliente.SiglaEstado);
            cmd.SetValue("cidade", cliente.Cidade);
            cmd.SetValue("bairro", cliente.Bairro);
            cmd.SetValue("cep", cliente.Cep);
            cmd.SetValue("sexo", cliente.Sexo);
            cmd.SetValue("cpd", cliente.Cpf);
            cmd.SetValue("celular", cliente.Celular);
            cmd.SetValue("dataDeNascimento", cliente.DataDeNascimento);
            cmd.SetValue("razaoSocial", cliente.RazaoSocial);
            cmd.SetValue("cnpj", cliente.Cnpj);
            cmd.SetValue("inscricaoEstadual", cliente.InscricaoEstadual);

            if (Verificar(cliente.Nome) == false)
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
        /// Editando pessoa Jurídica na pasta "J"(Pasta usada para guardar todas as pessoas jurídicas no diretorio do software)
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="endereco"></param>
        /// <param name="email"></param>
        /// <param name="situacao"></param>
        /// <param name="siglaEstado"></param>
        /// <param name="cidade"></param>
        /// <param name="bairro"></param>
        /// <param name="cep"></param>
        /// <param name="observacoes"></param>
        /// <param name="cnpj"></param>
        /// <param name="contato"></param>
        /// <param name="inscricaoestadual"></param>
        /// <param name="razaosocial"></param>
        /// <returns></returns>
        public static String Editar(Pessoa cliente) //Sempre gravar informações sobre o ultimo usuário carregado(No Form) para poder editar
        {
            string Saida = "";

            Spartacus.Database.Generic database;
            Spartacus.Database.Command cmd = new Spartacus.Database.Command();

            cmd.v_text = @"update pessoa set 
                    Nome = #nome#,
                    Tipo = #tipo#,
                    Endereco = #endereco#,
                    Email = #email#,
                    SiglaEstado = #siglaEstado#,
                    Cidade = #cidade#,
                    Bairro = #bairro#,
                    CEP = #cep#,
                    Sexo = #sexo#,
                    CPF = #cpf#,
                    Celular = #celular#,
                    DataDeNascimento = #dataDeNascimento#,
                    RazaoSocial = #razaoSocial#,
                    Cnpj = #cnpj#,
                    InscricaoEstadual = #inscricaoEstadual#
                    where ID = #id#";


            cmd.AddParameter("id", Spartacus.Database.Type.INTEGER);
            cmd.AddParameter("nome", Spartacus.Database.Type.STRING);
            cmd.AddParameter("tipo", Spartacus.Database.Type.STRING);
            cmd.AddParameter("endereco", Spartacus.Database.Type.STRING);
            cmd.AddParameter("email", Spartacus.Database.Type.STRING);
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

            cmd.SetValue("id", cliente.ID);
            cmd.SetValue("nome", cliente.Nome);
            cmd.SetValue("tipo", cliente.Tipo);
            cmd.SetValue("endereco", cliente.Endereco);
            cmd.SetValue("email", cliente.Email);
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
            string saida = String.Format("cliente {0} foi excluido com sucesso!", Nome);
            Spartacus.Database.Generic database;
            Spartacus.Database.Command cmd = new Spartacus.Database.Command();

            cmd.v_text = "delete from pessoa Where Nome = #nome#";

            cmd.AddParameter("nome", Spartacus.Database.Type.INTEGER);
            cmd.SetValue("nome", Nome);

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
        /// /Verificando a existencia do cliente
        /// </summary>
        /// <param name="Nome">Nome.</param>
        public static bool Verificar(string Nome)
        {
            bool PessoaEncontrada = false;
            Spartacus.Database.Generic dataBase;
            System.Data.DataTable Tabela;
            Spartacus.Database.Command cmd = new Spartacus.Database.Command();

            cmd.v_text = "select * from pessoa where Nome = #Nome#";

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
        /// Carregando lista com todos as informações de todos clientes
        /// </summary>
        /// <returns>The lista.</returns>
        public static DataTable CarregarLista()
        {
            Spartacus.Database.Generic database;
            System.Data.DataTable tabela = new DataTable("Pessoas");

            try
            {
                database = new Spartacus.Database.Sqlite(DB.GetStrConection());

                tabela = database.Query("select * from pessoa", "Pessoas");
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
            Spartacus.Database.Generic database;
            System.Data.DataTable tabela = new DataTable("Pessoas");

            try
            {
                database = new Spartacus.Database.Sqlite(DB.GetStrConection());

                tabela = database.Query("select Nome from pessoa", "Pessoas");
            }
            catch (Exception ex)
            {
                ControllerArquivoLog.GeraraLog(ex);
            }

            return tabela;
        }
            
        /// <summary>
        /// Preenchendo a classe Pessoa com as informações do DataTable
        /// </summary>
        /// <returns>The cliente.</returns>
        /// <param name="informacoes">Informacoes.</param>
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

                Cliente.ID = InfoCliente[0];
                Cliente.Nome = InfoCliente[1];
                Cliente.Tipo = InfoCliente[2];
                Cliente.Endereco = InfoCliente[3];
                Cliente.Email = InfoCliente[4];
                Cliente.SiglaEstado = InfoCliente[5];
                Cliente.Cidade = InfoCliente[6];
                Cliente.Bairro = InfoCliente[7];
                Cliente.Cep = InfoCliente[8];
                Cliente.Sexo = InfoCliente[9];
                Cliente.Celular = InfoCliente[10];
                Cliente.DataDeNascimento = InfoCliente[11];
                Cliente.RazaoSocial = InfoCliente[12];
                Cliente.Cnpj = InfoCliente[13];
                Cliente.InscricaoEstadual = InfoCliente[14];
            }
            catch (Exception ex)
            {
                ControllerArquivoLog.GeraraLog(ex);
            }
            return Cliente;
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
            DataTable tabela = new DataTable();

            cmd.v_text = "Select ID from pessoa where nome = #nome#";

            cmd.AddParameter("nome", Spartacus.Database.Type.STRING);
            cmd.SetValue("nome", Nome);

            try
            {
                database = new Spartacus.Database.Sqlite(DB.GetStrConection());

                tabela = database.Query(cmd.GetUpdatedText(), "pessoas");


                foreach (DataRow r in tabela.Rows)
                {
                    foreach (DataColumn c in tabela.Columns)
                    {
                        saida = Convert.ToInt16(r[c]);
                    }
                }
            }
            catch (Exception ex)
            {
                ControllerArquivoLog.GeraraLog(ex);
            }
            return saida;
        }
    }
}
