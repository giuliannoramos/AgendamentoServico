using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace AgendamentoServico.Repositories
{
    public class AgendamentoRepository
    {
        private readonly string _connection = @"Data Source=ITELABD12\SQLEXPRESS; Initial Catalog=AgendamentoServico; Integrated Security=True;";
        public bool CreateAgendamento(Agendamento agendamento)
        {
            int IdAgendamentoCriado = -1;
            try
            {
                var query = @"INSERT INTO Agendamento 
                              (DataContrato, PrazoEntrega, IdProfissional, IdCliente, IdServico) 
                              OUTPUT Inserted.Id
                              VALUES (@dataContrato,@prazoEntrega,@idProfissional,@idCliente,@idServico)";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@dataContrato", agendamento.DataContrato);
                    command.Parameters.AddWithValue("@prazoEntrega", agendamento.PrazoEntrega);
                    command.Parameters.AddWithValue("@idProfissional", agendamento.IdProfissional);
                    command.Parameters.AddWithValue("@idCliente", agendamento.IdCliente);
                    command.Parameters.AddWithValue("@idServico", agendamento.IdServico);
                    command.Connection.Open();
                    IdAgendamentoCriado = (int)command.ExecuteScalar();
                }

                Console.WriteLine("Agendamento cadastrado com sucesso.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }
        }
    }
}
