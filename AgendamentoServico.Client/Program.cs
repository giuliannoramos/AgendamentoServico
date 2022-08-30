using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using AgendamentoServico.Client.Service;
using AgendamentoServico.Client.Dtos;
using AgendamentoServico.Client.Models;

namespace AgendamentoServico.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var profissionalService = new ProfissionalService();
            var clienteService = new ClienteService();
            var servicoService = new ServicoService();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\n Informe a operação desejada:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" 1 - Cadastrar um profissional.");
            Console.WriteLine(" 2 - Cadastrar um cliente.");
            Console.WriteLine(" 3 - Cadastrar um serviço.");
            Console.WriteLine(" 4 - Cadastrar um agendamento.");
            Console.WriteLine("\n 5 - Listar profissionais cadastrados.");
            Console.WriteLine(" 6 - Listar clientes cadastrados.");
            Console.WriteLine(" 7 - Listar serviços cadastrados.");
            Console.WriteLine(" 8 - Listar agendamentos cadastrados.");
            Console.WriteLine("\n 9 - Atualizar um cadastro de profissional.");
            Console.WriteLine(" 10 - Atualizar um cadastro de cliente.");
            Console.WriteLine(" 11 - Atualizar um cadastro de serviço.");
            Console.WriteLine(" 12 - Atualizar um cadastro de agendamento.");
            Console.WriteLine("\n 13 - Remover um profissional cadastrado.");
            Console.WriteLine(" 14 - Remover um cliente cadastrado.");
            Console.WriteLine(" 15 - Remover um serviço cadastrado.");
            Console.WriteLine(" 16 - Remover um agendamento cadastrado.");
            Console.WriteLine(" 0 - Sair");
            int opcao = Convert.ToInt32(Console.ReadLine());
            while (opcao != 0)
            {
                if (opcao == 1)
                {
                    Console.WriteLine("\nInsira os dados do profissional:");
                    Console.WriteLine("Nome");
                    Console.WriteLine("Cnpj");
                    Console.WriteLine("Email");
                    Console.WriteLine("Especialidade\n");

                    var profissional = new Profissional()
                    {
                        Nome = Console.ReadLine(),
                        Cnpj = Console.ReadLine(),
                        Email = Console.ReadLine(),
                        Especialidade = Console.ReadLine(),
                    };

                    profissionalService.Cadastrar(profissional);
                    Console.WriteLine("\n Profissional cadastrado com sucesso.");
                }

                else if (opcao == 2)
                {
                    Console.WriteLine("\nInsira os dados do cliente:");
                    Console.WriteLine("Nome");
                    Console.WriteLine("Cpf");
                    Console.WriteLine("Data de Nascimento");
                    Console.WriteLine("Endereço");
                    Console.WriteLine("Email\n");

                    var cliente = new Cliente()
                    {
                        Nome = Console.ReadLine(),
                        Cpf = Console.ReadLine(),
                        DataNascimento = Convert.ToDateTime(Console.ReadLine()),
                        Endereco = Console.ReadLine(),
                        Email = Console.ReadLine(),
                    };

                    clienteService.Cadastrar(cliente);
                    Console.WriteLine("\n Cliente cadastrado com sucesso.");
                }

                else if (opcao == 3)
                {
                    Console.WriteLine("\nInsira os dados do serviço:");
                    Console.WriteLine("Tipo");
                    Console.WriteLine("Descrição");
                    Console.WriteLine("Valor\n");                    

                    var servico = new Servico()
                    {
                        Tipo = Console.ReadLine(),
                        Descricao = Console.ReadLine(),
                        Valor = Convert.ToInt32(Console.ReadLine()),                        
                    };

                    servicoService.Cadastrar(servico);
                    Console.WriteLine("\n Serviço cadastrado com sucesso.");
                }

                else if (opcao == 4)
                {
                    
                }

                else if (opcao == 5)
                {
                    var resultado = ListarProfissionais();
                    //mostra os dados na tela                    
                    foreach (var item in resultado)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n=====================================");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Id: " + item.Id);
                        Console.WriteLine("Nome: " + item.Nome);
                        Console.WriteLine("Cnpj: " + item.Cnpj);
                        Console.WriteLine("Email: " + item.Email);
                        Console.WriteLine("Especialidade: " + item.Especialidade);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("=====================================");
                        Console.ForegroundColor = ConsoleColor.White;
                    }                    
                }

                else if (opcao == 6)
                {
                    var resultado = ListarClientes();
                    //mostra os dados na tela                    
                    foreach (var item in resultado)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n=====================================");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Id: " + item.Id);
                        Console.WriteLine("Nome: " + item.Nome);
                        Console.WriteLine("Cpf: " + item.Cpf);
                        Console.WriteLine("Data de Nascimento: " + item.DataNascimento);
                        Console.WriteLine("Endereço: " + item.Endereco);
                        Console.WriteLine("Email: " + item.Email);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("=====================================");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }

                else if (opcao == 7)
                {
                    var resultado = ListarServicos();
                    //mostra os dados na tela                    
                    foreach (var item in resultado)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n=====================================");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Id: " + item.Id);
                        Console.WriteLine("Tipo: " + item.Tipo);
                        Console.WriteLine("Descrição: " + item.Descricao);
                        Console.WriteLine("Valor: " + item.Valor);                        
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("=====================================");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
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
                    Console.WriteLine("Especialidade\n");                    

                    var profissional = new Profissional()
                    {
                        Nome = Console.ReadLine(),
                        Cnpj = Console.ReadLine(),
                        Email = Console.ReadLine(),
                        Especialidade = Console.ReadLine(),                        
                    };

                    profissionalService.Atualizar(id, profissional);
                    Console.WriteLine("\n Profissional atualizado com sucesso.");
                }

                else if (opcao == 10)
                {
                    Console.WriteLine("Informe o id do cliente para atualizar:");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("\nInsira os novos dados do cliente:");
                    Console.WriteLine("Nome");
                    Console.WriteLine("Cpf");
                    Console.WriteLine("Data de nascimento");
                    Console.WriteLine("Endereço");
                    Console.WriteLine("Email\n");

                    var cliente = new Cliente()
                    {
                        Nome = Console.ReadLine(),
                        Cpf = Console.ReadLine(),
                        DataNascimento = Convert.ToDateTime(Console.ReadLine()),
                        Endereco = Console.ReadLine(),
                        Email = Console.ReadLine(),
                    };

                    clienteService.Atualizar(id, cliente);
                    Console.WriteLine("\n Cliente atualizado com sucesso.");
                }

                else if (opcao == 11)
                {
                    Console.WriteLine("Informe o id do serviço para atualizar:");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("\nInsira os novos dados do serviço:");
                    Console.WriteLine("Tipo");
                    Console.WriteLine("Descrição");
                    Console.WriteLine("Valor\n");                    

                    var servico = new Servico()
                    {
                        Tipo = Console.ReadLine(),
                        Descricao = Console.ReadLine(),
                        Valor = Convert.ToInt32(Console.ReadLine()),                        
                    };

                    servicoService.Atualizar(id, servico);
                    Console.WriteLine("\n Serviço atualizado com sucesso.");
                }

                else if (opcao == 12)
                {

                }

                else if (opcao == 13)
                {
                    Console.WriteLine("Informe o id do profissional para deletar:");
                    int id = Convert.ToInt32(Console.ReadLine());

                    profissionalService.Deletar(id);
                    Console.WriteLine("\nProfissional deletado com sucesso.");
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

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\n Informe a operação desejada:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" 1 - Cadastrar um profissional.");
                Console.WriteLine(" 2 - Cadastrar um cliente.");
                Console.WriteLine(" 3 - Cadastrar um serviço.");
                Console.WriteLine(" 4 - Cadastrar um agendamento.");
                Console.WriteLine("\n 5 - Listar profissionais cadastrados.");
                Console.WriteLine(" 6 - Listar clientes cadastrados.");
                Console.WriteLine(" 7 - Listar serviços cadastrados.");
                Console.WriteLine(" 8 - Listar agendamentos cadastrados.");
                Console.WriteLine("\n 9 - Atualizar um cadastro de profissional.");
                Console.WriteLine(" 10 - Atualizar um cadastro de cliente.");
                Console.WriteLine(" 11 - Atualizar um cadastro de serviço.");
                Console.WriteLine(" 12 - Atualizar um cadastro de agendamento.");
                Console.WriteLine("\n 13 - Remover um profissional cadastrado.");
                Console.WriteLine(" 14 - Remover um cliente cadastrado.");
                Console.WriteLine(" 15 - Remover um serviço cadastrado.");
                Console.WriteLine(" 16 - Remover um agendamento cadastrado.");
                Console.WriteLine(" 0 - Sair");
                opcao = Convert.ToInt32(Console.ReadLine());
            }
        }

        public static List<ProfissionalDto> ListarProfissionais()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            //Busca todos os clientes dentro da api;
            try
            {
                //monta a request para a api;
                response = httpClient.GetAsync("https://localhost:44311/profissional/readall").Result;
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine(resultado);
                    return new List<ProfissionalDto>();
                }
                //converte os dados recebidos e retorna eles como objetos do C#;
                var objetoDesserializado = JsonConvert.DeserializeObject<List<ProfissionalDto>>(resultado);

                return objetoDesserializado;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return new List<ProfissionalDto>();
            }
        }

        public static List<ClienteDto> ListarClientes()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            //Busca todos os clientes dentro da api;
            try
            {
                //monta a request para a api;
                response = httpClient.GetAsync("https://localhost:44311/cliente/readall").Result;
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine(resultado);
                    return new List<ClienteDto>();
                }
                //converte os dados recebidos e retorna eles como objetos do C#;
                var objetoDesserializado = JsonConvert.DeserializeObject<List<ClienteDto>>(resultado);

                return objetoDesserializado;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return new List<ClienteDto>();
            }
        }

        public static List<ServicoDto> ListarServicos()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            //Busca todos os clientes dentro da api;
            try
            {
                //monta a request para a api;
                response = httpClient.GetAsync("https://localhost:44311/servico/readall").Result;
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine(resultado);
                    return new List<ServicoDto>();
                }
                //converte os dados recebidos e retorna eles como objetos do C#;
                var objetoDesserializado = JsonConvert.DeserializeObject<List<ServicoDto>>(resultado);

                return objetoDesserializado;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return new List<ServicoDto>();
            }
        }
               
    }
}
