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
            List<String> ListaDeInformacoes = new List<string>();
            bool TemInformacao = false; //Verifica se achou algo.

            foreach (var itemOS in ControllerOrdemServico.LoadListFinalizadas()) //Carregando informações da Os
            {
                ListaDeInformacoes.Add(ControllerOrdemServico.LoadOSFinalizada(itemOS).Identificador);
                ListaDeInformacoes.Add(ControllerOrdemServico.LoadOSFinalizada(itemOS).Cliente);

                if (!string.IsNullOrWhiteSpace(ControllerOrdemServico.LoadOSFinalizada(itemOS).Identificador))
                {
                    TemInformacao = true;
                }

                foreach (var item in ControllerServico.LoadList()) //Carregando informações do serviço
                {
                    ListaDeInformacoes.Add(ControllerServico.Load(item).Descricao);
                    ListaDeInformacoes.Add(ControllerServico.Load(item).Valor.ToString());
                    ListaDeInformacoes.Add(ControllerServico.Load(item).Tecnico);
                }

                if (TemInformacao)
                {
                    Data_Os.Rows.Add(ListaDeInformacoes[0], ListaDeInformacoes[1], ListaDeInformacoes[2], ListaDeInformacoes[3], ListaDeInformacoes[4]);
                }
            }
        }
    }
}
