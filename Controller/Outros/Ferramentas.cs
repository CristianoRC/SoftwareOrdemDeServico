using System;
using System.IO;

namespace Controller
{
	public static class Ferramentas
	{
		public static void SalvarUltimoLogin(string Login)
		{
			StreamWriter sw = null;

			try 
			{
				sw = new StreamWriter("UltimoLogin.dat");

				sw.WriteLine(Login);
			}
			catch (Exception ex) 
			{
                ControllerArquivoLog.GeraraLog(ex);
			}
			finally 
			{
				if (sw != null)
					sw.Close ();
			}
		}

		public static string RecuperarUltimoLogin()
		{
			StreamReader sr = null;
			string saida = "";

			try 
			{
				if(File.Exists("UltimoLogin.dat"))
				{
					sr = new StreamReader("UltimoLogin.dat");

					saida = sr.ReadLine();
				}
				
			}
			catch (Exception ex) 
			{
                ControllerArquivoLog.GeraraLog(ex);
			}
			finally
			{
				if (sr != null)
					sr.Close ();
			}

			return saida;
		}
	}
}