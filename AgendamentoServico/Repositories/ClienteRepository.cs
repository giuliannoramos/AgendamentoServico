using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace AgendamentoServico.Models
{
    public class ClienteRepository
    {
        private readonly string _connection = @"Data Source=ITELABD12\SQLEXPRESS; Initial Catalog=AgendamentoServico; Integrated Security=True;";
        public bool CreateCliente(Cliente cliente)
        {            
            try
            {
                var query = @"INSERT INTO Cliente 
                              (Nome, Cpf, DataNascimento, Endereco, Email)                              
                              VALUES (@nome,@cpf,@dataNascimento,@endereco,@email)";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@nome", cliente.Nome);
                    command.Parameters.AddWithValue("@cpf", cliente.Cpf);
                    command.Parameters.AddWithValue("@dataNascimento", cliente.DataNascimento);
                    command.Parameters.AddWithValue("@endereco", cliente.Endereco);
                    command.Parameters.AddWithValue("@email", cliente.Email);
                    command.Connection.Open();
                    command.ExecuteScalar();
                }

                Console.WriteLine("Cliente cadastrado com sucesso.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }
        }

        public List<ClienteDto> ReadAllCliente()
        {
            List<ClienteDto> clientesEncontrados;
            try
            {
                var query = @"SELECT Id, Nome, Cpf, DataNascimento, Endereco, Email FROM Cliente";

                using (var connection = new SqlConnection(_connection))
                {
                    clientesEncontrados = connection.Query<ClienteDto>(query).ToList();
                }

                return clientesEncontrados;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }

        public bool UpdateCliente(ClienteDto cliente, int id)
        {
            try
            {
                var query = @"UPDATE Cliente SET Nome = @nome, Cpf = @cpf, DataNascimento = @dataNascimento, Endereco = @endereco, Email = @email WHERE Id = @id";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@nome", cliente.Nome);
                    command.Parameters.AddWithValue("@cpf", cliente.Cpf);
                    command.Parameters.AddWithValue("@dataNascimento", cliente.DataNascimento);
                    command.Parameters.AddWithValue("@endereco", cliente.Endereco);
                    command.Parameters.AddWithValue("@email", cliente.Email);
                    command.Connection.Open();
                    command.ExecuteScalar();
                }

                Console.WriteLine("Cliente atualizado com sucesso.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }
        }

        public bool DeleteCliente(int id)
        {
            try
            {
                var query = "DELETE FROM Cliente " +
                    "WHERE Id= @id";

                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@id", id);
                    command.Connection.Open();
                    command.ExecuteScalar();
                }

                Console.WriteLine("Cliente Removido com sucesso.");
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
