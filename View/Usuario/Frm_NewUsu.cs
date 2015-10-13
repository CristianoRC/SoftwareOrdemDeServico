using System;
using System.Windows.Forms;

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
            
            Model.Pessoa_e_Usuario.Usuario UsuarioBase = new Model.Pessoa_e_Usuario.Usuario();
            string saida = "";

            if (! UsuarioBase.Verificar(Txt_Login.Text))
            {   
                //Salvando e passando o resulado para a saida.
                saida = UsuarioBase.Save(Txt_Login.Text, Txt_Senha.Text, Txt_Tipo.Text);

                Txt_Login.Clear();
                Txt_Senha.Clear();
                Txt_Tipo.Text = " ";
            }
            else
            {
                saida = "Usuario já cadastrado!";
            }
            
           

            MessageBox.Show(String.Format("{0}",saida), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
