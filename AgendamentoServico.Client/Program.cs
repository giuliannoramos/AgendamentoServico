using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using AgendamentoServico.Client.Service;

namespace AgendamentoServico.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var profissionalService = new ProfissionalService();

            Console.WriteLine("\n\n Informe a operação desejada:");
            Console.WriteLine(" 1 - Cadastrar um profissional.");
            Console.WriteLine(" 2 - Cadastrar um cliente.");
            Console.WriteLine(" 3 - Cadastrar um serviço.");
            Console.WriteLine(" 4 - Cadastrar um agendamento.");
            Console.WriteLine(" 5 - Listar profissionais cadastrados.");
            Console.WriteLine(" 6 - Listar clientes cadastrados.");
            Console.WriteLine(" 7 - Listar serviços cadastrados.");
            Console.WriteLine(" 8 - Listar agendamentos cadastrados.");
            Console.WriteLine(" 9 - Atualizar um cadastro de profissional.");
            Console.WriteLine(" 10 - Atualizar um cadastro de cliente.");
            Console.WriteLine(" 11 - Atualizar um cadastro de serviço.");
            Console.WriteLine(" 12 - Atualizar um cadastro de agendamento.");
            Console.WriteLine(" 13 - Remover um profissional cadastrado.");
            Console.WriteLine(" 14 - Remover um cliente cadastrado.");
            Console.WriteLine(" 15 - Remover um serviço cadastrado.");
            Console.WriteLine(" 16 - Remover um agendamento cadastrado.");
            Console.WriteLine(" 0 - Sair");
            int opcao = Convert.ToInt32(Console.ReadLine());
            while (opcao != 0)
            {
                if (opcao == 1)
                {

                }

                else if (opcao == 2)
                {
                    
                }

                else if (opcao == 3)
                {
                    
                }

                else if (opcao == 4)
                {
                    
                }

                else if (opcao == 5)
                {
                    
                }

                else if (opcao == 6)
                {                    
                    
                }

                else if (opcao == 7)
                {
                    
                }

                else if (opcao == 8)
                {

                }

                else if (opcao == 9)
                {
                    Console.WriteLine("Informe o id do profissional para atualizar:");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("\nInsira os novos dados do profissional:");                    
                    Console.WriteLine("Nome");                    
                    Console.WriteLine("Cnpj");                    
                    Console.WriteLine("Email");                    
                    Console.WriteLine("Especialidade");                    

                    var profissional = new Profissional()
                    {
                        Nome = Console.ReadLine(),
                        Cnpj = Console.ReadLine(),
                        Email = Console.ReadLine(),
                        Especialidade = Console.ReadLine(),                        
                    };

                    profissionalService.Atualizar(id, profissional);
                    Console.WriteLine("\nProfissional atualizado com sucesso.");
                }

                else if (opcao == 10)
                {

                }

                else if (opcao == 11)
                {

                }

                else if (opcao == 12)
                {

                }

                else if (opcao == 13)
                {
                
                }

                else if (opcao == 14)
                {

                }

                else if (opcao == 15)
                {

                }

                else if (opcao == 16)
                {

                }

                Console.WriteLine("\n\n Informe a operação desejada:");
                Console.WriteLine(" 1 - Cadastrar um profissional.");
                Console.WriteLine(" 2 - Cadastrar um cliente.");
                Console.WriteLine(" 3 - Cadastrar um serviço.");
                Console.WriteLine(" 4 - Cadastrar um agendamento.");
                Console.WriteLine(" 5 - Listar profissionais cadastrados.");
                Console.WriteLine(" 6 - Listar clientes cadastrados.");
                Console.WriteLine(" 7 - Listar serviços cadastrados.");
                Console.WriteLine(" 8 - Listar agendamentos cadastrados.");
                Console.WriteLine(" 9 - Atualizar um cadastro de profissional.");
                Console.WriteLine(" 10 - Atualizar um cadastro de cliente.");
                Console.WriteLine(" 11 - Atualizar um cadastro de serviço.");
                Console.WriteLine(" 12 - Atualizar um cadastro de agendamento.");
                Console.WriteLine(" 13 - Remover um profissional cadastrado.");
                Console.WriteLine(" 14 - Remover um cliente cadastrado.");
                Console.WriteLine(" 15 - Remover um serviço cadastrado.");
                Console.WriteLine(" 16 - Remover um agendamento cadastrado.");
                Console.WriteLine(" 0 - Sair");
                opcao = Convert.ToInt32(Console.ReadLine());
            }

        }

       
    }
}
