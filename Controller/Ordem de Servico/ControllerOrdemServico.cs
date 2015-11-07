using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Model;
using Model.Ordem_de_Servico;

namespace Controller
{
    public class ControllerOrdemServico
    {


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
        public void CreatPDF(string Identificador, string Referencia, string Situacao, string Defeito, string Descricao, string Observacao, string NumeroSerie, string Equipamento, string DataEntradaServico, string Cliente)
        {
            Document Documento = new Document();
            string local = String.Format("{0}/OS.pdf", Path.GetTempPath());
            PdfWriter.GetInstance(Documento, new FileStream(local, FileMode.Create));
            Empresa Empresa = new Empresa();
            ControllerEmpresa controllerEmpresa = new ControllerEmpresa();


            Paragraph _identificador = new Paragraph();
            Paragraph _cliente = new Paragraph();
            Paragraph _dataEntrada = new Paragraph();
            Paragraph _equipamento = new Paragraph();
            Paragraph _defeito = new Paragraph();
            Paragraph _situacao = new Paragraph();
            Paragraph _descricao = new Paragraph();
            Paragraph _numeroSerie = new Paragraph();
            Paragraph _referencia = new Paragraph();
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
            _identificador.Add(String.Format("Numero da ordem: {0}", Identificador));
            _cliente.Add(String.Format("Cliente: {0}", Cliente));
            _dataEntrada.Add(String.Format("Data de entrada: {0}", DataEntradaServico));
            _equipamento.Add(String.Format("Equipamento: {0}", Equipamento));
            _situacao.Add(String.Format("Situação: {0}", Situacao));
            _defeito.Add(String.Format("Defeito: {0}", Defeito));
            _descricao.Add(String.Format("Descrição: {0}", Descricao));
            _numeroSerie.Add(String.Format("Numero de serie: {0}", NumeroSerie));
            _referencia.Add(String.Format("Referência: {0}", Referencia));
            _observacoes.Add(String.Format("Observações: {0}", Observacao));

            //Carregando informações da empresa
            Empresa = controllerEmpresa.Load();
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
            Documento.Add(_referencia);
            Documento.Add(_linhaEmBranco);
            Documento.Add(_observacoes);

            Documento.Close();

            Process.Start(local);
        }

        /// <summary>
        /// Salvando a ordem de serviço em arquivo de Texto.
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
        /// <returns></returns>
        public string Save(string Identificador, string Referencia, string Situacao, string Defeito, string Descricao, string Observacao, string NumeroSerie, string Equipamento, string DataEntradaServico, string Cliente)
        {
            OrdemServico OSBase = new OrdemServico();

            string Saida = null;

            OSBase.Identificador = Identificador;
            OSBase.Equipamento = Equipamento;
            OSBase.Situacao = Situacao;
            OSBase.NumeroSerie = NumeroSerie;
            OSBase.Defeito = Defeito;
            OSBase.Referencia = Referencia;
            OSBase.DataEntradaServico = DataEntradaServico;
            OSBase.Observacao = Observacao;
            OSBase.Descricao = Descricao;
            OSBase.Cliente = Cliente;

            StreamWriter sw = null;


            if (Verificar(OSBase.Identificador) == false)
            {
                try
                {
                    sw = new StreamWriter(String.Format("OS/{0}.os", Identificador));

                    sw.WriteLine(OSBase.Identificador);
                    sw.WriteLine(OSBase.Cliente);
                    sw.WriteLine(OSBase.Equipamento);
                    sw.WriteLine(OSBase.Situacao);
                    sw.WriteLine(OSBase.NumeroSerie);
                    sw.WriteLine(OSBase.Defeito);
                    sw.WriteLine(OSBase.Referencia);
                    sw.WriteLine(OSBase.DataEntradaServico);
                    sw.WriteLine(OSBase.Observacao);
                    sw.WriteLine(OSBase.Descricao);

                }
                catch (System.Exception Exc)
                {
                    Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();

                    Log.ArquivoExceptionLog(Exc);

                    Saida = "Ocorreu um erro inesperado! Um arquivo com as informações desse erro foi criado no diretorio do seu software";
                }
                finally
                {
                    if (sw != null)
                    {
                        sw.Close();

                        Saida = "Ordem de Serviço registrada com sucesso!";
                    }

                }
            }
            else
            {
                //Chamara a função de salvar novamente se for verificado que o numero "sorteado já existe na base de dados."
                Save(OSBase.Identificador, OSBase.Referencia, OSBase.Situacao, OSBase.Defeito, OSBase.Descricao, OSBase.Observacao, OSBase.NumeroSerie, OSBase.Equipamento, OSBase.DataEntradaServico, OSBase.Cliente);
            }


            return Saida;

        }

