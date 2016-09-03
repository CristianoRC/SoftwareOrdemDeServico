using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using View.Pessoas;

namespace View
{
    public partial class Frm_Pai : Form
    {
        public Frm_Pai()
        {
            InitializeComponent();
        }

        //Informações dos técnicos para os forms de OS.
        string Usuario;
        bool NivelAcesso;
        int Id;

        public Frm_Pai(string usuario, bool nivelAcesso,int id)
        {
            InitializeComponent();

            Usuario = usuario;
            NivelAcesso = nivelAcesso;
            Id = id;

            if (NivelAcesso == false) // Técnico e o que faz a manutenção;
            {
                //Desativando algumas informações que o usario não pode usar.

                usuariosToolStripMenuItem.Visible = false;

                emailToolStripMenuItem.Enabled = false;
                EmpresaToolStripMenuItem.Enabled = false;
                BackupexibirPainelToolStripMenuItem.Enabled = false;
                

                //Desativando função de excluir para usuarios
                excluirToolStripMenuItem3.Enabled = false;
                excluirToolStripMenuItem2.Enabled = false;
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
            OS.Frm_NewOrdem frm_NewOrdem = new OS.Frm_NewOrdem(Id); 

            frm_NewOrdem.MdiParent = this;

            frm_NewOrdem.Show();
        }

        private void editarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OS.Frm_EditarOS Frm_Editar = new OS.Frm_EditarOS(Id);

            Frm_Editar.MdiParent = this;

            Frm_Editar.Show();

        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pessoas.Frm_Cliente Pessoa = new Pessoas.Frm_Cliente();

            Pessoa.MdiParent = this;

            Pessoa.Show();
        }

        private void jurídicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pessoas.Frm_Cliente Pessoa = new Pessoas.Frm_Cliente();

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
                Controller.ControllerArquivoLog.GeraraLog(exc);
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

        private void cadastrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Pessoas.Frm_Cliente Pessoa = new Pessoas.Frm_Cliente();

            Pessoa.MdiParent = this;

            Pessoa.Show();
        }

        private void listarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Pessoas.Frm_ListarFisica Frm_ListarFisica = new Pessoas.Frm_ListarFisica();

            Frm_ListarFisica.MdiParent = this;

            Frm_ListarFisica.Show();
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
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void excluirToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            
        }

        private void reportarBugsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Report frm_Report = new Frm_Report();

            frm_Report.MdiParent = this;

            frm_Report.Show();
        }

        private void emailBaseOrçamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_EmailBaseOrcamento frm_EmailBaseOrcamento = new Frm_EmailBaseOrcamento();

            frm_EmailBaseOrcamento.MdiParent = this;

            frm_EmailBaseOrcamento.Show();
        }

        private void ordemDeServiçoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Frm_ImprimirOS Imprimir = new Frm_ImprimirOS();

            Imprimir.MdiParent = this;

            Imprimir.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Frm_Cliente frm_cliente = new Frm_Cliente();

            frm_cliente.MdiParent = this;

            frm_cliente.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Frm_ListarFisica frm_ListarCliente = new Frm_ListarFisica();

            frm_ListarCliente.MdiParent = this;

            frm_ListarCliente.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_ExcluirPessoaFisica frm_ExcluirPessoa = new Frm_ExcluirPessoaFisica();

            frm_ExcluirPessoa.MdiParent = this;

            frm_ExcluirPessoa.Show();
        }
    }
}
