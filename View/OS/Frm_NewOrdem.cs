using System;
using Model.Pessoa_e_Usuario;
using Controller;
using System.Windows.Forms;

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

            if (MessageBox.Show("Deseja imprimir o arquivo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                controllerOS.CreatPDF(Txt_Nordem.Text, Txt_Referencia.Text, Txt_Situacao.Text, Txt_Defeito.Text, Txt_Descricao.Text, Txt_Observacoes.Text, Txt_Nserie.Text, Txt_Equipamento.Text, Txt_DataEntrada.Text, Txt_Cliente.Text);
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

            Txt_ListaPessoa.Items.Clear();

            if (CheckPessoaFisica.Checked == true)
            {
                ControllerFisica controllerPF = new ControllerFisica();

                foreach (var item in controllerPF.LoadList())
                {
                    //Le o nome das pessoas (arquivos) e adiciona ele a cada passada no ComboBox.

                    Txt_ListaPessoa.Items.Add(item.ToString());
                }
            }

            if (CheckPessoaJuridica.Checked == true)
            {
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
    }
}