        /// <summary>
        /// Editar a ordem de serviço, quase a mesam coisa que a Save(), ela só não verifica se o arquivo já existe, apenas salva.
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
        /// <returns></returns>
        public string Edit(string Identificador, string Referencia, string Situacao, string Defeito, string Descricao, string Observacao, string NumeroSerie, string Equipamento, string DataEntradaServico, string Cliente)
        {
            OrdemServico OSBase = new OrdemServico();
            string Saida = null;

            OSBase.Identificador = Identificador;
            OSBase.Equipamento = Equipamento;
            OSBase.Situacao = Situacao;
            OSBase.NumeroSerie = NumeroSerie;
            OSBase.Defeito = Defeito;
            OSBase.Referencia = Referencia;
            OSBase.DataEntradaServico = DataEntradaServico;
            OSBase.Observacao = Observacao;
            OSBase.Descricao = Descricao;
            OSBase.Cliente = Cliente;


            StreamWriter sw = null;


            if (Verificar(OSBase.Identificador) == true)
            {
                try
                {
                    sw = new StreamWriter(String.Format("OS/{0}.os", Identificador));

                    sw.WriteLine(OSBase.Identificador);
                    sw.WriteLine(OSBase.Cliente);
                    sw.WriteLine(OSBase.Equipamento);
                    sw.WriteLine(OSBase.Situacao);
                    sw.WriteLine(OSBase.NumeroSerie);
                    sw.WriteLine(OSBase.Defeito);
                    sw.WriteLine(OSBase.Referencia);
                    sw.WriteLine(OSBase.DataEntradaServico);
                    sw.WriteLine(OSBase.Observacao);
                    sw.WriteLine(OSBase.Descricao);
                }
                catch (System.Exception Exc)
                {
                    Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();

                    Log.ArquivoExceptionLog(Exc);

                    Saida = "Ocorreu um erro inesperado! Um arquivo com as informações desse erro foi criado no diretorio do seu software";
                }
                finally
                {
                    if (sw != null)
                    {
                        sw.Close();

                        Saida = "Ordem de Serviço editada com sucesso!";
                    }

                }
            }
            else
            {
                Saida = "Numero de ordem de sefviço inválido!";
            }


            return Saida;

        }

        /// <summary>
        /// Carregando a ordem de serviço atraves do arquivo de texto.
        /// </summary>
        /// <param name="_Identificador"></param>
        /// <returns>Ordem de serviço</returns>
        public OrdemServico Load(string _Identificador)
        {
            OrdemServico OSBase = new OrdemServico();
            StreamReader sr = null;

            try
            {
                sr = new StreamReader(String.Format("OS/{0}.os", _Identificador));

                OSBase.Identificador = sr.ReadLine();
                OSBase.Cliente = sr.ReadLine();
                OSBase.Equipamento = sr.ReadLine();
                OSBase.Situacao = sr.ReadLine();
                OSBase.NumeroSerie = sr.ReadLine();
                OSBase.Defeito = sr.ReadLine();
                OSBase.Referencia = sr.ReadLine();
                OSBase.DataEntradaServico = sr.ReadLine();
                OSBase.Observacao = sr.ReadLine();
                OSBase.Descricao = sr.ReadLine();
            }
            catch (Exception Exc)
            {
                Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();

                Log.ArquivoExceptionLog(Exc);
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }

            return OSBase;
        }

        /// <summary>
        /// Carrega uma lista de ordens de serviço.
        /// </summary>
        /// <returns>Lista com nome de todas Ordens de serviço registrada</returns>
        public List<string> LoadList()
        {
            List<string> ListaDeOS = new List<string>();
            DirectoryInfo NomesArquivos = new DirectoryInfo("OS/");
            string[] NovoItem = new string[2];


            //Ira pegar todas os nomes dos arquivos do diretorio ira separar um por um e um array separado por '.' e lgo apos salvar o nome do arquivo sem o seu formato.

            foreach (var item in NomesArquivos.GetFiles())
            {
                NovoItem = item.ToString().Split('.');

                ListaDeOS.Add(NovoItem[0]);
            }

            return ListaDeOS;
        }

