using System;
using System.IO;
using System.Collections.Generic;
using Model;

namespace Controller
{
    public static class ControllerServicoBase
    {
        /// <summary>
        /// Salvando/ Gerando arquivo de serviço base -> Exemplo:Manutenção preventiva.
        /// </summary>
        /// <param name="nomeBase"></param>
        /// <param name="observacoes"></param>
        /// <param name="Valor"></param>
        public static string Save(string nome, string observacoes, string Valor)
        {
            string Saida = "";
            StreamWriter sw = null;
            try
            {
                ServicoBase servicoBase = new ServicoBase();
                sw = new StreamWriter(string.Format("ServicosBase/{0}.txt", nome));

                servicoBase.Nome = nome;
                servicoBase.Observacoes = observacoes;
                servicoBase.Valor = Valor;


                sw.WriteLine(servicoBase.Nome);
                sw.WriteLine(servicoBase.Observacoes);
                sw.WriteLine(servicoBase.Valor);

                Saida = "Serviço base salvo com sucesso!";
            }
            catch (Exception exc)
            {
                ControllerArquivoLog.GeraraLog (exc);

                Saida = "Ocorreu um erro ao salvar o Serviço base.";
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }

            return Saida;
        }

        /// <summary>
        /// Carregando informaçoes do serviço base.
        /// </summary>
        /// <param name="Nome"></param>
        /// <returns></returns>
        public static ServicoBase Load(string Nome)
        {
            ServicoBase servicoBase = new ServicoBase();
            StreamReader sr = null;

            try
            {
                sr = new StreamReader(string.Format("ServicosBase/{0}.txt", Nome));

                servicoBase.Nome = sr.ReadLine();
                servicoBase.Observacoes = sr.ReadLine();
                servicoBase.Valor = sr.ReadLine();

            }
            catch (Exception exc)
            {
                ControllerArquivoLog.GeraraLog(exc);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }

            return servicoBase;
        }

        /// <summary>
        /// Carregando Lista de "nomes" de todos sos serviçoes base.
        /// </summary>
        /// <returns></returns>
        public static List<string> LoadList()
        {
            List<string> ListaBase = new List<string>();
            DirectoryInfo NomesArquivos = new DirectoryInfo("ServicosBase/");
            string[] NovoItem = new string[2];


            //Ira pegar todas os nomes dos arquivos do diretorio ira separar um por um e um array separado por '.' e lgo apos salvar o nome do arquivo sem o seu formato.

            foreach (var item in NomesArquivos.GetFiles())
            {
                NovoItem = item.ToString().Split('.');

                ListaBase.Add(NovoItem[0]);
            }

            return ListaBase;
        }

        /// <summary>
        /// Verificando se o serviço existe ou não.
        /// </summary>
        /// <param name="Nome"></param>
        /// <returns></returns>
        public static bool Verificar(string Nome)
        {
            bool Saida = false;

            if (File.Exists(string.Format("ServicosBase/{0}.txt", Nome)))
            {
                Saida = true;
            }

            return Saida;
        }
    }
}
