using System;
using Model.Ordem_de_Servico;
using System.Windows.Forms;
using Controller;

namespace View.OS
{
    public partial class Frm_ListarOS : Form
    {
        public Frm_ListarOS()
        {
            InitializeComponent();
        }

        private void Frm_ListarOS_Load(object sender, EventArgs e)
        {
            OrdemServico OSBase = new OrdemServico();
            ControllerOrdemServico controllerOS = new ControllerOrdemServico();

            foreach (var item in controllerOS.LoadList())
            {
                if (!string.IsNullOrWhiteSpace(controllerOS.Load(item).Identificador))
                {
                    OSBase = controllerOS.Load(item);

                    Data_Os.Rows.Add(OSBase.Identificador, OSBase.Defeito, OSBase.Equipamento, OSBase.Situacao, OSBase.Cliente, OSBase.DataEntradaServico);

                }
            }
        }
    }
}
