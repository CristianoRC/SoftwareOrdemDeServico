using System;
using System.IO;
using System.Collections.Generic;
using Model.Pessoa_e_Usuario;
using System.Data;

namespace Controller
{
    /// <summary>
    /// Usada como classe dos técnicos da empresa, cada um com o seu login.
    /// </summary>
    public static class ControllerUsuario
    {

        /// <summary>
        /// Salvando novo usuário
        /// </summary>
        /// <param name="Nome"></param>
        /// <param name="Senha"></param>
        /// <param name="NivelAcesso"></param>
        /// <returns></returns>
        public static String Salvar(String Nome, String Senha, char NivelAcesso) //Criar função para verificar a existencia de Login
        {
            // 0 false; 1 True;

            string Saida = "";

            Spartacus.Database.Generic dataBase;

            try
            {
                dataBase = new Spartacus.Database.Sqlite(DB.GetStrConection());

                dataBase.Execute(String.Format(
                    @"insert into Tecnicos  
                      (login,senha,nivelacesso)
                      values ('{0}','{2}',{3});",
                      Nome,Senha,NivelAcesso));

                Saida = "Tecnico cadastrado com sucesso!";
            }
            catch (Exception Exc)
            {
                ControllerArquivoLog.GeraraLog(Exc);

                Saida = ("Erro: " + Exc.Message);
            }

            return Saida;
          } 
            
        /// <summary>
        /// Editando usuário
        /// </summary>
        /// <param name="Nome"></param>
        /// <param name="Senha"></param>
        /// <param name="NivelAcesso"></param>
        /// <returns></returns>
        public static String Editar(int Id,String Nome, String Senha, char NivelAcesso)
        {
            string Saida = "";
            Spartacus.Database.Generic dataBase;

            try
            {
                dataBase = new Spartacus.Database.Sqlite(DB.GetStrConection());

                dataBase.Execute(String.Format(
                    @"update Tecnicos  set 
                      login = '{0}', 
                      senha = '{1}', 
                      nivelacesso = {2}  
                      Where id ={3} ;",
                      Nome,Senha,NivelAcesso,Id));

                Saida = "Tecnico editado com sucesso!";
            }
            catch (Exception Exc)
			{
                ControllerArquivoLog.GeraraLog(Exc);

                Saida = "Erro: " + Exc.Message;
            }

             return Saida;
        }

        /// <summary>
        /// Carregando Lista com nome de todos usuarios.
        /// </summary>
        /// <returns></returns>
        public static DataTable CarregarLista()
        {
            Spartacus.Database.Generic dataBase;
            System.Data.DataTable Tabela;
            Tabela = new DataTable("Tecnicos");


            try
            {
                dataBase = new Spartacus.Database.Sqlite(DB.GetStrConection());

                Tabela = dataBase.Query("Select * from tecnicos","Tecnicos");
            }
            catch (Exception Exc)
            {
                ControllerArquivoLog.GeraraLog(Exc);
            }

            return Tabela;
        }

        /// <summary>
        /// Carregando usuario.
        /// </summary>
        /// <param name="Nome"></param>
        /// <returns>Usuario</returns>
        public static tecnico Carregar(int ID) //Verificar Código que carrega as informações para classe Tecnicos.
        {
            tecnico UsuarioBase = new tecnico();

            Spartacus.Database.Generic dataBase;
            System.Data.DataTable Tabela;

            try
            {
                Tabela = new DataTable("Tecnicos");
                dataBase = new Spartacus.Database.Sqlite(DB.GetStrConection());

                Tabela = dataBase.Query(String.Format("Select * from tecnicos WHERE Id = {0}",ID),"Tecnicos");


                foreach (DataRow r in Tabela.Rows) 
                {
                    foreach (DataColumn c in Tabela.Columns) 
                    {
                        switch (c.ColumnName) 
                        {
                            case  "Id":
                                UsuarioBase.Id = Convert.ToInt32(r[c]);
                                break;
                            case  "Login":
                                UsuarioBase.Nome = r[c].ToString();
                                break;
                            case  "Senha":
                                UsuarioBase.Senha = r[c].ToString();
                                break;
                            case  "NivelAcesso":
                                UsuarioBase.NivelAcesso = Convert.ToChar(r[c]);
                                break;
                        }
                    }
                }
            }
            catch (Exception exc)
			{
                ControllerArquivoLog.GeraraLog(exc);
            }

            return UsuarioBase;
        }

        /// <summary>
        /// Carregando usuario.
        /// </summary>
        /// <param name="Nome"></param>
        /// <returns>Usuario</returns>
        public static tecnico Carregar(string Login) //Verificar Código que carrega as informações para classe Tecnicos.
        {
            tecnico UsuarioBase = new tecnico();

            Spartacus.Database.Generic dataBase;
            System.Data.DataTable Tabela;

            try
            {
                dataBase = new Spartacus.Database.Sqlite(DB.GetStrConection());

                Tabela = dataBase.Query(String.Format("Select * from tecnicos WHERE Login = '{0}'",Login),"Tecnicos");

                foreach (DataRow r in Tabela.Rows) 
                {
                    foreach (DataColumn c in Tabela.Columns) 
                    {
                        switch (c.ColumnName) 
                        {
                            case  "Id":
                                UsuarioBase.Id = Convert.ToInt32(r[c]);
                                break;
                            case  "Login":
                                UsuarioBase.Nome = r[c].ToString();
                                break;
                            case  "Senha":
                                UsuarioBase.Senha = r[c].ToString();
                                break;
                            case  "NivelAcesso":
                                UsuarioBase.NivelAcesso = Convert.ToChar(r[c]);
                                break;
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                ControllerArquivoLog.GeraraLog(exc);
            }

            return UsuarioBase;
        }

        /// <summary>
        /// Verificando de o suario existe.
        /// </summary>
        /// <param name="Nome"></param>
        /// <returns></returns>
        public static bool Autenticar(string Nome, string Senha)
        {
            bool UsuarioEncontrado = false;
            Spartacus.Database.Generic dataBase;
            System.Data.DataTable Tabela;

            try
            {
                dataBase = new Spartacus.Database.Sqlite(DB.GetStrConection());

                Tabela = dataBase.Query(String.Format(
                    @"select * from tecnicos 
                    where Login = '{0}' 
                    and Senha = '{1}'",
                    Nome,Senha),
                    "Tecnicos");
                
                if(Tabela.Rows.Count != 0)
                {
                    UsuarioEncontrado = true;
                }
            }
            catch (Exception Exc)
            {
                ControllerArquivoLog.GeraraLog(Exc);

                UsuarioEncontrado = false;
            }

            return UsuarioEncontrado;
        }

        /// <summary>
        /// Excluindo usuario
        /// </summary>
        /// <param name="Nome"></param>
        /// <returns>Resultado da operação</returns>
        public static string Deletar(int ID)
        {
            string saida = String.Format("O técnico foi excluida com sucesso!");
            Spartacus.Database.Generic dataBase;

            try
            {
                dataBase = new Spartacus.Database.Sqlite(DB.GetStrConection());

                dataBase.Execute(String.Format("delete from Tecnicos where Id = {0}",ID));
            }
            catch (Exception exc)
            {
                saida = string.Format("Ocorreu um erro ao excluir o técnico:", exc.Message);
            }

            return saida;
        }
    }
}