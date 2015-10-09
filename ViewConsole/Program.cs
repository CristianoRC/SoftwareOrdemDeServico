using System;
using System.Collections.Generic;
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
            Console.WriteLine("  3- Finalizar Ordem de serviço");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("_______________________________________________________________________________________________________________________");

            Console.WriteLine(" ");
            Console.WriteLine("                                                      Pessoa Física");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  4- Nova Pessoa Física");
            Console.WriteLine("  5- Listar Pessoa Física");
            Console.WriteLine("  6- Excluir Pessoa Física");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("________________________________________________________________________________________________________________________");


            Console.WriteLine(" ");
            Console.WriteLine("                                                     Pessoa Jurídica");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  6- Nova Pessoa Jurídica");
            Console.WriteLine("  7- Listar Pessoa Jurídica");
            Console.WriteLine("  8- Excluir Pessoa Jurídica");

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
                case 1:
                    Console.Clear();
                    NovaOrdem();
                    break;

                default:
                    //Apenas ira fechar a aplicação.                  
                    break;
            }
        }

        static void NovaOrdem()
        {
            Model.Ordem_de_Servico.OrdemServico OSBase = new Model.Ordem_de_Servico.OrdemServico();
            EntradaDeDados.Variaveis EntradaVariaveis = new EntradaDeDados.Variaveis();
            //-------------------------------------- Parte que o usuario não precisa digitar -----------------------------

            Random R = new Random();
            OSBase.Identificador = R.Next(999999999).ToString();
            OSBase.DataEntradaServico = DateTime.Now.ToString();


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                                    **  Nova ordem de serviço  **");

            Console.WriteLine(" ");
            Console.WriteLine(" ");


            Console.WriteLine(string.Format("Numero da ordem de serviço: {0}", OSBase.Identificador));
            Console.WriteLine(string.Format("Data de entrada da ordem de serviço: {0}", OSBase.DataEntradaServico.ToString()));
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Digite o nome do cliente: ");
            OSBase.Cliente = EntradaVariaveis.LeString();
            Console.WriteLine(" ");

            Console.Write("Digite o nome do equipamento: ");
            OSBase.Equipamento = EntradaVariaveis.LeString();
            Console.WriteLine(" ");

            Console.Write("Digite o defeito do equipamento: ");
            OSBase.Defeito = EntradaVariaveis.LeString();
            Console.WriteLine(" ");

            Console.Write("Digite a descrição: ");
            OSBase.Descricao = EntradaVariaveis.LeString();
            Console.WriteLine(" ");

            Console.Write("Digite o numero de série do equipamento: ");
            OSBase.NumeroSerie = EntradaVariaveis.LeString();
            Console.WriteLine(" ");

            Console.Write("Digite observações se houver: ");
            OSBase.Observacao = EntradaVariaveis.LeString();
            Console.WriteLine(" ");

            Console.Write("Digite a referencia: ");
            OSBase.Referencia = EntradaVariaveis.LeString();
            Console.WriteLine(" ");

            Console.Write("Digite a situação (Avaliação/Manutenção): ");
            OSBase.Situacao = EntradaVariaveis.LeString();
            Console.WriteLine(" ");

            OSBase.Save(OSBase.Identificador, OSBase.Referencia, OSBase.Situacao, OSBase.Defeito, OSBase.Descricao,OSBase.Observacao, OSBase.NumeroSerie, OSBase.Equipamento, OSBase.DataEntradaServico, OSBase.Cliente);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ordem de serviço salva com sucesso."); //Problemas em retornar o valor da função salvar();

            Console.ReadKey();

            Console.WriteLine("  1- Ir para o menu");
            Console.WriteLine("  2- Sar");
            int Verificador = EntradaVariaveis.LeInt();
            if(Verificador == 1)
            {
                Console.Clear();

                MenuPrincipal();
            }

            //Implementar sistema de pergunta se quer voltar para o "Menu".
        }
    }
}
