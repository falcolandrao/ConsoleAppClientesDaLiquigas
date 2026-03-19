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

            return clientes.Count();
        }

        public int ExibirDiasCancelamento()
        {
            var clientes = _clientesRepository.ObterClientes();

            Console.WriteLine("Clientes Com Data de Cancelamento de Cadastro >>> \n");

            var clientesCancelados = clientes
                .Where(c => c.DataCancelamentoCadastro != null)
                .ToList();

            if (!clientesCancelados.Any())
            {
                Console.WriteLine("Não existem clientes cancelados na base");
                return 0;
            }
            
            foreach (var cliente in clientesCancelados)
            {
                var diasCancelado = (cliente.DataCancelamentoCadastro.Value - cliente.DataCadastro).TotalDays;

                Console.WriteLine(
                   $"{cliente.Id} {cliente.NomeCompleto} {cliente.Cpf} {cliente.Endereco} {cliente.Bairro} " +
                   $"{cliente.Idade} anos {cliente.DataCadastro} {cliente.DataCancelamentoCadastro} {diasCancelado} dias cancelado"
                );
            }

            return clientesCancelados.Count;
        }
    }
}
