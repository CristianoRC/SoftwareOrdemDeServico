using System;
using Arquivos;

namespace Controller
{
	public static class Ferramentas
	{
		public static void GeraraLog(Exception Exc)
		{
			Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();

			Log.ArquivoExceptionLog(Exc);
		}
	}
}

