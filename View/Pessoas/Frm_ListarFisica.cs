using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            foreach (var item in PessoaFisicaBase.LoadList())
            {
                Data_Os.Rows.Add(PessoaFisicaBase.Load(item).Nome, PessoaFisicaBase.Load(item).Celular, PessoaFisicaBase.Load(item).CPF, PessoaFisicaBase.Load(item).Cidade, PessoaFisicaBase.Load(item).Situacao);
            }
        }
    }
}
