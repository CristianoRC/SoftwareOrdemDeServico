using System;
using System.IO;
using System.Collections.Generic;
using Model.Pessoa_e_Usuario;

namespace Controller
{
    public static class ControllerJuridica
    {
        //TODO: Dar manutenção as classes abaixo, muitos parâmetros;


        /// <summary>
        /// Salvando pessoa Jurídica na pasta "J"(Pasta usada para guardar todas as pessoas jurídicas no diretorio do software)
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
        /// <param name="cnpj"></param>
        /// <param name="contato"></param>
        /// <param name="inscricaoestadual"></param>
        /// <param name="razaosocial"></param>
        /// <returns></returns>
        public static String Save(string nome, string endereco, string email, string situacao, string siglaEstado, string cidade, string bairro, string cep, string observacoes, string cnpj, string contato, string inscricaoestadual, string razaosocial)
        {
            StreamWriter sw = null;
            string Saida = "";

            //Ira verificar com o nome passado na criação da classe para saber se já tem um usuario registrado com esse nome

            if (Verificar(nome) == false)
            {
                try
                {

                    sw = new StreamWriter(String.Format("Pessoa/J/{0}.pessoaj", nome.TrimStart().TrimEnd()));

                    Juridica PessoaJBase = new Juridica();

                    PessoaJBase.Nome = nome;
                    PessoaJBase.Endereco = endereco;
                    PessoaJBase.Email = email;
                    PessoaJBase.Situacao = situacao;
                    PessoaJBase.SiglaEstado = siglaEstado;
                    PessoaJBase.Cidade = cidade;
                    PessoaJBase.Bairro = bairro;
                    PessoaJBase.Cep = cep;
                    PessoaJBase.Observacoes = observacoes;
                    PessoaJBase.Cnpj = cnpj;
                    PessoaJBase.Contato = contato;
                    PessoaJBase.InscricaoEstadual = inscricaoestadual;
                    PessoaJBase.RazaoSocial = razaosocial;

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
                    ControllerArquivoLog.GeraraLog(exc);

                    Saida = "Ocorreu um erro inesperado: " + exc.Message;
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
                //Se o a pessoa jurídica já for cadastrada caira nesse código como retorno e nada sera salvo.
                Saida = "Pessoa Jurídica já cadastrada.";

                return Saida;
            }
        }

        /// <summary>
        /// Editando pessoa Jurídica na pasta "J"(Pasta usada para guardar todas as pessoas jurídicas no diretorio do software)
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
        /// <param name="cnpj"></param>
        /// <param name="contato"></param>
        /// <param name="inscricaoestadual"></param>
        /// <param name="razaosocial"></param>
        /// <returns></returns>
        public static String Edit(string nome, string endereco, string email, string situacao, string siglaEstado, string cidade, string bairro, string cep, string observacoes, string cnpj, string contato, string inscricaoestadual, string razaosocial)
        {
            StreamWriter sw = null;
            string Saida = "";

            //Ira verificar com o nome passado na criação da classe para saber se já tem um usuario registrado com esse nome

            try
            {

                sw = new StreamWriter(String.Format("Pessoa/J/{0}.pessoaj", nome.TrimStart().TrimEnd()));

                Juridica PessoaJBase = new Juridica();

                PessoaJBase.Nome = nome;
                PessoaJBase.Endereco = endereco;
                PessoaJBase.Email = email;
                PessoaJBase.Situacao = situacao;
                PessoaJBase.SiglaEstado = siglaEstado;
                PessoaJBase.Cidade = cidade;
                PessoaJBase.Bairro = bairro;
                PessoaJBase.Cep = cep;
                PessoaJBase.Observacoes = observacoes;
                PessoaJBase.Cnpj = cnpj;
                PessoaJBase.Contato = contato;
                PessoaJBase.InscricaoEstadual = inscricaoestadual;
                PessoaJBase.RazaoSocial = razaosocial;

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
                ControllerArquivoLog.GeraraLog(exc);

                Saida = "Ocorreu um erro inesperado! Um arquivo com as informações desse erro foi criado no diretorio do seu software";
            }
            finally
            {
                if (sw != null)
                    sw.Close();

                Saida = "Pessoa Jurídica editada com sucesso!";
            }

            return Saida;
        }

        /// <summary>
        /// Carregando pessoa Física.
        /// </summary>
        /// <param name="IdentificadorLoad"></param>
        /// <returns>Pessoa Jurídica.</returns>
        public static Juridica Load(String IdentificadorLoad)
        {
            Juridica PessoaJBase = new Juridica();

            StreamReader sr = null;
            try
            {
                sr = new StreamReader(String.Format("Pessoa/J/{0}.PESSOAJ", IdentificadorLoad));

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
                ControllerArquivoLog.GeraraLog(exc);
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
        public static List<string> LoadList()
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
        /// <param name="nome"></param>
        /// <returns></returns>
        public static bool Verificar(String nome)
        {
            //Verifica de o já há um "usuario"(arquivo com o nome), no diretorio das pessoas físicas e retorna um valor booleano .

            bool Encontrado = false;

            if (File.Exists(String.Format("Pessoa/J/{0}.pessoaj", nome.TrimStart().TrimEnd())))
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
        /// Excluindo pessoa jurídica
        /// </summary>
        /// <param name="Nome"></param>
        /// <returns>Resultado da operação</returns>
        public static string Excluir(string Nome)
        {
            string saida = String.Format("Pessoa jurídica {0} foi excluida com sucesso!", Nome);

            try
            {
                File.Delete(string.Format("Pessoa/J/{0}.pessoaj", Nome));
            }
            catch (Exception exc)
            {
                saida = string.Format("Ocorreu um erro ao excluir a pessoa jurídica: {0}", exc.Message);
            }

            return saida;
        }

    }
}
