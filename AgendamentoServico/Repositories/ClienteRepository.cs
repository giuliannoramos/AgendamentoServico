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
            int IdClienteCriado = -1;
            try
            {
                var query = @"INSERT INTO Cliente 
                              (Nome, Cpf, DataNascimento, Endereco, Email) 
                              OUTPUT Inserted.Id
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
                    IdClienteCriado = (int)command.ExecuteScalar();
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
    }
}
