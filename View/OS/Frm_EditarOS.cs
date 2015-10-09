using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace View.OS
{
    public partial class Frm_EditarOS : Form
    {
        public Frm_EditarOS()
        {
            InitializeComponent();
        }

        private void Frm_EditarOS_Load(object sender, EventArgs e)
        {

        }

        private void Btm_Pesquisa_Click(object sender, EventArgs e)
        {
            Model.Ordem_de_Servico.OrdemServico OrdemDeServico = new Model.Ordem_de_Servico.OrdemServico();
           
            //Verificado se a ordem de serviço que foi procurada existe e se existir retornar a Ordem de serviço base.
            if (OrdemDeServico.Verificar(Txt_Pesquisa.Text) == true)
            {
                OrdemDeServico = OrdemDeServico.Load(Txt_Pesquisa.Text);

                Txt_Nordem.Text = OrdemDeServico.Identificador;
                Txt_Referencia.Text = OrdemDeServico.Referencia;
                Txt_Situacao.Text = OrdemDeServico.Situacao;
                Txt_Defeito.Text = OrdemDeServico.Defeito;
                Txt_Descricao.Text = OrdemDeServico.Descricao;
                Txt_Observacoes.Text = OrdemDeServico.Observacao;
                Txt_Nserie.Text = OrdemDeServico.NumeroSerie;
                Txt_Equipamento.Text = OrdemDeServico.Equipamento;
                Txt_DataEntrada.Text = OrdemDeServico.DataEntradaServico;
                Txt_Descricao.Text = OrdemDeServico.Descricao;
                Txt_Cliente.Text = OrdemDeServico.Cliente;

            }
            else
            {
                MessageBox.Show("Ordem de serviço não encontrada!","Informações",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Model.Ordem_de_Servico.OrdemServico OrdemDeServico = new Model.Ordem_de_Servico.OrdemServico();

            string Retorno = OrdemDeServico.Edit(Txt_Nordem.Text, Txt_Referencia.Text, Txt_Situacao.Text, Txt_Defeito.Text, Txt_Descricao.Text, Txt_Observacoes.Text, Txt_Nserie.Text, Txt_Equipamento.Text, Txt_DataEntrada.Text,Txt_Cliente.Text);

            MessageBox.Show(String.Format("{0}", Retorno), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}