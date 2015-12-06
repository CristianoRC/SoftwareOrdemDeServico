using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using Controller;

namespace View.Servicos
{
    public partial class Frm_ListarOrcamento : Form
    {
        public Frm_ListarOrcamento()
        {
            InitializeComponent();
        }

        private void Frm_ListarOrcamento_Load(object sender, EventArgs e)
        {
            Orcamento OrcamentoBase = new Orcamento();
            ControllerOrcamento controllerOrcamento = new ControllerOrcamento();

            foreach (var item in controllerOrcamento.LoadList())
            {
                OrcamentoBase = controllerOrcamento.Load(item);

                if (!string.IsNullOrWhiteSpace(OrcamentoBase.Identificador))
                {
                    OrcamentoBase = controllerOrcamento.Load(item);

                    Data_Os.Rows.Add(OrcamentoBase.Identificador, OrcamentoBase.Equipamento, OrcamentoBase.Valor, OrcamentoBase.Cliente, OrcamentoBase.Observacoes);
                }
            }
        }
    }
}