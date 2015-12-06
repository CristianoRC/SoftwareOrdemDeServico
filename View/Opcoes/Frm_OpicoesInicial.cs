using System;
using System.IO;
using System.Windows.Forms;
using Controller;

namespace View.Opicoes
{
    public partial class Frm_OpicoesInicial : Form
    {
        public Frm_OpicoesInicial()
        {
            InitializeComponent();
        }
        bool TemFoto = false;

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;

                TemFoto = true;
            }
        }

        private void Btm_Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Check_Informações.Checked == true)
                {
                    Model.Empresa EmpresaBase = new Model.Empresa();
                    ControllerEmpresa controllerEmpresa = new ControllerEmpresa();

                    EmpresaBase.Nome = Txt_Nome.Text;
                    EmpresaBase.Contato = Txt_Contato.Text;
                    EmpresaBase.Endereco = Txt_Endereco.Text;

                    string Resultado = controllerEmpresa.Save(EmpresaBase.Nome, EmpresaBase.Contato, EmpresaBase.Endereco);

                    MessageBox.Show(Resultado, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (TemFoto)
                {
                    /*
                        Se o arquivo do logo já existe ele cria um novo com o 1 no final para não dar erro(Arquivo já esta sendo usado), com esse 
                    erro não  posso excluir nem subistituir o arquivo por isso do numero 1 no final, e toda vez que o FRM_Login for chamado  
                    ele ira verificar se existe um arquivo "Logo1.png" e ira renomear para "Logo.png". (Na tela de login a imagen ainda não
                    esta sendo usada, por isso dara para renomer/ excluir).

                    */
                    if (File.Exists("Logo.png"))
                    {
                        File.Copy(openFileDialog1.FileName, "Logo1.png");
                    }
                    else
                    {
                        File.Copy(openFileDialog1.FileName, "Logo.png");
                    }

                    MessageBox.Show("Logo modificado com sucesso! Reinicie seu software para que as modificações sejam feitas.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception Exc)
            {
                Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();
                Log.ArquivoExceptionLog(Exc);

                MessageBox.Show("Ocorreu um erro inesperado, um arquivo de LOG foi criado no diretorio do seu software!");
            }
        }

        private void Frm_OpicoesInicial_Load(object sender, EventArgs e)
        {
            Model.Empresa EmpresaBase = new Model.Empresa();
            ControllerEmpresa controllerEmpresa = new ControllerEmpresa();

            EmpresaBase = controllerEmpresa.Load();

            Txt_Nome.Text = EmpresaBase.Nome;
            Txt_Contato.Text = EmpresaBase.Contato;
            Txt_Endereco.Text = EmpresaBase.Endereco;
        }
    }
}
