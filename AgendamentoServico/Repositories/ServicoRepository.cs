using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace AgendamentoServico.Repositories
{
    public class ServicoRepository
    {
        private readonly string _connection = @"Data Source=ITELABD12\SQLEXPRESS; Initial Catalog=AgendamentoServico; Integrated Security=True;";
        public bool CreateServico(Servico servico)
        {            
            try
            {
                var query = @"INSERT INTO Servico 
                              (Tipo, Descricao, Valor)                              
                              VALUES (@tipo,@descricao,@valor)";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@tipo", servico.Tipo);
                    command.Parameters.AddWithValue("@descricao", servico.Descricao);
                    command.Parameters.AddWithValue("@valor", servico.Valor);                    
                    command.Connection.Open();
                    command.ExecuteScalar();
                }

                Console.WriteLine("Serviço cadastrado com sucesso.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }
        }

        public List<ServicoDto> ReadAllServico()
        {
            List<ServicoDto> servicosEncontrados;
            try
            {
                var query = @"SELECT Id, Tipo, Descricao, Valor FROM Servico";

                using (var connection = new SqlConnection(_connection))
                {
                    servicosEncontrados = connection.Query<ServicoDto>(query).ToList();
                }

                return servicosEncontrados;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }

        public bool UpdateServico(ServicoDto servico, int id)
        {
            try
            {
                var query = @"UPDATE Servico SET Tipo = @tipo, Descricao = @descricao, Valor = @valor WHERE Id = @id";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@tipo", servico.Tipo);
                    command.Parameters.AddWithValue("@descricao", servico.Descricao);
                    command.Parameters.AddWithValue("@valor", servico.Valor);                    
                    command.Connection.Open();
                    command.ExecuteScalar();
                }

                Console.WriteLine("Serviço atualizado com sucesso.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }
        }

        public bool DeleteServico(int id)
        {
            try
            {
                var query = "DELETE FROM Servico " +
                    "WHERE Id= @id";

                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@id", id);
                    command.Connection.Open();
                    command.ExecuteScalar();
                }

                Console.WriteLine("Serviço removido com sucesso.");
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
