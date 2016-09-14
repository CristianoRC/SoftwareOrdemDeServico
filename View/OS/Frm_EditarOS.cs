using System;
using Controller;
using System.Windows.Forms;
using Model.Ordem_de_Servico;

namespace View.OS
{
    public partial class Frm_EditarOS : Form
    {
        /// <summary>
        /// Utilizado quando o é chamado pelo formulário de listagem de OS para edicao.
        /// </summary>
        /// <param name="idTecnico"></param>
        /// <param name="IDOs"></param>
        public Frm_EditarOS(int idTecnico, int IDOs)
        {
            IDTecnico = idTecnico;
            IDChamado = IDOs;
            CarregarLista = true;
            
            InitializeComponent();
        }
        
        public Frm_EditarOS(int idTecnico)
        {
            IDTecnico = idTecnico;

            InitializeComponent();
        }

        private int IDTecnico;
        private int IDChamado;
        private bool CarregarLista; //Pega a informação se o formulário foi aberto do form ListaOS

        private void Frm_EditarOS_Load(object sender, EventArgs e)
        {
            System.Data.DataTable Tabela = new System.Data.DataTable();

            Tabela = ControllerPessoa.CarregarListaDeNomes();

            if (Tabela.Rows.Count != 0)
            {
                foreach (System.Data.DataRow r in Tabela.Rows)
                {
                    foreach (System.Data.DataColumn c in Tabela.Columns)
                    {
                        Txt_Cliente.Items.Add(r[c].ToString());
                    }
                }
            }

            System.Data.DataTable TabelaOS = new System.Data.DataTable();

            TabelaOS = ControllerOrdemServico.CarregarListaDeIds();
            if (TabelaOS.Rows.Count != 0)
            {
                foreach (System.Data.DataRow r in TabelaOS.Rows)
                {
                    foreach (System.Data.DataColumn c in TabelaOS.Columns)
                    {
                        Txt_IDPesquisa.Items.Add(r[c].ToString());
                    }
                }
            }
            
            if (CarregarLista)
            {
                //Carregando as informações passadas pelo form de listagem de OS.
                CarregarInformacoes(IDChamado);

                CarregarLista = false;
            }
        }

        private void Btm_Pesquisa_Click(object sender, EventArgs e)
        {
            //Verificado se a ordem de serviço que foi procurada existe e se existir retornar a Ordem de serviço base.
            if (!String.IsNullOrEmpty(Txt_IDPesquisa.Text))
            {
                CarregarInformacoes(Convert.ToInt32(Txt_IDPesquisa.Text));
            }
            else
            {
                MessageBox.Show("Escolha uma ordem de serviço!", "Informações", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string Retorno = ControllerOrdemServico.Editar(PreencherOS());

            MessageBox.Show(String.Format("{0}", Retorno), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (MessageBox.Show("Deseja imprimir o arquivo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ControllerOrdemServico.CreatPDF(PreencherOS());
            }


            Txt_DataEntrada.Clear();
            Txt_Defeito.Clear();
            Txt_Descricao.Clear();
            Txt_Equipamento.Clear();
            Txt_Nserie.Clear();
            Txt_Observacoes.Clear();
        }

        private void CarregarInformacoes(int id)
        {
            OrdemServico OrdemDeServico = new OrdemServico();
            OrdemDeServico = ControllerOrdemServico.Carregar(id);

            IDChamado = OrdemDeServico.ID;
            Txt_Situacao.Text = OrdemDeServico.Situacao;
            Txt_Defeito.Text = OrdemDeServico.Defeito;
            Txt_Descricao.Text = OrdemDeServico.Descricao;
            Txt_Observacoes.Text = OrdemDeServico.Observacao;
            Txt_Nserie.Text = OrdemDeServico.NumeroSerie;
            Txt_Equipamento.Text = OrdemDeServico.Equipamento;
            Txt_DataEntrada.Text = OrdemDeServico.dataEntradaServico;
            Txt_Descricao.Text = OrdemDeServico.Descricao;
            Txt_Cliente.Text = ControllerPessoa.VerificarNome(OrdemDeServico.IDCliente);

            //Caso o estatus da OS for finalizado, não é possível mudar.
            if (OrdemDeServico.Situacao == "Finalizado")
            {
                Txt_Situacao.Enabled = false;
            }
            else
            {
                Txt_Situacao.Enabled = true;
            }
        }

        /// <summary>
        /// Carregando as informações dos TxtBox para a Classe Cliente.
        /// </summary>
        /// <returns></returns>
        private OrdemServico PreencherOS()
        {
            OrdemServico OSBase = new OrdemServico();
            OSBase.ID = IDChamado;
            OSBase.dataEntradaServico = Txt_DataEntrada.Text;
            OSBase.Defeito = Txt_Defeito.Text;
            OSBase.Descricao = Txt_Descricao.Text;
            OSBase.Equipamento = Txt_Equipamento.Text;
            OSBase.IDCliente = ControllerPessoa.VerificarID(Txt_Cliente.Text);
            OSBase.IDTecnico = IDTecnico;
            OSBase.NumeroSerie = Txt_Nserie.Text;
            OSBase.Observacao = Txt_Observacoes.Text;
            OSBase.Situacao = Txt_Situacao.Text;
            return OSBase;
        }
    }
}