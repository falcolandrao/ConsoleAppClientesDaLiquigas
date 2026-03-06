using ConsoleAppClientesDaLiquigas.Data;
using ConsoleAppClientesDaLiquigas.Services;
using System;

namespace ConsoleAppClientesDaLiquigas
{
    class Program
    {
        static void Main(string[] args)
        {

            var clientesRepository = new ClientesRepository();
            
            var clientesService = new ClientesService(clientesRepository);

            var dataExecucao = ClientesService.ObterDataAtual();

            int opcaoSelecionada;

            Console.WriteLine("Digite 1 - Para Listar e exportar os clientes \n");
            Console.WriteLine("Digite 2 - Para Validar total de dias que determinado cliente cancelou o cadastro \n");

            opcaoSelecionada = Convert.ToInt32(Console.ReadLine());

            try
            {
                switch (opcaoSelecionada)
                {
                    case 1:

                        Console.WriteLine("Lista dos Clientes da Liquigas >>> \n");

                        Console.WriteLine(dataExecucao);

                        clientesService.ListarClientes();

                        Console.WriteLine("\n");

                        Console.WriteLine("Total de Clientes {0} \n ", clientesService.ObterTotalClientes());

                        Console.WriteLine("\n");
                        break;

                    case 2:

                        clientesService.CalcularDiasCancelamento();
                        break;

                    default:
                        Console.WriteLine("Digito invalido");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            Console.ReadKey();
        }
    }
}