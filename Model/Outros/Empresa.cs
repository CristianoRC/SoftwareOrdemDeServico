using System;
using System.IO;

namespace Model
{
    class Empresa
    {
        //TODO: Fazer a função Save(); Tem pronto direto no formulario;
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
    }
}
