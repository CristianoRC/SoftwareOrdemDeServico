using System;
using System.Windows.Forms;
using Model.Pessoa_e_Usuario;

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

            Juridica PessoaJuridicaBase = new Juridica();

            foreach (var item in PessoaJuridicaBase.LoadList())
            {
                Data_Os.Rows.Add(PessoaJuridicaBase.Load(item).Nome, PessoaJuridicaBase.Load(item).Contato, PessoaJuridicaBase.Load(item).Cnpj, PessoaJuridicaBase.Load(item).Cidade, PessoaJuridicaBase.Load(item).Situacao);
            }
        }
    }
}
