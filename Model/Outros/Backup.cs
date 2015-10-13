using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;

namespace Model
{
    public class Backup
    {
        public void CriarArquivoZip(List<string> arquivos, string ArquivoDestino)
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

        public void ExtrairArquivoZip(string localizacaoArquivoZip, string destino)
        {
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
                            zip.ExtractAll(destino);
                        }
                        catch
                        {
                            
                        }
                    }
                    else
                    {
                        //lança uma exceção se o destino não existe
                        throw new DirectoryNotFoundException("O arquivo destino não foi localizado");
                    }
                }
            }
            else
            {
                //lança uma exceção se a origem não existe
                throw new FileNotFoundException("O Arquivo Zip não foi localizado");
            }
        }
    }
}
