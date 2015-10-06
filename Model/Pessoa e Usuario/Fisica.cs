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
        private string nomeTeste = "";


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


        public String Save()
        {
            StreamWriter sw = null;
            string Saida = "";

            //Ira verificar com o nome passado na criação da classe para saber se já tem um usuario registrado com esse nome

            if (Verificar(nomeTeste) == false)
            {

                try
                {
                    sw = new StreamWriter(String.Format("Pessoa/F/{0}.pessoaf", nomeTeste.TrimStart().TrimEnd()));

                    //Parte de Pessoa
                    sw.WriteLine(Nome);
                    sw.WriteLine(Endereco);
                    sw.WriteLine(Telefone);
                    sw.WriteLine(Situacao);
                    sw.WriteLine(SiglaEstado);
                    sw.WriteLine(Cidade);
                    sw.WriteLine(Bairro);
                    sw.WriteLine(Cep);
                    sw.WriteLine(Observacoes);

                    //Parte de Pessoa Física
                    sw.WriteLine(cpf);
                    sw.WriteLine(Celular);
                    sw.WriteLine(Sexo);
                    sw.WriteLine(DataDeNascimento);

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
                Saida = "Usuario já cadastrado";

                return Saida;
            }
        }

        public List<string> Load()
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

        public Fisica(string _nome)
        {
            //Quando cria uma nova pessoa fisica e passado "nomeTeste", para verificar se ele já existe.

            nomeTeste = _nome;
        }
    }
}
