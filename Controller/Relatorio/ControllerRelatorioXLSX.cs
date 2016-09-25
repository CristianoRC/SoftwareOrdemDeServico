using System;

namespace Controller
{
    public static class ControllerRelatorioXLSX
    {
        /// <summary>
        /// Exporta a tabela de clientes do banco, gerando um arquivo XLSX como resultado final.
        /// </summary>
        /// <returns>The tabelas para XLSX.</returns>
        /// <param name="Caminho">Caminho do arquivo.</param>
        public static string ExportarTabelaDeClientesParaXLSX(String Caminho)
        {

            Spartacus.Database.Generic database;
            System.Data.DataTable tabela = new System.Data.DataTable("relatorio");
            Spartacus.Database.Command cmd = new Spartacus.Database.Command();

            cmd.v_text = @"select ID, Nome, Tipo, Email, SiglaEstado, Endereco, Cidade,Bairro
                          from Pessoa where status <> #status#";


            cmd.AddParameter("status", Spartacus.Database.Type.BOOLEAN);
            cmd.SetValue("status", "0"); // O == False.

            try
            {
                database = new Spartacus.Database.Sqlite(DB.GetStrConection());
                tabela = database.Query(cmd.GetUpdatedText(), "relatorio");

                if (tabela.Rows.Count != 0)
                {
                    database.TransferToFile(cmd.GetUpdatedText(), Caminho);

                    return "Relatório gerado com sucesso!";
                }
                else
                {
                    return "Não foi encontrado infromações no Banco de dados. ";
                }

            }
            catch (Spartacus.Database.Exception ex)
            {
                return String.Format("Ocorreu um erro ao gerar o relatório: {0}", ex.v_message);
            }
        }
    }
}

