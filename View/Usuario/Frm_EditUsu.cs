using System;
using Controller;
using System.Windows.Forms;
using Model.Pessoa_e_Usuario;

namespace View.Usuario
{
    public partial class Frm_EditUsu : Form
    {
        public Frm_EditUsu()
        {
            InitializeComponent();
        }

        private int IDtec;

        private void Frm_EditUsu_Load(object sender, EventArgs e)
        {
            System.Data.DataTable tabela = new System.Data.DataTable("Tecnicos");

            tabela = ControllerUsuario.CarregarListaDeNomes();
            
            if (tabela.Rows.Count != 0)
            {
                foreach (System.Data.DataRow r in tabela.Rows)
                {
                    foreach (System.Data.DataColumn c in tabela.Columns)
                    {
                        Txt_Tecnicos.Items.Add(r[c].ToString());
                    }
                }
            }
        }

        private void Btm_Salvar_Click(object sender, EventArgs e)
        {
            string saida = "";

            if (!String.IsNullOrEmpty(Txt_Login.Text))
            {
                //Salvando e passando o resulado para a saida.
                saida = ControllerUsuario.Editar(IDtec, Txt_Login.Text, Txt_Senha.Text, VerificarTipo());

                Txt_Login.Clear();
                Txt_Senha.Clear();
                Txt_Tipo.Text = " ";


                MessageBox.Show(String.Format("{0}", saida), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Btm_Pesquisar_Click(object sender, EventArgs e)
        {
            tecnico UsuarioBase = new tecnico();

            UsuarioBase = ControllerUsuario.Carregar(Txt_Tecnicos.Text);

            IDtec = UsuarioBase.Id;
            Txt_Login.Text = UsuarioBase.Nome;
            Txt_Senha.Text = UsuarioBase.Senha;
            Txt_Tipo.Text = RetornarTipo(UsuarioBase);
        }

        private string RetornarTipo(tecnico Informacoes)
        {
            if (Informacoes.NivelAcesso == true)
            {
                return "Administrador";
            }
            else
            {
                return "Técnico";
            }
        }

        private char VerificarTipo()
        {
            if (Txt_Tipo.Text == "Administrador")
            {
                return '1';
            }
            else
            {
                return '0';
            }
        }
    }
}
