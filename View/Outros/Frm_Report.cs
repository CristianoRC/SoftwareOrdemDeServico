using System;
using Controller;
using System.Windows.Forms;

namespace View
{
    public partial class Frm_Report : Form
    {
        public Frm_Report()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ControllerLog controllerLog = new ControllerLog();

            String Saida = controllerLog.enviar(Txt_Report.Text);

            if (Saida == "E-mail enviado com sucesso!")
            {
                MessageBox.Show(Saida, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Txt_Report.Clear();
            }
            else
            {
                MessageBox.Show(Saida, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
