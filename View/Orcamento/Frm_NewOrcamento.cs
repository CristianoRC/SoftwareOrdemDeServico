using System;
using System.Windows.Forms;
using Controller;
using Model;
using Model.Ordem_de_Servico;
using Model.Pessoa_e_Usuario;

namespace View
{
    public partial class Frm_NewOrcamento : Form
    {
        public Frm_NewOrcamento()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Finalizando o orçamento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void finalizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ControllerOrdemServico.Verificar(Txt_NOrdem.Text)) //Verifica se a ordem de serviço existe ou não.
            {
                Orcamento OrcamentoBase = new Orcamento();

                OrcamentoBase.Identificador = Txt_NOrdem.Text;
                OrcamentoBase.Cliente = Txt_NomeCliente.Text;
                OrcamentoBase.Equipamento = RecuperarNomeEquipamento();
                OrcamentoBase.Observacoes = Txt_Observacoes.Text;
                OrcamentoBase.Valor = Txt_ValorFinal.Text;

                string Menssagem = ControllerOrcamento.Save(OrcamentoBase.Identificador, OrcamentoBase.Equipamento, OrcamentoBase.Cliente, OrcamentoBase.Valor, OrcamentoBase.Observacoes);

                MessageBox.Show(Menssagem, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Verifica se quer ou não enviar o e-mail para o cliente sobre as informações!

                if (Menssagem == "Orçamento finalziado com sucesso!")
                {
                    if (MessageBox.Show("Você deseja enviar um e-mail para o cliente com as informações?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string Resultado = ControllerEmail.EnviarOrcamento(Txt_NomeCliente.Text, InformacaoCliente()[1], NomeEmpresa(), OrcamentoBase.Equipamento, OrcamentoBase.Valor, OrcamentoBase.Observacoes);

                        MessageBox.Show(Resultado, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Ordem de serviço não foi encontrada!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Recuperando informações do cliente.
        /// </summary>
        /// <returns>Nome e E-mail do cliente</returns>
        private string[] InformacaoCliente()
        {
            OrdemServico OSBase = new OrdemServico();
            Fisica PessoaFisicaBase = new Fisica();
            Juridica PessoaJuridicaBase = new Juridica();

            string NomeDoCliente = "Não Econtrado";
            string EmailCliente = "Não encontrado";
            string[] Informacoes = new string[2];

            NomeDoCliente = Txt_NomeCliente.Text;


            //Verificando o tipo e o Email do usuario

            if (ControllerJuridica.Verificar(NomeDoCliente)) //Verifica se é Juridica
            {
                PessoaJuridicaBase = ControllerJuridica.Load(NomeDoCliente);
                EmailCliente = PessoaFisicaBase.Email;
                NomeDoCliente = PessoaFisicaBase.Nome;

                Informacoes[0] = NomeDoCliente;
                Informacoes[1] = EmailCliente;

            }
            else if (ControllerFisica.Verificar(NomeDoCliente)) //Verifica se é pessoa Física.
            {
                EmailCliente = ControllerFisica.Load(NomeDoCliente).Email;
                NomeDoCliente = ControllerFisica.Load(NomeDoCliente).Nome;

                Informacoes[0] = NomeDoCliente;
                Informacoes[1] = EmailCliente;
            }

            return Informacoes;
        }

        /// <summary>
        /// Recuperando informações da empresa
        /// </summary>
        /// <returns>Nome da empresa</returns>
        private string NomeEmpresa()
        {

            Empresa EmpresaBase = new Empresa();

            string NomeEmpresa = "Não encontrado";

            NomeEmpresa = ControllerEmpresa.Load().Nome;

            return NomeEmpresa;
        }

        /// <summary>
        /// Recuperando E-mail base;
        /// </summary>
        /// <returns>Texto do E-mail base ainda codificado.</returns>
        private string RecuperandoEmailBase()
        {
            Email Email = new Email();

            string TextoEmail = "Não encontrado";

            TextoEmail = ControllerEmail.LoadEmailBase();

            return TextoEmail;
        }

        /// <summary>
        /// Pegando o nome do equipamento para decodificar na menssagem do e-mail
        /// </summary>
        /// <returns></returns>
        private string RecuperarNomeEquipamento()
        {
            OrdemServico OSBase = new OrdemServico();

            string NomeEquipamento = "Não encontrado";

            OSBase = ControllerOrdemServico.Load(Txt_NOrdem.Text); //Carregando informações da ordem de serviço para a OSBase;
            NomeEquipamento = OSBase.Equipamento;

            return NomeEquipamento;
        }

        private void verificarNomeDoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Saida;

            if (ControllerOrdemServico.Verificar(Txt_NOrdem.Text))
            {
                Saida = ControllerOrdemServico.Load(Txt_NOrdem.Text).Cliente;
            }
            else
            {
                MessageBox.Show("Ocorreu um problema a ordem de serviço não foi encontrada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Saida = "Ordem de serviço não foi encontrada";
            }

            Txt_NomeCliente.Text = Saida;
        }
    }
}
