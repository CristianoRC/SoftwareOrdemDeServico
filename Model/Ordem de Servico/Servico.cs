namespace Model.Ordem_de_Servico
{
    public class Servico
    {
        private string descricao;
        private double valor;

        //TODO:Organizar essa classe depois de criado as ordens de servico em arquivos, Calcular o Valor e pegar a descrição do arquivo;

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
