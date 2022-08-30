using System;
using System.Collections.Generic;
using System.Text;

namespace AgendamentoServico.Client.Models
{
    public class Agendamento
    {
        public DateTime DataContrato { get; set; }
        public DateTime PrazoEntrega { get; set; }
        public int IdProfissional { get; set; }
        public int IdCliente { get; set; }
        public int IdServico { get; set; }
    }
}
