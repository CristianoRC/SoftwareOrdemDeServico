using System;

namespace Model.Negocios
{
    public class ContasPagar
    {
        private int quantidadeParcelas;
        private DateTime dataVencimento;
        private DateTime dataPagamento;
        private int numeroParcelaAtual;
        private double desconto;
        private double juros;
        private double valorPago;
        private double valorConta;



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

        public double Desconto
        {
            get
            {
                return desconto;
            }

            set
            {
                desconto = value;
            }
        }

        public double Juros
        {
            get
            {
                return juros;
            }

            set
            {
                juros = value;
            }
        }

        public double ValorPago
        {
            get
            {
                return valorPago;
            }

            set
            {
                valorPago = value;
            }
        }

        public double ValorConta
        {
            get
            {
                return valorConta;
            }

            set
            {
                valorConta = value;
            }
        }

        public int NumeroParcelaAtual
        {
            get
            {
                return numeroParcelaAtual;
            }

            set
            {
                numeroParcelaAtual = value;
            }
        }
    }
}
