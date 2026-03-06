using ConsoleAppClientesDaLiquigas.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppClientesDaLiquigas.Data
{
    public class ClientesRepository
    {
        private List<Clientes> clientes = new List<Clientes>
        { 
            new Clientes 
            { 
                Id = 1,
                NomeCompleto = "Leandro de Azevedo",
                Cpf = "29090050050",
                Endereco = "Rua Teste da Silva, 123",
                Bairro = "São Teste da Silva",
                Idade = 40,
                DataCadastro = new DateTime(2022, 01, 01),
                DataCancelamentoCadastro = new DateTime(2023, 01, 01),
                EstaAtivo = false,
                TabelaDePrecos = new List<TabelaDePrecos>()
                    {
                        new TabelaDePrecos { Id = 1, PesoDoBotijao = "P13", PrecoDoBotijao = 99.99, QtdDeBotijao = 2},
                        new TabelaDePrecos { Id = 2, PesoDoBotijao = "P20", PrecoDoBotijao = 119.99, QtdDeBotijao = 1}
                    }
            },

            new Clientes
            {
                Id = 2,
                NomeCompleto = "Florisbela Antunes Costa",
                Cpf = "29796850420",
                Endereco = "Rua Teste da Lua, 123",
                Bairro = "Tatuapé",
                Idade = 25,
                DataCadastro = new DateTime(2015, 01, 01),
                DataCancelamentoCadastro = new DateTime(2015, 10, 01),
                EstaAtivo = false,
                TabelaDePrecos = new List<TabelaDePrecos>()
                {
                    new TabelaDePrecos { Id = 1, PesoDoBotijao = "P13", PrecoDoBotijao = 99.99, QtdDeBotijao = 3},
                }
            }

        };

        public List<Clientes> ObterClientes()
        {
            return clientes;
        }

    }
}
