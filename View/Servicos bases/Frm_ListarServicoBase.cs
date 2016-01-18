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

            foreach (var itemOS in ControllerServicoBase.LoadList()) //Carregando informações da Os
            {
                ListaDeInformacoes.Add(ControllerServicoBase.Load(itemOS).Nome);
                ListaDeInformacoes.Add(ControllerServicoBase.Load(itemOS).Valor.ToString());
                ListaDeInformacoes.Add(ControllerServicoBase.Load(itemOS).Observacoes);

                if (!string.IsNullOrWhiteSpace(ControllerServicoBase.Load(itemOS).Nome))
                {
                    Data_Os.Rows.Add(ListaDeInformacoes[0], ListaDeInformacoes[1], ListaDeInformacoes[2]);

                    ListaDeInformacoes.Clear();
                }
            }
        }
    }
}
