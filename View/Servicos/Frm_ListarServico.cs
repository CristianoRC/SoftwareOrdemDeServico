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

            List<String> ListaDeInformacoes = new List<string>();
            bool TemInformacao = false; //Verifica se achou algo.

            foreach (var itemOS in controllerOS.LoadListFinalizadas()) //Carregando informações da Os
            {
                ListaDeInformacoes.Add(controllerOS.LoadOSFinalizada(itemOS).Identificador);
                ListaDeInformacoes.Add(controllerOS.LoadOSFinalizada(itemOS).Cliente);

                if (!string.IsNullOrWhiteSpace(controllerOS.LoadOSFinalizada(itemOS).Identificador))
                {
                    TemInformacao = true;
                }

                foreach (var item in controllerServico.LoadList()) //Carregando informações do serviço
                {
                    ListaDeInformacoes.Add(controllerServico.Load(item).Descricao);
                    ListaDeInformacoes.Add(controllerServico.Load(item).Valor.ToString());
                    ListaDeInformacoes.Add(controllerServico.Load(item).Tecnico);
                }

                if (TemInformacao)
                {
                    Data_Os.Rows.Add(ListaDeInformacoes[0], ListaDeInformacoes[1], ListaDeInformacoes[2], ListaDeInformacoes[3], ListaDeInformacoes[4]);
                }
            }
        }
    }
}
