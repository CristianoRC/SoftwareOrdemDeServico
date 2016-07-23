using Ionic.Zip;
using System.Collections.Generic;
using System.IO;

namespace Controller
{
    public static class ControllerBackup
    {
        /// <summary>
        /// Criando arquivo "Zip" de backup das informações.
        /// </summary>
        /// <param name="arquivos"></param>
        /// <param name="ArquivoDestino"></param>
        public static void CriarArquivoZip(List<string> arquivos, string ArquivoDestino)
        {
            ZipFile zip = new ZipFile();

            // percorre todos os arquivos da lista
            foreach (string item in arquivos)
            {
                // se o item é um arquivo
                if (File.Exists(item))
                {
                    try
                    {
                        // Adiciona o arquivo na pasta raiz dentro do arquivo zip
                        zip.AddFile(item, "");
                    }
                    catch
                    {

                    }
                }
                // se o item é uma pasta
                else if (Directory.Exists(item))
                {
                    try
                    {
                        // Adiciona a pasta no arquivo zip com o nome da pasta 
                        zip.AddDirectory(item, new DirectoryInfo(item).Name);
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
            // Salva o arquivo zip para o destino
            try
            {
                zip.Save(ArquivoDestino);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Extraindo informações do "Zip" e colocando na pasta do software.
        /// </summary>
        /// <param name="localizacaoArquivoZip"></param>
        /// <param name="destino"></param>
        public static string ExtrairArquivoZip(string localizacaoArquivoZip, string destino)
        {
            string saida;

            if (File.Exists(localizacaoArquivoZip))
            {
                //recebe a localização do arquivo zip
                ZipFile zip = new ZipFile(localizacaoArquivoZip);
                {
                    //verifica se o destino existe
                    if (Directory.Exists(destino))
                    {
                        try
                        {
                            //extrai o arquivo zip para o destino
                            zip.ExtractExistingFile = ExtractExistingFileAction.OverwriteSilently; // Sobrepor os arquivos para não dar erro de arquivo já existente.
                            zip.ExtractAll(destino);
                           

                            saida = "O backup fou restaurado com sucesso. Reinicie o software para finalizar a operação.";
                        }
                        catch (System.Exception exc)
                        {
                            saida = "Falha ao restaurar o backup";

                            ControllerArquivoLog.GeraraLog (exc);
                        }
                    }
                    else
                    {
                        //lança uma exceção se o destino não existe
                        saida = "O arquivo destino não foi localizado";
                    }
                }
            }
            else
            {
                //lança uma exceção se a origem não existe
                saida = "O Arquivo Zip não foi localizado";
            }
            return saida;
        }
    }
}
