using System;
using System.IO;
using System.Collections.Generic;

namespace Model.Pessoa_e_Usuario
{
   public class Juridica : Pessoa
    {
        private string razaoSocial;
        private string cnpj;
        private string contato;
        private string inscricaoEstadual;
        private string nomeTeste = "";

        public string RazaoSocial
        {
            get
            {
                return razaoSocial;
            }

            set
            {
                razaoSocial = value;
            }
        }

        public string Cnpj
        {
            get
            {
                return cnpj;
            }

            set
            {
                cnpj = value;
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

        public string InscricaoEstadual
        {
            get
            {
                return inscricaoEstadual;
            }

            set
            {
                inscricaoEstadual = value;
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

                    //Parte de Pessoa Jurídica
                    sw.WriteLine(Cnpj);
                    sw.WriteLine(Contato);
                    sw.WriteLine(InscricaoEstadual);
                    sw.WriteLine(RazaoSocial);

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

                    Saida = "Pessoa Jurídica registrada com sucesso!";
                }

                return Saida;
            }
            else
            {
                Saida = "Pessoa Jurídica já cadastrado";

                return Saida;
            }
        }

        public List<string> LoadList()
        {
            List<string> ListaDePessoaJuridica = new List<string>();
            DirectoryInfo NomesArquivos = new DirectoryInfo("Pessoa/J/");
            string[] NovoItem = new string[2];


            //Ira pegar todas os nomes dos arquivos do diretorio ira separar um por um e um array separado por '.' e lgo apos salvar o nome do arquivo sem o seu formato.

            foreach (var item in NomesArquivos.GetFiles())
            {
                NovoItem = item.ToString().Split('.');

                ListaDePessoaJuridica.Add(NovoItem[0]);

            }

            return ListaDePessoaJuridica;
        }

        public bool Verificar(String _nome)
        {
            //Verifica de o já há um "usuario"(arquivo com o nome), no diretorio das pessoas físicas e retorna um valor booleano .

            bool Encontrado = false;
            DirectoryInfo Arquivo = new DirectoryInfo(String.Format("Pessoa/J/{0}.pessoaj", _nome.TrimStart().TrimEnd()));

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

        public Juridica(string _nome)
        {
            //Quando cria uma nova pessoa fisica e passado "nomeTeste", para verificar se ele já existe.

            nomeTeste = _nome;
        }

    }
}
