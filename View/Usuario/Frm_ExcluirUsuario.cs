using System;
using System.Windows.Forms;
using Controller;

namespace View.Usuario
{
    public partial class Frm_ExcluirUsuario : Form
    {
        public Frm_ExcluirUsuario()
        {
            InitializeComponent();
        }

        private void Btm_Excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você deseja realmente excluir esse usuário?","Verificação",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
               string Saida =  ControllerUsuario.Deletar(Txt_Tecnicos.Text.Trim());

                MessageBox.Show(Saida,"Informação",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            AtualziarListaDeUsuarios();
        }

        private void Frm_ExcluirUsuario_Load(object sender, EventArgs e)
        {
            AtualziarListaDeUsuarios();
        }

        private void AtualziarListaDeUsuarios()
        {

            Txt_Tecnicos.Items.Clear();

            System.Data.DataTable tabela = new System.Data.DataTable();

            tabela = ControllerUsuario.CarregarListaDeNomes();

            foreach (System.Data.DataRow r in tabela.Rows)
            {
                foreach (System.Data.DataColumn c in tabela.Columns) 
                {
                    Txt_Tecnicos.Items.Add(r[c]);
                }
            }
        }
    }
}
