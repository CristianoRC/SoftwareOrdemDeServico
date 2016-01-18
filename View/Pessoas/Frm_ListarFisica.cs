using System;
using Controller;
using System.Windows.Forms;
using Model.Pessoa_e_Usuario;

namespace View.Pessoas
{
    public partial class Frm_ListarFisica : Form
    {
        public Frm_ListarFisica()
        {
            InitializeComponent();
        }

        private void Frm_ListarFisica_Load(object sender, EventArgs e)
        {

            Fisica PessoaFisicaBase = new Fisica();

            foreach (var item in ControllerFisica.LoadList())
            {
                PessoaFisicaBase = ControllerFisica.Load(item);

                Data_Os.Rows.Add(PessoaFisicaBase.Nome, PessoaFisicaBase.Celular, PessoaFisicaBase.CPF, PessoaFisicaBase.Cidade, PessoaFisicaBase.Situacao);
            }
        }
    }
}
