using System;
using Model.Ordem_de_Servico;
using System.Windows.Forms;

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

            foreach (var item in OSBase.LoadList())
            {
                Data_Os.Rows.Add(OSBase.Load(item).Identificador, OSBase.Load(item).Equipamento, OSBase.Load(item).Situacao, OSBase.Load(item).Cliente, OSBase.Load(item).DataEntradaServico);
            }
        }
    }
}
