using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Controller;

namespace View
{
    public partial class Frm_ListarServico : Form
    {
        public Frm_ListarServico()
        {
            InitializeComponent();
        }

        private void Frm_ListarServico_Load(object sender, EventArgs e)
        {
            ControllerOrdemServico controllerOS = new ControllerOrdemServico();
            ControllerServico controllerServico = new ControllerServico();

            List<String> ListaDeInformações = new List<string>();
            bool TemInformacao = false; //Verifica se achou algo.

            foreach (var itemOS in controllerOS.LoadListFinalizadas()) //Carregando informações da Os
            {
                ListaDeInformações.Add(controllerOS.LoadOSFinalizada(itemOS).Identificador);
                ListaDeInformações.Add(controllerOS.LoadOSFinalizada(itemOS).Cliente);

                if (!string.IsNullOrWhiteSpace(controllerOS.LoadOSFinalizada(itemOS).Identificador))
                {
                    TemInformacao = true;
                }

                foreach (var item in controllerServico.LoadList()) //Carregando informações do serviço
                {
                    ListaDeInformações.Add(controllerServico.Load(item).Descricao);
                    ListaDeInformações.Add(controllerServico.Load(item).Valor.ToString());
                }

                if (TemInformacao)
                {
                    Data_Os.Rows.Add(ListaDeInformações[0], ListaDeInformações[1], ListaDeInformações[2], ListaDeInformações[3]);
                }
            }
        }
    }
}
