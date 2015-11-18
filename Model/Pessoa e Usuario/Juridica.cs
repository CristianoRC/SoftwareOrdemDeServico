namespace Model.Pessoa_e_Usuario
{
    public class Juridica : Pessoa
    {
        private string razaoSocial;
        private string cnpj;
        private string contato;
        private string inscricaoEstadual;

        public string RazaoSocial
        {
            get
            {
                return razaoSocial;
            }

            set
            {
                razaoSocial = value;
            }
        }
        public string Cnpj
        {
            get
            {
                return cnpj;
            }

            set
            {
                cnpj = value;
            }
        }
        public string Contato
        {
            get
            {
                return contato;
            }

            set
            {
                contato = value;
            }
        }
        public string InscricaoEstadual
        {
            get
            {
                return inscricaoEstadual;
            }

            set
            {
                inscricaoEstadual = value;
            }
        }
    }
}
