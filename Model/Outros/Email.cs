using System;
using System.IO;
using Spartacus.Utils;

namespace Model
{
    public class Email
    {
        //TODO: Sistema de enviar cópia da OS para o cliente quando ela for criada.

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

    }
}
