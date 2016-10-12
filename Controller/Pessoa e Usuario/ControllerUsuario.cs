using System;
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
        public static String Criar(String Nome, String Senha, char NivelAcesso)
        {
            string Saida = "";

            if (!VerificarExistenciaUsuario(Nome))
            {
                Spartacus.Database.Generic dataBase;
                Spartacus.Database.Command cmd = new Spartacus.Database.Command();

                cmd.v_text = "insert into Tecnicos (login,senha,nivelacesso,Status) values (#login#,#senha#,#nivelacesso#,#status#);";

                cmd.AddParameter("login", Spartacus.Database.Type.STRING);
                cmd.AddParameter("senha", Spartacus.Database.Type.STRING);
                cmd.AddParameter("nivelacesso", Spartacus.Database.Type.BOOLEAN);
                cmd.AddParameter("Status", Spartacus.Database.Type.BOOLEAN);

                cmd.SetValue("login", Nome.ToLower());
                cmd.SetValue("senha", Senha);
                cmd.SetValue("nivelacesso", NivelAcesso.ToString());
                cmd.SetValue("status", Convert.ToString('1'));

                try
                {
                    dataBase = new Spartacus.Database.Sqlite(DB.GetStrConection());

                    dataBase.Execute(cmd.GetUpdatedText());

                    Saida = "Tecnico cadastrado com sucesso!";
                }
                catch (Exception Exc)
                {
                    ControllerArquivoLog.GeraraLog(Exc);

                    Saida = ("Erro: " + Exc.Message);
                }
            }
            else
            {
                Saida = "Erro! já existe um usuário com esse mesmo login";
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
        public static String Editar(int Id, String Nome, String Senha, char NivelAcesso)
        {
            string Saida = "";
            Spartacus.Database.Generic dataBase;
            Spartacus.Database.Command cmd = new Spartacus.Database.Command();

            cmd.v_text = @"update Tecnicos  set 
                           login = #login#, 
                           senha = #senha#, 
                           nivelacesso = #nivelacesso#  
                           Where id = #id#;";

            cmd.AddParameter("login", Spartacus.Database.Type.STRING);
            cmd.AddParameter("senha", Spartacus.Database.Type.STRING);
            cmd.AddParameter("nivelacesso", Spartacus.Database.Type.BOOLEAN);
            cmd.AddParameter("id", Spartacus.Database.Type.INTEGER);

            cmd.SetValue("login", Nome.ToLower());
            cmd.SetValue("senha", Senha);
            cmd.SetValue("nivelacesso", NivelAcesso.ToString());
            cmd.SetValue("id", Id.ToString());


            try
            {
                dataBase = new Spartacus.Database.Sqlite(DB.GetStrConection());

                dataBase.Execute(cmd.GetUpdatedText());

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
        /// Carregando Lista todas as informações de todos usuários usuarios.
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

                Tabela = dataBase.Query("Select Id,login from tecnicos where Status <> '0'", "Tecnicos");
            }
            catch (Exception Exc)
            {
                ControllerArquivoLog.GeraraLog(Exc);
            }

            return Tabela;
        }

        /// <summary>
        /// Carregando Lista com nome de todos usuarios.
        /// </summary>
        /// <returns></returns>
        public static DataTable CarregarListaDeNomes()
        {
            Spartacus.Database.Generic dataBase;
            System.Data.DataTable Tabela;
            Tabela = new DataTable("Tecnicos");


            try
            {
                dataBase = new Spartacus.Database.Sqlite(DB.GetStrConection());

                Tabela = dataBase.Query("Select login from tecnicos where Status <> '0'", "Tecnicos");
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
        public static tecnico Carregar(int ID)
        {
            tecnico UsuarioBase = new tecnico();

            Spartacus.Database.Generic dataBase;
            System.Data.DataTable Tabela;

            try
            {
                Tabela = new DataTable("Tecnicos");
                dataBase = new Spartacus.Database.Sqlite(DB.GetStrConection());

                Tabela = dataBase.Query(String.Format("Select * from tecnicos WHERE Id = {0}", ID), "Tecnicos");


                foreach (DataRow r in Tabela.Rows)
                {
                    foreach (DataColumn c in Tabela.Columns)
                    {
                        switch (c.ColumnName)
                        {
                            case "Id":
                                UsuarioBase.Id = Convert.ToInt32(r[c]);
                                break;
                            case "Login":
                                UsuarioBase.Nome = r[c].ToString();
                                break;
                            case "Senha":
                                UsuarioBase.Senha = r[c].ToString();
                                break;
                            case "NivelAcesso":
                                UsuarioBase.NivelAcesso = Convert.ToBoolean(r[c]);
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
        public static tecnico Carregar(string Login)
        {
            tecnico UsuarioBase = new tecnico();

            Spartacus.Database.Generic dataBase;
            System.Data.DataTable Tabela;

            try
            {
                dataBase = new Spartacus.Database.Sqlite(DB.GetStrConection());

                Tabela = dataBase.Query(String.Format("Select * from tecnicos WHERE Login = '{0}'", Login.ToLower()), "Tecnicos");

                foreach (DataRow r in Tabela.Rows)
                {
                    foreach (DataColumn c in Tabela.Columns)
                    {
                        switch (c.ColumnName)
                        {
                            case "Id":
                                UsuarioBase.Id = Convert.ToInt32(r[c]);
                                break;
                            case "Login":
                                UsuarioBase.Nome = r[c].ToString();
                                break;
                            case "Senha":
                                UsuarioBase.Senha = r[c].ToString();
                                break;
                            case "NivelAcesso":
                                UsuarioBase.NivelAcesso = Convert.ToBoolean(r[c]);
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
        /// Verificando se o usuário existe.
        /// </summary>
        /// <param name="Nome"></param>
        /// <returns></returns>
        public static bool Autenticar(string Login, string Senha)
        {
            bool UsuarioEncontrado = false;
            Spartacus.Database.Generic dataBase;
            DataTable Tabela = new DataTable("Tecnicos");
            Spartacus.Database.Command cmd = new Spartacus.Database.Command();

            cmd.v_text = "Select * from Tecnicos where Login = #login# and Senha = #senha# and Status <> #status#";

            cmd.AddParameter("Login", Spartacus.Database.Type.STRING);
            cmd.AddParameter("senha", Spartacus.Database.Type.STRING);
            cmd.AddParameter("status", Spartacus.Database.Type.BOOLEAN);


            cmd.SetValue("status", Convert.ToString('0'));
            cmd.SetValue("Login", Login.ToLower());
            cmd.SetValue("senha", Senha);

            try
            {
                dataBase = new Spartacus.Database.Sqlite(DB.GetStrConection());
                    
                Tabela = dataBase.Query(cmd.GetUpdatedText(), "Tecnicos");

                if (Tabela.Rows.Count == 1)
                {
                    UsuarioEncontrado = true;
                }
            }
            catch (Spartacus.Database.Exception ex)
            {
                ControllerArquivoLog.GeraraLog(ex);
                UsuarioEncontrado = false;
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
            string saida = String.Format("O técnico foi excluido com sucesso!");
            Spartacus.Database.Generic dataBase;

            Spartacus.Database.Command cmd = new Spartacus.Database.Command();

            cmd.v_text = "update Tecnicos set Status = #status# Where Id = #id#";

            cmd.AddParameter("id", Spartacus.Database.Type.INTEGER);
            cmd.AddParameter("status", Spartacus.Database.Type.BOOLEAN);

            cmd.SetValue("id", ID.ToString());
            cmd.SetValue("status", Convert.ToString('0'));

            try
            {
                dataBase = new Spartacus.Database.Sqlite(DB.GetStrConection());

                dataBase.Execute(cmd.GetUpdatedText());
            }
            catch (Spartacus.Database.Exception exc)
            {
                ControllerArquivoLog.GeraraLog(exc);

                saida = string.Format("Ocorreu um erro ao excluir o técnico:", exc.Message);
            }

            return saida;
        }

        /// <summary>
        /// Excluindo usuario
        /// </summary>
        /// <param name="Nome"></param>
        /// <returns>Resultado da operação</returns>
        public static string Deletar(string login)
        {
            string saida = String.Format("O técnico foi excluido com sucesso!");
            Spartacus.Database.Generic dataBase;
            Spartacus.Database.Command cmd = new Spartacus.Database.Command();


            cmd.v_text = "update Tecnicos set Status = #status# Where Login = #login#";

            cmd.AddParameter("login", Spartacus.Database.Type.STRING);
            cmd.AddParameter("status", Spartacus.Database.Type.BOOLEAN);

            cmd.SetValue("status", Convert.ToString('0'));
            cmd.SetValue("login", login.ToLower());

            try
            {
                dataBase = new Spartacus.Database.Sqlite(DB.GetStrConection());

                dataBase.Execute(cmd.GetUpdatedText());
            }
            catch (Spartacus.Database.Exception exc)
            {
                ControllerArquivoLog.GeraraLog(exc);

                saida = string.Format("Ocorreu um erro ao excluir o técnico:", exc.Message);
            }

            return saida;
        }

        /// <summary>
        /// Verificando se o login já esta sendo utilizado
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public static bool VerificarExistenciaUsuario(string login)
        {
            Spartacus.Database.Generic database;
            Spartacus.Database.Command cmd = new Spartacus.Database.Command();
            DataTable tabela = new DataTable("Tabela");
       
            cmd.v_text = "select Login from Tecnicos where login = #login#";

            cmd.AddParameter("login", Spartacus.Database.Type.STRING);

            cmd.SetValue("login", login.ToLower());

            try
            {
                database = new Spartacus.Database.Sqlite(DB.GetStrConection());

                tabela = database.Query(cmd.GetUpdatedText(), "Tecnicos");

                if (tabela.Rows.Count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Spartacus.Database.Exception exc)
            {
                ControllerArquivoLog.GeraraLog(exc);

                return true;
            }
        }
    }
}