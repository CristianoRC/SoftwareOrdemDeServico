using System;
using System.IO;
using System.Collections.Generic;

namespace Model.Pessoa_e_Usuario
{
    public class Usuario
    {
        private String nome;
        private String senha;
        private String nivelAcesso;

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
        public string NivelAcesso
        {
            get
            {
                return nivelAcesso;
            }

            set
            {
                nivelAcesso = value;
            }
        }
    }
}
