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
    public partial class Frm_EditarProduto : Form
    {
        public Frm_EditarProduto()
        {
            InitializeComponent();
        }

        private void Btm_Pesquisar_Click(object sender, EventArgs e)
        {
            Model.Produtos.Produto ProdutoBase = new Model.Produtos.Produto();

            bool Resultado = ProdutoBase.Verificar(Txt_Pesquisa.Text);

            if (Resultado)
            {
                ProdutoBase = ProdutoBase.Load(Txt_Pesquisa.Text);

                Txt_Atacado.Text = ProdutoBase.PrecoVendaAtacado;
                Txt_Codigo.Text = ProdutoBase.CodigoBarra;
                Txt_Descricao.Text = ProdutoBase.Descricao;
                Txt_Marca.Text = ProdutoBase.MarcaProduto;
                Txt_Nome.Text = ProdutoBase.Nome;
                Txt_Preco.Text = ProdutoBase.PrecoCusto;
                Txt_Referencia.Text = ProdutoBase.Referencia;
                Txt_Venda.Text = ProdutoBase.PrecoVenda;
            }
            else
            {
                MessageBox.Show("Produto não encontrado!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Model.Produtos.Produto ProdutoBase = new Model.Produtos.Produto();

            ProdutoBase.CodigoBarra = Txt_Codigo.Text;
            ProdutoBase.Descricao = Txt_Descricao.Text;
            ProdutoBase.MarcaProduto = Txt_Marca.Text;
            ProdutoBase.Nome = Txt_Nome.Text;
            ProdutoBase.PrecoCusto = Txt_Preco.Text;
            ProdutoBase.PrecoVenda = Txt_Venda.Text;
            ProdutoBase.PrecoVendaAtacado = Txt_Atacado.Text;
            ProdutoBase.Referencia = Txt_Referencia.Text;

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
    }
}
