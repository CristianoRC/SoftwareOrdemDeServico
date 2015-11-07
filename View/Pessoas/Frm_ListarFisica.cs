using System;
using Controller;
using System.Windows.Forms;

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

            Model.Pessoa_e_Usuario.Fisica PessoaFisicaBase = new Model.Pessoa_e_Usuario.Fisica();
            ControllerFisica controllerPF = new ControllerFisica();

            foreach (var item in controllerPF.LoadList())
            {
                PessoaFisicaBase = controllerPF.Load(item);

                Data_Os.Rows.Add(PessoaFisicaBase.Nome, PessoaFisicaBase.Celular, PessoaFisicaBase.CPF, PessoaFisicaBase.Cidade, PessoaFisicaBase.Situacao);
            }
        }
    }
}
