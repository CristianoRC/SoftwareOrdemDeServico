using Controller;
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
    public partial class Frm_ListarClientes : Form
    {
        public Frm_ListarClientes()
        {
            InitializeComponent();
        }

        private void AtualizarLista()
        {
            Data_Os.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Data_Os.DataSource = ControllerPessoa.CarregarLista();
        }

        private void Btm_Atualizar_Click(object sender, EventArgs e)
        {
            AtualizarLista();
        }

        private void Frm_ListarClientes_Load(object sender, EventArgs e)
        {
            AtualizarLista();
        }
    }
}
