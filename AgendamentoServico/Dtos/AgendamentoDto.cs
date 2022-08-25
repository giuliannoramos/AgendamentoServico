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
        public ProfissionalDto IdProfissional { get; set; }
        public ClienteDto IdCliente { get; set; }
        public ServicoDto IdServico { get; set; }
    }
}
