using System;
using System.IO;
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
                         values (#Nome#,#Tipo#,#Endereco#,#Email#,
                                 #SiglaEstado#,#Cidade#,#Bairro#,#CEP#,
                                 #Sexo#,#CPF#,#Celular#,#DataDeNascimento#,
                                 #RazaoSocial#,#Cnpj#,#InscricaoEstadual#);";


            cmd.AddParameter("Nome",Spartacus.Database.Type.STRING);
            cmd.AddParameter("Tipo",Spartacus.Database.Type.STRING);
            cmd.AddParameter("Endereco",Spartacus.Database.Type.STRING);
            cmd.AddParameter("Email",Spartacus.Database.Type.STRING);
            cmd.AddParameter("SiglaEstado",Spartacus.Database.Type.STRING);
            cmd.AddParameter("Cidade",Spartacus.Database.Type.STRING);
            cmd.AddParameter("Bairro",Spartacus.Database.Type.STRING);
            cmd.AddParameter("CEP",Spartacus.Database.Type.STRING);
            cmd.AddParameter("Sexo",Spartacus.Database.Type.STRING);
            cmd.AddParameter("CPF",Spartacus.Database.Type.STRING);
            cmd.AddParameter("Celular",Spartacus.Database.Type.STRING);
            cmd.AddParameter("DataDeNascimento",Spartacus.Database.Type.STRING);
            cmd.AddParameter("RazaoSocial",Spartacus.Database.Type.STRING);
            cmd.AddParameter("Cnpj",Spartacus.Database.Type.STRING);
            cmd.AddParameter("InscricaoEstadual",Spartacus.Database.Type.STRING);


            cmd.SetValue("Nome",cliente.Nome);
            cmd.SetValue("Tipo",cliente.Tipo);
            cmd.SetValue("Endereco",cliente.Endereco);
            cmd.SetValue("Email",cliente.Email);
            cmd.SetValue("SiglaEstado",cliente.SiglaEstado);
            cmd.SetValue("Cidade",cliente.Cidade);
            cmd.SetValue("Bairro",cliente.Bairro);
            cmd.SetValue("CEP",cliente.Cep);
            cmd.SetValue("Sexo",cliente.Sexo);
            cmd.SetValue("CPF",cliente.Cpf);
            cmd.SetValue("Celular",cliente.Celular);
            cmd.SetValue("DataDeNascimento",cliente.DataDeNascimento);
            cmd.SetValue("RazaoSocial",cliente.RazaoSocial);
            cmd.SetValue("Cnpj",cliente.Cnpj);
            cmd.SetValue("InscricaoEstadual",cliente.InscricaoEstadual);

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
                    Nome = #Nome#,
                    Tipo = #Tipo#,
                    Endereco = #Endereco#,
                    Email = #Email#,
                    SiglaEstado = #SiglaEstado#,
                    Cidade = #Cidade#,
                    Bairro = #Bairro#,
                    CEP = #CEP#,
                    Sexo = #Sexo#,
                    CPF = #CPF#,
                    Celular = #Celular#,
                    DataDeNascimento = #DataDeNascimento#,
                    RazaoSocial = #RazaoSocial#,
                    Cnpj = #Cnpj#,
                    InscricaoEstadual = #InscricaoEstadual#
                    where ID = #Id#";
                   

            cmd.AddParameter("Id",Spartacus.Database.Type.INTEGER);
            cmd.AddParameter("Nome",Spartacus.Database.Type.STRING);
            cmd.AddParameter("Tipo",Spartacus.Database.Type.STRING);
            cmd.AddParameter("Endereco",Spartacus.Database.Type.STRING);
            cmd.AddParameter("Email",Spartacus.Database.Type.STRING);
            cmd.AddParameter("SiglaEstado",Spartacus.Database.Type.STRING);
            cmd.AddParameter("Cidade",Spartacus.Database.Type.STRING);
            cmd.AddParameter("Bairro",Spartacus.Database.Type.STRING);
            cmd.AddParameter("CEP",Spartacus.Database.Type.STRING);
            cmd.AddParameter("Sexo",Spartacus.Database.Type.STRING);
            cmd.AddParameter("CPF",Spartacus.Database.Type.STRING);
            cmd.AddParameter("Celular",Spartacus.Database.Type.STRING);
            cmd.AddParameter("DataDeNascimento",Spartacus.Database.Type.STRING);
            cmd.AddParameter("RazaoSocial",Spartacus.Database.Type.STRING);
            cmd.AddParameter("Cnpj",Spartacus.Database.Type.STRING);
            cmd.AddParameter("InscricaoEstadual",Spartacus.Database.Type.STRING);

            cmd.SetValue("Id",cliente.ID);
            cmd.SetValue("Nome",cliente.Nome);
            cmd.SetValue("Tipo",cliente.Tipo);
            cmd.SetValue("Endereco",cliente.Endereco);
            cmd.SetValue("Email",cliente.Email);
            cmd.SetValue("SiglaEstado",cliente.SiglaEstado);
            cmd.SetValue("Cidade",cliente.Cidade);
            cmd.SetValue("Bairro",cliente.Bairro);
            cmd.SetValue("CEP",cliente.Cep);
            cmd.SetValue("Sexo",cliente.Sexo);
            cmd.SetValue("CPF",cliente.Cpf);
            cmd.SetValue("Celular",cliente.Celular);
            cmd.SetValue("DataDeNascimento",cliente.DataDeNascimento);
            cmd.SetValue("RazaoSocial",cliente.RazaoSocial);
            cmd.SetValue("Cnpj",cliente.Cnpj);
            cmd.SetValue("InscricaoEstadual",cliente.InscricaoEstadual);

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

            cmd.v_text = "delete from pessoa Where Nome = #Nome#";

            cmd.AddParameter("Nome",Spartacus.Database.Type.INTEGER);
            cmd.SetValue("Nome",Nome);

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

            cmd.AddParameter("Nome",Spartacus.Database.Type.STRING);
            cmd.SetValue("Nome",Nome);

            try
            {
                dataBase = new Spartacus.Database.Sqlite(DB.GetStrConection());

                Tabela = dataBase.Query(cmd.GetUpdatedText(),"Pessoa");


                if(Tabela.Rows.Count != 0)
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

            cmd.v_text = "Select * from pessoa where nome = #Nome#";

            cmd.AddParameter("Nome",Spartacus.Database.Type.STRING);
            cmd.SetValue("Nome", Nome);


            try
            {
                database = new Spartacus.Database.Sqlite(DB.GetStrConection());

                tabela = database.Query(cmd.GetUpdatedText(),"pessoas");
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

            cmd.v_text = "Select * from pessoa where nome = #Id#";

            cmd.AddParameter("Id",Spartacus.Database.Type.INTEGER);
            cmd.SetValue("Id", id.ToString());


            try
            {
                database = new Spartacus.Database.Sqlite(DB.GetStrConection());

                tabela = database.Query(cmd.GetUpdatedText(),"pessoas");
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

                tabela = database.Query("select * from pessoa","Pessoas");
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
    }
}
