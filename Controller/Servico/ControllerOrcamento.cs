using Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace Controller
{
    public class ControllerOrcamento
    {

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
        public string Save(String Identificador, String Equipamento, String Cliente, String Valor, String Observações)
        {
            string Saida = null;

            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(String.Format("Orcamentos/{0}.txt", Identificador));

                sw.WriteLine(Equipamento);
                sw.WriteLine(Cliente);
                sw.WriteLine(Valor);
                sw.WriteLine(Observações);

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

                    Saida = "Orçamento finalziado com sucesso!";
                }

            }

            return Saida;

        }

        /// <summary>
        /// Carregando o orçamento atraves do arquivo de texto.
        /// </summary>
        /// <param name="_Identificador"></param>
        /// <returns>Ordem de serviço</returns>
        public Orcamento Load(string Identificador)
        {
            Orcamento OrcamentoBase = new Orcamento();
            StreamReader sr = null;

            try
            {
                sr = new StreamReader(String.Format("Orcamentos/{0}.txt", Identificador));

                OrcamentoBase.Equipamento = sr.ReadLine();
                OrcamentoBase.Cliente = sr.ReadLine();
                OrcamentoBase.Observacoes = sr.ReadLine();
                OrcamentoBase.Valor = sr.ReadLine();
                OrcamentoBase.Identificador = Identificador; //TODO:Verificar novamente essa linha de código.

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

            return OrcamentoBase;
        }

        /// <summary>
        /// Carrega uma lista de ordens de serviço.
        /// </summary>
        /// <returns>Lista com nome de todas Ordens de serviço registrada</returns>
        public List<string> LoadList()
        {
            List<string> ListaDeOrcamentos = new List<string>();
            DirectoryInfo NomesArquivos = new DirectoryInfo("Orcamentos/");
            string[] NovoItem = new string[2];


            //Ira pegar todas os nomes dos arquivos do diretorio ira separar um por um e um array separado por '.' e lgo apos salvar o nome do arquivo sem o seu formato.

            foreach (var item in NomesArquivos.GetFiles())
            {
                NovoItem = item.ToString().Split('.');

                ListaDeOrcamentos.Add(NovoItem[0]);
            }

            return ListaDeOrcamentos;
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

            if (File.Exists((string.Format("Orcamentos/{0}.txt", _Identificador))))
            {
                Encontrado = true;
            }
            else
            {
                Encontrado = false;
            }

            return Encontrado;
        }

        public string Excluir(string Identificador)
        {
            string saida = " ";

            if (Verificar(Identificador))
            {
                try
                {
                    File.Delete(string.Format("Orcamentos/{0}.txt", Identificador));

                    saida = "Orçamento foi deletado com sucesso!";
                }
                catch
                {
                    saida = "Erro ao excluir o orçamento";
                }

            }
            else
            {
                saida = "Orçamento não encontrado na base de dados!";
            }

            return saida;
        }

    }
}
