using System;
using System.Collections.Generic;
using System.Text;

namespace AgendamentoServico.Client.Models
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
    }
}