        /// <summary>
        /// Verifica se a ordem de serviço existe ou não.
        /// </summary>
        /// <param name="_Identificador"></param>
        /// <returns>Retorna um valor (true/false)</returns>
        public bool Verificar(string _Identificador)
        {
            //Verifica de o já há uma "Ordem de Serviço"(arquivo com o nome), no diretorio das pessoas físicas e retorna um valor booleano .

            bool Encontrado = false;

            if (File.Exists((string.Format("OS/{0}.os", _Identificador))))
            {
                Encontrado = true;
            }
            else
            {
                Encontrado = false;
            }

            return Encontrado;
        }

        //Ordens finalizadas
        /// <summary>
        /// Finalizando Ordem de serviço.
        /// </summary>
        /// <param name="NumeroOS"></param>
        /// <returns>Menssagen informando se deu certo ou não</returns>
        public void FinalizarOS(string NumeroOS)
        {
            OrdemServico OSBase = new OrdemServico();

            //Modificando a situação da ordem de serviço
            OSBase = Load(NumeroOS);
            OSBase.Situacao = "Finalizado";
            Edit(OSBase.Identificador, OSBase.Referencia, OSBase.Situacao, OSBase.Defeito, OSBase.Descricao, OSBase.Observacao, OSBase.NumeroSerie, OSBase.Equipamento, OSBase.DataEntradaServico, OSBase.Cliente);

            //Movendo a ordem de serviço para a pasta das finalizadas.
            File.Move(String.Format("OS/{0}.os", NumeroOS), String.Format("OS/Finalizadas/{0}.os", NumeroOS));

        }

        /// <summary>
        /// Carregando a ordem de serviço(Finalizada) atraves do arquivo de texto.
        /// </summary>
        /// <param name="_Identificador"></param>
        /// <returns>Ordem de serviço</returns>
        public OrdemServico LoadOSFinalizada(string _Identificador)
        {
            OrdemServico OSBase = new OrdemServico();
            StreamReader sr = null;

            try
            {
                sr = new StreamReader(String.Format("OS/Finalizadas/{0}.os", _Identificador));

                OSBase.Identificador = sr.ReadLine();
                OSBase.Cliente = sr.ReadLine();
                OSBase.Equipamento = sr.ReadLine();
                OSBase.Situacao = sr.ReadLine();
                OSBase.NumeroSerie = sr.ReadLine();
                OSBase.Defeito = sr.ReadLine();
                OSBase.Referencia = sr.ReadLine();
                OSBase.DataEntradaServico = sr.ReadLine();
                OSBase.Observacao = sr.ReadLine();
                OSBase.Descricao = sr.ReadLine();
            }
            catch (Exception Exc)
            {
                Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();

                Log.ArquivoExceptionLog(Exc);
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }

            return OSBase;
        }

        /// <summary>
        /// Carrega uma lista de ordens de serviço(Finalizadas).
        /// </summary>
        /// <returns>Lista com nome de todas Ordens de serviço registrada</returns>
        public List<string> LoadListFinalizadas()
        {
            List<string> ListaDeOS = new List<string>();
            DirectoryInfo NomesArquivos = new DirectoryInfo("OS/Finalizadas");
            string[] NovoItem = new string[2];


            //Ira pegar todas os nomes dos arquivos do diretorio ira separar um por um e um array separado por '.' e lgo apos salvar o nome do arquivo sem o seu formato.

            foreach (var item in NomesArquivos.GetFiles())
            {
                NovoItem = item.ToString().Split('.');

                ListaDeOS.Add(NovoItem[0]);
            }

            return ListaDeOS;
        }

        /// <summary>
        /// Verifica se a ordem de serviço existe ou não.
        /// </summary>
        /// <param name="_Identificador"></param>
        /// <returns>Retorna um valor (true/false)</returns>
        public bool VerificarFinalizada(string _Identificador)
        {
            //Verifica de o já há uma "Ordem de Serviço"(arquivo com o nome), no diretorio das pessoas físicas e retorna um valor booleano .

            bool Encontrado = false;

            if (File.Exists((string.Format("OS/Finalizadas/{0}.os", _Identificador))))
            {
                Encontrado = true;
            }
            else
            {
                Encontrado = false;
            }

            return Encontrado;
        }

    }
}
