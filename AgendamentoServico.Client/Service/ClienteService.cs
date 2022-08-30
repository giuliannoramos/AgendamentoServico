using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using AgendamentoServico.Client.Dtos;
using AgendamentoServico.Client.Extensions;
using AgendamentoServico.Client.Models;
using Newtonsoft.Json;

namespace AgendamentoServico.Client.Service
{
    class ClienteService
    {
        public void Cadastrar(Cliente cliente)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var viewModel = new
            {
                cliente = cliente,
            };

            try
            {                                
                response = httpClient.UpdateAsJsonAsync($"https://localhost:44311/cliente/create", viewModel).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine(response);
                }              

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Atualizar(int id, ClienteDto cliente)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var viewModel = new
            {
                cliente = cliente,
                id
            };

            try
            {                              
                response = httpClient.UpdateAsJsonAsync($"https://localhost:44311/cliente/update", viewModel).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine(response);
                }

                //converte os dados recebidos e retorna eles como objetos do C#;

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Deletar(int id)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var viewModel = new
            {
                id
            };

            try
            {
                response = httpClient.DeleteAsJsonAsync($"https://localhost:44311/cliente/delete", viewModel).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine(response);
                }

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
