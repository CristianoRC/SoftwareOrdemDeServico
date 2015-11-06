using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class Frm_Servico : Form
    {
        public Frm_Servico()
        {
            InitializeComponent();
        }

        private void finalizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Txt_OS.Text))
            {
                Model.Ordem_de_Servico.OrdemServico OSbase = new Model.Ordem_de_Servico.OrdemServico();
                Model.Ordem_de_Servico.Servico ServicoBase = new Model.Ordem_de_Servico.Servico();
                bool Resultado = false;

                if (OSbase.Verificar(Txt_OS.Text))//Verifica se a OS existe ou não
                {
                    Resultado = OSbase.FinalizarOS(Txt_OS.Text);

                    if (Resultado)
                    {
                        MessageBox.Show("Ordem de serviço Finalizada com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um problema ao finalizar sua Ordem de serviço, informações foram salvas no arquivo log no diretorio do sue software", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    //Gerando o serviço
                    ServicoBase.Save(Txt_Descricao.Text, double.Parse(Txt_Valor.Text), Txt_OS.Text);


                    if (MessageBox.Show("Enviar E-mail para o cliente informando sobre o término do serviço?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Model.Email EmailBase = new Model.Email();

                        //Decodificando Email Base para enviar!
                        String EmailDecoficado = EmailBase.DecodificarEmailBase(RecuperandoEmailBase(), NomeEmpresa(), InformacaoCliente()[0]);

                        bool ResultadoEnvio = EmailBase.Enviar(InformacaoCliente()[0], InformacaoCliente()[1], NomeEmpresa(), EmailDecoficado);

                        if (ResultadoEnvio)
                        {
                            MessageBox.Show("E-mail enviado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Ocorreu um problema ao enviar o E-mail!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Informe o numero da ordem de serviço!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string[] InformacaoCliente()
        {
            Model.Ordem_de_Servico.OrdemServico OSBase = new Model.Ordem_de_Servico.OrdemServico();
            Model.Pessoa_e_Usuario.Fisica PessoaFisicaBase = new Model.Pessoa_e_Usuario.Fisica();
            Model.Pessoa_e_Usuario.Juridica PessoaJuridicaBase = new Model.Pessoa_e_Usuario.Juridica();
            string NomeDoCliente = "Não Econtrado";
            string EmailCliente = "Não encontrado";
            string[] Informacoes = new string[2];

            NomeDoCliente = OSBase.LoadOSFinalizada(Txt_OS.Text).Cliente;

            //TODO:Arrumar para verificar o tipo de pessoa

            //Verificando o tipo e o Email do usuario


            if (true) //Verifica se é PessoaFisica
            {
                EmailCliente = PessoaFisicaBase.Load(NomeDoCliente).Email;
                NomeDoCliente = PessoaFisicaBase.Load(NomeDoCliente).Nome;

                Informacoes[0] = NomeDoCliente;
                Informacoes[1] = EmailCliente;
            }
            else if (PessoaJuridicaBase.Verificar(NomeDoCliente)) //Verifica se é pessoa Juridica
            {
                PessoaJuridicaBase = PessoaJuridicaBase.Load(NomeDoCliente);
                EmailCliente = PessoaFisicaBase.Email;
                NomeDoCliente = PessoaFisicaBase.Nome;

                Informacoes[0] = NomeDoCliente;
                Informacoes[1] = EmailCliente;
            }

            return Informacoes;
        }

        private string NomeEmpresa()
        {

            Model.Empresa EmpresaBase = new Model.Empresa();
            string NomeEmpresa = "Não encontrado";

            NomeEmpresa = EmpresaBase.Load().Nome;

            return NomeEmpresa;
        }

        private string RecuperandoEmailBase()
        {
            Model.Email Email = new Model.Email();
            string TextoEmail = "Não encontrado";

            TextoEmail = Email.LoadEmailBase();

            return TextoEmail;
        }
    }
}
