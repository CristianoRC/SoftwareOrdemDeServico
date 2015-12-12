using System;
using System.IO;

namespace Controller
{
    public class ControllerLog
    {
        /// <summary>
        /// Enviando informações sobre problemas no software e arquivo de log.
        /// </summary>
        /// <param name="Menssagem"></param>
        /// <returns></returns>
        public string enviar(String Menssagem)
        {
            ControllerEmail controllerEmail = new ControllerEmail();
            string saida;
            ControllerEmpresa controllerEmpresa = new ControllerEmpresa();

            saida = controllerEmail.EnviarArquivoLog(controllerEmpresa.Load().Nome, Menssagem);

            return saida;
        }

        /// <summary>
        /// Apagando o arquivo de Log
        /// </summary>
        public void apagar()
        {
            if (File.Exists("Log.txt"))
            {
                File.Delete("Log.txt");
            }
        }
    }
}
