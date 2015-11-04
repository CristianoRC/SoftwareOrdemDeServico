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
    public partial class Frm_EmailBase : Form
    {
        public Frm_EmailBase()
        {
            InitializeComponent();
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Model.Email EmailBase = new Model.Email();

            EmailBase.SaveEmailBase(Txt_EmailBase.Text);

            MessageBox.Show(EmailBase.SaveEmailBase(Txt_EmailBase.Text), "Indormação", MessageBoxButtons.OK, MessageBoxIcon.Information); //Mostrando o resultado da função SaveEmailBase.
        }

        private void Frm_EmailBase_Load(object sender, EventArgs e)
        {
            Model.Email EmailBase = new Model.Email();

            Txt_EmailBase.Text = EmailBase.LoadEmailBase();
        }
    }
}
