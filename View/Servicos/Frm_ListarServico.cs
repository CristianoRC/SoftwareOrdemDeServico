using System;
using System.Collections.Generic;
using System.Windows.Forms;

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

            Model.Ordem_de_Servico.Servico ServicoBase = new Model.Ordem_de_Servico.Servico();
            Model.Ordem_de_Servico.OrdemServico OSBase = new Model.Ordem_de_Servico.OrdemServico();
            List<String> ListaDeInformações = new List<string>();
            bool TemInformacao = false; //Verifica se achou algo.

            foreach (var itemOS in OSBase.LoadListFinalizadas()) //Carregando informações da Os
            {
                ListaDeInformações.Add(OSBase.LoadOSFinalizada(itemOS).Identificador);
                ListaDeInformações.Add(OSBase.LoadOSFinalizada(itemOS).Cliente);

                if (!string.IsNullOrWhiteSpace(OSBase.LoadOSFinalizada(itemOS).Identificador))
                {
                    TemInformacao = true;
                }

                foreach (var item in ServicoBase.LoadList()) //Carregando informações do serviço
                {
                    ListaDeInformações.Add(ServicoBase.Load(item).Descricao);
                    ListaDeInformações.Add(ServicoBase.Load(item).Valor.ToString());
                }

                if (TemInformacao)
                {
                    Data_Os.Rows.Add(ListaDeInformações[0], ListaDeInformações[1], ListaDeInformações[2], ListaDeInformações[3]);
                }
            }
        }
    }
}
