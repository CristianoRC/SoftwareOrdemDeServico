using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using System.IO;

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
            Model.Backup backup = new Model.Backup();
            List<string> Diretorios = new List<string>();

            Diretorios.Add("Os/");
            Diretorios.Add("Pessoa/");
            Diretorios.Add("Usuario/");
            Diretorios.Add("Produto/");

            backup.CriarArquivoZip(Diretorios, string.Format("Backup.rar"));

            MessageBox.Show(String.Format("Backup criado com sucesso no diretorio do seu softwar", DateTime.Now), "Inormação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Btm_Carregar_Click(object sender, EventArgs e)
        {
            Model.Backup backup = new Model.Backup();

            string diretorio = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);

            openFileDialog1.ShowDialog();

            backup.ExtrairArquivoZip(openFileDialog1.FileName, diretorio);

            MessageBox.Show(String.Format("Backup recuperado com sucesso!"), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}