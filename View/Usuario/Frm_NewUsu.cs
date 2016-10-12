using System;
using System.Windows.Forms;
using Controller;

namespace View.Formularios_Usuarios
{
    public partial class Frm_NewUsu : Form
    {
        public Frm_NewUsu()
        {
            InitializeComponent();
        }
        private void Btm_Salvar_Click(object sender, EventArgs e)
        {
            string saida = "";

                saida = ControllerUsuario.Criar(Txt_Login.Text, Txt_Senha.Text, VerificarTipo());

                Txt_Login.Clear();
                Txt_Senha.Clear();
          
            MessageBox.Show(String.Format("{0}", saida), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private char VerificarTipo()
        {
            if(Txt_Tipo.Text == "Administrador")
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
