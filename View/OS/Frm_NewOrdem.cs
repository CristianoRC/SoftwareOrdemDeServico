using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace View.OS
{
    public partial class Frm_NewOrdem : Form
    {
        public Frm_NewOrdem()
        {
            InitializeComponent();
        }

        private void Frm_NewOrdem_Load(object sender, EventArgs e)
        {
            Txt_DataEntrada.Text = DateTime.Now.ToString();

            Random R = new Random();

            Txt_Nordem.Text = R.Next(999999999).ToString();


            if (VerificarNordem() == false) //Ira verificar se já existe uma ordem com o numero sorteado, se tiver ira realizar um novo sorteio;
            {
                Txt_Nordem.Text = R.Next(999999999).ToString();

                VerificarNordem();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(String.Format("OS/{0}.os", Txt_Nordem.Text));

                sw.WriteLine(Txt_Nordem.Text); //O numero da ordem de serviço vai vir sempre 1º.
                sw.WriteLine(Txt_Cliente.Text);
                sw.WriteLine(Txt_Equipamento.Text);
                sw.WriteLine(Txt_Situacao.Text);
                sw.WriteLine(Txt_Nserie.Text);
                sw.WriteLine(Txt_Defeito.Text);
                sw.WriteLine(Txt_Referencia.Text);
                sw.WriteLine(Txt_DataEntrada.Text);
                sw.WriteLine(Txt_Observacoes.Text);
            }
            catch (Exception Exc)
            {
                MessageBox.Show("Ocorreu um erro inesperado um arquivo de LOG foi criado no diretorio do seu sotware.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();

                Log.ArquivoExceptionLog(Exc);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();

                    MessageBox.Show("Ordem de serviço criada com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Txt_Cliente.Clear();
                    Txt_DataEntrada.Clear();
                    Txt_Defeito.Clear();
                    Txt_Descricao.Clear();
                    Txt_Equipamento.Clear();
                    Txt_Nordem.Clear();
                    Txt_Nserie.Clear();
                    Txt_Observacoes.Clear();
                    Txt_Referencia.Clear();
                }
            }
        }

        private bool VerificarNordem()
        {
            if (File.Exists(String.Format("OS/{0}.os", Txt_Nordem.Text)))
            {
                return false;
            }
            else
            {
                return true;
            }

        }


        private void Btm_Pesquisar_Click(object sender, EventArgs e)
        {

            bool VerificadorJ = false;
            bool VerificadorF = false;

            if (VerificadorF == false)
            {
                if (CheckPessoaFisica.Checked == true)
                {
                    DirectoryInfo ListaPessoasFBase = new DirectoryInfo("Pessoa/F");

                    foreach (var item in ListaPessoasFBase.GetFiles())
                    {
                        Txt_ListaPessoa.Items.Add(item.ToString());
                    }

                    VerificadorF = true;
                }
            }

            if (VerificadorJ == false)
            {

                if (CheckPessoaJuridica.Checked == true)
                {
                    DirectoryInfo ListaPessoasJBase = new DirectoryInfo("Pessoa/J");

                    foreach (var item in ListaPessoasJBase.GetFiles())
                    {
                        Txt_ListaPessoa.Items.Add(item.ToString());
                    }

                    VerificadorJ = true;
                }
            }

        }
    }
}
