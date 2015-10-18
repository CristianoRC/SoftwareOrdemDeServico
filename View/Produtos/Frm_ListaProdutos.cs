using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class Frm_ListaProdutos : Form
    {
        public Frm_ListaProdutos()
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
