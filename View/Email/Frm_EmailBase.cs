using System;
using Controller;
using System.Windows.Forms;

namespace View
{
    public partial class Frm_EmailBase : Form
    {
        public Frm_EmailBase()
        {
            InitializeComponent();
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Resultado = ControllerEmail.SalvarEmailFinalizacaoOS(Txt_EmailBase.Text);

            MessageBox.Show(Resultado ,"Indormação", MessageBoxButtons.OK, MessageBoxIcon.Information); //Mostrando o resultado da função SaveEmailBase.
        }

        private void Frm_EmailBase_Load(object sender, EventArgs e)
        {
            Txt_EmailBase.Text = ControllerEmail.CarregarEmailFinalizacaoOS();
        }

        private void Txt_EmailBase_TextChanged(object sender, EventArgs e)
        {

        }

        private void códigosHTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Abrindo site com os códigos HTML
            System.Diagnostics.Process.Start(@"http://codigofonte.uol.com.br/artigos/principais-tags-de-html");
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
