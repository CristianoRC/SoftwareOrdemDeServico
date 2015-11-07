using System;
using System.IO;
using System.Collections.Generic;


namespace Model.Pessoa_e_Usuario
{
    public class Fisica : Pessoa
    {
        private string sexo;
        private string cpf;
        private string celular;
        private DateTime dataDeNascimento;


        public string Sexo
        {
            get
            {
                return sexo;
            }

            set
            {
                sexo = value;
            }
        }
        public string CPF
        {
            get
            {
                return cpf;
            }

            set
            {
                cpf = value;
            }
        }
        public string Celular
        {
            get
            {
                return celular;
            }

            set
            {
                celular = value;
            }
        }
        public DateTime DataDeNascimento
        {
            get
            {
                return dataDeNascimento;
            }

            set
            {
                dataDeNascimento = value;
            }
        }

    }
}
