namespace Model
{
    /// <summary>
    /// Serviçoes basicos que a empresa faz.
    /// </summary>
    public class ServicoBase
    {
        private string nome;
        private string observacoes;
        private double valor;
        private double valoresAdicionais;

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public string Observacoes
        {
            get
            {
                return observacoes;
            }

            set
            {
                observacoes = value;
            }
        }

        public double Valor
        {
            get
            {
                return valor + valoresAdicionais; //Valor(Usado como total), vai retornar o valor dele + os valores adicionais do serviço.
            }

            set
            {
                valor = value;
            }
        }

        public double ValoresAdicionais
        {
            get
            {
                return valoresAdicionais;
            }

            set
            {
                valoresAdicionais = value;
            }
        }
    }
}
