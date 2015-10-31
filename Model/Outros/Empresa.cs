using System;
using System.IO;

namespace Model
{
    class Empresa
    {
        /// <summary>
        /// Pegando informações da empresa no arquivo de configuração da mesma.
        /// </summary>
        /// <returns>Informações da empresa</returns>
        public string[] RetornarValor()
        {
            StreamReader sr = null;
            string[] valores = new string[3];

            try
            {
                sr = new StreamReader("Empresa.CFG");

                valores[0] = sr.ReadLine();
                valores[1] = sr.ReadLine();
                valores[2] = sr.ReadLine();

            }     
            catch(FileNotFoundException)
            {
                valores[0] = "Erro arquivo não encontrado";
                valores[2] = "Erro arquivo não encontrado";
                valores[3] = "Erro arquivo não encontrado";

                return valores;
            }
            catch (Exception Exc)
            {
                Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();

                Log.ArquivoExceptionLog(Exc);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }

            return valores;
        }
    }
}
