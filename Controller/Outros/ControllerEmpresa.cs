using System;
using System.IO;
using Model;

namespace Controller
{
    public static class ControllerEmpresa
    {

        /// <summary>
        /// Pegando informações da empresa no arquivo de configuração da mesma.
        /// </summary>
        /// <returns>Informações da empresa</returns>
        public static Empresa Load()
        {
            StreamReader sr = null;
            Empresa EmpresaBase = new Empresa();

            try
            {
                sr = new StreamReader("Empresa.CFG");

                EmpresaBase.Nome = sr.ReadLine();
                EmpresaBase.Contato = sr.ReadLine();
                EmpresaBase.Endereco = sr.ReadLine();

            }
            catch (Exception Exc)
            {
                ControllerArquivoLog.GeraraLog(Exc);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }

            return EmpresaBase;
        }

        /// <summary>
        /// Salvando informações da empresa
        /// </summary>
        /// <param name="_Nome"></param>
        /// <param name="_Contato"></param>
        /// <param name="_Endereco"></param>
        /// <returns></returns>
        public static string Save(String Nome, String Contato, String Endereco)
        {
            string Saida = " ";
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter("Empresa.CFG");

                sw.WriteLine(Nome);
                sw.WriteLine(Contato);
                sw.WriteLine(Endereco);

                Saida = "Operação efetuada com sucesso!";
            }
            catch (Exception exc)
            {
                Saida = "Ocorreu um erro ao tentar salvar o arquivo de configuração.";

                ControllerArquivoLog.GeraraLog (exc);
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }

            return Saida;
        }
    }
}
