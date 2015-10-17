using System;

namespace ViewConsole
{
    internal class OrdemDeServico
    {
        public void CriarNovaOrdem()
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

            OSBase.Save(OSBase.Identificador, OSBase.Referencia, OSBase.Situacao, OSBase.Defeito, OSBase.Descricao, OSBase.Observacao, OSBase.NumeroSerie, OSBase.Equipamento, OSBase.DataEntradaServico, OSBase.Cliente);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ordem de serviço salva com sucesso."); //Problemas em retornar o valor da função salvar();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.Write("  Vose deseja imprimir a Ornde de serviço? (s/n)");
            char resposta = EntradaVariaveis.LeChar();

            if (resposta == 'S' || resposta == 's')
            {
                OSBase.Save(OSBase.Identificador, OSBase.Referencia, OSBase.Situacao, OSBase.Defeito, OSBase.Descricao, OSBase.Observacao, OSBase.NumeroSerie, OSBase.Equipamento, OSBase.DataEntradaServico, OSBase.Cliente);
            }


            Console.ReadKey();

            Console.WriteLine("  1- Ir para o menu");
            Console.WriteLine("  2- Sar");
            Console.WriteLine(" ");
            Console.Write("Digite uma das opções acima: ");
            int Verificador = EntradaVariaveis.LeInt();
            if (Verificador == 1)
            {
                Console.Clear();

                MenuPrincipal menuPrincipal = new MenuPrincipal();
                menuPrincipal.MostrarMenu();
            }
        }

        public void ListarOrdemDeServico()
        {
            Model.Ordem_de_Servico.OrdemServico OSBase = new Model.Ordem_de_Servico.OrdemServico();
            EntradaDeDados.Variaveis EntradaVariaveis = new EntradaDeDados.Variaveis();


            //"Mostrando o "cabeçalho" de como vão ficar ordenadas as informações.

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Identificador / Equipamento / Situação / Cliente / Data de entrada do serviço");
            Console.WriteLine("_____________________________________________________________________________________________________________________");


            //Fazendo busca geral (buscando o nome de todas Ordem de serviço) e logo apos carregando as informações de cada ordem de serviço.
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var item in OSBase.LoadList())
            {
                Console.WriteLine(" ");
                Console.WriteLine(" {0} / {1} / {2} / {3} / {4}", OSBase.Load(item).Identificador, OSBase.Load(item).Equipamento, OSBase.Load(item).Situacao, OSBase.Load(item).Cliente, OSBase.Load(item).DataEntradaServico);
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

        public void CarregarOrdemDeServiço()
        {
            Model.Ordem_de_Servico.OrdemServico OSBase = new Model.Ordem_de_Servico.OrdemServico();
            EntradaDeDados.Variaveis EntradaVariaveis = new EntradaDeDados.Variaveis();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("  Digite o numero da ordem de serviço: ");
            string Identificador = EntradaVariaveis.LeString();
            Console.WriteLine("_____________________________________________________________________________________________________________________");
            Console.WriteLine(" ");

            //Ira verificar se a ordem de serviço existe ou não.
            if (OSBase.Verificar(Identificador))
            {
                OSBase = OSBase.Load(Identificador);
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine("  Numero da ordem de serviço: {0}", OSBase.Identificador);
                Console.WriteLine("  Cliente: {0} ", OSBase.Cliente);
                Console.WriteLine("  Equipamento: {0}", OSBase.Equipamento);
                Console.WriteLine("  Situação: {0}", OSBase.Situacao);
                Console.WriteLine("  Numero de serie: {0}", OSBase.NumeroSerie);
                Console.WriteLine("  Defeito: {0} ", OSBase.Defeito);
                Console.WriteLine("  Referencia: {0}", OSBase.Referencia);
                Console.WriteLine("  Data de entrada: {0} ", OSBase.DataEntradaServico);
                Console.WriteLine("  Observações: {0}", OSBase.Observacao);
                Console.WriteLine("  Descrição: {0}", OSBase.Descricao);

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.Write("  Vose deseja imprimir a Ornde de serviço? (s/n)");
                char resposta = EntradaVariaveis.LeChar();

                if (resposta == 'S' || resposta == 's')
                {
                    OSBase.CreatPDF(OSBase.Identificador, OSBase.Referencia, OSBase.Situacao, OSBase.Defeito, OSBase.Descricao, OSBase.Observacao, OSBase.NumeroSerie, OSBase.Equipamento, OSBase.DataEntradaServico, OSBase.Cliente);
                }
            }
            else
            {
                Console.WriteLine("Ordem de serviço não encontrada");
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
                CarregarOrdemDeServiço();
            }
        }

        public void imprimir()
        {
            Model.Ordem_de_Servico.OrdemServico OSBase = new Model.Ordem_de_Servico.OrdemServico();
            EntradaDeDados.Variaveis EntradaVariaveis = new EntradaDeDados.Variaveis();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("  Digite o numero da ordem de serviço: ");
            string Identificador = EntradaVariaveis.LeString();
            Console.WriteLine("_____________________________________________________________________________________________________________________");
            Console.WriteLine(" ");

            //Ira verificar se a ordem de serviço existe ou não.
            if (OSBase.Verificar(Identificador))
            {
                OSBase = OSBase.Load(Identificador);
                Console.ForegroundColor = ConsoleColor.Gray;
                
                OSBase.CreatPDF(OSBase.Identificador, OSBase.Referencia, OSBase.Situacao, OSBase.Defeito, OSBase.Descricao, OSBase.Observacao, OSBase.NumeroSerie, OSBase.Equipamento, OSBase.DataEntradaServico, OSBase.Cliente);

                Console.WriteLine("  Ordem de seviço gerada com sucesso!");

                Console.ReadKey();

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("  Ordem de seviço não encontrada em nossa base de dados!");

                Console.ReadKey();
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
                CarregarOrdemDeServiço();
            }

        }
    }
}