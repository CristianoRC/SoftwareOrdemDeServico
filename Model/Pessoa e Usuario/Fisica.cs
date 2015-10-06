using System;
using System.IO;
using System.Collections.Generic;


namespace Model.Pessoa_e_Usuario
{
    public class Fisica : Pessoa
    {
        private char sexo; //Usar sempre letra maiuscula.
        private string cpf;
        private string celular;
        private DateTime dataDeNascimento;


        public char Sexo
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

        public string Cpf
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

        public String Save(String _nome, String _endereco, string _telefone, char _situacao, string _siglaEstado, string _cidade, string _bairro, string _cep, string _observacoes, string _cpf, string _celular, char _sexo, DateTime _datadenascimento)
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
                    PessoaFBase.Telefone = _telefone;
                    PessoaFBase.Situacao = _situacao;
                    PessoaFBase.SiglaEstado = _siglaEstado;
                    PessoaFBase.Cidade = _cidade;
                    PessoaFBase.Bairro = _bairro;
                    PessoaFBase.Cep = _cep;
                    PessoaFBase.Observacoes = _observacoes;
                    PessoaFBase.Cpf = _cpf;
                    PessoaFBase.sexo = _sexo;
                    PessoaFBase.celular = _celular;
                    PessoaFBase.DataDeNascimento = _datadenascimento;

                    //Parte de Pessoa
                    sw.WriteLine(PessoaFBase.Nome);
                    sw.WriteLine(PessoaFBase.Endereco);
                    sw.WriteLine(PessoaFBase.Telefone);
                    sw.WriteLine(PessoaFBase.Situacao);
                    sw.WriteLine(PessoaFBase.SiglaEstado);
                    sw.WriteLine(PessoaFBase.Cidade);
                    sw.WriteLine(PessoaFBase.Bairro);
                    sw.WriteLine(PessoaFBase.Cep);
                    sw.WriteLine(PessoaFBase.Observacoes);

                    //Parte de Pessoa Física
                    sw.WriteLine(PessoaFBase.Cpf);
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

        public Fisica Load(String _Nome)
        {
            Fisica PessoaFBase = new Fisica();

            if (Verificar(_Nome))
            {
                StreamReader sr = null;
                try
                {
                    sr = new StreamReader(String.Format("Pessoa/J/{0}.pessoaj", _Nome));

                    //Parte de Pessoa
                    PessoaFBase.Endereco = sr.ReadLine();
                    PessoaFBase.Telefone = sr.ReadLine();
                    PessoaFBase.Situacao = Convert.ToChar(sr.ReadLine());
                    PessoaFBase.SiglaEstado = sr.ReadLine();
                    PessoaFBase.Cidade = sr.ReadLine();
                    PessoaFBase.Bairro = sr.ReadLine();
                    PessoaFBase.Cep = sr.ReadLine();
                    PessoaFBase.Observacoes = sr.ReadLine();

                    //Parte de Pessoa Jurídica
                    PessoaFBase.cpf = sr.ReadLine();
                    PessoaFBase.Celular = sr.ReadLine();
                    PessoaFBase.Sexo = Convert.ToChar(sr.ReadLine());
                    PessoaFBase.DataDeNascimento = Convert.ToDateTime(sr.ReadLine());
                }
                catch (Exception exc)
                {
                    //TODO Implementar sistema de aviso de arquivo para Windows Forms & Console;
                    Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();

                    Log.ArquivoExceptionLog(exc);
                }
                finally
                {
                    if (sr != null)
                        sr.Close();
                }
            }
            else
            {
                //TODO Implementar sistema de aviso de arquivo para Windows Forms & Console;
            }

            return PessoaFBase;
        }

        public List<string> LoadLista()
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

        public bool Verificar(String _nome)
        {
            //Verifica de o já há um "usuario"(arquivo com o nome), no diretorio das pessoas físicas e retorna um valor booleano .

            bool Encontrado = false;
            DirectoryInfo Arquivo = new DirectoryInfo(String.Format("Pessoa/F/{0}.pessoaf", _nome.TrimStart().TrimEnd()));

            if (Arquivo.Exists)
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
