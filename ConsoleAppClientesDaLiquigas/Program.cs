using ConsoleAppClientesDaLiquigas.Model;
using ConsoleAppStudent;
using System;
using System.Collections.Generic;

namespace ConsoleAppClientesDaLiquigas
{
    class Program
    {
        static void Main(string[] args)
        {
            var auxClientesLiquigas = Clientes.ObterTodosOsClientes();

            var auxDataHora = Clientes.DataHoraCorrente();

            int escolherNumero;

            Console.WriteLine("Digite 1 - Para Listar e exportar os clientes \n");
            Console.WriteLine("Digite 2 - Para Validar total de dias que determinado cliente cancelou o cadastro \n");

            escolherNumero = Convert.ToInt32(Console.ReadLine());

            try
            {
                switch (escolherNumero)
                {
                    case 1:

                        Console.WriteLine("Lista dos Clientes da Liquigas >>> \n");

                        Console.WriteLine(auxDataHora);

                        Clientes.EscreverDadosNaConsole(auxClientesLiquigas);

                        Console.WriteLine("\n");

                        Console.WriteLine("Total de Clientes {0} \n ", Clientes.TotalDeClientes(auxClientesLiquigas));

                        Console.WriteLine("\n");
                        break;

                    case 2:

                        Clientes.ValidaDataCancelamentoEmDias(auxClientesLiquigas);
                        break;

                    default:
                        Console.WriteLine("Digito invalido");
                        break;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            Console.ReadKey();
        }
    }
}