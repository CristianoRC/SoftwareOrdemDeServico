using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Model.Ordem_de_Servico
{
    public class OrdemServico
    {
        private string identificador;
        private string referencia;
        private string situacao;
        private string defeito;
        private string descricao;
        private string observacao;
        private string numeroSerie;
        private string equipamento;
        private string dataEntradaServico;
        private string cliente;

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

        public string Referencia
        {
            get
            {
                return referencia;
            }

            set
            {
                referencia = value;
            }
        }

        public string Situacao
        {
            get
            {
                return situacao;
            }

            set
            {
                situacao = value;
            }
        }

        public string Defeito
        {
            get
            {
                return defeito;
            }

            set
            {
                defeito = value;
            }
        }

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

        public string Observacao
        {
            get
            {
                return observacao;
            }

            set
            {
                observacao = value;
            }
        }

        public string NumeroSerie
        {
            get
            {
                return numeroSerie;
            }

            set
            {
                numeroSerie = value;
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

        public string DataEntradaServico
        {
            get
            {
                return dataEntradaServico;
            }

            set
            {
                dataEntradaServico = value;
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
    }
}
