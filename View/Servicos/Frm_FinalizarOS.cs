using System;
using System.Windows.Forms;
using Model.Ordem_de_Servico;
using Controller;
using Model.Pessoa_e_Usuario;
using Model;

namespace View
{
    public partial class Frm_Servico : Form
    {
        public Frm_Servico(string nomeDoTecnico)
        {
            InitializeComponent();
        }


        /// <summary>
        /// Finalizando Ordem de serviço (Botão).
        /// </summary>
        private void finalizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }


        /// <summary>
        /// Carregando o nome de todos os serviços e os adicionando no combo Box(Txt_Servicos).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Servico_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Carregando o valor do serviço para o TextBox(Usado para valores) cada vez que o algo é selecionado no TextBox dos serviços;
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_Servico_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
