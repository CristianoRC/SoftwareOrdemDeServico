namespace Model.Pessoa_e_Usuario
{
     public abstract class Pessoa
    {
        private string nome;
        private string endereco;
        private string telefone;
        private string situacao;
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
