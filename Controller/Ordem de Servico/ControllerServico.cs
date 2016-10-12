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
        public static string Criar(Servico ServicoBase)
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

            cmd.v_text = "delete from Trabalhos where OrdemDeServico = #idordemdeservico#";
            cmd.AddParameter("idordemdeservico", Spartacus.Database.Type.INTEGER);
            cmd.SetValue("idordemdeservico", NumeroOs.ToString());

            try
            {
                ReverterStatusDaOrdemDeServico(NumeroOs);

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
        /// Carrega uma lista de ids das Ordens de serviço que contém um serviço.
        /// </summary>
        /// <returns>Lista de Ids Das ordens de serviço.</returns>
        public static DataTable CarregarListaDeIdsDasOrdensDeServico()
        {
            Spartacus.Database.Generic database;
            Spartacus.Database.Command cmd = new Spartacus.Database.Command();
            DataTable tabela = new DataTable("Trabalhos");

            cmd.v_text = "select OrdemDeServico from Trabalhos";

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

        /// <summary>
        /// Reverte o status da Ordemd e serviço quando o serviço é excluido, o Status volta para Manutenção,
        /// pois não pdoe háver uma Ordem de serviço finalizada sem um serviço criado.
        /// </summary>
        /// <param name="IDOrdemDeServico">Identifier ordem de servico.</param>
        private static void ReverterStatusDaOrdemDeServico(int IDOrdemDeServico)
        {
            
            Spartacus.Database.Generic database;
            Spartacus.Database.Command cmd = new Spartacus.Database.Command();

            cmd.v_text = "update OrdemDeServico set Situacao = #situacao# where ID = #id#";

            cmd.AddParameter("situacao", Spartacus.Database.Type.STRING);
            cmd.AddParameter("id", Spartacus.Database.Type.INTEGER);

            cmd.SetValue("situacao", "Manutenção", false); // valor com acento será mantido por causa do false
            cmd.SetValue("id", IDOrdemDeServico.ToString());

            try
            {
                database = new Spartacus.Database.Sqlite(DB.GetStrConection());

                // desabilitando seguranca de execucao de comandos 
                database.SetExecuteSecurity(false);

                database.Execute(cmd.GetUpdatedText());
            }
            catch (Spartacus.Database.Exception ex)
            {
                ControllerArquivoLog.GeraraLog(ex);
            }
        }
    }

}