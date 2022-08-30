using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using AgendamentoServico.Client.Dtos;
using AgendamentoServico.Client.Extensions;
using Newtonsoft.Json;

namespace AgendamentoServico.Client.Service
{
    public class ProfissionalService
    {
        public void Cadastrar(Profissional profissional)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var viewModel = new
            {
                profissional = profissional,                
            };

            try
            {    
                response = httpClient.CreateAsJsonAsync($"https://localhost:44311/profissional/create", viewModel).Result;

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

        public void Atualizar(int id, ProfissionalDto profissional)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var viewModel = new
            {
                profissional = profissional,
                id
            };

            try
            {   
                response = httpClient.UpdateAsJsonAsync($"https://localhost:44311/profissional/update", viewModel).Result;                

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
                response = httpClient.DeleteAsJsonAsync($"https://localhost:44311/profissional/delete", viewModel).Result;
                
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
