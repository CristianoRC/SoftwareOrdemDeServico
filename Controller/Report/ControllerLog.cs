using System;
using System.IO;

namespace Controller
{
    public static class ControllerLog
    {
        /// <summary>
        /// Enviando informações sobre problemas no software e arquivo de log.
        /// </summary>
        /// <param name="Menssagem"></param>
        /// <returns></returns>
        public static string enviar(String Menssagem)
        {
            string saida;

            saida = ControllerEmail.EnviarArquivoLog(ControllerEmpresa.Load().Nome, Menssagem);

            return saida;
        }

        /// <summary>
        /// Apagando o arquivo de Log
        /// </summary>
        public static void apagar()
        {
            string CaminhoArquivoLog = String.Format("{0}/Log.txt",Ferramentas.ObterCaminhoDoExecutavel());

            if (File.Exists(CaminhoArquivoLog))
            {
                File.Delete(CaminhoArquivoLog);
            }
        }
    }
}
