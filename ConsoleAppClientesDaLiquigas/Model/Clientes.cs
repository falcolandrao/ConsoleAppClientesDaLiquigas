using ConsoleAppStudent;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppClientesDaLiquigas.Model
{
    public class Clientes
    {
        private static int diferencaEmDias;

        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public int Idade { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataCancelamentoCadastro { get; set; }
        public List<TabelaDePrecos> TabelaDePrecos { get; set; }

        public static List<Clientes> ObterTodosOsClientes()
        {
            List<Clientes> dados = new List<Clientes>();
            
            
            dados.Add(new Clientes()
            {
                Id = 1,
                NomeCompleto = "Leandro de Azevedo",
                Cpf = "29796050854",
                Endereco = "Rua Teste da Silva, 123",
                Bairro = "São Mateus",
                Idade = 39,
                DataCadastro = new DateTime(2022, 01, 01),
                DataCancelamentoCadastro = new DateTime(2022, 12, 31),
                TabelaDePrecos = new List<TabelaDePrecos>()
                {
                    new TabelaDePrecos { Id = 1, PesoDoBotijao = "P13", PrecoDoBotijao = 99.99, QtdDeBotijao = 2},
                    new TabelaDePrecos { Id = 2, PesoDoBotijao = "P20", PrecoDoBotijao = 119.99, QtdDeBotijao = 1}
                }
            });

            dados.Add(new Clientes()
            {
                Id = 2,
                NomeCompleto = "Florisbela Antunes Costa",
                Cpf = "29796850420",
                Endereco = "Rua Teste da Lua, 123",
                Bairro = "Tatuapé",
                Idade = 25,
                DataCadastro = new DateTime(2015, 01, 01),
                DataCancelamentoCadastro = null,
                TabelaDePrecos = new List<TabelaDePrecos>()
                {
                    new TabelaDePrecos { Id = 1, PesoDoBotijao = "P13", PrecoDoBotijao = 99.99, QtdDeBotijao = 3},
                }
            });

            return dados;
        }

        public static void EscreverDadosNaConsole(List<Clientes> auxClientesLiquigas)
        {
            var queryListaPedidos = auxClientesLiquigas.SelectMany(auxClientes => auxClientes.TabelaDePrecos, (auxClientes, TabelaDePrecos) => new
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

            ExportData.ExportCsv(queryListaPedidos, "ListaDosClientes");

            foreach (var obj in queryListaPedidos)
            {
                Console.WriteLine(obj);
            }
        }

        public static string DataHoraCorrente()
        {
            return String.Format($"{DateTime.Now}\n");
        }

        public static int TotalDeClientes(List<Clientes> auxClientesLiquigas)
        {
            int contador = 0;

            contador = auxClientesLiquigas.Count();

            return contador;
        }

        public static double ValidaDataCancelamentoEmDias(List<Clientes> auxClientesLiquigas)
        {
            Console.WriteLine("Clientes Com Data de Cancelamento de Cadastro >>> \n");
            
            foreach (var item in auxClientesLiquigas)
            {
                if (item.DataCadastro != null && item.DataCancelamentoCadastro != null)
                {
                    System.TimeSpan difDatas = ((TimeSpan)(item.DataCancelamentoCadastro - item.DataCadastro));

                    double auxDifEmDias = difDatas.TotalDays;

                    Console.WriteLine(string.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8}", item.Id, item.NomeCompleto, item.Cpf, item.Endereco,
                    item.Bairro, item.Idade + " anos ", item.DataCadastro, item.DataCancelamentoCadastro, auxDifEmDias + " dias cancelado "));
                }
 
            }
            
            return diferencaEmDias;
        }
    }

    public class TabelaDePrecos
    {
        public int Id { get; set; }
        public string PesoDoBotijao { get; set; }
        public double PrecoDoBotijao { get; set; }
        public int QtdDeBotijao { get; set; }
    }
}