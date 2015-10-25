using System;
using System.Windows.Forms;

namespace View
{
    public partial class Frm_ListarProdutos : Form
    {
        public Frm_ListarProdutos()
        {
            InitializeComponent();
        }

        private void Frm_ListaProdutos_Load(object sender, EventArgs e)
        {
            Model.Produtos.Produto ProdutoBase = new Model.Produtos.Produto();

            foreach (var item in ProdutoBase.LoadList())
            {
                Data_Os.Rows.Add(ProdutoBase.Load(item).CodigoBarra, ProdutoBase.Load(item).Nome, ProdutoBase.Load(item).MarcaProduto, ProdutoBase.Load(item).PrecoCusto, ProdutoBase.Load(item).PrecoVenda, ProdutoBase.Load(item).PrecoVendaAtacado);
            }
        }
    }
}
