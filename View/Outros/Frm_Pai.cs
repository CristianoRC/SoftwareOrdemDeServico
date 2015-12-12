using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace View
{
    public partial class Frm_Pai : Form
    {


        public Frm_Pai()
        {
            InitializeComponent();
        }

        string Usuario;
        string NivelAcesso;

        public Frm_Pai(string usuario, string nivelAcesso)
        {
            InitializeComponent();

            Usuario = usuario;
            NivelAcesso = nivelAcesso;

            if (nivelAcesso == "Técnico") // Técnico e o que faz a manutenção;
            {
                //Desativando algumas informações que o usario não pode usar.

                usuariosToolStripMenuItem.Visible = false;

                emailToolStripMenuItem.Enabled = false;
                EmpresaToolStripMenuItem.Enabled = false;
                BackupexibirPainelToolStripMenuItem.Enabled = false;
                serviçosBásicosToolStripMenuItem.Enabled = false;

                //Desativando função de excluir para usuarios
                excluirToolStripMenuItem3.Enabled = false;
                excluirToolStripMenuItem2.Enabled = false;
                excluirToolStripMenuItem1.Enabled = false;
                excluirToolStripMenuItem.Enabled = false;
                excluirToolStripMenuItem4.Enabled = false;

            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você deseja realmente sair?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
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

        private void telaInicialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opicoes.Frm_OpicoesInicial Tela_Inicial = new Opicoes.Frm_OpicoesInicial();

            Tela_Inicial.MdiParent = this;

            Tela_Inicial.Show();
        }

        private void Frm_Pai_Load(object sender, EventArgs e)
        {
            //Se o logo estiver na pasta do software ele vai ficar no fundo da Tela Pai.
            if (File.Exists("Logo.png"))
            {
                this.BackgroundImage = System.Drawing.Image.FromFile("Logo.png");
            }

            StreamReader sr = null;
            try
            {
                sr = new System.IO.StreamReader("Empresa.CFG");

                Lbl_NomeEmpresa.Text = sr.ReadLine();

                Lbl_Nome.Text = Usuario;
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
            Outros.Frm_Sobre Sobre = new Outros.Frm_Sobre();

            Sobre.MdiParent = this;

            Sobre.Show();
        }

        private void listarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OS.Frm_ListarOS Frm_ListarOS = new OS.Frm_ListarOS();

            Frm_ListarOS.MdiParent = this;

            Frm_ListarOS.Show();
        }

        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("calc");
        }

        private void blocoDeNotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("Notepad");
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.Usuario.Frm_EditUsu frm_EdiUso = new View.Usuario.Frm_EditUsu();

            frm_EdiUso.MdiParent = this;

            frm_EdiUso.Show();
        }

        private void Frm_Pai_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void exibirPainelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Backup frm_Backup = new Frm_Backup();

            frm_Backup.MdiParent = this;

            frm_Backup.Show();
        }

        private void imprimirOrdemDeServiçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_ImprimirOS frm_ImprimirOS = new Frm_ImprimirOS();

            frm_ImprimirOS.MdiParent = this;

            frm_ImprimirOS.Show();
        }

        private void listarUsuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuario.Frm_ListarUsuarios frm_ListarUsuarios = new Usuario.Frm_ListarUsuarios();

            frm_ListarUsuarios.MdiParent = this;

            frm_ListarUsuarios.Show();
        }

        private void emailBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_EmailBase frm_EmailBase = new Frm_EmailBase();

            frm_EmailBase.MdiParent = this;

            frm_EmailBase.Show();
        }

        private void servidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_ConfigEmail frm_ConfigEmail = new Frm_ConfigEmail();

            frm_ConfigEmail.MdiParent = this;

            frm_ConfigEmail.Show();
        }

        private void listarServiçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_ListarServico frm_ListarServico = new Frm_ListarServico();

            frm_ListarServico.MdiParent = this;

            frm_ListarServico.Show();
        }

        private void finalizarOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Servico frm_Servico = new Frm_Servico(Lbl_Nome.Text);

            frm_Servico.MdiParent = this;

            frm_Servico.Show();
        }

        private void novoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_NewServicoBase frm_NewServicoBase = new Frm_NewServicoBase();

            frm_NewServicoBase.MdiParent = this;

            frm_NewServicoBase.Show();
        }

        private void editarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Frm_EditarServicoBase frm_EditarServicoBase = new Frm_EditarServicoBase();

            frm_EditarServicoBase.MdiParent = this;

            frm_EditarServicoBase.Show();
        }

        private void listaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_ListarServicoBase frm_ListarServicoBase = new Frm_ListarServicoBase();

            frm_ListarServicoBase.MdiParent = this;

            frm_ListarServicoBase.Show();
        }

        private void cadastrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Pessoas.Frm_PessoaFisica Pessoa = new Pessoas.Frm_PessoaFisica();

            Pessoa.MdiParent = this;

            Pessoa.Show();
        }

        private void cadastrarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Pessoas.Frm_PessoaJuridica Pessoa = new Pessoas.Frm_PessoaJuridica();

            Pessoa.MdiParent = this;

            Pessoa.Show();
        }

        private void listarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Pessoas.Frm_ListarFisica Frm_ListarFisica = new Pessoas.Frm_ListarFisica();

            Frm_ListarFisica.MdiParent = this;

            Frm_ListarFisica.Show();
        }

        private void listarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Pessoas.Frm_ListarJuridica Frm_ListarJuridica = new Pessoas.Frm_ListarJuridica();

            Frm_ListarJuridica.MdiParent = this;

            Frm_ListarJuridica.Show();
        }

        private void excluirToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            OS.Frm_ExcluirOS frm_ExcluirOS = new OS.Frm_ExcluirOS();

            frm_ExcluirOS.MdiParent = this;

            frm_ExcluirOS.Show();
        }

        private void excluirToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Servicos.Frm_ExcluirServico frm_ExcluirServico = new Servicos.Frm_ExcluirServico();

            frm_ExcluirServico.MdiParent = this;

            frm_ExcluirServico.Show();
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pessoas.Frm_ExcluirPessoaFisica frm_ExcluirPF = new Pessoas.Frm_ExcluirPessoaFisica();

            frm_ExcluirPF.MdiParent = this;

            frm_ExcluirPF.Show();
        }

        private void excluirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Pessoas.Frm_ExcluirPessoaJuridica frm_ExcluirPJ = new Pessoas.Frm_ExcluirPessoaJuridica();

            frm_ExcluirPJ.MdiParent = this;

            frm_ExcluirPJ.Show();
        }

        private void excluirToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            View.Usuario.Frm_ExcluirUsuario frm_ExcluirUsuario = new View.Usuario.Frm_ExcluirUsuario();

            frm_ExcluirUsuario.MdiParent = this;

            frm_ExcluirUsuario.Show();
        }

        private void finalizarOrdemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Servico frm_Servico = new Frm_Servico(Lbl_Nome.Text);

            frm_Servico.MdiParent = this;

            frm_Servico.Show();
        }

        private void Frm_Pai_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void novoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Frm_NewOrcamento frm_NewOrcamento = new Frm_NewOrcamento();

            frm_NewOrcamento.MdiParent = this;

            frm_NewOrcamento.Show();
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Servicos.Frm_ListarOrcamento frm_ListarOrcamento = new Servicos.Frm_ListarOrcamento();

            frm_ListarOrcamento.MdiParent = this;

            frm_ListarOrcamento.Show();
        }

        private void excluirToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Frm_ExcluirOrcamento frm_ExcluirOrcamento = new Frm_ExcluirOrcamento();

            frm_ExcluirOrcamento.MdiParent = this;

            frm_ExcluirOrcamento.Show();
        }

        private void reportarBugsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Report frm_Report = new Frm_Report();

            frm_Report.MdiParent = this;

            frm_Report.Show();
        }
    }
}
