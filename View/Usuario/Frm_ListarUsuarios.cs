using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Model.Pessoa_e_Usuario.Usuario UsuarioBase = new Model.Pessoa_e_Usuario.Usuario();

            foreach (var item in UsuarioBase.LoadList())
            {
                Data_Os.Rows.Add(UsuarioBase.Load(item).Nome, UsuarioBase.Load(item).NivelAcesso);
            }
        }
    }
}
