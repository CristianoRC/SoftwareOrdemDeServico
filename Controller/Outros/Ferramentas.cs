using System;
using System.IO;
using System.Windows.Forms;

namespace Controller
{
	public static class Ferramentas
	{
		public static void SalvarUltimoLogin(string Login)
		{
			StreamWriter sw = null;

			try
			{
				sw = new StreamWriter(String.Format("{0}/UltimoLogin.dat", ObterCaminhoDoExecutavel()));

				sw.WriteLine(Login);
			}
			catch (Exception ex)
			{
				ControllerArquivoLog.GeraraLog(ex);
			}
			finally
			{
				if (sw != null)
					sw.Close();
			}
		}

		public static string RecuperarUltimoLogin()
		{
			StreamReader sr = null;
			string saida = "";
			string LocalDoArquivo = String.Format("{0}/UltimoLogin.dat", ObterCaminhoDoExecutavel());


			try
			{
				if (File.Exists(LocalDoArquivo))
				{
					sr = new StreamReader(LocalDoArquivo);

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
					sr.Close();
			}

			return saida;
		}

		/// <summary>
		/// Retona o caminho para o arquivo executável que iniciou o aplicativo.(A pasta do Executável)
		/// Documentação: https://msdn.microsoft.com/pt-br/library/system.windows.forms.application.startuppath(v=vs.110).aspx
		/// </summary>
		public static string ObterCaminhoDoExecutavel()
		{
			return Application.StartupPath.ToString();			
		}

		public static bool VerificarEmailValido(string email)
		{
			try
			{
				var addr = new System.Net.Mail.MailAddress(email);
				return addr.Address == email;
			}
			catch
			{
				return false;
			}
		}
	}
}