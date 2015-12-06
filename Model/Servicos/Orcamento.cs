using System;

namespace Model
{
    public class Orcamento
    {
        private string identificador;
        private string equipamento;
        private string cliente;
        private string valor;
        private string observacoes;

        public string Identificador
        {
            get
            {
                return identificador;
            }

            set
            {
                identificador = value;
            }
        }

        public string Equipamento
        {
            get
            {
                return equipamento;
            }

            set
            {
                equipamento = value;
            }
        }

        public string Cliente
        {
            get
            {
                return cliente;
            }

            set
            {
                cliente = value;
            }
        }

        public string Valor
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
    }
}
