using System;

namespace ViewConsole
{
    internal class PessoaJuridica
    {
        public void NovaPessoaJuridica()
        {
            Model.Pessoa_e_Usuario.Juridica PessoaJBase = new Model.Pessoa_e_Usuario.Juridica();
            EntradaDeDados.Variaveis EntradaVariaveis = new EntradaDeDados.Variaveis();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                                                  Cadastro de pessoa Jurídica");


            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Nome: ");
            PessoaJBase.Nome = EntradaVariaveis.LeString();

            Console.Write("Endereço: ");
            PessoaJBase.Endereco = EntradaVariaveis.LeString();

            Console.Write("Telefone: ");
            PessoaJBase.Telefone = EntradaVariaveis.LeString();

            Console.Write("Situação: ");
            PessoaJBase.Situacao = EntradaVariaveis.LeString();

            Console.Write("Sigla do estado: ");
            PessoaJBase.SiglaEstado = EntradaVariaveis.LeString();

            Console.Write("Cidade: ");
            PessoaJBase.Cidade = EntradaVariaveis.LeString();

            Console.Write("Bairro: ");
            PessoaJBase.Bairro = EntradaVariaveis.LeString();

            Console.Write("CEP: ");
            PessoaJBase.Cep = EntradaVariaveis.LeString(); //TODO: Arrumar uma forma de verificar se o dgitado esta no formato certo.

            Console.Write("Observações: ");
            PessoaJBase.Observacoes = EntradaVariaveis.LeString();

            //Parte de Pessoa Física
            Console.Write("CNPJ: ");
            PessoaJBase.Cnpj = EntradaVariaveis.LeString(); //TODO: Arrumar uma forma de verificar se o dgitado esta no formato certo.

            Console.Write("Contato: ");
            PessoaJBase.Contato = EntradaVariaveis.LeString();

            Console.Write("Inscrição estadual: ");
            PessoaJBase.InscricaoEstadual = EntradaVariaveis.LeString();

            Console.Write("Razão social: ");       
            PessoaJBase.RazaoSocial = EntradaVariaveis.LeString();

            
            Console.WriteLine(" ");
            //A função Save() Retona uma string infomando sobre o que ocorreu.
            Console.WriteLine(PessoaJBase.Save(PessoaJBase.Nome, PessoaJBase.Endereco, PessoaJBase.Telefone, PessoaJBase.Situacao, PessoaJBase.SiglaEstado, PessoaJBase.Cidade, PessoaJBase.Bairro, PessoaJBase.Cep, PessoaJBase.Observacoes, PessoaJBase.Cnpj, PessoaJBase.Contato, PessoaJBase.InscricaoEstadual, PessoaJBase.RazaoSocial));


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("_____________________________________________________________________________________________________________________");
            Console.WriteLine(" ");
            Console.WriteLine("  1- Ir para o menu");
            Console.WriteLine("  2- Sar");
            Console.WriteLine(" ");
            Console.Write("  Digite uma das opções acima: ");
            int Verificador = EntradaVariaveis.LeInt();

            if (Verificador == 1)
            {
                Console.Clear();

                MenuPrincipal menuPrincipal = new MenuPrincipal();
                menuPrincipal.MostrarMenu();
            }

        }

        public void ListarPessoaJuridica()
        {
            Model.Pessoa_e_Usuario.Juridica PessoaJuridicaBase = new Model.Pessoa_e_Usuario.Juridica();
            EntradaDeDados.Variaveis EntradaVariaveis = new EntradaDeDados.Variaveis();

            // "Mostrando o "cabeçalho" de como vão ficar ordenadas as informações.
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Nome / Contato / CNPJ / Cidade / Situação ");
            Console.WriteLine("_____________________________________________________________________________________________________________________");

            Console.ForegroundColor = ConsoleColor.Gray;
            //Fazendo busca geral (buscando o nome de todas as pessoas físicas) e logo apos carregando as informações de cada Pessoa.
            foreach (var item in PessoaJuridicaBase.LoadList())
            {
                Console.WriteLine(" ");
                Console.WriteLine(" {0} / {1} / {2} / {3} / {4}", PessoaJuridicaBase.Load(item).Nome, PessoaJuridicaBase.Load(item).Contato, PessoaJuridicaBase.Load(item).Cnpj, PessoaJuridicaBase.Load(item).Cidade, PessoaJuridicaBase.Load(item).Situacao);
            }


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("_____________________________________________________________________________________________________________________");
            Console.WriteLine(" ");
            Console.WriteLine("  1- Ir para o menu");
            Console.WriteLine("  2- Sar");
            Console.WriteLine(" ");
            Console.Write("  Digite uma das opções acima: ");
            int Verificador = EntradaVariaveis.LeInt();

            if (Verificador == 1)
            {
                Console.Clear();

                MenuPrincipal menuPrincipal = new MenuPrincipal();
                menuPrincipal.MostrarMenu();
            }
        }

        public void CarregarPessoaJuridica()
        {
            Model.Pessoa_e_Usuario.Juridica PessoaJuridicaBase = new Model.Pessoa_e_Usuario.Juridica();
            EntradaDeDados.Variaveis EntradaVariaveis = new EntradaDeDados.Variaveis();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("  Digite o nome da pessoa física: ");
            String Nome = EntradaVariaveis.LeString();
            Console.WriteLine(" ");


            if (PessoaJuridicaBase.Verificar(Nome))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                // "Mostrando o "cabeçalho" de como vão ficar ordenadas as informações
                Console.WriteLine(" Nome / Contato / CNPJ / Cidade / Situação ");
                Console.WriteLine("_____________________________________________________________________________________________________________________");

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(" ");
                Console.WriteLine(" {0} / {1} / {2} / {3} / {4}", PessoaJuridicaBase.Load(Nome).Nome, PessoaJuridicaBase.Load(Nome).Contato, PessoaJuridicaBase.Load(Nome).Cnpj, PessoaJuridicaBase.Load(Nome).Cidade, PessoaJuridicaBase.Load(Nome).Situacao);
 
        }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Pessoa Jurídica {0} não encontrada", Nome);
            }


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("_____________________________________________________________________________________________________________________");
            Console.WriteLine(" ");
            Console.WriteLine("  1- Ir para o menu");
            Console.WriteLine("  2- Sar");
            Console.WriteLine("  3- Repetir operação");
            Console.WriteLine(" ");
            Console.Write("  Digite uma das opções acima: ");
            int Verificador = EntradaVariaveis.LeInt();

            if (Verificador == 1)
            {
                Console.Clear();

                MenuPrincipal menuPrincipal = new MenuPrincipal();
                menuPrincipal.MostrarMenu();
            }
            if (Verificador == 3)
            {
                Console.Clear();
                CarregarPessoaJuridica();
            }
        }
    }
}
