using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using Controller;

namespace View
{
    public partial class Frm_Backup : Form
    {
        public Frm_Backup()
        {
            InitializeComponent();
        }

        private void Btm_Salvar_Click(object sender, EventArgs e)
        {
            List<string> Diretorios = new List<string>();

            Diretorios.Add("Os/");
            Diretorios.Add("Pessoa/");
            Diretorios.Add("Usuario/");
            Diretorios.Add("ServicosBase/");
            Diretorios.Add("Email.dat");
            Diretorios.Add("Menssagem.dat");
            Diretorios.Add("Logo.png");
            Diretorios.Add("Empresa.CFG");
            Diretorios.Add("Log.txt");

            ControllerBackup.CriarArquivoZip(Diretorios, string.Format("Backup.rar"));

            MessageBox.Show(String.Format("Backup criado com sucesso no diretorio do seu software"), "Inormação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Btm_Carregar_Click(object sender, EventArgs e)
        {
            string diretorio = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);

            openFileDialog1.ShowDialog();

            string saida = ControllerBackup.ExtrairArquivoZip(openFileDialog1.FileName, diretorio);

            MessageBox.Show(saida, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}