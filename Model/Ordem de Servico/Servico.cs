using System;
using System.IO;
using System.Collections.Generic;

namespace Model.Ordem_de_Servico
{
    public class Servico
    {
        private string descricao;
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
