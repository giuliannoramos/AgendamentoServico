using System;
using System.Collections.Generic;
using System.Text;

namespace AgendamentoServico.Client.Dtos
{
    public class ServicoDto
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
    }
}
