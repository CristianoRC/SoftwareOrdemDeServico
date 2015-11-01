using System;
using System.IO;

namespace Model
{
   public class Empresa
    {

        private string nome;
        private string contato;
        private string endereco;

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }
        public string Contato
        {
            get
            {
                return contato;
            }

            set
            {
                contato = value;
            }
        }
        public string Endereco
        {
            get
            {
                return endereco;
            }

            set
            {
                endereco = value;
            }
        }

        /// <summary>
        /// Pegando informações da empresa no arquivo de configuração da mesma.
        /// </summary>
        /// <returns>Informações da empresa</returns>
        public Empresa Load()
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
                Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();

                Log.ArquivoExceptionLog(Exc);
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
        public string Save(String _Nome, String _Contato, String _Endereco)
        {
            string Saida = " ";
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter("Empresa.CFG");

                sw.WriteLine(_Nome);
                sw.WriteLine(_Contato);
                sw.WriteLine(_Endereco);

                Saida = "Operação efetuada com sucesso!";
            }
            catch (Exception exc)
            {
                Saida = "Ocorreu um erro ao tentar salvar o arquivo de configuração.";

                Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();
                Log.ArquivoExceptionLog(exc);
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
