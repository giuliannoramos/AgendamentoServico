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
            int IdServicoCriado = -1;
            try
            {
                var query = @"INSERT INTO Servico 
                              (Tipo, Descricao, Valor) 
                              OUTPUT Inserted.Id
                              VALUES (@tipo,@descricao,@valor)";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@tipo", servico.Tipo);
                    command.Parameters.AddWithValue("@descricao", servico.Descricao);
                    command.Parameters.AddWithValue("@valor", servico.Valor);                    
                    command.Connection.Open();
                    IdServicoCriado = (int)command.ExecuteScalar();
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
    }
}
