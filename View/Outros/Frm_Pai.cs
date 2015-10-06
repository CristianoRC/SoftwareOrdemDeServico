using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class Frm_Pai : Form
    {

        public Frm_Pai()
        {
            InitializeComponent();
        }

        string Usuario;

        public Frm_Pai(Char nivelAcesso, String usuario)
        {

             Usuario = usuario;

            if(nivelAcesso == 'U')
            {
                MessageBox.Show("É usuario");
            }
            else if (nivelAcesso == 'A')
            {
                MessageBox.Show("É Adm");
            }
            InitializeComponent();
        }


        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você deseja realmente sair?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Frm_Pai_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios_Usuarios.Frm_NewUsu Frm_NewUso = new Formularios_Usuarios.Frm_NewUsu();

            Frm_NewUso.MdiParent = this;

            Frm_NewUso.Show();
        }

        private void novaF5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           OS.Frm_NewOrdem Frm_NewOrdem = new OS.Frm_NewOrdem();

            Frm_NewOrdem.MdiParent = this;

            Frm_NewOrdem.Show();
        }

        private void editarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OS.Frm_EditarOS Frm_Editar = new OS.Frm_EditarOS();

            Frm_Editar.MdiParent = this;

            Frm_Editar.Show();

            
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pessoas.Frm_PessoaFisica Pessoa = new Pessoas.Frm_PessoaFisica();

            Pessoa.MdiParent = this;

            Pessoa.Show();
        }

        private void jurídicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pessoas.Frm_PessoaJuridica Pessoa = new Pessoas.Frm_PessoaJuridica();

            Pessoa.MdiParent = this;

            Pessoa.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Lbl_HoraData.Text = DateTime.Now.ToLongTimeString();
        }

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void telaInicialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opicoes.Frm_OpicoesInicial Tela_Inicial = new Opicoes.Frm_OpicoesInicial();

            Tela_Inicial.MdiParent = this;

            Tela_Inicial.Show();
        }

        private void exibirPainelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(panel1.Visible == false)
            {
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;
            }
        }

        private void Frm_Pai_Load(object sender, EventArgs e)
        {
            System.IO.StreamReader sr = null;
            try
            {
                sr = new System.IO.StreamReader("Empresa.CFG");

                Lbl_NomeEmpresa.Text = sr.ReadLine();

                Lbl_Nome.Text = Usuario;

                Pic_LgoEmpresa.ImageLocation = "Logo.png";
            }
            catch (Exception exc)
            {
                Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();
                Log.ArquivoExceptionLog(exc);
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }

        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Sobre Sobre = new Frm_Sobre();

            Sobre.MdiParent = this;

            Sobre.Show();
        }

        private void listarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OS.Frm_ListarOS Frm_ListarOS = new OS.Frm_ListarOS();

            Frm_ListarOS.MdiParent = this;

            Frm_ListarOS.Show();
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pessoas.Frm_ListarJuridica Frm_ListarJuridica = new Pessoas.Frm_ListarJuridica();

            Frm_ListarJuridica.MdiParent = this;

            Frm_ListarJuridica.Show();
        }
    }
}
