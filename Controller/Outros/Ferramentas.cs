using System;
using Arquivos;
using System.IO;

namespace Controller
{
	public static class Ferramentas
	{
		public static void GeraraLog(Exception Exc)
		{
			Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();

			Log.ArquivoExceptionLog(Exc);
		}
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
				GeraraLog(ex);
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
				GeraraLog(ex);
			}

			return saida;
		}
	}
}

