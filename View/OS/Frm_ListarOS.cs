using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.OS
{
    public partial class Frm_ListarOS : Form
    {
        public Frm_ListarOS()
        {
            InitializeComponent();
        }

        private void Frm_ListarOS_Load(object sender, EventArgs e)
        {
            Model.Ordem_de_Servico.OrdemServico OSBase = new Model.Ordem_de_Servico.OrdemServico();

            foreach (var item in OSBase.LoadList())
            {
                Data_Os.Rows.Add(OSBase.Load(item).Identificador, OSBase.Load(item).Equipamento, OSBase.Load(item).Situacao, OSBase.Load(item).PessoaFisica, OSBase.Load(item).DataEntradaServico);//TODO Arrumar código de pessoa fisica ou juridica aqui.
            }
        }
    }
}
