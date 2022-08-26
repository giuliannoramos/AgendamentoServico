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
            try
            {
                var query = @"INSERT INTO Agendamento 
                              (DataContrato, PrazoEntrega, IdProfissional, IdCliente, IdServico)                              
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
                    command.ExecuteScalar();
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

        public List<AgendamentoDto> ReadAllAgendamento()
        {
            List<AgendamentoDto> agendamentosEncontrados;
            try
            {
                var query = @"SELECT Id, DataContrato, PrazoEntrega, IdProfissional, IdCliente, IdServico FROM Agendamento";

                using (var connection = new SqlConnection(_connection))
                {
                    agendamentosEncontrados = connection.Query<AgendamentoDto>(query).ToList();
                }

                return agendamentosEncontrados;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }

        public bool UpdateAgendamento(AgendamentoDto agendamento)
        {
            try
            {
                var query = @"UPDATE Agendamento SET DataContrato=@dataContrato, PrazoEntrega=@prazoEntrega, IdProfissional=@idProfissional, IdCliente=@idCliente, IdServico=@idServico WHERE Id = @id";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@id", agendamento.Id);
                    command.Parameters.AddWithValue("@dataContrato", agendamento.DataContrato);
                    command.Parameters.AddWithValue("@prazoEntrega", agendamento.PrazoEntrega);
                    command.Parameters.AddWithValue("@idProfissional", agendamento.IdProfissional);
                    command.Parameters.AddWithValue("@idCliente", agendamento.IdCliente);
                    command.Parameters.AddWithValue("@idServico", agendamento.IdServico);
                    command.Connection.Open();
                    command.ExecuteScalar();
                }

                Console.WriteLine("Agendamento atualizado com sucesso.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }
        }

        public bool DeleteAgendamento(AgendamentoDto agendamento)
        {
            try
            {
                var query = "DELETE FROM Agendamento " +
                    "WHERE Id= @idAgendamento";

                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@idAgendamento", agendamento.Id);
                    command.Connection.Open();
                    command.ExecuteScalar();
                }

                Console.WriteLine("Agendamento removido com sucesso.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
