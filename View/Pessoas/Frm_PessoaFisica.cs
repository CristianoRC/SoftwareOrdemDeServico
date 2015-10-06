using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace View.Pessoas
{
    public partial class Frm_PessoaFisica : Form
    {
        public Frm_PessoaFisica()
        {
            InitializeComponent();
        }

        private void Btm_Salvar_Click(object sender, EventArgs e)
        {

            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(String.Format("Pessoa/F/{0}.pessoaf",Txt_Nome.Text.TrimEnd().TrimStart()));

                sw.WriteLine(Txt_Nome.Text);
                sw.WriteLine(Txt_Endereco.Text);
                sw.WriteLine(Txt_Telefone.Text);
                sw.WriteLine(Txt_Situacao.Text);
                sw.WriteLine(Txt_Estado.Text);
                sw.WriteLine(Txt_Cidade.Text);
                sw.WriteLine(Txt_Bairro.Text);
                sw.WriteLine(Txt_Cep.Text);
                sw.WriteLine(Txt_Observacoes.Text);

                //Parte de Pessoa Física
                sw.WriteLine(Txt_CPF.Text);
                sw.WriteLine(Txt_Celular.Text);
                sw.WriteLine(Txt_Sexo.Text);
                sw.WriteLine(Txt_DataNacimento.Text);
            }
            catch (Exception Exc)
            {
                Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();

                Log.ArquivoExceptionLog(Exc);

                MessageBox.Show("Ocorreu um erro inesperado! Um arquivo de LOG foi criado no diretorio do seu sotware", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();

                    MessageBox.Show("Pessoal Física Salva com sucesso!","Informação",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
        }
    }
}
