using System;

namespace Controller
{
	public static class ControllerRelatoriosXLSX
	{

		/// <summary>
		/// Exporta as infromações da Query passada por parâmetro, para um arquivo XLSX
		/// </summary>
		/// <returns>The tabela para XLS.</returns>
		/// <param name="Caminho">Caminho em que será salvo o arquivo, completo, já com a extenção e o nome.</param>
		/// <param name="QuerySQL">Comando que será utilizado para gerar a tebela que será exportada.</param>
		public static string ExportarTabelaParaXLSX(String Caminho, Spartacus.Database.Command QuerySQL)
		{
			Spartacus.Database.Generic database;

			try
			{
				database = new Spartacus.Database.Sqlite(DB.GetStrConection());

				database.TransferToFile(QuerySQL.GetUpdatedText(), Caminho);

				return "Relatório gerado com sucesso!";

			}
			catch (Spartacus.Database.Exception ex)
			{
				return String.Format("Ocorreu um erro ao gerar o relatório: {0}", ex.v_message);
			}
		}
	}
}

