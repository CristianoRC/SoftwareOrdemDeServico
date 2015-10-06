using System.IO;
using System.Collections.Generic;

namespace Model.Produtos
{
    public class Produto
    {
        private string nome;
        private string codigoBarra;
        private string referencia;
        private string descricao;
        private string marcaProduto;
        private double precoCusto;
        private double precoVenda;
        private double precoVendaAtacado;

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public string CodigoBarra
        {
            get
            {
                return codigoBarra;
            }

            set
            {
                codigoBarra = value;
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

        public double PrecoCusto
        {
            get
            {
                return precoCusto;
            }

            set
            {
                precoCusto = value;
            }
        }

        public double PrecoVenda
        {
            get
            {
                return precoVenda;
            }

            set
            {
                precoVenda = value;
            }
        }

        public double PrecoVendaAtacado
        {
            get
            {
                return precoVendaAtacado;
            }

            set
            {
                precoVendaAtacado = value;
            }
        }

        public string MarcaProduto
        {
            get
            {
                return marcaProduto;
            }

            set
            {
                marcaProduto = value;
            }
        }


        public string Save(string _Nome, string _CodigoBarra, string _Referencia, string _Descricao, string _Marcaproduto, double _PrecoCusto, double _PrecoVenda, double _PrecoVendaAtacado)
        {
            Produto ProdutoBase = new Produto();
            StreamWriter sw = null;
            string Saida = null;


            if (Verificar(_CodigoBarra) == false)
            {

                ProdutoBase.Nome = _Nome;
                ProdutoBase.CodigoBarra = _CodigoBarra;
                ProdutoBase.Referencia = _Referencia;
                ProdutoBase.Descricao = _Descricao;
                ProdutoBase.MarcaProduto = _Marcaproduto;
                ProdutoBase.PrecoCusto = _PrecoCusto;
                ProdutoBase.PrecoVenda = _PrecoVenda;
                ProdutoBase.PrecoVendaAtacado = _PrecoVendaAtacado;

                try
                {
                    sw = new StreamWriter(string.Format("Produtos/{0}.csv", ProdutoBase.CodigoBarra));

                    sw.WriteLine(ProdutoBase.Nome);
                    sw.WriteLine(ProdutoBase.CodigoBarra);
                    sw.WriteLine(ProdutoBase.Referencia);
                    sw.WriteLine(ProdutoBase.Descricao);
                    sw.WriteLine(ProdutoBase.MarcaProduto);
                    sw.WriteLine(ProdutoBase.PrecoCusto);
                    sw.WriteLine(ProdutoBase.PrecoVenda);
                    sw.WriteLine(ProdutoBase.PrecoVendaAtacado);

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

                        Saida = "Pessoa Física registrada com sucesso!";
                    }
                }
            }
            else
            {
                Saida = "Eesse código de barras já foi cadastrado em nossa base de dados";
            }

            return Saida;
        }

        public List<string> LoadList()
        {
            List<string> ListaDeProdutos = new List<string>();
            DirectoryInfo NomesArquivos = new DirectoryInfo("Produtos/");
            string[] NovoItem = new string[2];


            //Ira pegar todas os nomes dos arquivos do diretorio ira separar um por um e um array separado por '.' e lgo apos salvar o nome do arquivo sem o seu formato.

            foreach (var item in NomesArquivos.GetFiles())
            {
                NovoItem = item.ToString().Split('.');

                ListaDeProdutos.Add(NovoItem[0]);
            }

            return ListaDeProdutos;
        }

        public bool Verificar(string _CodigoBarra)
        {
            //Verifica de o já há um "produto"(arquivo com o nome), no diretorio das pessoas físicas e retorna um valor booleano .

            bool Encontrado = false;
            DirectoryInfo Arquivo = new DirectoryInfo(string.Format("Produtos/{0}.csv", _CodigoBarra.TrimStart().TrimEnd()));

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
