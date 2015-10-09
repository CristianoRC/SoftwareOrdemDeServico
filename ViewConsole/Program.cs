using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuPrincipal();

            
        }

        static void MenuPrincipal()
        {

            EntradaDeDados.Variaveis EntradaVariaveis = new EntradaDeDados.Variaveis();
            short Resultado;

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("                                    **  Software de Ordem de serviço 1.0  **");

            Console.WriteLine(" ");
            Console.WriteLine(" ");

            Console.WriteLine("                                                   Ordem de serviço");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  1- Nova Ordem de serviço");
            Console.WriteLine("  2- Listar Ordens de serviço");
            Console.WriteLine("  3- Editar Ordem de serviço");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("_______________________________________________________________________________________________________________________");

            Console.WriteLine(" ");
            Console.WriteLine("                                                      Pessoa Física");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  4- Nova Pessoa Física");
            Console.WriteLine("  5- Listar Pessoa Física");
            Console.WriteLine("  6- Editar Pessoa Física");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("________________________________________________________________________________________________________________________");


            Console.WriteLine(" ");
            Console.WriteLine("                                                     Pessoa Jurídica");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  6- Nova Pessoa Jurídica");
            Console.WriteLine("  7- Listar Pessoa Jurídica");
            Console.WriteLine("  8- Editar Pessoa Jurídica");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("________________________________________________________________________________________________________________________");

            Console.WriteLine(" ");
            Console.WriteLine("                                                          Outros");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  9- Sobre");
            Console.WriteLine("  0- Sair");

            
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.Write("  Digite o valor para ir para uma dessas opções acima: ");

            Resultado = EntradaVariaveis.LeShort();


            //TODO: Implementar o sistema de MENU lgo após de implementar as funçoes

            switch (Resultado)
            {
                default:
                    //Apenas ira fechar a aplicação.                  
                    break;
            }
        }
    }
}
