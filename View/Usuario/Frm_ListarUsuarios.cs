using System;
using Controller;
using System.Windows.Forms;

namespace View.Usuario
{
    public partial class Frm_ListarUsuarios : Form
    {
        public Frm_ListarUsuarios()
        {
            InitializeComponent();
        }

        private void Frm_ListarUsuarios_Load(object sender, EventArgs e)
        {
            AtualizaLista();
        }

        private void Btm_Atualizar_Click(object sender, EventArgs e)
        {
            AtualizaLista();
        }

        private void AtualizaLista()
        {
            Data_Os.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            Data_Os.DataSource = ControllerUsuario.CarregarLista();
        }
    }
}
