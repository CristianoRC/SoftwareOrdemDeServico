using System;
using System.IO;
using System.Windows.Forms;

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
                 pictureBox1.ImageLocation =  openFileDialog1.FileName;

                 TemFoto = true;
            }
        }

        private void Btm_Salvar_Click(object sender, EventArgs e)
        {
            StreamWriter sw = null;
            
            try
            {
                if (TemFoto)
                {
                    if (File.Exists("Logo.png"))
                    {
                        File.Delete("Logo.png");
                    }

                    File.Copy(openFileDialog1.FileName, "Logo.png");

                }

                sw = new StreamWriter("Empresa.CFG");

                sw.WriteLine(textBox1.Text);
                sw.WriteLine(Txt_Contato.Text);
                sw.WriteLine(Txt_Endereco.Text);
            }
            catch (Exception Exc)
            {
                Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();
                Log.ArquivoExceptionLog(Exc);

                MessageBox.Show("Ocorreu um erro inesperado, um arquivo de LOG foi criado no diretorio do seu software!");
            }
            finally
            {
                if(sw != null)
                {
                    sw.Close();

                    MessageBox.Show("Informações salvas com sucesso reinicie seu Software para as por em pratica", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
