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
            ControllerEmail controllerEmail = new ControllerEmail();

            controllerEmail.SaveEmailBase(Txt_EmailBase.Text);

            MessageBox.Show(controllerEmail.SaveEmailBase(Txt_EmailBase.Text), "Indormação", MessageBoxButtons.OK, MessageBoxIcon.Information); //Mostrando o resultado da função SaveEmailBase.
        }

        private void Frm_EmailBase_Load(object sender, EventArgs e)
        {
            ControllerEmail controllerEmail = new ControllerEmail();

            Txt_EmailBase.Text = controllerEmail.LoadEmailBase();
        }
    }
}
