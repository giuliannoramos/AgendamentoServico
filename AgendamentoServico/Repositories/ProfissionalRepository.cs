using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace AgendamentoServico.Repositories
{
    public class ProfissionalRepository
    {
        private readonly string _connection = @"Data Source=ITELABD12\SQLEXPRESS; Initial Catalog=AgendamentoServico; Integrated Security=True;";
        public bool CreateProfissional(Profissional profissional)
        {            
            try
            {
                var query = @"INSERT INTO Profissional 
                              (Nome, Cnpj, Email, Especialidade) VALUES (@nome,@cnpj,@email,@especialidade)";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@nome", profissional.Nome);
                    command.Parameters.AddWithValue("@cnpj", profissional.Cnpj);
                    command.Parameters.AddWithValue("@email", profissional.Email);
                    command.Parameters.AddWithValue("@especialidade", profissional.Especialidade);
                    command.Connection.Open();
                    command.ExecuteScalar();
                }

                Console.WriteLine("Profissional cadastrado com sucesso.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }
        }

        public List<ProfissionalDto> ReadAllProfissional()
        {
            List<ProfissionalDto> profissionaisEncontrados;
            try
            {
                var query = @"SELECT Id, Nome, Cnpj, Email, Especialidade FROM Profissional";

                using (var connection = new SqlConnection(_connection))
                {
                    profissionaisEncontrados = connection.Query<ProfissionalDto>(query).ToList();
                }

                return profissionaisEncontrados;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }       

        public bool UpdateProfissional(ProfissionalDto profissional)
        {
            try
            {
                var query = @"UPDATE Profissional SET Nome = @nome, Cnpj = @cnpj, Email = @email, Especialidade = @especialidade WHERE Id = @id";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@id", profissional.Id);
                    command.Parameters.AddWithValue("@nome", profissional.Nome);
                    command.Parameters.AddWithValue("@cnpj", profissional.Cnpj);
                    command.Parameters.AddWithValue("@email", profissional.Email);
                    command.Parameters.AddWithValue("@especialidade", profissional.Especialidade);
                    command.Connection.Open();
                    command.ExecuteScalar();
                }

                Console.WriteLine("Profissional atualizado com sucesso.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }
        }

        public bool DeleteProfissional(ProfissionalDto profissional)
        {
            try
            {
                var query = "DELETE FROM Profissional " +
                    "WHERE Id= @idProfissional";

                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);                    
                    command.Parameters.AddWithValue("@idProfissional", profissional.Id);
                    command.Connection.Open();
                    command.ExecuteScalar();
                }

                Console.WriteLine("Profissional removido com sucesso.");
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
