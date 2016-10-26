namespace Model.Pessoa_e_Usuario
{
     public class Pessoa
    {
        public int ID {get;set;}
        public string Nome {get;set;}
        public string Tipo {get;set;}
        public string Email { get; set; }
		public string Logradouro {get;set;}
        public string Complemento { get; set; }
        public string SiglaEstado {get;set;}
        public string Cidade {get;set;}
        public string Bairro {get;set;}
        public string Cep {get;set;}
        public bool Status {get;set;}

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