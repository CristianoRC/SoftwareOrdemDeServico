using System;
using System.IO;

namespace Controller
{
    public static class ControllerArquivoLog
    {

        public static void GeraraLog(Exception exc)
        {
            StreamWriter sw = null;

            try 
            {
                sw = new StreamWriter(String.Format("{0}/Log.txt",Ferramentas.ObterCaminhoDoExecutavel()),true);

                sw.WriteLine("---------------------------------------------");
                sw.WriteLine(DateTime.Now.ToLongDateString());
                sw.WriteLine("Erro: {0}", exc.ToString());
                sw.WriteLine("---------------------------------------------");
            } 
            finally
            {
                if(sw != null)
                {
                    sw.Close();
                }
            }

        }
    }
}

