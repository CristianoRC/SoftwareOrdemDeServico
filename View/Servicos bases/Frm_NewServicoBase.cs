using System;
using System.Windows.Forms;
using Controller;

namespace View
{
    public partial class Frm_NewServicoBase : Form
    {
        public Frm_NewServicoBase()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gerando o arquivo com as informações do serviço base.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControllerServicoBase controllerServicoBase = new ControllerServicoBase();

            controllerServicoBase.Save(Txt_Nome.Text, Txt_Observacoes.Text, Double.Parse(Txt_Valor.Text));
        }
    }
}
