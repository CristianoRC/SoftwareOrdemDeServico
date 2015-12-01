using System;
using System.Windows.Forms;
using Model.Ordem_de_Servico;
using Controller;
using Model.Pessoa_e_Usuario;
using Model;

namespace View
{
    public partial class Frm_Servico : Form
    {
        public Frm_Servico(string nomeDoTecnico)
        {
            InitializeComponent();

            //Passando o nome do tecnico para a variavel global para ser sado na horade salvar o serviço.
            NomeDoTecnico = nomeDoTecnico;
        }

        //Usada para salvar o nome do tecnico no serviço.
        public string NomeDoTecnico;

        /// <summary>
        /// Finalizando Ordem de serviço (Botão).
        /// </summary>
        private void finalizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Txt_OS.Text))
            {
                OrdemServico OSbase = new OrdemServico();
                Servico ServicoBase = new Servico();

                ControllerOrdemServico controllerOS = new ControllerOrdemServico();
                ControllerServico controllerServico = new ControllerServico();
                ControllerEmail controllerEmail = new ControllerEmail();
                bool Finalizada = false;


                if (controllerOS.Verificar(Txt_OS.Text))//Verifica se a OS existe ou não
                {

                    try
                    {
                        controllerOS.FinalizarOS(Txt_OS.Text);
                        MessageBox.Show("Ordem de serviço Finalizada com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Gerando o serviço
                        controllerServico.Save(Txt_Descricao.Text, double.Parse(Txt_Valor.Text), Txt_OS.Text,Txt_Servico.Text,NomeDoTecnico);

                        Finalizada = true;
                    }
                    catch
                    {
                        MessageBox.Show("Ocorreu um problema ao finalizar sua Ordem de serviço, informações foram salvas no arquivo log no diretorio do sue software", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    if (Finalizada)
                    {
                        if (MessageBox.Show("Enviar E-mail para o cliente informando sobre o término do serviço?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Email EmailBase = new Email();

                            //Decodificando Email Base para enviar!
                            String EmailDecoficado = controllerEmail.DecodificarEmailBase(RecuperandoEmailBase(), NomeEmpresa(), InformacaoCliente()[0],RecuperarNomeEquipamento());

                            string ResultadoEnvio = controllerEmail.Enviar(InformacaoCliente()[0], InformacaoCliente()[1], NomeEmpresa(), EmailDecoficado);

                            MessageBox.Show(ResultadoEnvio, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Informe o numero da ordem de serviço!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


            ControllerOrdemServico controllerOS = new ControllerOrdemServico();
            ControllerFisica controllerPF = new ControllerFisica();
            ControllerJuridica controllerPJ = new ControllerJuridica();

            string NomeDoCliente = "Não Econtrado";
            string EmailCliente = "Não encontrado";
            string[] Informacoes = new string[2];

            NomeDoCliente = controllerOS.LoadOSFinalizada(Txt_OS.Text).Cliente;


            //Verificando o tipo e o Email do usuario

            if (controllerPJ.Verificar(NomeDoCliente)) //Verifica se é Juridica
            {
                PessoaJuridicaBase = controllerPJ.Load(NomeDoCliente);
                EmailCliente = PessoaFisicaBase.Email;
                NomeDoCliente = PessoaFisicaBase.Nome;

                Informacoes[0] = NomeDoCliente;
                Informacoes[1] = EmailCliente;

            }
            else if (controllerPF.Verificar(NomeDoCliente)) //Verifica se é pessoa Física.
            {
                EmailCliente = controllerPF.Load(NomeDoCliente).Email;
                NomeDoCliente = controllerPF.Load(NomeDoCliente).Nome;

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
            ControllerEmpresa controllerEmpresa = new ControllerEmpresa();

            string NomeEmpresa = "Não encontrado";

            NomeEmpresa = controllerEmpresa.Load().Nome;

            return NomeEmpresa;
        }

        /// <summary>
        /// Recuperando E-mail base;
        /// </summary>
        /// <returns>Texto do E-mail base ainda codificado.</returns>
        private string RecuperandoEmailBase()
        {
            Email Email = new Email();
            ControllerEmail controllerEmail = new ControllerEmail();

            string TextoEmail = "Não encontrado";

            TextoEmail = controllerEmail.LoadEmailBase();

            return TextoEmail;
        }

        /// <summary>
        /// Pegando o nome do equipamento para decodificar na menssagem do e-mail
        /// </summary>
        /// <returns></returns>
        private string RecuperarNomeEquipamento()
        {
            ControllerOrdemServico controllerOS = new ControllerOrdemServico();
            OrdemServico OSBase = new OrdemServico();

            string NomeEquipamento = "Não encontrado";

            OSBase = controllerOS.LoadOSFinalizada(Txt_OS.Text); //Carregando informações da ordem de serviço para a OSBase;
            NomeEquipamento = OSBase.Equipamento;

            return NomeEquipamento;
        }

        /// <summary>
        /// Carregando o nome de todos os serviços e os adicionando no combo Box(Txt_Servicos).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Servico_Load(object sender, EventArgs e)
        {
            ControllerServicoBase controllerServicoBase = new ControllerServicoBase();

            foreach (var Servicos in controllerServicoBase.LoadList())
            {
                Txt_Servico.Items.Add(Servicos);
            }
        }

        /// <summary>
        /// Carregando o valor do serviço para o TextBox(Usado para valores) cada vez que o algo é selecionado no TextBox dos serviços;
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_Servico_SelectedIndexChanged(object sender, EventArgs e)
        {
            ControllerServicoBase controllerServicoBase = new ControllerServicoBase();

            Txt_Valor.Text = controllerServicoBase.Load(Txt_Servico.Text).Valor.ToString();
        }
    }
}
