using System;
using System.IO;
using System.Collections.Generic;
using Model.Ordem_de_Servico;

namespace Controller
{
    public class ControllerServico
    {

        /// <summary>
        /// Criandoo arqui de "Serviço finalizado".
        /// </summary>
        /// <param name="Descricao"></param>
        /// <param name="Valor"></param>
        /// <param name="NumeroOS"></param>
        /// <returns></returns>
        public string Save(string Descricao, double Valor, string NumeroOS,string ServicoBase,string NomeDoTecnico)
        {
            Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();
            string Saida;
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(String.Format("OS/Servicos/{0}.txt", NumeroOS));

                sw.WriteLine(ServicoBase);
                sw.WriteLine(Valor);
                sw.WriteLine(Descricao);
                sw.WriteLine(NomeDoTecnico);

                Saida = "Serviço gerado com sucesso!";
            }
            catch (Exception exc)
            {
                Log.ArquivoExceptionLog(exc);

                Saida = "Erro ao finalizar o serviço!um arquivo com informações foi criado no diretorio doseu Software (Log.Txt).";
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }

            return Saida;
        }

        /// <summary>
        /// Carregando informações do serviço finalizado.
        /// </summary>
        /// <param name="NumeroServico"></param>
        /// <returns>Informações do serviço carregado.</returns>
        public Servico Load(string NomeServico)
        {
            Servico servicoSave = new Servico();
            Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();
            StreamReader sr = null;

            try
            {
                sr = new StreamReader(string.Format("OS/Servicos/{0}.txt", NomeServico));

                servicoSave.ServicoBase = sr.ReadLine();
                servicoSave.Valor = Double.Parse(sr.ReadLine());
                servicoSave.Descricao = sr.ReadLine();
                servicoSave.Tecnico = sr.ReadLine();
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

            return servicoSave;
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

        /// <summary>
        /// Verificando se o arquivo do serviço existe ou não.
        /// </summary>
        /// <param name="identificador"></param>
        /// <returns></returns>
        public bool Verificar(string identificador)
        {
            bool saida = false;

            if (File.Exists(string.Format("Os/Servicos/{0}.txt",identificador)))
            {
                saida = true;
            }
            return saida;
        }

        /// <summary>
        /// Excluindo servico
        /// </summary>
        /// <param name="Identificador"></param>
        /// <returns>Resultado da operação</returns>
        public string Excluir(string Identificador)
        {
            string saida = String.Format("O serviço numero {0} foi excluido com sucesso!", Identificador);

            try
            {
                File.Delete(string.Format("OS/Servicos/{0}.txt", Identificador));
            }
            catch (Exception exc)
            {
                saida = string.Format("Ocorreu um erro ao excluir o serviço: {0}", exc.Message);
            }

            return saida;
        }
    }
}
