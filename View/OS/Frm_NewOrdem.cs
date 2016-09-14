using System;
using Model;
using Controller;
using System.Windows.Forms;
using System.Collections.Generic;
using Model.Pessoa_e_Usuario;
using Model.Ordem_de_Servico;

namespace View.OS
{
    public partial class Frm_NewOrdem : Form
    {
        public Frm_NewOrdem(int idTecnico)
        {
            InitializeComponent();

            IDTecnico = idTecnico;
        }

        private int IDTecnico;

        private void Frm_NewOrdem_Load(object sender, EventArgs e)
        {
            Txt_DataEntrada.Text = DateTime.Now.ToString("dd/MM/yy");

            Txt_Clientes.Items.Clear();


            //Preenchendo o ComboBox com o nome de Clientes
            System.Data.DataTable Tabela = new System.Data.DataTable();

            Tabela = ControllerPessoa.CarregarListaDeNomes();

            if (Tabela.Rows.Count != 0)
            {
                foreach (System.Data.DataRow r in Tabela.Rows)
                {
                    foreach (System.Data.DataColumn c in Tabela.Columns)
                    {
                        Txt_Clientes.Items.Add(r[c].ToString());
                    }
                }
            }

            //Colocando o primeiro da lista no combobox para não ficar vazio.
            if (Txt_Clientes.Items.Count != 0)
            {
                Txt_Clientes.Text = Txt_Clientes.Items[0].ToString();
            }

            Txt_Situacao.Text = Txt_Situacao.Items[0].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Txt_Clientes.Text))
            {
                string Retorno = ControllerOrdemServico.Salvar(PreencherOS());

                MessageBox.Show(String.Format("{0}", Retorno), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (MessageBox.Show("Deseja imprimir  a ordem de serviço?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ControllerOrdemServico.CreatPDF(PreencherOS());
                }

                if (MessageBox.Show("Deseja enviar a ordem de serviço para o cliente?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //  Email EmailBase = new Email();


                    //TODO:Arrumar o código logo após a manutenção do sistema de e-mail
                    //string ResultadoEnvio = ControllerEmail.EnviarOrdemDeServiço(CarregarCliente());

                    //Corrigir bugs acima, ira se arrumar logo após da implementação do sistema de escrever e-mail só para "anexo";

                    // MessageBox.Show(ResultadoEnvio, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Txt_DataEntrada.Clear();
                Txt_Defeito.Clear();
                Txt_Descricao.Clear();
                Txt_Equipamento.Clear();
                Txt_Nserie.Clear();
                Txt_Observacoes.Clear();
            }
            else
            {
                MessageBox.Show("Selecione um cliente!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        /// <summary>
        /// Carregando as informações dos TxtBox para a Classe Cliente.
        /// </summary>
        /// <returns></returns>
        private OrdemServico PreencherOS()
        {
            OrdemServico OSBase = new OrdemServico();

            OSBase.dataEntradaServico = Txt_DataEntrada.Text;
            OSBase.Defeito = Txt_Defeito.Text;
            OSBase.Descricao = Txt_Descricao.Text;
            OSBase.Equipamento = Txt_Equipamento.Text;
            OSBase.IDCliente = ControllerPessoa.VerificarID(Txt_Clientes.Text);
            OSBase.IDTecnico = IDTecnico;
            OSBase.NumeroSerie = Txt_Nserie.Text;
            OSBase.Observacao = Txt_Observacoes.Text;
            OSBase.Situacao = Txt_Situacao.Text;
            return OSBase;
        }
    }
}
