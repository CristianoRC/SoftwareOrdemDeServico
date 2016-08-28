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

            if (!ControllerUsuario.Verificar(Txt_Login.Text))
            {
                saida = ControllerUsuario.Salvar(Txt_Login.Text, Txt_Senha.Text, VerificarTipo());

                Txt_Login.Clear();
                Txt_Senha.Clear();
            }
            else
            {
                saida = "Usuario já cadastrado!";
            }



            MessageBox.Show(String.Format("{0}", saida), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool VerificarTipo()
        {
            if(Txt_Tipo.Text == "Administrador")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
