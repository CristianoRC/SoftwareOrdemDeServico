using Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.Pessoas
{
    public partial class Frm_ExcluirClientes : Form
    {
        public Frm_ExcluirClientes()
        {
            InitializeComponent();
        }

        private void Frm_ExcluirClientes_Load(object sender, EventArgs e)
        {
            AtualziarLsitaDeClientes();
        }
        private void AtualziarLsitaDeClientes()
        {
            Txt_Pessoa.Items.Clear();

            System.Data.DataTable tabela = new System.Data.DataTable();

            tabela = ControllerPessoa.CarregarListaDeNomes();
            if (tabela.Rows.Count  != 0)
            {
                foreach (System.Data.DataRow r in tabela.Rows)
                {
                    foreach (System.Data.DataColumn c in tabela.Columns)
                    {
                        Txt_Pessoa.Items.Add(r[c].ToString());
                    }
                }

                Txt_Pessoa.Text = Txt_Pessoa.Items[0].ToString();
            }
        }

        private void Btm_Deletar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você deseja mesmo excluir o cliente?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                String saida = ControllerPessoa.Deletar(Txt_Pessoa.Text);

                MessageBox.Show(saida, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
 
                AtualziarLsitaDeClientes();
            }
        }
    }
}
