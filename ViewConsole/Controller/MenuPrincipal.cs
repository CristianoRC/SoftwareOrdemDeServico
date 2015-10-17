using System;


namespace ViewConsole
{
    internal class MenuPrincipal
    {
        public void MostrarMenu()
        {

            EntradaDeDados.Variaveis EntradaVariaveis = new EntradaDeDados.Variaveis();
            short Resultado;

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("                                    **  Software de Ordem de serviço 1.0  **");

            Console.WriteLine(" ");
            Console.WriteLine(" ");

            Console.WriteLine("                                                   Ordem de serviço");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  1- Nova ordem de serviço");
            Console.WriteLine("  2- Listar ordens de serviço");
            Console.WriteLine("  3- Carregar ordem de serviço");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("_______________________________________________________________________________________________________________________");

            Console.WriteLine(" ");
            Console.WriteLine("                                                      Pessoa Física");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  4- Nova pessoa física");
            Console.WriteLine("  5- Listar pessoa física");
            Console.WriteLine("  6- Carregar pessoa física");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("________________________________________________________________________________________________________________________");


            Console.WriteLine(" ");
            Console.WriteLine("                                                     Pessoa Jurídica");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  7- Nova pessoa jurídica");
            Console.WriteLine("  8- Listar pessoa jurídica");
            Console.WriteLine("  9- Carregar pessoa jurídica");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("________________________________________________________________________________________________________________________");

            Console.WriteLine(" ");
            Console.WriteLine("                                                          Outros");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  10- Imprimir Ordem de serviço");
            Console.WriteLine("  0- Sair");


            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.Write("  Digite o valor para ir para uma dessas opções acima: ");
            Resultado = EntradaVariaveis.LeShort();


            //Instanciando as classes que serao usadas no Switch
            OrdemDeServico oS = new OrdemDeServico();
            PessoaFisica pessoaFisica = new PessoaFisica();
            PessoaJuridica pessoaJuridica = new PessoaJuridica();



            if (Resultado >= 0 && Resultado <= 10)
            {

                switch (Resultado)
                {
                    case 1:
                        Console.Clear();

                        oS.CriarNovaOrdem();
                        break;
                    case 2:
                        Console.Clear();
                        oS.ListarOrdemDeServico();
                        break;
                    case 3:
                        Console.Clear();
                        oS.CarregarOrdemDeServiço();
                        break;
                    case 4:
                        Console.Clear();
                        pessoaFisica.NovaPessoaFisica();
                        break;
                    case 5:
                        Console.Clear();
                        pessoaFisica.ListarPessoaFisica();
                        break;
                    case 6:
                        Console.Clear();
                        pessoaFisica.CarregarPessoaFisica();
                        break;
                    case 7:
                        Console.Clear();
                        pessoaJuridica.NovaPessoaJuridica();
                        break;
                    case 8:
                        Console.Clear();
                        pessoaJuridica.ListarPessoaJuridica();
                        break;
                    case 9:
                        Console.Clear();
                        pessoaJuridica.CarregarPessoaJuridica();
                        break;
                    case 10:
                        Console.Clear();
                        oS.imprimir();
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(" ");
                Console.WriteLine("  Opção {0} não encontrada", Resultado);
                Console.ReadKey();
                Console.Clear();
                MostrarMenu();
            }
        }
    }
}
