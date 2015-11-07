using System;
using System.IO;
using System.Collections.Generic;
using Model.Pessoa_e_Usuario;

namespace Controller
{
    public class ControllerJuridica
    {

        /// <summary>
        /// Salvando pessoa Jurídica na pasta "J"(Pasta usada para guardar todas as pessoas jurídicas no diretorio do software)
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
        /// <param name="_cnpj"></param>
        /// <param name="_contato"></param>
        /// <param name="_inscricaoestadual"></param>
        /// <param name="_razaosocial"></param>
        /// <returns></returns>
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
                    PessoaJBase.Email = _telefone;
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
                    sw.WriteLine(PessoaJBase.Email);
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

        /// <summary>
        /// Carregando pessoa Física.
        /// </summary>
        /// <param name="_IdentificadorLoad"></param>
        /// <returns>Pessoa Jurídica.</returns>
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
                PessoaJBase.Email = sr.ReadLine();
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

        /// <summary>
        /// Carregando Lista com nome de todas pessoas Jurídicas registradas.
        /// </summary>
        /// <returns>Lista de nomes.</returns>
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

        /// <summary>
        /// Verificando de a "Pessoa jurídica" existe.
        /// </summary>
        /// <param name="_nome"></param>
        /// <returns></returns>
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
