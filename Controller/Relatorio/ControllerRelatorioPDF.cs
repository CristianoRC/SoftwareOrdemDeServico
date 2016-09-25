using System;

namespace Controller
{
    public static class ControllerRelatorioPDF
    {
        /// <summary>
        /// Exporta a tabela de clientes do banco, gerando um PDF como resultado final.
        /// </summary>
        /// <returns>The tabelas para PDF.</returns>
        /// <param name="Caminho">Caminho do arquivo, "Nome.PDF".</param>
        public static string ExportarTabelaDeClientesParaPDF(String Caminho)
        {

            Spartacus.Database.Generic database;
            Spartacus.Reporting.Report relatorio;
            System.Data.DataTable tabela = new System.Data.DataTable("relatorio");
            Spartacus.Database.Command cmd = new Spartacus.Database.Command();


            cmd.v_text = @"select  'Lista de Clientes cadastrados  no sistema' as titulo, ID, Nome, Tipo, Email, SiglaEstado, Endereco, Cidade,Bairro
                          from Pessoa where status <> #status#";


            cmd.AddParameter("status", Spartacus.Database.Type.BOOLEAN);
            cmd.SetValue("status", "0"); // O == False.

            try
            {
                database = new Spartacus.Database.Sqlite(DB.GetStrConection());
                tabela = database.Query(cmd.GetUpdatedText(), "relatorio");

                if (tabela.Rows.Count != 0)
                {
                    System.Collections.Generic.List<Spartacus.Reporting.Field> v_fields;

                    v_fields = new System.Collections.Generic.List<Spartacus.Reporting.Field>();

                    v_fields.Add(new Spartacus.Reporting.Field("Id", "Id", Spartacus.Reporting.FieldAlignment.CENTER, 8, Spartacus.Database.Type.INTEGER));
                    v_fields.Add(new Spartacus.Reporting.Field("Nome", "Nome", Spartacus.Reporting.FieldAlignment.CENTER, 20, Spartacus.Database.Type.STRING));
                    v_fields.Add(new Spartacus.Reporting.Field("Email", "Email", Spartacus.Reporting.FieldAlignment.CENTER, 20, Spartacus.Database.Type.STRING));
                    v_fields.Add(new Spartacus.Reporting.Field("SiglaEstado", "Estado", Spartacus.Reporting.FieldAlignment.CENTER, 13, Spartacus.Database.Type.STRING));
                    v_fields.Add(new Spartacus.Reporting.Field("Endereco", "Endereço", Spartacus.Reporting.FieldAlignment.CENTER, 10, Spartacus.Database.Type.STRING));
                    v_fields.Add(new Spartacus.Reporting.Field("Cidade", "Cidade", Spartacus.Reporting.FieldAlignment.CENTER, 14, Spartacus.Database.Type.STRING));
                    v_fields.Add(new Spartacus.Reporting.Field("Bairro", "Bairro", Spartacus.Reporting.FieldAlignment.CENTER, 10, Spartacus.Database.Type.STRING));
                    v_fields.Add(new Spartacus.Reporting.Field("Tipo", "Tipo de Pessoa", Spartacus.Reporting.FieldAlignment.CENTER, 5, Spartacus.Database.Type.STRING));

                    relatorio = new Spartacus.Reporting.Report(tabela, "titulo", v_fields);
                    relatorio.Execute();
                    relatorio.Save(Caminho);

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

