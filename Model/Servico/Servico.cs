namespace Model.Ordem_de_Servico
{
    public class Servico
    {
        private string descricao;
        private string servicoBase;
        private string tecnico;
        private double valor;

        public string Descricao
        {
            get
            {
                return descricao;
            }

            set
            {
                descricao = value;
            }
        }

        public string ServicoBase
        {
            get
            {
                return servicoBase;
            }

            set
            {
                servicoBase = value;
            }
        }

        public string Tecnico
        {
            get
            {
                return tecnico;
            }

            set
            {
                tecnico = value;
            }
        }

        public double Valor
        {
            get
            {
                return valor;
            }

            set
            {
                valor = value;
            }
        }
    }
}
