using System;
using System.IO;
using System.Collections.Generic;
using Model.Pessoa_e_Usuario;

namespace Model.Ordem_de_Servico
{
    public class OrdemServico
    {
        private int identificador;
        private string referencia;
        private string situacao; //P para pronto M para manutenção A avaliação
        private string defeito;
        private string descricao;
        private string observacao;
        private string numeroSerie;
        private string equipamento;
        private DateTime dataEntradaServico; //Substitiu o int que tem na documentação, para salvar a data e a hora de entrada do serviço/produto.
        private Fisica pessoaFisica;
        private Juridica pessoaJuridica;

        public string Referencia
        {
            get
            {
                return referencia;
            }

            set
            {
                referencia = value;
            }
        }

        public string Situacao
        {
            get
            {
                return situacao;
            }

            set
            {
                situacao = value;
            }
        }

        public string Defeito
        {
            get
            {
                return defeito;
            }

            set
            {
                defeito = value;
            }
        }

        public string Descricao
        {
            get
            {
                return descricao;
            }

            set
            {
                descricao = value;
            }
        }

        public string Observacao
        {
            get
            {
                return observacao;
            }

            set
            {
                observacao = value;
            }
        }

        public string NumeroSerie
        {
            get
            {
                return numeroSerie;
            }

            set
            {
                numeroSerie = value;
            }
        }

        public string Equipamento
        {
            get
            {
                return equipamento;
            }

            set
            {
                equipamento = value;
            }
        }

        public DateTime DataEntradaServico
        {
            get
            {
                return dataEntradaServico;
            }

            set
            {
                dataEntradaServico = value;
            }
        }

        public Fisica PessoaFisica
        {
            get
            {
                return pessoaFisica;
            }

            set
            {
                pessoaFisica = value;
            }
        }
        //TODO:Verificar o código para ter um responsavel pela ordem de serviço
        public Juridica PessoaJuridica
        {
            get
            {
                return pessoaJuridica;
            }

            set
            {
                pessoaJuridica = value;
            }
        }

        public int Identificador
        {
            get
            {
                return identificador;
            }

            set
            {
                identificador = value;
            }
        }

        public string Save(int _Identificador)
        {
            OrdemServico OSBase = new OrdemServico();
            string Saida = null;

            OSBase.DataEntradaServico = DateTime.Now;
            Random R = new Random();
            OSBase.Identificador = R.Next(999999999);

            StreamWriter sw = null;


            if (Verificar(OSBase.identificador) == false)
            {
                try
                {
                    sw = new StreamWriter(String.Format("OS/{0}.os", Identificador));

                    sw.WriteLine(OSBase.Identificador); //O numero da ordem de serviço vai vir sempre 1º.
                    sw.WriteLine(OSBase.PessoaFisica);  //TODO Arrumar Código para verificar o tipo depessoa.
                    sw.WriteLine(OSBase.Equipamento);
                    sw.WriteLine(OSBase.Situacao);
                    sw.WriteLine(OSBase.NumeroSerie);
                    sw.WriteLine(OSBase.Defeito);
                    sw.WriteLine(OSBase.Referencia);
                    sw.WriteLine(OSBase.DataEntradaServico);
                    sw.WriteLine(OSBase.Observacao);
                }
                catch (System.Exception Exc)
                {
                    Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();

                    Log.ArquivoExceptionLog(Exc);

                    Saida = "Ocorreu um erro inesperado! Um arquivo com as informações desse erro foi criado no diretorio do seu software";
                }
                finally
                {
                    if (sw != null)
                    {
                        sw.Close();

                        Saida = "Ordem de Serviço registrada com sucesso!";
                    }

                }
            }
            else
            {
                Save(OSBase.Identificador);
            }


            return Saida;

        }

        public List<string> LoadList()
        {
            List<string> ListaDeOS = new List<string>();
            DirectoryInfo NomesArquivos = new DirectoryInfo("OS/");
            string[] NovoItem = new string[2];


            //Ira pegar todas os nomes dos arquivos do diretorio ira separar um por um e um array separado por '.' e lgo apos salvar o nome do arquivo sem o seu formato.

            foreach (var item in NomesArquivos.GetFiles())
            {
                NovoItem = item.ToString().Split('.');

                ListaDeOS.Add(NovoItem[0]);
            }

            return ListaDeOS;
        }

        public OrdemServico Load(int _Identificador)
        {
            OrdemServico OSBase = new OrdemServico();
            StreamReader sr = null;

            if (Verificar(_Identificador))
            {
                try
                {
                    sr = new StreamReader(String.Format("OS/{0}.os", _Identificador));

                    OSBase.Identificador = int.Parse(sr.ReadLine());
                    //OSBase.PessoaFisica = sr.ReadLine(); //TODO: Arrumar na questão de pessoa Fisica ou Juridica.
                    OSBase.Equipamento = sr.ReadLine();
                    OSBase.Situacao = sr.ReadLine();
                    OSBase.NumeroSerie = sr.ReadLine();
                    OSBase.Defeito = sr.ReadLine();
                    OSBase.Referencia = sr.ReadLine();
                    OSBase.DataEntradaServico = DateTime.Parse(sr.ReadLine());
                    OSBase.Observacao = sr.ReadLine();
                }
                catch (Exception Exc)
                {
                    Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();

                    Log.ArquivoExceptionLog(Exc);
                }
                finally
                {
                    if (sr != null)
                        sr.Close();
                }
            }
            else
            {
                //TODO:Verificar uma meneira de retornar uma mensagem.
            }


            return OSBase;
        }

        public bool Verificar(int _Identificador)
        {
            //Verifica de o já há uma "Ordem de Serviço"(arquivo com o nome), no diretorio das pessoas físicas e retorna um valor booleano .

            bool Encontrado = false;
            DirectoryInfo Arquivo = new DirectoryInfo(string.Format("OS/{0}.os", _Identificador));

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
