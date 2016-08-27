using System;
using System.Windows.Forms;
using Controller;

namespace View.OS
{
    public partial class Frm_ExcluirOS : Form
    {
        public Frm_ExcluirOS()
        {
            InitializeComponent();
        }

        private void Btm_Excluir_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Você realmente deseja excluir?", "Excluir?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//Verifica se a pessoa quer realmente excluir a Ormde de serviço.
            {
                string saida = ControllerOrdemServico.Deletar(Convert.ToInt16(Txt_Os.Text));

                MessageBox.Show(saida, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Frm_ExcluirOS_Load(object sender, EventArgs e)
        {
            Txt_Os.DataSource = ControllerOrdemServico.CarregarListaDeIds();
        }
    }
}
