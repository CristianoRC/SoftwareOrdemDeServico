using System;
using System.Data;
using Model;
using System.Collections.Generic;


namespace Controller
{
    public static class ControllerServico
    {
        /// <summary>
        /// Salvando um novo serviço, Seriço que é gerado apartir da finalização de uma Ordem de serviço
        /// </summary>
        /// <param name="ServicoBase">Servico Base.</param>
        public static string Salvar(Servico ServicoBase)
        {
            Spartacus.Database.Generic database;
            Spartacus.Database.Command cmd = new Spartacus.Database.Command();

            cmd.v_text = "Insert into Trabalhos(OrdemDeServico,Valor,Descricao) values (#idordemdeservico#,#valor#,#descricao#)";
            cmd.AddParameter("idordemdeservico", Spartacus.Database.Type.INTEGER);
            cmd.AddParameter("valor", Spartacus.Database.Type.REAL);
            cmd.AddParameter("descricao", Spartacus.Database.Type.STRING);
            cmd.SetLocale("valor", Spartacus.Database.Locale.EUROPEAN);


            cmd.SetValue("idordemdeservico", ServicoBase.IdOrdemDeServico.ToString());
            cmd.SetValue("valor", ServicoBase.Valor.ToString());
            cmd.SetValue("descricao", ServicoBase.Descricao);

            try
            {
                database = new Spartacus.Database.Sqlite(DB.GetStrConection());

                database.Execute(cmd.GetUpdatedText());

                return "Serviço foi salvo com sucesso";
            }
            catch (Spartacus.Database.Exception ex)
            {
                ControllerArquivoLog.GeraraLog(ex);

                return String.Format("Ocorreu um erro ao tentar salvar o serviço{0}", ex.Message);
            }
        }

        /// <summary>
        /// Carregando as informações de um trabalhos
        /// </summary>
        /// <param name="NumeroOs">Numero os.</param>
        public static Servico Carregar(int NumeroOs)
        {
            DataTable tabela = new DataTable("Trabalhos");
            Spartacus.Database.Generic database;
            Spartacus.Database.Command cmd = new Spartacus.Database.Command();

            cmd.v_text = "Select * from Trabalhos where OrdemDeServico = #idOS#";
            cmd.AddParameter("idOS", Spartacus.Database.Type.INTEGER);
            cmd.SetValue("idOS", NumeroOs.ToString());

            try
            {
                database = new Spartacus.Database.Sqlite(DB.GetStrConection());

                tabela = database.Query(cmd.GetUpdatedText(), "Trabalhos");
            }
            catch (Spartacus.Database.Exception ex)
            {
                ControllerArquivoLog.GeraraLog(ex);
            }

            return PreencherTrabalho(tabela);
        }

        /// <summary>
        /// Deletando serviço gerado
        /// </summary>
        /// <param name="NumeroOs">Numero os.</param>
        public static string Deletar(int NumeroOs)
        {
            Spartacus.Database.Generic database;
            Spartacus.Database.Command cmd = new Spartacus.Database.Command();

            cmd.v_text = "delete from Trabalhos where ID = #id#";
            cmd.AddParameter("id", Spartacus.Database.Type.INTEGER);
            cmd.SetValue("id", NumeroOs.ToString());

            try
            {
                database = new Spartacus.Database.Sqlite(DB.GetStrConection());

                database.Execute(cmd.GetUpdatedText());

                return "Serviço deletado com sucesso!";
            }
            catch (Spartacus.Database.Exception ex)
            {
                ControllerArquivoLog.GeraraLog(ex);

                return String.Format("Ocorreu um erro:{0}", ex.Message);
            }
        }

        /// <summary>
        /// Carregando lista de servicos executados.
        /// </summary>
        /// <returns>The lista.</returns>
        public static DataTable CarregarLista()
        {
            Spartacus.Database.Generic database;
            Spartacus.Database.Command cmd = new Spartacus.Database.Command();
            DataTable tabela = new DataTable("Trabalhos");

            cmd.v_text = "select t.* from Trabalhos t";

            try
            {
                database = new Spartacus.Database.Sqlite(DB.GetStrConection());

                tabela = database.Query(cmd.GetUpdatedText(), "Trabalhos");
            }
            catch (Spartacus.Database.Exception ex)
            {
                ControllerArquivoLog.GeraraLog(ex);
            }

            return tabela;
        }

        /// <summary>
        /// Carregando lista de Ids Serviços executados.
        /// </summary>
        /// <returns>The lista.</returns>
        public static DataTable CarregarListaDeIds()
        {
            Spartacus.Database.Generic database;
            Spartacus.Database.Command cmd = new Spartacus.Database.Command();
            DataTable tabela = new DataTable("Trabalhos");

            cmd.v_text = "select ID from Trabalhos";

            try
            {
                database = new Spartacus.Database.Sqlite(DB.GetStrConection());

                tabela = database.Query(cmd.GetUpdatedText(), "Trabalhos");
            }
            catch (Spartacus.Database.Exception ex)
            {
                ControllerArquivoLog.GeraraLog(ex);
            }

            return tabela;
        }

        /// <summary>
        /// Preenchendo a classe Serviço com as informações de um DataTabel
        /// </summary>
        /// <returns>The trabalho.</returns>
        /// <param name="tabela">Tabela.</param>
        private static Servico PreencherTrabalho(DataTable tabela)
        {
            Servico ServicoBase = new Servico();

            List<string> Informacoes = new List<string>();

            foreach (DataRow r in tabela.Rows)
            {
                foreach (DataColumn c in tabela.Columns)
                {
                    Informacoes.Add(r[c].ToString());
                }
            }

            ServicoBase.ID = Convert.ToInt32(Informacoes[0]);
            ServicoBase.IdOrdemDeServico = Convert.ToInt32(Informacoes[1]);
            ServicoBase.Valor = Convert.ToDecimal(Informacoes[2]);

            return ServicoBase;
        }
    }
}

