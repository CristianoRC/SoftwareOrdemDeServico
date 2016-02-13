using System;
using System.Windows.Forms;
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
            Model.Ordem_de_Servico.OrdemServico OSBase = new Model.Ordem_de_Servico.OrdemServico();

            //checkBox1.Checked = Verifica se a ordem já foi finalizada, se for = true é que já foi finalizada  se for = false não.
            if (checkBox1.Checked == false)
            {
                //Verificado se a ordem de serviço que foi procurada existe e se existir retornar a Ordem de serviço base.
                if (ControllerOrdemServico.Verificar(Txt_Pesquisa.Text) == true)
                {
                    OSBase = ControllerOrdemServico.Load(Txt_Pesquisa.Text);
                    ControllerOrdemServico.CreatPDF(OSBase.Identificador, OSBase.Referencia, OSBase.Situacao, OSBase.Defeito, OSBase.Descricao, OSBase.Observacao, OSBase.NumeroSerie, OSBase.Equipamento, OSBase.DataEntradaServico, OSBase.Cliente);
                }
                else
                {
                    MessageBox.Show("Numero da ordem de serviço não encontrado em nossa base de dados!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                //Verificado se a ordem de serviço que foi procurada existe e se existir retornar a Ordem de serviço base.
                if (ControllerOrdemServico.VerificarFinalizada(Txt_Pesquisa.Text) == true)
                {
                    OSBase = ControllerOrdemServico.LoadOSFinalizada(Txt_Pesquisa.Text);
                    ControllerOrdemServico.CreatPDF(OSBase.Identificador, OSBase.Referencia, OSBase.Situacao, OSBase.Defeito, OSBase.Descricao, OSBase.Observacao, OSBase.NumeroSerie, OSBase.Equipamento, OSBase.DataEntradaServico, OSBase.Cliente);
                }
                else
                {
                    MessageBox.Show("Numero da ordem de serviço não encontrado em nossa base de dados!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}