using System;
using System.Windows.Forms;
using System.Data;
using Controller;

namespace View
{
    public partial class Frm_ImprimirOS : Form
    {
        public Frm_ImprimirOS()
        {
            InitializeComponent();
        }

        private void Btm_Imprimir_Click(object sender, EventArgs e)
        {

        }

        private void Frm_ImprimirOS_Load(object sender, EventArgs e)
        {
            CarregarListaDeIds();
        }

        private void CarregarListaDeIds()
        {
            Txt_Ids.Items.Clear();

            DataTable tabela = new DataTable("InformacoesIDs");
            tabela = ControllerOrdemServico.CarregarListaDeIds();

            foreach (DataRow r in tabela.Rows)
            {
                foreach (DataColumn c in tabela.Columns)
                {
                    Txt_Ids.Items.Add(r[c].ToString());
                }
            }
        }
    }
}
