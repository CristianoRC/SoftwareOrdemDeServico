using System;
using System.IO;
using System.Collections.Generic;
using Model;
using System.Data;

namespace Controller
{
    public static class ControllerTrabalho
    {
        /// <summary>
        /// "Criando" um novo trabalho
        /// </summary>
        /// <param name="infoTrabalho">Info trabalho.</param>
        public static string Salvar(Trabalho infoTrabalho)
        {
            Spartacus.Database.Generic database;
            Spartacus.Database.Command cmd = new Spartacus.Database.Command();

            cmd.v_text = " insert into trabalhos (OrdemDeServico,Valor) values(#Os#,#Valor#)";

            cmd.AddParameter("Os",Spartacus.Database.Type.INTEGER);
            cmd.AddParameter("Valor",Spartacus.Database.Type.REAL);

            cmd.SetValue("Os", infoTrabalho.IdOrdemDeServico.ToString());
            cmd.SetValue("Valor",infoTrabalho.Valor.ToString());

            try
            {
                database = new Spartacus.Database.Sqlite(DB.GetStrConection());

                database.Execute(cmd.GetUpdatedText());

                return "Trabalho foi salvo com sucesso!";
            }
            catch (Exception ex)
            {
                ControllerArquivoLog.GeraraLog(ex);
                return String.Format("Ocorreu um erro: {0}",ex.Message);
            }
        }

        /// <summary>
        /// Deletando informações sobre o trabalho
        /// </summary>
        /// <param name="ID">I.</param>
        public static string Deletar(int ID)
        {
            Spartacus.Database.Generic database;
            Spartacus.Database.Command cmd = new Spartacus.Database.Command();

            cmd.v_text = "delete from trabalhos where id = #Id#";
                
            cmd.AddParameter("Id",Spartacus.Database.Type.INTEGER);
            cmd.SetValue("Id",ID);

            try
            {
                database = new Spartacus.Database.Sqlite(DB.GetStrConection());

                database.Execute(cmd.GetUpdatedText());

                return "Trabalho foi deletado com sucesso!";
            }
            catch (Exception ex)
            {
                ControllerArquivoLog.GeraraLog(ex);

                return String.Format("Ocorreu um erro: {0}",ex.Message);
            }
        }

        /// <summary>
        /// Retornando todos trabalhos.
        /// </summary>
        /// <returns>The lista.</returns>
        public static DataTable CarregarLista()
        {
            Spartacus.Database.Generic database;
            System.Data.DataTable tabela = new DataTable("Trabalhos");

            try
            {
                database = new Spartacus.Database.Sqlite(DB.GetStrConection());

                tabela = database.Query("select * from trabalho","Trabalhos");
            }
            catch (Exception ex)
            {
                ControllerArquivoLog.GeraraLog(ex);
            }

            return tabela;
        }

//        public static Trabalho Carregar(int ID)
//        {
//
//        }
//
//        public static Trabalho Carregar(int NumeroOS)
//        {
//
//        }
    }
}
//TODO:Dependendo como ficar, desenvolver uma função para mudar a situação da OS.