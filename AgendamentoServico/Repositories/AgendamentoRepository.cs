using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using AgendamentoServico.Dtos;

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

        public bool UpdateAgendamento(AgendamentoDto agendamento, int id)
        {
            try
            {
                var query = @"UPDATE Agendamento SET DataContrato=@dataContrato, PrazoEntrega=@prazoEntrega, IdProfissional=@idProfissional, IdCliente=@idCliente, IdServico=@idServico WHERE Id = @id";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@id", id);
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

        public bool DeleteAgendamento(int id)
        {
            try
            {
                var query = "DELETE FROM Agendamento " +
                    "WHERE Id= @id";

                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@id", id);
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

        public List<AgendamentoDetalhadoDto> ListarAgendamentosParaHojeDetalhado()
        {
            List<AgendamentoDetalhadoDto> agendamentosEncontrados;
            try
            {                
                var query = @"SELECT a.Id, a.DataContrato, a.PrazoEntrega, a.IdProfissional, p.Nome, a.IdCliente, c.Nome, a.IdServico, s.Tipo, s.Descricao, s.Valor FROM Agendamento a
                              INNER JOIN Profissional p ON p.Id = a.IdProfissional
                              INNER JOIN Cliente c ON c.Id = a.IdCliente
                              INNER JOIN Servico s ON s.Id = a.IdServico
                              WHERE PrazoEntrega > getdate() - 1 and PrazoEntrega < getdate() + 1";

                using (var connection = new SqlConnection(_connection))
                {                                      
                    agendamentosEncontrados = connection.Query<AgendamentoDetalhadoDto>(query).ToList();                    
                }

                return agendamentosEncontrados;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);                
                return null;                
            }
        }
    }
}
