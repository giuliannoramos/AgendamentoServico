using System;
using System.Collections.Generic;
using System.Text;

namespace AgendamentoServico.Client.Dtos
{
    class ProfissionalDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Especialidade { get; set; }
    }
}
