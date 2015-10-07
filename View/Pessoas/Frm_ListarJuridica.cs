using System;
using System.Windows.Forms;

namespace View.Pessoas
{
    public partial class Frm_ListarJuridica : Form
    {
        public Frm_ListarJuridica()
        {
            InitializeComponent();
        }

        private void Frm_ListarJuridica_Load(object sender, EventArgs e)
        {

            Model.Pessoa_e_Usuario.Juridica PessoaJuridicaBase = new Model.Pessoa_e_Usuario.Juridica();

            foreach (var item in PessoaJuridicaBase.LoadList())
            {
                //Fazer um load na mão para saber se o problema e na parte de load.
                Data_Os.Rows.Add(PessoaJuridicaBase.Load(item).Nome, PessoaJuridicaBase.Load(item).Contato, PessoaJuridicaBase.Load(item).Cnpj, PessoaJuridicaBase.Load(item).Cidade, Convert.ToString(PessoaJuridicaBase.Load(item).Situacao));//TODO Arrumar código de pessoa fisica ou juridica aqui.
            }
        }
    }
}
