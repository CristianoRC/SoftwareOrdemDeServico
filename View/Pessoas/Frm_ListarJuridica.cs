using System;
using System.Windows.Forms;
using Model.Pessoa_e_Usuario;
using Controller;

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

            foreach (var item in ControllerJuridica.LoadList())
            {
                PessoaJuridicaBase = ControllerJuridica.Load(item);

                Data_Os.Rows.Add(PessoaJuridicaBase.Nome, PessoaJuridicaBase.Contato, PessoaJuridicaBase.Cnpj, PessoaJuridicaBase.Cidade, PessoaJuridicaBase.Situacao);
            }
        }
    }
}
