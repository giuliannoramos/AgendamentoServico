using System;
using System.Collections.Generic;
using System.Text;

namespace AgendamentoServico.Client.Dtos
{
    public class AgendamentoDto
    {
        public int Id { get; set; }
        public DateTime DataContrato { get; set; }
        public DateTime PrazoEntrega { get; set; }
        public int IdProfissional { get; set; }
        public int IdCliente { get; set; }
        public int IdServico { get; set; }
    }
}
