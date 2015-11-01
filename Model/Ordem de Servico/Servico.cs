using System;
using System.IO;
using System.Collections.Generic;

namespace Model.Ordem_de_Servico
{
    public class Servico
    {
        private string descricao;
        private double valor;

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
        public double Valor
        {
            get
            {
                return valor;
            }

            set
            {
                valor = value;
            }
        }

        /// <summary>
        /// Criandoo arqui de "Serviço finalizado".
        /// </summary>
        /// <param name="Descricao"></param>
        /// <param name="Valor"></param>
        /// <param name="NumeroOS"></param>
        /// <returns></returns>
        private bool Save(string Descricao, double Valor, string NumeroOS)
        {
            Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();
            bool saida;
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(String.Format("Servicos/{0}.txt", NumeroOS));

                sw.WriteLine(Descricao);
                sw.WriteLine(Valor);

                saida = true;
            }
            catch (Exception exc)
            {
                Log.ArquivoExceptionLog(exc);

                saida = false;
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }

            return saida;
        }

        /// <summary>
        /// Gerando um novo serviço.
        /// </summary>
        public string GerarServico(string Descricao, double Valor, string NumeroOS)
        {
            string Saida = "";
            OrdemServico OSBase = new OrdemServico();
            Servico ServicoBase = new Servico();

            //Tentando finalizar a OS, se ela não for encontrada ira retornar a mensagem doretamente da Função (FinalizarOS()).
            if (OSBase.FinalizarOS(NumeroOS))
            {
                //Criando o arquivo e verificando se ele foi criado corretamente ou ou não (com o valor de retorno da fução Save);
                if (ServicoBase.Save(Descricao, Valor, NumeroOS))
                {
                    Saida = "Serviço gerado com sucesso!";
                }
                else
                {
                    //Se tiver algum problema na hora de gerar o serviço sera apresentada essa mensagem ao usario.

                    Saida = "Erro ao finalizar o serviço! um arquivo com informações foi criado no diretorio do seu Software (Log.Txt).";
                }
            }
            else
            {
                //Se não conseguir finalziar a OS ira aparecer essa mensagem.
                Saida = "Ordem de serviço não encontrada em nossa base de dados!";
            }
            return Saida;
        }

        /// <summary>
        /// Carregando informações do serviço finalizado.
        /// </summary>
        /// <param name="NumeroServico"></param>
        /// <returns>Informações do serviço carregado.</returns>
        public Servico Load(string NumeroServico)
        {
            Servico ServicoBase = new Servico();
            Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();
            StreamReader sr = null;

            try
            {
                sr = new StreamReader(string.Format("Servicos/{0}.txt", NumeroServico));

                ServicoBase.Descricao = sr.ReadLine();
                ServicoBase.Valor = Double.Parse(sr.ReadLine());
            }
            catch (Exception exc)
            {
                Log.ArquivoExceptionLog(exc);
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }

            return ServicoBase;
        }

        /// <summary>
        /// Carregando Lista de Serviços finalizados.
        /// </summary>
        /// <returns>Lista de nomes de todos os serviços finalizados.</returns>
        public List<String> LoadList()
        {
            List<string> listaBase = new List<string>();
            DirectoryInfo NomesArquivos = new DirectoryInfo("OS/Servicos/");
            string[] NovoItem = new string[2];

            //Ira pegar todas os nomes dos arquivos do diretorio ira separar um por um e um array separado por '.' e lgo apos salvar o nome do arquivo sem o seu formato.

            foreach (var item in NomesArquivos.GetFiles())
            {
                NovoItem = item.ToString().Split('.');
                listaBase.Add(NovoItem[0]);
            }

            return listaBase;
        }
    }
}
