using System;
using System.Windows.Forms;
using Controller;
using System.Data;

namespace View.OS
{
    public partial class Frm_ListarOS : Form
    {
        public Frm_ListarOS(int IdTecnico)
        {
            InitializeComponent();

            v_IDTecnico = IdTecnico;
        }

        private int v_IDTecnico;

        private void Frm_ListarOS_Load(object sender, EventArgs e)
        {
            AualizarGridSemFiltro();
            AtualizarListaDeClientes();

            comboBox_FiltroInicial.Text = comboBox_FiltroInicial.Items[0].ToString();
            comboBoxStatus.Text = comboBoxStatus.Items[0].ToString();
        }

        private void Data_Os_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int IdOs = int.Parse(Data_Os.CurrentRow.Cells[0].Value.ToString());
            Frm_EditarOS frm_Editaros = new Frm_EditarOS(v_IDTecnico, IdOs);

            frm_Editaros.ShowDialog();
        }

        private void Btm_Atualizar_Click(object sender, EventArgs e)
        {
            if (checkBox_Filtro.Checked == true)
            {
                AualizarGridComFiltro();
            }
            else
            {
                AualizarGridSemFiltro();
                AtualizarListaDeClientes();
            }
        }

        private void AualizarGridSemFiltro()
        {
            Data_Os.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            Data_Os.DataSource = ControllerOrdemServico.CarregarLista();

            Data_Os.Columns[2].HeaderText = "Numero de Serie";
            Data_Os.Columns[4].HeaderText = "Data de Entrada";
        }

        private void AualizarGridComFiltro()
        {
            string ComandoSQL;
            int IDCliente = ControllerPessoa.VerificarID(comboBox_Clientes.Text);

            if (comboBoxStatus.Text == "É")
            {
                ComandoSQL = "=";
            }
            else
            {
                ComandoSQL = "<>";
            }

            Data_Os.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            Data_Os.DataSource = ControllerOrdemServico.CarregarListaComFiltroDePesquisa(ComandoSQL, IDCliente);

            Data_Os.Columns[2].Name = "Numero de Serie";
            Data_Os.Columns[4].Name = "Data de Entrada";
        }

        private void AtualizarListaDeClientes()
        {
            comboBox_Clientes.Items.Clear();

            DataTable tabela = new DataTable("ListaDeNomes");
            tabela = ControllerPessoa.CarregarListaDeNomes();


            if (tabela.Rows.Count != 0)
            {
                foreach (DataRow r in tabela.Rows)
                {
                    foreach (DataColumn c in tabela.Columns)
                    {
                        comboBox_Clientes.Items.Add(r[c].ToString());
                    }
                }
                comboBox_Clientes.Text = comboBox_Clientes.Items[0].ToString();
            }
        }
    }
}
