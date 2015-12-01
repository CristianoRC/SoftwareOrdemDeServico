namespace Model
{
    public class Email
    {
        private string email;
        private string senha;
        private string host;
        private int port;


        public string EnderecoEmail
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }
        public string Senha
        {
            get
            {
                return senha;
            }

            set
            {
                senha = value;
            }
        }
        public string Host
        {
            get
            {
                return host;
            }

            set
            {
                host = value;
            }
        }
        public int Port
        {
            get
            {
                return port;
            }

            set
            {
                port = value;
            }
        }

        public static object Attachments { get; set; }
    }
}
