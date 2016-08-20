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

            string query = string.Format
                (@" insert into trabalho (OrdemDeServico,Valor) values({0},'{1}')",
                    infoTrabalho.IdOrdemDeServico,infoTrabalho.Valor);


            try
            {
                database = new Spartacus.Database.Sqlite(DB.GetStrConection());

                database.Execute(query);

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

            string query = string.Format(@"delete from trabalho where id = {0}",ID);


            try
            {
                database = new Spartacus.Database.Sqlite(DB.GetStrConection());

                database.Execute(query);

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