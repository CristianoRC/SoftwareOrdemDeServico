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
    public partial class Frm_NovoProduto : Form
    {
        public Frm_NovoProduto()
        {
            InitializeComponent();
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO implementar no sistema de backup!

            Model.Produtos.Produto ProdutoBase = new Model.Produtos.Produto();

            ProdutoBase.CodigoBarra = Txt_Codigo.Text;
            ProdutoBase.Descricao = Txt_Descricao.Text;
            ProdutoBase.MarcaProduto = Txt_Marca.Text;
            ProdutoBase.Nome = Txt_Nome.Text;
            ProdutoBase.PrecoCusto = Txt_Preco.Text;
            ProdutoBase.PrecoVenda = Txt_Venda.Text;
            ProdutoBase.PrecoVendaAtacado = Txt_Atacado.Text;
            ProdutoBase.Referencia = Txt_Referencia.Text;

            //Se o produto não for achado ele ira salvar.
            if (!ProdutoBase.Verificar(ProdutoBase.CodigoBarra))
            {
                string Resultado = ProdutoBase.Save(ProdutoBase.Nome, ProdutoBase.CodigoBarra, ProdutoBase.Referencia, ProdutoBase.Descricao, ProdutoBase.MarcaProduto, ProdutoBase.PrecoCusto, ProdutoBase.PrecoVenda, ProdutoBase.PrecoVendaAtacado);
                MessageBox.Show(Resultado, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Txt_Atacado.Clear();
                Txt_Codigo.Clear();
                Txt_Descricao.Clear();
                Txt_Marca.Clear();
                Txt_Nome.Clear();
                Txt_Preco.Clear();
                Txt_Referencia.Clear();
                Txt_Venda.Clear();
            }
            else
            {
                MessageBox.Show("Código do produto já foi encontrado me nossa base de dados!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
