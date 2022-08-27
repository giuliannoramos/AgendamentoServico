﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using AgendamentoServico.Client.Dtos;
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
                var json = JsonConvert.SerializeObject(viewModel);
                //monta a request para a api;                
                response = httpClient.PostAsync($"https://localhost:44311/cliente/create", new StringContent(json, Encoding.UTF8, "application/json")).Result;

                var resultado = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine(resultado);
                }

                //converte os dados recebidos e retorna eles como objetos do C#;

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Atualizar(int id, Cliente cliente)
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
                var json = JsonConvert.SerializeObject(viewModel);
                //monta a request para a api;                
                response = httpClient.PutAsync($"https://localhost:44311/cliente/update", new StringContent(json, Encoding.UTF8, "application/json")).Result;

                var resultado = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine(resultado);
                }

                //converte os dados recebidos e retorna eles como objetos do C#;

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
