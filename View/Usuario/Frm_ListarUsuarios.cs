using System;
using Controller;
using System.Windows.Forms;

namespace View.Usuario
{
    public partial class Frm_ListarUsuarios : Form
    {
        public Frm_ListarUsuarios()
        {
            InitializeComponent();
        }

        private void Frm_ListarUsuarios_Load(object sender, EventArgs e)
        {
            foreach (var item in ControllerUsuario.LoadList())
            {
                Data_Os.Rows.Add(ControllerUsuario.Load(item).Nome, ControllerUsuario.Load(item).NivelAcesso);
            }
        }
    }
}
