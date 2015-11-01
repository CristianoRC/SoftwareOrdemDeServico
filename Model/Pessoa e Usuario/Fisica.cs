using System;
using System.IO;
using System.Collections.Generic;


namespace Model.Pessoa_e_Usuario
{
    public class Fisica : Pessoa
    {
        private string sexo;
        private string cpf;
        private string celular;
        private DateTime dataDeNascimento;


        public string Sexo
        {
            get
            {
                return sexo;
            }

            set
            {
                sexo = value;
            }
        }
        public string CPF
        {
            get
            {
                return cpf;
            }

            set
            {
                cpf = value;
            }
        }
        public string Celular
        {
            get
            {
                return celular;
            }

            set
            {
                celular = value;
            }
        }
        public DateTime DataDeNascimento
        {
            get
            {
                return dataDeNascimento;
            }

            set
            {
                dataDeNascimento = value;
            }
        }


        /// <summary>
        /// Salvando pessoa Física na pasta "F"(Pasta usada para guardar todas as pessoas físicas no diretorio do software).
        /// </summary>
        /// <param name="_nome"></param>
        /// <param name="_endereco"></param>
        /// <param name="_telefone"></param>
        /// <param name="_situacao"></param>
        /// <param name="_siglaEstado"></param>
        /// <param name="_cidade"></param>
        /// <param name="_bairro"></param>
        /// <param name="_cep"></param>
        /// <param name="_observacoes"></param>
        /// <param name="_cpf"></param>
        /// <param name="_celular"></param>
        /// <param name="_sexo"></param>
        /// <param name="_datadenascimento"></param>
        /// <returns></returns>
        public String Save(String _nome, String _endereco, string _telefone, string _situacao, string _siglaEstado, string _cidade, string _bairro, string _cep, string _observacoes, string _cpf, string _celular, string _sexo, DateTime _datadenascimento)
        {
            StreamWriter sw = null;
            string Saida = "";

            //Ira verificar com o nome passado na criação da classe para saber se já tem um usuario registrado com esse nome

            if (Verificar(_nome) == false)
            {

                try
                {
                    sw = new StreamWriter(String.Format("Pessoa/F/{0}.pessoaf", _nome.TrimStart().TrimEnd()));

                    Fisica PessoaFBase = new Fisica();

                    PessoaFBase.Nome = _nome;
                    PessoaFBase.Endereco = _endereco;
                    PessoaFBase.Email = _telefone;
                    PessoaFBase.Situacao = _situacao;
                    PessoaFBase.SiglaEstado = _siglaEstado;
                    PessoaFBase.Cidade = _cidade;
                    PessoaFBase.Bairro = _bairro;
                    PessoaFBase.Cep = _cep;
                    PessoaFBase.Observacoes = _observacoes;
                    PessoaFBase.CPF = _cpf;
                    PessoaFBase.sexo = _sexo;
                    PessoaFBase.celular = _celular;
                    PessoaFBase.DataDeNascimento = _datadenascimento;

                    //Parte de Pessoa
                    sw.WriteLine(PessoaFBase.Nome);
                    sw.WriteLine(PessoaFBase.Endereco);
                    sw.WriteLine(PessoaFBase.Email);
                    sw.WriteLine(PessoaFBase.Situacao);
                    sw.WriteLine(PessoaFBase.SiglaEstado);
                    sw.WriteLine(PessoaFBase.Cidade);
                    sw.WriteLine(PessoaFBase.Bairro);
                    sw.WriteLine(PessoaFBase.Cep);
                    sw.WriteLine(PessoaFBase.Observacoes);

                    //Parte de Pessoa Física
                    sw.WriteLine(PessoaFBase.CPF);
                    sw.WriteLine(PessoaFBase.celular);
                    sw.WriteLine(PessoaFBase.sexo);
                    sw.WriteLine(PessoaFBase.DataDeNascimento);

                }
                catch (Exception exc)
                {
                    Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();

                    Log.ArquivoExceptionLog(exc);

                    Saida = "Ocorreu um erro inesperado! Um arquivo com as informações desse erro foi criado no diretorio do seu software";
                }
                finally
                {
                    if (sw != null)
                        sw.Close();

                    Saida = "Pessoa Física registrada com sucesso!";
                }

                return Saida;
            }
            else
            {
                Saida = "Pessoa Física já cadastrada.";

                return Saida;
            }
        }

        /// <summary>
        /// Carregando pessoa Física.
        /// </summary>
        /// <param name="_Nome"></param>
        /// <returns>Pessoa Física</returns>
        public Fisica Load(String _Nome)
        {
            Fisica PessoaFBase = new Fisica();


            StreamReader sr = null;
            try
            {
                sr = new StreamReader(String.Format("Pessoa/F/{0}.pessoaf", _Nome));

                //Parte de Pessoa
                PessoaFBase.Nome = sr.ReadLine();
                PessoaFBase.Endereco = sr.ReadLine();
                PessoaFBase.Email = sr.ReadLine();
                PessoaFBase.Situacao = sr.ReadLine();
                PessoaFBase.SiglaEstado = sr.ReadLine();
                PessoaFBase.Cidade = sr.ReadLine();
                PessoaFBase.Bairro = sr.ReadLine();
                PessoaFBase.Cep = sr.ReadLine();
                PessoaFBase.Observacoes = sr.ReadLine();

                //Parte de Pessoa Jurídica
                PessoaFBase.cpf = sr.ReadLine();
                PessoaFBase.Celular = sr.ReadLine();
                PessoaFBase.Sexo = sr.ReadLine();
                PessoaFBase.DataDeNascimento = Convert.ToDateTime(sr.ReadLine());
            }
            catch (Exception exc)
            {
                Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();

                Log.ArquivoExceptionLog(exc);
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }

            return PessoaFBase;
        }

        /// <summary>
        /// Carregando Lista com nome de todas pessoas Físicas registradas.
        /// </summary>
        /// <returns>Lista de nomes.</returns>
        public List<string> LoadList()
        {
            List<string> ListaDePessoaFisica = new List<string>();
            DirectoryInfo NomesArquivos = new DirectoryInfo("Pessoa/F/");
            string[] NovoItem = new string[2];


            //Ira pegar todas os nomes dos arquivos do diretorio ira separar um por um e um array separado por '.' e lgo apos salvar o nome do arquivo sem o seu formato.

            foreach (var item in NomesArquivos.GetFiles())
            {
                NovoItem = item.ToString().Split('.');

                ListaDePessoaFisica.Add(NovoItem[0]);

            }

            return ListaDePessoaFisica;
        }

        /// <summary>
        /// Verificando de a "Pessoa física" existe.
        /// </summary>
        /// <param name="_nome"></param>
        /// <returns></returns>
        public bool Verificar(String _nome)
        {
            //Verifica de o já há um "usuario"(arquivo com o nome), no diretorio das pessoas físicas e retorna um valor booleano .

            bool Encontrado = false;

            if (File.Exists(String.Format("Pessoa/F/{0}.pessoaf", _nome.TrimStart().TrimEnd())))
            {
                Encontrado = true;
            }
            else
            {
                Encontrado = false;
            }

            return Encontrado;
        }

    }
}
