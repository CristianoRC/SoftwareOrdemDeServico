using System;
using System.IO;
using System.Collections.Generic;
using Model.Pessoa_e_Usuario;

namespace Model.Ordem_de_Servico
{
    public class OrdemServico
    {
        private string identificador;
        private string referencia;
        private string situacao;
        private string defeito;
        private string descricao;
        private string observacao;
        private string numeroSerie;
        private string equipamento;
        private string dataEntradaServico;
        private string cliente;

        public string Identificador
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

        public string DataEntradaServico
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

        public string Cliente
        {
            get
            {
                return cliente;
            }

            set
            {
                cliente = value;
            }
        }

        public string Save(string Identificador, string Referencia, string Situacao, string Defeito, string Descricao, string Obervacao, string NumeroSerie, string Equipamento, string DataEntradaServico, string Cliente)
        {
            OrdemServico OSBase = new OrdemServico();
            string Saida = null;

            OSBase.Identificador = Identificador;
            OSBase.Equipamento = Equipamento;
            OSBase.Situacao = Situacao;
            OSBase.NumeroSerie = NumeroSerie;
            OSBase.Defeito = Defeito;
            OSBase.Referencia = Referencia;
            OSBase.DataEntradaServico = DataEntradaServico;
            OSBase.Observacao = Obervacao;
            OSBase.Descricao = Descricao;
            OSBase.Cliente = Cliente;

            StreamWriter sw = null;


            if (Verificar(OSBase.identificador) == false)
            {
                try
                {
                    sw = new StreamWriter(String.Format("OS/{0}.os", Identificador));

                    sw.WriteLine(OSBase.Identificador);
                    sw.WriteLine(OSBase.Cliente);
                    sw.WriteLine(OSBase.Equipamento);
                    sw.WriteLine(OSBase.Situacao);
                    sw.WriteLine(OSBase.NumeroSerie);
                    sw.WriteLine(OSBase.Defeito);
                    sw.WriteLine(OSBase.Referencia);
                    sw.WriteLine(OSBase.DataEntradaServico);
                    sw.WriteLine(OSBase.Observacao);
                    sw.WriteLine(OSBase.Descricao);
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
                //Chamara a função de salvar novamente se for verificado que o numero "sorteado já existe na base de dados."
                Save(OSBase.Identificador, OSBase.Referencia, OSBase.Situacao, OSBase.Defeito, OSBase.Descricao, OSBase.Observacao, OSBase.NumeroSerie, OSBase.Equipamento, OSBase.DataEntradaServico,OSBase.Cliente);
            }


            return Saida;

        }

        public string Edit(string Identificador, string Referencia, string Situacao, string Defeito, string Descricao, string Obervacao, string NumeroSerie, string Equipamento, string DataEntradaServico, string Cliente)
        {
            OrdemServico OSBase = new OrdemServico();
            string Saida = null;

            OSBase.Identificador = Identificador;
            OSBase.Equipamento = Equipamento;
            OSBase.Situacao = Situacao;
            OSBase.NumeroSerie = NumeroSerie;
            OSBase.Defeito = Defeito;
            OSBase.Referencia = Referencia;
            OSBase.DataEntradaServico = DataEntradaServico;
            OSBase.Observacao = Obervacao;
            OSBase.Descricao = Descricao;
            OSBase.Cliente = Cliente;


            StreamWriter sw = null;


            if (Verificar(OSBase.identificador) == true)
            {
                try
                {
                    sw = new StreamWriter(String.Format("OS/{0}.os", Identificador));

                    sw.WriteLine(OSBase.Identificador);
                    sw.WriteLine(OSBase.cliente);
                    sw.WriteLine(OSBase.Equipamento);
                    sw.WriteLine(OSBase.Situacao);
                    sw.WriteLine(OSBase.NumeroSerie);
                    sw.WriteLine(OSBase.Defeito);
                    sw.WriteLine(OSBase.Referencia);
                    sw.WriteLine(OSBase.DataEntradaServico);
                    sw.WriteLine(OSBase.Observacao);
                    sw.WriteLine(OSBase.Descricao);
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

                        Saida = "Ordem de Serviço editada com sucesso!";
                    }

                }
            }
            else
            {
                Saida = "Numero de ordem de sefviço inválido!";
            }


            return Saida;

        }

        public OrdemServico Load(string _Identificador)
        {
            OrdemServico OSBase = new OrdemServico();
            StreamReader sr = null;

            try
            {
                sr = new StreamReader(String.Format("OS/{0}.os", _Identificador));

                OSBase.Identificador = sr.ReadLine();
                OSBase.cliente = sr.ReadLine();
                OSBase.Equipamento = sr.ReadLine();
                OSBase.Situacao = sr.ReadLine();
                OSBase.NumeroSerie = sr.ReadLine();
                OSBase.Defeito = sr.ReadLine();
                OSBase.Referencia = sr.ReadLine();
                OSBase.DataEntradaServico = sr.ReadLine();
                OSBase.Observacao = sr.ReadLine();
                OSBase.Descricao = sr.ReadLine();
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

            return OSBase;
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

        public bool Verificar(string _Identificador)
        {
            //Verifica de o já há uma "Ordem de Serviço"(arquivo com o nome), no diretorio das pessoas físicas e retorna um valor booleano .

            bool Encontrado = false;

            if (File.Exists((string.Format("OS/{0}.os", _Identificador))))
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
