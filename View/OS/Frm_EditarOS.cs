using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace View.OS
{
    public partial class Frm_EditarOS : Form
    {
        public Frm_EditarOS()
        {
            InitializeComponent();
        }

        private void Frm_EditarOS_Load(object sender, EventArgs e)
        {

        }

        private void Btm_Pesquisa_Click(object sender, EventArgs e)
        {
            if (Txt_Pesquisa.Text != "")
            {
                if (File.Exists(String.Format("OS/{0}.os", Txt_Pesquisa.Text.Trim())))
                {
                    StreamReader sr = null;

                    try
                    {
                        sr = new StreamReader(String.Format("OS/{0}.os", Txt_Pesquisa.Text));

                        Txt_Nordem.Text = sr.ReadLine();
                        Txt_Cliente.Text = sr.ReadLine();
                        Txt_Equipamento.Text = sr.ReadLine();
                        Txt_Situacao.Text = sr.ReadLine();
                        Txt_Nserie.Text = sr.ReadLine();
                        Txt_Defeito.Text = sr.ReadLine();
                        Txt_Referencia.Text = sr.ReadLine();
                        Txt_DataEntrada.Text = sr.ReadLine();
                        Txt_Observacoes.Text = sr.ReadLine();
                    }
                    catch (Exception Exc)
                    {
                        Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();

                        Log.ArquivoExceptionLog(Exc);

                        MessageBox.Show("Ocorreu um erro inerperado, um arquivo de Log foi criado no diretorio do sue sotware", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (sr != null)
                            sr.Close();
                    }
                }

            }
            else
            {
                //Se o valor do Txt da pesquisa for inválido ira aparecer esse erro.
                MessageBox.Show("Insira um valor valido da ordem de serviço!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                    MessageBox.Show("Ordem de serviço editada com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
    }
}