using System;

namespace ViewConsole
{
    internal class PessoaFisica
    {
        public void NovaPessoaFisica()
        {
            Model.Pessoa_e_Usuario.Fisica PessoaFBase = new Model.Pessoa_e_Usuario.Fisica();
            EntradaDeDados.Variaveis EntradaVariaveis = new EntradaDeDados.Variaveis();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("                                                  Cadastro de pessoa física");

            Console.Write("Nome: ");
            PessoaFBase.Nome = EntradaVariaveis.LeString();

            Console.Write("Endereço: ");
            PessoaFBase.Endereco = EntradaVariaveis.LeString();

            Console.Write("Telefone: ");
            PessoaFBase.Telefone = EntradaVariaveis.LeString();

            Console.Write("Situação: ");
            PessoaFBase.Situacao = EntradaVariaveis.LeString();

            Console.Write("Sigla do estado: ");
            PessoaFBase.SiglaEstado = EntradaVariaveis.LeString();

            Console.Write("Cidade: ");
            PessoaFBase.Cidade = EntradaVariaveis.LeString();

            Console.Write("Bairro: ");
            PessoaFBase.Bairro = EntradaVariaveis.LeString();

            Console.Write("CEP: ");
            PessoaFBase.Cep = EntradaVariaveis.LeString(); //TODO: Arrumar uma forma de verificar se o dgitado esta no formato certo.

            Console.Write("Observações: ");
            PessoaFBase.Observacoes = EntradaVariaveis.LeString();

            //Parte de Pessoa Física
            Console.Write("CPF: ");
            PessoaFBase.CPF = EntradaVariaveis.LeString(); //TODO: Arrumar uma forma de verificar se o dgitado esta no formato certo.

            Console.Write("Celular: ");
            PessoaFBase.Celular = EntradaVariaveis.LeString();

            Console.Write("Sexo: ");
            PessoaFBase.Sexo = EntradaVariaveis.LeString();//TODO: Arrumar o LeSexo da minha biblioteca.

            Console.Write("Data de nascimento: ");  //TODO: Arrumar um modo de não salvar o horario apenas a data.        
            PessoaFBase.DataDeNascimento = EntradaVariaveis.LeDateTame();

            Console.WriteLine(" "); 

            //A função Save() Retona uma string infomando sobre o que ocorreu.
            Console.WriteLine(PessoaFBase.Save(PessoaFBase.Nome, PessoaFBase.Endereco, PessoaFBase.Telefone, PessoaFBase.Situacao, PessoaFBase.SiglaEstado, PessoaFBase.Cidade, PessoaFBase.Bairro, PessoaFBase.Cep, PessoaFBase.Observacoes, PessoaFBase.CPF, PessoaFBase.Celular, PessoaFBase.Sexo, PessoaFBase.DataDeNascimento));



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

        public void ListarPessoaFisica()
        {
            Model.Pessoa_e_Usuario.Fisica PessoaFisicaBase = new Model.Pessoa_e_Usuario.Fisica();
            EntradaDeDados.Variaveis EntradaVariaveis = new EntradaDeDados.Variaveis();

            // "Mostrando o "cabeçalho" de como vão ficar ordenadas as informações.
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Nome / Celular / CPF / Cidade / Situação ");
            Console.WriteLine("_____________________________________________________________________________________________________________________");

            Console.ForegroundColor = ConsoleColor.Gray;
            //Fazendo busca geral (buscando o nome de todas as pessoas físicas) e logo apos carregando as informações de cada Pessoa.
            foreach (var item in PessoaFisicaBase.LoadList())
            {
                Console.WriteLine(" ");
                Console.WriteLine(" {0} / {1} / {2} / {3} / {4}",PessoaFisicaBase.Load(item).Nome, PessoaFisicaBase.Load(item).Celular, PessoaFisicaBase.Load(item).CPF, PessoaFisicaBase.Load(item).Cidade,PessoaFisicaBase.Load(item).Situacao);
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

        public void CarregarPessoaFisica()
        {
            Model.Pessoa_e_Usuario.Fisica PessoaFisicaBase = new Model.Pessoa_e_Usuario.Fisica();
            EntradaDeDados.Variaveis EntradaVariaveis = new EntradaDeDados.Variaveis();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("  Digite o nome da pessoa física: ");
            String Nome = EntradaVariaveis.LeString();
            Console.WriteLine(" ");


            if (PessoaFisicaBase.Verificar(Nome))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                // "Mostrando o "cabeçalho" de como vão ficar ordenadas as informações
                Console.WriteLine(" Nome / Celular / CPF / Cidade / Situação ");
                Console.WriteLine("_____________________________________________________________________________________________________________________");

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(" ");
                Console.WriteLine(" {0} / {1} / {2} / {3} / {4}", PessoaFisicaBase.Load(Nome).Nome, PessoaFisicaBase.Load(Nome).Celular, PessoaFisicaBase.Load(Nome).CPF, PessoaFisicaBase.Load(Nome).Cidade, PessoaFisicaBase.Load(Nome).Situacao);
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Pessoa física {0} não encontrada",Nome);
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
            if(Verificador == 3)
            {
                Console.Clear();
                CarregarPessoaFisica();
            }
        }
    }
}
