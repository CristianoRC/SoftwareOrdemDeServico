using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Controller;

namespace View
{
    public partial class Frm_ListarServicoBase : Form
    {
        public Frm_ListarServicoBase()
        {
            InitializeComponent();
        }

        private void Frm_ListarServicoBase_Load(object sender, EventArgs e)
        {
            List<String> ListaDeInformacoes = new List<string>();

            foreach (var item in ControllerServicoBase.LoadList()) //Carregando informações da Os
            {
                ListaDeInformacoes.Add(ControllerServicoBase.Load(item).Nome);
                ListaDeInformacoes.Add(ControllerServicoBase.Load(item).Valor.ToString());
                ListaDeInformacoes.Add(ControllerServicoBase.Load(item).Observacoes);

                if (!string.IsNullOrWhiteSpace(ControllerServicoBase.Load(item).Nome))
                {
                    Data_Os.Rows.Add(ListaDeInformacoes[0], ListaDeInformacoes[1], ListaDeInformacoes[2]);

                    ListaDeInformacoes.Clear();
                }
            }
        }
    }
}
