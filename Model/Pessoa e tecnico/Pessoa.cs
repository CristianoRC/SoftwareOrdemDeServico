using System;

namespace Model.Pessoa_e_Usuario
{
     public class Pessoa
    {
        public string ID {get;set;}
        public string Nome {get;set;}
        public string Tipo {get;set;}
        public string Endereco {get;set;}
        public string Email {get;set;}
        public string SiglaEstado {get;set;}
        public string Cidade {get;set;}
        public string Bairro {get;set;}
        public string Cep {get;set;}

        //Física
        public string Sexo {get;set;}
        public string Cpf {get;set;}
        public string Celular {get;set;}
        public string DataDeNascimento {get;set;}

        //Jurídica

        public string RazaoSocial {get;set;}
        public string Cnpj {get;set;}
        public string Contato {get;set;}
        public string InscricaoEstadual {get;set;}
    }
}