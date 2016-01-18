using System;
using Controller;
using System.Windows.Forms;

namespace View
{
    public partial class Frm_EmailBaseOrcamento : Form
    {
        public Frm_EmailBaseOrcamento()
        {
            InitializeComponent();
        }

        private void códigosHTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Abrindo site com os códigos HTML
            System.Diagnostics.Process.Start(@"http://codigofonte.uol.com.br/artigos/principais-tags-de-html");
        }

        private void Frm_EmailBaseOrcamento_Load(object sender, EventArgs e)
        {
            Txt_EmailBase.Text = ControllerEmail.LoadEmailBaseOrcamento();
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControllerEmail.SaveEmailBaseOrcamento(Txt_EmailBase.Text);
        }
    }
}
