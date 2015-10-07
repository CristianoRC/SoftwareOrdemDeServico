using System;
using System.Collections.Generic;
using System.IO;
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
            Model.Ordem_de_Servico.OrdemServico OrdemDeServico = new Model.Ordem_de_Servico.OrdemServico();

            string Retorno = OrdemDeServico.Save(Txt_Nordem.Text, Txt_Referencia.Text, Txt_Situacao.Text, Txt_Defeito.Text, Txt_Descricao.Text, Txt_Observacoes.Text, Txt_Nserie.Text, Txt_Equipamento.Text, Txt_DataEntrada.Text);

            MessageBox.Show(String.Format("{0}", Retorno), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        private void Btm_Pesquisar_Click(object sender, EventArgs e)
        {

            Txt_ListaPessoa.Items.Clear();

            if (CheckPessoaFisica.Checked == true)
            {
                Model.Pessoa_e_Usuario.Fisica PessoaFBase = new Model.Pessoa_e_Usuario.Fisica();

                foreach (var item in PessoaFBase.LoadList())
                {
                    Txt_ListaPessoa.Items.Add(item.ToString());
                }
            }

            if (CheckPessoaJuridica.Checked == true)
            {
                Model.Pessoa_e_Usuario.Juridica PessoaJBase = new Model.Pessoa_e_Usuario.Juridica();

                foreach (var item in PessoaJBase.LoadList())
                {
                    Txt_ListaPessoa.Items.Add(item.ToString());
                }
            }
        }
    }
}
