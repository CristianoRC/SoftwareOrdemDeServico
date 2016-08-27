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

            cmd.v_text = @"insert into ordemdeservico 
                        (Situacao,Defeito,Descricao,Observacao,NumeroDeSerie,Equipamento,DataEntradaServico,IdCliente,IdTecnico) 
                        values(#Situacao#,#Defeito#,#Descricao#,#Observacao#,#NumeroDeSerie#,
                               #Equipamento#,#DataEntradaServico#,#IdCliente#,#IdTecnico#);";


            cmd.AddParameter("Situacao", Spartacus.Database.Type.STRING);
            cmd.AddParameter("Defeito", Spartacus.Database.Type.STRING);
            cmd.AddParameter("Descricao", Spartacus.Database.Type.STRING);
            cmd.AddParameter("Observacao", Spartacus.Database.Type.STRING);
            cmd.AddParameter("NumeroDeSerie", Spartacus.Database.Type.STRING);
            cmd.AddParameter("Equipamento", Spartacus.Database.Type.STRING);
            cmd.AddParameter("DataEntradaServico", Spartacus.Database.Type.STRING);
            cmd.AddParameter("IdCliente", Spartacus.Database.Type.INTEGER);
            cmd.AddParameter("IdTecnico", Spartacus.Database.Type.INTEGER);

            cmd.SetValue("Situacao", Os.Situacao);
            cmd.SetValue("Defeito", Os.Defeito);
            cmd.SetValue("Descricao", Os.Descricao);
            cmd.SetValue("Observacao", Os.Observacao);
            cmd.SetValue("NumeroDeSerie", Os.NumeroSerie);
            cmd.SetValue("Equipamento", Os.Equipamento);
            cmd.SetValue("DataEntradaServico", Os.dataEntradaServico);
            cmd.SetValue("IdCliente", Os.IDCliente.ToString());
            cmd.SetValue("IdTecnico", Os.IDTecnico.ToString());


            try
            {
                database = new Spartacus.Database.Sqlite(DB.GetStrConection());

                database.Execute(cmd.GetUpdatedText());

                return "Ordem de serviço foi salva com sucesso!";
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

        public static string Editar(OrdemServico OS)
        {
            string Saida = "";

            Spartacus.Database.Generic database;
            Spartacus.Database.Command cmd = new Spartacus.Database.Command();

            cmd.v_text = @"update OrdemDeServico set 
                       Situacao = #Situacao#,
                       Defeito = #Defeito#,
                       Descricao = #Descricao#,
                       Observacao = #Observacao#,
                       NumeroDeSerie = #NumeroDeSerie#,
                       Equipamento = #Equipamento#,
                       Equipamentoo = #DataEntradaServico#,
                       IdCliente = #IdCliente#,
                       IdCliente = #IdTecnico#
                       Where ID = #ID#";


            cmd.AddParameter("ID", Spartacus.Database.Type.INTEGER);
            cmd.AddParameter("Situacao", Spartacus.Database.Type.STRING);
            cmd.AddParameter("Defeito", Spartacus.Database.Type.STRING);
            cmd.AddParameter("Descricao", Spartacus.Database.Type.STRING);
            cmd.AddParameter("Observacao", Spartacus.Database.Type.STRING);
            cmd.AddParameter("NumeroDeSerie", Spartacus.Database.Type.STRING);
            cmd.AddParameter("Equipamento", Spartacus.Database.Type.STRING);
            cmd.AddParameter("DataEntradaServico", Spartacus.Database.Type.STRING);
            cmd.AddParameter("IdCliente", Spartacus.Database.Type.STRING);
            cmd.AddParameter("IdTecnico", Spartacus.Database.Type.STRING);
            

            cmd.SetValue("ID", OS.ID.ToString());
            cmd.SetValue("Situacao", OS.Situacao);
            cmd.SetValue("Defeito", OS.Defeito);
            cmd.SetValue("Descricao", OS.Descricao);
            cmd.SetValue("Observacao", OS.Observacao);
            cmd.SetValue("NumeroDeSerie", OS.NumeroSerie);
            cmd.SetValue("Equipamento", OS.Equipamento);
            cmd.SetValue("DataEntradaServico", OS.dataEntradaServico);
            cmd.SetValue("IdCliente", OS.IDCliente.ToString());
            cmd.SetValue("IdTecnico", OS.IDTecnico.ToString());
            
            try
            {
                database = new Spartacus.Database.Sqlite(DB.GetStrConection());

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

        //TODO:Fazer testes com a controller pessoa para ver se o código desenvolvido funciona normalmente.
        public static OrdemServico Carregar(int ID)
        {
            OrdemServico OSBase = new OrdemServico();

            return OSBase;
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

                tabela = database.Query("select ID from ordemdeservico", "Ordemdeservico");
            }
            catch (Exception ex)
            {
                ControllerArquivoLog.GeraraLog(ex);
            }
            return tabela;
        }

        /// <summary>
        /// Gerando PDF da ordem de serviço. (A ordem de serviço em PDF não fica salvar ela é gerada cada vez que a função é chamada)
        /// </summary>
        /// <param name="Identificador"></param>
        /// <param name="Referencia"></param>
        /// <param name="Situacao"></param>
        /// <param name="Defeito"></param>
        /// <param name="Descricao"></param>
        /// <param name="Observacao"></param>
        /// <param name="NumeroSerie"></param>
        /// <param name="Equipamento"></param>
        /// <param name="DataEntradaServico"></param>
        /// <param name="Cliente"></param>
        public static void CreatPDF(OrdemServico OSBase)
        {

            Document Documento = new Document();
            string local = String.Format("{0}/OS.pdf", Path.GetTempPath());
            PdfWriter.GetInstance(Documento, new FileStream(local, FileMode.Create));
            Empresa Empresa = new Empresa();


            Paragraph _identificador = new Paragraph();
            Paragraph _cliente = new Paragraph();
            Paragraph _dataEntrada = new Paragraph();
            Paragraph _equipamento = new Paragraph();
            Paragraph _defeito = new Paragraph();
            Paragraph _situacao = new Paragraph();
            Paragraph _descricao = new Paragraph();
            Paragraph _numeroSerie = new Paragraph();
            Paragraph _observacoes = new Paragraph();
            Paragraph _linha = new Paragraph();
            Paragraph _linhaEmBranco = new Paragraph();
            Paragraph _cabecalho = new Paragraph();
            Paragraph _nomeEmpresa = new Paragraph();
            Paragraph _contatoEmpresa = new Paragraph();
            Paragraph _enderecoEmpresa = new Paragraph();



            //Alinhado o Cabeçalho no meio da pagina;
            _cabecalho.Alignment = Element.ALIGN_CENTER;
            _cabecalho.Add("Ordem de serviço");
            _linha.Add("______________________________________________________________________________");
            _linhaEmBranco.Add(" ");
            _identificador.Add(String.Format("Numero da ordem: {0}", OSBase.ID));
            _cliente.Add(String.Format("Cliente: {0}", OSBase.IDCliente));
            _dataEntrada.Add(String.Format("Data de entrada: {0}", OSBase.dataEntradaServico));
            _equipamento.Add(String.Format("Equipamento: {0}", OSBase.Equipamento));
            //_situacao.Add(String.Format("Tipo: {0}", )); Excluir após a criação do Orçamento
            _defeito.Add(String.Format("Defeito: {0}", OSBase.Defeito));
            _descricao.Add(String.Format("Descrição: {0}", OSBase.Descricao));
            _numeroSerie.Add(String.Format("Numero de serie: {0}", OSBase.NumeroSerie));
            _observacoes.Add(String.Format("Observações: {0}", OSBase.Observacao));

            //Carregando informações da empresa
            Empresa = ControllerEmpresa.Load();
            _nomeEmpresa.Add(Empresa.Nome);
            _contatoEmpresa.Add(Empresa.Contato);
            _enderecoEmpresa.Add(Empresa.Endereco);


            Documento.Open();

            Documento.Add(_cabecalho);
            Documento.Add(_linhaEmBranco);
            Documento.Add(_linhaEmBranco);

            Documento.Add(_nomeEmpresa);
            Documento.Add(_contatoEmpresa);
            Documento.Add(_enderecoEmpresa);


            Documento.Add(_linha);
            Documento.Add(_linhaEmBranco);
            Documento.Add(_identificador);
            Documento.Add(_linhaEmBranco);
            Documento.Add(_cliente);
            Documento.Add(_linhaEmBranco);
            Documento.Add(_dataEntrada);
            Documento.Add(_linhaEmBranco);
            Documento.Add(_linha);

            Documento.Add(_linhaEmBranco);
            Documento.Add(_equipamento);
            Documento.Add(_linhaEmBranco);
            Documento.Add(_situacao);
            Documento.Add(_linhaEmBranco);
            Documento.Add(_defeito);
            Documento.Add(_linhaEmBranco);
            Documento.Add(_descricao);
            Documento.Add(_linhaEmBranco);
            Documento.Add(_numeroSerie);
            Documento.Add(_linhaEmBranco);
            Documento.Add(_linhaEmBranco);
            Documento.Add(_observacoes);

            Documento.Close();

            Process.Start(local);
        }
    }
}
//TODO:Orcamento vai estar apenas na opção de Situação, e quando acabar o orcamento gerra um trabalho