using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace Model.Ordem_de_Servico
{
    public class OrdemServico
    {
        private string identificador;
        private string referencia;
        private string situacao;
        private string defeito;
        private string descricao;
        private string observacao;
        private string numeroSerie;
        private string equipamento;
        private string dataEntradaServico;
        private string cliente;

        public string Identificador
        {
            get
            {
                return identificador;
            }

            set
            {
                identificador = value;
            }
        }

        public string Referencia
        {
            get
            {
                return referencia;
            }

            set
            {
                referencia = value;
            }
        }

        public string Situacao
        {
            get
            {
                return situacao;
            }

            set
            {
                situacao = value;
            }
        }

        public string Defeito
        {
            get
            {
                return defeito;
            }

            set
            {
                defeito = value;
            }
        }

        public string Descricao
        {
            get
            {
                return descricao;
            }

            set
            {
                descricao = value;
            }
        }

        public string Observacao
        {
            get
            {
                return observacao;
            }

            set
            {
                observacao = value;
            }
        }

        public string NumeroSerie
        {
            get
            {
                return numeroSerie;
            }

            set
            {
                numeroSerie = value;
            }
        }

        public string Equipamento
        {
            get
            {
                return equipamento;
            }

            set
            {
                equipamento = value;
            }
        }

        public string DataEntradaServico
        {
            get
            {
                return dataEntradaServico;
            }

            set
            {
                dataEntradaServico = value;
            }
        }

        public string Cliente
        {
            get
            {
                return cliente;
            }

            set
            {
                cliente = value;
            }
        }

        //Problemas em gerara o PDF
        /*private void GerarPDF(string Identificador, string Referencia, string Situacao, string Defeito, string Descricao, string Observacao, string NumeroSerie, string Equipamento, string DataEntradaServico, string Cliente)
        {
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;

            //Caminho para encontrar o relatorio Base.
            reportViewer.LocalReport.ReportEmbeddedResource = "Model.Ordem_de_Servico.ReportBase.rdlc";

            //Parametros do relatorio
            List<ReportParameter> ListaDeParametros = new List<ReportParameter>();

            ListaDeParametros.Add(new ReportParameter("Nome", Cliente));
            ListaDeParametros.Add(new ReportParameter("Equipamento", Equipamento));
            ListaDeParametros.Add(new ReportParameter("NumeroDeSerie", NumeroSerie));
            ListaDeParametros.Add(new ReportParameter("Situacao", Situacao));
            ListaDeParametros.Add(new ReportParameter("Defeito", Defeito));
            ListaDeParametros.Add(new ReportParameter("Observacoes", Observacao));
            ListaDeParametros.Add(new ReportParameter("Descricao", Descricao));
            ListaDeParametros.Add(new ReportParameter("Referencia", Referencia));
            ListaDeParametros.Add(new ReportParameter("NumeroOrdem", Identificador));
            ListaDeParametros.Add(new ReportParameter("DataEntrada", DataEntradaServico));

            //TODO:Arrumar sistema de nome e endereço de empresa quando estiver pronto
            ListaDeParametros.Add(new ReportParameter("EnderecoEmpresa", "Av. Ferreira Viana 2886"));
            ListaDeParametros.Add(new ReportParameter("ContatoEmpresa", "CristianoCunha@ti1.info"));
            ListaDeParametros.Add(new ReportParameter("NomeEmpresa", "Cunha Soluções em TI"));

            //Passando os parametros para o relatorio
            reportViewer.LocalReport.SetParameters(ListaDeParametros);
            
            Warning[] Warnings;
            string[] Streamids;
            string Mimetype;
            string encoding;
            string extension;

            byte[] bytePDF = reportViewer.LocalReport.Render("pdf", null, out Mimetype, out encoding, out extension, out Streamids, out Warnings);

            FileStream fsPDF = null;
            string NomeArquivoPDF = String.Format("OS/Teste.pdf");

            fsPDF = new FileStream(NomeArquivoPDF,FileMode.Create);

            fsPDF.Write(bytePDF,0,bytePDF.Length);

            //Abrindo o PDF
            Process.Start(NomeArquivoPDF);

        }

    */

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


            if (Verificar(OSBase.identificador) == false)
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

                    
                    //GerarPDF(OSBase.Identificador, OSBase.Referencia, OSBase.Situacao, OSBase.Defeito, OSBase.Descricao, OSBase.Observacao, OSBase.NumeroSerie, OSBase.Equipamento, OSBase.DataEntradaServico, OSBase.Cliente);
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


            if (Verificar(OSBase.identificador) == true)
            {
                try
                {
                    sw = new StreamWriter(String.Format("OS/{0}.os", Identificador));

                    sw.WriteLine(OSBase.Identificador);
                    sw.WriteLine(OSBase.cliente);
                    sw.WriteLine(OSBase.Equipamento);
                    sw.WriteLine(OSBase.Situacao);
                    sw.WriteLine(OSBase.NumeroSerie);
                    sw.WriteLine(OSBase.Defeito);
                    sw.WriteLine(OSBase.Referencia);
                    sw.WriteLine(OSBase.DataEntradaServico);
                    sw.WriteLine(OSBase.Observacao);
                    sw.WriteLine(OSBase.Descricao);


                    //GerarPDF(OSBase.Identificador, OSBase.Referencia, OSBase.Situacao, OSBase.Defeito, OSBase.Descricao, OSBase.Observacao, OSBase.NumeroSerie, OSBase.Equipamento, OSBase.DataEntradaServico, OSBase.Cliente);

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

        public OrdemServico Load(string _Identificador)
        {
            OrdemServico OSBase = new OrdemServico();
            StreamReader sr = null;

            try
            {
                sr = new StreamReader(String.Format("OS/{0}.os", _Identificador));

                OSBase.Identificador = sr.ReadLine();
                OSBase.cliente = sr.ReadLine();
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

    }
}
