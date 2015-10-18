using System;
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
        private string precoCusto;
        private string precoVenda;
        private string precoVendaAtacado;

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

        public string PrecoCusto
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

        public string PrecoVenda
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

        public string PrecoVendaAtacado
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


        public string Save(string _Nome, string _CodigoBarra, string _Referencia, string _Descricao, string _Marcaproduto, string _PrecoCusto, string _PrecoVenda, string _PrecoVendaAtacado)
        {
            Produto ProdutoBase = new Produto();
            StreamWriter sw = null;
            string Saida = null;


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
                sw = new StreamWriter(string.Format("Produtos/{0}.txt", ProdutoBase.CodigoBarra));

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

                    Saida = "Produto registrado com sucesso!";
                }
            }

            return Saida;
        }

        public Produto Load(string _Codigo)
        {
            Produto ProdutoBase = new Produto();
            StreamReader sr = null;

            try
            {
                sr = new StreamReader(String.Format("Produtos/{0}.txt", _Codigo));

                ProdutoBase.Nome = sr.ReadLine();
                ProdutoBase.CodigoBarra = sr.ReadLine();
                ProdutoBase.Referencia = sr.ReadLine();
                ProdutoBase.Descricao = sr.ReadLine();
                ProdutoBase.MarcaProduto = sr.ReadLine();
                ProdutoBase.PrecoCusto = sr.ReadLine();
                ProdutoBase.PrecoVenda = sr.ReadLine(); ;
                ProdutoBase.PrecoVendaAtacado = sr.ReadLine();

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

            return ProdutoBase;
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

            bool Encontrado;

            if (File.Exists(string.Format("Produtos/{0}.txt", _CodigoBarra)))
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
