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
    class AgendamentoService
    {
        public void Cadastrar(Agendamento agendamento)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var viewModel = new
            {
                agendamento = agendamento,
            };

            try
            {
                response = httpClient.CreateAsJsonAsync($"https://localhost:44311/agendamento/create", viewModel).Result;

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

        public void Atualizar(int id, AgendamentoDto agendamento)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var viewModel = new
            {
                agendamento = agendamento,
                id
            };

            try
            {
                response = httpClient.UpdateAsJsonAsync($"https://localhost:44311/agendamento/update", viewModel).Result;

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
                response = httpClient.DeleteAsJsonAsync($"https://localhost:44311/agendamento/delete", viewModel).Result;

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
