using System;
using System.Data;
using System.Collections.Generic;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Model;
using Model.Ordem_de_Servico;
using Ionic.Zip;
using System.IO;


namespace Controller
{
    public static class ControllerOrdemServico
    {
        /// <summary>
        /// Salcando Ordem De Serviço
        /// </summary>
        /// <param name="Os">Os.</param>
        public static string Salvar(OrdemServico Os)
        {
            Spartacus.Database.Generic database;
            Spartacus.Database.Command cmd = new Spartacus.Database.Command();
            
            cmd.v_text = @"insert into OrdemDeServico 
                           (Situacao,Defeito,Descricao,Observacao,NumeroDeSerie,Equipamento,DataEntradaServico,IdCliente,IdTecnico)
                           values(#situacao#,#defeito#,#descricao#,#observacao#,#numerodeserie#,#equipamento#,#dataentradaservico#,#idcliente#,#idtecnico#)";


            cmd.AddParameter("situacao", Spartacus.Database.Type.STRING);
            cmd.AddParameter("defeito", Spartacus.Database.Type.STRING);
            cmd.AddParameter("descricao", Spartacus.Database.Type.STRING);
            cmd.AddParameter("observacao", Spartacus.Database.Type.STRING);
            cmd.AddParameter("numeroDeSerie", Spartacus.Database.Type.STRING);
            cmd.AddParameter("equipamento", Spartacus.Database.Type.STRING);
            cmd.AddParameter("dataEntradaServico", Spartacus.Database.Type.STRING);
            cmd.AddParameter("idCliente",Spartacus.Database.Type.INTEGER);
            cmd.AddParameter("idTecnico",Spartacus.Database.Type.INTEGER);

            // valor com acento será mantido por causa do false
            cmd.SetValue("situacao", Os.Situacao,false);
            cmd.SetValue("defeito", Os.Defeito,false);
            cmd.SetValue("descricao", Os.Descricao,false);
            cmd.SetValue("observacao", Os.Observacao,false);
            cmd.SetValue("numeroDeSerie", Os.NumeroSerie);
            cmd.SetValue("equipamento", Os.Equipamento,false);
            cmd.SetValue("dataEntradaServico", Os.dataEntradaServico);
            cmd.SetValue("idCliente",Os.IDCliente.ToString());
            cmd.SetValue("idTecnico",Os.IDTecnico.ToString());

            try
            {
                database = new Spartacus.Database.Sqlite(DB.GetStrConection());

                // desabilitando seguranca de execucao de comandos 
                database.SetExecuteSecurity(false);

                database.Execute(cmd.GetUpdatedText());

                return "Ordem de serviço numero foi salva com sucesso!";
            }
            catch (Exception ex)
            {
                ControllerArquivoLog.GeraraLog(ex);
                return String.Format("Ocorreu um erro ao tental salvar a Ordem de serviço:{0}", ex.Message);
            }
        }

        /// <summary>
        /// Deletando ordem de serviço.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public static string Deletar(int id)
        {
            Spartacus.Database.Generic database;
            Spartacus.Database.Command cmd = new Spartacus.Database.Command();

            cmd.v_text = "delete from ordemdeservico where id = #ID#";

            cmd.AddParameter("ID", Spartacus.Database.Type.INTEGER);
            cmd.SetValue("ID", id.ToString());

            try
            {
                database = new Spartacus.Database.Sqlite(DB.GetStrConection());

                database.Execute(cmd.GetUpdatedText());

                return "Ordem de serviço deletada com sucesso!";
            }
            catch (Exception ex)
            {
                ControllerArquivoLog.GeraraLog(ex);
                return "Erro ou excluir a ordem de serviço";
            }
        }

        /// <summary>
        /// Editando Ordem de serviço
        /// </summary>
        /// <param name="OS">O.</param>
        public static string Editar(OrdemServico Os)
        {
            string Saida = "";

            Spartacus.Database.Generic database;
            Spartacus.Database.Command cmd = new Spartacus.Database.Command();

            cmd.v_text = @"update OrdemDeServico set 
                       Situacao = #situacao#,
                       Defeito = #defeito#,
                       Descricao = #descricao#,
                       Observacao = #observacao#,
                       NumeroDeSerie = #numerodeserie#,
                       Equipamento = #equipamento#,
                       DataEntradaServico = #dataentradaservico#,
                       IdCliente = #idcliente#,
                       IdTecnico = #idtecnico#
                       Where ID = #id#";


            cmd.AddParameter("ID", Spartacus.Database.Type.INTEGER);
            cmd.AddParameter("Situacao", Spartacus.Database.Type.STRING);
            cmd.AddParameter("Defeito", Spartacus.Database.Type.STRING);
            cmd.AddParameter("Descricao", Spartacus.Database.Type.STRING);
            cmd.AddParameter("Observacao", Spartacus.Database.Type.STRING);
            cmd.AddParameter("NumeroDeSerie", Spartacus.Database.Type.STRING);
            cmd.AddParameter("Equipamento", Spartacus.Database.Type.STRING);
            cmd.AddParameter("DataEntradaServico", Spartacus.Database.Type.STRING);
            cmd.AddParameter("IdCliente", Spartacus.Database.Type.INTEGER);
            cmd.AddParameter("IdTecnico", Spartacus.Database.Type.INTEGER);


            // valor com acento será mantido por causa do false
            cmd.SetValue("id",Os.ID.ToString());
            cmd.SetValue("situacao", Os.Situacao, false);
            cmd.SetValue("defeito", Os.Defeito, false);
            cmd.SetValue("descricao", Os.Descricao, false);
            cmd.SetValue("observacao", Os.Observacao, false);
            cmd.SetValue("numeroDeSerie", Os.NumeroSerie);
            cmd.SetValue("equipamento", Os.Equipamento, false);
            cmd.SetValue("dataEntradaServico", Os.dataEntradaServico);
            cmd.SetValue("idCliente", Os.IDCliente.ToString());
            cmd.SetValue("idTecnico", Os.IDTecnico.ToString());

            try
            {
                database = new Spartacus.Database.Sqlite(DB.GetStrConection());

                // desabilitando seguranca de execucao de comandos 
                database.SetExecuteSecurity(false);

                database.Execute(cmd.GetUpdatedText());

                Saida = "Ordem de serviço editada com sucesso!";
            }
            catch (Exception exc)
            {
                ControllerArquivoLog.GeraraLog(exc);

                Saida = "Ocorreu um erro inesperado: " + exc.Message;
            }

            return Saida;
        }

        /// <summary>
        /// Finalizando ordem de serviço(Mudando o Status da OS).
        /// </summary>
        /// <returns>The O.</returns>
        public static string FinalizarOS(Trabalho InfoTrabalho)
        {
            Spartacus.Database.Generic database;
            Spartacus.Database.Command cmd = new Spartacus.Database.Command();

            cmd.v_text = "update OrdemDeServico set Situacao = #situacao# where ID = #id#";

            cmd.AddParameter("situacao",Spartacus.Database.Type.STRING);
            cmd.AddParameter("id",Spartacus.Database.Type.INTEGER);

            cmd.SetValue("situacao","Finalizado");
            cmd.SetValue("id",InfoTrabalho.IdOrdemDeServico.ToString());

            try
            {
                database = new Spartacus.Database.Sqlite(DB.GetStrConection());

                database.Execute(cmd.GetUpdatedText());

                ControllerServico.Salvar(InfoTrabalho);//Gerar um trabalho, após ter alterado as informações da OS.

                return "Ordem de serviço finalizda com sucesso.";
            }
            catch (Spartacus.Database.Exception ex)
            {
                ControllerArquivoLog.GeraraLog(ex);

                return String.Format("Ocorreu um erro ao tentar finalizar a OS: {0}",ex.Message);
            }

        }

       /// <summary>
       /// Carregando as informações da tabela para a classe de OS.
       /// </summary>
       /// <param name="ID">I.</param>
        public static OrdemServico Carregar(int ID)
        {
            System.Data.DataTable tabela = new DataTable("OrdemDeServico");
            OrdemServico OSBase = new OrdemServico();
            Spartacus.Database.Generic database;
            Spartacus.Database.Command cmd = new Spartacus.Database.Command();

            cmd.v_text = "Select * from OrdemDeServico Where ID = #id#";

            cmd.AddParameter("id",Spartacus.Database.Type.INTEGER);
            cmd.SetValue("id",ID.ToString());

            try
            {
                database = new Spartacus.Database.Sqlite(DB.GetStrConection());

                tabela = database.Query(cmd.GetUpdatedText(),"OrdemDeServico");

                OSBase = PreencherOS(tabela);
            }
            catch (Spartacus.Database.Exception ex)
            {
                ControllerArquivoLog.GeraraLog(ex);
            }


            return OSBase;
        }

        /// <summary>
        /// Retorna um DataTable com todas as Ordens de serviço, utilizando um filtro de pesquisa~.
        /// </summary>
        /// <returns>The lista.</returns>
        public static DataTable CarregarListaComFiltroDePesquisa(string filtroSQL, int IDCliente)
        {
            DataTable tabela = new DataTable("ordemdeservico");
            Spartacus.Database.Generic database;
            Spartacus.Database.Command cmd = new Spartacus.Database.Command();

            cmd.v_text = String.Format("select * from ordemdeservico where idcliente {0} #idcliente#",filtroSQL);
            cmd.AddParameter("idcliente", Spartacus.Database.Type.STRING);
            cmd.SetValue("idcliente", IDCliente.ToString());

            try
            {
                database = new Spartacus.Database.Sqlite(DB.GetStrConection());

                tabela = database.Query(cmd.GetUpdatedText(), "Ordemdeservico");
            }
            catch (Exception ex)
            {
                ControllerArquivoLog.GeraraLog(ex);
            }
            return tabela;
        }

        /// <summary>
        /// Retorna um DataTable com todas as Ordens de serviço.
        /// </summary>
        /// <returns>The lista.</returns>
        public static DataTable CarregarLista()
        {
            DataTable tabela = new DataTable("ordemdeservico");
            Spartacus.Database.Generic database;

            try
            {
                database = new Spartacus.Database.Sqlite(DB.GetStrConection());

                tabela = database.Query("select * from ordemdeservico", "Ordemdeservico");
            }
            catch (Exception ex)
            {
                ControllerArquivoLog.GeraraLog(ex);
            }
            return tabela;
        }

        /// <summary>
        /// Retorna um DataTable com todas as Ordens de serviço NÃO FINALIZADAS.
        /// </summary>
        /// <returns>The lista.</returns>
        public static DataTable CarregarListaDeIdsNaoFinalizados()
        {
            DataTable tabela = new DataTable("ordemdeservico");
            Spartacus.Database.Generic database;

            try
            {
                database = new Spartacus.Database.Sqlite(DB.GetStrConection());

                tabela = database.Query("select ID from ordemdeservico where Situacao <> 'Finalizado'", "Ordemdeservico");
            }
            catch (Exception ex)
            {
                ControllerArquivoLog.GeraraLog(ex);
            }
            return tabela;
        }

        /// <summary>
        /// Retorna um DataTable com todas as Ordens de serviço.
        /// </summary>
        /// <returns>The lista.</returns>
        public static DataTable CarregarListaDeIds()
        {
            DataTable tabela = new DataTable("ordemdeservico");
            Spartacus.Database.Generic database;

            try
            {
                database = new Spartacus.Database.Sqlite(DB.GetStrConection());

                tabela = database.Query("select ID from ordemdeservico where Situacao <> 'Finalizado'", "Ordemdeservico");
            }
            catch (Exception ex)
            {
                ControllerArquivoLog.GeraraLog(ex);
            }
            return tabela;
        }

        /// <summary>
        /// Retorna um DataTable com todas os orçamentos.(Ordemd e serviço com Situação = Orçamento)
        /// </summary>
        /// <returns>The lista.</returns>
        public static DataTable CarregarListaOrcamentos()
        {
            DataTable tabela = new DataTable("ordemdeservico");
            Spartacus.Database.Generic database;

            try
            {
                database = new Spartacus.Database.Sqlite(DB.GetStrConection());

                tabela = database.Query("select * from ordemdeservico where Situacao = 'Orçamento'", "Ordemdeservico");
            }
            catch (Exception ex)
            {
                ControllerArquivoLog.GeraraLog(ex);
            }
            return tabela;
        }

        /// <summary>
        /// Preenchendo a classe OS com as informações do DataTable
        /// </summary>
        /// <returns>The cliente.</returns>
        /// <param name="informacoes">Informacoes.</param>
        private static OrdemServico PreencherOS(DataTable tabela)
        {
            List<string> OSBaseLista = new List<string>();
            OrdemServico OSBase = new OrdemServico();


            try
            {
                foreach (DataRow r in tabela.Rows)
                {
                    foreach (DataColumn c in tabela.Columns)
                    {
                        OSBaseLista.Add(r[c].ToString());
                    }
                }

                OSBase.ID = Convert.ToInt32(OSBaseLista[0]);
                OSBase.Situacao = OSBaseLista[1];
                OSBase.Defeito = OSBaseLista[2];
                OSBase.Descricao = OSBaseLista[3];
                OSBase.Observacao = OSBaseLista[4];
                OSBase.NumeroSerie = OSBaseLista[5];
                OSBase.Equipamento = OSBaseLista[6];
                OSBase.dataEntradaServico = OSBaseLista[7];
                OSBase.IDCliente = Convert.ToInt32(OSBaseLista[8]);
                OSBase.IDTecnico = Convert.ToInt32(OSBaseLista[9]);
               
            }
            catch (Exception ex)
            {
                ControllerArquivoLog.GeraraLog(ex);
            }
            return OSBase;
        }
    }
}