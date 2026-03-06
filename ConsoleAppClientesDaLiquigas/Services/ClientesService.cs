using ConsoleAppClientesDaLiquigas.Data;
using ConsoleAppClientesDaLiquigas.Model;
using ConsoleAppStudent;
using System;
using System.Linq;

namespace ConsoleAppClientesDaLiquigas.Services
{
    public class ClientesService
    {
        private ClientesRepository _clientesRepository;

        public ClientesService(ClientesRepository clientesRepository)
        {
            _clientesRepository = clientesRepository;
        }

        public void ListarClientes()
        {
            var clientes = _clientesRepository.ObterClientes();

            var queryListaPedidos = clientes.SelectMany(auxClientes => auxClientes.TabelaDePrecos, (auxClientes, TabelaDePrecos) => new
            {
                auxClientes.Id,
                auxClientes.NomeCompleto,
                auxClientes.Cpf,
                auxClientes.Endereco,
                auxClientes.Bairro,
                auxClientes.Idade,
                auxClientes.DataCadastro,
                auxClientes.DataCancelamentoCadastro,
                TabelaDePrecos.PesoDoBotijao,
                TabelaDePrecos.PrecoDoBotijao,
                TabelaDePrecos.QtdDeBotijao
            });

            ExportData.ExportarCsv(queryListaPedidos, "ListaDosClientes");

            foreach (var obj in queryListaPedidos)
            {
                Console.WriteLine(obj);
            }
        }

        public static string ObterDataAtual()
        {
            return String.Format($"{DateTime.Now}\n");
        }

        public int ObterTotalClientes()
        {
            var clientes = _clientesRepository.ObterClientes();

            int contador = clientes.Count();

            return contador;
        }

        public int CalcularDiasCancelamento()
        {
            int diferencaEmDias = 0;

            var clientes = _clientesRepository.ObterClientes();

            Console.WriteLine("Clientes Com Data de Cancelamento de Cadastro >>> \n");

            var validaEstaAtivoOuNao = clientes.Exists(val => val.DataCancelamentoCadastro == null && val.EstaAtivo == true);

            if (validaEstaAtivoOuNao)
            {
                Console.WriteLine("Não existem clientes cancelados na base");
            }
            else
            {
                foreach (var item in clientes)
                {
                    if (item.DataCadastro != null && item.DataCancelamentoCadastro != null)
                    {
                        System.TimeSpan difDatas = ((TimeSpan)(item.DataCancelamentoCadastro - item.DataCadastro));

                        double auxDifEmDias = difDatas.TotalDays;

                        Console.WriteLine(string.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8}", item.Id, item.NomeCompleto, item.Cpf, item.Endereco,
                        item.Bairro, item.Idade + " anos ", item.DataCadastro, item.DataCancelamentoCadastro, auxDifEmDias + " dias cancelado "));
                    }

                }

            }
            return diferencaEmDias;
        }
    }
}
