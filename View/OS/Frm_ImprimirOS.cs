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
            ControllerOrdemServico controllerOS = new ControllerOrdemServico();

            //checkBox1.Checked = Verifica se a ordem já foi finalizada, se for = true é que já foi finalizada  se for = false não.
            if (checkBox1.Checked == false)
            {
                //Verificado se a ordem de serviço que foi procurada existe e se existir retornar a Ordem de serviço base.
                if (controllerOS.Verificar(Txt_Pesquisa.Text) == true)
                {
                    OSBase = controllerOS.Load(Txt_Pesquisa.Text);
                    controllerOS.CreatPDF(OSBase.Identificador, OSBase.Referencia, OSBase.Situacao, OSBase.Defeito, OSBase.Descricao, OSBase.Observacao, OSBase.NumeroSerie, OSBase.Equipamento, OSBase.DataEntradaServico, OSBase.Cliente);
                }
                else
                {
                    MessageBox.Show("Numero da ordem de serviço não encontrado em nossa base de dados!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                //Verificado se a ordem de serviço que foi procurada existe e se existir retornar a Ordem de serviço base.
                if (controllerOS.VerificarFinalizada(Txt_Pesquisa.Text) == true)
                {
                    OSBase = controllerOS.LoadOSFinalizada(Txt_Pesquisa.Text);
                    controllerOS.CreatPDF(OSBase.Identificador, OSBase.Referencia, OSBase.Situacao, OSBase.Defeito, OSBase.Descricao, OSBase.Observacao, OSBase.NumeroSerie, OSBase.Equipamento, OSBase.DataEntradaServico, OSBase.Cliente);
                }
                else
                {
                    MessageBox.Show("Numero da ordem de serviço não encontrado em nossa base de dados!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}