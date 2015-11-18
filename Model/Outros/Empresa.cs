namespace Model
{
   public class Empresa
    {

        private string nome;
        private string contato;
        private string endereco;

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
    }
}
