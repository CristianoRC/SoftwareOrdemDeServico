using System;
using System.IO;
using Model.Pessoa_e_Usuario;
using System.Collections.Generic;


namespace Controller
{
    public static class ControllerFisica
    {
        //TODO: Dar manutenção nos métodos com muitos parâmetros;
        /// <summary>
        /// Salvando pessoa Física na pasta "F"(Pasta usada para guardar todas as pessoas físicas no diretorio do software).
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="endereco"></param>
        /// <param name="email"></param>
        /// <param name="situacao"></param>
        /// <param name="siglaEstado"></param>
        /// <param name="cidade"></param>
        /// <param name="bairro"></param>
        /// <param name="cep"></param>
        /// <param name="observacoes"></param>
        /// <param name="cpf"></param>
        /// <param name="celular"></param>
        /// <param name="sexo"></param>
        /// <param name="datadenascimento"></param>
        /// <returns></returns>
        public static String Save(String nome, String endereco, string email, string situacao, string siglaEstado, string cidade, string bairro, string cep, string observacoes, string cpf, string celular, string sexo, DateTime datadenascimento)
        {
            StreamWriter sw = null;
            string Saida = "";

            //Ira verificar com o nome passado na criação da classe para saber se já tem um usuario registrado com esse nome

            if (Verificar(nome) == false)
            {

                try
                {
                    sw = new StreamWriter(String.Format("Pessoa/F/{0}.pessoaf", nome.TrimStart().TrimEnd()));

                    Fisica PessoaFBase = new Fisica();

                    PessoaFBase.Nome = nome;
                    PessoaFBase.Endereco = endereco;
                    PessoaFBase.Email = email;
                    PessoaFBase.Situacao = situacao;
                    PessoaFBase.SiglaEstado = siglaEstado;
                    PessoaFBase.Cidade = cidade;
                    PessoaFBase.Bairro = bairro;
                    PessoaFBase.Cep = cep;
                    PessoaFBase.Observacoes = observacoes;
                    PessoaFBase.CPF = cpf;
                    PessoaFBase.Sexo = sexo;
                    PessoaFBase.Celular = celular;
                    PessoaFBase.DataDeNascimento = datadenascimento;

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
                    sw.WriteLine(PessoaFBase.Celular);
                    sw.WriteLine(PessoaFBase.Sexo);
                    sw.WriteLine(PessoaFBase.DataDeNascimento);

                }
                catch (Exception exc)
                {
                    Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();

                    Log.ArquivoExceptionLog(exc);

                    Saida = "Ocorreu um erro inesperado: " + exc.Message;
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
        /// Editando pessoa Física na pasta "F"(Pasta usada para guardar todas as pessoas físicas no diretorio do software).
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="endereco"></param>
        /// <param name="email"></param>
        /// <param name="situacao"></param>
        /// <param name="siglaEstado"></param>
        /// <param name="cidade"></param>
        /// <param name="bairro"></param>
        /// <param name="cep"></param>
        /// <param name="observacoes"></param>
        /// <param name="cpf"></param>
        /// <param name="celular"></param>
        /// <param name="sexo"></param>
        /// <param name="datadenascimento"></param>
        /// <returns></returns>
        public static String Edit(String nome, String endereco, string email, string situacao, string siglaEstado, string cidade, string bairro, string cep, string observacoes, string cpf, string celular, string sexo, DateTime datadenascimento)
        {
            StreamWriter sw = null;
            string Saida = "";

            //Ira verificar com o nome passado na criação da classe para saber se já tem um usuario registrado com esse nome

            try
            {
                sw = new StreamWriter(String.Format("Pessoa/F/{0}.pessoaf", nome.TrimStart().TrimEnd()));

                Fisica PessoaFBase = new Fisica();

                PessoaFBase.Nome = nome;
                PessoaFBase.Endereco = endereco;
                PessoaFBase.Email = email;
                PessoaFBase.Situacao = situacao;
                PessoaFBase.SiglaEstado = siglaEstado;
                PessoaFBase.Cidade = cidade;
                PessoaFBase.Bairro = bairro;
                PessoaFBase.Cep = cep;
                PessoaFBase.Observacoes = observacoes;
                PessoaFBase.CPF = cpf;
                PessoaFBase.Sexo = sexo;
                PessoaFBase.Celular = celular;
                PessoaFBase.DataDeNascimento = datadenascimento;

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
                sw.WriteLine(PessoaFBase.Celular);
                sw.WriteLine(PessoaFBase.Sexo);
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

                Saida = "Pessoa Física editada com sucesso!";
            }

            return Saida;
        }

        /// <summary>
        /// Carregando pessoa Física.
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>Pessoa Física</returns>
        public static Fisica Load(String nome)
        {
            Fisica PessoaFBase = new Fisica();


            StreamReader sr = null;
            try
            {
                sr = new StreamReader(String.Format("Pessoa/F/{0}.pessoaf", nome));

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
                PessoaFBase.CPF = sr.ReadLine();
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
        public static List<string> LoadList()
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
        /// <param name="nome"></param>
        /// <returns></returns>
        public static bool Verificar(String nome)
        {
            //Verifica de o já há um "usuario"(arquivo com o nome), no diretorio das pessoas físicas e retorna um valor booleano .

            bool Encontrado = false;

            if (File.Exists(String.Format("Pessoa/F/{0}.pessoaf", nome).TrimEnd().TrimStart()))
            {
                Encontrado = true;
            }
            else
            {
                Encontrado = false;
            }

            return Encontrado;
        }

        /// <summary>
        /// Excluindo pessoa física
        /// </summary>
        /// <param name="Nome"></param>
        /// <returns>Resultado da operação</returns>
        public static string Excluir(string Nome)
        {
            string saida = String.Format("Pessoa física {0} foi excluida com sucesso!", Nome);

            try
            {
                File.Delete(string.Format("Pessoa/F/{0}.pessoaf", Nome));
            }
            catch (Exception exc)
            {
                saida = string.Format("Ocorreu um erro ao excluir a pessoa física: {0}", exc.Message);
            }

            return saida;
        }

    }
}
