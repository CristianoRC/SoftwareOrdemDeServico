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
            ControllerUsuario controllerUsuario = new ControllerUsuario();

            foreach (var item in controllerUsuario.LoadList())
            {
                Data_Os.Rows.Add(controllerUsuario.Load(item).Nome, controllerUsuario.Load(item).NivelAcesso);
            }
        }
    }
}
