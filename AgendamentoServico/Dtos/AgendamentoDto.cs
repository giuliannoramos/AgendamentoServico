using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoServico
{
    public class AgendamentoDto
    {
        public int Id { get; set; }
        public DateTime DataContrato { get; set; }
        public DateTime PrazoEntrega { get; set; }
        ProfissionalDto IdProfissional { get; set; }
        ClienteDto IdCliente { get; set; }
        ServicoDto IdServico { get; set; }
    }
}
