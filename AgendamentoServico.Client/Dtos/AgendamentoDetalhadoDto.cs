using System;
using System.Collections.Generic;
using System.Text;

namespace AgendamentoServico.Client.Dtos
{
    public class AgendamentoDetalhadoDto
    {
        public int Id { get; set; }
        public DateTime DataContrato { get; set; }
        public DateTime PrazoEntrega { get; set; }
        public int IdProfissional { get; set; }
        public string NomeProfissional { get; set; }
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public int IdServico { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
    }
}
