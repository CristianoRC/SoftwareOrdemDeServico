using System;
using Model;
using Controller;
using System.Windows.Forms;
using Model.Ordem_de_Servico;
using Model.Pessoa_e_Usuario;

namespace View.OS
{
    public partial class Frm_NewOrdem : Form
    {
        public Frm_NewOrdem()
        {
            InitializeComponent();
        }

        private void Frm_NewOrdem_Load(object sender, EventArgs e)
        {
            Txt_DataEntrada.Text = DateTime.Now.ToString();
            Random R = new Random();
            Txt_Nordem.Text = R.Next(999999999).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ControllerOrdemServico controllerOS = new ControllerOrdemServico();

            string Retorno = controllerOS.Save(Txt_Nordem.Text, Txt_Referencia.Text, Txt_Situacao.Text, Txt_Defeito.Text, Txt_Descricao.Text, Txt_Observacoes.Text, Txt_Nserie.Text, Txt_Equipamento.Text, Txt_DataEntrada.Text, Txt_Cliente.Text);

            MessageBox.Show(String.Format("{0}", Retorno), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (MessageBox.Show("Deseja imprimir  a ordem de serviço?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                controllerOS.CreatPDF(Txt_Nordem.Text, Txt_Referencia.Text, Txt_Situacao.Text, Txt_Defeito.Text, Txt_Descricao.Text, Txt_Observacoes.Text, Txt_Nserie.Text, Txt_Equipamento.Text, Txt_DataEntrada.Text, Txt_Cliente.Text);
            }

            if (MessageBox.Show("Deseja enviar a ordem de serviço para o cliente?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ControllerEmail controllerEmail = new ControllerEmail();
                Email EmailBase = new Email();

                //Decodificando Email Base para enviar!
                String EmailDecoficado = controllerEmail.DecodificarEmailBase(RecuperandoEmailBase(), NomeEmpresa(), "Cristiano", RecuperarNomeEquipamento());

                string ResultadoEnvio = controllerEmail.EnviarOrdemDeServiço("Cristiano", "Contato@cristianoprogramador.com", NomeEmpresa(), EmailDecoficado);

                //Corrigir bugs acima, ira se arrumar logo após da implementação do sistema de escrever e-mail só para "anexo";

                MessageBox.Show(ResultadoEnvio, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Txt_Cliente.Clear();
            Txt_DataEntrada.Clear();
            Txt_Defeito.Clear();
            Txt_Descricao.Clear();
            Txt_Equipamento.Clear();
            Txt_Nordem.Clear();
            Txt_Nserie.Clear();
            Txt_Observacoes.Clear();
            Txt_Referencia.Clear();
        }

        private void Btm_Pesquisar_Click(object sender, EventArgs e)
        {

            if (CheckPessoaFisica.Checked == true)
            {
                Txt_ListaPessoa.Items.Clear();

                ControllerFisica controllerPF = new ControllerFisica();

                foreach (var item in controllerPF.LoadList())
                {
                    //Le o nome das pessoas (arquivos) e adiciona ele a cada passada no ComboBox.

                    Txt_ListaPessoa.Items.Add(item.ToString());
                }
            }

            if (CheckPessoaJuridica.Checked == true)
            {
                Txt_ListaPessoa.Items.Clear();

                ControllerJuridica controllerPJ = new ControllerJuridica();

                foreach (var item in controllerPJ.LoadList())
                {
                    Txt_ListaPessoa.Items.Add(item.ToString());
                }
            }
        }

        private void Txt_ListaPessoa_TextChanged(object sender, EventArgs e)
        {
            Txt_Cliente.Text = Txt_ListaPessoa.Text;

            //Passando valor do usuario selecionado para o novo formularios na hora de registrar a ordem de seviço.
        }

        //TODO:Arrumar sistema de e-mail  só para esse tipo(com Anexo da Ordem de serviço).


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

            OSBase = controllerOS.LoadOSFinalizada(Txt_Nordem.Text); //Carregando informações da ordem de serviço para a OSBase;
            NomeEquipamento = OSBase.Equipamento;

            return NomeEquipamento;
        }

    }
}
