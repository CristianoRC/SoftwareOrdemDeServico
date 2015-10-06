using System;

namespace Model.Negocios
{
    public class ContasReceber
    {
        private int quantidadeParcelas;
        private DateTime dataVencimento;
        private DateTime dataPagamento;
        private int numeroParcela;

        public int QuantidadeParcelas
        {
            get
            {
                return quantidadeParcelas;
            }

            set
            {
                quantidadeParcelas = value;
            }
        }

        public DateTime DataVencimento
        {
            get
            {
                return dataVencimento;
            }

            set
            {
                dataVencimento = value;
            }
        }

        public DateTime DataPagamento
        {
            get
            {
                return dataPagamento;
            }

            set
            {
                dataPagamento = value;
            }
        }

        public int NumeroParcela
        {
            get
            {
                return numeroParcela;
            }

            set
            {
                numeroParcela = value;
            }
        }

    }
}
