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
                sw = new StreamWriter("Log.txt",true);

                sw.WriteLine("---------------------------------------------");
                sw.WriteLine(DateTime.Now.ToLongDateString());
                sw.WriteLine("Erro: {0}", exc.Message);
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

