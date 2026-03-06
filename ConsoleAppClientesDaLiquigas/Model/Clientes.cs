using System;
using System.Collections.Generic;

namespace ConsoleAppClientesDaLiquigas.Model
{
    public class Clientes
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public int Idade { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataCancelamentoCadastro { get; set; }
        public bool EstaAtivo { get; set; }

        public List<TabelaDePrecos> TabelaDePrecos { get; set; }
    }
}