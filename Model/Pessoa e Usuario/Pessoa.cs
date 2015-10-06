namespace Model.Pessoa_e_Usuario
{
     public class Pessoa
    {
        private string nome;
        private string endereco;
        private string telefone;
        private char situacao;       //Para a situação usar apenas V para esta tudo certo e F para esta pendente (Devendo).
        private char tipo;            //Para a situação usar apenas F ou J (Pessoa Fisica ou Jurídica).
        private string siglaEstado;
        private string cidade;
        private string bairro;
        private string cep;
        private string observacoes;

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

        public string Endereco
        {
            get
            {
                return endereco;
            }

            set
            {
                endereco = value;
            }
        }

        public string Telefone
        {
            get
            {
                return telefone;
            }

            set
            {
                telefone = value;
            }
        }

        public char Situacao
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

        public char Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }

        public string SiglaEstado
        {
            get
            {
                return siglaEstado;
            }

            set
            {
                siglaEstado = value;
            }
        }

        public string Cidade
        {
            get
            {
                return cidade;
            }

            set
            {
                cidade = value;
            }
        }

        public string Bairro
        {
            get
            {
                return bairro;
            }

            set
            {
                bairro = value;
            }
        }

        public string Cep
        {
            get
            {
                return cep;
            }

            set
            {
                cep = value;
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
