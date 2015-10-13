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


        public String Save(string _nome, string _endereco, string _telefone, string _situacao, string _siglaEstado, string _cidade, string _bairro, string _cep, string _observacoes, string _cnpj, string _contato, string _inscricaoestadual, string _razaosocial)
        {
            StreamWriter sw = null;
            string Saida = "";

            //Ira verificar com o nome passado na criação da classe para saber se já tem um usuario registrado com esse nome

            if (Verificar(_nome) == false)
            {
                try
                {

                    sw = new StreamWriter(String.Format("Pessoa/J/{0}.pessoaj", _nome.TrimStart().TrimEnd()));

                    Juridica PessoaJBase = new Juridica();

                    PessoaJBase.Nome = _nome;
                    PessoaJBase.Endereco = _endereco;
                    PessoaJBase.Telefone = _telefone;
                    PessoaJBase.Situacao = _situacao;
                    PessoaJBase.SiglaEstado = _siglaEstado;
                    PessoaJBase.Cidade = _cidade;
                    PessoaJBase.Bairro = _bairro;
                    PessoaJBase.Cep = _cep;
                    PessoaJBase.Observacoes = _observacoes;
                    PessoaJBase.Cnpj = _cnpj;
                    PessoaJBase.Contato = _contato;
                    PessoaJBase.InscricaoEstadual = _inscricaoestadual;
                    PessoaJBase.RazaoSocial = _razaosocial;

                    //Parte de Pessoa
                    sw.WriteLine(PessoaJBase.Nome);
                    sw.WriteLine(PessoaJBase.Endereco);
                    sw.WriteLine(PessoaJBase.Telefone);
                    sw.WriteLine(PessoaJBase.Situacao);
                    sw.WriteLine(PessoaJBase.SiglaEstado);
                    sw.WriteLine(PessoaJBase.Cidade);
                    sw.WriteLine(PessoaJBase.Bairro);
                    sw.WriteLine(PessoaJBase.Cep);
                    sw.WriteLine(PessoaJBase.Observacoes);

                    //Parte de Pessoa Jurídica
                    sw.WriteLine(PessoaJBase.Cnpj);
                    sw.WriteLine(PessoaJBase.Contato);
                    sw.WriteLine(PessoaJBase.InscricaoEstadual);
                    sw.WriteLine(PessoaJBase.RazaoSocial);
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
                Saida = "Pessoa Jurpidica já cadastrada.";

                return Saida;
            }
        }

        public Juridica Load(String _IdentificadorLoad)
        {
            Juridica PessoaJBase = new Juridica();

            StreamReader sr = null;
            try
            {
                sr = new StreamReader(String.Format("Pessoa/J/{0}.PESSOAJ", _IdentificadorLoad));

                //Parte de Pessoa
                PessoaJBase.Nome = sr.ReadLine();
                PessoaJBase.Endereco = sr.ReadLine();
                PessoaJBase.Telefone = sr.ReadLine();
                PessoaJBase.Situacao = sr.ReadLine();
                PessoaJBase.SiglaEstado = sr.ReadLine();
                PessoaJBase.Cidade = sr.ReadLine();
                PessoaJBase.Bairro = sr.ReadLine();
                PessoaJBase.Cep = sr.ReadLine();
                PessoaJBase.Observacoes = sr.ReadLine();

                //Parte de Pessoa Jurídica
                PessoaJBase.Cnpj = sr.ReadLine();
                PessoaJBase.Contato = sr.ReadLine();
                PessoaJBase.InscricaoEstadual = sr.ReadLine();
                PessoaJBase.RazaoSocial = sr.ReadLine();
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

            return PessoaJBase;
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

            if (File.Exists(String.Format("Pessoa/J/{0}.pessoaj", _nome.TrimStart().TrimEnd())))
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
